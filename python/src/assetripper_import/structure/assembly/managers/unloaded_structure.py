"""Port of Source/AssetRipper.Import/Structure/Assembly/Serializable/UnloadedStructure.cs
(Phase 16f part 2): lazy MonoBehaviour field recovery.

A MonoBehaviour's script (`m_Script` PPtr -> `MonoScript`) can be defined *later* in the same
SerializedFile (`SerializedAssetCollection` populates its assets dict strictly in file order --
see `serialized_asset_collection.py`'s `_read_data`) or in a collection loaded afterward, so its
real field layout can't be resolved while the file is still being parsed.

Two passes, matching upstream's actual (deferred) timing:
  1. `game_asset_factory.py::GameAssetFactory.read_asset` parks a raw `UnloadedMonoBehaviour`
     placeholder (this module) instead of `UnknownObject`, whenever a MonoBehaviour has no
     embedded type tree/hand-written layout AND an assembly manager was actually found.
  2. `GameStructure.__init__` calls `resolve_unloaded_mono_behaviours` exactly once, right
     after the whole `GameBundle` has finished loading -- every collection's assets are
     populated and cross-collection dependencies are wired by then, so `m_Script` resolves
     correctly as long as the MonoScript exists anywhere in the loaded bundle. Each
     placeholder is replaced in its collection via `AssetCollection.replace_asset` (ported
     from upstream in an earlier phase, unused until now).

Only the standard MonoBehaviour header fields present in a *release* build are modeled here
(`m_GameObject`, `m_Enabled`, `m_Script`, `m_Name`, `m_EditorClassIdentifier`) -- no
`m_PrefabParentObject`/`m_PrefabInternal`/etc., the exact same "release-format fields only"
precedent `asset_creation/layouts/game_object.py` already established for GameObject.
`m_GameObject` matters beyond cosmetics: it's what lets the recovered component attach to the
right GameObject in the exported scene; `m_Name` is what `StructureBackedAsset.name` picks up.

If resolution fails for any reason (script PPtr null, MonoScript itself unreadable, assembly
not found/not parseable, field signature this port can't resolve -- see mono_manager.py's own
decline rules) the placeholder is replaced with a plain `UnknownObject`, i.e. exactly today's
pre-16f behavior for that asset.
"""
from __future__ import annotations

from assetripper_assets.null_object import NullObject
from assetripper_io_endian.endian_span_reader import EndianSpanReader
from assetripper_io_files.special_file_names import fix_assembly_name
from assetripper_serialization_logic.primitive_type import PrimitiveType
from assetripper_serialization_logic.serializable_pointer_type import SerializablePointerType
from assetripper_serialization_logic.serializable_type import Field, SerializableType

from ....asset_creation.raw_data_object import RawDataObject, UnknownObject
from ....asset_creation.type_tree_object import StructureBackedAsset

_MONO_SCRIPT_CLASS_ID = 115


class UnloadedMonoBehaviour(RawDataObject):
    """First-pass placeholder. Never observed outside `GameStructure.__init__` --
    `resolve_unloaded_mono_behaviours` always replaces every instance (with either a real
    resolved asset or a plain `UnknownObject`) before returning control to any caller."""

    @property
    def name(self) -> str:
        return f"UnloadedMonoBehaviour_{self.raw_data_hash:X}"


def _bool_leaf() -> SerializableType:
    result = SerializableType(None, PrimitiveType.BOOL, "bool")
    result.max_depth = 0
    return result


def _string_leaf() -> SerializableType:
    result = SerializableType(None, PrimitiveType.STRING, "string")
    result.max_depth = 0
    return result


_HEADER_FIELDS: "tuple[Field, ...]" = (
    Field(SerializablePointerType.shared(), 0, "m_GameObject", False),
    Field(_bool_leaf(), 0, "m_Enabled", True),
    Field(SerializablePointerType.shared(), 0, "m_Script", False),
    Field(_string_leaf(), 0, "m_Name", False),
    Field(_string_leaf(), 0, "m_EditorClassIdentifier", False),
)


def _header_type() -> SerializableType:
    result = SerializableType(None, PrimitiveType.COMPLEX, "MonoBehaviourHeader")
    result.fields = list(_HEADER_FIELDS)
    result.max_depth = 1
    return result


def _resolve_pptr(collection, pptr):
    if pptr is None or pptr.path_id == 0:
        return None
    return collection.get_asset_by_pptr(pptr.to_pptr(), NullObject)


def resolve_unloaded_mono_behaviours(bundle, assembly_manager) -> None:
    """Call exactly once, right after the whole `GameBundle` has finished loading."""
    for asset in list(bundle.fetch_assets_in_hierarchy()):
        if not isinstance(asset, UnloadedMonoBehaviour):
            continue
        resolved = _try_resolve(asset, assembly_manager)
        replacement = resolved if resolved is not None else UnknownObject(asset.asset_info, asset.raw_data)
        asset.collection.replace_asset(replacement)


def _try_resolve(asset: UnloadedMonoBehaviour, assembly_manager):
    collection = asset.collection
    version = collection.version
    flags = collection.flags

    header_structure = _header_type().create_serializable_structure()
    try:
        header_structure.read(EndianSpanReader(asset.raw_data, collection.endian_type), version, flags)
    except Exception:  # noqa: BLE001 -- a layout mismatch here just means "can't resolve"
        return None

    script = _resolve_pptr(collection, header_structure["m_Script"])
    if script is None or getattr(script, "class_id", None) != _MONO_SCRIPT_CLASS_ID:
        return None

    class_name = script.get("m_ClassName") or ""
    if not class_name:
        return None  # injected/empty script identity -- nothing to resolve against
    namespace = script.get("m_Namespace") or ""
    assembly = fix_assembly_name(script.get("m_AssemblyName") or "")

    serializable_type = assembly_manager.get_serializable_type(assembly, namespace, class_name)
    if serializable_type is None:
        return None

    combined = SerializableType(serializable_type.namespace, PrimitiveType.COMPLEX, serializable_type.name)
    combined.fields = list(_HEADER_FIELDS) + list(serializable_type.fields)
    combined.max_depth = max((field.type.max_depth + 1 for field in combined.fields), default=0)

    structure = combined.create_serializable_structure()
    ok, _error = structure.try_read(EndianSpanReader(asset.raw_data, collection.endian_type), version, flags)
    if not ok:
        return None

    return StructureBackedAsset(asset.asset_info, structure)

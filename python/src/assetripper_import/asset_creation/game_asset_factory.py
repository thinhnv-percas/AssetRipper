"""
Port of the type-tree-driven parts of
Source/AssetRipper.Import/AssetCreation/GameAssetFactory.cs.

Upstream `ReadAsset` resolves an asset's layout in this order:
  1. `AssetFactory.CreateSerialized(assetInfo, version)` -- a generated class for the class
     ID and Unity version, from AssetRipper.SourceGenerated
  2. `TypeTreeNodeStruct.TryMakeFromTpk(...)` -- the Tpk type-tree database
  3. `UnknownObject`

Neither (1) nor (2) is available to this port, so the order here is:
  1. the SerializedFile's own embedded type tree (`SerializedType.old_type`)
  2. a hand-written layout, if one is registered for the class ID (see
     asset_creation.layouts for what's covered and why the rest isn't)
  3. `UnknownObject`

MonoBehaviours (class ID 114) follow upstream's structure: with an embedded type tree they
read like any other asset via SerializableTreeType.FromRootNode(root, monoBehaviourStructure:
True). Without one, upstream falls back to `UnloadedStructure`, which resolves the script's
fields from IL through the assembly manager. Phase 16f ports this for the Mono backend: with
an `assembly_manager` configured (see `game_structure.py`), a MonoBehaviour with no type tree
becomes an `UnloadedMonoBehaviour` placeholder instead of `UnknownObject` -- `GameStructure`
resolves every one of those for real once the whole bundle has finished loading (see
`structure.assembly.managers.unloaded_structure`'s module docstring for why that has to be a
second pass). With no assembly manager (still true for IL2CPP, or a Mono game whose `Managed/`
directory wasn't found), the behavior is unchanged: `UnknownObject`.
"""
from __future__ import annotations

from assetripper_io_endian.endian_span_reader import EndianSpanReader
from assetripper_primitives import UnityVersion

from .raw_data_object import UnknownObject, UnreadableObject
from .type_tree_object import TypeTreeObject

_MONO_BEHAVIOUR_CLASS_ID = 114
_MINIMUM_SUPPORTED_VERSION = UnityVersion(3, 5, 0)


class GameAssetFactory:
    """Stands in for upstream's GameAssetFactory. `read_asset` matches the call shape
    SerializedAssetCollection expects: `read_asset(asset_info, object_data, type_)`."""

    def __init__(self, layout_provider=..., assembly_manager=None):
        if layout_provider is ...:
            from .layouts import default_layout_provider

            layout_provider = default_layout_provider
        self.layout_provider = layout_provider
        """Callable `(class_id, version) -> TypeTreeNodeStruct | None`, used when a file
        embeds no type tree. Defaults to the hand-written layout registry
        (asset_creation.layouts); pass `None` explicitly to disable it (e.g. in tests that
        want to force UnknownObject for anything without an embedded tree)."""
        self.assembly_manager = assembly_manager
        """Phase 16f: a `MonoAssemblyManager` (or `None`, the pre-16f default) -- see this
        module's docstring for what it changes about MonoBehaviour resolution."""

    def read_asset(self, asset_info, object_data: bytes, type_):
        version = asset_info.collection.version
        if version < _MINIMUM_SUPPORTED_VERSION and not version.equals(0, 0, 0):
            # Upstream returns UnreadableObject below 3.5, the oldest version its type
            # trees cover.
            return UnreadableObject(asset_info, object_data)

        is_mono_behaviour = asset_info.class_id == _MONO_BEHAVIOUR_CLASS_ID
        root = self._resolve_root(asset_info, type_, version)
        if root is None:
            if is_mono_behaviour and self.assembly_manager is not None:
                from ..structure.assembly.managers.unloaded_structure import UnloadedMonoBehaviour

                return UnloadedMonoBehaviour(asset_info, object_data)
            return UnknownObject(asset_info, object_data)

        try:
            asset = TypeTreeObject.create(asset_info, root, is_mono_behaviour)
        except Exception:  # noqa: BLE001 -- a malformed tree shouldn't abort the whole file
            return UnknownObject(asset_info, object_data)

        reader = EndianSpanReader(object_data, asset_info.collection.endian_type)
        ok, _error = asset.fields.try_read(reader, version, asset_info.collection.flags)
        if not ok:
            return UnreadableObject(asset_info, object_data)
        return asset

    def _resolve_root(self, asset_info, type_, version: UnityVersion):
        old_type = getattr(type_, "old_type", None) if type_ is not None else None
        if old_type is not None and len(old_type.nodes) > 0:
            from ..structure.assembly.type_trees.type_tree_node_struct import TypeTreeNodeStruct

            ok, root = TypeTreeNodeStruct.try_make_from_type_tree(old_type)
            if ok:
                return root

        if self.layout_provider is not None:
            return self.layout_provider(asset_info.class_id, version)
        return None

"""
Phase 16f part 2: end-to-end tests for the actual pipeline wiring -- a MonoBehaviour with no
embedded type tree, read through a real `SerializedFile` (mirroring
test_game_asset_factory.py's approach) alongside a real MonoScript pointing at a synthetic
`.dll` (built the same way test_mono_manager_serializable_type.py does), resolved via
`resolve_unloaded_mono_behaviours` the same way `GameStructure.__init__` calls it.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_import.asset_creation.raw_data_object import UnknownObject
from assetripper_import.asset_creation.type_tree_object import StructureBackedAsset
from assetripper_import.structure.assembly.dotnet_metadata.compressed_integer import encode_type_def_or_ref
from assetripper_import.structure.assembly.dotnet_metadata.table_ids import TableId
from assetripper_import.structure.assembly.managers.mono_assembly_manager import MonoAssemblyManager
from assetripper_import.structure.assembly.managers.unloaded_structure import (
    UnloadedMonoBehaviour,
    resolve_unloaded_mono_behaviours,
)
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.virtual_file_system import VirtualFileSystem
from assetripper_primitives import UnityVersion

from ._module_builder import Coded, ModuleBuilder, wrap_pe
from ._tree_builder import unity_string

_MONO_SCRIPT_CLASS_ID = 115
_MONO_BEHAVIOUR_CLASS_ID = 114


def _pptr(file_id: int, path_id: int) -> bytes:
    return struct.pack("<iq", file_id, path_id)


def _build_dll() -> bytes:
    b = ModuleBuilder()
    h = b.heaps
    h.add_guid()
    b.add_row(TableId.MODULE, generation=0, name=h.add_string("Test.dll"), mvid=1, enc_id=0, enc_base_id=0)
    b.add_row(TableId.ASSEMBLY_REF, major_version=4, minor_version=0, build_number=0, revision_number=0,
              flags=0, public_key_or_token=h.add_blob(b""), name=h.add_string("mscorlib"), culture=h.add_string(""),
              hash_value=h.add_blob(b""))

    def type_ref(namespace: str, name: str) -> int:
        return b.add_row(
            TableId.TYPE_REF, resolution_scope=Coded("ResolutionScope", TableId.ASSEMBLY_REF, 1),
            name=h.add_string(name), namespace=h.add_string(namespace),
        )

    tr_mono_behaviour = type_ref("UnityEngine", "MonoBehaviour")

    b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("<Module>"), namespace=h.add_string(""),
        extends=Coded.null("TypeDefOrRef"), field_list=1, method_list=1,
    )
    b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("TestBehaviour"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_mono_behaviour), field_list=1, method_list=1,
    )
    b.add_row(TableId.FIELD, flags=0x0006, name=h.add_string("health"), signature=h.add_blob(bytes([0x06, 0x08])))

    return wrap_pe(b.build())


def _build_serialized_file(objects) -> "object":
    """`objects`: list of (file_id, class_id, payload) -- no embedded type tree for any of
    them, matching a stripped release build."""
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=False,
    )
    for file_id, class_id, payload in objects:
        serialized_type = SerializedType()
        serialized_type.type_id = class_id
        serialized_type.is_stripped_type = False
        serialized_type.script_type_index = -1

        obj = ObjectInfo(serialized_type)
        obj.file_id = file_id
        obj.serialized_type_index = len(builder.types)
        obj.object_data = payload
        builder.types.append(serialized_type)
        builder.objects.append(obj)

    serialized_file = builder.build()
    serialized_file.name = "sharedassets0.assets"
    return serialized_file


def _build_collection(mono_behaviour_payload: bytes, assembly_manager):
    mono_script_payload = (
        unity_string("TestBehaviour") + unity_string("TestBehaviour") + unity_string("MyGame") + unity_string("Test")
    )
    serialized_file = _build_serialized_file([
        (1, _MONO_BEHAVIOUR_CLASS_ID, mono_behaviour_payload),
        (2, _MONO_SCRIPT_CLASS_ID, mono_script_payload),
    ])
    bundle = GameBundle()
    factory = GameAssetFactory(assembly_manager=assembly_manager)
    collection = bundle.add_collection_from_serialized_file(serialized_file, factory)
    return bundle, collection


def _build_assembly_manager() -> MonoAssemblyManager:
    file_system = VirtualFileSystem()
    file_system.directory.create("/Managed")
    file_system.file.write_all_bytes("/Managed/Test.dll", _build_dll())
    return MonoAssemblyManager({"Test.dll": "/Managed/Test.dll"}, file_system)


def test_mono_behaviour_with_no_type_tree_becomes_unloaded_placeholder_when_manager_present():
    payload = _pptr(0, 0) + b"\x00\x00\x00\x00" + _pptr(0, 2) + unity_string("") + unity_string("") + struct.pack("<i", 42)
    bundle, collection = _build_collection(payload, _build_assembly_manager())
    mono_behaviour = collection.assets[1]
    assert isinstance(mono_behaviour, UnloadedMonoBehaviour)


def test_mono_behaviour_with_no_type_tree_and_no_manager_stays_unknown_object():
    payload = _pptr(0, 0) + b"\x00\x00\x00\x00" + _pptr(0, 2) + unity_string("") + unity_string("") + struct.pack("<i", 42)
    bundle, collection = _build_collection(payload, None)
    mono_behaviour = collection.assets[1]
    assert isinstance(mono_behaviour, UnknownObject)


def test_resolve_unloaded_mono_behaviours_recovers_real_field_values():
    assembly_manager = _build_assembly_manager()
    payload = (
        _pptr(0, 0)  # m_GameObject
        + b"\x01\x00\x00\x00"  # m_Enabled = true, aligned
        + _pptr(0, 2)  # m_Script -> the MonoScript at path_id 2
        + unity_string("My Instance")  # m_Name
        + unity_string("")  # m_EditorClassIdentifier
        + struct.pack("<i", 42)  # health
    )
    bundle, collection = _build_collection(payload, assembly_manager)
    assert isinstance(collection.assets[1], UnloadedMonoBehaviour)

    resolve_unloaded_mono_behaviours(bundle, assembly_manager)

    resolved = collection.assets[1]
    assert isinstance(resolved, StructureBackedAsset)
    assert not isinstance(resolved, UnknownObject)
    assert resolved["health"] == 42
    assert resolved.name == "My Instance"
    assert resolved.class_id == _MONO_BEHAVIOUR_CLASS_ID


def test_resolve_unloaded_mono_behaviours_falls_back_to_unknown_object_when_script_missing():
    assembly_manager = _build_assembly_manager()
    payload = (
        _pptr(0, 0) + b"\x00\x00\x00\x00" + _pptr(0, 999) + unity_string("") + unity_string("")
    )  # m_Script points nowhere
    bundle, collection = _build_collection(payload, assembly_manager)

    resolve_unloaded_mono_behaviours(bundle, assembly_manager)

    resolved = collection.assets[1]
    assert isinstance(resolved, UnknownObject)


def test_asset_with_embedded_type_tree_is_unaffected_by_assembly_manager():
    """Regression guard (required by ROADMAP.md Phase 16f): an asset that already has a real
    type tree must keep going through the pre-existing TypeTreeObject path unchanged, even
    when an assembly_manager is configured."""
    from assetripper_import.asset_creation.type_tree_object import TypeTreeObject

    from ._tree_builder import node, string_nodes

    tree_nodes = [node("TextAsset", "Base", 0), *string_nodes("m_Name", 1), *string_nodes("m_Script", 1)]
    serialized_type = SerializedType()
    serialized_type.type_id = 49
    serialized_type.is_stripped_type = False
    serialized_type.script_type_index = -1
    serialized_type.old_type.nodes = list(tree_nodes)
    serialized_type.old_type.build_string_buffer()

    obj = ObjectInfo(serialized_type)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = unity_string("Hi") + unity_string("There")

    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT, version=UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER, has_type_tree=True,
    )
    builder.types.append(serialized_type)
    builder.objects.append(obj)
    serialized_file = builder.build()
    serialized_file.name = "sharedassets0.assets"

    bundle = GameBundle()
    factory = GameAssetFactory(assembly_manager=_build_assembly_manager())
    collection = bundle.add_collection_from_serialized_file(serialized_file, factory)

    asset = collection.assets[1]
    assert isinstance(asset, TypeTreeObject)
    assert asset["m_Name"] == "Hi"

"""Phase 16f part 2: EmptyScriptExportCollection emits real `.cs` text (via `mono_manager.py`
+ `csharp_emitter.py`) when `register_default_exporters` is given an `assembly_manager` that
resolves the script's class, instead of `empty_script.py`'s dummy stub -- see
script_exporter.py/empty_script_export_collection.py's module docstrings for exactly where.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_import.structure.assembly.dotnet_metadata.compressed_integer import encode_type_def_or_ref
from assetripper_import.structure.assembly.dotnet_metadata.table_ids import TableId
from assetripper_import.structure.assembly.managers.mono_assembly_manager import MonoAssemblyManager
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.virtual_file_system import VirtualFileSystem
from assetripper_primitives import UnityVersion

from import_._module_builder import Coded, ModuleBuilder, wrap_pe
from import_._tree_builder import node, string_nodes, tree, unity_string

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)
_MONO_SCRIPT_CLASS_ID = 115

_MONO_SCRIPT_TREE = tree(
    node("MonoScript", "Base", 0),
    *string_nodes("m_Name", 1),
    *string_nodes("m_ClassName", 1),
    *string_nodes("m_Namespace", 1),
    *string_nodes("m_AssemblyName", 1),
)


def _script_bytes(name: str, class_name: str, namespace: str, assembly_name: str) -> bytes:
    return unity_string(name) + unity_string(class_name) + unity_string(namespace) + unity_string(assembly_name)


def _build_dll() -> bytes:
    b = ModuleBuilder()
    h = b.heaps
    h.add_guid()
    b.add_row(TableId.MODULE, generation=0, name=h.add_string("Assembly-CSharp.dll"), mvid=1, enc_id=0, enc_base_id=0)
    b.add_row(TableId.ASSEMBLY_REF, major_version=4, minor_version=0, build_number=0, revision_number=0,
              flags=0, public_key_or_token=h.add_blob(b""), name=h.add_string("mscorlib"), culture=h.add_string(""),
              hash_value=h.add_blob(b""))

    tr_mono_behaviour = b.add_row(
        TableId.TYPE_REF, resolution_scope=Coded("ResolutionScope", TableId.ASSEMBLY_REF, 1),
        name=h.add_string("MonoBehaviour"), namespace=h.add_string("UnityEngine"),
    )
    b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("<Module>"), namespace=h.add_string(""),
        extends=Coded.null("TypeDefOrRef"), field_list=1, method_list=1,
    )
    b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("PlayerController"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_mono_behaviour), field_list=1, method_list=1,
    )
    b.add_row(TableId.FIELD, flags=0x0006, name=h.add_string("health"), signature=h.add_blob(bytes([0x06, 0x08])))
    return wrap_pe(b.build())


def _build_assembly_manager() -> MonoAssemblyManager:
    file_system = VirtualFileSystem()
    file_system.directory.create("/Managed")
    file_system.file.write_all_bytes("/Managed/Assembly-CSharp.dll", _build_dll())
    return MonoAssemblyManager({"Assembly-CSharp.dll": "/Managed/Assembly-CSharp.dll"}, file_system)


def _build_and_export(tmp_path, script: tuple, assembly_manager=None) -> str:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT, version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER, has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = _MONO_SCRIPT_CLASS_ID
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _MONO_SCRIPT_TREE
    builder.types.append(type_)

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = _script_bytes(*script)
    builder.objects.append(obj)

    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory(assembly_manager=assembly_manager))

    exporter = ProjectExporter()
    register_default_exporters(exporter, assembly_manager=assembly_manager)
    exporter.export(game_bundle, str(tmp_path), FS)

    cs_files = list(tmp_path.rglob("*.cs"))
    assert len(cs_files) == 1
    return cs_files[0].read_text(encoding="utf-8")


def test_recovered_script_emits_real_field_declaration(tmp_path):
    assembly_manager = _build_assembly_manager()
    text = _build_and_export(
        tmp_path,
        ("PlayerController", "PlayerController", "MyGame", "Assembly-CSharp"),
        assembly_manager=assembly_manager,
    )
    assert "public class PlayerController : MonoBehaviour" in text
    assert "public int health;" in text
    assert "Dummy class." not in text


def test_unresolvable_assembly_falls_back_to_dummy_stub(tmp_path):
    assembly_manager = _build_assembly_manager()
    text = _build_and_export(
        tmp_path,
        ("EnemyAI", "EnemyAI", "MyGame", "SomeOtherAssembly"),
        assembly_manager=assembly_manager,
    )
    assert "Dummy class." in text
    assert "public class EnemyAI : MonoBehaviour" in text


def test_no_assembly_manager_still_falls_back_to_dummy_stub(tmp_path):
    text = _build_and_export(tmp_path, ("PlayerController", "PlayerController", "MyGame", "Assembly-CSharp"))
    assert "Dummy class." in text

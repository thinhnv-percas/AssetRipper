"""End-to-end tests for the script content exporter (Export phase 6c-2):
ScriptExporter/EmptyScriptExportCollection -- dummy-class stubs with stable per-script
GUIDs (see script_hashing.py), since this port never has a set assembly manager and thus
always takes upstream's "no decompilation" branch.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_modules.scripts import script_hashing
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, string_nodes, tree, unity_string

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)
_MONO_SCRIPT_CLASS_ID = 115

# MonoScript (class 115): m_Name, m_ClassName, m_Namespace, m_AssemblyName, m_ExecutionOrder.
_MONO_SCRIPT_TREE = tree(
    node("MonoScript", "Base", 0),
    *string_nodes("m_Name", 1),
    *string_nodes("m_ClassName", 1),
    *string_nodes("m_Namespace", 1),
    *string_nodes("m_AssemblyName", 1),
    node("int", "m_ExecutionOrder", 1),
)


def _script_bytes(name: str, class_name: str, namespace: str, assembly_name: str, execution_order: int = 0) -> bytes:
    return (
        unity_string(name)
        + unity_string(class_name)
        + unity_string(namespace)
        + unity_string(assembly_name)
        + struct.pack("<i", execution_order)
    )


def _build_and_export(tmp_path, scripts: list):
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = _MONO_SCRIPT_CLASS_ID
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _MONO_SCRIPT_TREE
    builder.types.append(type_)

    for file_id, script in enumerate(scripts, start=1):
        obj = ObjectInfo(type_)
        obj.file_id = file_id
        obj.serialized_type_index = 0
        obj.object_data = _script_bytes(*script)
        builder.objects.append(obj)

    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())

    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)


def test_script_is_exported_as_dummy_class_with_meta(tmp_path):
    _build_and_export(tmp_path, [("PlayerController", "PlayerController", "MyGame", "Assembly-CSharp")])

    cs_files = list(tmp_path.rglob("*.cs"))
    assert len(cs_files) == 1
    cs_path = cs_files[0]
    assert cs_path.parent.parts[-3:] == ("Scripts", "Assembly-CSharp", "MyGame")

    text = cs_path.read_text(encoding="utf-8")
    assert "namespace MyGame" in text
    assert "public class PlayerController : MonoBehaviour" in text
    assert "Dummy class." in text

    meta_path = cs_path.with_name(cs_path.name + ".meta")
    assert meta_path.exists()
    expected_guid = script_hashing.calculate_script_guid("Assembly-CSharp", "MyGame", "PlayerController")
    assert str(expected_guid) in meta_path.read_text(encoding="utf-8")


def test_firstpass_assembly_exports_under_plugins_folder(tmp_path):
    _build_and_export(tmp_path, [("Foo", "Foo", "", "Assembly-CSharp-firstpass")])

    cs_files = list(tmp_path.rglob("*.cs"))
    assert len(cs_files) == 1
    assert cs_files[0].parent.parts[-2:] == ("Plugins", "Assembly-CSharp-firstpass")

    text = cs_files[0].read_text(encoding="utf-8")
    assert text.startswith("using UnityEngine;\n\npublic class Foo : MonoBehaviour\n")
    assert "namespace" not in text  # no namespace wrapper for an empty namespace


def test_duplicate_scripts_are_deduplicated_into_one_file(tmp_path):
    _build_and_export(
        tmp_path,
        [
            ("Foo", "Foo", "MyGame", "Assembly-CSharp"),
            ("Foo", "Foo", "MyGame", "Assembly-CSharp"),
        ],
    )

    cs_files = list(tmp_path.rglob("*.cs"))
    assert len(cs_files) == 1


def test_injected_script_with_no_identity_is_skipped(tmp_path):
    _build_and_export(tmp_path, [("", "", "", "")])

    assert list(tmp_path.rglob("*.cs")) == []


def test_second_distinct_script_gets_its_own_file_and_guid(tmp_path):
    _build_and_export(
        tmp_path,
        [
            ("Foo", "Foo", "MyGame", "Assembly-CSharp"),
            ("Bar", "Bar", "MyGame", "Assembly-CSharp"),
        ],
    )

    cs_files = sorted(p.name for p in tmp_path.rglob("*.cs"))
    assert cs_files == ["Bar.cs", "Foo.cs"]

    for cs_path in tmp_path.rglob("*.cs"):
        meta_text = cs_path.with_name(cs_path.name + ".meta").read_text(encoding="utf-8")
        expected_guid = script_hashing.calculate_script_guid("Assembly-CSharp", "MyGame", cs_path.stem)
        assert str(expected_guid) in meta_text

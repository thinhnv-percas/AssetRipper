"""End-to-end test for the export driver
(Source/AssetRipper.Export.UnityProjects/ProjectExporter.cs port): a SerializedFile with a
real embedded type tree, read through the dynamic reader, exported to a directory of
.asset/.meta files.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
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

# TextAsset (class ID 49): m_Name (string), m_Script (string).
_TEXT_ASSET_TREE = tree(
    node("TextAsset", "Base", 0),
    *string_nodes("m_Name", 1),
    *string_nodes("m_Script", 1),
)


def _build_game_bundle():
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = 49
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _TEXT_ASSET_TREE

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = unity_string("MyText") + unity_string("hello world")

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return game_bundle


def _read_file(path) -> str:
    with open(path, encoding="utf-8") as f:
        return f.read()


def test_export_writes_asset_and_meta_files(tmp_path):
    game_bundle = _build_game_bundle()

    exporter = ProjectExporter()
    exporter.export(game_bundle, str(tmp_path), FS)

    asset_path = tmp_path / "Assets" / "TextAsset" / "MyText.asset"
    meta_path = tmp_path / "Assets" / "TextAsset" / "MyText.asset.meta"
    assert asset_path.exists()
    assert meta_path.exists()

    asset_text = _read_file(asset_path)
    assert "%TAG !u! tag:unity3d.com,2011:" in asset_text
    assert "--- !u!49 &4900000" in asset_text
    assert "m_Name: MyText" in asset_text
    assert "m_Script: hello world" in asset_text

    meta_text = _read_file(meta_path)
    assert "fileFormatVersion: 2" in meta_text
    assert "guid: " in meta_text
    assert "NativeFormatImporter:" in meta_text
    assert "mainObjectFileID: 4900000" in meta_text


def test_export_guid_is_stable_within_a_single_export(tmp_path):
    game_bundle = _build_game_bundle()
    exporter = ProjectExporter()
    exporter.export(game_bundle, str(tmp_path), FS)

    meta_text = _read_file(tmp_path / "Assets" / "TextAsset" / "MyText.asset.meta")
    guid_lines = [line for line in meta_text.splitlines() if line.startswith("guid:")]
    assert len(guid_lines) == 1
    guid_value = guid_lines[0].split(":", 1)[1].strip()
    assert len(guid_value) == 32
    int(guid_value, 16)  # a valid hex string


def test_export_two_bundles_produce_different_guids(tmp_path_factory):
    first_dir = tmp_path_factory.mktemp("first")
    second_dir = tmp_path_factory.mktemp("second")

    exporter = ProjectExporter()
    exporter.export(_build_game_bundle(), str(first_dir), FS)
    exporter.export(_build_game_bundle(), str(second_dir), FS)

    first_meta = _read_file(first_dir / "Assets" / "TextAsset" / "MyText.asset.meta")
    second_meta = _read_file(second_dir / "Assets" / "TextAsset" / "MyText.asset.meta")

    def guid_of(text: str) -> str:
        return next(line for line in text.splitlines() if line.startswith("guid:"))

    assert guid_of(first_meta) != guid_of(second_meta)


def test_export_calls_progress_callback_once_per_exportable_collection(tmp_path):
    calls = []
    exporter = ProjectExporter()
    exporter.export(
        _build_game_bundle(),
        str(tmp_path),
        FS,
        progress_callback=lambda current, total, name: calls.append((current, total, name)),
    )

    assert calls == [(1, 1, "MyText")]


def test_create_collections_is_a_public_alias_of_the_grouping_logic():
    exporter = ProjectExporter()
    game_bundle = _build_game_bundle()
    collections = exporter.create_collections(game_bundle)
    assert len(collections) == 1
    assert collections[0].name == "MyText"

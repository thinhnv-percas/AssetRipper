"""End-to-end test for `ExportHandler` (Source/AssetRipper.Export.UnityProjects/
ExportHandler.cs) -- the pipeline driver added in Phase 8 to close the gap the audit in
python/ROADMAP.md found: `ProjectExporter` was previously only ever invoked from tests.

This is the first test in the whole project that drives the full stack from a real file on
disk rather than an in-memory GameBundle: write a synthetic SerializedFile to a temp
directory, run `load_and_process`/`export` through `GameStructure` (platform discovery via
`MixedGameStructure`, since an arbitrary directory doesn't match any named platform layout),
and assert the exported project looks like a real Unity project directory.
"""
import struct
import zipfile

from assetripper_export_configuration.export_settings import ExportSettings
from assetripper_export_configuration.full_configuration import FullConfiguration
from assetripper_export_configuration.text_export_mode import TextExportMode
from assetripper_export_unity_projects.export_handler import ExportHandler
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, string_nodes, tree, unity_string

FS = LocalFileSystem()

# TextAsset (class ID 49): m_Name (string), m_Script (string) -- same fixture shape as
# test_project_exporter.py. Unlike that test, `ExportHandler.export` wires in
# `register_default_exporters()` by default (a real user's export would too), so this
# TextAsset is exported through `TextAssetExporter` as raw text with a guessed extension
# rather than falling through to the generic YAML `.asset` exporter.
_TEXT_ASSET_TREE = tree(
    node("TextAsset", "Base", 0),
    *string_nodes("m_Name", 1),
    *string_nodes("m_Script", 1),
)


def _write_synthetic_game(directory) -> None:
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
    # Writing real bytes to disk (unlike most tests, which hand a SerializedFile straight to
    # GameAssetFactory in memory) means the type tree's string offsets must actually be
    # resolvable on read-back -- see TypeTree.build_string_buffer's docstring.
    type_.old_type.build_string_buffer()

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = unity_string("MyText") + unity_string("hello world")

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()

    stream = MemoryStream()
    serialized_file.write(stream)
    (directory / "sharedassets0.assets").write_bytes(stream.to_array())


def test_load_process_and_export_produces_a_real_unity_project(tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    output_dir = tmp_path / "output"

    handler = ExportHandler()
    game_data = handler.load_process_and_export([str(game_dir)], str(output_dir), FS)

    assert game_data.project_version.equals(2019, 4, 0)

    asset_path = output_dir / "Assets" / "TextAsset" / "MyText.txt"
    meta_path = output_dir / "Assets" / "TextAsset" / "MyText.txt.meta"
    assert asset_path.exists()
    assert meta_path.exists()
    assert asset_path.read_text(encoding="utf-8") == "hello world"

    version_txt = output_dir / "ProjectSettings" / "ProjectVersion.txt"
    assert version_txt.exists()
    assert "2019.4.0" in version_txt.read_text(encoding="utf-8")

    manifest = output_dir / "Packages" / "manifest.json"
    assert manifest.exists()
    assert "com.unity.modules.ai" in manifest.read_text(encoding="utf-8")


def test_export_cleans_up_the_extracted_archive_temp_directory(tmp_path):
    """2026-08-03 fix: ExportHandler.export now deletes any temp directory GameStructure.load
    extracted an archive into, once export (including post-exporters, e.g. DllPostExporter,
    which can still need to read files from it) is completely done with it."""
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)

    zip_path = tmp_path / "game.zip"
    with zipfile.ZipFile(zip_path, "w") as archive:
        archive.write(game_dir / "sharedassets0.assets", "sharedassets0.assets")

    handler = ExportHandler()
    game_data = handler.load_and_process([str(zip_path)], FS)

    assert len(game_data.temp_directories) == 1
    extracted_directory = game_data.temp_directories[0]
    assert FS.directory.exists(extracted_directory)

    output_dir = tmp_path / "output"
    handler.export(game_data, str(output_dir), FS)

    assert not FS.directory.exists(extracted_directory)
    assert game_data.temp_directories == []
    assert (output_dir / "Assets" / "TextAsset" / "MyText.txt").exists()


def test_load_and_process_skips_processing_when_bundle_is_empty(tmp_path):
    empty_dir = tmp_path / "empty"
    empty_dir.mkdir()

    handler = ExportHandler()
    game_data = handler.load_and_process([str(empty_dir)], FS)

    assert not game_data.game_bundle.has_any_asset_collections()


def test_settings_are_threaded_through_to_registration(tmp_path):
    # Phase 10: `export()`'s `settings` parameter reaches `register_default_exporters`,
    # which should force `.bytes` here instead of the guessed `.txt` extension.
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    output_dir = tmp_path / "output"

    settings = FullConfiguration(export_settings=ExportSettings(text_export_mode=TextExportMode.BYTES))
    handler = ExportHandler()
    handler.load_process_and_export([str(game_dir)], str(output_dir), FS, settings=settings)

    assert (output_dir / "Assets" / "TextAsset" / "MyText.bytes").exists()
    assert not (output_dir / "Assets" / "TextAsset" / "MyText.txt").exists()


def test_load_then_process_then_export_as_separate_steps(tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    output_dir = tmp_path / "output"

    handler = ExportHandler()
    game_data = handler.load([str(game_dir)], FS)
    assert game_data.game_bundle.has_any_asset_collections()

    handler.process(game_data)
    handler.export(game_data, str(output_dir), FS)

    assert (output_dir / "Assets" / "TextAsset" / "MyText.txt").exists()

"""Tests for `build_export_plan` (Phase 17b) -- assetripper_gui_web/export_plan.py.

Builds the same synthetic TextAsset game used by test_export_handler.py and
test_virtual_file_system.py, loads it for real (LocalFileSystem, since input always lives on
disk), then builds an `ExportPlan` and checks its VFS tree contains exactly what a real disk
export of the same game_data would.
"""
from assetripper_export_unity_projects.export_handler import ExportHandler
from assetripper_gui_web.export_plan import build_export_plan
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, string_nodes, tree, unity_string

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


def _load_synthetic_game_data(tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    return ExportHandler().load_and_process([str(game_dir)], LocalFileSystem())


def test_build_export_plan_contains_the_real_exported_files(tmp_path):
    game_data = _load_synthetic_game_data(tmp_path)

    plan = build_export_plan(game_data)

    assert plan.project_version.equals(2019, 4, 0)
    all_files = plan.all_files()
    assert "/Assets/TextAsset/MyText.txt" in all_files
    assert "/Assets/TextAsset/MyText.txt.meta" in all_files
    assert "/ProjectSettings/ProjectVersion.txt" in all_files
    assert "/Packages/manifest.json" in all_files

    assert plan.file_system.file.read_all_bytes("/Assets/TextAsset/MyText.txt") == b"hello world"


def test_build_export_plan_matches_a_real_disk_export_of_the_same_game_data(tmp_path):
    game_data = _load_synthetic_game_data(tmp_path)

    plan = build_export_plan(game_data)
    virtual_paths = sorted(path.lstrip("/") for path in plan.all_files())

    output_dir = tmp_path / "output"
    ExportHandler().export(game_data, str(output_dir), LocalFileSystem())
    disk_paths = sorted(str(p.relative_to(output_dir)).replace("\\", "/") for p in output_dir.rglob("*") if p.is_file())

    assert virtual_paths == disk_paths


def test_build_export_plan_respects_settings():
    from assetripper_export_configuration.export_settings import ExportSettings
    from assetripper_export_configuration.full_configuration import FullConfiguration
    from assetripper_export_configuration.text_export_mode import TextExportMode

    import tempfile
    from pathlib import Path

    with tempfile.TemporaryDirectory() as tmp:
        game_data = _load_synthetic_game_data(Path(tmp))

        settings = FullConfiguration(export_settings=ExportSettings(text_export_mode=TextExportMode.BYTES))
        plan = build_export_plan(game_data, settings=settings)

        all_files = plan.all_files()
        assert "/Assets/TextAsset/MyText.bytes" in all_files
        assert "/Assets/TextAsset/MyText.txt" not in all_files

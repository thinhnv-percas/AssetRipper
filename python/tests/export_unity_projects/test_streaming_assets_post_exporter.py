from dataclasses import dataclass

from assetripper_export_configuration.full_configuration import FullConfiguration
from assetripper_export_configuration.import_settings import ImportSettings
from assetripper_export_configuration.streaming_assets_mode import StreamingAssetsMode
from assetripper_export_unity_projects.project.streaming_assets_post_exporter import StreamingAssetsPostExporter
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_primitives import UnityVersion

FS = LocalFileSystem()


@dataclass
class _FakePlatformStructure:
    streaming_assets_path: str
    file_system: object


@dataclass
class _FakeGameData:
    platform_structure: object
    assembly_manager: object = None


def _make_source_tree(tmp_path):
    source = tmp_path / "source_game" / "StreamingAssets"
    (source / "sub").mkdir(parents=True)
    (source / "top.txt").write_text("top", encoding="utf-8")
    (source / "sub" / "nested.txt").write_text("nested", encoding="utf-8")
    return str(source)


def test_copies_nested_streaming_assets_tree(tmp_path):
    source = _make_source_tree(tmp_path)
    game_data = _FakeGameData(platform_structure=_FakePlatformStructure(source, FS))

    output_dir = tmp_path / "output"
    StreamingAssetsPostExporter().do_post_export(game_data, str(output_dir), UnityVersion(2020, 1, 0), FS)

    dest = output_dir / "Assets" / "StreamingAssets"
    assert (dest / "top.txt").read_text(encoding="utf-8") == "top"
    assert (dest / "sub" / "nested.txt").read_text(encoding="utf-8") == "nested"


def test_no_platform_structure_is_a_no_op(tmp_path):
    game_data = _FakeGameData(platform_structure=None)
    StreamingAssetsPostExporter().do_post_export(game_data, str(tmp_path), UnityVersion(2020, 1, 0), FS)
    assert not (tmp_path / "Assets").exists()


def test_missing_streaming_assets_directory_is_a_no_op(tmp_path):
    game_data = _FakeGameData(platform_structure=_FakePlatformStructure(str(tmp_path / "nonexistent"), FS))
    StreamingAssetsPostExporter().do_post_export(game_data, str(tmp_path), UnityVersion(2020, 1, 0), FS)
    assert not (tmp_path / "Assets").exists()


def test_empty_streaming_assets_path_is_a_no_op(tmp_path):
    game_data = _FakeGameData(platform_structure=_FakePlatformStructure("", FS))
    StreamingAssetsPostExporter().do_post_export(game_data, str(tmp_path), UnityVersion(2020, 1, 0), FS)
    assert not (tmp_path / "Assets").exists()


def test_streaming_assets_mode_ignore_is_wired_through_settings(tmp_path):
    source = _make_source_tree(tmp_path)
    game_data = _FakeGameData(platform_structure=_FakePlatformStructure(source, FS))
    settings = FullConfiguration(import_settings=ImportSettings(streaming_assets_mode=StreamingAssetsMode.IGNORE))

    StreamingAssetsPostExporter().do_post_export(
        game_data, str(tmp_path / "output"), UnityVersion(2020, 1, 0), FS, settings
    )

    assert not (tmp_path / "output" / "Assets").exists()

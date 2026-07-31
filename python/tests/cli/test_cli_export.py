"""Smoke tests for the `assetripper-inspect export` subcommand (Phase 8: pipeline driver
wiring). Uses the same fixture-building technique as tests/export_unity_projects/
test_export_handler.py -- a real SerializedFile written to disk and read back through
GameStructure, not an in-memory GameBundle handed straight to the exporter.
"""
from __future__ import annotations

import struct

from assetripper_cli.cli import main
from assetripper_io_files.build_target import BuildTarget
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


def test_export_subcommand_writes_a_unity_project(tmp_path, capsys):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    output_dir = tmp_path / "output"

    exit_code = main(["export", str(game_dir), "-o", str(output_dir)])

    out = capsys.readouterr().out
    assert exit_code == 0
    assert "Done." in out
    assert (output_dir / "Assets" / "TextAsset" / "TextAsset.txt").exists()
    assert (output_dir / "ProjectSettings" / "ProjectVersion.txt").exists()


def test_export_subcommand_applies_config_file(tmp_path, capsys):
    # Phase 10: `--config <settings.json>` should reach register_default_exporters and force
    # TextExportMode.BYTES instead of the guessed ".txt" extension.
    from assetripper_export_configuration.export_settings import ExportSettings
    from assetripper_export_configuration.full_configuration import FullConfiguration
    from assetripper_export_configuration.text_export_mode import TextExportMode

    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    output_dir = tmp_path / "output"

    config_path = tmp_path / "settings.json"
    FullConfiguration(export_settings=ExportSettings(text_export_mode=TextExportMode.BYTES)).save(str(config_path))

    exit_code = main(["export", str(game_dir), "-o", str(output_dir), "--config", str(config_path)])

    assert exit_code == 0
    assert (output_dir / "Assets" / "TextAsset" / "TextAsset.bytes").exists()
    assert not (output_dir / "Assets" / "TextAsset" / "TextAsset.txt").exists()


def test_export_subcommand_requires_output_flag(tmp_path, capsys):
    exit_code = main(["export", str(tmp_path)])

    out = capsys.readouterr().out
    assert exit_code == 1
    assert "-o/--output is required" in out


def test_export_subcommand_requires_input_path(capsys):
    exit_code = main(["export", "-o", "/tmp/wherever"])

    out = capsys.readouterr().out
    assert exit_code == 1
    assert "no input paths given" in out


def test_export_subcommand_reports_missing_input(tmp_path, capsys):
    missing = tmp_path / "does_not_exist"
    output_dir = tmp_path / "output"

    exit_code = main(["export", str(missing), "-o", str(output_dir)])

    out = capsys.readouterr().out
    assert exit_code == 1
    assert "Error:" in out


def test_export_subcommand_help(capsys):
    assert main(["export", "--help"]) == 0
    assert "Usage: assetripper-inspect export" in capsys.readouterr().out


def test_top_level_usage_mentions_export(capsys):
    assert main([]) == 1
    out = capsys.readouterr().out
    assert "export" in out.lower()

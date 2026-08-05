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
    assert (output_dir / "Assets" / "TextAsset" / "MyText.txt").exists()
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
    assert (output_dir / "Assets" / "TextAsset" / "MyText.bytes").exists()
    assert not (output_dir / "Assets" / "TextAsset" / "MyText.txt").exists()


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


def test_assembly_dir_flag_is_repeatable_and_reaches_the_loader(tmp_path, capsys, monkeypatch):
    """ROADMAP 16c-alt. Asserts against what `load_and_process` actually received rather than
    against exported `.cs` files: the synthetic game here has no MonoBehaviour, so the flag's
    *effect* on output would be invisible, while the wiring is exactly what could break."""
    from assetripper_export_unity_projects import export_handler as export_handler_module

    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)

    received = {}
    original = export_handler_module.ExportHandler.load_and_process

    def _spy(self, paths, file_system, **kwargs):
        received.update(kwargs)
        return original(self, paths, file_system, **kwargs)

    monkeypatch.setattr(export_handler_module.ExportHandler, "load_and_process", _spy)

    exit_code = main([
        "export", str(game_dir), "-o", str(tmp_path / "output"),
        "--assembly-dir", "/dumps/one", "--assembly-dir", "/dumps/two",
    ])

    assert exit_code == 0
    assert received["assembly_directories"] == ["/dumps/one", "/dumps/two"]


def test_assembly_dir_flag_requires_a_value(capsys):
    exit_code = main(["export", "game", "-o", "out", "--assembly-dir"])

    assert exit_code == 1
    assert "--assembly-dir requires a value" in capsys.readouterr().out


def test_assembly_dir_flag_overrides_the_config_file(tmp_path, monkeypatch):
    """Same precedence rule every other explicit argument to `load` follows: explicit wins
    over `settings`. Here the config names one directory and the flag names another."""
    from assetripper_export_configuration.full_configuration import FullConfiguration
    from assetripper_export_configuration.import_settings import ImportSettings

    config_path = tmp_path / "settings.json"
    FullConfiguration(import_settings=ImportSettings(assembly_directories=["/from/config"])).save(str(config_path))

    received = _spy_on_game_structure_load(monkeypatch)
    exit_code = _run_export(tmp_path, "--config", str(config_path), "--assembly-dir", "/from/flag")

    assert exit_code == 0
    assert list(received["assembly_directories"]) == ["/from/flag"]


def test_config_file_assembly_directories_are_used_when_no_flag_is_given(tmp_path, monkeypatch):
    from assetripper_export_configuration.full_configuration import FullConfiguration
    from assetripper_export_configuration.import_settings import ImportSettings

    config_path = tmp_path / "settings.json"
    FullConfiguration(import_settings=ImportSettings(assembly_directories=["/from/config"])).save(str(config_path))

    received = _spy_on_game_structure_load(monkeypatch)
    assert _run_export(tmp_path, "--config", str(config_path)) == 0
    assert list(received["assembly_directories"]) == ["/from/config"]


def _run_export(tmp_path, *extra_args: str) -> int:
    game_dir = tmp_path / "game"
    game_dir.mkdir(exist_ok=True)
    _write_synthetic_game(game_dir)
    return main(["export", str(game_dir), "-o", str(tmp_path / "output"), *extra_args])


def _spy_on_game_structure_load(monkeypatch) -> dict:
    """Records the keyword arguments `GameStructure.load` was actually called with.

    Spying on `ExportHandler.load` would not work: it fills settings-derived values in with
    `kwargs.setdefault`, and `**kwargs` hands the callee its own fresh dict, so the caller's
    copy never sees them. `GameStructure.load` is the real destination anyway.
    """
    from assetripper_import.structure import game_structure as game_structure_module

    received: dict = {}
    original = game_structure_module.GameStructure.load

    def _spy(paths, file_system, **kwargs):
        received.update(kwargs)
        return original(paths, file_system, **kwargs)

    monkeypatch.setattr(game_structure_module.GameStructure, "load", staticmethod(_spy))
    return received

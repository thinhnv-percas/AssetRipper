"""
Smoke test for the assetripper-inspect CLI (assetripper_cli.cli.main).

This is new code (not a C# port), so it's tested directly rather than against a ported
test suite: build a real SerializedFile, run the CLI against it, and check the report.
"""
from __future__ import annotations

from assetripper_cli.cli import main
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_primitives import UnityVersion


def _write_sample_file(path) -> None:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2021, 3, 5),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
    )
    serialized_file = builder.build()
    stream = MemoryStream()
    serialized_file.write(stream)
    path.write_bytes(stream.to_array())


def test_inspect_recognizes_a_serialized_file(tmp_path, capsys):
    sample = tmp_path / "sample.assets"
    _write_sample_file(sample)

    exit_code = main([str(sample)])

    out = capsys.readouterr().out
    assert exit_code == 0
    assert "LARGE_FILES_SUPPORT" in out
    assert "2021.3.5f0" in out
    assert "STANDALONE_WIN64_PLAYER" in out


def test_inspect_reports_unrecognized_files(tmp_path, capsys):
    not_asset = tmp_path / "notasset.txt"
    not_asset.write_text("hello world")

    exit_code = main([str(not_asset)])

    out = capsys.readouterr().out
    assert exit_code == 0
    assert "Not a recognized SerializedFile" in out


def test_inspect_reports_failure_for_missing_file(tmp_path, capsys):
    missing = tmp_path / "does_not_exist.assets"

    exit_code = main([str(missing)])

    out = capsys.readouterr().out
    assert exit_code == 1
    assert "Error:" in out


def test_help_and_no_args_print_usage(capsys):
    assert main([]) == 1
    assert "Usage:" in capsys.readouterr().out

    assert main(["--help"]) == 0
    assert "Usage:" in capsys.readouterr().out


def test_version_flag(capsys):
    assert main(["--version"]) == 0
    assert "assetripper-inspect" in capsys.readouterr().out

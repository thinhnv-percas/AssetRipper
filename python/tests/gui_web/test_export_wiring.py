"""Tests for the Phase 8 GUI wiring: `/LoadFolder` now runs the full GameStructure pipeline
(game_file_loader.load_paths) instead of the old "load the first readable file" hack, and
`/Export/UnityProject` drives a real export instead of flashing "not implemented". Same
fixture-building technique as tests/export_unity_projects/test_export_handler.py.
"""
from __future__ import annotations

import struct
import time

import pytest
from assetripper_gui_web import create_app, game_file_loader
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


@pytest.fixture(autouse=True)
def _reset_game_file_loader():
    game_file_loader.reset()
    yield
    game_file_loader.reset()


@pytest.fixture
def client():
    app = create_app()
    app.testing = True
    return app.test_client()


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


def _wait_for_export_to_finish(timeout: float = 5.0) -> None:
    # Phase 11: /Export/UnityProject now runs on a background thread (see
    # game_file_loader.start_export) so the GUI can poll live progress instead of blocking
    # the whole request on a large export.
    deadline = time.monotonic() + timeout
    while game_file_loader.export_progress()["running"]:
        if time.monotonic() > deadline:
            raise AssertionError("export did not finish within the timeout")
        time.sleep(0.01)


def test_load_folder_runs_full_pipeline(client, tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)

    response = client.post("/LoadFolder", data={"Path": str(game_dir)}, follow_redirects=True)

    assert response.status_code == 200
    assert game_file_loader.is_loaded()
    assert game_file_loader.has_game_data()
    assert not game_file_loader.load_errors()


def test_load_folder_reports_missing_directory(client, tmp_path):
    missing = tmp_path / "does_not_exist"

    response = client.post("/LoadFolder", data={"Path": str(missing)}, follow_redirects=True)

    assert response.status_code == 200
    assert not game_file_loader.is_loaded()
    assert game_file_loader.load_errors()


def test_export_unity_project_writes_a_real_project(client, tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    output_dir = tmp_path / "output"

    client.post("/LoadFolder", data={"Path": str(game_dir)})
    assert game_file_loader.has_game_data()

    response = client.post("/Export/UnityProject", data={"OutputPath": str(output_dir)}, follow_redirects=True)
    _wait_for_export_to_finish()

    assert response.status_code == 200
    assert (output_dir / "Assets" / "TextAsset" / "MyText.txt").exists()
    assert (output_dir / "ProjectSettings" / "ProjectVersion.txt").exists()
    assert game_file_loader.export_progress()["error"] is None


def test_export_progress_endpoint_reports_completion(client, tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    output_dir = tmp_path / "output"

    client.post("/LoadFolder", data={"Path": str(game_dir)})
    client.post("/Export/UnityProject", data={"OutputPath": str(output_dir)})
    _wait_for_export_to_finish()

    response = client.get("/Export/Progress")

    assert response.status_code == 200
    data = response.get_json()
    assert data["running"] is False
    assert data["error"] is None
    assert data["total"] == 1
    assert data["current"] == 1


def test_start_export_rejects_a_second_concurrent_export(tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    game_file_loader.load_paths([str(game_dir)])
    assert game_file_loader.has_game_data()

    # Simulate an export already in flight rather than racing a real background thread
    # (a synthetic single-asset export can finish before a second start_export() call).
    game_file_loader._state.export_progress["running"] = True
    try:
        with pytest.raises(RuntimeError):
            game_file_loader.start_export(str(tmp_path / "output2"))
    finally:
        game_file_loader.reset()


def test_export_progress_records_error_without_raising(client, tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    client.post("/LoadFolder", data={"Path": str(game_dir)})

    # A regular file where the export expects to create a directory -- makes the background
    # thread's export() call raise; start_export()/the POST route must not propagate that.
    blocked_output = tmp_path / "blocked_output"
    blocked_output.write_text("not a directory", encoding="utf-8")

    response = client.post(
        "/Export/UnityProject", data={"OutputPath": str(blocked_output)}, follow_redirects=True
    )
    _wait_for_export_to_finish()

    assert response.status_code == 200
    assert game_file_loader.export_progress()["error"] is not None


def test_export_unity_project_without_game_data_flashes_error(client, tmp_path):
    # load_file (not load_folder) never populates game_data, so export must decline.
    sample = tmp_path / "sample.assets"
    _write_synthetic_game(tmp_path)
    (sample).write_bytes((tmp_path / "sharedassets0.assets").read_bytes())
    client.post("/LoadFile", data={"Path": str(sample)})
    assert not game_file_loader.has_game_data()

    response = client.post(
        "/Export/UnityProject", data={"OutputPath": str(tmp_path / "output")}, follow_redirects=True
    )

    assert response.status_code == 200
    assert not (tmp_path / "output").exists()


def test_export_unity_project_without_loaded_data_flashes_error(client, tmp_path):
    response = client.post(
        "/Export/UnityProject", data={"OutputPath": str(tmp_path / "output")}, follow_redirects=True
    )

    assert response.status_code == 200
    assert not (tmp_path / "output").exists()

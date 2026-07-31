"""Tests for the Phase 8 GUI wiring: `/LoadFolder` now runs the full GameStructure pipeline
(game_file_loader.load_paths) instead of the old "load the first readable file" hack, and
`/Export/UnityProject` drives a real export instead of flashing "not implemented". Same
fixture-building technique as tests/export_unity_projects/test_export_handler.py.
"""
from __future__ import annotations

import struct

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

    assert response.status_code == 200
    assert (output_dir / "Assets" / "TextAsset" / "TextAsset.txt").exists()
    assert (output_dir / "ProjectSettings" / "ProjectVersion.txt").exists()


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

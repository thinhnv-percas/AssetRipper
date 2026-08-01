"""Phase 17 (python/ROADMAP.md): browsing an exported Unity project's tree in the GUI --
`/Project`, `/Project/Browse`, `/Project/File`, `/Project/Load`. Same synthetic-game-fixture
technique as test_export_wiring.py.
"""
from __future__ import annotations

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
    deadline = time.monotonic() + timeout
    while game_file_loader.export_progress()["running"]:
        if time.monotonic() > deadline:
            raise AssertionError("export did not finish within the timeout")
        time.sleep(0.01)


def _load_and_export_blank(client, tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    client.post("/LoadFolder", data={"Path": str(game_dir)})
    assert game_file_loader.has_game_data()
    client.post("/Export/UnityProject", data={"OutputPath": ""})
    _wait_for_export_to_finish()
    assert game_file_loader.export_progress()["error"] is None


def test_blank_output_path_exports_to_a_temp_dir_and_becomes_browsable(client, tmp_path):
    import os

    _load_and_export_blank(client, tmp_path)

    assert game_file_loader.has_exported_project()
    project_dir = game_file_loader.exported_project_dir()
    assert os.path.isfile(os.path.join(project_dir, "ProjectSettings", "ProjectVersion.txt"))


def test_project_browse_lists_root_directories(client, tmp_path):
    _load_and_export_blank(client, tmp_path)

    response = client.get("/Project/Browse")
    assert response.status_code == 200
    text = response.get_data(as_text=True)
    assert "ProjectSettings" in text
    assert "Assets" in text


def test_project_browse_lists_subdirectory_contents(client, tmp_path):
    _load_and_export_blank(client, tmp_path)

    response = client.get("/Project/Browse", query_string={"path": "Assets/TextAsset"})
    assert response.status_code == 200
    text = response.get_data(as_text=True)
    assert "MyText.txt" in text


def test_project_file_serves_the_real_exported_content(client, tmp_path):
    _load_and_export_blank(client, tmp_path)

    response = client.get("/Project/File", query_string={"path": "Assets/TextAsset/MyText.txt"})
    assert response.status_code == 200
    assert response.get_data(as_text=True) == "hello world"


def test_project_file_rejects_path_traversal(client, tmp_path):
    _load_and_export_blank(client, tmp_path)

    response = client.get("/Project/File", query_string={"path": "../../../../etc/passwd"})
    assert response.status_code == 400


def test_project_browse_rejects_path_traversal(client, tmp_path):
    _load_and_export_blank(client, tmp_path)

    response = client.get("/Project/Browse", query_string={"path": "../../../../etc"})
    assert response.status_code == 400


def test_project_browse_without_any_export_redirects_home(client):
    response = client.get("/Project/Browse", follow_redirects=True)
    assert response.status_code == 200
    assert b"No exported project to browse" in response.data


def test_load_exported_project_points_at_an_arbitrary_existing_directory(client, tmp_path):
    # An export from an *earlier* run/process -- no fresh export happens here, just a real
    # directory on disk (built via a real export in a throwaway session, then "reloaded").
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    output_dir = tmp_path / "output"
    client.post("/LoadFolder", data={"Path": str(game_dir)})
    client.post("/Export/UnityProject", data={"OutputPath": str(output_dir)})
    _wait_for_export_to_finish()
    game_file_loader.reset()
    assert not game_file_loader.has_exported_project()

    response = client.post("/Project/Load", data={"Path": str(output_dir)}, follow_redirects=True)

    assert response.status_code == 200
    assert game_file_loader.has_exported_project()
    assert game_file_loader.exported_project_dir() == str(output_dir)


def test_load_exported_project_reports_missing_directory(client, tmp_path):
    missing = tmp_path / "does_not_exist"

    response = client.post("/Project/Load", data={"Path": str(missing)}, follow_redirects=True)

    assert response.status_code == 200
    assert not game_file_loader.has_exported_project()


def test_reset_cleans_up_the_owned_temp_dir(client, tmp_path):
    _load_and_export_blank(client, tmp_path)
    project_dir = game_file_loader.exported_project_dir()
    import os

    assert os.path.isdir(project_dir)

    game_file_loader.reset()

    assert not os.path.isdir(project_dir)
    assert not game_file_loader.has_exported_project()


def test_disk_export_with_explicit_path_also_becomes_browsable(client, tmp_path):
    """A real OutputPath (the pre-Phase-17 behavior) still works, and now additionally
    becomes browsable via /Project -- it's just not cleaned up on reset() since the user
    picked that location themselves."""
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)
    output_dir = tmp_path / "output"
    client.post("/LoadFolder", data={"Path": str(game_dir)})

    client.post("/Export/UnityProject", data={"OutputPath": str(output_dir)})
    _wait_for_export_to_finish()

    assert game_file_loader.has_exported_project()
    assert game_file_loader.exported_project_dir() == str(output_dir)

    game_file_loader.reset()
    assert output_dir.exists()  # user-picked directories are never deleted by reset()

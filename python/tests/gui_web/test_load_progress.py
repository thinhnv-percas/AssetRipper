"""Phase 19c: a real `.ipa` takes ~38s to extract and read (see ROADMAP Phase 19), which used
to hang the whole `/LoadFolder`/`/LoadFile` POST with zero feedback. `start_load` now runs
`load_paths` on a background thread with a `load_progress()` status the GUI polls, mirroring
`start_export`/`export_progress` (Phase 11) exactly rather than inventing a new pattern.
"""
from __future__ import annotations

import pytest
from assetripper_gui_web import create_app, game_file_loader
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, string_nodes, tree, unity_string

from ._load_helpers import wait_for_load_to_finish

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


def test_load_progress_reports_completion_with_no_error(client, tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)

    client.post("/LoadFolder", data={"Path": str(game_dir)})
    wait_for_load_to_finish()

    response = client.get("/Load/Progress")
    assert response.status_code == 200
    data = response.get_json()
    assert data["running"] is False
    assert data["error"] is None


def test_start_load_rejects_a_second_concurrent_load(tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)

    # Simulate a load already in flight rather than racing a real background thread (a
    # synthetic single-asset load can finish before a second start_load() call).
    game_file_loader._state.load_progress["running"] = True
    try:
        with pytest.raises(RuntimeError):
            game_file_loader.start_load([str(game_dir)])
    finally:
        game_file_loader._state.load_progress["running"] = False
        game_file_loader.reset()


def test_load_submit_button_disabled_while_running(client, tmp_path):
    game_file_loader._state.load_progress = {"running": True, "message": "Reading 3 file(s)...", "error": None}
    try:
        response = client.get("/")
        text = response.get_data(as_text=True)
        assert "disabled" in text
        assert "Reading 3 file(s)..." in text
    finally:
        game_file_loader._state.load_progress = {"running": False, "message": "", "error": None}


def test_load_progress_reports_a_coarse_milestone_message(tmp_path):
    """The callback shape is (message: str), not (current, total, name) like export's --
    there's no cheap way to know a numeric total up front (see GameStructure.load's
    docstring). Confirms at least one real milestone string actually reaches load_progress()
    during a real (synchronous, direct) load."""
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)

    seen_messages = []
    game_file_loader.load_paths([str(game_dir)], progress_callback=seen_messages.append)

    assert game_file_loader.has_game_data()
    assert any("platform structure" in m for m in seen_messages)
    assert any("Reading" in m for m in seen_messages)
    assert any("processors" in m for m in seen_messages)

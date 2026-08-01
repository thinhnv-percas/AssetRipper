"""Phase 19: the bug the user actually hit -- "the GUI tool still doesn't work with apk and
ipa input files". Root cause (see python/ROADMAP.md Phase 19): the engine has handled
`.apk`/`.ipa` correctly since Phase 3/14 (`zip_extractor`'s `_DIRECT_EXTRACT_EXTENSIONS`
already lists them), but the GUI's "Load File" button called `game_file_loader.load_file`
(a raw SerializedFile/UnityFS-only reader) instead of `load_paths` (the real pipeline) --
so handing it an `.apk` always failed with "not a recognized SerializedFile or UnityFS
bundle", even though `/LoadFolder` -> `load_paths` handled the exact same file correctly.

Phase 19a's fix: `/LoadFile` and `/LoadFolder` are now aliases of the same `load_paths`-based
handler. This is the most important test in this module: it builds a *synthetic but valid*
`.apk` (a real ZIP -- no Git LFS needed) shaped enough to be recognized as Android structure
(`assets/bin/Data/` + `META-INF/`, see AndroidGameStructure.is_android_structure) with one real
embedded SerializedFile, and asserts `/LoadFile` now succeeds on it exactly like `/LoadFolder`
always would have on an equivalent folder.
"""
from __future__ import annotations

import io
import zipfile

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


def _build_synthetic_serialized_file() -> bytes:
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
    obj.object_data = unity_string("MyText") + unity_string("hello from a fake apk")

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()

    stream = MemoryStream()
    serialized_file.write(stream)
    return stream.to_array()


def _write_synthetic_apk(path) -> None:
    """A real ZIP, shaped like a minimal Android APK: `assets/bin/Data/` (Unity's data
    directory) plus `META-INF/` (needed for `AndroidGameStructure.is_android_structure`'s
    directory-match check to pass -- `assets/` alone isn't enough, see
    `_get_root_android_directory_match`). The one embedded SerializedFile is named
    `globalgamemanagers` deliberately: `_collect_default_serialized_files` looks for that
    exact name (or `mainData`/level files) when scanning a platform's data directory --
    unlike a `sharedassetsN.assets` file, which in a real APK is discovered as a *dependency*
    of `globalgamemanagers` rather than by a direct filename scan, so it can't be picked up by
    this simple a synthetic fixture without also faking that dependency chain."""
    buffer = io.BytesIO()
    with zipfile.ZipFile(buffer, "w") as archive:
        archive.writestr("META-INF/MANIFEST.MF", b"synthetic manifest")
        archive.writestr("assets/bin/Data/globalgamemanagers", _build_synthetic_serialized_file())
    path.write_bytes(buffer.getvalue())


def test_load_file_accepts_a_synthetic_apk(client, tmp_path):
    apk_path = tmp_path / "game.apk"
    _write_synthetic_apk(apk_path)

    client.post("/LoadFile", data={"Path": str(apk_path)})
    wait_for_load_to_finish()

    assert not game_file_loader.load_errors()
    assert game_file_loader.has_game_data()
    collection_names = {c.name for c in game_file_loader.game_data().game_bundle.fetch_asset_collections()}
    assert "globalgamemanagers" in collection_names


def test_load_folder_accepts_the_same_synthetic_apk(client, tmp_path):
    """`/LoadFile` and `/LoadFolder` are aliases of the same handler as of Phase 19a -- both
    must behave identically on the exact same input."""
    apk_path = tmp_path / "game.apk"
    _write_synthetic_apk(apk_path)

    client.post("/LoadFolder", data={"Path": str(apk_path)})
    wait_for_load_to_finish()

    assert not game_file_loader.load_errors()
    assert game_file_loader.has_game_data()


def test_load_file_and_load_folder_produce_the_same_result(client, tmp_path):
    apk_path = tmp_path / "game.apk"
    _write_synthetic_apk(apk_path)

    client.post("/LoadFile", data={"Path": str(apk_path)})
    wait_for_load_to_finish()
    via_load_file = game_file_loader.has_game_data()
    game_file_loader.reset()

    client.post("/LoadFolder", data={"Path": str(apk_path)})
    wait_for_load_to_finish()
    via_load_folder = game_file_loader.has_game_data()

    assert via_load_file == via_load_folder is True


def test_loading_a_garbage_file_leaves_nothing_loaded_with_a_clear_error(client, tmp_path):
    """Regression check for the second, smaller bug the ROADMAP flagged alongside the main
    one: the old `load_file` set `_state.game_bundle` *before* validating, so a failed load
    left the GUI in a contradictory "loaded but empty" state (`is_loaded() == True`,
    `has_game_data() == False`). Since `/LoadFile` no longer calls `load_file` at all, this is
    fixed as a side effect of 19a -- confirmed here rather than assumed."""
    garbage = tmp_path / "not_a_game.txt"
    garbage.write_text("definitely not a Unity game", encoding="utf-8")

    client.post("/LoadFile", data={"Path": str(garbage)})
    wait_for_load_to_finish()

    assert not game_file_loader.is_loaded()
    assert not game_file_loader.has_game_data()
    assert game_file_loader.load_errors()

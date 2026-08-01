"""
No C# test project covers GUI.Web's route wiring directly (its own test project only
covers Paths), so these are original smoke tests (not a port) for the Flask app: static
pages, the file-system probe API, and a full load -> browse round trip against a
synthetic SerializedFile built with SerializedFileBuilder (the same technique used in
tests/cli/test_cli.py).
"""
from __future__ import annotations

import json

import pytest
from assetripper_gui_web import create_app, game_file_loader
from assetripper_io_files.bundle_files.compression_type import CompressionType
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_primitives import UnityVersion
from io_files_bundle._bundle_builder import build_bundle

from ._load_helpers import wait_for_load_to_finish


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


def _write_sample_file(path, with_object: bool = True) -> None:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2021, 3, 5),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
    )
    if with_object:
        type_ = SerializedType()
        type_.type_id = 1
        type_.is_stripped_type = False
        type_.script_type_index = -1

        obj = ObjectInfo(type_)
        obj.file_id = 1
        obj.serialized_type_index = 0
        obj.object_data = b"\x01\x02\x03\x04"

        builder.types.append(type_)
        builder.objects.append(obj)

    serialized_file = builder.build()
    stream = MemoryStream()
    serialized_file.write(stream)
    path.write_bytes(stream.to_array())


def test_static_pages_render(client):
    for url in ("/", "/Privacy", "/Licenses", "/PremiumFeatures", "/Commands", "/ConfigurationFiles", "/Settings/Edit"):
        response = client.get(url)
        assert response.status_code == 200, url


def test_privacy_page_has_real_content_not_a_stub(client):
    response = client.get("/Privacy")
    assert b"This app does not access the internet." in response.data
    assert b"Not implemented in this Python port yet." not in response.data


def test_licenses_page_lists_third_party_packages_not_a_stub(client):
    response = client.get("/Licenses")
    assert b"Flask" in response.data
    assert b"Bootstrap" in response.data
    assert b"Not implemented in this Python port yet." not in response.data


def test_io_file_probe_endpoints(client, tmp_path):
    existing = tmp_path / "exists.txt"
    existing.write_text("hi")

    assert client.get(f"/IO/File/Exists?Path={existing}").get_json() is True
    assert client.get("/IO/File/Exists?Path=/does/not/exist").get_json() is False
    assert client.get(f"/IO/Directory/Exists?Path={tmp_path}").get_json() is True
    assert client.get(f"/IO/Directory/Empty?Path={tmp_path}").get_json() is False


def test_load_file_and_browse_round_trip(client, tmp_path):
    sample = tmp_path / "sample.assets"
    _write_sample_file(sample)

    response = client.post("/LoadFile", data={"Path": str(sample)}, follow_redirects=True)
    wait_for_load_to_finish()
    assert response.status_code == 200
    assert game_file_loader.is_loaded()
    assert not game_file_loader.load_errors()

    root_path = json.dumps({"P": []})
    bundle_response = client.get(f"/Bundles/View?Path={root_path}")
    assert bundle_response.status_code == 200
    assert b"sample" in bundle_response.data

    collection_path = json.dumps({"B": {"P": []}, "I": 0})
    collection_response = client.get(f"/Collections/View?Path={collection_path}")
    assert collection_response.status_code == 200
    # The sample file embeds no type tree, so its object's layout can't be resolved and it
    # becomes an UnknownObject -- whose class_name still resolves through ClassIDType.
    assert b"GameObject" in collection_response.data

    count_response = client.get(f"/Collections/Count?Path={collection_path}")
    assert count_response.get_json() == {"count": 1}

    asset_path = json.dumps({"C": {"B": {"P": []}, "I": 0}, "D": 1})
    asset_response = client.get(f"/Assets/View?Path={asset_path}")
    assert asset_response.status_code == 200
    assert b"01 02 03 04" in asset_response.data


def test_load_unrecognized_file_records_an_error(client, tmp_path):
    """Phase 19a: `/LoadFile` now goes through `load_paths` (like `/LoadFolder` always did),
    so an unrecognized file correctly leaves `is_loaded()` False with an error -- not the old
    `load_file`'s bug where a failed load still left a contradictory "loaded but empty" bundle
    state (see ROADMAP Phase 19, point 3; fixed as a side effect of 19a rather than needing
    19b's originally-planned separate fix, since `/LoadFile` no longer calls `load_file` at
    all)."""
    not_asset = tmp_path / "notasset.txt"
    not_asset.write_text("hello world")

    client.post("/LoadFile", data={"Path": str(not_asset)})
    wait_for_load_to_finish()
    assert not game_file_loader.is_loaded()
    assert game_file_loader.load_errors()
    assert "No valid Unity assets found" in game_file_loader.load_errors()[0]


def test_reset_clears_loaded_state(client, tmp_path):
    sample = tmp_path / "sample.assets"
    _write_sample_file(sample)
    client.post("/LoadFile", data={"Path": str(sample)})
    wait_for_load_to_finish()
    assert game_file_loader.is_loaded()

    client.post("/Reset")
    assert not game_file_loader.is_loaded()


def test_search_finds_loaded_asset_by_class_name(client, tmp_path):
    sample = tmp_path / "sample.assets"
    _write_sample_file(sample)
    client.post("/LoadFile", data={"Path": str(sample)})
    wait_for_load_to_finish()

    response = client.get("/Search/View?q=GameObject")
    assert response.status_code == 200
    assert b"GameObject" in response.data


def test_bundle_view_404s_for_unresolvable_path(client):
    root_path = json.dumps({"P": []})
    response = client.get(f"/Bundles/View?Path={root_path}")
    assert response.status_code == 404


def test_load_unityfs_bundle_and_browse_resource(client, tmp_path):
    """A bundle with only a raw resource (no SerializedFile) has no "asset collection" for
    `load_paths`/`GameStructure` to recognize, so `has_any_asset_collections()` is False and
    the unified `/LoadFile`=`/LoadFolder` route (Phase 19a) correctly declines it as "no valid
    Unity assets found" -- same as any other file with nothing `GameStructure` can classify.
    Raw single-file/resource browsing (this test's actual subject) is exercised by calling
    `game_file_loader.load_file` directly instead of through a route, since Phase 19a no
    longer wires any GUI button to it (see that module's docstring)."""
    bundle_path = tmp_path / "level0"
    bundle_path.write_bytes(build_bundle(CompressionType.LZ4, {"CAB-abc": b"raw asset bytes" * 5}))

    game_file_loader.load_file(str(bundle_path))
    assert game_file_loader.is_loaded()
    assert not game_file_loader.load_errors()

    gb = game_file_loader.game_bundle()
    assert [r.name for r in gb.resources] == ["CAB-abc"]

    root_path = json.dumps({"P": []})
    bundle_view = client.get(f"/Bundles/View?Path={root_path}")
    assert bundle_view.status_code == 200
    assert b"CAB-abc" in bundle_view.data

    resource_path = json.dumps({"B": {"P": []}, "I": 0})
    resource_view = client.get(f"/Resources/View?Path={resource_path}")
    assert resource_view.status_code == 200

    resource_data = client.get(f"/Resources/Data?Path={resource_path}")
    assert resource_data.status_code == 200
    assert resource_data.data == b"raw asset bytes" * 5


def test_load_file_on_an_unreadable_file_leaves_nothing_loaded(tmp_path):
    """Phase 19b regression: `load_file` used to set `_state.game_bundle` to a fresh (empty)
    `GameBundle` *before* validating the file, so a failed load left `is_loaded() == True`
    with nothing actually in it -- a contradictory state, not just a bad error message. Fixed
    by only assigning `_state.game_bundle` once a read actually succeeds."""
    not_a_game = tmp_path / "not_a_game.bin"
    not_a_game.write_bytes(b"definitely not a SerializedFile or UnityFS bundle")

    game_file_loader.load_file(str(not_a_game))

    assert not game_file_loader.is_loaded()
    assert game_file_loader.load_errors()
    assert "not a recognized SerializedFile" in game_file_loader.load_errors()[0]


def test_load_file_on_a_missing_path_leaves_nothing_loaded(tmp_path):
    missing = tmp_path / "does_not_exist.assets"

    game_file_loader.load_file(str(missing))

    assert not game_file_loader.is_loaded()
    assert game_file_loader.load_errors()

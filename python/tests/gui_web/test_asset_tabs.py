"""Tests for the asset page's tabs (2026-08-03, ROADMAP Phase 11 leftovers): `/Assets/Json` and
the Dependencies tab, plus the tab-enabling rules.

Uses the same synthetic-SerializedFile approach as `test_asset_preview.py`, extended with a
GameObject that holds a real PPtr so the Dependencies tab has something to resolve -- upstream's
`DependenciesTab` skips null PPtrs, and a fixture with only nulls would test nothing.
"""
from __future__ import annotations

import json
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

from ._load_helpers import wait_for_load_to_finish

_TEXT_ASSET_TREE = tree(node("TextAsset", "Base", 0), *string_nodes("m_Name", 1), *string_nodes("m_Script", 1))

# A minimal Transform: enough to carry one non-null PPtr (m_GameObject) plus one null one
# (m_Father), so the Dependencies tab has both cases to render in a single asset.
_TRANSFORM_TREE = tree(
    node("Transform", "Base", 0),
    node("PPtr<GameObject>", "m_GameObject", 1),
    node("int", "m_FileID", 2),
    node("SInt64", "m_PathID", 2),
    node("PPtr<Transform>", "m_Father", 1),
    node("int", "m_FileID", 2),
    node("SInt64", "m_PathID", 2),
)

_TEXT_ASSET_PATH_ID = 1
_TRANSFORM_PATH_ID = 2


@pytest.fixture(autouse=True)
def _reset_game_file_loader():
    game_file_loader.reset()
    yield
    game_file_loader.reset()


@pytest.fixture
def client(tmp_path):
    app = create_app()
    app.testing = True
    test_client = app.test_client()

    sample = tmp_path / "sample.assets"
    _write_sample_file(sample)
    test_client.post("/LoadFile", data={"Path": str(sample)})
    wait_for_load_to_finish()
    return test_client


def _write_sample_file(path) -> None:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )

    text_type = SerializedType()
    text_type.type_id = 49
    text_type.is_stripped_type = False
    text_type.script_type_index = -1
    text_type.old_type = _TEXT_ASSET_TREE
    text_type.old_type.build_string_buffer()
    text_obj = ObjectInfo(text_type)
    text_obj.file_id = _TEXT_ASSET_PATH_ID
    text_obj.serialized_type_index = 0
    text_obj.object_data = unity_string("MyText") + unity_string("hello world")

    transform_type = SerializedType()
    transform_type.type_id = 4
    transform_type.is_stripped_type = False
    transform_type.script_type_index = -1
    transform_type.old_type = _TRANSFORM_TREE
    transform_type.old_type.build_string_buffer()
    transform_obj = ObjectInfo(transform_type)
    transform_obj.file_id = _TRANSFORM_PATH_ID
    transform_obj.serialized_type_index = 1
    # m_GameObject points at the TextAsset (class doesn't matter for PPtr resolution, only the
    # path ID does), m_Father is null.
    transform_obj.object_data = struct.pack("<iq", 0, _TEXT_ASSET_PATH_ID) + struct.pack("<iq", 0, 0)

    builder.types.extend([text_type, transform_type])
    builder.objects.extend([text_obj, transform_obj])
    serialized_file = builder.build()

    stream = MemoryStream()
    serialized_file.write(stream)
    path.write_bytes(stream.to_array())


def _asset_path(path_id: int) -> str:
    return json.dumps({"C": {"B": {"P": []}, "I": 0}, "D": path_id})


# -- /Assets/Json -------------------------------------------------------------------------


def test_json_endpoint_returns_the_assets_decoded_fields(client):
    response = client.get(f"/Assets/Json?Path={_asset_path(_TEXT_ASSET_PATH_ID)}")

    assert response.status_code == 200
    assert response.mimetype == "application/json"
    document = json.loads(response.data)
    assert document["m_Name"] == "MyText"
    assert document["m_Script"] == "hello world"


def test_json_endpoint_works_for_an_asset_no_content_exporter_handles(client):
    """The point of having a Json tab at all: unlike /Image, /Text and /Yaml it does not go
    through an exporter, so it works for any asset whose fields resolved."""
    response = client.get(f"/Assets/Json?Path={_asset_path(_TRANSFORM_PATH_ID)}")

    assert response.status_code == 200
    document = json.loads(response.data)
    assert document["m_GameObject"] == {"m_FileID": 0, "m_PathID": _TEXT_ASSET_PATH_ID}


def test_json_endpoint_404s_for_an_unknown_asset(client):
    assert client.get(f"/Assets/Json?Path={_asset_path(9999)}").status_code == 404


def test_json_endpoint_404s_when_nothing_is_loaded():
    app = create_app()
    app.testing = True
    response = app.test_client().get(f"/Assets/Json?Path={_asset_path(1)}")
    assert response.status_code == 404


# -- Dependencies tab ---------------------------------------------------------------------


def _dependencies_pane(response) -> str:
    """Just the Dependencies pane's markup. Scoping matters: `m_Father` legitimately appears in
    the Fields tab (it *is* a field), so a whole-page assertion would say nothing about whether
    the Dependencies tab skipped it."""
    text = response.data.decode("utf-8")
    start = text.index('id="tab-dependencies"')
    end = text.index('id="tab-json"', start)
    return text[start:end]


def test_dependencies_tab_lists_a_resolvable_reference(client):
    response = client.get(f"/Assets/View?Path={_asset_path(_TRANSFORM_PATH_ID)}")

    assert response.status_code == 200
    assert 'data-bs-target="#tab-dependencies"' in response.data.decode("utf-8")
    pane = _dependencies_pane(response)
    assert "m_GameObject" in pane
    assert "TextAsset" in pane, "the resolved target's class name should be shown"
    assert "/Assets/View" in pane, "and it should link to that asset"


def test_dependencies_tab_omits_null_references(client):
    """Upstream skips null PPtrs, and it matters: every unset reference field is one, so listing
    them would bury the real entries."""
    response = client.get(f"/Assets/View?Path={_asset_path(_TRANSFORM_PATH_ID)}")

    assert "m_Father" not in _dependencies_pane(response)


def test_dependencies_tab_is_absent_for_an_asset_with_no_references(client):
    """Tab enabling mirrors upstream's `AssetHtmlTab.Enabled` -- an empty tab is worse than none."""
    response = client.get(f"/Assets/View?Path={_asset_path(_TEXT_ASSET_PATH_ID)}")

    text = response.data.decode("utf-8")
    assert "tab-dependencies" in text, "the pane is always present, just empty"
    assert 'data-bs-target="#tab-dependencies"' not in text, "but its tab button is not rendered"


# -- tab scaffolding ----------------------------------------------------------------------


def test_the_asset_page_renders_real_bootstrap_tabs(client):
    response = client.get(f"/Assets/View?Path={_asset_path(_TEXT_ASSET_PATH_ID)}")

    text = response.data.decode("utf-8")
    assert 'class="nav nav-tabs' in text
    assert 'data-bs-toggle="tab"' in text
    assert "js/tabs.js" in text, "tab switching needs the local script, no Bootstrap JS is vendored"


def test_the_json_tab_is_rendered_when_fields_resolved(client):
    response = client.get(f"/Assets/View?Path={_asset_path(_TEXT_ASSET_PATH_ID)}")
    assert 'data-bs-target="#tab-json"' in response.data.decode("utf-8")


def test_no_template_still_uses_a_bare_table(client):
    """ROADMAP Phase 11 left "convert every template to Bootstrap classes" as debt, and site.css
    carried fallback rules for bare `<table>` markup. Both are gone; this keeps them gone."""
    from pathlib import Path

    import assetripper_gui_web

    templates = Path(assetripper_gui_web.__file__).parent / "templates"
    offenders = [
        str(path.relative_to(templates))
        for path in templates.rglob("*.html")
        if "<table>" in path.read_text(encoding="utf-8")
    ]
    assert offenders == []

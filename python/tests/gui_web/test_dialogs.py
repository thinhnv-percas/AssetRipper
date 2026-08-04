"""Phase 11: the `/Dialogs/*` routes should degrade gracefully (404, `available: False`)
rather than raise when there's no display to show a native picker on -- exactly the situation
this test suite runs in (a headless CI/CCR container), which doubles as real coverage of the
degrade path any user without a display would also hit.

**2026-08-03:** covers all five routes, after the Phase 20e audit found `/Dialogs/Files`,
`/Dialogs/Folders` and `/Dialogs/SaveFile` were missing entirely. The degrade path is the only
one testable here (a real picker needs a human at a display), so these assert every route
degrades *identically* -- a new route that raised a 500 instead would break the browser-side
fallback to manual text entry.
"""
from __future__ import annotations

import pytest
from assetripper_gui_web import create_app


@pytest.fixture
def client():
    app = create_app()
    app.testing = True
    return app.test_client()


def test_file_dialog_degrades_without_a_display(client):
    response = client.get("/Dialogs/File")

    assert response.status_code == 404
    assert response.get_json() == {"available": False}


def test_folder_dialog_degrades_without_a_display(client):
    response = client.get("/Dialogs/Folder")

    assert response.status_code == 404
    assert response.get_json() == {"available": False}


def test_multi_select_file_dialog_degrades_without_a_display(client):
    response = client.get("/Dialogs/Files")

    assert response.status_code == 404
    assert response.get_json() == {"available": False}


def test_multi_select_folder_dialog_degrades_without_a_display(client):
    response = client.get("/Dialogs/Folders")

    assert response.status_code == 404
    assert response.get_json() == {"available": False}


def test_save_file_dialog_degrades_without_a_display(client):
    response = client.get("/Dialogs/SaveFile")

    assert response.status_code == 404
    assert response.get_json() == {"available": False}


def test_every_dialog_route_exists_and_degrades_the_same_way(client):
    """Upstream has five dialog endpoints; assert this port now answers on all five and that
    none of them 404s for the wrong reason (a missing route also returns 404, so the JSON body
    is what distinguishes "no display" from "no such route")."""
    for route in ("/Dialogs/File", "/Dialogs/Files", "/Dialogs/Folder", "/Dialogs/Folders", "/Dialogs/SaveFile"):
        response = client.get(route)
        assert response.status_code == 404, route
        assert response.get_json() == {"available": False}, route


def test_multi_select_routes_would_return_a_paths_list(client, monkeypatch):
    """The shape multi-select returns differs from single-select (`paths` vs `path`), and the
    headless degrade path never exercises it. Patch the Tk layer to prove the success shape."""
    from assetripper_gui_web.routes import dialogs

    monkeypatch.setattr(dialogs, "_with_tk", lambda action: ["/games/one", "/games/two"])

    response = client.get("/Dialogs/Files")

    assert response.status_code == 200
    assert response.get_json() == {"available": True, "paths": ["/games/one", "/games/two"]}


def test_single_select_routes_keep_returning_a_bare_path(client, monkeypatch):
    """Guards the existing `index.html` callers: their JS reads `.path`, not `.paths`."""
    from assetripper_gui_web.routes import dialogs

    monkeypatch.setattr(dialogs, "_with_tk", lambda action: "/games/only")

    response = client.get("/Dialogs/File")

    assert response.status_code == 200
    assert response.get_json() == {"available": True, "path": "/games/only"}

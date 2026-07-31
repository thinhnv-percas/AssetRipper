"""Phase 11: `/Dialogs/File` and `/Dialogs/Folder` should degrade gracefully (404,
`available: False`) rather than raise when there's no display to show a native picker on
-- exactly the situation this test suite runs in (a headless CI/CCR container), which
doubles as real coverage of the degrade path any user without a display would also hit.
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

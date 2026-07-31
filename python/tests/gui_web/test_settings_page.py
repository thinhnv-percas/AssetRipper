"""Phase 10: `/Settings/Edit` is a real form over `assetripper_export_configuration`,
backed by `game_file_loader.settings()`'s session-only state -- not a `stub.html` page
anymore."""
from __future__ import annotations

import pytest
from assetripper_export_configuration.full_configuration import FullConfiguration
from assetripper_export_configuration.image_export_format import ImageExportFormat
from assetripper_export_configuration.streaming_assets_mode import StreamingAssetsMode
from assetripper_gui_web import create_app, game_file_loader
from assetripper_processing.configuration.bundled_assets_export_mode import BundledAssetsExportMode


@pytest.fixture(autouse=True)
def _reset_settings():
    game_file_loader.set_settings(FullConfiguration())
    yield
    game_file_loader.set_settings(FullConfiguration())


@pytest.fixture
def client():
    app = create_app()
    app.testing = True
    return app.test_client()


def test_settings_edit_get_renders_current_values(client):
    response = client.get("/Settings/Edit")

    assert response.status_code == 200
    assert b"Not implemented in this Python port yet." not in response.data
    assert b"PNG" in response.data


_FORM_DEFAULTS = {
    "script_content_level": "LEVEL_2",
    "streaming_assets_mode": "EXTRACT",
    "image_export_format": "PNG",
    "audio_export_format": "DEFAULT",
    "shader_export_mode": "DUMMY",
    "sprite_export_mode": "YAML",
    "text_export_mode": "PARSE",
    "bundled_assets_export_mode": "DIRECT_EXPORT",
}


def test_settings_edit_post_updates_state_and_redirects(client):
    form = dict(_FORM_DEFAULTS, image_export_format="JPEG", streaming_assets_mode="IGNORE")

    response = client.post("/Settings/Edit", data=form, follow_redirects=True)

    assert response.status_code == 200
    settings = game_file_loader.settings()
    assert settings.export_settings.image_export_format == ImageExportFormat.JPEG
    assert settings.import_settings.streaming_assets_mode == StreamingAssetsMode.IGNORE


def test_settings_edit_post_sets_booleans_from_checkboxes(client):
    form = dict(_FORM_DEFAULTS, bundled_assets_export_mode="GROUP_BY_BUNDLE_NAME")
    form["export_unreadable_assets"] = "on"
    form["publicize_assemblies"] = "on"

    client.post("/Settings/Edit", data=form, follow_redirects=True)

    settings = game_file_loader.settings()
    assert settings.export_settings.export_unreadable_assets is True
    assert settings.processing_settings.publicize_assemblies is True
    assert settings.processing_settings.remove_nullable_attributes is False
    assert settings.processing_settings.bundled_assets_export_mode == BundledAssetsExportMode.GROUP_BY_BUNDLE_NAME


def test_settings_edit_post_preserves_unexposed_unity_version_fields(client):
    from assetripper_export_configuration.import_settings import ImportSettings
    from assetripper_primitives import UnityVersion

    game_file_loader.set_settings(
        FullConfiguration(import_settings=ImportSettings(default_version=UnityVersion(2019, 4, 0)))
    )

    client.post("/Settings/Edit", data=_FORM_DEFAULTS, follow_redirects=True)

    assert game_file_loader.settings().import_settings.default_version == UnityVersion(2019, 4, 0)

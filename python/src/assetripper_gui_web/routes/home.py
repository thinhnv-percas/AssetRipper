"""Port of the home/static/settings routes registered directly in
Source/AssetRipper.GUI.Web/WebApplicationLauncher.cs (IndexPage, CommandsPage,
PrivacyPage, LicensesPage, PremiumFeaturesPage, ConfigurationFilesPage, SettingsPage).

`/Settings/Edit` (Phase 10): a real form over `assetripper_export_configuration`'s
dataclasses, backed by `game_file_loader.settings()`'s session-only state (see that
module's docstring -- not persisted to disk). Fields for enum members this port declares
but never consumes (`SpriteExportMode`, `ScriptContentLevel`, `remove_nullable_attributes`,
`publicize_assemblies`) are still exposed here so the setting round-trips correctly for a
future consumer, matching upstream's own GUI which exposes the same settings whether or
not every one changes behavior yet. `ImportSettings.default_version`/`target_version`
(a `UnityVersion | None`) are deliberately not exposed as form fields -- carried through
unchanged on every POST -- since they need a version-string parser/validator this phase
doesn't add; set them via a `FullConfiguration` JSON file and the CLI's `--config` instead.
"""
from __future__ import annotations

from flask import Blueprint, flash, redirect, render_template, request, url_for

from assetripper_export_configuration.audio_export_format import AudioExportFormat
from assetripper_export_configuration.export_settings import ExportSettings
from assetripper_export_configuration.image_export_format import ImageExportFormat
from assetripper_export_configuration.import_settings import ImportSettings
from assetripper_export_configuration.processing_settings import ProcessingSettings
from assetripper_export_configuration.script_content_level import ScriptContentLevel
from assetripper_export_configuration.shader_export_mode import ShaderExportMode
from assetripper_export_configuration.sprite_export_mode import SpriteExportMode
from assetripper_export_configuration.streaming_assets_mode import StreamingAssetsMode
from assetripper_export_configuration.text_export_mode import TextExportMode
from assetripper_export_configuration.full_configuration import FullConfiguration
from assetripper_processing.configuration.bundled_assets_export_mode import BundledAssetsExportMode

from .. import game_file_loader
from ..paths import BundlePath

bp = Blueprint("home", __name__)


@bp.get("/")
def index():
    return render_template(
        "index.html",
        is_loaded=game_file_loader.is_loaded(),
        has_game_data=game_file_loader.has_game_data(),
        export_progress=game_file_loader.export_progress(),
        load_errors=game_file_loader.load_errors(),
        root_path=BundlePath().to_json(),
    )


@bp.get("/Commands")
def commands():
    return render_template("stub.html", page_title="Commands")


@bp.get("/Privacy")
def privacy():
    # Verbatim port of upstream's PrivacyPage.cs -- same one-sentence policy applies here:
    # this GUI only serves the local Flask dev server on 127.0.0.1, no outbound requests.
    return render_template("privacy.html", page_title="Privacy Policy")


_THIRD_PARTY_PACKAGES = (
    # PyPI runtime dependencies from pyproject.toml's [project] dependencies, plus the
    # vendored Bootstrap CSS. Not a full per-dependency license-text bundle the way
    # upstream's Licenses.Load(name) embeds one per NuGet package (Source/
    # AssetRipper.GUI.Licensing) -- that would need pulling each PyPI package's actual
    # LICENSE file at build time, which this phase doesn't add. Bootstrap's LICENSE *is*
    # vendored alongside its CSS (static/vendor/bootstrap/LICENSE) since it ships as a
    # static asset in this repo, not a PyPI dependency resolved at install time.
    # License strings below are only asserted where this port could directly confirm them
    # (installed package metadata / PyPI classifiers) -- see the linked project page for
    # anything left as "see project page" rather than guessed.
    {"name": "Flask", "url": "https://pypi.org/project/Flask/", "license": "see project page"},
    {"name": "lz4", "url": "https://pypi.org/project/lz4/", "license": "BSD License"},
    {"name": "xxhash", "url": "https://pypi.org/project/xxhash/", "license": "BSD-2-Clause"},
    {"name": "texture2ddecoder", "url": "https://pypi.org/project/texture2ddecoder/", "license": "MIT License"},
    {"name": "Pillow", "url": "https://pypi.org/project/pillow/", "license": "see project page"},
    {"name": "Bootstrap", "url": "https://getbootstrap.com/", "license": "MIT (vendored, see static/vendor/bootstrap/LICENSE)"},
)


@bp.get("/Licenses")
def licenses():
    return render_template("licenses.html", page_title="Licenses", packages=_THIRD_PARTY_PACKAGES)


@bp.get("/PremiumFeatures")
def premium_features():
    return render_template("stub.html", page_title="Premium Features")


@bp.get("/ConfigurationFiles")
def configuration_files():
    return render_template("stub.html", page_title="Configuration Files")


_ENUM_CHOICES = {
    "image_export_format": ImageExportFormat,
    "audio_export_format": AudioExportFormat,
    "shader_export_mode": ShaderExportMode,
    "sprite_export_mode": SpriteExportMode,
    "text_export_mode": TextExportMode,
    "script_content_level": ScriptContentLevel,
    "streaming_assets_mode": StreamingAssetsMode,
    "bundled_assets_export_mode": BundledAssetsExportMode,
}


@bp.route("/Settings/Edit", methods=["GET", "POST"])
def settings():
    if request.method == "POST":
        current = game_file_loader.settings()
        form = request.form
        game_file_loader.set_settings(
            FullConfiguration(
                import_settings=ImportSettings(
                    script_content_level=ScriptContentLevel[form.get("script_content_level")],
                    streaming_assets_mode=StreamingAssetsMode[form.get("streaming_assets_mode")],
                    default_version=current.import_settings.default_version,
                    target_version=current.import_settings.target_version,
                ),
                export_settings=ExportSettings(
                    audio_export_format=AudioExportFormat[form.get("audio_export_format")],
                    image_export_format=ImageExportFormat[form.get("image_export_format")],
                    shader_export_mode=ShaderExportMode[form.get("shader_export_mode")],
                    sprite_export_mode=SpriteExportMode[form.get("sprite_export_mode")],
                    text_export_mode=TextExportMode[form.get("text_export_mode")],
                    export_unreadable_assets=form.get("export_unreadable_assets") == "on",
                ),
                processing_settings=ProcessingSettings(
                    bundled_assets_export_mode=BundledAssetsExportMode[form.get("bundled_assets_export_mode")],
                    remove_nullable_attributes=form.get("remove_nullable_attributes") == "on",
                    publicize_assemblies=form.get("publicize_assemblies") == "on",
                ),
            )
        )
        flash("Settings saved.")
        return redirect(url_for("home.settings"))

    return render_template(
        "settings.html",
        page_title="Settings",
        settings=game_file_loader.settings(),
        enum_choices=_ENUM_CHOICES,
    )

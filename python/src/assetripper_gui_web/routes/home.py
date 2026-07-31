"""Port of the home/static/settings routes registered directly in
Source/AssetRipper.GUI.Web/WebApplicationLauncher.cs (IndexPage, CommandsPage,
PrivacyPage, LicensesPage, PremiumFeaturesPage, ConfigurationFilesPage, SettingsPage)."""
from __future__ import annotations

from flask import Blueprint, render_template

from .. import game_file_loader
from ..paths import BundlePath

bp = Blueprint("home", __name__)


@bp.get("/")
def index():
    return render_template(
        "index.html",
        is_loaded=game_file_loader.is_loaded(),
        load_errors=game_file_loader.load_errors(),
        root_path=BundlePath().to_json(),
    )


@bp.get("/Commands")
def commands():
    return render_template("stub.html", page_title="Commands")


@bp.get("/Privacy")
def privacy():
    return render_template("stub.html", page_title="Privacy")


@bp.get("/Licenses")
def licenses():
    return render_template("stub.html", page_title="Licenses")


@bp.get("/PremiumFeatures")
def premium_features():
    return render_template("stub.html", page_title="Premium Features")


@bp.get("/ConfigurationFiles")
def configuration_files():
    return render_template("stub.html", page_title="Configuration Files")


@bp.get("/Settings/Edit")
def settings():
    return render_template("stub.html", page_title="Settings")

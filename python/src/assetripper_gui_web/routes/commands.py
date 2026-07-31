"""Port of Source/AssetRipper.GUI.Web/Pages/Commands.cs -- only LoadFile/Reset are
functional; Export commands need the unported Export pipeline."""
from __future__ import annotations

import os

from flask import Blueprint, flash, redirect, request, url_for

from .. import game_file_loader

bp = Blueprint("commands", __name__)


@bp.post("/LoadFile")
def load_file():
    path = request.form.get("Path", "")
    game_file_loader.load_file(path)
    return redirect(url_for("home.index"))


@bp.post("/LoadFolder")
def load_folder():
    """Simplification: scans the folder for the first file SerializedFileScheme can
    read and loads that one file. The real LoadFolder command loads every file in the
    directory into one GameBundle via the full Import pipeline."""
    folder = request.form.get("Path", "")
    if not os.path.isdir(folder):
        flash(f"Directory not found: {folder}")
        return redirect(url_for("home.index"))

    for name in sorted(os.listdir(folder)):
        candidate = os.path.join(folder, name)
        if os.path.isfile(candidate):
            game_file_loader.load_file(candidate)
            if game_file_loader.is_loaded() and not game_file_loader.load_errors():
                return redirect(url_for("home.index"))
    flash(f"No recognized SerializedFile found in: {folder}")
    return redirect(url_for("home.index"))


@bp.post("/Reset")
def reset():
    game_file_loader.reset()
    return redirect(url_for("home.index"))


@bp.post("/Export/UnityProject")
def export_unity_project():
    flash("Export is not implemented in this Python port (needs AssetRipper.Export).")
    return redirect(url_for("home.index"))


@bp.post("/Export/PrimaryContent")
def export_primary_content():
    flash("Export is not implemented in this Python port (needs AssetRipper.Export).")
    return redirect(url_for("home.index"))

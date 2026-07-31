"""Port of Source/AssetRipper.GUI.Web/Pages/Commands.cs

LoadFile/LoadFolder/Reset/Export.UnityProject are now wired to the real pipeline (see
game_file_loader.py's module docstring and assetripper_export_unity_projects/
export_handler.py). Export.PrimaryContent still isn't: it needs
`AssetRipper.Export.PrimaryContent`, a separate content-extraction pipeline this port
hasn't touched (distinct from `AssetRipper.Export.UnityProjects`, which the rest of this
file now drives)."""
from __future__ import annotations

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
    """Loads every file under `Path` as a full Unity game via `GameStructure` (platform
    discovery, dependency resolution, processors) -- unlike `load_file`'s single raw file,
    this is what `/Export/UnityProject` needs."""
    folder = request.form.get("Path", "")
    game_file_loader.load_paths([folder])
    for error in game_file_loader.load_errors():
        flash(error)
    return redirect(url_for("home.index"))


@bp.post("/Reset")
def reset():
    game_file_loader.reset()
    return redirect(url_for("home.index"))


@bp.post("/Export/UnityProject")
def export_unity_project():
    output_path = request.form.get("OutputPath", "")
    if not game_file_loader.has_game_data():
        flash("Load a game folder first (use Load Folder, not Load File -- export needs the full game structure).")
        return redirect(url_for("home.index"))
    if not output_path:
        flash("No output path given.")
        return redirect(url_for("home.index"))

    from assetripper_export_unity_projects.export_handler import ExportHandler
    from assetripper_io_files.local_file_system import LocalFileSystem

    try:
        ExportHandler().export(game_file_loader.game_data(), output_path, LocalFileSystem.instance())
    except Exception as ex:  # noqa: BLE001 -- GUI error boundary, reported to the user via flash
        flash(f"Export failed: {ex!r}")
        return redirect(url_for("home.index"))

    flash(f"Exported to {output_path}")
    return redirect(url_for("home.index"))


@bp.post("/Export/PrimaryContent")
def export_primary_content():
    flash("Primary content export is not implemented in this Python port (needs AssetRipper.Export.PrimaryContent).")
    return redirect(url_for("home.index"))

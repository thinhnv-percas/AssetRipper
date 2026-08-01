"""Port of Source/AssetRipper.GUI.Web/Pages/Commands.cs

LoadFile/LoadFolder/Reset/Export.UnityProject are now wired to the real pipeline (see
game_file_loader.py's module docstring and assetripper_export_unity_projects/
export_handler.py). Export.PrimaryContent still isn't: it needs
`AssetRipper.Export.PrimaryContent`, a separate content-extraction pipeline this port
hasn't touched (distinct from `AssetRipper.Export.UnityProjects`, which the rest of this
file now drives).

`/Export/UnityProject` (Phase 11): now starts the export on a background thread and
returns immediately instead of blocking the whole request -- `/Export/Progress` (JSON,
polled by index.html) reports live progress via `game_file_loader.export_progress()`.

Phase 17: `OutputPath` is now optional -- left blank, `start_export` exports into a temp
directory instead and the result becomes browsable at `/Project` once it finishes (see
game_file_loader.py's docstring). A non-blank path keeps exporting straight to disk exactly
like before.
"""
from __future__ import annotations

from flask import Blueprint, flash, jsonify, redirect, request, url_for

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
    output_path = request.form.get("OutputPath", "").strip()
    if not game_file_loader.has_game_data():
        flash("Load a game folder first (use Load Folder, not Load File -- export needs the full game structure).")
        return redirect(url_for("home.index"))

    try:
        game_file_loader.start_export(output_path or None)
    except RuntimeError as ex:
        flash(str(ex))
        return redirect(url_for("home.index"))

    if output_path:
        flash(f"Export started to {output_path} -- see progress below.")
    else:
        flash("Export started -- once finished, browse it in the tool from the link below.")
    return redirect(url_for("home.index"))


@bp.get("/Export/Progress")
def export_progress():
    return jsonify(game_file_loader.export_progress())


@bp.post("/Export/PrimaryContent")
def export_primary_content():
    flash("Primary content export is not implemented in this Python port (needs AssetRipper.Export.PrimaryContent).")
    return redirect(url_for("home.index"))

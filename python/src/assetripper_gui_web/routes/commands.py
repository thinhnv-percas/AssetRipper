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

`/LoadFile`/`/LoadFolder` (Phase 19c): now the same, via `start_load` + `/Load/Progress` --
a real `.ipa` takes ~38s to extract and read (see ROADMAP Phase 19), which used to hang the
whole POST request with no feedback. Mirrors the export-progress pattern exactly rather than
inventing a new one.

`OutputPath` is required (Phase 17 rewrite dropped the old "blank = export into a temp dir,
then browse it" behavior -- see game_file_loader.py's docstring for why: `/Project` now
previews a loaded game instantly via `ExportPlan`, with no export step needed, so this real
disk export always needs a real path again, same as before Phase 17 existed).

**Phase 19a:** `/LoadFile` and `/LoadFolder` are now aliases of the same `_load` handler,
which always calls `game_file_loader.load_paths([path])` regardless of whether `path` is a
file or a directory -- fixes the real bug the user hit: a `.apk`/`.ipa` handed to the old
"Load File" button (which called `game_file_loader.load_file`, a raw-SerializedFile/bundle-only
reader) always failed with "not a recognized SerializedFile or UnityFS bundle", even though
`load_paths` (behind "Load Folder") has handled archive inputs correctly since Phase 3/14 --
`zip_extractor`/`platform_checker` already classify `.apk`/`.ipa`/`.obb`/`.zip`, a real game
folder, or one loose `.assets`/bundle file correctly, with no format-detection logic needed at
the GUI layer. Kept as two distinct route names (not collapsed to one) so neither an old
bookmark nor `test_flask_app.py`'s existing route list breaks.
"""
from __future__ import annotations

from flask import Blueprint, flash, jsonify, redirect, request, url_for

from .. import config_files, game_file_loader

bp = Blueprint("commands", __name__)


def _load():
    path = request.form.get("Path", "")
    try:
        game_file_loader.start_load([path])
    except RuntimeError as ex:
        flash(str(ex))
    return redirect(url_for("home.index"))


@bp.post("/LoadFile")
def load_file():
    return _load()


@bp.post("/LoadFolder")
def load_folder():
    return _load()


@bp.get("/Load/Progress")
def load_progress():
    return jsonify(game_file_loader.load_progress())


@bp.post("/Reset")
def reset():
    game_file_loader.reset()
    # 2026-08-03: `/ConfigurationFiles` entries are session state too, so a Reset that left them
    # behind would be a half-reset (upstream's Reset clears its Settings storage the same way).
    config_files.reset()
    return redirect(url_for("home.index"))


@bp.post("/Export/UnityProject")
def export_unity_project():
    output_path = request.form.get("OutputPath", "").strip()
    if not game_file_loader.has_game_data():
        flash("Load a game folder first (use Load Folder, not Load File -- export needs the full game structure).")
        return redirect(url_for("home.index"))
    if not output_path:
        flash("An output directory is required. To just look around without exporting to disk, use the preview link instead.")
        return redirect(url_for("home.index"))

    try:
        game_file_loader.start_export(output_path)
    except RuntimeError as ex:
        flash(str(ex))
        return redirect(url_for("home.index"))

    flash(f"Export started to {output_path} -- see progress below.")
    return redirect(url_for("home.index"))


@bp.get("/Export/Progress")
def export_progress():
    return jsonify(game_file_loader.export_progress())


@bp.post("/Export/PrimaryContent")
def export_primary_content():
    flash("Primary content export is not implemented in this Python port (needs AssetRipper.Export.PrimaryContent).")
    return redirect(url_for("home.index"))

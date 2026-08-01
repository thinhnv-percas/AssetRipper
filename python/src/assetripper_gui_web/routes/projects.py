"""Phase 17 (python/ROADMAP.md): browse an exported Unity project's `Assets/`/
`ProjectSettings/`/`Packages/` tree directly in the GUI, instead of only ever writing to disk
and leaving the user to open it with their OS file explorer.

**This is an additive feature, not a port** -- upstream's GUI has no equivalent page; it exports
and stops. Scoped to the "17a-lite" option from the ROADMAP: no `VirtualFileSystem`, just a real
directory on disk (either a `tempfile.mkdtemp` `game_file_loader.start_export` created when the
GUI's OutputPath was left blank, or an arbitrary previously-exported folder via `/Project/Load`)
walked with plain `os.listdir`. This is a **browsable tree of exported files, not a Unity
Editor**: no importer, no reference validation, no scene hierarchy view -- open the folder in
the real Unity Editor for that.
"""
from __future__ import annotations

import os

from flask import Blueprint, Response, abort, flash, redirect, render_template, request, url_for

from .. import game_file_loader
from ..asset_preview import mime_type_for_extension

bp = Blueprint("projects", __name__, url_prefix="/Project")


def _resolve(root: str, rel_path: str) -> str:
    """Joins `rel_path` onto `root` and confirms the result doesn't escape `root` -- guards
    the classic path-traversal case (`../../etc/passwd` via the `path` query param)."""
    rel_path = (rel_path or "").replace("\\", "/").lstrip("/")
    candidate = os.path.normpath(os.path.join(root, rel_path))
    root_real = os.path.realpath(root)
    candidate_real = os.path.realpath(candidate)
    if candidate_real != root_real and not candidate_real.startswith(root_real + os.sep):
        abort(400, description="Path escapes the exported project root.")
    return candidate_real


@bp.get("/", strict_slashes=False)
def index():
    return browse()


@bp.get("/Browse")
def browse():
    if not game_file_loader.has_exported_project():
        flash("No exported project to browse yet -- export one, or load a previously exported folder below.")
        return redirect(url_for("home.index"))

    root = game_file_loader.exported_project_dir()
    rel_path = request.args.get("path", "")
    directory = _resolve(root, rel_path)
    if not os.path.isdir(directory):
        abort(404, description="Not a directory in the exported project.")

    entries = []
    for name in sorted(os.listdir(directory)):
        full = os.path.join(directory, name)
        child_rel = os.path.join(rel_path, name).replace("\\", "/") if rel_path else name
        entries.append(
            {
                "name": name,
                "is_dir": os.path.isdir(full),
                "rel_path": child_rel,
                "size": None if os.path.isdir(full) else os.path.getsize(full),
            }
        )
    entries.sort(key=lambda e: (not e["is_dir"], e["name"].lower()))

    crumbs = []
    if rel_path:
        parts = rel_path.split("/")
        accumulated = ""
        for part in parts:
            accumulated = f"{accumulated}/{part}" if accumulated else part
            crumbs.append({"name": part, "rel_path": accumulated})

    return render_template(
        "projects/view.html",
        page_title="Exported Project",
        root=root,
        rel_path=rel_path,
        crumbs=crumbs,
        entries=entries,
    )


@bp.get("/File")
def file():
    if not game_file_loader.has_exported_project():
        abort(404, description="No exported project to browse.")

    root = game_file_loader.exported_project_dir()
    rel_path = request.args.get("path", "")
    path = _resolve(root, rel_path)
    if not os.path.isfile(path):
        abort(404, description="File not found in the exported project.")

    extension = os.path.splitext(path)[1].lstrip(".")
    with open(path, "rb") as f:
        data = f.read()
    return Response(data, mimetype=mime_type_for_extension(extension))


@bp.post("/Load")
def load():
    path = request.form.get("Path", "")
    try:
        game_file_loader.load_exported_project(path)
    except FileNotFoundError as ex:
        flash(str(ex))
        return redirect(url_for("home.index"))

    return redirect(url_for("projects.browse"))

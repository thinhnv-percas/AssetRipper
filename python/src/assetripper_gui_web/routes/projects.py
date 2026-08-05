"""Phase 17 (rewritten, python/ROADMAP.md): preview the files that WOULD be exported --
assets and code -- directly in the GUI, right after loading a game, with **no** export-to-disk
step required. Reads from `game_file_loader.get_export_plan()` (Phase 17b's `ExportPlan`, built
by running the real `ExportHandler.export()` into an in-memory `VirtualFileSystem`, Phase 17a)
rather than a real disk directory -- this replaces the first, wrong-goal implementation
(commit `37db9bf`, "browse a project already exported to disk", which required an export step
first and only ever looked at a real directory).

`/Project/Load` (secondary path, kept from `37db9bf` as the ROADMAP recommends): still lets a
user point at a real directory exported in an earlier run/process, without needing the source
game loaded. Whenever that's been used, it takes priority over the `ExportPlan` preview -- see
`game_file_loader.has_exported_project()`/its module docstring for the precedence rule. A fresh
`load_paths()` clears it, falling back to previewing the newly loaded game.

URL shapes kept identical to `37db9bf` (`/Project`, `/Project/Browse?path=`, `/Project/File?path=`,
`/Project/Load`) -- per the ROADMAP, only the *data source* changes, not the route surface.
`/Project/Browse` does double duty as both the directory-listing view and the single-file
inline-preview view (dispatched on whether `path` resolves to a directory or a file), so no new
URL was needed to satisfy "render inline, not just downloadable" -- `/Project/File` stays the
raw-bytes endpoint an `<img>`/`<audio>` `src` (or a plain download link) points at, exactly as
the ROADMAP specifies.
"""
from __future__ import annotations

import os

from flask import Blueprint, Response, abort, flash, redirect, render_template, request, url_for

from .. import game_file_loader
from ..asset_preview import (
    AUDIO_EXTENSIONS,
    CODE_EXTENSIONS,
    IMAGE_EXTENSIONS,
    MESH_EXTENSIONS,
    TEXT_EXTENSIONS,
    YAML_EXTENSIONS,
    mime_type_for_extension,
)

bp = Blueprint("projects", __name__, url_prefix="/Project")


def _extension_of(name: str) -> str:
    return name.rsplit(".", 1)[-1].lower() if "." in name else ""


def _render_kind(extension: str) -> str:
    if extension in IMAGE_EXTENSIONS:
        return "image"
    if extension in AUDIO_EXTENSIONS:
        return "audio"
    if extension in CODE_EXTENSIONS:
        return "code"
    if extension in TEXT_EXTENSIONS or extension in YAML_EXTENSIONS:
        return "text"
    if extension in MESH_EXTENSIONS:
        return "mesh"
    return "binary"


def _crumbs(rel_path: str) -> list[dict]:
    crumbs = []
    if rel_path:
        accumulated = ""
        for part in rel_path.split("/"):
            accumulated = f"{accumulated}/{part}" if accumulated else part
            crumbs.append({"name": part, "rel_path": accumulated})
    return crumbs


# --- Two data sources, normalized to a common shape: {"kind": "dir", "entries": [...], -----
# "rel_path": ...} or {"kind": "file", "rel_path": ..., "extension": ..., "data": bytes} --------


def _resolve_disk(root: str, rel_path: str) -> dict:
    """Guards the classic path-traversal case (`../../etc/passwd` via the `path` query param)
    against a real directory on disk."""
    rel_path = (rel_path or "").replace("\\", "/").lstrip("/")
    candidate = os.path.normpath(os.path.join(root, rel_path))
    root_real = os.path.realpath(root)
    candidate_real = os.path.realpath(candidate)
    if candidate_real != root_real and not candidate_real.startswith(root_real + os.sep):
        abort(400, description="Path escapes the exported project root.")

    if os.path.isdir(candidate_real):
        entries = []
        for name in sorted(os.listdir(candidate_real)):
            full = os.path.join(candidate_real, name)
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
        return {"kind": "dir", "entries": entries, "rel_path": rel_path}

    if os.path.isfile(candidate_real):
        with open(candidate_real, "rb") as f:
            data = f.read()
        return {"kind": "file", "rel_path": rel_path, "extension": _extension_of(os.path.basename(candidate_real)), "data": data}

    abort(404, description="Not found in the exported project.")


def _resolve_plan(plan, rel_path: str) -> dict:
    """No separate path-traversal guard needed: `VirtualFileSystem` paths are dict lookups by
    literal component name (see its module docstring) -- there is no directory entry literally
    named `..` to escape into, so a `../` segment just fails to resolve like any other bogus
    name, the same way it would 404 on a real disk path outside the root."""
    fs = plan.file_system
    normalized = fs.path.get_full_path(rel_path or "/")

    if fs.directory.exists(normalized):
        entries = []
        for dir_path in fs.directory.get_directories(normalized):
            entries.append({"name": fs.path.get_file_name(dir_path), "is_dir": True, "rel_path": dir_path.lstrip("/"), "size": None})
        for file_path in fs.directory.get_files(normalized):
            size = len(fs.file.read_all_bytes(file_path))
            entries.append({"name": fs.path.get_file_name(file_path), "is_dir": False, "rel_path": file_path.lstrip("/"), "size": size})
        entries.sort(key=lambda e: (not e["is_dir"], e["name"].lower()))
        return {"kind": "dir", "entries": entries, "rel_path": normalized.lstrip("/")}

    if fs.file.exists(normalized):
        data = fs.file.read_all_bytes(normalized)
        return {"kind": "file", "rel_path": normalized.lstrip("/"), "extension": _extension_of(fs.path.get_file_name(normalized)), "data": data}

    abort(404, description="Not found in the export preview.")


# --- Left pane: the project tree -----------------------------------------------------------
#
# Both sources already expose "list one directory" (`_resolve_disk`/`_resolve_plan` above), so
# the tree is built from repeated one-level listings rather than a second traversal
# implementation per source. `_list_dir` is the single adapter that hides which source is in
# play; everything below it is source-agnostic.


def _list_dir(source, rel_path: str) -> "list[dict]":
    """One directory's entries, or `[]` if `rel_path` isn't a directory in this source."""
    kind, payload = source
    try:
        result = _resolve_disk(payload, rel_path) if kind == "disk" else _resolve_plan(payload, rel_path)
    except Exception:  # noqa: BLE001 -- a 400/404 abort just means "nothing to show here"
        return []
    return result["entries"] if result["kind"] == "dir" else []


def _build_tree(source, selected_rel_path: str) -> "list[dict]":
    """A **path-expanded** tree: every ancestor of `selected_rel_path` is expanded to show its
    children, and every other directory is rendered collapsed (a link that re-renders the page
    expanded at that node).

    Deliberately not a full recursive walk. A real exported game is large -- the
    `demo-android.apk` fixture produces ~4,500 files -- so emitting every node would mean a
    multi-megabyte page of mostly-collapsed markup on every request. Path-expansion bounds the
    output to roughly (depth x siblings-per-level) instead, which is what a file explorer
    actually shows, and it needs no client-side JavaScript or lazy-load endpoint to do it.
    """
    expanded = set()
    accumulated = ""
    for part in (selected_rel_path or "").split("/"):
        if not part:
            continue
        accumulated = f"{accumulated}/{part}" if accumulated else part
        expanded.add(accumulated)

    def build(rel_path: str, depth: int) -> "list[dict]":
        nodes = []
        for entry in _list_dir(source, rel_path):
            node = {
                "name": entry["name"],
                "rel_path": entry["rel_path"],
                "is_dir": entry["is_dir"],
                "size": entry["size"],
                "depth": depth,
                "is_selected": entry["rel_path"] == selected_rel_path,
                "is_expanded": entry["is_dir"] and entry["rel_path"] in expanded,
                "children": [],
            }
            if node["is_expanded"]:
                node["children"] = build(entry["rel_path"], depth + 1)
            nodes.append(node)
        return nodes

    return build("", 0)


def _asset_count_warning(plan) -> bool:
    """Phase 17c's mandatory honesty banner: if the loaded build has (almost) no readable
    asset files under Assets/, that's Phase 18's real "no type tree" gap surfacing, not a bug
    in this preview -- the user must not be left to guess the game is simply empty."""
    asset_files = [p for p in plan.all_files() if p.startswith("/Assets/") and not p.endswith(".meta")]
    return len(asset_files) == 0


@bp.get("/", strict_slashes=False)
def index():
    return browse()


@bp.get("/Browse")
def browse():
    if not game_file_loader.has_browsable_project():
        flash("No game loaded yet -- load one first (Load Folder); its export preview appears here automatically, no export step needed.")
        return redirect(url_for("home.index"))

    rel_path = request.args.get("path", "")
    using_disk = game_file_loader.has_exported_project()
    if using_disk:
        source = ("disk", game_file_loader.exported_project_dir())
        warn_empty = False
    else:
        plan = game_file_loader.get_export_plan()
        source = ("plan", plan)
        warn_empty = _asset_count_warning(plan)

    result = _resolve_disk(source[1], rel_path) if using_disk else _resolve_plan(source[1], rel_path)
    normalized_rel_path = result["rel_path"]

    file_view = None
    if result["kind"] == "file":
        extension = result["extension"]
        kind = _render_kind(extension)
        file_view = {
            "rel_path": normalized_rel_path,
            "extension": extension,
            "kind": kind,
            "text": result["data"].decode("utf-8", errors="replace") if kind in ("text", "code") else None,
            "size": len(result["data"]),
        }
        warn_empty = False

    return render_template(
        "projects/view.html",
        page_title="Export Preview",
        crumbs=_crumbs(normalized_rel_path),
        tree=_build_tree(source, normalized_rel_path),
        entries=result["entries"] if result["kind"] == "dir" else None,
        file_view=file_view,
        using_disk=using_disk,
        warn_empty=warn_empty,
    )


@bp.get("/File")
def file():
    if not game_file_loader.has_browsable_project():
        abort(404, description="No game loaded.")

    rel_path = request.args.get("path", "")
    if game_file_loader.has_exported_project():
        result = _resolve_disk(game_file_loader.exported_project_dir(), rel_path)
    else:
        result = _resolve_plan(game_file_loader.get_export_plan(), rel_path)

    if result["kind"] != "file":
        abort(404, description="Not a file.")

    return Response(result["data"], mimetype=mime_type_for_extension(result["extension"]))


@bp.post("/Load")
def load():
    path = request.form.get("Path", "")
    try:
        game_file_loader.load_exported_project(path)
    except FileNotFoundError as ex:
        flash(str(ex))
        return redirect(url_for("home.index"))

    return redirect(url_for("projects.browse"))

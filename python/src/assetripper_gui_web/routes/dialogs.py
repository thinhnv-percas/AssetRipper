"""Native file/folder picker (Phase 11), the closest equivalent to upstream's
Source/AssetRipper.GUI.Web/Dialogs.cs + NativeDialogs (which shell out to OS-native pickers
via P/Invoke on Windows/Linux/macOS). Python's stdlib equivalent is `tkinter.filedialog`,
which needs a real Tk/X11 display -- this only works when the GUI runs on the user's own
desktop machine (the intended use of the `.bat` launcher), not a headless/remote server.

Degrades on purpose: any failure (no `tkinter`, no display, dialog cancelled) reports
`{"available": False}` with a 404 rather than raising, so the browser-side JS in
index.html falls back to the existing manual text input instead of showing a broken
picker button.

**Phase 19a:** `askopenfilename`'s `filetypes` now lists the archive/bundle inputs
`load_paths` actually accepts (`.apk`/`.ipa`/`.obb`/`.zip`/`.assets`/`.bundle`/`.unity3d`) so the
native picker's default filter doesn't hide them -- before this, a user picking a `.apk` off
their desktop had no reason to expect the dialog would show it. "All files" is still listed so
nothing is ever actually hidden, just deprioritized.

**2026-08-03 (Phase 20e audit follow-up):** upstream has five dialog endpoints; this port had
two. Added the three missing ones -- `/Dialogs/Files` and `/Dialogs/Folders` (multi-select,
upstream's `OpenFiles`/`OpenFolders`) and `/Dialogs/SaveFile`. Multi-select is a genuine
capability gain rather than pure convenience: `game_file_loader.load_paths` has always taken a
*list* of paths (a split APK + its `.obb` is the standard real case), but nothing in the GUI
could ever produce more than one. `/Dialogs/SaveFile` is what an "export to..." field wants,
where the target doesn't exist yet so a folder picker won't do.

Multi-select responses return `{"paths": [...]}`; single-select keeps `{"path": "..."}` so the
existing callers in `index.html` don't change. `askdirectory` has no multi-select mode in Tk at
all, so `/Dialogs/Folders` collects folders one at a time until the user cancels -- documented
in that route rather than pretending Tk offers something it doesn't.
"""
from __future__ import annotations

from flask import Blueprint, jsonify

bp = Blueprint("dialogs", __name__, url_prefix="/Dialogs")

_GAME_FILE_TYPES = [
    ("Game archives and bundles", "*.apk *.ipa *.obb *.zip *.assets *.bundle *.unity3d"),
    ("All files", "*.*"),
]

_MAX_FOLDERS = 32
"""Safety bound on `/Dialogs/Folders`' repeat-until-cancel loop, so a stuck dialog can't spin
forever. Far above any realistic number of game directories."""


def _with_tk(action):
    """Runs `action(root, filedialog)` against a hidden, top-most Tk root, returning None on any
    failure (no tkinter, no display, dialog cancelled) so every route can degrade identically."""
    try:
        import tkinter
        from tkinter import filedialog
    except ImportError:
        return None

    try:
        root = tkinter.Tk()
        root.withdraw()
        root.attributes("-topmost", True)
        try:
            return action(root, filedialog)
        finally:
            root.destroy()
    except Exception:  # noqa: BLE001 -- any Tk/display failure just degrades to unavailable
        return None


def _single(result):
    if not result:
        return jsonify({"available": False}), 404
    return jsonify({"available": True, "path": result})


def _multiple(results):
    if not results:
        return jsonify({"available": False}), 404
    return jsonify({"available": True, "paths": list(results)})


@bp.get("/File")
def file():
    return _single(_with_tk(lambda root, fd: fd.askopenfilename(parent=root, filetypes=_GAME_FILE_TYPES) or None))


@bp.get("/Files")
def files():
    """Upstream's `OpenFiles`. `askopenfilenames` returns a tuple (possibly empty on cancel)."""

    def action(root, fd):
        selected = fd.askopenfilenames(parent=root, filetypes=_GAME_FILE_TYPES)
        return list(selected) if selected else None

    return _multiple(_with_tk(action))


@bp.get("/Folder")
def folder():
    return _single(_with_tk(lambda root, fd: fd.askdirectory(parent=root) or None))


@bp.get("/Folders")
def folders():
    """Upstream's `OpenFolders`. Tk has **no** multi-select directory dialog, so this reopens the
    single-folder picker until the user cancels, accumulating what they chose. That's a real UX
    difference from upstream's native multi-select dialog, not a hidden one -- but it does let a
    user hand `load_paths` several game directories, which was previously impossible."""

    def action(root, fd):
        chosen: list[str] = []
        while len(chosen) < _MAX_FOLDERS:
            path = fd.askdirectory(parent=root)
            if not path:
                break
            if path not in chosen:
                chosen.append(path)
        return chosen or None

    return _multiple(_with_tk(action))


@bp.get("/SaveFile")
def save_file():
    """Upstream's `SaveFile`. Unlike the open dialogs this returns a path that need not exist
    yet, which is what an export-target field actually needs."""
    return _single(_with_tk(lambda root, fd: fd.asksaveasfilename(parent=root) or None))

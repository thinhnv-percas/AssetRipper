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
"""
from __future__ import annotations

from flask import Blueprint, jsonify

bp = Blueprint("dialogs", __name__, url_prefix="/Dialogs")

_GAME_FILE_TYPES = [
    ("Game archives and bundles", "*.apk *.ipa *.obb *.zip *.assets *.bundle *.unity3d"),
    ("All files", "*.*"),
]


def _open_dialog(kind: str) -> "str | None":
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
            if kind == "file":
                path = filedialog.askopenfilename(parent=root, filetypes=_GAME_FILE_TYPES)
            else:
                path = filedialog.askdirectory(parent=root)
        finally:
            root.destroy()
        return path or None
    except Exception:  # noqa: BLE001 -- any Tk/display failure just degrades to unavailable
        return None


@bp.get("/File")
def file():
    path = _open_dialog("file")
    if path is None:
        return jsonify({"available": False}), 404
    return jsonify({"available": True, "path": path})


@bp.get("/Folder")
def folder():
    path = _open_dialog("folder")
    if path is None:
        return jsonify({"available": False}), 404
    return jsonify({"available": True, "path": path})

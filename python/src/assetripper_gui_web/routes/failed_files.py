"""Port of Source/AssetRipper.GUI.Web/Pages/FailedFiles/{FailedFileAPI,ViewPage}.cs"""
from __future__ import annotations

from flask import Blueprint, abort, render_template

from .. import game_file_loader
from ..path_params import get_path_param
from ..paths import FailedFilePath, try_get_failed_file

bp = Blueprint("failed_files", __name__, url_prefix="/FailedFiles")


def _resolve(path: FailedFilePath):
    if not game_file_loader.is_loaded():
        abort(404, description="No files loaded.")
    failed_file = try_get_failed_file(game_file_loader.game_bundle(), path)
    if failed_file is None:
        abort(404, description=f"Failed file could not be resolved: {path}")
    return failed_file


@bp.get("/View")
def view():
    path = get_path_param(FailedFilePath)
    failed_file = _resolve(path)
    return render_template("failed_files/view.html", failed_file=failed_file, path=path)


@bp.get("/StackTrace")
def stack_trace():
    path = get_path_param(FailedFilePath)
    failed_file = _resolve(path)
    return failed_file.stack_trace, 200, {"Content-Type": "text/plain"}

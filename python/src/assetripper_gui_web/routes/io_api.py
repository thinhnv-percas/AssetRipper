"""Port of the /IO/* file-system probe endpoints registered directly in
Source/AssetRipper.GUI.Web/WebApplicationLauncher.cs. These are fully functional --
they only need the local filesystem, no loaded GameBundle."""
from __future__ import annotations

import os

from flask import Blueprint, abort, jsonify, request

bp = Blueprint("io_api", __name__, url_prefix="/IO")


def _require_path() -> str:
    path = request.args.get("Path")
    if not path:
        abort(400)
    return path


@bp.get("/File/Exists")
def file_exists():
    return jsonify(os.path.isfile(_require_path()))


@bp.get("/Directory/Exists")
def directory_exists():
    return jsonify(os.path.isdir(_require_path()))


@bp.get("/Directory/Empty")
def directory_empty():
    path = _require_path()
    empty = not os.path.isdir(path) or not os.listdir(path)
    return jsonify(empty)

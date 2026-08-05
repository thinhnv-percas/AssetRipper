"""Port of Source/AssetRipper.GUI.Web/Pages/Resources/{ResourceAPI,ViewPage}.cs"""
from __future__ import annotations

from flask import Blueprint, Response, abort, render_template

from .. import game_file_loader
from ..path_params import get_path_param
from ..paths import ResourcePath, try_get_resource

bp = Blueprint("resources", __name__, url_prefix="/Resources")


def _resolve(path: ResourcePath):
    if not game_file_loader.is_loaded():
        abort(404, description="No files loaded.")
    resource = try_get_resource(game_file_loader.game_bundle(), path)
    if resource is None:
        abort(404, description=f"Resource could not be resolved: {path}")
    return resource


@bp.get("/View")
def view():
    path = get_path_param(ResourcePath)
    resource = _resolve(path)
    return render_template("resources/view.html", resource=resource, path=path)


@bp.get("/Data")
def data():
    path = get_path_param(ResourcePath)
    resource = _resolve(path)
    payload = resource.to_byte_array() if hasattr(resource, "to_byte_array") else b""
    return Response(payload, mimetype="application/octet-stream")

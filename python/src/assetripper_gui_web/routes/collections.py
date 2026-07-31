"""Port of Source/AssetRipper.GUI.Web/Pages/Collections/{CollectionAPI,ViewPage}.cs"""
from __future__ import annotations

from flask import Blueprint, abort, render_template

from .. import game_file_loader
from ..path_params import get_path_param
from ..paths import CollectionPath, try_get_collection

bp = Blueprint("collections", __name__, url_prefix="/Collections")


def _resolve(path: CollectionPath):
    if not game_file_loader.is_loaded():
        abort(404, description="No files loaded.")
    collection = try_get_collection(game_file_loader.game_bundle(), path)
    if collection is None:
        abort(404, description=f"Collection could not be resolved: {path}")
    return collection


@bp.get("/View")
def view():
    path = get_path_param(CollectionPath)
    collection = _resolve(path)
    assets = [(asset, path.get_asset(path_id)) for path_id, asset in collection.assets.items()]
    return render_template("collections/view.html", collection=collection, path=path, assets=assets)


@bp.get("/Count")
def count():
    path = get_path_param(CollectionPath)
    collection = _resolve(path)
    return {"count": len(collection.assets)}

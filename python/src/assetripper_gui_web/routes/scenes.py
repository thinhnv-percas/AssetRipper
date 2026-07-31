"""Port of Source/AssetRipper.GUI.Web/Pages/Scenes/{SceneAPI,ViewPage}.cs

This Python port's raw-SerializedFile loader (game_file_loader.load_file) never
assigns AssetCollection.scene, so no collection will ever resolve as a scene yet --
scene grouping is set up by AssetRipper.Processing, which isn't ported. The route is
wired up so it will work once/if a collection with .scene set exists.
"""
from __future__ import annotations

from flask import Blueprint, abort, render_template

from .. import game_file_loader
from ..path_params import get_path_param
from ..paths import ScenePath, try_get_collection

bp = Blueprint("scenes", __name__, url_prefix="/Scenes")


@bp.get("/View")
def view():
    path = get_path_param(ScenePath)
    if not game_file_loader.is_loaded():
        abort(404, description="No files loaded.")
    collection = try_get_collection(game_file_loader.game_bundle(), path.first_collection)
    if collection is None:
        abort(404, description=f"Scene could not be resolved: {path.first_collection}")
    if not collection.is_scene:
        abort(404, description=f"Collection is not a scene: {path.first_collection}")

    return render_template("scenes/view.html", scene=collection.scene, path=path)

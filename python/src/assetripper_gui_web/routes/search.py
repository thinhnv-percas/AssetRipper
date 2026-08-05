"""Port of Source/AssetRipper.GUI.Web/Pages/Search/{SearchAPI,ViewPage}.cs's PerformSearch/Match."""
from __future__ import annotations

from flask import Blueprint, abort, render_template, request

from .. import game_file_loader
from ..paths import get_asset_path

bp = Blueprint("search", __name__, url_prefix="/Search")


def _matches(asset, query: str) -> bool:
    query = query.lower()
    if query in asset.get_best_name().lower():
        return True
    return query in asset.class_name.lower()


@bp.get("/View")
def view():
    query = request.args.get("q", "").strip()
    results = []
    if query:
        if not game_file_loader.is_loaded():
            abort(404, description="No files loaded.")
        for collection in game_file_loader.game_bundle().fetch_asset_collections():
            for asset in collection:
                if _matches(asset, query):
                    results.append((asset, collection, get_asset_path(asset)))

    return render_template("search/view.html", query=query, results=results)

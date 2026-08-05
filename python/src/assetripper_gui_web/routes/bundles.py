"""Port of Source/AssetRipper.GUI.Web/Pages/Bundles/{BundleAPI,ViewPage}.cs"""
from __future__ import annotations

from flask import Blueprint, abort, render_template

from .. import game_file_loader
from ..path_params import get_path_param
from ..paths import BundlePath, try_get_bundle

bp = Blueprint("bundles", __name__, url_prefix="/Bundles")


@bp.get("/View")
def view():
    path = get_path_param(BundlePath)
    if not game_file_loader.is_loaded():
        abort(404, description="No files loaded.")
    bundle = try_get_bundle(game_file_loader.game_bundle(), path)
    if bundle is None:
        abort(404, description=f"Bundle could not be resolved: {path}")

    return render_template(
        "bundles/view.html",
        bundle=bundle,
        path=path,
        child_bundles=[(b, path.get_child(i)) for i, b in enumerate(bundle.bundles)],
        collections=[(c, path.get_collection(i)) for i, c in enumerate(bundle.collections)],
        resources=[(r, path.get_resource(i)) for i, r in enumerate(bundle.resources)],
        failed_files=[(f, path.get_failed_file(i)) for i, f in enumerate(bundle.failed_files)],
    )

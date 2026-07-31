"""
Python/Flask port of the route skeleton of Source/AssetRipper.GUI.Web.

AssetRipper.GUI.Web is ASP.NET Core minimal APIs plus a hand-written C# HTML-builder
DSL (no MVC/Razor). Flask + Jinja2 templates is the natural Python replacement for
that combination, so this is a fresh implementation of the route map and page
structure, not a line-by-line port of the tag-builder classes.

Only a fraction of pages are functional: file loading and raw metadata browsing of
Unity SerializedFiles (info/hex views) work end-to-end via the already-ported
AssetRipper.IO.Files/AssetRipper.Assets packages. Everything that depends on the
Import -> Processing -> Export pipeline or the SourceGenerated typed asset classes
(image/audio/model/text/yaml asset tabs, project export, settings persistence beyond
a stub) is out of scope -- that pipeline requires Mono.Cecil IL analysis of compiled
Unity assemblies, which has no reasonable Python equivalent.
"""
from __future__ import annotations

from flask import Flask


def create_app() -> Flask:
    app = Flask(__name__)
    app.secret_key = "assetripper-gui-web-dev"

    from .routes.assets import bp as assets_bp
    from .routes.bundles import bp as bundles_bp
    from .routes.collections import bp as collections_bp
    from .routes.commands import bp as commands_bp
    from .routes.failed_files import bp as failed_files_bp
    from .routes.home import bp as home_bp
    from .routes.io_api import bp as io_api_bp
    from .routes.resources import bp as resources_bp
    from .routes.scenes import bp as scenes_bp
    from .routes.search import bp as search_bp

    app.register_blueprint(home_bp)
    app.register_blueprint(commands_bp)
    app.register_blueprint(bundles_bp)
    app.register_blueprint(collections_bp)
    app.register_blueprint(assets_bp)
    app.register_blueprint(resources_bp)
    app.register_blueprint(failed_files_bp)
    app.register_blueprint(scenes_bp)
    app.register_blueprint(search_bp)
    app.register_blueprint(io_api_bp)

    return app

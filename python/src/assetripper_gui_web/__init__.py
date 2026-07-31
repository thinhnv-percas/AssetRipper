"""
Python/Flask port of the route skeleton of Source/AssetRipper.GUI.Web.

AssetRipper.GUI.Web is ASP.NET Core minimal APIs plus a hand-written C# HTML-builder
DSL (no MVC/Razor). Flask + Jinja2 templates is the natural Python replacement for
that combination, so this is a fresh implementation of the route map and page
structure, not a line-by-line port of the tag-builder classes.

As of Phase 8 (see python/ROADMAP.md), `/LoadFolder` and `/Export/UnityProject` drive the
real Import -> Processing -> Export pipeline end to end (game_file_loader.load_paths ->
ExportHandler -> ProjectExporter), not a Mono.Cecil-based one -- this port's dynamic
TypeTree reader (assetripper_import/asset_creation/game_asset_factory.py) replaces the
generated SourceGenerated typed asset classes entirely, so no IL analysis is needed. Still
missing (see ROADMAP Phase 9-13): the settings pages remain stubs, several asset tabs
(image/audio/model previews) aren't wired to the content exporters yet, and export of
files whose payload lives in an external .resS (Texture2D/AudioClip/Mesh on most player
builds) is declined rather than guessed at.
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

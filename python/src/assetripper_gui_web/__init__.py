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
generated SourceGenerated typed asset classes entirely, so no IL analysis is needed.
Streamed (`.resS`) payloads export correctly (Phase 9), `/Settings/Edit` is a real form
(Phase 10), and asset preview tabs (Image/Text/Yaml/Binary) plus a live export progress
bar are wired in (Phase 11) -- see ROADMAP Phase 12-13 for what's still a documented gap
(prefab/scene export, several asset types).
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
    from .routes.dialogs import bp as dialogs_bp
    from .routes.failed_files import bp as failed_files_bp
    from .routes.home import bp as home_bp
    from .routes.io_api import bp as io_api_bp
    from .routes.projects import bp as projects_bp
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
    app.register_blueprint(dialogs_bp)
    app.register_blueprint(projects_bp)

    return app

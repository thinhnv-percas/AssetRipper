"""Port of Source/AssetRipper.Export.UnityProjects/ExportHandler.cs

This is the piece that was missing to make the whole port runnable end to end: every
package up to this point (GameStructure discovery, the dynamic reader, processors,
ProjectExporter, post-exporters) existed but nothing in production code called them in
sequence -- only their own tests did. `ExportHandler` is that missing driver: `load()` ->
`process()` -> `export()`, exactly like upstream's `Load`/`Process`/`Export` methods.

Not ported: `FullConfiguration`-based settings (`Settings.ExportRootPath`,
`Settings.SetProjectSettings`, `BeforeExport`/`DoFinalOverrides` premium hooks) -- this port
has no settings model yet (see python/ROADMAP.md Phase 10), so `export()` takes
`output_directory` directly, matching how `ProjectExporter.export` and
`run_default_post_exporters` already do. `ThrowIfSettingsDontMatch` has no counterpart for
the same reason.
"""
from __future__ import annotations

import logging

from assetripper_import.structure.game_structure import GameStructure
from assetripper_processing.default_processors import run_default_processors
from assetripper_processing.game_data import GameData

from .post_exporters import run_default_post_exporters
from .project_exporter import ProjectExporter

_logger = logging.getLogger(__name__)


class ExportHandler:
    def __init__(self, register_exporters=None):
        """`register_exporters(project_exporter)` wires content exporters onto a fresh
        `ProjectExporter` before each export -- defaults to
        `assetripper_export_modules.registration.register_default_exporters`. Passed in
        rather than imported directly to avoid a hard dependency from this package (Export)
        onto assetripper_export_modules, mirroring the layering upstream keeps between
        Export.UnityProjects and its content-module packages."""
        if register_exporters is None:
            from assetripper_export_modules.registration import register_default_exporters

            register_exporters = register_default_exporters
        self._register_exporters = register_exporters

    def load(self, paths, file_system, **kwargs) -> GameData:
        if len(paths) == 1:
            _logger.info("Attempting to read files from %s", paths[0])
        else:
            _logger.info("Attempting to read files from %d paths...", len(paths))

        game_structure = GameStructure.load(paths, file_system, **kwargs)
        game_data = GameData.from_game_structure(game_structure)
        _logger.info("Finished reading files")
        return game_data

    def process(self, game_data: GameData) -> None:
        _logger.info("Processing loaded assets...")
        run_default_processors(game_data)
        _logger.info("Finished processing assets")

    def export(self, game_data: GameData, output_directory: str, file_system) -> None:
        _logger.info("Starting export")
        _logger.info("Attempting to export assets to %s...", output_directory)
        _logger.info("Exporting to Unity version %s", game_data.project_version)

        project_exporter = ProjectExporter()
        self._register_exporters(project_exporter)
        project_exporter.export(game_data.game_bundle, output_directory, file_system, game_data.project_version)
        _logger.info("Finished exporting assets")

        run_default_post_exporters(game_data, output_directory, game_data.project_version, file_system)
        _logger.info("Finished post-export")

    def load_and_process(self, paths, file_system, **kwargs) -> GameData:
        game_data = self.load(paths, file_system, **kwargs)
        if game_data.game_bundle.has_any_asset_collections():
            self.process(game_data)
        return game_data

    def load_process_and_export(self, input_paths, output_directory: str, file_system, **kwargs) -> GameData:
        game_data = self.load_and_process(input_paths, file_system, **kwargs)
        self.export(game_data, output_directory, file_system)
        return game_data

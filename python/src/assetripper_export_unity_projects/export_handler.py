"""Port of Source/AssetRipper.Export.UnityProjects/ExportHandler.cs

This is the piece that was missing to make the whole port runnable end to end: every
package up to this point (GameStructure discovery, the dynamic reader, processors,
ProjectExporter, post-exporters) existed but nothing in production code called them in
sequence -- only their own tests did. `ExportHandler` is that missing driver: `load()` ->
`process()` -> `export()`, exactly like upstream's `Load`/`Process`/`Export` methods.

Not ported: `Settings.ExportRootPath`/`Settings.SetProjectSettings`,
`BeforeExport`/`DoFinalOverrides` premium hooks, `ThrowIfSettingsDontMatch`. A `FullConfiguration`
settings model now exists (Phase 10, assetripper_export_configuration/) and is accepted as an
optional `settings` parameter on `load`/`export`, but `output_directory` stays its own argument
rather than folding into `settings.ExportRootPath` as upstream has it, matching how
`ProjectExporter.export` and `run_default_post_exporters` already replaced settings-object
access with direct arguments.
"""
from __future__ import annotations

import logging

from assetripper_import.structure import zip_extractor
from assetripper_import.structure.game_structure import GameStructure
from assetripper_processing.default_processors import run_default_processors
from assetripper_processing.game_data import GameData

from .post_exporters import run_default_post_exporters
from .project_exporter import ProjectExporter

_logger = logging.getLogger(__name__)


class ExportHandler:
    def __init__(self, register_exporters=None):
        """`register_exporters(project_exporter, settings, assembly_manager=None)` wires
        content exporters onto a fresh `ProjectExporter` before each export -- defaults to
        `assetripper_export_modules.registration.register_default_exporters`. Passed in
        rather than imported directly to avoid a hard dependency from this package (Export)
        onto assetripper_export_modules, mirroring the layering upstream keeps between
        Export.UnityProjects and its content-module packages."""
        if register_exporters is None:
            from assetripper_export_modules.registration import register_default_exporters

            register_exporters = register_default_exporters
        self._register_exporters = register_exporters

    def load(self, paths, file_system, settings=None, progress_callback=None, **kwargs) -> GameData:
        """`settings` (Phase 10): a `FullConfiguration`; only its `import_settings`
        (`default_version`/`target_version`/`ignore_streaming_assets`/`script_content_level`/
        `assembly_directories`) is consulted, and only to fill in values `kwargs` didn't
        already specify -- an explicit keyword argument always wins over `settings`.

        `assembly_directories` (ROADMAP 16c-alt) is the shortcut route into Phase 16 for an
        IL2CPP build: point it at a directory of dummy `.dll` files produced by an external
        tool (Il2CppDumper / Cpp2IL / DevX-GameRecovery) and the 16c metadata reader recovers
        script types from those, without this port parsing `global-metadata.dat` itself.

        `progress_callback` (Phase 19c): forwarded to `GameStructure.load` -- see its
        docstring for exactly what milestones it reports."""
        if settings is not None:
            import_settings = settings.import_settings
            kwargs.setdefault("default_version", import_settings.default_version)
            kwargs.setdefault("target_version", import_settings.target_version)
            kwargs.setdefault("ignore_streaming_assets", import_settings.ignore_streaming_assets)
            kwargs.setdefault("script_content_level", import_settings.script_content_level)
            kwargs.setdefault("assembly_directories", import_settings.assembly_directories)

        if len(paths) == 1:
            _logger.info("Attempting to read files from %s", paths[0])
        else:
            _logger.info("Attempting to read files from %d paths...", len(paths))

        game_structure = GameStructure.load(paths, file_system, progress_callback=progress_callback, **kwargs)
        game_data = GameData.from_game_structure(game_structure)
        _logger.info("Finished reading files")
        return game_data

    def process(self, game_data: GameData, settings=None) -> None:
        _logger.info("Processing loaded assets...")
        run_default_processors(game_data, settings)
        _logger.info("Finished processing assets")

    def export(
        self, game_data: GameData, output_directory: str, file_system, settings=None, progress_callback=None
    ) -> None:
        _logger.info("Starting export")
        _logger.info("Attempting to export assets to %s...", output_directory)
        _logger.info("Exporting to Unity version %s", game_data.project_version)

        project_exporter = ProjectExporter()
        self._register_exporters(project_exporter, settings, assembly_manager=game_data.assembly_manager)
        project_exporter.export(
            game_data.game_bundle,
            output_directory,
            file_system,
            game_data.project_version,
            progress_callback=progress_callback,
        )
        _logger.info("Finished exporting assets")

        run_default_post_exporters(game_data, output_directory, game_data.project_version, file_system, settings)
        _logger.info("Finished post-export")

        # 2026-08-03 fix: clean up any temp directories GameStructure.load extracted an
        # archive into. Must come after post-exporters (not before export, not between
        # export and post-export) -- DllPostExporter reads assembly files that can live
        # inside one of these directories, and streamed-resource exporters read texture/
        # audio/mesh bytes from them throughout the main export pass.
        if game_data.temp_directories:
            zip_extractor.cleanup(game_data.temp_directories, file_system)
            game_data.temp_directories = []

    def load_and_process(self, paths, file_system, settings=None, progress_callback=None, **kwargs) -> GameData:
        game_data = self.load(paths, file_system, settings=settings, progress_callback=progress_callback, **kwargs)
        if game_data.game_bundle.has_any_asset_collections():
            if progress_callback:
                progress_callback("Running processors...")
            self.process(game_data, settings)
        return game_data

    def load_process_and_export(
        self, input_paths, output_directory: str, file_system, settings=None, progress_callback=None, **kwargs
    ) -> GameData:
        game_data = self.load_and_process(input_paths, file_system, settings=settings, **kwargs)
        self.export(game_data, output_directory, file_system, settings, progress_callback=progress_callback)
        return game_data

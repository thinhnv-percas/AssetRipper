"""Port of Source/AssetRipper.Export.UnityProjects/ProjectExporter.cs

Not ported: the `EventExport*` progress events (this port has no GUI progress bar to drive
yet) and `CoreConfiguration`-based configuration -- `export` takes `output_directory` and
`export_version` directly. Only one exporter is registered by default
(`DefaultYamlExporter`, for every asset), matching this phase's scope: Phase 6 registers
more specific exporters (textures, meshes, audio, ...) on top of the same
ObjectHandlerStack-based `override_exporter` mechanism, without needing this class to change.
"""
from __future__ import annotations

import logging

from assetripper_assets.unity_object_base import UnityObjectBase
from assetripper_primitives import UnityVersion

from .object_handler_stack import ObjectHandlerStack
from .project.default_yaml_exporter import DefaultYamlExporter
from .project.project_asset_container import ProjectAssetContainer

_logger = logging.getLogger(__name__)


class ProjectExporter:
    def __init__(self):
        self._asset_exporter_stack = ObjectHandlerStack()
        self.override_exporter(UnityObjectBase, DefaultYamlExporter(), allow_inheritance=True)

    def override_exporter(self, type_: type, exporter, allow_inheritance: bool = True) -> None:
        self._asset_exporter_stack.override_handler(type_, exporter, allow_inheritance)

    def to_export_type(self, type_: type):
        for exporter in self._asset_exporter_stack.get_handler_stack(type_):
            known, asset_type = exporter.to_unknown_export_type(type_)
            if known:
                return asset_type
        raise LookupError(f"There is no exporter that knows the AssetType for unknown asset type '{type_}'")

    def _create_collection(self, asset):
        for exporter in self._asset_exporter_stack.get_handler_stack(type(asset)):
            created, collection = exporter.try_create_collection(asset)
            if created:
                return collection
        raise LookupError(f"There is no exporter that can handle '{asset}'")

    def export(self, game_bundle, output_directory: str, file_system, export_version: UnityVersion | None = None) -> None:
        export_version = export_version if export_version is not None else game_bundle.get_max_unity_version()

        collections = self._create_collections(game_bundle)
        container = ProjectAssetContainer(self, export_version, game_bundle.fetch_assets(), collections)
        exportable_count = sum(1 for c in collections if c.exportable)
        current_exportable = 0

        for collection in collections:
            container.current_collection = collection
            if collection.exportable:
                current_exportable += 1
                _logger.info("(%d/%d) Exporting '%s'", current_exportable, exportable_count, collection.name)
                if not collection.export(container, output_directory, file_system):
                    _logger.warning("Failed to export '%s' (%s)", collection.name, type(collection).__name__)

    def _create_collections(self, game_bundle) -> list:
        collections = []
        queued = set()

        for asset in game_bundle.fetch_assets():
            if asset.asset_info not in queued:
                collection = self._create_collection(asset)
                for element in collection.assets:
                    queued.add(element.asset_info)
                collections.append(collection)

        return collections

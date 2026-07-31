"""Port of Source/AssetRipper.Export.UnityProjects/Project/DefaultYamlExporter.cs"""
from __future__ import annotations

from ..asset_export_collection import AssetExportCollection
from .yaml_exporter_base import YamlExporterBase


class DefaultYamlExporter(YamlExporterBase):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        return True, AssetExportCollection(self, asset)

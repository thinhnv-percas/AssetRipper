"""Port of Source/AssetRipper.Export.UnityProjects/Project/YamlExporterBase.cs

The multi-asset-per-file overload (used upstream for scene/prefab files) is not ported --
see asset_exporter.py's module docstring.
"""
from __future__ import annotations

from assetripper_io_files.asset_type import AssetType

from ..asset_exporter import export_asset
from ..i_asset_exporter import IAssetExporter


class YamlExporterBase(IAssetExporter):
    def export(self, container, asset, path: str, file_system) -> bool:
        return export_asset(container, asset, path, file_system)

    def to_export_type(self, asset) -> AssetType:
        return AssetType.SERIALIZED

    def to_unknown_export_type(self, type_: type) -> "tuple[bool, AssetType]":
        return True, AssetType.SERIALIZED

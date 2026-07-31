"""Port of Source/AssetRipper.Export.UnityProjects/BinaryAssetExporter.cs"""
from __future__ import annotations

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection
from assetripper_export_unity_projects.i_asset_exporter import IAssetExporter
from assetripper_io_files.asset_type import AssetType


class BinaryAssetExporter(IAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        return True, AssetExportCollection(self, asset)

    def to_export_type(self, asset) -> AssetType:
        return AssetType.META

    def to_unknown_export_type(self, type_: type) -> "tuple[bool, AssetType]":
        return True, AssetType.META

    @staticmethod
    def is_valid_data(data) -> bool:
        return data is not None and len(data) > 0

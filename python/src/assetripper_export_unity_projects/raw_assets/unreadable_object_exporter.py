"""Port of Source/AssetRipper.Export.UnityProjects/RawAssets/UnreadableObjectExporter.cs"""
from __future__ import annotations

from assetripper_import.asset_creation.raw_data_object import UnreadableObject
from assetripper_io_files.asset_type import AssetType

from ..i_asset_exporter import IAssetExporter
from .unreadable_export_collection import UnreadableExportCollection


class UnreadableObjectExporter(IAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if isinstance(asset, UnreadableObject):
            return True, UnreadableExportCollection(self, asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        file_system.file.write_all_bytes(path, asset.raw_data)
        return True

    def to_export_type(self, asset) -> AssetType:
        return AssetType.META

    def to_unknown_export_type(self, type_: type) -> "tuple[bool, AssetType]":
        return True, AssetType.META

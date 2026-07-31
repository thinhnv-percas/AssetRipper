"""Port of Source/AssetRipper.Export.UnityProjects/Shaders/ShaderExporterBase.cs"""
from __future__ import annotations

from ..binary_asset_exporter import BinaryAssetExporter
from .shader_export_collection import ShaderExportCollection

_SHADER_CLASS_ID = 48


class ShaderExporterBase(BinaryAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _SHADER_CLASS_ID:
            return True, ShaderExportCollection(self, asset)
        return False, None

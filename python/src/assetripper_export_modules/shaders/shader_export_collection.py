"""Port of Source/AssetRipper.Export.UnityProjects/Shaders/ShaderExportCollection.cs,
scoped down: `nonModifiableTextures` is always empty (see shader_importer.py)."""
from __future__ import annotations

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection
from assetripper_export_unity_projects.project.shader_importer import ShaderImporter


class ShaderExportCollection(AssetExportCollection):
    def _create_importer(self, container):
        importer = ShaderImporter()
        if self.asset.asset_bundle_name is not None:
            importer.asset_bundle_name = self.asset.asset_bundle_name
        return importer

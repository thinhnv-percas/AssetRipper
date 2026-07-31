"""Port of Source/AssetRipper.Processing/Configuration/ProcessingSettings.cs

Not ported: `EnablePrefabOutlining`/`EnableStaticMeshSeparation`/`EnableAssetDeduplication`
-- premium-only upstream, and (per the original port plan) no processor in this repo reads
those settings at all, so there is nothing for them to configure yet.
"""
from __future__ import annotations

from dataclasses import dataclass

from assetripper_processing.configuration.bundled_assets_export_mode import BundledAssetsExportMode


@dataclass
class ProcessingSettings:
    # Matches upstream's real default (BundledAssetsExportMode.DirectExport). Phase 5/8
    # had defaulted default_processors()'s own bundled_assets_export_mode parameter to
    # GROUP_BY_ASSET_TYPE instead -- a small, undocumented deviation from upstream this
    # settings model corrects.
    bundled_assets_export_mode: BundledAssetsExportMode = BundledAssetsExportMode.DIRECT_EXPORT
    remove_nullable_attributes: bool = False
    publicize_assemblies: bool = False

    def to_dict(self) -> dict:
        return {
            "bundled_assets_export_mode": self.bundled_assets_export_mode.name,
            "remove_nullable_attributes": self.remove_nullable_attributes,
            "publicize_assemblies": self.publicize_assemblies,
        }

    @staticmethod
    def from_dict(data: dict) -> "ProcessingSettings":
        defaults = ProcessingSettings()
        return ProcessingSettings(
            bundled_assets_export_mode=BundledAssetsExportMode[
                data.get("bundled_assets_export_mode", defaults.bundled_assets_export_mode.name)
            ],
            remove_nullable_attributes=data.get("remove_nullable_attributes", defaults.remove_nullable_attributes),
            publicize_assemblies=data.get("publicize_assemblies", defaults.publicize_assemblies),
        )

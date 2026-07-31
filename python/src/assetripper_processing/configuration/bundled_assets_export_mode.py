"""Port of Source/AssetRipper.Processing/Configuration/BundledAssetsExportMode.cs"""
from __future__ import annotations

from enum import Enum, auto


class BundledAssetsExportMode(Enum):
    GROUP_BY_ASSET_TYPE = auto()
    """Bundled assets are treated the same as assets from other files."""
    GROUP_BY_BUNDLE_NAME = auto()
    """Bundled assets are grouped by their asset bundle name, e.g.
    Assets/Asset_Bundles/NameOfAssetBundle/InternalPath1/.../InternalPathN/assetName.ext."""
    DIRECT_EXPORT = auto()
    """Bundled assets are exported without grouping, e.g.
    Assets/InternalPath1/.../InternalPathN/bundledAssetName.ext."""

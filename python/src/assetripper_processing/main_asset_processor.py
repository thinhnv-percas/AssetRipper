"""Port of Source/AssetRipper.Processing/MainAssetProcessor.cs

Scoped down to the certain, class-ID-driven self-pairing (Font/TerrainData are their own
main asset). The cross-asset pairing (`font.TryGetFontMaterial`/`TryGetFontTexture`,
`terrainData.GetSplatAlphaTextures`) is not ported: those are generated extension methods
built on exact field layouts this port doesn't have confirmed, and their effect is limited
to combined-asset export grouping (Phase 6, not yet implemented), so nothing depends on it
yet.
"""
from __future__ import annotations

from assetripper_import.class_id_type import ClassIDType

from .i_asset_processor import IAssetProcessor

_SELF_MAIN_ASSET_CLASS_IDS = frozenset({ClassIDType.Font, ClassIDType.TerrainData})


class MainAssetProcessor(IAssetProcessor):
    def process(self, game_data) -> None:
        for asset in game_data.game_bundle.fetch_assets():
            if asset.class_id in _SELF_MAIN_ASSET_CLASS_IDS:
                asset.main_asset = asset

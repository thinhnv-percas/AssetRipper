"""Port of Source/AssetRipper.Assets/EmptyAsset.cs"""
from __future__ import annotations

from .unity_asset_base import UnityAssetBase


class EmptyAsset(UnityAssetBase):
    _instance: "EmptyAsset | None" = None

    def __new__(cls):
        if cls is not EmptyAsset:
            return super().__new__(cls)
        if EmptyAsset._instance is None:
            EmptyAsset._instance = super().__new__(cls)
        return EmptyAsset._instance

    @staticmethod
    def instance() -> "EmptyAsset":
        return EmptyAsset()

"""Port of Source/AssetRipper.Assets/Metadata/NullPPtr.cs"""
from __future__ import annotations

from ..unity_asset_base import UnityAssetBase
from .i_pptr import IPPtr


class NullPPtr(UnityAssetBase, IPPtr):
    _instance: "NullPPtr | None" = None

    def __new__(cls):
        if NullPPtr._instance is None:
            NullPPtr._instance = super().__new__(cls)
        return NullPPtr._instance

    @staticmethod
    def instance() -> "NullPPtr":
        return NullPPtr()

    @property
    def file_id(self) -> int:
        return 0

    @property
    def path_id(self) -> int:
        return 0

    def set_asset(self, collection, asset) -> None:
        raise NotImplementedError("NullPPtr cannot be assigned an asset.")

    def try_get_asset(self, collection) -> tuple[bool, object]:
        return False, None

"""Port of Source/AssetRipper.Assets/Bundles/ProcessedBundle.cs

A Bundle containing ProcessedAssetCollections.
"""
from __future__ import annotations

from assetripper_primitives import UnityGuid

from .virtual_bundle import VirtualBundle


class ProcessedBundle(VirtualBundle):
    def __init__(self, name: str | None = None):
        super().__init__()
        from assetripper_assets.collections.processed_asset_collection import ProcessedAssetCollection

        self.collection_type = ProcessedAssetCollection
        self._name = name if name else _generate_random_name()

    @property
    def name(self) -> str:
        return self._name

    def add_new_processed_collection(self, name: str, version):
        from assetripper_assets.collections.processed_asset_collection import ProcessedAssetCollection

        processed_collection = ProcessedAssetCollection(self)
        processed_collection.name = name
        processed_collection.set_layout(version)
        return processed_collection


def _generate_random_name() -> str:
    return f"ProcessedBundle_{UnityGuid.new_guid()}"

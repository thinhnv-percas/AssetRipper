"""Port of Source/AssetRipper.Assets/Bundles/SerializedBundle.cs

A Bundle created from serialized assets.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .bundle import Bundle


class SerializedBundle(Bundle):
    def __init__(self):
        super().__init__()
        self._name = ""

    @property
    def name(self) -> str:
        return self._name

    @staticmethod
    def from_file_container(container, factory, default_version: UnityVersion | None = None) -> "SerializedBundle":
        """
        Deferred: requires AssetRipper.IO.Files.FileContainer/CompressedFile, which
        aren't ported yet (see the BundleFiles/CompressedFiles deferral notes).
        """
        raise NotImplementedError("SerializedBundle.from_file_container requires FileContainer, which isn't ported yet.")

    def _is_compatible_bundle(self, bundle: Bundle) -> bool:
        return isinstance(bundle, SerializedBundle)

    def _is_compatible_collection(self, collection) -> bool:
        from assetripper_assets.collections.serialized_asset_collection import SerializedAssetCollection

        return isinstance(collection, SerializedAssetCollection)

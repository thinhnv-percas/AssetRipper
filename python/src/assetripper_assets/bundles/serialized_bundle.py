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
        bundle = SerializedBundle()
        bundle._name = container.name_fixed
        for resource_file in container.resource_files:
            bundle.add_resource(resource_file)
        for serialized_file in container.serialized_files:
            bundle.add_collection_from_serialized_file(serialized_file, factory, default_version)
        for child_container in container.file_lists:
            child_bundle = SerializedBundle.from_file_container(child_container, factory, default_version)
            bundle.add_bundle(child_bundle)
        for failed_file in container.failed_files:
            bundle.add_failed(failed_file)
        return bundle

    def _is_compatible_bundle(self, bundle: Bundle) -> bool:
        return isinstance(bundle, SerializedBundle)

    def _is_compatible_collection(self, collection) -> bool:
        from assetripper_assets.collections.serialized_asset_collection import SerializedAssetCollection

        return isinstance(collection, SerializedAssetCollection)

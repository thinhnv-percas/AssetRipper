"""Port of Source/AssetRipper.Assets/Collections/SerializedAssetCollection.cs

A collection of assets read from a SerializedFile.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from ..metadata.asset_info import AssetInfo
from .asset_collection import AssetCollection


class SerializedAssetCollection(AssetCollection):
    def __init__(self, bundle):
        super().__init__(bundle)
        self._dependency_identifiers = None

    def initialize_dependency_list(self, dependency_provider=None) -> None:
        if len(self.dependencies) > 1:
            raise Exception("Dependency list has already been initialized.")
        if self._dependency_identifiers is not None:
            for i, identifier in enumerate(self._dependency_identifiers):
                dependency = self.bundle.resolve_collection(identifier)
                if dependency is None and dependency_provider is not None:
                    dependency_provider.report_missing_dependency(identifier)
                self._set_dependency(i + 1, dependency)
            self._dependency_identifiers = None

    @staticmethod
    def from_serialized_file(bundle, file, factory, default_version: UnityVersion | None = None) -> "SerializedAssetCollection":
        """Creates a SerializedAssetCollection from a SerializedFile. The new collection
        is automatically added to `bundle`."""
        default_version = default_version if default_version is not None else UnityVersion()
        version = default_version if file.version.equals(0, 0, 0) else file.version
        collection = SerializedAssetCollection(bundle)
        collection.name = file.name_fixed
        collection.version = version
        collection.original_version = version
        collection.platform = file.platform
        collection.flags = file.flags
        collection.endian_type = file.endian_type

        file_dependencies = list(file.dependencies)
        if file_dependencies:
            collection._dependency_identifiers = file_dependencies

        _read_data(collection, file, factory)
        return collection


def _read_data(collection: SerializedAssetCollection, file, factory) -> None:
    for object_info in file.objects:
        class_id = 114 if object_info.type_id < 0 else object_info.type_id
        asset_info = AssetInfo(collection, object_info.file_id, class_id)
        asset = factory.read_asset(asset_info, object_info.object_data, object_info.type)
        if asset is not None:
            collection.add_asset(asset)

"""
Port of Source/AssetRipper.Assets/Bundles/GameBundle.cs

A Bundle encompassing an entire game.

GameBundle.FromPaths (Source/.../GameBundle.FromPaths.cs) is deferred: it needs
SchemeReader, CompressedFile, and FileContainer, none of which are ported yet.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .bundle import Bundle


class GameBundle(Bundle):
    def __init__(self):
        super().__init__()
        self.resource_provider = None

    @property
    def name(self) -> str:
        return "GameBundle"

    def _is_compatible_bundle(self, bundle: Bundle) -> bool:
        return not isinstance(bundle, GameBundle)

    def _resolve_external_resource(self, original_name: str):
        if self.resource_provider is not None:
            resource_file = self.resource_provider.find_resource(original_name)
            if resource_file is not None:
                self.add_resource(resource_file)
            return resource_file
        return super()._resolve_external_resource(original_name)

    def initialize_all_dependency_lists(self, dependency_provider=None) -> None:
        super().initialize_all_dependency_lists(dependency_provider)

    def has_any_asset_collections(self) -> bool:
        return any(True for _ in self.fetch_asset_collections())

    def add_new_processed_collection(self, name: str, version: UnityVersion):
        from assetripper_assets.collections.processed_asset_collection import ProcessedAssetCollection

        processed_collection = ProcessedAssetCollection(self)
        processed_collection.name = name
        processed_collection.set_layout(version)
        return processed_collection

    def add_new_processed_bundle(self, name: str | None = None):
        from .processed_bundle import ProcessedBundle

        processed_bundle = ProcessedBundle(name)
        self.add_bundle(processed_bundle)
        return processed_bundle

    def get_max_unity_version(self) -> UnityVersion:
        versions = [c.version for c in self.fetch_asset_collections()]
        versions.append(UnityVersion.MIN_VERSION)
        return max(versions)

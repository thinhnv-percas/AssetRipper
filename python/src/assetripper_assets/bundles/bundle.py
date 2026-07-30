"""
Port of Source/AssetRipper.Assets/Bundles/Bundle.cs

A container for AssetCollections, ResourceFiles, and other Bundles.
"""
from __future__ import annotations

from assetripper_io_files.special_file_names import (
    BUILTIN_EXTRA_NAME_1,
    BUILTIN_EXTRA_NAME_2,
    DEFAULT_RESOURCE_NAME_1,
    DEFAULT_RESOURCE_NAME_2,
    fix_file_identifier,
)


class Bundle:
    def __init__(self):
        self.parent: "Bundle | None" = None
        self._resources: list = []
        self._collections: list = []
        self._bundles: list["Bundle"] = []
        self._failed_files: list = []

    @property
    def resources(self) -> list:
        return self._resources

    @property
    def collections(self) -> list:
        return self._collections

    @property
    def bundles(self) -> list["Bundle"]:
        return self._bundles

    @property
    def failed_files(self) -> list:
        return self._failed_files

    @property
    def any_failed(self) -> bool:
        return len(self._failed_files) > 0 or any(b.any_failed for b in self._bundles)

    @property
    def name(self) -> str:
        raise NotImplementedError

    @property
    def scenes(self):
        seen = set()
        for collection in self.fetch_asset_collections():
            scene = collection.scene
            if scene is not None and id(scene) not in seen:
                seen.add(id(scene))
                yield scene

    def initialize_all_dependency_lists(self, dependency_provider=None) -> None:
        """Initializes the dependency list for each SerializedAssetCollection in this
        Bundle and its children Bundles."""
        from assetripper_assets.collections.serialized_asset_collection import SerializedAssetCollection

        for collection in self.collections:
            if isinstance(collection, SerializedAssetCollection):
                collection.initialize_dependency_list(dependency_provider)
        for bundle in self.bundles:
            bundle.initialize_all_dependency_lists(dependency_provider)

    def resolve_collection(self, name_or_identifier):
        """Resolves an AssetCollection with the specified name (or FileIdentifier) in
        this Bundle and its ascendants."""
        name = name_or_identifier.get_file_path() if hasattr(name_or_identifier, "get_file_path") else name_or_identifier

        result = self._resolve_internal(name)
        if result is not None:
            return result

        fixed_name = fix_file_identifier(name)
        result = self._resolve_internal(fixed_name)
        if result is not None:
            return result

        alternates = {
            DEFAULT_RESOURCE_NAME_1: DEFAULT_RESOURCE_NAME_2,
            DEFAULT_RESOURCE_NAME_2: DEFAULT_RESOURCE_NAME_1,
            BUILTIN_EXTRA_NAME_1: BUILTIN_EXTRA_NAME_2,
            BUILTIN_EXTRA_NAME_2: BUILTIN_EXTRA_NAME_1,
        }
        alternate = alternates.get(fixed_name)
        return self._resolve_internal(alternate) if alternate is not None else None

    def _resolve_internal(self, name: str):
        bundle_to_exclude = None
        current_bundle = self
        while current_bundle is not None:
            result = _try_resolve_from_collections(current_bundle, name)
            if result is None:
                result = _try_resolve_from_child_bundles(current_bundle, name, bundle_to_exclude)
            if result is not None:
                return result
            bundle_to_exclude = current_bundle
            current_bundle = current_bundle.parent
        return None

    def resolve_resource(self, name: str | None):
        """Resolves a ResourceFile with the specified name in this Bundle and its ascendants."""
        if not name:
            return None

        original_name = name
        fixed_name = fix_file_identifier(name)

        bundle_to_exclude = None
        current_bundle = self
        while current_bundle is not None:
            result = _try_resolve_from_resources(current_bundle, fixed_name)
            if result is None:
                result = _try_resolve_from_child_bundles_resource(current_bundle, original_name, fixed_name, bundle_to_exclude)
            if result is None:
                result = current_bundle._resolve_external_resource(original_name)
            if result is not None:
                return result
            bundle_to_exclude = current_bundle
            current_bundle = current_bundle.parent
        return None

    def _resolve_external_resource(self, original_name: str):
        return None

    def add_resource(self, resource) -> None:
        self._resources.append(resource)

    def add_collection(self, collection) -> None:
        if collection.bundle is not self:
            raise ValueError("Collection's bundle property did not match this.")
        elif self._is_compatible_collection(collection):
            self._collections.append(collection)
        else:
            raise ValueError("The collection is not compatible with this Bundle.")

    def add_bundle(self, bundle: "Bundle") -> None:
        if bundle.parent is None:
            if self._is_compatible_bundle(bundle):
                self._bundles.append(bundle)
                bundle.parent = self
            else:
                raise ValueError("Child Bundle is not compatible with this parent Bundle.")
        elif bundle.parent is self:
            pass
        else:
            raise ValueError("bundle already has a parent.")

    def add_failed(self, file) -> None:
        self._failed_files.append(file)

    def _is_compatible_collection(self, collection) -> bool:
        return True

    def _is_compatible_bundle(self, bundle: "Bundle") -> bool:
        from .game_bundle import GameBundle

        return not isinstance(bundle, GameBundle)

    def get_root(self) -> "Bundle":
        root = self
        while root.parent is not None:
            root = root.parent
        return root

    def fetch_assets_in_hierarchy(self):
        return self.get_root().fetch_assets()

    def fetch_assets(self):
        for collection in self._collections:
            yield from collection
        for bundle in self._bundles:
            yield from bundle.fetch_assets()

    def fetch_asset_collections(self):
        for collection in self._collections:
            yield collection
        for bundle in self._bundles:
            yield from bundle.fetch_asset_collections()

    def fetch_resource_files(self):
        for resource in self._resources:
            yield resource
        for bundle in self._bundles:
            yield from bundle.fetch_resource_files()

    def __str__(self) -> str:
        return self.name

    def add_collection_from_serialized_file(self, file, factory, default_version=None):
        from assetripper_assets.collections.serialized_asset_collection import SerializedAssetCollection
        from assetripper_primitives import UnityVersion

        return SerializedAssetCollection.from_serialized_file(
            self, file, factory, default_version if default_version is not None else UnityVersion()
        )

    def dispose(self) -> None:
        for resource_file in self._resources:
            resource_file.dispose()
        for bundle in self._bundles:
            bundle.dispose()


def _try_resolve_from_collections(current_bundle: Bundle, name: str):
    # Uniqueness is not guaranteed because of asset bundle variants.
    for collection in current_bundle.collections:
        if collection.name == name:
            return collection
    return None


def _try_resolve_from_child_bundles(current_bundle: Bundle, name: str, bundle_to_exclude: Bundle | None):
    for bundle in current_bundle.bundles:
        if bundle is not bundle_to_exclude:
            collection = _try_resolve_from_collections(bundle, name)
            if collection is not None:
                return collection
    return None


def _try_resolve_from_resources(current_bundle: Bundle, fixed_name: str):
    for resource in current_bundle.resources:
        if resource.name_fixed == fixed_name:
            return resource
    return None


def _try_resolve_from_child_bundles_resource(current_bundle: Bundle, original_name: str, fixed_name: str, bundle_to_exclude: Bundle | None):
    for bundle in current_bundle.bundles:
        if bundle is not bundle_to_exclude:
            resource = _try_resolve_from_resources(bundle, fixed_name)
            if resource is not None:
                return resource
    return None

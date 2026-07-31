"""Port of Source/AssetRipper.GUI.Web/Paths/PathExtensions.cs

C#'s extension methods (Bundle.GetPath(), GameBundle.TryGetBundle(), etc.)
become plain functions taking the target object as the first argument.
"""
from __future__ import annotations

from .asset_path import AssetPath
from .bundle_path import BundlePath
from .collection_path import CollectionPath
from .failed_file_path import FailedFilePath
from .resource_path import ResourcePath


def get_bundle_path(bundle) -> BundlePath:
    indices: list[int] = []
    current = bundle
    while current.parent is not None:
        indices.append(current.parent.bundles.index(current))
        current = current.parent
    indices.reverse()
    return BundlePath(tuple(indices))


def get_collection_path(collection) -> CollectionPath:
    return CollectionPath(get_bundle_path(collection.bundle), collection.bundle.collections.index(collection))


def get_asset_path(asset) -> AssetPath:
    return AssetPath(get_collection_path(asset.collection), asset.path_id)


def try_get_bundle(game_bundle, path: BundlePath):
    current = game_bundle
    for index in path.path:
        if index < 0 or index >= len(current.bundles):
            return None
        current = current.bundles[index]
    return current


def try_get_collection(game_bundle, path: CollectionPath):
    bundle = try_get_bundle(game_bundle, path.bundle_path)
    if bundle is None or path.index < 0 or path.index >= len(bundle.collections):
        return None
    return bundle.collections[path.index]


def try_get_resource(game_bundle, path: ResourcePath):
    bundle = try_get_bundle(game_bundle, path.bundle_path)
    if bundle is None or path.index < 0 or path.index >= len(bundle.resources):
        return None
    return bundle.resources[path.index]


def try_get_failed_file(game_bundle, path: FailedFilePath):
    bundle = try_get_bundle(game_bundle, path.bundle_path)
    if bundle is None or path.index < 0 or path.index >= len(bundle.failed_files):
        return None
    return bundle.failed_files[path.index]


def try_get_asset(game_bundle, path: AssetPath):
    collection = try_get_collection(game_bundle, path.collection_path)
    if collection is None:
        return None
    # Uses the raw assets dict rather than AssetCollection.get_asset, because that
    # filters out NullObject instances.
    return collection.assets.get(path.path_id)

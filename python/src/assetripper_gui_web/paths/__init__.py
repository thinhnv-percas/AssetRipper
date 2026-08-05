"""Python port of Source/AssetRipper.GUI.Web/Paths -- compact index-path
identifiers used to address bundles/collections/assets/resources/failed files
and scenes from URLs, without needing GUIDs or full names."""
from .asset_path import AssetPath
from .bundle_path import BundlePath
from .collection_path import CollectionPath
from .failed_file_path import FailedFilePath
from .path_extensions import (
    get_asset_path,
    get_bundle_path,
    get_collection_path,
    try_get_asset,
    try_get_bundle,
    try_get_collection,
    try_get_failed_file,
    try_get_resource,
)
from .resource_path import ResourcePath
from .scene_path import ScenePath

__all__ = [
    "BundlePath",
    "CollectionPath",
    "AssetPath",
    "FailedFilePath",
    "ResourcePath",
    "ScenePath",
    "get_bundle_path",
    "get_collection_path",
    "get_asset_path",
    "try_get_bundle",
    "try_get_collection",
    "try_get_resource",
    "try_get_failed_file",
    "try_get_asset",
]

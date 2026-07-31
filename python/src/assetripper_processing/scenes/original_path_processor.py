"""Port of Source/AssetRipper.Processing/Scenes/OriginalPathProcessor.cs

`IResourceManager.Container`/`IAssetBundle.Container` are read via dynamic field access
(`asset["m_Container"]`) rather than generated interfaces: both are Map fields (an array of
(string, PPtr) or (string, AssetInfo) pairs), a shape the dynamic reader already supports
generically (see structure/assembly/serializable/serializable_pair.py). `cls=NullObject` is
passed to `get_asset_by_pptr` for the same reason as ProjectYamlWalker's PPtr resolution --
every asset in this port derives from NullObject, which AssetCollection.get_asset otherwise
filters out.

Not ported: `UndoPathLowercasing`'s `INamed` check (this port's TypeTreeObject doesn't
special-case a `.name`/`Name` property the way generated classes do -- `getattr(asset,
"name", None)` stands in, matching get_best_name()'s own convention) is included, but the
Shader override-path special case IS included since it only copies already-known
original_* values (no invented field names needed).
"""
from __future__ import annotations

import posixpath

from assetripper_import.class_id_type import ClassIDType
from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_assets.null_object import NullObject

from ..configuration.bundled_assets_export_mode import BundledAssetsExportMode
from ..i_asset_processor import IAssetProcessor
from ..original_path_helper import ensure_path_not_rooted, ensure_starts_with_assets

_RESOURCES_KEYWORD = "Resources"
_DIRECTORY_SEPARATOR = "/"
_ASSETS_DIRECTORY = "Assets" + _DIRECTORY_SEPARATOR
_RESOURCE_FULL_PATH = _ASSETS_DIRECTORY + _RESOURCES_KEYWORD
_ASSET_BUNDLE_FULL_PATH = _ASSETS_DIRECTORY + "AssetBundles"
_BUNDLE_EXTENSION = ".bundle"


class OriginalPathProcessor(IAssetProcessor):
    def __init__(self, bundled_assets_export_mode: BundledAssetsExportMode = BundledAssetsExportMode.GROUP_BY_ASSET_TYPE):
        self.bundled_assets_export_mode = bundled_assets_export_mode

    def process(self, game_data) -> None:
        pending: dict = {}
        for asset in game_data.game_bundle.fetch_assets():
            if asset.class_id == ClassIDType.ResourceManager:
                _set_original_paths_for_resource_manager(asset)
            elif asset.class_id == ClassIDType.AssetBundle:
                _set_original_paths_for_asset_bundle(asset, self.bundled_assets_export_mode)
                if self.bundled_assets_export_mode == BundledAssetsExportMode.GROUP_BY_BUNDLE_NAME:
                    bundle_name = _ensure_does_not_end_with_bundle_extension(_get_asset_bundle_name(asset))
                    if not isinstance(asset.collection.bundle, GameBundle):
                        for collection in asset.collection.bundle.collections:
                            pending[collection] = (bundle_name, asset)

        for collection, (bundle_name, _bundle_asset) in pending.items():
            for asset in collection:
                if asset.original_directory is None:
                    asset.original_directory = posixpath.join(_ASSET_BUNDLE_FULL_PATH, bundle_name, asset.class_name)


def _set_original_paths_for_resource_manager(manager) -> None:
    container = manager.get("m_Container") or ()
    for pair in container:
        pptr = pair.second.value
        asset = manager.collection.get_asset_by_pptr(pptr, NullObject)
        if asset is None:
            continue

        resource_path = posixpath.join(_RESOURCE_FULL_PATH, pair.first.value)
        if asset.original_path is None:
            asset.original_path = resource_path
            _undo_path_lowercasing(asset)
            _set_override_path_if_shader(asset)
        elif len(asset.original_path) < len(resource_path):
            # for paths like "Resources/inner/resources/extra/file" Unity creates 2 resource
            # entries: "inner/resources/extra/file" and "extra/file"
            asset.original_path = resource_path
            _undo_path_lowercasing(asset)
            _set_override_path_if_shader(asset)


def _set_original_paths_for_asset_bundle(bundle_asset, bundled_assets_export_mode: BundledAssetsExportMode) -> None:
    bundle_name = _ensure_does_not_end_with_bundle_extension(_get_asset_bundle_name(bundle_asset))
    bundle_directory = bundle_name + _DIRECTORY_SEPARATOR
    directory = posixpath.join(_ASSET_BUNDLE_FULL_PATH, bundle_name)

    container = bundle_asset.get("m_Container") or ()
    for pair in container:
        asset_info = pair.second.value
        pptr = asset_info["asset"] if "asset" in asset_info else None
        if pptr is None or pptr.file_id != 0:
            # skip shared bundle assets -- they're exported in their own bundle's directory
            continue

        asset = bundle_asset.collection.get_asset_by_pptr(pptr, NullObject)
        if asset is None:
            continue

        asset.asset_bundle_name = bundle_name

        asset_path = ensure_path_not_rooted(pair.first.value)
        if not asset_path:
            continue

        if bundled_assets_export_mode == BundledAssetsExportMode.DIRECT_EXPORT:
            asset.original_path = ensure_starts_with_assets(asset_path)
        elif bundled_assets_export_mode == BundledAssetsExportMode.GROUP_BY_BUNDLE_NAME:
            if asset_path.lower().startswith(_ASSETS_DIRECTORY.lower()):
                asset_path = asset_path[len(_ASSETS_DIRECTORY):]
            if asset_path.lower().startswith(bundle_directory.lower()):
                asset_path = asset_path[len(bundle_directory):]
            asset.original_path = posixpath.join(directory, asset_path)

        _undo_path_lowercasing(asset)
        _set_override_path_if_shader(asset)


def _get_asset_bundle_name(asset_bundle) -> str:
    # Field name uncertain without generated IAssetBundle.GetAssetBundleName() to check
    # against -- tries both plausible field names rather than asserting one.
    name = asset_bundle.get("m_Name") or asset_bundle.get("m_AssetBundleName")
    return name or ""


def _ensure_does_not_end_with_bundle_extension(path: str) -> str:
    # Unity behaves oddly if a folder name ends with ".bundle" (native-plugin packaging
    # quirk on Mac/iOS) -- strip it, matching upstream.
    if path.lower().endswith(_BUNDLE_EXTENSION):
        return path[: -len(_BUNDLE_EXTENSION)]
    return path


def _undo_path_lowercasing(asset) -> None:
    """Unity often lowercases every character in a path during compilation; this restores
    proper capitalization when the names otherwise match case-insensitively."""
    asset_name = getattr(asset, "name", None)
    original_name = asset.original_name
    if (
        asset_name is not None
        and original_name is not None
        and len(asset_name) == len(original_name)
        and original_name.lower() == asset_name.lower()
    ):
        asset.original_name = asset_name


def _set_override_path_if_shader(asset) -> None:
    # Original name is prioritized below the asset name, so the override path needs setting
    # too -- otherwise a Shader would export under the wrong name.
    if asset.class_id == ClassIDType.Shader:
        if asset.override_directory is None:
            asset.override_directory = asset.original_directory
        if asset.override_name is None:
            asset.override_name = asset.original_name
        if asset.override_extension is None:
            asset.override_extension = asset.original_extension

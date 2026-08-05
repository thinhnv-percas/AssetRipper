"""No C# test project covers PathExtensions directly, so these are original tests
(not a port) exercising get_*_path/try_get_* round trips against a small
in-memory GameBundle/Bundle/AssetCollection hierarchy."""
from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_primitives import UnityVersion
from assetripper_gui_web.paths import (
    get_asset_path,
    get_bundle_path,
    get_collection_path,
    try_get_asset,
    try_get_bundle,
    try_get_collection,
    try_get_failed_file,
    try_get_resource,
)


def _make_hierarchy():
    version = UnityVersion()
    root = GameBundle()
    child = root.add_new_processed_bundle("child")
    collection = root.add_new_processed_collection("main", version)
    child_collection = child.add_new_processed_collection("child-main", version)
    return root, child, collection, child_collection


def test_get_bundle_path_round_trips_through_try_get_bundle():
    root, child, _, _ = _make_hierarchy()

    root_path = get_bundle_path(root)
    assert root_path.is_root
    assert try_get_bundle(root, root_path) is root

    child_path = get_bundle_path(child)
    assert child_path.path == (0,)
    assert try_get_bundle(root, child_path) is child


def test_get_collection_path_round_trips_through_try_get_collection():
    root, child, collection, child_collection = _make_hierarchy()

    path = get_collection_path(collection)
    assert try_get_collection(root, path) is collection

    child_path = get_collection_path(child_collection)
    assert try_get_collection(root, child_path) is child_collection


def test_try_get_bundle_out_of_range_returns_none():
    root, _, _, _ = _make_hierarchy()
    from assetripper_gui_web.paths import BundlePath

    assert try_get_bundle(root, BundlePath((99,))) is None


def test_try_get_resource_and_failed_file_out_of_range_return_none():
    root, _, _, _ = _make_hierarchy()
    from assetripper_gui_web.paths import BundlePath, FailedFilePath, ResourcePath

    assert try_get_resource(root, ResourcePath(BundlePath(), 0)) is None
    assert try_get_failed_file(root, FailedFilePath(BundlePath(), 0)) is None


def test_get_asset_path_round_trips_through_try_get_asset():
    from assetripper_assets.unity_object_base import UnityObjectBase

    root, _, collection, _ = _make_hierarchy()
    asset = collection.create_asset(-1, lambda asset_info: UnityObjectBase(asset_info))

    path = get_asset_path(asset)
    assert try_get_asset(root, path) is asset

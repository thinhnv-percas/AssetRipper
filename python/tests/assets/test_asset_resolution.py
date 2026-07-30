"""Port of Source/AssetRipper.Assets.Tests/AssetResolutionTests.cs"""
from assetripper_assets.bundles import GameBundle
from assetripper_assets.null_object import NullObject
from assetripper_assets.i_unity_object_base import IUnityObjectBase
from assetripper_primitives import UnityVersion


class SealedNullObject(NullObject):
    pass


def _create():
    return GameBundle().add_new_processed_collection("Create", UnityVersion())


def test_resolving_null_objects():
    collection = _create()
    asset = collection.create_asset(-1, lambda asset_info: SealedNullObject(asset_info))

    # NullObject is not a real asset, so we should not be able to get it under normal conditions.
    assert collection.get_asset(asset.path_id) is None
    assert collection.get_asset_in_dependency(0, asset.path_id) is None
    assert collection.get_asset(asset.path_id, IUnityObjectBase) is None
    assert collection.get_asset_in_dependency(0, asset.path_id, IUnityObjectBase) is None

    # We are explicitly looking for a NullObject, so we should get it.
    assert collection.get_asset(asset.path_id, NullObject) is asset
    assert collection.get_asset_in_dependency(0, asset.path_id, NullObject) is asset
    assert collection.get_asset(asset.path_id, SealedNullObject) is asset
    assert collection.get_asset_in_dependency(0, asset.path_id, SealedNullObject) is asset

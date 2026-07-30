"""Port of Source/AssetRipper.Assets.Tests/GameBundleTests.cs"""
from assetripper_assets.bundles import GameBundle
from assetripper_primitives import UnityVersion


def test_has_any_asset_collections_returns_false():
    game_bundle = GameBundle()
    assert not game_bundle.has_any_asset_collections()


def test_add_new_processed_collection_adds_new_processed_collection():
    game_bundle = GameBundle()
    name = "testName"
    version = UnityVersion.parse("10.3.1f1")
    processed_collection = game_bundle.add_new_processed_collection(name, version)
    assert processed_collection.name == name
    assert processed_collection.version == version
    assert processed_collection in list(game_bundle.fetch_asset_collections())


def test_get_max_unity_version_returns_max_unity_version():
    game_bundle = GameBundle()
    game_bundle.add_new_processed_collection("test", UnityVersion.parse("1.0.0f1"))
    game_bundle.add_new_processed_collection("test2", UnityVersion.parse("2.0.10f3"))
    game_bundle.add_new_processed_collection("test3", UnityVersion.parse("3.0.0f0"))
    assert game_bundle.get_max_unity_version() == UnityVersion.parse("3.0.0f0")

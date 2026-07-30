"""Port of Source/AssetRipper.Assets.Tests/SceneDefinitionTests.cs"""
import pytest

from assetripper_assets.bundles import GameBundle
from assetripper_assets.collections import AssetCollection, SceneDefinition
from assetripper_primitives import UnityGuid, UnityVersion


def _create_collection() -> AssetCollection:
    game_bundle = GameBundle()
    return game_bundle.add_new_processed_collection(str(UnityGuid.new_guid()), UnityVersion.MIN_VERSION)


def test_from_name_creates_scene_definition_with_name():
    scene_definition = SceneDefinition.from_name("testScene")
    assert scene_definition.name == "testScene"


def test_from_name_creates_scene_definition_with_guid():
    scene_definition = SceneDefinition.from_name("testScene")
    assert scene_definition.guid != UnityGuid.ZERO


def test_from_path_creates_scene_definition_with_path():
    scene_definition = SceneDefinition.from_path("Assets/Scenes/testScene")
    assert scene_definition.path == "Assets/Scenes/testScene"


def test_from_path_creates_scene_definition_with_guid():
    scene_definition = SceneDefinition.from_path("Assets/Scenes/testScene")
    assert scene_definition.guid != UnityGuid.ZERO


def test_add_collection_adds_collection_to_scene_definition():
    scene_definition = SceneDefinition.from_name("testScene")
    mock_asset_collection = _create_collection()
    scene_definition.add_collection(mock_asset_collection)
    assert len(scene_definition.collections) == 1
    assert scene_definition.collections[0] is mock_asset_collection


def test_add_collection_throws_when_asset_collection_is_part_of_different_scene():
    scene_definition1 = SceneDefinition.from_name("testScene1")
    mock_asset_collection1 = _create_collection()
    scene_definition1.add_collection(mock_asset_collection1)

    scene_definition2 = SceneDefinition.from_name("testScene2")
    mock_asset_collection2 = _create_collection()
    scene_definition2.add_collection(mock_asset_collection2)

    with pytest.raises(Exception):
        scene_definition1.add_collection(mock_asset_collection2)


def test_remove_collection_removes_collection_from_scene_definition():
    scene_definition = SceneDefinition.from_name("testScene")
    mock_asset_collection = _create_collection()
    scene_definition.add_collection(mock_asset_collection)

    scene_definition.remove_collection(mock_asset_collection)

    assert list(scene_definition.collections) == []


def test_remove_collection_throws_when_collection_not_part_of_scene_definition():
    scene_definition = SceneDefinition.from_name("testScene")
    mock_asset_collection1 = _create_collection()
    mock_asset_collection2 = _create_collection()

    scene_definition.add_collection(mock_asset_collection1)

    with pytest.raises(ValueError):
        scene_definition.remove_collection(mock_asset_collection2)


def test_remove_collection_deletes_asset_collection_scene_reference():
    scene_definition = SceneDefinition.from_name("testScene")
    mock_asset_collection = _create_collection()
    scene_definition.add_collection(mock_asset_collection)

    scene_definition.remove_collection(mock_asset_collection)

    assert mock_asset_collection.scene is None

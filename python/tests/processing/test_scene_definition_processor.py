"""End-to-end test for Source/AssetRipper.Processing/Scenes/SceneDefinitionProcessor.cs
(scoped port): a BuildSettings asset in one collection recovers the scene path for an
OcclusionCullingSettings asset in another, real-dynamic-reader-read, collection.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion
from assetripper_processing.game_data import GameData
from assetripper_processing.scenes.scene_definition_processor import SceneDefinitionProcessor

from import_._tree_builder import node, tree, unity_string

_V2019 = UnityVersion(2019, 4, 0)

# BuildSettings (class 141): vector<string> m_Scenes.
_BUILD_SETTINGS_TREE = tree(
    node("BuildSettings", "Base", 0),
    node("vector", "m_Scenes", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    node("string", "data", 3),
    node("Array", "Array", 4),
    node("int", "size", 5),
    node("char", "data", 5),
)

# OcclusionCullingSettings (class 29): no fields needed for this scoped port.
_OCCLUSION_CULLING_SETTINGS_TREE = tree(node("OcclusionCullingSettings", "Base", 0))


def _add_collection(game_bundle, name: str, class_id: int, tree_nodes, payload: bytes):
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = class_id
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = tree_nodes

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = payload

    builder.types.append(type_)
    builder.objects.append(obj)
    file = builder.build()
    file.name = name
    return game_bundle.add_collection_from_serialized_file(file, GameAssetFactory())


def test_scene_definition_processor_recovers_scene_path_from_build_settings():
    game_bundle = GameBundle()
    _add_collection(
        game_bundle,
        "globalgamemanagers",
        141,
        _BUILD_SETTINGS_TREE,
        struct.pack("<i", 1) + unity_string("Assets/Scenes/Level0.unity"),
    )
    scene_collection = _add_collection(game_bundle, "level0", 29, _OCCLUSION_CULLING_SETTINGS_TREE, b"")

    game_data = GameData(game_bundle, _V2019, None, None)
    SceneDefinitionProcessor().process(game_data)

    assert scene_collection.is_scene
    assert scene_collection.scene.path == "Assets/Scenes/Level0"
    assert scene_collection.scene.name == "Level0"


def test_scene_definition_processor_falls_back_to_collection_name():
    game_bundle = GameBundle()
    scene_collection = _add_collection(game_bundle, "level0", 29, _OCCLUSION_CULLING_SETTINGS_TREE, b"")

    game_data = GameData(game_bundle, _V2019, None, None)
    SceneDefinitionProcessor().process(game_data)

    assert scene_collection.is_scene
    assert scene_collection.scene.name == "level0"


def test_non_scene_collections_are_left_alone():
    game_bundle = GameBundle()
    build_settings_collection = _add_collection(
        game_bundle,
        "globalgamemanagers",
        141,
        _BUILD_SETTINGS_TREE,
        struct.pack("<i", 0),
    )

    game_data = GameData(game_bundle, _V2019, None, None)
    SceneDefinitionProcessor().process(game_data)

    assert not build_settings_collection.is_scene

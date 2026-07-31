"""End-to-end test for the scoped port of
Source/AssetRipper.Processing/Scenes/OriginalPathProcessor.cs: a ResourceManager's
m_Container recovers a "Resources/..." original_path for the asset it points at.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_assets.null_object import NullObject
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion
from assetripper_processing.game_data import GameData
from assetripper_processing.scenes.original_path_processor import OriginalPathProcessor

from import_._tree_builder import node, pptr_nodes, string_nodes, tree, unity_string

_V2019 = UnityVersion(2019, 4, 0)

# ResourceManager (class 147): map<string, PPtr<Object>> m_Container.
_RESOURCE_MANAGER_TREE = tree(
    node("ResourceManager", "Base", 0),
    node("map", "m_Container", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    node("pair", "data", 3),
    *string_nodes("first", 4),
    *pptr_nodes("second", "Object", 4),
)

# TextAsset (class 49): m_Name (string), m_Script (string) -- the target the resource
# manager's container entry points at.
_TEXT_ASSET_TREE = tree(
    node("TextAsset", "Base", 0),
    *string_nodes("m_Name", 1),
    *string_nodes("m_Script", 1),
)


def _build_game_bundle():
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )

    resource_manager_type = SerializedType()
    resource_manager_type.type_id = 147
    resource_manager_type.is_stripped_type = False
    resource_manager_type.script_type_index = -1
    resource_manager_type.old_type = _RESOURCE_MANAGER_TREE

    resource_manager_obj = ObjectInfo(resource_manager_type)
    resource_manager_obj.file_id = 1
    resource_manager_obj.serialized_type_index = 0
    # m_Container: {"Materials/Wood": {fileID: 0, pathID: 2}}
    resource_manager_obj.object_data = struct.pack("<i", 1) + unity_string("Materials/Wood") + struct.pack("<iq", 0, 2)

    text_asset_type = SerializedType()
    text_asset_type.type_id = 49
    text_asset_type.is_stripped_type = False
    text_asset_type.script_type_index = -1
    text_asset_type.old_type = _TEXT_ASSET_TREE

    text_asset_obj = ObjectInfo(text_asset_type)
    text_asset_obj.file_id = 2
    text_asset_obj.serialized_type_index = 1
    text_asset_obj.object_data = unity_string("Wood") + unity_string("wood material data")

    builder.types.append(resource_manager_type)
    builder.types.append(text_asset_type)
    builder.objects.append(resource_manager_obj)
    builder.objects.append(text_asset_obj)
    serialized_file = builder.build()

    game_bundle = GameBundle()
    collection = game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return game_bundle, collection


def test_original_path_processor_recovers_resources_path():
    game_bundle, collection = _build_game_bundle()
    text_asset = collection.get_asset(2, NullObject)
    assert text_asset.original_path is None

    game_data = GameData(game_bundle, _V2019, None, None)
    OriginalPathProcessor().process(game_data)

    assert text_asset.original_path == "Assets/Resources/Materials/Wood"

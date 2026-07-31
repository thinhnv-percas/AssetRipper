"""Test for the scoped port of
Source/AssetRipper.Processing/Editor/EditorFormatProcessor.cs (PlayerSettings patching
only)."""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_assets.null_object import NullObject
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion
from assetripper_processing.editor.editor_format_processor import EditorFormatProcessor
from assetripper_processing.game_data import GameData

from import_._tree_builder import node, tree

# PlayerSettings (class 129): int webGLLinkerTarget, bool allowUnsafeCode.
_PLAYER_SETTINGS_TREE = tree(
    node("PlayerSettings", "Base", 0),
    node("int", "webGLLinkerTarget", 1),
    node("bool", "allowUnsafeCode", 1),
)


def _build_player_settings_collection(*, release: bool):
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER if release else BuildTarget.NO_TARGET,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = 129
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _PLAYER_SETTINGS_TREE

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = struct.pack("<i", 0) + struct.pack("<?", False)

    builder.types.append(type_)
    builder.objects.append(obj)
    file = builder.build()
    file.name = "ProjectSettings"

    game_bundle = GameBundle()
    collection = game_bundle.add_collection_from_serialized_file(file, GameAssetFactory())
    return game_bundle, collection


def test_player_settings_fields_get_patched_in_release_collections():
    game_bundle, collection = _build_player_settings_collection(release=True)
    player_settings = collection.get_asset(1, NullObject)
    assert player_settings.is_player_settings

    game_data = GameData(game_bundle, UnityVersion(2019, 4, 0), None, None)
    EditorFormatProcessor().process(game_data)

    assert player_settings["webGLLinkerTarget"] == 1
    assert player_settings["allowUnsafeCode"] is True


def test_player_settings_fields_are_not_touched_in_non_release_collections():
    game_bundle, collection = _build_player_settings_collection(release=False)
    player_settings = collection.get_asset(1, NullObject)

    game_data = GameData(game_bundle, UnityVersion(2019, 4, 0), None, None)
    EditorFormatProcessor().process(game_data)

    assert player_settings["webGLLinkerTarget"] == 0
    assert player_settings["allowUnsafeCode"] is False

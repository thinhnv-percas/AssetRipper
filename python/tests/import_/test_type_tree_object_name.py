"""`TypeTreeObject.name` (discovered while naming Phase 12's synthesized `.prefab` files):
stands in for upstream's `INamed` marker interface so `get_best_name()`/`__str__`'s
`getattr(self, "name", None)` fallback actually picks up `m_Name` instead of silently
falling straight through to the class name for every dynamically-read asset.
"""
from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from ._tree_builder import node, string_nodes, tree, unity_string

_V2019 = UnityVersion(2019, 4, 0)
_TEXT_ASSET_TREE = tree(node("TextAsset", "Base", 0), *string_nodes("m_Name", 1), *string_nodes("m_Script", 1))
_RENDER_SETTINGS_TREE = tree(node("RenderSettings", "Base", 0))


def _build_asset(class_id: int, tree_nodes, payload: bytes):
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
    serialized_file = builder.build()
    serialized_file.name = "x"

    game_bundle = GameBundle()
    collection = game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return list(collection.assets.values())[0]


def test_name_property_returns_m_name_field():
    # str(asset)/repr(asset) intentionally still return class_name -- TypeTreeObject
    # overrides __str__ itself (see that module) independently of this .name property.
    asset = _build_asset(49, _TEXT_ASSET_TREE, unity_string("MyText") + unity_string("hello"))
    assert asset.name == "MyText"
    assert asset.get_best_name() == "MyText"


def test_name_property_is_none_without_an_m_name_field():
    asset = _build_asset(104, _RENDER_SETTINGS_TREE, b"")
    assert asset.name is None
    assert asset.get_best_name() == "RenderSettings"  # falls back to class_name

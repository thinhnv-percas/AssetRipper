"""Phase 13c: `SpriteProcessor` wiring test -- the dynamic-field-access side (the pure
math is verified independently in test_sprite_coordinates.py). Builds a synthetic Sprite
(and, for the atlas-reference test, a synthetic SpriteAtlas) via a hand-built type tree,
mirroring the pattern in tests/import_/_tree_builder.py.
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
from assetripper_processing.textures.sprite_processor import SpriteProcessor

from import_._tree_builder import node, rect_nodes, string_nodes, tree, unity_string, vector2_nodes, vector4_nodes

_V2019 = UnityVersion(2019, 4, 0)
_SPRITE_CLASS_ID = 213
_SPRITE_ATLAS_CLASS_ID = 687078895

_ATLAS_TAGS_NODES = [
    node("vector", "m_AtlasTags", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    *string_nodes("data", 3),
]

_SPRITE_TREE = tree(
    node("Sprite", "Base", 0),
    *string_nodes("m_Name", 1),
    *rect_nodes("m_Rect", 1),
    *vector2_nodes("m_Pivot", 1),
    *vector2_nodes("m_Offset", 1),
    *vector4_nodes("m_Border", 1),
    node("PPtr<SpriteAtlas>", "m_SpriteAtlas", 1),
    node("int", "m_FileID", 2),
    node("SInt64", "m_PathID", 2),
    *_ATLAS_TAGS_NODES,
    node("SpriteRenderData", "m_RD", 1),
    *rect_nodes("textureRect", 2),
    *vector2_nodes("textureRectOffset", 2),
)

_ATLAS_TREE = tree(node("SpriteAtlas", "Base", 0), *string_nodes("m_Name", 1))


def _sprite_payload(
    name: str,
    rect: "tuple[float, float, float, float]",
    pivot: "tuple[float, float]",
    offset: "tuple[float, float]",
    border: "tuple[float, float, float, float]",
    atlas_file_id: int,
    atlas_path_id: int,
    texture_rect: "tuple[float, float, float, float]",
    texture_rect_offset: "tuple[float, float]",
) -> bytes:
    return (
        unity_string(name)
        + struct.pack("<4f", *rect)
        + struct.pack("<2f", *pivot)
        + struct.pack("<2f", *offset)
        + struct.pack("<4f", *border)
        + struct.pack("<iq", atlas_file_id, atlas_path_id)
        + struct.pack("<i", 0)  # m_AtlasTags: empty vector<string>
        + struct.pack("<4f", *texture_rect)
        + struct.pack("<2f", *texture_rect_offset)
    )


def _build_bundle_with_sprite(sprite_payload: bytes, include_atlas: bool = False) -> GameBundle:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )

    sprite_type = SerializedType()
    sprite_type.type_id = _SPRITE_CLASS_ID
    sprite_type.is_stripped_type = False
    sprite_type.script_type_index = -1
    sprite_type.old_type = _SPRITE_TREE

    sprite_obj = ObjectInfo(sprite_type)
    sprite_obj.file_id = 1
    sprite_obj.serialized_type_index = 0
    sprite_obj.object_data = sprite_payload

    builder.types.append(sprite_type)
    builder.objects.append(sprite_obj)

    if include_atlas:
        atlas_type = SerializedType()
        atlas_type.type_id = _SPRITE_ATLAS_CLASS_ID
        atlas_type.is_stripped_type = False
        atlas_type.script_type_index = -1
        atlas_type.old_type = _ATLAS_TREE

        atlas_obj = ObjectInfo(atlas_type)
        atlas_obj.file_id = 2
        atlas_obj.serialized_type_index = 1
        atlas_obj.object_data = unity_string("MyAtlas")

        builder.types.append(atlas_type)
        builder.objects.append(atlas_obj)

    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return game_bundle


def _find_asset(game_bundle, class_id: int):
    for collection in game_bundle.fetch_asset_collections():
        for asset in collection:
            if asset.class_id == class_id:
                return asset
    raise AssertionError(f"no asset with class_id {class_id} found")


def test_sprite_with_no_crop_and_no_atlas_is_left_alone():
    payload = _sprite_payload(
        name="MySprite",
        rect=(0.0, 0.0, 100.0, 50.0),
        pivot=(0.5, 0.5),
        offset=(0.0, 0.0),
        border=(0.0, 0.0, 0.0, 0.0),
        atlas_file_id=0,
        atlas_path_id=0,  # null PPtr -- no atlas reference
        texture_rect=(0.0, 0.0, 100.0, 50.0),  # matches m_Rect exactly -- no crop
        texture_rect_offset=(0.0, 0.0),
    )
    game_bundle = _build_bundle_with_sprite(payload)
    sprite = _find_asset(game_bundle, _SPRITE_CLASS_ID)

    SpriteProcessor().process(GameData(game_bundle, _V2019, None, None))

    assert sprite["m_Rect"]["x"] == 0.0
    assert sprite["m_Rect"]["width"] == 100.0
    assert sprite["m_Pivot"]["x"] == 0.5
    assert sprite["m_Pivot"]["y"] == 0.5
    assert sprite["m_Border"]["x"] == 0.0
    # Offset recomputed from pivot/rect: (0.5-0.5)*100 = 0, (0.5-0.5)*50 = 0.
    assert sprite["m_Offset"]["x"] == 0.0
    assert sprite["m_Offset"]["y"] == 0.0


def test_sprite_referencing_a_resolvable_atlas_gets_its_reference_cleared():
    payload = _sprite_payload(
        name="PackedSprite",
        rect=(0.0, 0.0, 100.0, 50.0),
        pivot=(0.5, 0.5),
        offset=(0.0, 0.0),
        border=(0.0, 0.0, 0.0, 0.0),
        atlas_file_id=0,
        atlas_path_id=2,  # points at the SpriteAtlas asset (file_id=2) in the same collection
        texture_rect=(0.0, 0.0, 100.0, 50.0),
        texture_rect_offset=(0.0, 0.0),
    )
    game_bundle = _build_bundle_with_sprite(payload, include_atlas=True)
    sprite = _find_asset(game_bundle, _SPRITE_CLASS_ID)
    assert sprite["m_SpriteAtlas"].path_id == 2  # sanity check before processing

    SpriteProcessor().process(GameData(game_bundle, _V2019, None, None))

    assert sprite["m_SpriteAtlas"].path_id == 0
    assert sprite["m_SpriteAtlas"].file_id == 0


def test_sprite_without_pivot_or_border_fields_does_not_crash():
    """Older Unity versions may not serialize m_Pivot/m_Border at all -- verified by
    building a tree that omits them entirely."""
    from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory as _Factory

    minimal_tree = tree(
        node("Sprite", "Base", 0),
        *string_nodes("m_Name", 1),
        *rect_nodes("m_Rect", 1),
        *vector2_nodes("m_Offset", 1),
        node("SpriteRenderData", "m_RD", 1),
        *rect_nodes("textureRect", 2),
        *vector2_nodes("textureRectOffset", 2),
    )
    payload = (
        unity_string("NoPivotNoBorder")
        + struct.pack("<4f", 0.0, 0.0, 100.0, 50.0)
        + struct.pack("<2f", 0.0, 0.0)
        + struct.pack("<4f", 0.0, 0.0, 100.0, 50.0)
        + struct.pack("<2f", 0.0, 0.0)
    )

    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = _SPRITE_CLASS_ID
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = minimal_tree
    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = payload
    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, _Factory())
    sprite = _find_asset(game_bundle, _SPRITE_CLASS_ID)

    SpriteProcessor().process(GameData(game_bundle, _V2019, None, None))

    # No crop (textureRect == m_Rect), so the derived pivot round-trips to the offset
    # unchanged: center=(50,25), pivotOffset=(50,25), pivot=(0.5,0.5), Offset back to (0,0).
    assert sprite["m_Offset"]["x"] == 0.0
    assert sprite["m_Offset"]["y"] == 0.0


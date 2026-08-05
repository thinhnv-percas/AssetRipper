"""End-to-end test for Source/AssetRipper.Processing/Prefabs/PrefabProcessor.cs (scoped
port, see prefab_processor.py's module docstring): builds a 2-GameObject scene hierarchy
(root + child, both real dynamic-reader-read TypeTreeObjects with a real embedded type
tree) plus a loose GameObject with no scene, and checks the resulting
SceneHierarchyObject/PrefabHierarchyObject grouping.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_import.class_id_type import ClassIDType
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion
from assetripper_processing.game_data import GameData
from assetripper_processing.prefabs.prefab_processor import PrefabProcessor
from assetripper_processing.scenes.scene_definition_processor import SceneDefinitionProcessor

from import_._tree_builder import node, tree, unity_string

_V2019 = UnityVersion(2019, 4, 0)

_RENDER_SETTINGS_TREE = tree(node("RenderSettings", "Base", 0))

_GAME_OBJECT_TREE = tree(
    node("GameObject", "Base", 0),
    node("vector", "m_Component", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    node("ComponentPair", "data", 3),
    node("PPtr<Component>", "component", 4),
    node("int", "m_FileID", 5),
    node("SInt64", "m_PathID", 5),
    node("string", "m_Name", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    node("char", "data", 3),
)

_TRANSFORM_TREE = tree(
    node("Transform", "Base", 0),
    node("PPtr<GameObject>", "m_GameObject", 1),
    node("int", "m_FileID", 2),
    node("SInt64", "m_PathID", 2),
    node("PPtr<Transform>", "m_Father", 1),
    node("int", "m_FileID", 2),
    node("SInt64", "m_PathID", 2),
    node("vector", "m_Children", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    node("PPtr<Transform>", "data", 3),
    node("int", "m_FileID", 4),
    node("SInt64", "m_PathID", 4),
)


def _game_object_payload(name: str, transform_path_id: int) -> bytes:
    return struct.pack("<i", 1) + struct.pack("<iq", 0, transform_path_id) + unity_string(name)


def _transform_payload(game_object_path_id: int, father_path_id: int, children_path_ids) -> bytes:
    payload = struct.pack("<iq", 0, game_object_path_id) + struct.pack("<iq", 0, father_path_id)
    payload += struct.pack("<i", len(children_path_ids))
    for child_path_id in children_path_ids:
        payload += struct.pack("<iq", 0, child_path_id)
    return payload


def _add_object(builder, class_id: int, tree_nodes, path_id: int, payload: bytes) -> None:
    type_ = SerializedType()
    type_.type_id = class_id
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = tree_nodes

    obj = ObjectInfo(type_)
    obj.file_id = path_id
    obj.serialized_type_index = len(builder.types)
    obj.object_data = payload

    builder.types.append(type_)
    builder.objects.append(obj)


def _build_scene_collection(game_bundle):
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    _add_object(builder, 104, _RENDER_SETTINGS_TREE, 1, b"")  # RenderSettings, marks this a scene
    _add_object(builder, 1, _GAME_OBJECT_TREE, 2, _game_object_payload("Root", 3))
    _add_object(builder, 4, _TRANSFORM_TREE, 3, _transform_payload(2, 0, [5]))
    _add_object(builder, 1, _GAME_OBJECT_TREE, 4, _game_object_payload("Child", 5))
    _add_object(builder, 4, _TRANSFORM_TREE, 5, _transform_payload(4, 3, []))

    file = builder.build()
    file.name = "level0"
    return game_bundle.add_collection_from_serialized_file(file, GameAssetFactory())


def _build_loose_game_object_collection(game_bundle):
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    _add_object(builder, 1, _GAME_OBJECT_TREE, 2, _game_object_payload("LoosePrefab", 3))
    _add_object(builder, 4, _TRANSFORM_TREE, 3, _transform_payload(2, 0, []))

    file = builder.build()
    file.name = "sharedassets1"
    return game_bundle.add_collection_from_serialized_file(file, GameAssetFactory())


def _run_pipeline(game_bundle):
    game_data = GameData(game_bundle, _V2019, None, None)
    SceneDefinitionProcessor().process(game_data)
    PrefabProcessor().process(game_data)
    return game_data


def test_scene_hierarchy_groups_root_and_child_game_objects():
    game_bundle = GameBundle()
    _build_scene_collection(game_bundle)
    game_data = _run_pipeline(game_bundle)

    hierarchies = [a for a in game_data.game_bundle.fetch_assets() if a.class_id == ClassIDType.SceneAsset]
    assert len(hierarchies) == 1
    hierarchy = hierarchies[0]

    names = sorted(go.get("m_Name") for go in hierarchy.game_objects)
    assert names == ["Child", "Root"]
    assert len(hierarchy.components) == 2  # both Transforms
    assert len(hierarchy.managers) == 1  # RenderSettings

    for game_object in hierarchy.game_objects:
        assert game_object.main_asset is hierarchy
    for component in hierarchy.components:
        assert component.main_asset is hierarchy


def test_loose_game_object_gets_a_synthesized_prefab_hierarchy():
    game_bundle = GameBundle()
    _build_loose_game_object_collection(game_bundle)
    game_data = _run_pipeline(game_bundle)

    hierarchies = [
        a
        for a in game_data.game_bundle.fetch_assets()
        if a.class_id == ClassIDType.PrefabInstance and hasattr(a, "root")
    ]
    assert len(hierarchies) == 1
    hierarchy = hierarchies[0]

    assert hierarchy.root.get("m_Name") == "LoosePrefab"
    assert list(hierarchy.game_objects) == [hierarchy.root]
    assert len(hierarchy.components) == 1  # the Transform
    assert hierarchy.prefab in hierarchy.hidden_assets
    assert hierarchy.prefab.root_game_object is hierarchy.root
    assert hierarchy.root.main_asset is hierarchy


def test_scene_game_objects_are_not_also_turned_into_loose_prefabs():
    game_bundle = GameBundle()
    _build_scene_collection(game_bundle)
    game_data = _run_pipeline(game_bundle)

    prefab_hierarchies = [
        a
        for a in game_data.game_bundle.fetch_assets()
        if a.class_id == ClassIDType.PrefabInstance and hasattr(a, "root")
    ]
    assert prefab_hierarchies == []

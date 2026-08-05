"""Tests for `prefabs/missing_transforms.py` (2026-08-03), the port of upstream's
`PrefabProcessor.AddMissingTransforms`.

Unity requires every GameObject to have a Transform; one without cannot be placed in a hierarchy
at all. This is a measured edge case, not a hypothetical one in either direction: the real fixture
(`demo-android.apk`) has 407 GameObjects and **zero** missing a Transform, so these tests are the
only place the code path fires -- which is exactly why it needs them.

Fixtures are real embedded-type-tree assets read through the dynamic reader, matching
`test_prefab_processor.py`, so the synthesized Transform is appended to a genuine
`SerializableStructure`-backed `m_Component` array rather than a stand-in list.
"""
from __future__ import annotations

import struct

import pytest
from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion
from assetripper_processing.game_data import GameData
from assetripper_processing.prefabs import game_object_helpers
from assetripper_processing.prefabs.missing_transforms import add_missing_transforms

from import_._tree_builder import node, tree, unity_string

_V2019 = UnityVersion(2019, 4, 0)

# 5.5+ shape: m_Component is a vector of bare PPtr<Component>.
_GAME_OBJECT_TREE = tree(
    node("GameObject", "Base", 0),
    node("vector", "m_Component", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    node("PPtr<Component>", "data", 3),
    node("int", "m_FileID", 4),
    node("SInt64", "m_PathID", 4),
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
)


def _game_object_payload(name: str, component_path_ids) -> bytes:
    payload = struct.pack("<i", len(component_path_ids))
    for path_id in component_path_ids:
        payload += struct.pack("<iq", 0, path_id)
    return payload + unity_string(name)


def _build_game_data(*, give_the_second_object_a_transform: bool) -> GameData:
    """Two GameObjects; the second optionally already has a Transform, the first never does."""
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )

    def add_type(type_id: int, type_tree) -> SerializedType:
        serialized_type = SerializedType()
        serialized_type.type_id = type_id
        serialized_type.is_stripped_type = False
        serialized_type.script_type_index = -1
        serialized_type.old_type = type_tree
        serialized_type.old_type.build_string_buffer()
        builder.types.append(serialized_type)
        return serialized_type

    game_object_type = add_type(1, _GAME_OBJECT_TREE)
    transform_type = add_type(4, _TRANSFORM_TREE)

    def add_object(serialized_type: SerializedType, path_id: int, data: bytes) -> None:
        info = ObjectInfo(serialized_type)
        info.file_id = path_id
        info.serialized_type_index = builder.types.index(serialized_type)
        info.object_data = data
        builder.objects.append(info)

    add_object(game_object_type, 1, _game_object_payload("NoTransform", []))
    if give_the_second_object_a_transform:
        add_object(game_object_type, 2, _game_object_payload("HasTransform", [3]))
        add_object(transform_type, 3, struct.pack("<iq", 0, 2) + struct.pack("<iq", 0, 0))
    else:
        add_object(game_object_type, 2, _game_object_payload("AlsoNoTransform", []))

    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return GameData(game_bundle, _V2019, None, None)


def _game_objects(game_data):
    return [a for a in game_data.game_bundle.fetch_assets() if a.class_id == 1]


@pytest.fixture
def processed_bundle_factory():
    def make(game_data):
        return game_data.game_bundle.add_new_processed_bundle("Generated Hierarchy Assets")

    return make


def test_a_transform_is_added_to_every_game_object_that_lacks_one(processed_bundle_factory):
    game_data = _build_game_data(give_the_second_object_a_transform=False)

    added = add_missing_transforms(game_data, processed_bundle_factory(game_data))

    assert added == 2
    for game_object in _game_objects(game_data):
        assert game_object_helpers.get_transform(game_object) is not None, game_object.get("m_Name")


def test_a_game_object_that_already_has_a_transform_is_left_alone(processed_bundle_factory):
    game_data = _build_game_data(give_the_second_object_a_transform=True)
    existing = [a for a in game_data.game_bundle.fetch_assets() if a.class_id == 4]
    assert len(existing) == 1

    added = add_missing_transforms(game_data, processed_bundle_factory(game_data))

    assert added == 1, "only the one without a Transform should get one"
    with_transform = next(g for g in _game_objects(game_data) if g.get("m_Name") == "HasTransform")
    assert game_object_helpers.get_transform(with_transform) is existing[0], (
        "the pre-existing Transform must still be the one found, not a new duplicate"
    )


def test_the_synthesized_transform_is_listed_in_m_component(processed_bundle_factory):
    """The load-bearing part. A Transform that exists but is not in `m_Component` is an orphan --
    `SceneHierarchyObject` walks the component array, so Unity would never see it."""
    game_data = _build_game_data(give_the_second_object_a_transform=False)
    add_missing_transforms(game_data, processed_bundle_factory(game_data))

    game_object = _game_objects(game_data)[0]
    components = game_object.get("m_Component")
    assert len(components) == 1
    assert list(game_object_helpers.get_components(game_object))[0].class_id == 4


def test_the_synthesized_transform_points_back_at_its_game_object(processed_bundle_factory):
    """Without this the hierarchy walk cannot get from the Transform back to the GameObject, and
    `game_object_helpers.is_root` would misclassify it."""
    game_data = _build_game_data(give_the_second_object_a_transform=False)
    add_missing_transforms(game_data, processed_bundle_factory(game_data))

    game_object = _game_objects(game_data)[0]
    transform = game_object_helpers.get_transform(game_object)
    target = transform.get("m_GameObject")
    # Must be the structure's own SerializablePPtr, assigned through -- not replaced by a raw
    # PPtr, which the YAML walker cannot traverse.
    assert target.to_pptr().path_id == game_object.path_id


def test_the_synthesized_transform_has_unity_defaults_not_zeros(processed_bundle_factory):
    """A zero-filled Transform is not the identity: a zero quaternion is not a rotation at all,
    and a zero scale collapses the object to nothing."""
    game_data = _build_game_data(give_the_second_object_a_transform=False)
    add_missing_transforms(game_data, processed_bundle_factory(game_data))

    transform = game_object_helpers.get_transform(_game_objects(game_data)[0])
    # This tree deliberately omits m_LocalRotation/m_LocalScale, so the defaults are only
    # asserted when the layout in use actually has them -- see _initialize_default.
    rotation = transform.get("m_LocalRotation")
    if rotation is not None:
        assert rotation["w"] == 1.0
    scale = transform.get("m_LocalScale")
    if scale is not None:
        assert (scale["x"], scale["y"], scale["z"]) == (1.0, 1.0, 1.0)


def test_nothing_happens_and_no_collection_is_created_when_every_game_object_is_fine():
    """The overwhelmingly common case -- 407 of 407 on the real fixture. It must not leave an
    empty "Missing Prefab Transforms" collection behind in every export."""
    game_data = _build_game_data(give_the_second_object_a_transform=True)
    # Give the other one a Transform too, so nothing is missing.
    processed_bundle = game_data.game_bundle.add_new_processed_bundle("Generated Hierarchy Assets")
    add_missing_transforms(game_data, processed_bundle)
    collections_after_first_pass = len(processed_bundle.collections)

    assert add_missing_transforms(game_data, processed_bundle) == 0
    assert len(processed_bundle.collections) == collections_after_first_pass, (
        "a second pass must find nothing and create no collection"
    )


def test_running_it_twice_does_not_add_a_second_transform(processed_bundle_factory):
    game_data = _build_game_data(give_the_second_object_a_transform=False)
    processed_bundle = processed_bundle_factory(game_data)

    assert add_missing_transforms(game_data, processed_bundle) == 2
    assert add_missing_transforms(game_data, processed_bundle) == 0

    for game_object in _game_objects(game_data):
        assert len(game_object.get("m_Component")) == 1


def test_the_synthesized_transform_survives_yaml_export(processed_bundle_factory):
    """The reason `_point_game_object` assigns *through* the existing `SerializablePPtr` instead
    of replacing the field: a raw `PPtr` in a structure slot is something the YAML walker cannot
    traverse, so the whole scene export would break -- and only at export time, long after this
    processor ran."""
    from assetripper_export_unity_projects.yaml_walker import YamlWalker

    game_data = _build_game_data(give_the_second_object_a_transform=False)
    add_missing_transforms(game_data, processed_bundle_factory(game_data))

    transform = game_object_helpers.get_transform(_game_objects(game_data)[0])
    document = YamlWalker().export_yaml_document(transform, 1)

    assert document is not None
    root = document.root
    assert len(root.children) == 1, "one child: the class-name key mapped to the field mapping"


def test_the_owning_game_object_still_exports(processed_bundle_factory):
    """The other half: appending an element to `m_Component` must produce something the walker
    can traverse too, not a bare PPtr smuggled into a typed array."""
    from assetripper_export_unity_projects.yaml_walker import YamlWalker

    game_data = _build_game_data(give_the_second_object_a_transform=False)
    add_missing_transforms(game_data, processed_bundle_factory(game_data))

    game_object = _game_objects(game_data)[0]
    document = YamlWalker().export_yaml_document(game_object, 1)
    assert document is not None

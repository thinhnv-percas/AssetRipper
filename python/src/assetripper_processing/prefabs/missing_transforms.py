"""Port of `PrefabProcessor.AddMissingTransforms` (2026-08-03).

Unity requires every GameObject to have a Transform; one without is a GameObject the Unity
Editor cannot place in a hierarchy at all. Upstream synthesizes a default Transform for any such
GameObject before building scene/prefab hierarchies, and logs a warning naming it.

This is a real port rather than an authored guess, because it needs no new field knowledge: the
Transform layout already exists and is registered (`asset_creation/layouts/transform.py`), and
`TypeTreeObject.create` builds a default-initialized instance of it. The only values set by hand
are the two Unity defaults a zero-filled Transform would get wrong -- an identity rotation
(`w = 1`) and a unit scale -- and those are unambiguous, not inferred from bytes.

**How rare this is, measured rather than assumed:** the real fixture (`demo-android.apk`, a
shipped IL2CPP build) has 407 GameObjects and **zero** of them lack a Transform. So this exists
for malformed or partially-stripped builds, and its own tests are the only place it fires in
practice.
"""
from __future__ import annotations

import logging

from assetripper_import.asset_creation.type_tree_object import TypeTreeObject
from assetripper_primitives import UnityVersion

from . import game_object_helpers

_logger = logging.getLogger(__name__)

_GAME_OBJECT_CLASS_ID = 1
_TRANSFORM_CLASS_ID = 4

_MISSING_TRANSFORM_COLLECTION_NAME = "Missing Prefab Transforms"


def add_missing_transforms(game_data, processed_bundle) -> int:
    """Gives every Transform-less GameObject a default Transform. Returns how many were added.

    Unlike upstream this puts every synthesized Transform in one collection rather than routing
    scene GameObjects into a per-scene "(Generated Assets)" collection. The reason is ordering:
    upstream runs this *before* creating scene hierarchies and shares the same
    `GetOrCreateSceneCollection` cache with them, while this port's `PrefabProcessor` creates
    those collections inline in its own loop. Which collection a synthesized Transform lives in
    does not affect the exported bytes -- `SceneHierarchyObject` collects components by walking
    the GameObject hierarchy, not by collection membership -- so the simpler placement is used
    and noted rather than restructuring the processor around it.
    """
    missing = [
        asset
        for asset in game_data.game_bundle.fetch_assets()
        if asset.class_id == _GAME_OBJECT_CLASS_ID and game_object_helpers.get_transform(asset) is None
    ]
    if not missing:
        return 0

    collection = processed_bundle.add_new_processed_collection(
        _MISSING_TRANSFORM_COLLECTION_NAME, game_data.project_version
    )

    added = 0
    for game_object in missing:
        transform = _create_default_transform(collection, game_data.project_version)
        if transform is None:
            _logger.warning(
                "GameObject %s has no Transform, and no Transform layout is available for Unity "
                "%s, so one could not be added. It will not be placeable in the Unity Editor.",
                game_object.get("m_Name"),
                game_data.project_version,
            )
            continue

        _logger.warning("GameObject %s has no Transform. Adding one.", game_object.get("m_Name"))
        _point_game_object(transform, game_object)
        if not _append_component(game_object, transform):
            _logger.warning(
                "Could not add the synthesized Transform to GameObject %s's m_Component array; "
                "the Transform exists but the GameObject does not list it.",
                game_object.get("m_Name"),
            )
        added += 1
    return added


def _point_game_object(transform, game_object) -> None:
    """Writes the owning GameObject into the Transform's `m_GameObject`.

    Assigns *through* the existing `SerializablePPtr` rather than replacing the field value: the
    structure's field slots are typed by the layout, and putting a plain `PPtr` there would give
    the YAML walker something it cannot traverse.
    """
    pptr = game_object.collection.force_create_pptr(game_object)
    _write_pptr(transform.get("m_GameObject"), pptr)


def _write_pptr(target, pptr) -> bool:
    from assetripper_import.structure.assembly.serializable.serializable_pptr import SerializablePPtr

    if not isinstance(target, SerializablePPtr):
        return False
    target.file_id = pptr.file_id
    target.path_id = pptr.path_id
    return True


def _create_default_transform(collection, version):
    """Builds a Transform from the *registered* layout, so its field set and order are the same
    verified ones a Transform read from a real file gets -- nothing about the shape is authored
    here. `TypeTreeObject.create` default-initializes every field."""
    from assetripper_import.asset_creation.layouts import default_layout_provider

    root_node = default_layout_provider(_TRANSFORM_CLASS_ID, version)
    if root_node is None:
        return None

    def factory(asset_info):
        asset = TypeTreeObject.create(asset_info, root_node)
        # `TypeTreeObject.create` only allocates the field slots; `read` is what normally fills
        # them. Nothing is read here, so without this every field is still `None` -- and then
        # assigning `m_GameObject` would store a raw `PPtr` where the structure expects a
        # `SerializablePPtr`, which the YAML walker cannot traverse.
        asset.fields.initialize_fields(version)
        return asset

    transform = collection.create_asset(_TRANSFORM_CLASS_ID, factory)
    _initialize_default(transform)
    return transform


def _initialize_default(transform) -> None:
    """Upstream's `ITransform.InitializeDefault()`. A zero-filled Transform is not the identity:
    a zero quaternion is not a rotation at all, and a zero scale collapses the object."""
    rotation = transform.get("m_LocalRotation")
    if rotation is not None:
        rotation["w"] = 1.0
    scale = transform.get("m_LocalScale")
    if scale is not None:
        scale["x"] = 1.0
        scale["y"] = 1.0
        scale["z"] = 1.0


def _append_component(game_object, transform) -> bool:
    """Appends `transform` to `game_object.m_Component`, building an element of whichever shape
    this Unity version uses.

    `m_Component` is a `vector<ComponentPair>` before 5.5 and a `vector<PPtr>` from 5.5 on (see
    `game_object_helpers`' docstring for how both are read). Rather than branching on version,
    the element is built from the array field's own element descriptor, so it always matches what
    the layout in use actually declares -- the same source of truth the reader goes by.
    """
    structure = getattr(game_object, "fields", None)
    if structure is None:
        return False
    index = structure.try_get_index("m_Component")
    if index < 0:
        return False

    etalon = structure.type.fields[index]
    components = structure.fields[index].value
    if components is None:
        components = []
        structure.fields[index].value = components

    element = _create_component_element(etalon, structure.depth)
    if element is None:
        return False
    if not _point_element_at(element, transform, game_object.collection):
        return False
    components.append(element)
    return True


def _create_component_element(etalon, depth: int):
    """One `m_Component` element pointing at nothing yet -- the caller fills in the PPtr."""
    from assetripper_import.structure.assembly.serializable.serializable_pptr import SerializablePPtr
    from assetripper_import.structure.assembly.serializable.serializable_structure import (
        SerializableStructure,
    )

    element_type = etalon.type
    if element_type.is_engine_pointer():
        return SerializablePPtr(getattr(element_type, "path_id_is_64bit", True))
    element = SerializableStructure(element_type, depth + 1)
    element.initialize_fields(UnityVersion())
    return element


def _point_element_at(element, transform, collection) -> bool:
    """Writes the Transform's PPtr into a freshly created `m_Component` element, for either
    shape: a bare PPtr (5.5+), or a `ComponentPair` whose `component`/`second` field holds it."""
    pptr = collection.force_create_pptr(transform)
    if _write_pptr(element, pptr):
        return True
    for name in ("component", "second"):
        if name in element and _write_pptr(element[name], pptr):
            return True
    return False

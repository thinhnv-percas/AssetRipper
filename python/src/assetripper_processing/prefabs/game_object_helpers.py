"""Dynamic-field reimplementations of `Source/AssetRipper.SourceGenerated.Extensions/
{GameObjectExtensions,PrefabInstanceExtensions}.cs`'s hierarchy-walking helpers.

Upstream operates on generated typed interfaces (`IGameObject.GetComponentAccessList()`,
`ITransform.Father_C4P`, `ITransform.Children_C4P`, ...), each a real property backed by a
known field layout. This port's assets are dynamically-read `TypeTreeObject`s (or the
Phase 2 hand-written `GameObject`/`Transform` layouts) with no typed properties at all, so
every helper here goes through `asset.get(field_name)` instead -- a reimplementation of the
*algorithm*, not a port of the code.

Field shapes assumed (real, stable Unity field names, not guessed):
- `GameObject.m_Component`: an array of `ComponentPair`, each holding one field named
  `component` (a `PPtr<Component>`). This is what a real embedded type tree encodes --
  `ComponentPair`'s type name is not literally `"pair"`, so the dynamic reader's
  `TypeTreeNodeStruct.is_pair` structural check (which requires exactly that type name plus
  `first`/`second` sub-fields) doesn't match it; it reads as an ordinary Complex struct with
  a `component` field, not a `SerializablePair`. Phase 2's hand-written GameObject layout
  (used only for files with no embedded type tree) instead models `m_Component` as
  `vector<pair<int, PPtr<Component>>>` -- a real, different, pre-5.5-shaped encoding that
  *does* satisfy `is_pair` and produces `SerializablePair` objects (`.first`/`.second`).
  `_component_pptr` handles both shapes.
- `Transform.m_Father`/`m_GameObject`: `PPtr<Transform>`/`PPtr<GameObject>` fields, and
  `m_Children`: array of `PPtr<Transform>` -- both the dynamic reader and Phase 2's
  hand-written Transform layout encode these identically (plain PPtr fields, not pairs), so
  no shape-detection is needed for these three.
"""
from __future__ import annotations

from assetripper_assets.null_object import NullObject
from assetripper_import.class_id_type import ClassIDType

_TRANSFORM_CLASS_IDS = frozenset({ClassIDType.Transform, ClassIDType.RectTransform})


def _component_pptr(entry):
    """`entry` is one element of `GameObject.m_Component` -- see module docstring for the
    two possible shapes this handles."""
    if hasattr(entry, "get"):
        value = entry.get("component")
        if value is not None:
            return value
        return entry
    second = getattr(entry, "second", None)
    if second is not None:
        return second.value
    return entry


def get_components(game_object):
    """Yields every component resolved from `game_object.m_Component`, skipping any PPtr
    that doesn't resolve (missing cross-file dependency, stripped data, ...)."""
    collection = game_object.collection
    for entry in game_object.get("m_Component") or ():
        pptr = _component_pptr(entry)
        if pptr is None:
            continue
        component = collection.get_asset_by_pptr(pptr.to_pptr(), NullObject)
        if component is not None:
            yield component


def get_transform(game_object):
    """The first resolved Transform/RectTransform component, or None."""
    for component in get_components(game_object):
        if component.class_id in _TRANSFORM_CLASS_IDS:
            return component
    return None


def _resolve_pptr_field(asset, field_name: str):
    pptr = asset.get(field_name)
    if pptr is None or pptr.path_id == 0:
        return None
    return asset.collection.get_asset_by_pptr(pptr.to_pptr(), NullObject)


def _resolve_game_object(transform):
    return _resolve_pptr_field(transform, "m_GameObject")


def _resolve_father(transform):
    return _resolve_pptr_field(transform, "m_Father")


def is_root(game_object) -> bool:
    """Port of `GameObjectExtensions.IsRoot`: true when the GameObject has no Transform, or
    its Transform's parent doesn't resolve to anything."""
    transform = get_transform(game_object)
    if transform is None:
        return True
    return _resolve_father(transform) is None


def get_root(game_object):
    """Port of `GameObjectExtensions.GetRoot`: walks up `m_Father` until it can't resolve a
    parent Transform or that parent's owning GameObject, matching upstream's loop exactly
    (both conditions are checked, not just "no parent")."""
    transform = get_transform(game_object)
    if transform is None:
        return game_object

    while True:
        parent = _resolve_father(transform)
        if parent is None:
            break
        parent_game_object = _resolve_game_object(parent)
        if parent_game_object is None:
            break
        transform = parent

    return _resolve_game_object(transform) or game_object


def get_children(transform):
    """Yields the resolved child Transforms of `transform.m_Children`."""
    collection = transform.collection
    for child_pptr in transform.get("m_Children") or ():
        if child_pptr is None or child_pptr.path_id == 0:
            continue
        child = collection.get_asset_by_pptr(child_pptr.to_pptr(), NullObject)
        if child is not None:
            yield child


def fetch_hierarchy(root_game_object):
    """Port of `GameObjectExtensions.FetchHierarchy`: depth-first walk yielding `root`, its
    components, then recursing into every child GameObject (found via the Transform
    component's `m_Children`), in that order."""
    yield root_game_object

    transform = None
    for component in get_components(root_game_object):
        yield component
        if component.class_id in _TRANSFORM_CLASS_IDS:
            transform = component

    if transform is None:
        return

    for child_transform in get_children(transform):
        child_game_object = _resolve_game_object(child_transform)
        if child_game_object is not None:
            yield from fetch_hierarchy(child_game_object)

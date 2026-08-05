"""Port of Source/AssetRipper.Processing/ScriptableObject/ScriptableObjectProcessor.cs
(Phase 13h)

Groups MonoBehaviours that Unity treats as a single logical asset even though they're
serialized as several independent objects: a `TimelineAsset` (root) plus the `TrackAsset`/
`TimelineClip`-referenced/marker MonoBehaviours it privately owns, and a `PostProcessProfile`
(root) plus the effect-settings MonoBehaviours listed in its `settings` array. Without this,
each of those lands as its own loose `.asset` file and Unity's Editor can't reassemble the
Timeline/Volume-profile relationship.

Like `assetripper_processing/prefabs/game_object_helpers.py` (see its own docstring for the
same caveat), this is a *reimplementation of the algorithm* against dynamic field access
(`asset.get(field_name)`), not a literal port of upstream's code: upstream reads via
`IMonoBehaviour.LoadStructure()` (a `SerializableStructure` built from the script's *recovered*
field layout -- Phase 16 territory, not available in this port) falling back to nothing if
that fails. This port instead reads whatever a *real embedded type tree* already exposes via
`.get(...)` (works for editor-produced/non-stripped serialized files, the same precondition
every other dynamic-field helper in this codebase already depends on) and treats a
MonoBehaviour with no such fields as having none -- a strict, honestly-narrower subset of
upstream's capability, not a fabrication.

Field names used (all standard, stable Unity/Timeline/PostProcessing serialized field names,
same confidence tier as `m_GameObject`/`m_Component` elsewhere in this port -- not guessed):
`m_Script` (MonoBehaviour -> MonoScript PPtr, already used by `mono_script_info.py`),
`m_Namespace`/`m_ClassName` (MonoScript, ditto), `m_Tracks`/`m_MarkerTrack` (TimelineAsset),
`m_Parent` (TrackAsset), `m_Clips` + each clip's `m_Asset` (TrackAsset), `m_Markers.m_Objects`
(TrackAsset), `settings` (PostProcessProfile).
"""
from __future__ import annotations

import logging

from assetripper_assets.null_object import NullObject

from ..i_asset_processor import IAssetProcessor
from .scriptable_object_group import ScriptableObjectGroup

_logger = logging.getLogger(__name__)

_MONO_BEHAVIOUR_CLASS_ID = 114

_TIMELINE_NAMESPACE = "UnityEngine.Timeline"
_TIMELINE_ASSET_CLASS_NAME = "TimelineAsset"
_POST_PROCESS_NAMESPACE = "UnityEngine.Rendering.PostProcessing"
_POST_PROCESS_PROFILE_CLASS_NAME = "PostProcessProfile"


class ScriptableObjectProcessor(IAssetProcessor):
    def process(self, game_data) -> None:
        _logger.info("Processing Scriptable Object Groups")
        collection = game_data.add_new_processed_collection("Generated Scriptable Object Groups")

        # Assets that can be a child of a group.
        unique_assets: set = set()
        # Assets that cannot be a child of a group (referenced by more than one root, or
        # already a root/already grouped themselves).
        nonunique_assets: set = set()

        timeline_assets: list = []
        post_process_profiles: list = []

        for mono_behaviour in game_data.game_bundle.fetch_assets():
            if mono_behaviour.class_id != _MONO_BEHAVIOUR_CLASS_ID:
                continue
            if mono_behaviour.main_asset is not None:
                continue
            if is_timeline_asset(mono_behaviour):
                nonunique_assets.add(mono_behaviour)
                timeline_assets.append(mono_behaviour)
            elif is_post_process_profile(mono_behaviour):
                nonunique_assets.add(mono_behaviour)
                post_process_profiles.append(mono_behaviour)

        for timeline_asset in timeline_assets:
            for child in _find_timeline_asset_children(timeline_asset):
                _add_child(unique_assets, nonunique_assets, child)
        for post_process_profile in post_process_profiles:
            for child in _find_post_process_profile_children(post_process_profile):
                _add_child(unique_assets, nonunique_assets, child)

        nonunique_assets.clear()

        for timeline_asset in timeline_assets:
            group = _create_group(collection, timeline_asset)
            group.file_extension = "playable"
            group.children.extend(c for c in _find_timeline_asset_children(timeline_asset) if c in unique_assets)
            group.set_main_asset()
        for post_process_profile in post_process_profiles:
            group = _create_group(collection, post_process_profile)
            group.children.extend(
                c for c in _find_post_process_profile_children(post_process_profile) if c in unique_assets
            )
            group.set_main_asset()


def _add_child(unique_assets: set, nonunique_assets: set, child) -> None:
    if child.main_asset is not None:
        return
    if child in nonunique_assets:
        return
    if child not in unique_assets:
        unique_assets.add(child)
    else:
        unique_assets.discard(child)
        nonunique_assets.add(child)


def _create_group(collection, root) -> ScriptableObjectGroup:
    return collection.create_asset(-1, lambda asset_info, data: ScriptableObjectGroup(asset_info, data), root)


def _resolve_pptr(collection, pptr):
    if pptr is None or pptr.path_id == 0:
        return None
    return collection.get_asset_by_pptr(pptr.to_pptr(), NullObject)


def _get_script(mono_behaviour):
    return _resolve_pptr(mono_behaviour.collection, mono_behaviour.get("m_Script"))


def _is_type(mono_behaviour, namespace: str, class_name: str) -> bool:
    script = _get_script(mono_behaviour)
    if script is None:
        return False
    return (script.get("m_Namespace") or "") == namespace and (script.get("m_ClassName") or "") == class_name


def is_timeline_asset(mono_behaviour) -> bool:
    return _is_type(mono_behaviour, _TIMELINE_NAMESPACE, _TIMELINE_ASSET_CLASS_NAME)


def is_post_process_profile(mono_behaviour) -> bool:
    return _is_type(mono_behaviour, _POST_PROCESS_NAMESPACE, _POST_PROCESS_PROFILE_CLASS_NAME)


def _find_timeline_asset_children(root) -> list:
    collection = root.collection
    children: dict = {}  # dict-as-ordered-set: insertion order, no duplicates

    for track_pptr in root.get("m_Tracks") or ():
        track = _resolve_pptr(collection, track_pptr)
        if track is None:
            continue

        parent_pptr = track.get("m_Parent")
        parent = _resolve_pptr(collection, parent_pptr) if parent_pptr is not None else None
        if parent is not root:
            continue

        children[track] = None

        for clip in track.get("m_Clips") or ():
            clip_asset = _resolve_pptr(collection, clip.get("m_Asset"))
            if clip_asset is not None:
                children[clip_asset] = None

        markers = track.get("m_Markers")
        marker_objects = markers.get("m_Objects") if markers is not None else None
        for marker_pptr in marker_objects or ():
            marker = _resolve_pptr(collection, marker_pptr)
            if marker is not None:
                children[marker] = None

    marker_track = _resolve_pptr(collection, root.get("m_MarkerTrack"))
    if marker_track is not None:
        children[marker_track] = None

    return list(children)


def _find_post_process_profile_children(root) -> list:
    collection = root.collection
    children: dict = {}
    for pptr in root.get("settings") or ():
        child = _resolve_pptr(collection, pptr)
        if child is not None:
            children[child] = None
    return list(children)

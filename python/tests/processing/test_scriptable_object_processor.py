"""Phase 13h: `ScriptableObjectProcessor` -- groups a TimelineAsset/PostProcessProfile
MonoBehaviour with the other MonoBehaviours it privately owns. Builds synthetic MonoScript +
MonoBehaviour assets via hand-built type trees, mirroring test_sprite_processor.py.
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
from assetripper_processing.scriptable_object.scriptable_object_group import ScriptableObjectGroup
from assetripper_processing.scriptable_object.scriptable_object_processor import ScriptableObjectProcessor

from import_._tree_builder import node, pptr_nodes, string_nodes, tree, unity_string

_V2019 = UnityVersion(2019, 4, 0)
_MONO_BEHAVIOUR_CLASS_ID = 114
_MONO_SCRIPT_CLASS_ID = 115


def _pptr_array_nodes(name: str, target: str, level: int) -> list:
    return [
        node("vector", name, level),
        node("Array", "Array", level + 1),
        node("int", "size", level + 2),
        node(f"PPtr<{target}>", "data", level + 2),
        node("int", "m_FileID", level + 3),
        node("SInt64", "m_PathID", level + 3),
    ]


def _clip_array_nodes(name: str, level: int) -> list:
    return [
        node("vector", name, level),
        node("Array", "Array", level + 1),
        node("int", "size", level + 2),
        node("TimelineClip", "data", level + 2),
        node("PPtr<MonoBehaviour>", "m_Asset", level + 3),
        node("int", "m_FileID", level + 4),
        node("SInt64", "m_PathID", level + 4),
    ]


def _markers_struct_nodes(name: str, level: int) -> list:
    return [
        node("MarkerList", name, level),
        *_pptr_array_nodes("m_Objects", "MonoBehaviour", level + 1),
    ]


_MONO_SCRIPT_TREE = tree(
    node("MonoScript", "Base", 0),
    *string_nodes("m_Name", 1),
    *string_nodes("m_ClassName", 1),
    *string_nodes("m_Namespace", 1),
    *string_nodes("m_AssemblyName", 1),
)

_TIMELINE_ROOT_TREE = tree(
    node("MonoBehaviour", "Base", 0),
    *pptr_nodes("m_Script", "MonoScript", 1),
    *_pptr_array_nodes("m_Tracks", "MonoBehaviour", 1),
    *pptr_nodes("m_MarkerTrack", "MonoBehaviour", 1),
)

_TRACK_TREE = tree(
    node("MonoBehaviour", "Base", 0),
    *pptr_nodes("m_Parent", "MonoBehaviour", 1),
    *_clip_array_nodes("m_Clips", 1),
    *_markers_struct_nodes("m_Markers", 1),
)

_PPP_ROOT_TREE = tree(
    node("MonoBehaviour", "Base", 0),
    *pptr_nodes("m_Script", "MonoScript", 1),
    *_pptr_array_nodes("settings", "MonoBehaviour", 1),
)

_MINIMAL_MONOBEHAVIOUR_TREE = tree(node("MonoBehaviour", "Base", 0))


def _script_bytes(class_name: str, namespace: str) -> bytes:
    return unity_string("") + unity_string(class_name) + unity_string(namespace) + unity_string("TestAssembly")


def _pptr_bytes(file_id: int, path_id: int) -> bytes:
    return struct.pack("<iq", file_id, path_id)


def _pptr_array_bytes(path_ids: "list[int]") -> bytes:
    out = struct.pack("<i", len(path_ids))
    for path_id in path_ids:
        out += _pptr_bytes(0, path_id)
    return out


class _Builder:
    def __init__(self):
        self._builder = SerializedFileBuilder(
            generation=FormatVersion.LARGE_FILES_SUPPORT,
            version=_V2019,
            platform=BuildTarget.STANDALONE_WIN64_PLAYER,
            has_type_tree=True,
        )
        self._types: dict = {}

    def _type_for(self, class_id: int, tree_) -> SerializedType:
        key = id(tree_)
        cached = self._types.get(key)
        if cached is not None:
            return cached
        type_ = SerializedType()
        type_.type_id = class_id
        type_.is_stripped_type = False
        type_.script_type_index = -1
        type_.old_type = tree_
        self._builder.types.append(type_)
        self._types[key] = type_
        return type_

    def add(self, class_id: int, tree_, path_id: int, data: bytes) -> None:
        type_ = self._type_for(class_id, tree_)
        obj = ObjectInfo(type_)
        obj.file_id = path_id
        obj.serialized_type_index = self._builder.types.index(type_)
        obj.object_data = data
        self._builder.objects.append(obj)

    def build_bundle(self) -> GameBundle:
        serialized_file = self._builder.build()
        serialized_file.name = "sharedassets0"
        game_bundle = GameBundle()
        game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
        return game_bundle


def _find(game_bundle, path_id: int):
    for collection in game_bundle.fetch_asset_collections():
        for asset in collection:
            if asset.path_id == path_id:
                return asset
    raise AssertionError(f"no asset with path_id {path_id} found")


def _find_group(game_bundle) -> "list[ScriptableObjectGroup]":
    return [
        asset
        for collection in game_bundle.fetch_asset_collections()
        for asset in collection
        if isinstance(asset, ScriptableObjectGroup)
    ]


def test_timeline_asset_groups_owned_track_clips_and_markers():
    builder = _Builder()
    # path_ids: 1=TimelineAsset script, 2=root, 3=track, 4=marker_track, 5=clip asset, 6=marker
    builder.add(_MONO_SCRIPT_CLASS_ID, _MONO_SCRIPT_TREE, 1, _script_bytes("TimelineAsset", "UnityEngine.Timeline"))
    builder.add(
        _MONO_BEHAVIOUR_CLASS_ID,
        _TIMELINE_ROOT_TREE,
        2,
        _pptr_bytes(0, 1) + _pptr_array_bytes([3]) + _pptr_bytes(0, 4),
    )
    builder.add(
        _MONO_BEHAVIOUR_CLASS_ID,
        _TRACK_TREE,
        3,
        _pptr_bytes(0, 2) + _pptr_array_bytes([5]) + _pptr_array_bytes([6]),
    )
    builder.add(_MONO_BEHAVIOUR_CLASS_ID, _MINIMAL_MONOBEHAVIOUR_TREE, 4, b"")  # marker track
    builder.add(_MONO_BEHAVIOUR_CLASS_ID, _MINIMAL_MONOBEHAVIOUR_TREE, 5, b"")  # clip asset
    builder.add(_MONO_BEHAVIOUR_CLASS_ID, _MINIMAL_MONOBEHAVIOUR_TREE, 6, b"")  # marker
    game_bundle = builder.build_bundle()

    ScriptableObjectProcessor().process(GameData(game_bundle, _V2019, None, None))

    groups = _find_group(game_bundle)
    assert len(groups) == 1
    group = groups[0]
    assert group.file_extension == "playable"
    assert group.root is _find(game_bundle, 2)

    children = set(group.children)
    assert children == {_find(game_bundle, 3), _find(game_bundle, 4), _find(game_bundle, 5), _find(game_bundle, 6)}
    for child in children:
        assert child.main_asset is group
    assert group.root.main_asset is group


def test_post_process_profile_groups_settings_children():
    builder = _Builder()
    builder.add(
        _MONO_SCRIPT_CLASS_ID, _MONO_SCRIPT_TREE, 1, _script_bytes("PostProcessProfile", "UnityEngine.Rendering.PostProcessing")
    )
    builder.add(_MONO_BEHAVIOUR_CLASS_ID, _PPP_ROOT_TREE, 2, _pptr_bytes(0, 1) + _pptr_array_bytes([3]))
    builder.add(_MONO_BEHAVIOUR_CLASS_ID, _MINIMAL_MONOBEHAVIOUR_TREE, 3, b"")  # settings
    game_bundle = builder.build_bundle()

    ScriptableObjectProcessor().process(GameData(game_bundle, _V2019, None, None))

    groups = _find_group(game_bundle)
    assert len(groups) == 1
    group = groups[0]
    assert group.file_extension is None
    assert list(group.children) == [_find(game_bundle, 3)]
    assert _find(game_bundle, 3).main_asset is group


def test_track_not_owned_by_root_is_excluded():
    builder = _Builder()
    builder.add(_MONO_SCRIPT_CLASS_ID, _MONO_SCRIPT_TREE, 1, _script_bytes("TimelineAsset", "UnityEngine.Timeline"))
    builder.add(
        _MONO_BEHAVIOUR_CLASS_ID, _TIMELINE_ROOT_TREE, 2, _pptr_bytes(0, 1) + _pptr_array_bytes([3]) + _pptr_bytes(0, 0)
    )
    # track's m_Parent points at an unrelated asset (4), not root (2).
    builder.add(
        _MONO_BEHAVIOUR_CLASS_ID, _TRACK_TREE, 3, _pptr_bytes(0, 4) + _pptr_array_bytes([]) + _pptr_array_bytes([])
    )
    builder.add(_MONO_BEHAVIOUR_CLASS_ID, _MINIMAL_MONOBEHAVIOUR_TREE, 4, b"")  # unrelated parent
    game_bundle = builder.build_bundle()

    ScriptableObjectProcessor().process(GameData(game_bundle, _V2019, None, None))

    groups = _find_group(game_bundle)
    assert len(groups) == 1
    assert list(groups[0].children) == []
    assert _find(game_bundle, 3).main_asset is None


def test_child_shared_by_two_roots_becomes_nonunique_and_is_excluded_from_both():
    builder = _Builder()
    builder.add(
        _MONO_SCRIPT_CLASS_ID, _MONO_SCRIPT_TREE, 1, _script_bytes("PostProcessProfile", "UnityEngine.Rendering.PostProcessing")
    )
    builder.add(_MONO_BEHAVIOUR_CLASS_ID, _PPP_ROOT_TREE, 2, _pptr_bytes(0, 1) + _pptr_array_bytes([4]))
    builder.add(_MONO_BEHAVIOUR_CLASS_ID, _PPP_ROOT_TREE, 3, _pptr_bytes(0, 1) + _pptr_array_bytes([4]))
    builder.add(_MONO_BEHAVIOUR_CLASS_ID, _MINIMAL_MONOBEHAVIOUR_TREE, 4, b"")  # shared setting
    game_bundle = builder.build_bundle()

    ScriptableObjectProcessor().process(GameData(game_bundle, _V2019, None, None))

    groups = _find_group(game_bundle)
    assert len(groups) == 2
    for group in groups:
        assert list(group.children) == []
    assert _find(game_bundle, 4).main_asset is None

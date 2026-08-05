"""End-to-end test for Phase 13h (ScriptableObjectProcessor + ScriptableObjectGroupExportCollection):
runs ScriptableObjectProcessor then ProjectExporter on a synthetic TimelineAsset (root) with
one owned track (plus its clip/marker/marker-track), and checks that a single `.playable`
file comes out -- not four loose `.asset` files, which is what this port produced before
Phase 13h.
"""
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_primitives import UnityVersion
from assetripper_processing.game_data import GameData
from assetripper_processing.scriptable_object.scriptable_object_processor import ScriptableObjectProcessor

from processing.test_scriptable_object_processor import (
    _MONO_BEHAVIOUR_CLASS_ID,
    _MONO_SCRIPT_CLASS_ID,
    _MINIMAL_MONOBEHAVIOUR_TREE,
    _TIMELINE_ROOT_TREE,
    _TRACK_TREE,
    _MONO_SCRIPT_TREE,
    _Builder,
    _pptr_array_bytes,
    _pptr_bytes,
    _script_bytes,
)

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)


def test_timeline_asset_group_exports_as_a_single_playable_file(tmp_path):
    builder = _Builder()
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

    game_data = GameData(game_bundle, _V2019, None, None)
    ScriptableObjectProcessor().process(game_data)

    exporter = ProjectExporter()
    exporter.export(game_data.game_bundle, str(tmp_path), FS)

    playable_files = list(tmp_path.rglob("*.playable"))
    assert len(playable_files) == 1

    text = playable_files[0].read_text(encoding="utf-8")
    assert text.count("--- !u!114 ") == 5  # root + track + marker track + clip asset + marker, one file

    meta_path = playable_files[0].with_name(playable_files[0].name + ".meta")
    assert meta_path.exists()

    # The only loose `.asset` file left is the MonoScript itself (not grouped by
    # ScriptableObjectProcessor -- it isn't a MonoBehaviour); none of the 5 grouped
    # MonoBehaviours leaked out as their own file.
    asset_files = list(tmp_path.rglob("*.asset"))
    assert len(asset_files) == 1
    assert "MonoScript" in asset_files[0].read_text(encoding="utf-8")

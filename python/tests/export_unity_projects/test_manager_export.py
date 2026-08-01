"""Phase 15: `Project/{ManagerAssetExporter,ManagerExportCollection}.cs` port -- verifies
GlobalGameManager singletons (and PlayerSettings) land in `ProjectSettings/<Name>.asset`
with no `.meta` file, instead of a stray `Assets/<ClassName>/*.asset` (which is what every
export before this phase produced -- see ROADMAP.md's "Mục tiêu & Scope" audit note on why
that made every exported project open with zero project settings).
"""
from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_unity_projects.project.manager_asset_exporter import ManagerAssetExporter
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, tree

FS = LocalFileSystem()


def _build_game_bundle(entries: "list[tuple[int, str]]"):
    """`entries`: list of (class_id, type_name) pairs, each becoming one empty-payload asset."""
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    for file_id, (class_id, type_name) in enumerate(entries, start=1):
        type_ = SerializedType()
        type_.type_id = class_id
        type_.is_stripped_type = False
        type_.script_type_index = -1
        type_.old_type = tree(node(type_name, "Base", 0))

        obj = ObjectInfo(type_)
        obj.file_id = file_id
        obj.serialized_type_index = len(builder.types)
        obj.object_data = b""

        builder.types.append(type_)
        builder.objects.append(obj)

    serialized_file = builder.build()
    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return game_bundle


def _make_exporter() -> ProjectExporter:
    from assetripper_export_unity_projects.project.manager_asset_exporter import (
        _GLOBAL_GAME_MANAGER_CLASS_IDS,
        _PLAYER_SETTINGS_CLASS_ID,
    )

    exporter = ProjectExporter()
    manager_exporter = ManagerAssetExporter()
    for class_id in (*_GLOBAL_GAME_MANAGER_CLASS_IDS, _PLAYER_SETTINGS_CLASS_ID):
        exporter.override_exporter_for_class_id(class_id, manager_exporter)
    return exporter


def test_global_game_manager_exports_to_project_settings_with_no_meta_file(tmp_path):
    game_bundle = _build_game_bundle([(78, "TagManager")])  # ClassIDType.TagManager
    _make_exporter().export(game_bundle, str(tmp_path), FS)

    asset_path = tmp_path / "ProjectSettings" / "TagManager.asset"
    assert asset_path.exists()
    assert not (tmp_path / "ProjectSettings" / "TagManager.asset.meta").exists()
    assert list(tmp_path.rglob("Assets")) == []  # nothing landed under Assets/ instead


def test_player_settings_renamed_to_project_settings(tmp_path):
    # Class 129 (PlayerSettings) has no ClassIDType entry (see manager_asset_exporter.py's
    # docstring) -- routed purely by class ID, regardless of the type tree's own name.
    game_bundle = _build_game_bundle([(129, "PlayerSettings")])
    _make_exporter().export(game_bundle, str(tmp_path), FS)

    assert (tmp_path / "ProjectSettings" / "ProjectSettings.asset").exists()


def test_nav_mesh_project_settings_renamed_to_nav_mesh_areas(tmp_path):
    game_bundle = _build_game_bundle([(126, "NavMeshProjectSettings")])
    _make_exporter().export(game_bundle, str(tmp_path), FS)

    assert (tmp_path / "ProjectSettings" / "NavMeshAreas.asset").exists()
    assert not (tmp_path / "ProjectSettings" / "NavMeshProjectSettings.asset").exists()


def test_physics_manager_renamed_to_dynamics_manager(tmp_path):
    game_bundle = _build_game_bundle([(55, "PhysicsManager")])
    _make_exporter().export(game_bundle, str(tmp_path), FS)

    assert (tmp_path / "ProjectSettings" / "DynamicsManager.asset").exists()
    assert not (tmp_path / "ProjectSettings" / "PhysicsManager.asset").exists()


def test_export_id_is_always_one():
    game_bundle = _build_game_bundle([(78, "TagManager")])
    exporter = _make_exporter()
    collections = exporter.create_collections(game_bundle)
    assert len(collections) == 1
    asset = next(iter(collections[0].assets))
    assert collections[0].get_export_id(None, asset) == 1


def test_multiple_managers_each_get_their_own_project_settings_file(tmp_path):
    game_bundle = _build_game_bundle([(78, "TagManager"), (5, "TimeManager"), (11, "AudioManager")])
    _make_exporter().export(game_bundle, str(tmp_path), FS)

    project_settings_dir = tmp_path / "ProjectSettings"
    names = sorted(p.name for p in project_settings_dir.iterdir())
    assert names == ["AudioManager.asset", "TagManager.asset", "TimeManager.asset"]


def test_register_default_exporters_wires_managers_and_dummy_managers(tmp_path):
    """`registration.py`'s Phase 15 wiring, exercised end to end: a real GlobalGameManager
    goes to ProjectSettings/, a dummy-exported one (BuildSettings) produces no file at all."""
    from assetripper_export_modules.registration import register_default_exporters

    game_bundle = _build_game_bundle([(78, "TagManager"), (141, "BuildSettings")])
    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)

    assert (tmp_path / "ProjectSettings" / "TagManager.asset").exists()

    all_files = [p for p in tmp_path.rglob("*") if p.is_file()]
    assert all_files == [tmp_path / "ProjectSettings" / "TagManager.asset"]

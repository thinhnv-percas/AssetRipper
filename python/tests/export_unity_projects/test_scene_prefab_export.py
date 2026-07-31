"""End-to-end test for Phase 12 (Prefab/Scene export): runs the full
SceneDefinitionProcessor -> PrefabProcessor -> ProjectExporter pipeline on a synthetic
2-GameObject scene and a synthetic loose GameObject, and checks that a single `.unity`
file and a single `.prefab` file come out (not one loose `.asset` per GameObject/
Transform/manager, which is what this port produced before Phase 12).
"""
from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_processing.game_data import GameData
from assetripper_processing.prefabs.prefab_processor import PrefabProcessor
from assetripper_processing.scenes.scene_definition_processor import SceneDefinitionProcessor
from assetripper_primitives import UnityVersion

from processing.test_prefab_processor import _build_loose_game_object_collection, _build_scene_collection

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)


def _run_pipeline_and_export(game_bundle, tmp_path):
    game_data = GameData(game_bundle, _V2019, None, None)
    SceneDefinitionProcessor().process(game_data)
    PrefabProcessor().process(game_data)

    exporter = ProjectExporter()
    exporter.export(game_data.game_bundle, str(tmp_path), FS)
    return game_data


def test_scene_exports_as_a_single_unity_file(tmp_path):
    game_bundle = GameBundle()
    _build_scene_collection(game_bundle)
    _run_pipeline_and_export(game_bundle, tmp_path)

    unity_files = list(tmp_path.rglob("*.unity"))
    assert len(unity_files) == 1
    assert unity_files[0].name == "level0.unity"
    assert unity_files[0].with_name(unity_files[0].name + ".meta").exists()

    text = unity_files[0].read_text(encoding="utf-8")
    assert text.count("--- !u!") == 5  # RenderSettings + 2 GameObjects + 2 Transforms, one file
    assert "m_Name: Root" in text
    assert "m_Name: Child" in text

    # No loose per-object .asset files -- everything landed in the one .unity file.
    assert list(tmp_path.rglob("*.asset")) == []


def test_prefab_exports_as_a_single_prefab_file(tmp_path):
    game_bundle = GameBundle()
    _build_loose_game_object_collection(game_bundle)
    _run_pipeline_and_export(game_bundle, tmp_path)

    prefab_files = list(tmp_path.rglob("*.prefab"))
    assert len(prefab_files) == 1
    assert prefab_files[0].name == "LoosePrefab.prefab"

    text = prefab_files[0].read_text(encoding="utf-8")
    assert "m_Name: LoosePrefab" in text
    assert "--- !u!1 " in text  # GameObject document
    assert "--- !u!4 " in text  # Transform document

    meta_path = prefab_files[0].with_name(prefab_files[0].name + ".meta")
    assert meta_path.exists()
    assert "PrefabImporter:" in meta_path.read_text(encoding="utf-8")

    assert list(tmp_path.rglob("*.asset")) == []

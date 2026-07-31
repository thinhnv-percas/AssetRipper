"""Port of Source/AssetRipper.Processing/Scenes/SceneDefinitionProcessor.cs

Scoped down from the C# original, which needs generated interfaces this port doesn't have:

- Scene collections are identified by a best-effort, hard-coded set of "LevelGameManager"
  class IDs (`_LEVEL_GAME_MANAGER_CLASS_IDS`) instead of the generated `ILevelGameManager`
  marker interface (Unity's real class hierarchy isn't vendored here -- see
  assetripper_import/class_id_type.py's own docstring on abstract classes being removed).
  These are the well-known per-scene singleton managers that appear once per level file.
- Scene-path recovery from `IAssetBundle.SceneHashes`/`.Container` (used for scenes bundled
  into legacy .unity3d asset bundles rather than a player build) is not ported -- a real,
  if less common, source of scene names. Falls back to `SceneDefinition.from_name`, exactly
  like upstream's own fallback when path recovery fails.
- The "Generated Settings" ProcessedAssetCollection (EditorBuildSettings/EditorSettings) is
  not created: those are synthesized from scratch rather than read from existing data, which
  needs a "construct a valid instance to serialize" capability this port doesn't have yet
  (Phase 2's layouts only support reading bytes against a known shape). This only affects the
  Unity Editor's Build Settings window, not exported asset content.
- `IOcclusionCullingSettings.SceneGUID` recovery is skipped: converting the dynamically-read
  GUID sub-structure to a `UnityGuid` needs its exact sub-field names, which aren't known
  with confidence here. Every scene gets a fresh random GUID instead (`SceneDefinition`'s own
  fallback for a zero GUID) -- cosmetically different from upstream's recovered GUID, but
  not incorrect: nothing else in this port depends on a scene's GUID matching the original.
"""
from __future__ import annotations

import logging

from assetripper_import.class_id_type import ClassIDType
from assetripper_assets.collections.scene_definition import SceneDefinition

from ..i_asset_processor import IAssetProcessor
from . import scene_helpers

_logger = logging.getLogger(__name__)

_LEVEL_GAME_MANAGER_CLASS_IDS = frozenset(
    {
        ClassIDType.OcclusionCullingSettings,
        ClassIDType.RenderSettings,
        ClassIDType.LightmapSettings,
        ClassIDType.NavMeshSettings,
    }
)


class SceneDefinitionProcessor(IAssetProcessor):
    def process(self, game_data) -> None:
        _logger.info("Creating Scene Definitions")

        build_settings = None
        scene_collections: set = set()
        scene_paths: dict = {}

        for collection in game_data.game_bundle.fetch_asset_collections():
            for asset in collection:
                if asset.class_id in _LEVEL_GAME_MANAGER_CLASS_IDS:
                    scene_collections.add(collection)
                elif asset.class_id == ClassIDType.BuildSettings:
                    build_settings = asset

        for scene_collection in scene_collections:
            found, path = scene_helpers.try_get_scene_path(scene_collection, build_settings)
            if found:
                scene_paths[scene_collection] = path

        for scene_collection in scene_collections:
            path = scene_paths.get(scene_collection)
            if path is not None:
                scene_definition = SceneDefinition.from_path(path)
            else:
                scene_definition = SceneDefinition.from_name(scene_collection.name)
            scene_definition.add_collection(scene_collection)

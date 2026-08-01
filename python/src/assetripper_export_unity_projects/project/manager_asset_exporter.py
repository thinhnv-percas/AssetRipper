"""Port of Source/AssetRipper.Export.UnityProjects/Project/ManagerAssetExporter.cs

Upstream matches `asset is IGlobalGameManager or TypeTreeObject { IsPlayerSettings: true }`.
This port has no generated `IGlobalGameManager` marker interface (the same problem already
solved for per-scene managers in
`assetripper_processing/scenes/scene_definition_processor.py`'s `_LEVEL_GAME_MANAGER_CLASS_IDS`)
-- so `_GLOBAL_GAME_MANAGER_CLASS_IDS` below hard-codes the well-known, commonly-encountered
GlobalGameManager subclasses: the closest a shipped Unity player build gets to "everything in
globalgamemanagers/globalgamemanagers.assets that isn't dummy-exported or level-scoped".

Deliberately excluded (and therefore NOT routed here):
- The 4 `_LEVEL_GAME_MANAGER_CLASS_IDS` (OcclusionCullingSettings/RenderSettings/
  LightmapSettings/NavMeshSettings) -- per-scene, not global; handled by SceneYamlExporter.
- BuildSettings/PreloadData/AssetBundle/AssetBundleManifest/MonoManager/ResourceManager/
  ShaderNameRegistry -- upstream registers these with `OverrideDummyExporter` at higher
  priority than `ManagerAssetExporter`, so they never reach `ManagerExportCollection` even
  though they *are* `IGlobalGameManager`; see `dummy_asset_exporter.py` for where they go
  instead.
- EditorBuildSettings (class 1045) -- upstream special-cases it into
  `EditorBuildSettingsExportCollection` (not ported, see ROADMAP.md Phase 15: it needs a
  "Generated Settings" collection this port's `SceneDefinitionProcessor` doesn't create). An
  instance reaching this exporter would still land in a plain `ManagerExportCollection` --
  wrong only in that it skips scene-GUID patching on its `m_Scenes` list, a cosmetic detail
  nothing else in this port reads back. It practically never occurs anyway: EditorBuildSettings
  is an editor-only asset that shipped player builds don't embed.
- A long tail of obscure/legacy singleton managers real games essentially never ship
  (AnimationManager, NotificationManager, HaloManager, MasterServerInterface, UnityAdsManager,
  RuntimeInitializeOnLoadManager, CloudWebServicesManager, CloudServiceHandlerBehaviour,
  UnityAnalyticsManager, CrashReportManager, PerformanceReportingManager, NScreenBridge) --
  each tied to a deprecated or opt-in Unity subsystem (old Unity Ads/Analytics/Cloud Build
  integration, iOS local notifications, LAN master server networking). An instance of one of
  these falls through to DefaultYamlExporter (a stray `Assets/<ClassName>/*.asset`) instead of
  `ProjectSettings/` -- narrower than upstream, but documented rather than silently missing.

PlayerSettings itself (class 129) has no named entry in class_id_type.py at all -- see that
module's own docstring on abstract classes being removed upstream;
`TypeTreeObject.is_player_settings` hard-codes 129 directly, exactly mirroring upstream's
`TypeTreeObject.IsPlayerSettings`.
"""
from __future__ import annotations

from assetripper_import.asset_creation.type_tree_object import TypeTreeObject
from assetripper_import.class_id_type import ClassIDType

from .manager_export_collection import ManagerExportCollection
from .yaml_exporter_base import YamlExporterBase

_GLOBAL_GAME_MANAGER_CLASS_IDS = frozenset(
    {
        ClassIDType.TimeManager,
        ClassIDType.AudioManager,
        ClassIDType.InputManager,
        ClassIDType.Physics2DSettings,
        ClassIDType.GraphicsSettings,
        ClassIDType.QualitySettings,
        ClassIDType.PhysicsManager,
        ClassIDType.TagManager,
        ClassIDType.DelayedCallManager,
        ClassIDType.NavMeshProjectSettings,
        ClassIDType.NetworkManager,
        ClassIDType.ClusterInputManager,
        ClassIDType.UnityConnectSettings,
    }
)

# PlayerSettings has no ClassIDType entry (see module docstring), so it is routed by class ID
# directly rather than through `_GLOBAL_GAME_MANAGER_CLASS_IDS`.
_PLAYER_SETTINGS_CLASS_ID = 129


class ManagerAssetExporter(YamlExporterBase):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        is_player_settings = asset.class_id == _PLAYER_SETTINGS_CLASS_ID or (
            isinstance(asset, TypeTreeObject) and asset.is_player_settings
        )
        if is_player_settings or asset.class_id in _GLOBAL_GAME_MANAGER_CLASS_IDS:
            return True, ManagerExportCollection(self, asset)
        return False, None

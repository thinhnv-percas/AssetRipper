"""Port of Source/AssetRipper.Processing/Prefabs/PrefabProcessor.cs

Builds the `SceneHierarchyObject`/`PrefabHierarchyObject` marker assets that
`SceneExportCollection`/`PrefabExportCollection` (assetripper_export_unity_projects/
project/) group into one `.unity`/`.prefab` file per scene/prefab, instead of every
GameObject/Component exporting as its own loose `.asset` file.

Scoped down from upstream's `Process`, two branches:

- `AddMissingTransforms` (synthesizing a brand-new Transform component for a GameObject
  that somehow has none) is not ported: constructing a valid Transform from scratch needs
  the same "build a serializable instance with no source bytes" capability
  `SceneDefinitionProcessor` already declined for `EditorBuildSettings`/`EditorSettings`
  (see that module's docstring). A GameObject genuinely missing a Transform is rare/
  corrupt data in practice; skipping this means such a GameObject's descendants (if any --
  there can be none, since nothing can attach as its child without a Transform to attach
  to) may not get grouped into a hierarchy, and instead fall through to a loose per-asset
  YAML export -- a real, visible degradation for that edge case, not a silent one.
- The "prefabs with an existing PrefabInstance" branch is not ported: finding which
  GameObject a real `PrefabInstance` asset is the root of needs
  `IPrefabInstance.RootGameObjectP`, and this port doesn't have confirmed field-name
  knowledge for that relationship (unlike the fields `game_object_helpers.py` uses, which
  are all real, stable, and independently verifiable). A `PrefabInstance` already sitting
  inside a scene file is exported as part of that scene's `.unity` file either way (via
  `SceneHierarchyObject.create`'s direct class-ID bucketing), so the only real loss is: a
  `PrefabInstance` asset that exists standalone (not inside any scene) exports as a loose
  `.asset` instead of contributing to a synthesized `.prefab` grouping. The much more common
  case this phase targets -- loose GameObjects in an AssetBundle/Resources folder with no
  PrefabInstance at all -- is fully handled by the loop below.
"""
from __future__ import annotations

from assetripper_import.class_id_type import ClassIDType

from ..i_asset_processor import IAssetProcessor
from . import game_object_helpers
from .prefab_hierarchy_object import PrefabHierarchyObject, create_prefab_for_root
from .scene_hierarchy_object import SceneHierarchyObject

_GENERATED_HIERARCHY_BUNDLE_NAME = "Generated Hierarchy Assets"
_PREFAB_HIERARCHY_COLLECTION_NAME = "Prefab Hierarchies"
_GENERATED_PREFABS_COLLECTION_NAME = "Generated Prefabs"


class PrefabProcessor(IAssetProcessor):
    def process(self, game_data) -> None:
        processed_bundle = game_data.game_bundle.add_new_processed_bundle(_GENERATED_HIERARCHY_BUNDLE_NAME)
        prefab_hierarchy_collection = processed_bundle.add_new_processed_collection(
            _PREFAB_HIERARCHY_COLLECTION_NAME, game_data.project_version
        )
        prefab_instance_collection = processed_bundle.add_new_processed_collection(
            _GENERATED_PREFABS_COLLECTION_NAME, game_data.project_version
        )

        game_objects_already_processed: set = set()

        for scene in list(game_data.game_bundle.scenes):
            scene_collection = processed_bundle.add_new_processed_collection(
                f"{scene.name} (Generated Assets)", game_data.project_version
            )
            scene_hierarchy = SceneHierarchyObject.create(scene_collection, scene)
            game_objects_already_processed.update(scene_hierarchy.game_objects)

        for asset in game_data.game_bundle.fetch_assets():
            if asset.class_id != ClassIDType.GameObject or asset in game_objects_already_processed:
                continue

            root = game_object_helpers.get_root(asset)
            if root in game_objects_already_processed:
                continue
            game_objects_already_processed.add(root)

            prefab = create_prefab_for_root(root, prefab_instance_collection)
            prefab_hierarchy = PrefabHierarchyObject.create(prefab_hierarchy_collection, root, prefab)
            game_objects_already_processed.update(prefab_hierarchy.game_objects)

"""Port of Source/AssetRipper.Processing/Prefabs/SceneHierarchyObject.cs

`Create` differs from upstream's simple switch over every `scene.assets` item: upstream
pattern-matches on generated interfaces (`IGameObject`, `IComponent`, `ILevelGameManager`,
`IPrefabInstance`, `ISceneRoots`) this port doesn't have. Instead, root GameObjects (found
via `game_object_helpers.is_root`) are walked with `fetch_hierarchy` to collect every
GameObject/Component reachable from them -- a reimplementation of the algorithm that
produces the same grouping for any well-formed scene, without needing to classify "is this
class ID a component" (which isn't decidable from class ID alone in this port). Managers/
PrefabInstances/SceneRoots are still bucketed by class ID directly, since those don't need
a hierarchy walk to find.
"""
from __future__ import annotations

from assetripper_import.class_id_type import ClassIDType

from ..scenes.scene_definition_processor import _LEVEL_GAME_MANAGER_CLASS_IDS
from . import game_object_helpers
from .game_object_hierarchy_object import GameObjectHierarchyObject


class SceneHierarchyObject(GameObjectHierarchyObject):
    def __init__(self, asset_info, scene):
        super().__init__(asset_info)
        self.scene = scene
        self.managers: list = []
        self.scene_roots = None

    @property
    def name(self) -> str:
        return self.scene.name

    @property
    def assets(self):
        yield from super().assets
        yield from self.managers
        if self.scene_roots is not None:
            yield self.scene_roots

    def get_roots(self):
        return (game_object for game_object in self.game_objects if game_object_helpers.is_root(game_object))

    def fetch_dependencies(self):
        yield from super().fetch_dependencies()
        for asset in self.managers:
            yield "managers[]", self.collection.force_create_pptr(asset)
        yield "scene_roots", self.collection.force_create_pptr(self.scene_roots)

    @staticmethod
    def create(collection, scene) -> "SceneHierarchyObject":
        hierarchy = collection.create_asset(
            int(ClassIDType.SceneAsset), lambda asset_info: SceneHierarchyObject(asset_info, scene)
        )

        root_game_objects = []
        for asset in scene.assets:
            if asset.class_id == ClassIDType.GameObject:
                if game_object_helpers.is_root(asset):
                    root_game_objects.append(asset)
            elif asset.class_id == ClassIDType.PrefabInstance:
                hierarchy.prefab_instances.append(asset)
            elif asset.class_id == ClassIDType.SceneRoots:
                hierarchy.scene_roots = asset
            elif asset.class_id in _LEVEL_GAME_MANAGER_CLASS_IDS:
                hierarchy.managers.append(asset)

        for root in root_game_objects:
            for element in game_object_helpers.fetch_hierarchy(root):
                if element.class_id == ClassIDType.GameObject:
                    hierarchy.game_objects.append(element)
                else:
                    hierarchy.components.append(element)

        hierarchy.set_main_asset()
        return hierarchy

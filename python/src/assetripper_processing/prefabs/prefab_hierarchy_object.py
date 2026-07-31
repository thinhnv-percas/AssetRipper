"""Port of Source/AssetRipper.Processing/Prefabs/PrefabHierarchyObject.cs

`Root`/`Prefab` mirror upstream's fields exactly. `Prefab` is always hidden from YAML export
here (see synthetic_prefab_instance.py's module docstring for why -- this port doesn't
distinguish the pre-2018.3 "real Prefab asset in the file" case).
"""
from __future__ import annotations

from assetripper_import.class_id_type import ClassIDType

from . import game_object_helpers
from .game_object_hierarchy_object import GameObjectHierarchyObject
from .synthetic_prefab_instance import SyntheticPrefabInstance


class PrefabHierarchyObject(GameObjectHierarchyObject):
    def __init__(self, asset_info, root, prefab):
        super().__init__(asset_info)
        self.root = root
        self.prefab = prefab
        self.hidden_assets.add(prefab)

    @property
    def name(self) -> str:
        return self.root.get_best_name() if hasattr(self.root, "get_best_name") else getattr(self.root, "name", "")

    @property
    def assets(self):
        yield from super().assets
        yield self.prefab

    def fetch_dependencies(self):
        yield from super().fetch_dependencies()
        yield "prefab", self.collection.force_create_pptr(self.prefab)

    @staticmethod
    def create(collection, root, prefab) -> "PrefabHierarchyObject":
        hierarchy = collection.create_asset(
            int(ClassIDType.PrefabInstance), lambda asset_info: PrefabHierarchyObject(asset_info, root, prefab)
        )

        for element in game_object_helpers.fetch_hierarchy(root):
            if element.class_id == ClassIDType.GameObject:
                hierarchy.game_objects.append(element)
            else:
                hierarchy.components.append(element)

        hierarchy.set_main_asset()
        return hierarchy


def create_prefab_for_root(root, collection) -> SyntheticPrefabInstance:
    """Port of `GameObjectExtensions.CreatePrefabForRoot`, scoped to what this port's
    synthetic marker actually needs (see synthetic_prefab_instance.py): a stable identity
    plus the path-override info used to name the exported `.prefab` file."""
    prefab = collection.create_asset(
        int(ClassIDType.PrefabInstance), lambda asset_info: SyntheticPrefabInstance(asset_info, root)
    )
    prefab.asset_bundle_name = root.asset_bundle_name
    prefab.original_directory = root.original_directory
    prefab.original_name = root.original_name
    prefab.original_extension = root.original_extension
    prefab.override_directory = root.get_best_directory()
    prefab.override_name = root.get_best_name()
    prefab.override_extension = root.get_best_extension()
    return prefab

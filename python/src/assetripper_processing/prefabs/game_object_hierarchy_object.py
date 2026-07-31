"""Port of Source/AssetRipper.Processing/Prefabs/GameObjectHierarchyObject.cs

A marker asset -- never itself written to YAML -- that groups the GameObjects/Components/
PrefabInstances belonging to one exported `.prefab`/`.unity` file. `SceneExportCollection`/
`PrefabExportCollection` (assetripper_export_unity_projects/project/) read its `assets`/
`exportable_assets` to decide what goes in that one file; `ProjectExporter` finds it via
each real asset's `main_asset` (set by `set_main_asset()`) rather than by class ID, since
this port's class-ID-keyed exporter dispatch can't apply here (a `PrefabHierarchyObject`
reuses the real `PrefabInstance` class ID -- see its own module docstring).

Not ported: `StrippedAssets` -- upstream's own `PrefabProcessor.Process` never populates it
either (only test code does, see `AssetRipper.Tests/StrippedAssetTests.cs`), so it would be
a real port of something that's already a no-op in the actual pipeline. Skipped rather than
carried over as always-empty dead weight.
"""
from __future__ import annotations

from assetripper_assets.unity_object_base import UnityObjectBase


class GameObjectHierarchyObject(UnityObjectBase):
    def __init__(self, asset_info):
        super().__init__(asset_info)
        self.main_asset = self
        """Always itself -- port of `AssetGroup.MainAsset => this`. Distinct from
        `set_main_asset()`, which stamps *other* assets' `main_asset` to point here."""
        self.game_objects: list = []
        self.components: list = []
        self.prefab_instances: list = []
        self.hidden_assets: set = set()
        """Assets in `assets` that should not be part of the YAML export (e.g. the
        synthetic PrefabInstance marker -- see synthetic_prefab_instance.py)."""

    @property
    def assets(self):
        yield from self.game_objects
        yield from self.components
        yield from self.prefab_instances

    @property
    def exportable_assets(self):
        for asset in self.assets:
            if asset not in self.hidden_assets:
                yield asset

    def set_main_asset(self) -> None:
        for asset in self.assets:
            asset.main_asset = self

    def fetch_dependencies(self):
        for asset in self.game_objects:
            yield "game_objects[]", self.collection.force_create_pptr(asset)
        for asset in self.components:
            yield "components[]", self.collection.force_create_pptr(asset)
        for asset in self.prefab_instances:
            yield "prefab_instances[]", self.collection.force_create_pptr(asset)

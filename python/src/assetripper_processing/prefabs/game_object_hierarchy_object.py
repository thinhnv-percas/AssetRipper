"""Port of Source/AssetRipper.Processing/Prefabs/GameObjectHierarchyObject.cs

A marker asset -- never itself written to YAML -- that groups the GameObjects/Components/
PrefabInstances belonging to one exported `.prefab`/`.unity` file. `SceneExportCollection`/
`PrefabExportCollection` (assetripper_export_unity_projects/project/) read its `assets`/
`exportable_assets` to decide what goes in that one file; `ProjectExporter` finds it via
each real asset's `main_asset` (set by `set_main_asset()`) rather than by class ID, since
this port's class-ID-keyed exporter dispatch can't apply here (a `PrefabHierarchyObject`
reuses the real `PrefabInstance` class ID -- see its own module docstring).

`stripped_assets` (2026-08-03): ported. Nothing in this port *populates* it during a normal
export, matching upstream -- `PrefabProcessor.Process` never adds to `StrippedAssets` either,
only test code does. What is ported is the consumer side: `YamlWalker.export_yaml_document`
now honors it and emits the real Unity stripped-stub shape (see
assetripper_export_unity_projects/stripped_asset.py). That makes the shape verified against
upstream's own byte-exact expectations instead of merely absent, and gives a future producer
a working hook to plug into.
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
        self.stripped_assets: list = []
        """Assets this file references but does not own -- exported as `stripped` stubs
        carrying only the fields that identify where the real object lives. A list rather than
        a set because `UnityObjectBase` has no value-based hash and identity is what matters
        here; membership is checked by identity (see `stripped_asset.is_stripped`)."""
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

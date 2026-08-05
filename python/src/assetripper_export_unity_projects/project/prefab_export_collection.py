"""Port of Source/AssetRipper.Export.UnityProjects/Project/PrefabExportCollection.cs

Scoped to this port's modern-only prefab marker (see assetripper_processing/prefabs/
synthetic_prefab_instance.py): `EmitPrefabAsset`/the pre-2018.3 branch aren't ported, so this
always uses `PrefabImporter`, never `NativeFormatImporter`.
"""
from __future__ import annotations

from .assets_export_collection import AssetsExportCollection

_PREFAB_EXTENSION = "prefab"


class PrefabExportCollection(AssetsExportCollection):
    def __init__(self, asset_exporter, prefab_hierarchy_object):
        super().__init__(asset_exporter, prefab_hierarchy_object.prefab)
        self.root_game_object = prefab_hierarchy_object.root
        self.prefab = prefab_hierarchy_object.prefab
        self.hierarchy = prefab_hierarchy_object
        self.add_assets(prefab_hierarchy_object.assets)
        self.add_asset(prefab_hierarchy_object)

    def _get_export_extension(self, asset) -> str:
        return _PREFAB_EXTENSION

    @property
    def name(self) -> str:
        return self.root_game_object.get_best_name()

    @property
    def exportable_assets(self):
        for asset in self.hierarchy.exportable_assets:
            self._file = asset.collection
            yield asset

    def _create_importer(self, container):
        from .prefab_importer import PrefabImporter

        importer = PrefabImporter()
        if self.root_game_object.asset_bundle_name is not None:
            importer.asset_bundle_name = self.root_game_object.asset_bundle_name
        return importer

"""Port of Source/AssetRipper.Export.UnityProjects/Project/AssetsExportCollection.cs

A multi-asset-per-file `AssetExportCollection`: one designated `asset` (used for path
naming/importer purposes, same as the single-asset base) plus an arbitrary number of
additional assets sharing the same file, each with its own export ID. `PrefabExportCollection`
is the only subclass so far (scenes use `SceneExportCollection`, which doesn't reuse
directory/name-based path resolution at all -- see that module's docstring).
"""
from __future__ import annotations

from ..asset_export_collection import AssetExportCollection
from ..export_id_handler import get_pseudo_random_export_id


class AssetsExportCollection(AssetExportCollection):
    def __init__(self, asset_exporter, asset):
        super().__init__(asset_exporter, asset)
        self._file = asset.collection
        self._export_ids: dict = {}
        """asset_info -> (asset, export_id), in insertion order."""

    def add_asset(self, asset) -> bool:
        if asset is None or asset.asset_info == self.asset.asset_info:
            return False
        if asset.asset_info in self._export_ids:
            return False
        export_id = get_pseudo_random_export_id(asset, len(self._export_ids))
        self._export_ids[asset.asset_info] = (asset, export_id)
        return True

    def add_assets(self, assets) -> None:
        for asset in assets:
            self.add_asset(asset)

    def contains(self, asset) -> bool:
        return super().contains(asset) or asset.asset_info in self._export_ids

    def get_export_id(self, container, asset) -> int:
        if asset.asset_info == self.asset.asset_info:
            return super().get_export_id(container, asset)
        entry = self._export_ids.get(asset.asset_info)
        if entry is None:
            raise ValueError(f"{asset} is not part of this collection")
        return entry[1]

    def _export_inner(self, container, file_path: str, project_directory: str, file_system) -> bool:
        from ..asset_exporter import export_assets

        return export_assets(container, self.exportable_assets, file_path, file_system)

    @property
    def assets(self):
        # Mirrors upstream's `m_file = asset.Collection` side effect on each yield -- `file`
        # tracks whichever asset was most recently produced, since a scene/prefab's assets
        # can span multiple source collections and `ProjectAssetContainer.file` depends on
        # "the currently-being-processed asset's own collection" for relative-GUID logic.
        for asset in super().assets:
            self._file = asset.collection
            yield asset
        for asset, _export_id in self._export_ids.values():
            self._file = asset.collection
            yield asset

    @property
    def exportable_assets(self):
        return self.assets

    @property
    def file(self):
        return self._file

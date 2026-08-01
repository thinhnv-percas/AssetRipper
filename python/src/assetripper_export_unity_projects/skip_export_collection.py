"""Port of Source/AssetRipper.Export.UnityProjects/SkipExportCollection.cs

Unlike `EmptyExportCollection`, this claims to contain exactly one asset (so `contains()`
finds it and a pointer to it can be resolved) but still refuses to actually export it: any
pointer resolves to a missing reference (`meta_ptr.create_missing_reference`) instead of a
real asset. Used by `DummyAssetExporter`'s "not an empty collection" mode -- i.e. for asset
types where other assets are expected to reference them, and a broken-but-present pointer
is preferable to a crash.
"""
from __future__ import annotations

from .export_id_handler import get_main_export_id
from .i_export_collection import IExportCollection
from .meta_ptr import create_missing_reference


class SkipExportCollection(IExportCollection):
    def __init__(self, asset_exporter, asset):
        if asset_exporter is None:
            raise ValueError("asset_exporter must not be None")
        if asset is None:
            raise ValueError("asset must not be None")
        self.asset_exporter = asset_exporter
        self._asset = asset

    def export(self, container, project_directory: str, file_system) -> bool:
        raise NotImplementedError("SkipExportCollection does not support exporting")

    def contains(self, asset) -> bool:
        return asset.asset_info == self._asset.asset_info

    def get_export_id(self, container, asset) -> int:
        if asset.asset_info == self._asset.asset_info:
            return get_main_export_id(self._asset)
        raise ValueError(f"{asset} is not part of this collection")

    def create_export_pointer(self, container, asset, is_local: bool):
        if is_local:
            raise ValueError("is_local must be False for a SkipExportCollection pointer")
        asset_type = self.asset_exporter.to_export_type(asset)
        return create_missing_reference(self._asset.class_id, asset_type)

    @property
    def exportable(self) -> bool:
        return False

    @property
    def file(self):
        return self._asset.collection

    @property
    def flags(self):
        return self.file.flags

    @property
    def assets(self):
        return iter(())

    @property
    def name(self) -> str:
        return type(self._asset).__name__

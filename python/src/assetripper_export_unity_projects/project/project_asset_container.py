"""Port of Source/AssetRipper.Export.UnityProjects/ProjectAssetContainer.cs

Not ported: scene-related bookkeeping (`m_buildSettings`, `m_scenes`,
`ScenePathToGUID`/`IsSceneDuplicate`'s real logic) -- there is no SceneExportCollection yet
(Phase 5). `scene_path_to_guid` always returns a zero GUID and `is_scene_duplicate` always
returns False until then.
"""
from __future__ import annotations

from assetripper_primitives import UnityGuid

from ..export_id_handler import get_main_export_id
from ..i_export_container import IExportContainer
from ..meta_ptr import create_missing_reference


class ProjectAssetContainer(IExportContainer):
    def __init__(self, exporter, export_version, assets, collections):
        if exporter is None:
            raise ValueError("exporter must not be None")
        self._exporter = exporter
        self._export_version = export_version
        self.current_collection = None

        self._asset_collections: dict = {}
        for collection in collections:
            for asset in collection.assets:
                if asset.asset_info in self._asset_collections:
                    raise ValueError(f"Asset {asset} is already added by another collection")
                self._asset_collections[asset.asset_info] = collection

    def get_export_id(self, asset) -> int:
        collection = self._asset_collections.get(asset.asset_info)
        if collection is not None:
            return collection.get_export_id(self, asset)
        return get_main_export_id(asset)

    def to_export_type(self, type_: type):
        return self._exporter.to_export_type(type_)

    def create_export_pointer(self, asset):
        collection = self._asset_collections.get(asset.asset_info)
        if collection is not None:
            return collection.create_export_pointer(self, asset, collection is self.current_collection)
        from assetripper_io_files.asset_type import AssetType

        return create_missing_reference(asset.class_id, AssetType.META)

    def scene_path_to_guid(self, name: str) -> UnityGuid:
        return UnityGuid.ZERO

    def is_scene_duplicate(self, scene_id: int) -> bool:
        return False

    @property
    def file(self):
        return self.current_collection.file

    @property
    def export_version(self):
        return self._export_version

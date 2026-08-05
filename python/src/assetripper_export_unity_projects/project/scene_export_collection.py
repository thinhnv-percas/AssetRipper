"""Port of Source/AssetRipper.Export.UnityProjects/Project/SceneExportCollection.cs

Extends `ExportCollection` directly rather than the single-asset `AssetExportCollection`
base (unlike `PrefabExportCollection`): a scene's file path comes from `Scene.Path`, not
`get_best_directory()`/`get_best_name()`, so none of that base class's path-resolution
machinery applies.

Not ported: `IsSceneDuplicate`/duplicate-scene-name detection (`container.is_scene_duplicate`,
Source's `SceneHelpers.TryGetFileNameToSceneIndex`) -- this port's `IExportContainer`
(`ProjectAssetContainer`) already has `is_scene_duplicate` hardcoded to always return False
(see that module's docstring), so replicating the lookup here would just call an
always-False stub. Skipped rather than adding dead code; revisit together if either side
is ever implemented for real.
"""
from __future__ import annotations

from assetripper_assets.collections.serialized_asset_collection import SerializedAssetCollection
from assetripper_primitives import UnityGuid

from assetripper_processing.scenes.scene_definition_processor import _LEVEL_GAME_MANAGER_CLASS_IDS

from ..export_collection import ExportCollection
from ..export_id_handler import get_pseudo_random_value_32, get_pseudo_random_value_64
from ..meta_ptr import MetaPtr

_UNITY_EXTENSION = "unity"


def _sort_key(asset) -> tuple:
    # Managers sort before everything else (matches upstream's Compare: two managers keep
    # their relative order via class ID; anything vs. a non-manager is unordered, i.e.
    # stable -- Python's sort is stable, so a 2-tuple key reproduces that exactly).
    return (0 if asset.class_id in _LEVEL_GAME_MANAGER_CLASS_IDS else 1, asset.class_id)


class SceneExportCollection(ExportCollection):
    def __init__(self, asset_exporter, hierarchy):
        if asset_exporter is None:
            raise ValueError("asset_exporter must not be None")
        if hierarchy is None:
            raise ValueError("hierarchy must not be None")

        self.asset_exporter = asset_exporter
        self.hierarchy = hierarchy
        self._file = hierarchy.collection
        self._guid = UnityGuid.new_guid()
        self._export_ids: dict = {}

        for index, asset in enumerate(hierarchy.assets):
            if isinstance(asset.collection, SerializedAssetCollection):
                export_id = asset.path_id
            elif asset.collection.version.greater_than_or_equals(5, 5):
                export_id = get_pseudo_random_value_64(index)
            else:
                export_id = get_pseudo_random_value_32(index)
            self._export_ids[asset.asset_info] = export_id

        self._exportable_assets = sorted(hierarchy.exportable_assets, key=_sort_key)

    @property
    def scene(self):
        return self.hierarchy.scene

    @property
    def guid(self) -> UnityGuid:
        return self._guid

    def export(self, container, project_directory: str, file_system) -> bool:
        file_path = file_system.path.join(project_directory, f"{self.scene.path}.{_UNITY_EXTENSION}")
        folder_path = file_system.path.get_directory_name(file_path)
        file_system.directory.create(folder_path)
        return self._export_scene(container, file_path, file_system)

    def _export_scene(self, container, file_path: str, file_system) -> bool:
        from ..asset_exporter import export_assets
        from ..meta import Meta
        from .default_importer import DefaultImporter

        export_assets(container, self.exportable_assets, file_path, file_system)

        importer = DefaultImporter()
        if self.hierarchy.asset_bundle_name is not None:
            importer.asset_bundle_name = self.hierarchy.asset_bundle_name

        meta = Meta(self.guid, importer)
        self._export_meta(container, meta, file_path, file_system)
        return True

    def contains(self, asset) -> bool:
        return asset.asset_info in self._export_ids

    def get_export_id(self, container, asset) -> int:
        try:
            return self._export_ids[asset.asset_info]
        except KeyError:
            raise ValueError(f"{asset} is not part of this collection") from None

    def create_export_pointer(self, container, asset, is_local: bool) -> MetaPtr:
        export_id = self.get_export_id(container, asset)
        if is_local:
            return MetaPtr(export_id)
        from assetripper_io_files.asset_type import AssetType

        return MetaPtr(export_id, self.guid, AssetType.SERIALIZED)

    @property
    def assets(self):
        for asset in self.hierarchy.assets:
            self._file = asset.collection
            yield asset
        self._file = self.hierarchy.collection
        yield self.hierarchy

    @property
    def exportable_assets(self):
        for asset in self._exportable_assets:
            self._file = asset.collection
            yield asset

    @property
    def file(self):
        return self._file

    @property
    def name(self) -> str:
        return self.scene.name

"""Port of Source/AssetRipper.Export.UnityProjects/RawAssets/UnreadableExportCollection.cs"""
from __future__ import annotations

from assetripper_io_files.filesystem import MAX_FILE_NAME_LENGTH, fix_invalid_path_characters

from ..i_export_collection import IExportCollection
from ..meta_ptr import NULL_PTR


class UnreadableExportCollection(IExportCollection):
    def __init__(self, exporter, asset):
        self.asset_exporter = exporter
        self.asset = asset

    def create_export_pointer(self, container, asset, is_local: bool):
        return NULL_PTR

    def export(self, container, project_directory: str, file_system) -> bool:
        name = fix_invalid_path_characters(self.asset.name)
        resource_path = file_system.path.join(
            project_directory, "AssetRipper", "UnreadableAssets", self.asset.class_name, f"{name}.unreadable"
        )
        sub_path = file_system.path.get_directory_name(resource_path)
        file_system.directory.create(sub_path)
        res_file_name = file_system.path.get_file_name(resource_path)
        file_name = file_system.get_unique_name(sub_path, res_file_name, MAX_FILE_NAME_LENGTH)
        file_path = file_system.path.join(sub_path, file_name)
        return self.asset_exporter.export(container, self.asset, file_path, file_system)

    def get_export_id(self, container, asset) -> int:
        raise NotImplementedError("UnreadableExportCollection does not support export IDs")

    def contains(self, asset) -> bool:
        return asset.asset_info == self.asset.asset_info

    @property
    def file(self):
        return self.asset.collection

    @property
    def flags(self):
        return self.file.flags

    @property
    def assets(self):
        yield self.asset

    @property
    def name(self) -> str:
        return self.asset.name

"""Port of Source/AssetRipper.Export.UnityProjects/AssetExportCollection.cs

The common case: one asset, one `.asset` file, one `.meta` file, importer =
NativeFormatImporter. C#'s `AssetExportCollection<T>` is generic purely for compile-time
typing of `Asset`; there's nothing to preserve here.
"""
from __future__ import annotations

from assetripper_io_files.filesystem import fix_invalid_path_characters
from assetripper_primitives import UnityGuid

from .export_collection import ExportCollection
from .export_id_handler import get_main_export_id
from .meta_ptr import MetaPtr


class AssetExportCollection(ExportCollection):
    def __init__(self, asset_exporter, asset):
        if asset_exporter is None:
            raise ValueError("asset_exporter must not be None")
        if asset is None:
            raise ValueError("asset must not be None")
        self.asset_exporter = asset_exporter
        self.asset = asset
        self._guid = UnityGuid.new_guid()

    @property
    def guid(self) -> UnityGuid:
        return self._guid

    def export(self, container, project_directory: str, file_system) -> bool:
        sub_path = file_system.path.join(project_directory, fix_invalid_path_characters(self.asset.get_best_directory()))
        file_name = self._get_unique_file_name(self.asset, sub_path, file_system)

        file_system.directory.create(sub_path)

        file_path = file_system.path.join(sub_path, file_name)
        if not self._export_inner(container, file_path, project_directory, file_system):
            return False

        importer = self._create_importer(container)
        from .meta import Meta

        meta = Meta(self.guid, importer)
        self._export_meta(container, meta, file_path, file_system)
        return True

    def contains(self, asset) -> bool:
        return self.asset.asset_info == asset.asset_info

    def get_export_id(self, container, asset) -> int:
        if asset.asset_info == self.asset.asset_info:
            return get_main_export_id(self.asset)
        raise ValueError(f"{asset} is not part of this collection")

    def create_export_pointer(self, container, asset, is_local: bool) -> MetaPtr:
        export_id = self.get_export_id(container, asset)
        if is_local:
            return MetaPtr(export_id)
        return MetaPtr(export_id, self.guid, self.asset_exporter.to_export_type(self.asset))

    def _export_inner(self, container, file_path: str, project_directory: str, file_system) -> bool:
        return self.asset_exporter.export(container, self.asset, file_path, file_system)

    def _create_importer(self, container):
        from .project.native_format_importer import NativeFormatImporter

        importer = NativeFormatImporter()
        importer.main_object_file_id = self.get_export_id(container, self.asset)
        if importer.has_asset_bundle_name() and self.asset.asset_bundle_name is not None:
            importer.asset_bundle_name = self.asset.asset_bundle_name
        return importer

    @property
    def file(self):
        return self.asset.collection

    @property
    def assets(self):
        yield self.asset

    @property
    def name(self) -> str:
        return self.asset.get_best_name()

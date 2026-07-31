"""Port of Source/AssetRipper.Export.UnityProjects/IAssetExporter.cs

C#'s multi-asset-per-file overload (`Export(container, IEnumerable<asset>, ...)`) isn't
part of this interface here -- it's `asset_exporter.export_assets`, a free function called
directly by the multi-asset export collections (project/scene_export_collection.py,
project/assets_export_collection.py) rather than an `IAssetExporter` method, since no
exporter other than the scene/prefab machinery needs it.
"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IAssetExporter(ABC):
    @abstractmethod
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        """Returns (True, IExportCollection) if this exporter handles `asset`, else
        (False, None)."""
        ...

    def export(self, container, asset, path: str, file_system) -> bool:
        raise NotImplementedError

    @abstractmethod
    def to_export_type(self, asset):
        """Returns an assetripper_io_files.asset_type.AssetType."""
        ...

    @abstractmethod
    def to_unknown_export_type(self, type_: type) -> "tuple[bool, object]":
        """Returns (True, AssetType) if this exporter knows the export type for the given
        Python type, else (False, None)."""
        ...

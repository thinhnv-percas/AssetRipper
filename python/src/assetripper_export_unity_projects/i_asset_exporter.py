"""Port of Source/AssetRipper.Export.UnityProjects/IAssetExporter.cs

C#'s multi-asset-per-file overloads (`Export(container, IEnumerable<asset>, ...)`) are not
ported -- see asset_exporter.py's module docstring for why.
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

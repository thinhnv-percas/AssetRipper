"""Port of Source/AssetRipper.Export.UnityProjects/IExportContainer.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IExportContainer(ABC):
    @abstractmethod
    def get_export_id(self, asset) -> int: ...

    @abstractmethod
    def to_export_type(self, type_: type):
        """Returns an assetripper_io_files.asset_type.AssetType."""
        ...

    @abstractmethod
    def create_export_pointer(self, asset):
        """Returns a MetaPtr."""
        ...

    @abstractmethod
    def scene_path_to_guid(self, name: str):
        """Returns a UnityGuid."""
        ...

    @abstractmethod
    def is_scene_duplicate(self, scene_id: int) -> bool: ...

    @property
    @abstractmethod
    def file(self):
        """The AssetCollection currently being exported."""
        ...

    @property
    @abstractmethod
    def export_version(self):
        """A UnityVersion."""
        ...

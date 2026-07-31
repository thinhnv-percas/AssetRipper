"""Port of Source/AssetRipper.Export.UnityProjects/IExportCollection.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod

from assetripper_io_files.serialized_files.transfer_instruction_flags import TransferInstructionFlags


class IExportCollection(ABC):
    @abstractmethod
    def export(self, container, project_directory: str, file_system) -> bool: ...

    @abstractmethod
    def contains(self, asset) -> bool: ...

    @abstractmethod
    def get_export_id(self, container, asset) -> int: ...

    @abstractmethod
    def create_export_pointer(self, container, asset, is_local: bool):
        """Returns a MetaPtr."""
        ...

    @property
    @abstractmethod
    def file(self):
        """The AssetCollection this IExportCollection was built from."""
        ...

    @property
    def flags(self) -> TransferInstructionFlags:
        return TransferInstructionFlags.NO_TRANSFER_INSTRUCTION_FLAGS

    @property
    @abstractmethod
    def assets(self):
        """Iterable of IUnityObjectBase."""
        ...

    @property
    def exportable_assets(self):
        return self.assets

    @property
    def exportable(self) -> bool:
        return True

    @property
    @abstractmethod
    def name(self) -> str: ...

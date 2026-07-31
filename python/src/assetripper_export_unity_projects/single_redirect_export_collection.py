"""Port of Source/AssetRipper.Export.UnityProjects/SingleRedirectExportCollection.cs

A collection that redirects a single asset to an already-known MetaPtr, without
exporting anything itself -- used when the real content was (or will be) written by a
different collection and this asset just needs to resolve references to it.
"""
from __future__ import annotations

from assetripper_io_files.serialized_files.transfer_instruction_flags import TransferInstructionFlags

from .i_export_collection import IExportCollection


class SingleRedirectExportCollection(IExportCollection):
    def __init__(self, asset, pointer):
        self.asset = asset
        self.pointer = pointer

    @property
    def file(self):
        return self.asset.collection

    @property
    def flags(self) -> TransferInstructionFlags:
        return self.asset.collection.flags

    @property
    def assets(self):
        yield self.asset

    @property
    def name(self) -> str:
        return self.asset.get_best_name()

    @property
    def exportable(self) -> bool:
        return False

    def contains(self, asset) -> bool:
        return asset is self.asset

    def create_export_pointer(self, container, asset, is_local: bool):
        if is_local:
            raise NotImplementedError
        self._throw_if_not_asset(asset)
        return self.pointer

    def export(self, container, project_directory: str, file_system) -> bool:
        raise NotImplementedError

    def get_export_id(self, container, asset) -> int:
        self._throw_if_not_asset(asset)
        return self.pointer.file_id

    def _throw_if_not_asset(self, asset) -> None:
        if asset is not self.asset:
            raise ValueError("The asset must be the same one referenced in this collection.")

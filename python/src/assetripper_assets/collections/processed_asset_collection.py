"""Port of Source/AssetRipper.Assets/Collections/ProcessedAssetCollection.cs

A collection of artificial assets generated during asset processing.
"""
from __future__ import annotations

from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files.transfer_instruction_flags import TransferInstructionFlags
from assetripper_primitives import UnityVersion

from ..metadata.asset_info import AssetInfo
from .virtual_asset_collection import VirtualAssetCollection


class ProcessedAssetCollection(VirtualAssetCollection):
    def __init__(self, bundle):
        super().__init__(bundle)
        self._next_id = 0

    def set_layout(self, version: UnityVersion, platform: BuildTarget = BuildTarget.NO_TARGET, flags: TransferInstructionFlags = TransferInstructionFlags.NO_TRANSFER_INSTRUCTION_FLAGS) -> None:
        self.version = version
        self.original_version = version
        self.platform = platform
        self.flags = flags

    def create_asset(self, class_id: int, factory, data=None):
        """Port of both `CreateAsset<T>(classID, factory)` and
        `CreateAsset<TData, TAsset>(classID, data, factory)` -- pass `data` to use the
        two-argument factory form."""
        asset_info = self._create_asset_info(class_id)
        asset = factory(asset_info) if data is None else factory(asset_info, data)
        self.add_asset(asset)
        return asset

    def _create_asset_info(self, class_id: int) -> AssetInfo:
        self._next_id += 1
        return AssetInfo(self, self._next_id, class_id)

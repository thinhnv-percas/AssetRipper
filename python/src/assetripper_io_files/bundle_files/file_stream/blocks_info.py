"""Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/BlocksInfo.cs"""
from __future__ import annotations

from dataclasses import dataclass, field

from ..hash128 import Hash128
from .storage_block import StorageBlock


@dataclass(slots=True)
class BlocksInfo:
    uncompressed_data_hash: Hash128 = field(default_factory=Hash128)
    storage_blocks: list[StorageBlock] = field(default_factory=list)

    @staticmethod
    def read(reader) -> "BlocksInfo":
        uncompressed_data_hash = Hash128.read(reader)
        count = reader.read_int32()
        storage_blocks = [StorageBlock.read(reader) for _ in range(count)]
        return BlocksInfo(uncompressed_data_hash, storage_blocks)

    def write(self, writer) -> None:
        self.uncompressed_data_hash.write(writer)
        writer.write_int32(len(self.storage_blocks))
        for block in self.storage_blocks:
            block.write(writer)

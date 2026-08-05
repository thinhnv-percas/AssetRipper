"""Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/StorageBlock.cs

Contains compression information about a block. Blocks are similar to a chunk
structure in that they contain a data blob but without file entries.
"""
from __future__ import annotations

from dataclasses import dataclass

from ..compression_type import CompressionType
from .storage_block_flags import StorageBlockFlags, get_compression_type


@dataclass(slots=True)
class StorageBlock:
    uncompressed_size: int = 0
    compressed_size: int = 0
    flags: StorageBlockFlags = StorageBlockFlags(0)

    @property
    def compression_type(self) -> CompressionType:
        return get_compression_type(self.flags)

    @staticmethod
    def read(reader) -> "StorageBlock":
        return StorageBlock(
            uncompressed_size=reader.read_uint32(),
            compressed_size=reader.read_uint32(),
            flags=StorageBlockFlags(reader.read_uint16()),
        )

    def write(self, writer) -> None:
        writer.write_uint32(self.uncompressed_size)
        writer.write_uint32(self.compressed_size)
        writer.write_uint16(int(self.flags))

"""Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/FileStreamBundleHeader.cs"""
from __future__ import annotations

from ..bundle_flags import BundleFlags, get_compression
from ..bundle_header import BundleHeader
from ..compression_type import CompressionType

_UNITY_FS_MAGIC = "UnityFS"


class FileStreamBundleHeader(BundleHeader):
    def __init__(self):
        super().__init__()
        self.size: int = 0
        """Equal to file size, sometimes equal to uncompressed data size without the header."""
        self.compressed_blocks_info_size: int = 0
        self.uncompressed_blocks_info_size: int = 0
        self.flags: BundleFlags = BundleFlags.NONE

    @property
    def _magic_string(self) -> str:
        return _UNITY_FS_MAGIC

    @property
    def compression_type(self) -> CompressionType:
        return get_compression(self.flags)

    @compression_type.setter
    def compression_type(self, value: CompressionType) -> None:
        self.flags = (self.flags & ~BundleFlags.COMPRESSION_TYPE_MASK) | (BundleFlags.COMPRESSION_TYPE_MASK & BundleFlags(value))

    def read(self, reader) -> None:
        super().read(reader)
        self.size = reader.read_int64()
        self.compressed_blocks_info_size = reader.read_int32()
        self.uncompressed_blocks_info_size = reader.read_int32()
        self.flags = BundleFlags(reader.read_int32())

    def write(self, writer) -> None:
        super().write(writer)
        writer.write_int64(self.size)
        writer.write_int32(self.compressed_blocks_info_size)
        writer.write_int32(self.uncompressed_blocks_info_size)
        writer.write_int32(int(self.flags))

    @staticmethod
    def is_bundle_header(reader) -> bool:
        return BundleHeader._is_bundle_header_signature(reader, _UNITY_FS_MAGIC)

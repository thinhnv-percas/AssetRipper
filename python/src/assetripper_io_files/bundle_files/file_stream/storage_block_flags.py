"""Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/StorageBlockFlags.cs"""
from __future__ import annotations

from enum import IntFlag

from ..compression_type import CompressionType


class StorageBlockFlags(IntFlag):
    COMPRESSION_TYPE_MASK = 0x3F
    STREAMED = 0x40


def get_compression_type(flags: StorageBlockFlags) -> "CompressionType | int":
    """Unlike a C# enum cast (which never throws, even for undefined values), Python's
    `IntEnum(...)` raises for a masked value outside {0..4}. Real Unity bundles use exactly
    that kind of undefined value for Zstd-compressed blocks (Unity added Zstd support after
    this enum was last extended, so it has no named member here -- see zstd_compression.py),
    so an unrecognized value is returned as a plain int instead of raising: it simply
    compares unequal to every named `CompressionType`, which is exactly what
    `bundle_file_block_reader.decompress_blocks` needs to fall through to its Zstd sniff."""
    value = int(flags) & int(StorageBlockFlags.COMPRESSION_TYPE_MASK)
    try:
        return CompressionType(value)
    except ValueError:
        return value


def is_streamed(flags: StorageBlockFlags) -> bool:
    return bool(flags & StorageBlockFlags.STREAMED)


def with_compression_type(flags: StorageBlockFlags, compression_type: CompressionType) -> StorageBlockFlags:
    return (flags & ~StorageBlockFlags.COMPRESSION_TYPE_MASK) | StorageBlockFlags(int(compression_type))

"""Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/StorageBlockFlags.cs"""
from __future__ import annotations

from enum import IntFlag

from ..compression_type import CompressionType


class StorageBlockFlags(IntFlag):
    COMPRESSION_TYPE_MASK = 0x3F
    STREAMED = 0x40


def get_compression_type(flags: StorageBlockFlags) -> CompressionType:
    return CompressionType(int(flags) & int(StorageBlockFlags.COMPRESSION_TYPE_MASK))


def is_streamed(flags: StorageBlockFlags) -> bool:
    return bool(flags & StorageBlockFlags.STREAMED)


def with_compression_type(flags: StorageBlockFlags, compression_type: CompressionType) -> StorageBlockFlags:
    return (flags & ~StorageBlockFlags.COMPRESSION_TYPE_MASK) | StorageBlockFlags(int(compression_type))

"""Port of Source/AssetRipper.IO.Files/BundleFiles/BundleFlags.cs"""
from __future__ import annotations

from enum import IntFlag

from .compression_type import CompressionType


class BundleFlags(IntFlag):
    NONE = 0

    COMPRESSION_BIT_1 = 0x1
    COMPRESSION_BIT_2 = 0x2
    COMPRESSION_BIT_3 = 0x4
    COMPRESSION_BIT_4 = 0x8
    COMPRESSION_BIT_5 = 0x10
    COMPRESSION_BIT_6 = 0x20
    COMPRESSION_TYPE_MASK = 0x3F

    BLOCKS_AND_DIRECTORY_INFO_COMBINED = 0x40
    BLOCKS_INFO_AT_THE_END = 0x80
    OLD_WEB_PLUGIN_COMPATIBILITY = 0x100
    BLOCK_INFO_NEED_PADDING_AT_START = 0x200
    """Padding is added after blocks info, so files within asset bundles start on
    aligned boundaries. Introduced in 2020.3.34f1, 2021.3.2f1, 2022.1.1f1."""
    ENCRYPTION_OLD = 0x200
    """Chinese encryption flag prior to 2020.3.34f1, 2021.3.2f1, 2022.1.1f1."""
    ENCRYPTION_NEW = 0x400
    """Chinese encryption flag (presumably) after 2020.3.34f1, 2021.3.2f1, 2022.1.1f1."""


def get_compression(flags: BundleFlags) -> CompressionType:
    """The lowest 6 bits."""
    return CompressionType(int(flags) & int(BundleFlags.COMPRESSION_TYPE_MASK))


def get_blocks_and_directory_info_combined(flags: BundleFlags) -> bool:
    return bool(flags & BundleFlags.BLOCKS_AND_DIRECTORY_INFO_COMBINED)


def get_blocks_info_at_the_end(flags: BundleFlags) -> bool:
    return bool(flags & BundleFlags.BLOCKS_INFO_AT_THE_END)


def get_old_web_plugin_compatibility(flags: BundleFlags) -> bool:
    return bool(flags & BundleFlags.OLD_WEB_PLUGIN_COMPATIBILITY)


def get_block_info_need_padding_at_start(flags: BundleFlags) -> bool:
    return bool(flags & BundleFlags.BLOCK_INFO_NEED_PADDING_AT_START)

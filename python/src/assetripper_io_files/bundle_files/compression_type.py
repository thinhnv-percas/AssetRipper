"""Port of Source/AssetRipper.IO.Files/BundleFiles/CompressionType.cs"""
from __future__ import annotations

from enum import IntEnum


class CompressionType(IntEnum):
    NONE = 0
    LZMA = 1
    LZ4 = 2
    LZ4_HC = 3
    LZHAM = 4

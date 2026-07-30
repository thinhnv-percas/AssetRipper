"""Port of AssetRipper.IO.Endian.EndianType (external NuGet dependency)."""
from __future__ import annotations

from enum import Enum


class EndianType(Enum):
    BIG_ENDIAN = "big"
    LITTLE_ENDIAN = "little"

"""Port of Source/AssetRipper.Yaml/ScalarType.cs"""
from __future__ import annotations

from enum import Enum, auto


class ScalarType(Enum):
    BOOLEAN = auto()
    BYTE = auto()
    SBYTE = auto()
    UINT16 = auto()
    INT16 = auto()
    UINT32 = auto()
    INT32 = auto()
    UINT64 = auto()
    INT64 = auto()
    SINGLE = auto()
    DOUBLE = auto()
    STRING = auto()

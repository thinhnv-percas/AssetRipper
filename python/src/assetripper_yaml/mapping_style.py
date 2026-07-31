"""Port of Source/AssetRipper.Yaml/MappingStyle.cs"""
from __future__ import annotations

from enum import Enum, auto


class MappingStyle(Enum):
    BLOCK = auto()
    FLOW = auto()

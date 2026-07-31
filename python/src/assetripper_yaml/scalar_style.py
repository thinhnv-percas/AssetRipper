"""Port of Source/AssetRipper.Yaml/ScalarStyle.cs"""
from __future__ import annotations

from enum import Enum, auto


class ScalarStyle(Enum):
    PLAIN = auto()
    SINGLE_QUOTED = auto()
    DOUBLE_QUOTED = auto()

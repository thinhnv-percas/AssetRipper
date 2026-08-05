"""Port of Source/AssetRipper.Export/Configuration/TextExportMode.cs"""
from __future__ import annotations

from enum import IntEnum


class TextExportMode(IntEnum):
    BYTES = 0
    TXT = 1
    PARSE = 2

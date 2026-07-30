"""Port of Source/AssetRipper.IO.Files/Streams/Smart/SmartStreamType.cs"""
from __future__ import annotations

from enum import Enum, auto


class SmartStreamType(Enum):
    """The type of stream backing a SmartStream."""

    NULL = auto()
    """Not backed by a Stream."""
    FILE = auto()
    """Backed by a FileStream or MultiFileStream."""
    MEMORY = auto()
    """Backed by a MemoryStream."""

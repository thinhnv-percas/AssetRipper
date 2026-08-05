"""Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/NodeFlags.cs"""
from __future__ import annotations

from enum import IntFlag


class NodeFlags(IntFlag):
    DEFAULT = 0
    DIRECTORY = 1
    DELETED = 2
    SERIALIZED_FILE = 4

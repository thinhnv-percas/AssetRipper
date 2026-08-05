"""Port of Source/AssetRipper.IO.Files/AssetType.cs"""
from __future__ import annotations

from enum import IntEnum


class AssetType(IntEnum):
    INTERNAL = 0
    """Used by released game."""
    CACHED = 1
    """Library asset file. Editor-created; doesn't exist in the Assets directory.
    Has the format "library/cache/[first Hash byte as hex]/[Hash as hex]"."""
    SERIALIZED = 2
    """Serialized asset file. It contains all parameters inside itself."""
    META = 3
    """Binary asset file. It contains all parameters inside the meta file.
    On Unity 3, this is only used for 3D models; images and audio use CACHED instead."""

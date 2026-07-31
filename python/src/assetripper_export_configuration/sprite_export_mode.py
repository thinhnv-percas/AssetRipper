"""Port of Source/AssetRipper.Export/Configuration/SpriteExportMode.cs

Declared for API completeness but not yet consumed anywhere: there is no Sprite exporter
in this port yet (see python/ROADMAP.md Phase 13)."""
from __future__ import annotations

from enum import IntEnum


class SpriteExportMode(IntEnum):
    YAML = 0
    NATIVE = 1
    TEXTURE_2D = 2

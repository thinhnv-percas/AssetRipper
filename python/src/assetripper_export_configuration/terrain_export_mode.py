"""Port of Source/AssetRipper.Export/Configuration/TerrainExportMode.cs

Declared for API completeness but not yet consumed anywhere: there is no Terrain exporter
in this port yet (see python/ROADMAP.md Phase 13)."""
from __future__ import annotations

from enum import IntEnum


class TerrainExportMode(IntEnum):
    YAML = 0
    MESH = 1
    HEATMAP = 2

"""Port of Source/AssetRipper.Import/Configuration/ScriptContentLevel.cs

Declared for API completeness but not consumed anywhere: this port's `assembly_manager` is
always `None` (see assetripper_import/structure/game_structure.py's module docstring), so
behavior is always equivalent to upstream's `Level0` regardless of this setting's value.
"""
from __future__ import annotations

from enum import IntEnum


class ScriptContentLevel(IntEnum):
    LEVEL_0 = 0
    LEVEL_1 = 1
    LEVEL_2 = 2
    LEVEL_3 = 3

"""Port of Source/AssetRipper.Import/Configuration/ScriptContentLevel.cs

Since Phase 16f, `GameStructure`/`GameStructure.load` consult this (as a plain int, passed
through `ExportHandler.load`'s `settings.import_settings.script_content_level`): `LEVEL_0`
disables Mono script recovery entirely (`assembly_manager` stays `None` even if `.dll` files
were found); any other value attempts recovery. `LEVEL_1` ("stub method bodies") and
`LEVEL_2` ("default") are not distinguished -- this port's recovery is single-tier
(declaration + real field layout, never method bodies, see ROADMAP.md Phase 16g), so both
behave like `LEVEL_2`. IL2CPP is unaffected either way (16d/16e not implemented).
"""
from __future__ import annotations

from enum import IntEnum


class ScriptContentLevel(IntEnum):
    LEVEL_0 = 0
    LEVEL_1 = 1
    LEVEL_2 = 2
    LEVEL_3 = 3

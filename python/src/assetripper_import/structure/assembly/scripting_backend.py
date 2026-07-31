"""Port of Source/AssetRipper.Import/Structure/Assembly/ScriptingBackend.cs"""
from __future__ import annotations

from enum import IntEnum


class ScriptingBackend(IntEnum):
    UNKNOWN = 0
    MONO = 1
    IL2CPP = 2

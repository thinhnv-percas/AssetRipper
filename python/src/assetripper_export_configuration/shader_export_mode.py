"""Port of Source/AssetRipper.Export/Configuration/ShaderExportMode.cs

`Decompile` isn't implemented upstream either (see shaders/dummy_shader_text_exporter.py's
module docstring), so registration.py treats it the same as `Dummy`."""
from __future__ import annotations

from enum import IntEnum


class ShaderExportMode(IntEnum):
    DUMMY = 0
    YAML = 1
    DECOMPILE = 2

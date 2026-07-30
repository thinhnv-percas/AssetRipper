"""Port of Source/AssetRipper.Numerics/Vector2i.cs"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass(frozen=True, slots=True)
class Vector2i:
    X: int = 0
    Y: int = 0

    def __str__(self) -> str:
        return f"[{self.X}, {self.Y}]"

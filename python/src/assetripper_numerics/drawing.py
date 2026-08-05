"""Minimal shim for the small slice of System.Drawing that AssetRipper.Numerics touches."""
from __future__ import annotations

from dataclasses import dataclass

from ._vecmath import Vector2


@dataclass(frozen=True, slots=True)
class SizeF:
    width: float
    height: float

    def to_vector2(self) -> Vector2:
        return Vector2(self.width, self.height)


@dataclass(frozen=True, slots=True)
class RectangleF:
    x: float
    y: float
    width: float
    height: float

    @property
    def size(self) -> SizeF:
        return SizeF(self.width, self.height)


@dataclass(frozen=True, slots=True)
class Color:
    r: int
    g: int
    b: int
    a: int

    @staticmethod
    def from_argb(argb: int) -> "Color":
        argb &= 0xFFFFFFFF
        return Color(
            r=(argb >> 16) & 0xFF,
            g=(argb >> 8) & 0xFF,
            b=argb & 0xFF,
            a=(argb >> 24) & 0xFF,
        )

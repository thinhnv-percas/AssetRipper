"""Port of Source/AssetRipper.Numerics/ColorFloat.cs"""
from __future__ import annotations

from dataclasses import dataclass

from ._vecmath import Vector4


@dataclass(frozen=True, slots=True)
class ColorFloat:
    vector: Vector4

    def __init__(self, r: float | Vector4, g: float | None = None, b: float | None = None, a: float | None = None):
        if isinstance(r, Vector4):
            object.__setattr__(self, "vector", r)
        else:
            object.__setattr__(self, "vector", Vector4(r, g, b, a))

    @property
    def R(self) -> float:
        return self.vector.X

    @property
    def G(self) -> float:
        return self.vector.Y

    @property
    def B(self) -> float:
        return self.vector.Z

    @property
    def A(self) -> float:
        return self.vector.W

    def clamp(self) -> "ColorFloat":
        return ColorFloat(
            min(max(self.R, 0.0), 1.0),
            min(max(self.G, 0.0), 1.0),
            min(max(self.B, 0.0), 1.0),
            min(max(self.A, 0.0), 1.0),
        )

    def __add__(self, other: "ColorFloat") -> "ColorFloat":
        return ColorFloat(self.vector + other.vector)

    def __sub__(self, other: "ColorFloat") -> "ColorFloat":
        return ColorFloat(self.vector - other.vector)

    def __mul__(self, scalar: float) -> "ColorFloat":
        return ColorFloat(self.vector * scalar)

    __rmul__ = __mul__

    def __truediv__(self, scalar: float) -> "ColorFloat":
        return ColorFloat(self.vector / scalar)

    @staticmethod
    def black() -> "ColorFloat":
        return ColorFloat(0.0, 0.0, 0.0, 1.0)

    @staticmethod
    def white() -> "ColorFloat":
        return ColorFloat(1.0, 1.0, 1.0, 1.0)

    def __str__(self) -> str:
        return f"[R:{self.R:0.2f} G:{self.G:0.2f} B:{self.B:0.2f} A:{self.A:0.2f}]"

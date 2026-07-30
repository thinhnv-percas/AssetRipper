"""Port of Source/AssetRipper.Numerics/Color32.cs"""
from __future__ import annotations

from dataclasses import dataclass

from .color_float import ColorFloat
from .drawing import Color

_BYTE_MAX_VALUE = 255.0


@dataclass(frozen=True, slots=True)
class Color32:
    R: int
    G: int
    B: int
    A: int

    @property
    def rgba(self) -> int:
        """Reinterprets the R,G,B,A bytes (in that memory order) as a little-endian uint32."""
        return (self.R & 0xFF) | ((self.G & 0xFF) << 8) | ((self.B & 0xFF) << 16) | ((self.A & 0xFF) << 24)

    @staticmethod
    def from_rgba(rgba: int) -> "Color32":
        rgba &= 0xFFFFFFFF
        return Color32(
            R=rgba & 0xFF,
            G=(rgba >> 8) & 0xFF,
            B=(rgba >> 16) & 0xFF,
            A=(rgba >> 24) & 0xFF,
        )

    def to_color_float(self) -> ColorFloat:
        return ColorFloat(
            self.R / _BYTE_MAX_VALUE,
            self.G / _BYTE_MAX_VALUE,
            self.B / _BYTE_MAX_VALUE,
            self.A / _BYTE_MAX_VALUE,
        )

    @staticmethod
    def from_color_float(color: ColorFloat) -> "Color32":
        return Color32(
            _convert_float_to_byte(color.R),
            _convert_float_to_byte(color.G),
            _convert_float_to_byte(color.B),
            _convert_float_to_byte(color.A),
        )

    def to_system_color(self) -> Color:
        argb = (self.A << 24) | (self.R << 16) | (self.G << 8) | self.B
        return Color.from_argb(argb)

    @staticmethod
    def black() -> "Color32":
        return Color32(0, 0, 0, 255)

    @staticmethod
    def white() -> "Color32":
        return Color32(255, 255, 255, 255)

    def __str__(self) -> str:
        return f"[R:{self.R} G:{self.G} B:{self.B} A:{self.A}]"


def _convert_float_to_byte(value: float) -> int:
    if value != value:  # NaN check without importing math
        return 0
    scaled_value = value * 255.0
    if scaled_value <= 0:
        return 0
    elif scaled_value >= 255.0:
        return 255
    else:
        return int(scaled_value)

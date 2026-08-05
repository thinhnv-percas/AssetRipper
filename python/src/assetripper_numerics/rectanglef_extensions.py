"""Port of Source/AssetRipper.Numerics/RectangleFExtensions.cs"""
from __future__ import annotations

from ._vecmath import Vector2
from .drawing import RectangleF


def size(rectangle: RectangleF) -> Vector2:
    return rectangle.size.to_vector2()

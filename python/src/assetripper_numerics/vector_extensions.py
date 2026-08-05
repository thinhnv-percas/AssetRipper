"""Port of Source/AssetRipper.Numerics/VectorExtensions.cs"""
from __future__ import annotations

from ._vecmath import Vector3


def invert_x(vector: Vector3) -> Vector3:
    return Vector3(-vector.X, vector.Y, vector.Z)

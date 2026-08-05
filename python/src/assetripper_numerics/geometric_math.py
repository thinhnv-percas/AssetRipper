"""Port of Source/AssetRipper.Numerics/GeometricMath.cs"""
from __future__ import annotations

import math

from ._vecmath import Vector2


def angle_from_3_points(point1: Vector2, point2: Vector2, point3: Vector2) -> float:
    """Angle increase when the 2nd line is moving in a clockwise direction. Returns degrees."""
    transformed_p1_x = point1.X - point2.X
    transformed_p1_y = point1.Y - point2.Y
    transformed_p2_x = point3.X - point2.X
    transformed_p2_y = point3.Y - point2.Y

    angle_to_p1 = math.atan2(transformed_p1_y, transformed_p1_x)
    angle_to_p2 = math.atan2(transformed_p2_y, transformed_p2_x)

    angle = angle_to_p1 - angle_to_p2
    if angle < 0:
        angle += 2 * math.pi

    return 360.0 * angle / (2.0 * math.pi)

"""Port of Source/AssetRipper.Numerics/RelativeDistanceMethods.cs

A collection of functions calculating the relative distance between two points.
All functions return a float between 0 and 1 (inclusive): 0 indicates equality
and 1 indicates great distance. For the sequence functions, the return value is
the sum (not average, matching the C# `out sum, out count` pair) of the relative
distances for the individual points.
"""
from __future__ import annotations

from ._vecmath import Vector2, Vector3, Vector4
from .bone_weight import BoneWeight4
from .color_float import ColorFloat


def relative_distance(x1: float, x2: float) -> float:
    return 0.0 if x1 == x2 else abs(x1 - x2) / (abs(x1) + abs(x2))


def relative_distance2(x1: float, x2: float) -> float:
    ratio = (x1 - x2) / (x1 + x2)
    return ratio * ratio


def relative_distance_vector2(v1: Vector2, v2: Vector2) -> float:
    return 0.0 if v1 == v2 else Vector2.distance(v1, v2) / (v1.length() + v2.length())


def relative_distance2_vector2(v1: Vector2, v2: Vector2) -> float:
    return Vector2.distance_squared(v1, v2) / (v1 + v2).length_squared()


def relative_distance_vector3(v1: Vector3, v2: Vector3) -> float:
    return 0.0 if v1 == v2 else Vector3.distance(v1, v2) / (v1.length() + v2.length())


def relative_distance_vector4(v1: Vector4, v2: Vector4) -> float:
    return 0.0 if v1 == v2 else Vector4.distance(v1, v2) / (v1.length() + v2.length())


def relative_distance_color_float(v1: ColorFloat, v2: ColorFloat) -> float:
    return relative_distance_vector4(v1.vector, v2.vector)


def relative_distance_bone_weight4(v1: BoneWeight4, v2: BoneWeight4) -> float:
    return (
        relative_distance(v1.weight0, v2.weight0)
        + relative_distance(v1.weight1, v2.weight1)
        + relative_distance(v1.weight2, v2.weight2)
        + relative_distance(v1.weight3, v2.weight3)
    ) / 4


def _sequence(items1, items2, distance_fn):
    assert len(items1) == len(items2)
    total = 0.0
    for a, b in zip(items1, items2):
        total += distance_fn(a, b)
    return total, len(items1)


def relative_distance_floats(x1: list[float], x2: list[float]) -> tuple[float, int]:
    return _sequence(x1, x2, relative_distance)


def relative_distance_vector2s(v1: list[Vector2], v2: list[Vector2]) -> tuple[float, int]:
    return _sequence(v1, v2, relative_distance_vector2)


def relative_distance_vector3s(v1: list[Vector3], v2: list[Vector3]) -> tuple[float, int]:
    return _sequence(v1, v2, relative_distance_vector3)


def relative_distance_vector4s(v1: list[Vector4], v2: list[Vector4]) -> tuple[float, int]:
    return _sequence(v1, v2, relative_distance_vector4)


def relative_distance_color_floats(v1: list[ColorFloat], v2: list[ColorFloat]) -> tuple[float, int]:
    return _sequence(v1, v2, relative_distance_color_float)


def relative_distance_bone_weight4s(v1: list[BoneWeight4], v2: list[BoneWeight4]) -> tuple[float, int]:
    return _sequence(v1, v2, relative_distance_bone_weight4)

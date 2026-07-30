"""Port of Source/AssetRipper.Numerics/Vector3Extensions.cs"""
from __future__ import annotations

import math

from ._vecmath import Quaternion, Vector3

_K_EPSILON = 0.00001


def to_quaternion(source: Vector3, is_degrees: bool) -> Quaternion:
    # Abbreviations for the various angular functions
    cy = math.cos(_get_radians(source.Z, is_degrees) * 0.5)
    sy = math.sin(_get_radians(source.Z, is_degrees) * 0.5)
    cp = math.cos(_get_radians(source.Y, is_degrees) * 0.5)
    sp = math.sin(_get_radians(source.Y, is_degrees) * 0.5)
    cr = math.cos(_get_radians(source.X, is_degrees) * 0.5)
    sr = math.sin(_get_radians(source.X, is_degrees) * 0.5)

    return Quaternion(
        W=-((cr * cp * cy) + (sr * sp * sy)),
        X=-((sr * cp * cy) - (cr * sp * sy)),
        Y=((cr * sp * cy) + (sr * cp * sy)),
        Z=((cr * cp * sy) - (sr * sp * cy)),
    )


def _get_radians(angle: float, is_degrees: bool) -> float:
    return angle * math.pi / 180.0 if is_degrees else angle


def normalize(instance: Vector3) -> None:
    """
    Faithful port of the C# extension `Normalize(this Vector3 instance)`.
    Vector3 is a value type passed by value (not `ref`) in the original, so mutating
    `instance` there never affects the caller -- it is a no-op there, and so it is here.
    """
    return None


def dot(instance: Vector3, other: Vector3) -> float:
    return (instance.X * other.X) + (instance.Y * other.Y) + (instance.Z * other.Z)


def equals_by_dot(instance: Vector3, other: Vector3) -> bool:
    instance_length = instance.length()
    other_length = other.length()

    if instance_length < _K_EPSILON:
        return other_length < _K_EPSILON

    if other_length < _K_EPSILON:
        return False

    dot_value = dot(instance, other)
    deviation = 1.0 - (dot_value / instance_length / other_length)
    return deviation < _K_EPSILON

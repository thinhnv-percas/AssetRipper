"""Port of Source/AssetRipper.Numerics/QuaternionExtensions.cs"""
from __future__ import annotations

import math

from ._vecmath import Quaternion, Vector3

_K_EPSILON = 0.00001


def get_at(quaternion: Quaternion, index: int) -> float:
    if index == 0:
        return quaternion.X
    if index == 1:
        return quaternion.Y
    if index == 2:
        return quaternion.Z
    if index == 3:
        return quaternion.W
    raise IndexError(f"Index {index} is out of bound")


def set_at(quaternion: Quaternion, index: int, value: float) -> None:
    """Mutates `quaternion` in place, mirroring the C# `this ref Quaternion` parameter."""
    if index == 0:
        quaternion.X = value
    elif index == 1:
        quaternion.Y = value
    elif index == 2:
        quaternion.Z = value
    elif index == 3:
        quaternion.W = value
    else:
        raise IndexError(f"Index {index} is out of bound")


def flip_sign_at(quaternion: Quaternion, index: int) -> None:
    """Mutates `quaternion` in place, mirroring the C# `this ref Quaternion` parameter."""
    if index == 0:
        quaternion.X = -quaternion.X
    elif index == 1:
        quaternion.Y = -quaternion.Y
    elif index == 2:
        quaternion.Z = -quaternion.Z
    elif index == 3:
        quaternion.W = -quaternion.W
    else:
        raise IndexError(f"Index {index} is out of bound")


def to_euler_angle(quaternion: Quaternion, as_degrees: bool) -> Vector3:
    qx = quaternion.X
    qy = -quaternion.Y
    qz = -quaternion.Z
    qw = quaternion.W

    nq = (qx * qx) + (qy * qy) + (qz * qz) + (qw * qw)
    s = 2.0 / nq if nq > 0.0 else 0.0
    xs, ys, zs = qx * s, qy * s, qz * s
    wx, wy, wz = qw * xs, qw * ys, qw * zs
    xx, xy, xz = qx * xs, qx * ys, qx * zs
    yy, yz, zz = qy * ys, qy * zs, qz * zs

    m00 = 1.0 - (yy + zz)
    m10 = xy + wz
    m11 = 1.0 - (xx + zz)
    m12 = yz - wx
    m20 = xz - wy
    m21 = yz + wx

    test = math.sqrt((m00 * m00) + (m10 * m10))
    if test > 16 * 1.19209290e-07:  # FLT_EPSILON
        eax = math.atan2(m21, 1.0 - (xx + yy))
        eay = math.atan2(-m20, test)
        eaz = math.atan2(m10, m00)
    else:
        eax = math.atan2(-m12, m11)
        eay = math.atan2(-m20, test)
        eaz = 0.0

    return Vector3(
        X=_get_angle(eax, as_degrees),
        Y=_get_angle(eay, as_degrees),
        Z=_get_angle(eaz, as_degrees),
    )


def _get_angle(radians: float, convert_to_degrees: bool) -> float:
    return _radians_to_degrees(radians) if convert_to_degrees else radians


def _radians_to_degrees(radians: float) -> float:
    return radians * 180.0 / math.pi


def dot(a: Quaternion, b: Quaternion) -> float:
    return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z) + (a.W * b.W)


def is_unit_quaternion(a: Quaternion) -> bool:
    return ((a.X * a.X) + (a.Y * a.Y) + (a.Z * a.Z) + (a.W * a.W)) > 1.0 - _K_EPSILON


def is_zero(a: Quaternion) -> bool:
    return a.X == 0 and a.Y == 0 and a.Z == 0 and a.W == 0


def equals_by_dot(a: Quaternion, b: Quaternion) -> bool:
    return dot(a, b) > 1.0 - _K_EPSILON

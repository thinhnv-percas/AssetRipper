"""
Minimal port of the subset of System.Numerics (Vector2/3/4, Quaternion, Matrix4x4)
that AssetRipper.Numerics depends on via its `global using System.Numerics;` (Usings.cs).

Vector2/Vector3/Vector4 are immutable, mirroring the practical value-type behavior of
the C# structs (extension methods that mutate `this Vector3` by value, e.g.
Vector3Extensions.Normalize, are no-ops in C# too -- see vector3_extensions.py).
Quaternion is mutable because QuaternionExtensions.SetAt/FlipSignAt take `this ref Quaternion`,
which really does mutate the caller's variable in C#.

All components are rounded to IEEE 754 single precision (`_f32`) on every construction/assignment,
matching C#'s `float` (not `double`) so that arithmetic identities the original NUnit tests rely on
(e.g. two independently-derived single-precision computations landing on the exact same bit pattern)
hold here too -- computing in full Python double precision would leave tiny residual differences
that C#'s `float` rounding erases.
"""
from __future__ import annotations

import math
import struct
from dataclasses import dataclass

_PACK_F32 = struct.Struct("<f").pack
_UNPACK_F32 = struct.Struct("<f").unpack


def _f32(value: float) -> float:
    return _UNPACK_F32(_PACK_F32(value))[0]


@dataclass(frozen=True, slots=True)
class Vector2:
    X: float = 0.0
    Y: float = 0.0

    def __post_init__(self) -> None:
        object.__setattr__(self, "X", _f32(self.X))
        object.__setattr__(self, "Y", _f32(self.Y))

    @staticmethod
    def zero() -> "Vector2":
        return Vector2(0.0, 0.0)

    @staticmethod
    def one() -> "Vector2":
        return Vector2(1.0, 1.0)

    def __add__(self, other: "Vector2") -> "Vector2":
        return Vector2(self.X + other.X, self.Y + other.Y)

    def __sub__(self, other: "Vector2") -> "Vector2":
        return Vector2(self.X - other.X, self.Y - other.Y)

    def length(self) -> float:
        return _f32(math.sqrt(self.length_squared()))

    def length_squared(self) -> float:
        return self.X * self.X + self.Y * self.Y

    @staticmethod
    def distance(a: "Vector2", b: "Vector2") -> float:
        return (a - b).length()

    @staticmethod
    def distance_squared(a: "Vector2", b: "Vector2") -> float:
        return (a - b).length_squared()


@dataclass(frozen=True, slots=True)
class Vector3:
    X: float = 0.0
    Y: float = 0.0
    Z: float = 0.0

    def __post_init__(self) -> None:
        object.__setattr__(self, "X", _f32(self.X))
        object.__setattr__(self, "Y", _f32(self.Y))
        object.__setattr__(self, "Z", _f32(self.Z))

    @staticmethod
    def zero() -> "Vector3":
        return Vector3(0.0, 0.0, 0.0)

    @staticmethod
    def one() -> "Vector3":
        return Vector3(1.0, 1.0, 1.0)

    def __add__(self, other: "Vector3") -> "Vector3":
        return Vector3(self.X + other.X, self.Y + other.Y, self.Z + other.Z)

    def __sub__(self, other: "Vector3") -> "Vector3":
        return Vector3(self.X - other.X, self.Y - other.Y, self.Z - other.Z)

    def __neg__(self) -> "Vector3":
        return Vector3(-self.X, -self.Y, -self.Z)

    def __mul__(self, scalar: float) -> "Vector3":
        return Vector3(self.X * scalar, self.Y * scalar, self.Z * scalar)

    __rmul__ = __mul__

    def __truediv__(self, other) -> "Vector3":
        if isinstance(other, Vector3):
            return Vector3(self.X / other.X, self.Y / other.Y, self.Z / other.Z)
        return Vector3(self.X / other, self.Y / other, self.Z / other)

    def length(self) -> float:
        return _f32(math.sqrt(self.length_squared()))

    def length_squared(self) -> float:
        return self.X * self.X + self.Y * self.Y + self.Z * self.Z

    @staticmethod
    def negate(v: "Vector3") -> "Vector3":
        return -v

    @staticmethod
    def distance(a: "Vector3", b: "Vector3") -> float:
        return (a - b).length()

    @staticmethod
    def transform(position: "Vector3", matrix: "Matrix4x4") -> "Vector3":
        return Vector3(
            position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41,
            position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42,
            position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43,
        )


@dataclass(frozen=True, slots=True)
class Vector4:
    X: float = 0.0
    Y: float = 0.0
    Z: float = 0.0
    W: float = 0.0

    def __post_init__(self) -> None:
        object.__setattr__(self, "X", _f32(self.X))
        object.__setattr__(self, "Y", _f32(self.Y))
        object.__setattr__(self, "Z", _f32(self.Z))
        object.__setattr__(self, "W", _f32(self.W))

    @staticmethod
    def zero() -> "Vector4":
        return Vector4(0.0, 0.0, 0.0, 0.0)

    def __add__(self, other: "Vector4") -> "Vector4":
        return Vector4(self.X + other.X, self.Y + other.Y, self.Z + other.Z, self.W + other.W)

    def __sub__(self, other: "Vector4") -> "Vector4":
        return Vector4(self.X - other.X, self.Y - other.Y, self.Z - other.Z, self.W - other.W)

    def __mul__(self, scalar: float) -> "Vector4":
        return Vector4(self.X * scalar, self.Y * scalar, self.Z * scalar, self.W * scalar)

    __rmul__ = __mul__

    def __truediv__(self, scalar: float) -> "Vector4":
        return Vector4(self.X / scalar, self.Y / scalar, self.Z / scalar, self.W / scalar)

    def length(self) -> float:
        return _f32(math.sqrt(self.length_squared()))

    def length_squared(self) -> float:
        return self.X * self.X + self.Y * self.Y + self.Z * self.Z + self.W * self.W

    def as_vector3(self) -> Vector3:
        """Port of the BCL's Vector4.AsVector3(): reinterprets by dropping W."""
        return Vector3(self.X, self.Y, self.Z)

    @staticmethod
    def distance(a: "Vector4", b: "Vector4") -> float:
        return (a - b).length()


@dataclass(slots=True)
class Quaternion:
    """Mutable: QuaternionExtensions.SetAt/FlipSignAt mutate `ref Quaternion` in C#."""

    X: float = 0.0
    Y: float = 0.0
    Z: float = 0.0
    W: float = 1.0

    def __setattr__(self, name: str, value) -> None:
        object.__setattr__(self, name, _f32(value) if name in ("X", "Y", "Z", "W") else value)

    @staticmethod
    def identity() -> "Quaternion":
        return Quaternion(0.0, 0.0, 0.0, 1.0)

    @staticmethod
    def create_from_yaw_pitch_roll(yaw: float, pitch: float, roll: float) -> "Quaternion":
        half_roll = roll * 0.5
        sr, cr = math.sin(half_roll), math.cos(half_roll)
        half_pitch = pitch * 0.5
        sp, cp = math.sin(half_pitch), math.cos(half_pitch)
        half_yaw = yaw * 0.5
        sy, cy = math.sin(half_yaw), math.cos(half_yaw)
        return Quaternion(
            X=(cy * sp * cr) + (sy * cp * sr),
            Y=(sy * cp * cr) - (cy * sp * sr),
            Z=(cy * cp * sr) - (sy * sp * cr),
            W=(cy * cp * cr) + (sy * sp * sr),
        )

    @staticmethod
    def inverse(q: "Quaternion") -> "Quaternion":
        length_sq = q.X * q.X + q.Y * q.Y + q.Z * q.Z + q.W * q.W
        inv = 1.0 / length_sq
        return Quaternion(-q.X * inv, -q.Y * inv, -q.Z * inv, q.W * inv)


@dataclass(frozen=True, slots=True)
class Matrix4x4:
    M11: float = 1.0
    M12: float = 0.0
    M13: float = 0.0
    M14: float = 0.0
    M21: float = 0.0
    M22: float = 1.0
    M23: float = 0.0
    M24: float = 0.0
    M31: float = 0.0
    M32: float = 0.0
    M33: float = 1.0
    M34: float = 0.0
    M41: float = 0.0
    M42: float = 0.0
    M43: float = 0.0
    M44: float = 1.0

    def __post_init__(self) -> None:
        for field in (
            "M11", "M12", "M13", "M14",
            "M21", "M22", "M23", "M24",
            "M31", "M32", "M33", "M34",
            "M41", "M42", "M43", "M44",
        ):
            object.__setattr__(self, field, _f32(getattr(self, field)))

    @staticmethod
    def identity() -> "Matrix4x4":
        return Matrix4x4()

    def __mul__(self, other: "Matrix4x4") -> "Matrix4x4":
        a, b = self, other
        return Matrix4x4(
            M11=a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
            M12=a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
            M13=a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,
            M14=a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44,
            M21=a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
            M22=a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
            M23=a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,
            M24=a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44,
            M31=a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
            M32=a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
            M33=a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,
            M34=a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44,
            M41=a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
            M42=a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
            M43=a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43,
            M44=a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44,
        )

    @staticmethod
    def create_scale(scales: Vector3) -> "Matrix4x4":
        return Matrix4x4(M11=scales.X, M22=scales.Y, M33=scales.Z)

    @staticmethod
    def create_translation(position: Vector3) -> "Matrix4x4":
        return Matrix4x4(M41=position.X, M42=position.Y, M43=position.Z)

    @staticmethod
    def create_from_quaternion(quaternion: Quaternion) -> "Matrix4x4":
        q = quaternion
        xx, yy, zz = q.X * q.X, q.Y * q.Y, q.Z * q.Z
        xy, wz, xz = q.X * q.Y, q.Z * q.W, q.Z * q.X
        wy, yz, wx = q.Y * q.W, q.Y * q.Z, q.X * q.W
        return Matrix4x4(
            M11=1.0 - 2.0 * (yy + zz), M12=2.0 * (xy + wz), M13=2.0 * (xz - wy),
            M21=2.0 * (xy - wz), M22=1.0 - 2.0 * (zz + xx), M23=2.0 * (yz + wx),
            M31=2.0 * (xz + wy), M32=2.0 * (yz - wx), M33=1.0 - 2.0 * (yy + xx),
        )

    @staticmethod
    def transpose(m: "Matrix4x4") -> "Matrix4x4":
        return Matrix4x4(
            M11=m.M11, M12=m.M21, M13=m.M31, M14=m.M41,
            M21=m.M12, M22=m.M22, M23=m.M32, M24=m.M42,
            M31=m.M13, M32=m.M23, M33=m.M33, M34=m.M43,
            M41=m.M14, M42=m.M24, M43=m.M34, M44=m.M44,
        )

    @staticmethod
    def invert(matrix: "Matrix4x4") -> tuple[bool, "Matrix4x4"]:
        """Port of System.Numerics.Matrix4x4.Invert (cofactor expansion by 2x2 minors)."""
        m = matrix
        b00 = m.M11 * m.M22 - m.M12 * m.M21
        b01 = m.M11 * m.M23 - m.M13 * m.M21
        b02 = m.M11 * m.M24 - m.M14 * m.M21
        b03 = m.M12 * m.M23 - m.M13 * m.M22
        b04 = m.M12 * m.M24 - m.M14 * m.M22
        b05 = m.M13 * m.M24 - m.M14 * m.M23
        b06 = m.M31 * m.M42 - m.M32 * m.M41
        b07 = m.M31 * m.M43 - m.M33 * m.M41
        b08 = m.M31 * m.M44 - m.M34 * m.M41
        b09 = m.M32 * m.M43 - m.M33 * m.M42
        b10 = m.M32 * m.M44 - m.M34 * m.M42
        b11 = m.M33 * m.M44 - m.M34 * m.M43

        det = b00 * b11 - b01 * b10 + b02 * b09 + b03 * b08 - b04 * b07 + b05 * b06
        if abs(det) < 1.1920929e-07:  # float.Epsilon-ish guard used upstream
            return False, Matrix4x4(*([math.nan] * 16))

        inv_det = 1.0 / det

        M11 = (m.M22 * b11 - m.M23 * b10 + m.M24 * b09) * inv_det
        M12 = (-m.M12 * b11 + m.M13 * b10 - m.M14 * b09) * inv_det
        M13 = (m.M42 * b05 - m.M43 * b04 + m.M44 * b03) * inv_det
        M14 = (-m.M32 * b05 + m.M33 * b04 - m.M34 * b03) * inv_det

        M21 = (-m.M21 * b11 + m.M23 * b08 - m.M24 * b07) * inv_det
        M22 = (m.M11 * b11 - m.M13 * b08 + m.M14 * b07) * inv_det
        M23 = (-m.M41 * b05 + m.M43 * b02 - m.M44 * b01) * inv_det
        M24 = (m.M31 * b05 - m.M33 * b02 + m.M34 * b01) * inv_det

        M31 = (m.M21 * b10 - m.M22 * b08 + m.M24 * b06) * inv_det
        M32 = (-m.M11 * b10 + m.M12 * b08 - m.M14 * b06) * inv_det
        M33 = (m.M41 * b04 - m.M42 * b02 + m.M44 * b00) * inv_det
        M34 = (-m.M31 * b04 + m.M32 * b02 - m.M34 * b00) * inv_det

        M41 = (-m.M21 * b09 + m.M22 * b07 - m.M23 * b06) * inv_det
        M42 = (m.M11 * b09 - m.M12 * b07 + m.M13 * b06) * inv_det
        M43 = (-m.M41 * b03 + m.M42 * b01 - m.M43 * b00) * inv_det
        M44 = (m.M31 * b03 - m.M32 * b01 + m.M33 * b00) * inv_det

        return True, Matrix4x4(
            M11=M11, M12=M12, M13=M13, M14=M14,
            M21=M21, M22=M22, M23=M23, M24=M24,
            M31=M31, M32=M32, M33=M33, M34=M34,
            M41=M41, M42=M42, M43=M43, M44=M44,
        )

    def __str__(self) -> str:
        return (
            f"{{ {{M11:{self.M11} M12:{self.M12} M13:{self.M13} M14:{self.M14}}} "
            f"{{M21:{self.M21} M22:{self.M22} M23:{self.M23} M24:{self.M24}}} "
            f"{{M31:{self.M31} M32:{self.M32} M33:{self.M33} M34:{self.M34}}} "
            f"{{M41:{self.M41} M42:{self.M42} M43:{self.M43} M44:{self.M44}}} }}"
        )

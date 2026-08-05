"""Port of Source/AssetRipper.Numerics/Transformation.cs"""
from __future__ import annotations

from dataclasses import dataclass

from ._vecmath import Matrix4x4, Quaternion, Vector3
from .quaternion_extensions import is_zero


@dataclass(frozen=True, slots=True)
class Transformation:
    """A transformation composed of a translation, rotation, and scale."""

    matrix: Matrix4x4

    @staticmethod
    def create(translation: Vector3, rotation: Quaternion, scale: Vector3) -> "Transformation":
        return Transformation(_convert_to_matrix(translation, rotation, scale))

    @staticmethod
    def identity() -> "Transformation":
        return Transformation(Matrix4x4.identity())

    @staticmethod
    def identity_with_inverted_x() -> "Transformation":
        """Switches coordinates from left-handedness to right-handedness (Unity -> Gltf)."""
        return Transformation(Matrix4x4(-1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1))

    def transform_point(self, position: Vector3) -> Vector3:
        return Vector3.transform(position, self.matrix)

    def __mul__(self, other: "Transformation") -> "Transformation":
        return Transformation(self.matrix * other.matrix)

    @staticmethod
    def create_inverse(translation: Vector3, rotation: Quaternion, scale: Vector3) -> "Transformation":
        inverse_translation = Vector3.negate(translation)
        inverse_rotation = _invert_quaternion(rotation)
        inverse_scale = Vector3.one() / scale
        matrix = (
            Matrix4x4.create_translation(inverse_translation)
            * Matrix4x4.create_from_quaternion(inverse_rotation)
            * Matrix4x4.create_scale(inverse_scale)
        )
        return Transformation(matrix)

    def invert(self) -> "Transformation":
        success, inverted = Matrix4x4.invert(self.matrix)
        if not success:
            raise ValueError("Could not invert matrix")
        return Transformation(inverted)

    def transpose(self) -> "Transformation":
        return Transformation(Matrix4x4.transpose(self.matrix))

    def remove_translation(self) -> "Transformation":
        return Transformation(_reset_fourth_row(self.matrix))

    def __str__(self) -> str:
        return str(self.matrix)


def _convert_to_matrix(translation: Vector3, rotation: Quaternion, scale: Vector3) -> Matrix4x4:
    return (
        Matrix4x4.create_scale(scale)
        * Matrix4x4.create_from_quaternion(rotation)
        * Matrix4x4.create_translation(translation)
    )


def _invert_quaternion(rotation: Quaternion) -> Quaternion:
    if is_zero(rotation):
        return Quaternion.identity()
    return Quaternion.inverse(rotation)


def _reset_fourth_row(matrix: Matrix4x4) -> Matrix4x4:
    return Matrix4x4(
        matrix.M11, matrix.M12, matrix.M13, matrix.M14,
        matrix.M21, matrix.M22, matrix.M23, matrix.M24,
        matrix.M31, matrix.M32, matrix.M33, matrix.M34,
        0, 0, 0, 1,
    )

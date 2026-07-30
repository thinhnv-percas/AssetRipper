"""Port of Source/AssetRipper.Numerics.Tests/TransformationTests.cs"""
import math

import pytest

from assetripper_numerics import Vector3
from assetripper_numerics._vecmath import Matrix4x4, Quaternion
from assetripper_numerics.transformation import Transformation


def _approximately_equal_matrix(actual: Matrix4x4, expected: Matrix4x4, max_deviation: float) -> bool:
    fields = ("M11", "M12", "M13", "M14", "M21", "M22", "M23", "M24", "M31", "M32", "M33", "M34", "M41", "M42", "M43", "M44")
    return all(abs(getattr(actual, f) - getattr(expected, f)) <= max_deviation for f in fields)


def _assert_approximately_equal(actual: Transformation, expected: Transformation, max_deviation: float = 0.00001):
    assert _approximately_equal_matrix(actual.matrix, expected.matrix, max_deviation), (
        f"Expected:\n{expected}\nActual:\n{actual}"
    )


def test_move_then_scale():
    t1 = Transformation.create(Vector3(0, 0.5, 0), Quaternion.identity(), Vector3.one())
    t2 = Transformation.create(Vector3.zero(), Quaternion.identity(), Vector3(1, 2, 1))
    expected = Transformation.create(Vector3(0, 1, 0), Quaternion.identity(), Vector3(1, 2, 1))
    assert (t1 * t2).matrix == expected.matrix


def test_move_and_rotate_then_scale():
    t1 = Transformation.create(Vector3(0, 0.5, 0), Quaternion(0, 0, math.sqrt(2) / 2, math.sqrt(2) / 2), Vector3.one())
    t2 = Transformation.create(Vector3.zero(), Quaternion.identity(), Vector3(1, 2, 1))
    expected = Transformation.create(
        Vector3(0, 1, 0), Quaternion(0, 0, math.sqrt(2) / 2, math.sqrt(2) / 2), Vector3(2, 1, 1)
    )
    _assert_approximately_equal(t1 * t2, expected)
    assert not _approximately_equal_matrix((t2 * t1).matrix, expected.matrix, 0.00001)


def test_identity():
    actual = Transformation.create(Vector3.zero(), Quaternion.identity(), Vector3.one())
    _assert_approximately_equal(actual, Transformation.identity())


def test_remove_translation():
    translation = Vector3(2, 5, -8)
    rotation = Quaternion.create_from_yaw_pitch_roll(2, 0.5, 3)
    scale = Vector3(0.8, 2, 3)
    with_translation = Transformation.create(translation, rotation, scale)
    without_translation = Transformation.create(Vector3.zero(), rotation, scale)
    _assert_approximately_equal(with_translation.remove_translation(), without_translation)


def test_inversion():
    original = Transformation.create(Vector3(2, 5, -8), Quaternion.create_from_yaw_pitch_roll(2, 0.5, 3), Vector3(0.8, 2, 3))
    inverted = original.invert()
    _assert_approximately_equal(original * inverted, Transformation.identity())
    _assert_approximately_equal(inverted * original, Transformation.identity())


def test_inversion_from_components():
    translation = Vector3(2, 5, -8)
    rotation = Quaternion.create_from_yaw_pitch_roll(2, 0.5, 3)
    scale = Vector3(0.8, 2, 3)
    original = Transformation.create(translation, rotation, scale)
    inverted = Transformation.create_inverse(translation, rotation, scale)
    _assert_approximately_equal(original * inverted, Transformation.identity())
    _assert_approximately_equal(inverted * original, Transformation.identity())


def test_inversion_from_components_translation():
    translation = Vector3(2, 5, -8)
    rotation = Quaternion.identity()
    scale = Vector3.one()
    original = Transformation.create(translation, rotation, scale)
    inverted = Transformation.create_inverse(translation, rotation, scale)
    _assert_approximately_equal(original * inverted, Transformation.identity())
    _assert_approximately_equal(inverted * original, Transformation.identity())


def test_inversion_from_components_rotation():
    translation = Vector3.zero()
    rotation = Quaternion.create_from_yaw_pitch_roll(2, 0.5, 3)
    scale = Vector3.one()
    original = Transformation.create(translation, rotation, scale)
    inverted = Transformation.create_inverse(translation, rotation, scale)
    _assert_approximately_equal(original * inverted, Transformation.identity())
    _assert_approximately_equal(inverted * original, Transformation.identity())


def test_inversion_from_components_scale():
    translation = Vector3.zero()
    rotation = Quaternion.identity()
    scale = Vector3(0.8, 2, 3)
    original = Transformation.create(translation, rotation, scale)
    inverted = Transformation.create_inverse(translation, rotation, scale)
    _assert_approximately_equal(original * inverted, Transformation.identity())
    _assert_approximately_equal(inverted * original, Transformation.identity())


def test_vector_multiplication():
    vector = Vector3(2, 4, 6)
    transformation = Transformation(
        Matrix4x4(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)
    )
    expected = Vector3.transform(vector, transformation.matrix)
    actual = transformation.transform_point(vector)
    assert actual == expected


def test_multiply_transformations():
    t1 = Transformation.identity()
    t2 = Transformation.create(Vector3(5, 5, 5), Quaternion(1, 1, 1, 1), Vector3(2, 2, 2))
    expected = Transformation(
        Matrix4x4(-6, 8, 0, 0, 0, -6, 8, 0, 8, 0, -6, 0, 5, 5, 5, 1)
    )
    actual = t1 * t2
    assert actual.matrix == expected.matrix


def test_create_inverse():
    translation = Vector3(1, 2, 3)
    rotation = Quaternion(0.5, 0.5, 0.5, 0.5)
    scale = Vector3(2, 2, 2)

    transform = Transformation.create(translation, rotation, scale)
    inverse = transform.invert()
    success, expected = Matrix4x4.invert(transform.matrix)
    assert success
    assert inverse.matrix == expected


def test_transpose():
    matrix = Matrix4x4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
    transformation = Transformation(matrix)
    expected = Transformation(Matrix4x4.transpose(matrix))
    actual = transformation.transpose()
    assert actual.matrix == expected.matrix


def test_remove_translation_matrix():
    translation = Vector3(1, 2, 3)
    rotation = Quaternion.identity()
    scale = Vector3(2, 2, 2)

    transform = Transformation.create(translation, rotation, scale)
    expected = Transformation(Matrix4x4.create_scale(scale) * Matrix4x4.create_from_quaternion(rotation))
    actual = transform.remove_translation()
    assert actual.matrix == expected.matrix


def test_convert_to_matrix():
    translation = Vector3(1, 2, 3)
    rotation = Quaternion(1, 2, 3, 4)
    scale = Vector3(2, 2, 2)

    expected = Transformation(
        Matrix4x4.create_scale(scale) * Matrix4x4.create_from_quaternion(rotation) * Matrix4x4.create_translation(translation)
    )
    actual = Transformation.create(translation, rotation, scale)
    assert actual.matrix == expected.matrix

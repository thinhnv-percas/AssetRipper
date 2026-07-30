"""Port of Source/AssetRipper.Numerics.Tests/RelativeDistanceTests.cs"""
import random

import pytest

from assetripper_numerics import Vector2, Vector3, Vector4
from assetripper_numerics.relative_distance_methods import relative_distance as _relative_distance
from assetripper_numerics.relative_distance_methods import (
    relative_distance_vector2,
    relative_distance_vector3,
    relative_distance_vector4,
)


@pytest.fixture
def random_floats() -> list[float]:
    return [4 * random.random() - 2 for _ in range(60)]  # -2 to 2


def test_values_of_opposite_signs_have_distance_one():
    assert _relative_distance(5.0, -3.0) == 1.0


def test_equal_values_have_distance_zero(random_floats):
    for value in random_floats:
        distance = _relative_distance(value, value)
        assert distance == 0.0, f"Value {value} did not have zero distance with itself."


def test_distance_is_nonnegative_and_symmetric(random_floats):
    for i in range(len(random_floats) - 1):
        value1, value2 = random_floats[i], random_floats[i + 1]
        distance_a = _relative_distance(value1, value2)
        assert distance_a >= 0.0, f"Values {value1} and {value2} had negative distance."
        distance_b = _relative_distance(value2, value1)
        assert distance_a == distance_b, f"Values {value1} and {value2} did not exhibit symmetry."


def test_triangle_inequality_holds(random_floats):
    for i in range(len(random_floats) - 2):
        value1, value2, value3 = random_floats[i], random_floats[i + 1], random_floats[i + 2]
        distance_a = _relative_distance(value1, value2)
        distance_b = _relative_distance(value2, value3)
        distance_c = _relative_distance(value1, value3)
        assert (
            distance_a + distance_b >= distance_c
        ), f"Values {value1}, {value2}, and {value3} did not adhere to the triangle inequality."


def test_distance_is_the_same_in_multiple_dimensions(random_floats):
    for i in range(len(random_floats) - 1):
        value1, value2 = random_floats[i], random_floats[i + 1]
        distance_1d = _relative_distance(value1, value2)
        distance_2d = relative_distance_vector2(Vector2(value1, 0), Vector2(value2, 0))
        distance_3d = relative_distance_vector3(Vector3(value1, 0, 0), Vector3(value2, 0, 0))
        distance_4d = relative_distance_vector4(Vector4(value1, 0, 0, 0), Vector4(value2, 0, 0, 0))
        assert distance_2d == pytest.approx(distance_1d), (
            f"Values {value1} and {value2} did not have the same distance in 2 dimensions."
        )
        assert distance_3d == pytest.approx(distance_1d), (
            f"Values {value1} and {value2} did not have the same distance in 3 dimensions."
        )
        assert distance_4d == pytest.approx(distance_1d), (
            f"Values {value1} and {value2} did not have the same distance in 4 dimensions."
        )


def test_comparing_zero_with_itself_is_zero():
    assert _relative_distance(0.0, 0.0) == 0.0, "1D distance between zero was not zero."
    assert relative_distance_vector2(Vector2.zero(), Vector2.zero()) == 0.0, "2D distance between zero was not zero."
    assert relative_distance_vector3(Vector3.zero(), Vector3.zero()) == 0.0, "3D distance between zero was not zero."
    assert relative_distance_vector4(Vector4.zero(), Vector4.zero()) == 0.0, "4D distance between zero was not zero."

"""Port of Source/AssetRipper.Numerics.Tests/QuaternionTests.cs"""
from assetripper_numerics import Vector3
from assetripper_numerics.quaternion_extensions import is_unit_quaternion
from assetripper_numerics.vector3_extensions import equals_by_dot, to_quaternion
from assetripper_numerics.quaternion_extensions import to_euler_angle as _to_euler_angle


def _convert_euler_to_quaternion_and_back_to_euler(original: Vector3) -> Vector3:
    quaternion = to_quaternion(original, True)
    return _to_euler_angle(quaternion, True)


def test_converting_to_quaternion_and_back_gives_the_same_values():
    # Many sets of values give exactly equal results
    euler1 = Vector3(-67.0, 45.0, -162.0)
    converted1 = _convert_euler_to_quaternion_and_back_to_euler(euler1)
    assert converted1 == euler1

    # Some however are only near equal due to rounding errors
    euler2 = Vector3(-67.0, 45.0, 178.0)
    converted2 = _convert_euler_to_quaternion_and_back_to_euler(euler2)
    assert equals_by_dot(euler2, converted2)


def test_to_quaternion_creates_unit_quaternions():
    euler = Vector3(-67.0, 45.0, -182.0)
    quaternion = to_quaternion(euler, True)
    assert is_unit_quaternion(quaternion)

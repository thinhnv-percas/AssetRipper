"""Port of Source/AssetRipper.Numerics.Tests/MathTests.cs"""
from assetripper_numerics import Vector3, Vector4


def test_as_vector3_extension_method():
    v = Vector4(1, 2, 3, 4)
    assert v.as_vector3() == Vector3(1, 2, 3)

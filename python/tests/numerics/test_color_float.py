"""Port of Source/AssetRipper.Numerics.Tests/ColorFloatTests.cs"""
from assetripper_numerics.color_float import ColorFloat


def test_addition_returns_expected_result():
    color1 = ColorFloat(0.1, 0.2, 0.3, 0.4)
    color2 = ColorFloat(0.5, 0.6, 0.7, 0.8)
    expected = ColorFloat(0.6, 0.8, 1.0, 1.2)
    assert (color1 + color2) == expected


def test_subtraction_returns_expected_result():
    color1 = ColorFloat(5.0, 6.0, 7.0, 8.0)
    color2 = ColorFloat(1.0, 2.0, 3.0, 4.0)
    expected = ColorFloat(4.0, 4.0, 4.0, 4.0)
    assert (color1 - color2) == expected


def test_clamp_returns_expected_result():
    color1 = ColorFloat(-0.1, 1.2, 0.3, -1.3)
    expected = ColorFloat(0.0, 1.0, 0.3, 0.0)
    assert color1.clamp() == expected


def test_multiplication_returns_expected_result():
    color1 = ColorFloat(0.1, 0.2, 0.3, 0.4)
    factor = 2.0
    expected = ColorFloat(0.2, 0.4, 0.6, 0.8)
    assert (color1 * factor) == expected


def test_static_methods_black_and_white_test_returns_expected_result():
    black = ColorFloat.black()
    white = ColorFloat.white()
    assert black == ColorFloat(0, 0, 0, 1)
    assert white == ColorFloat(1, 1, 1, 1)

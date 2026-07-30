"""Port of Source/AssetRipper.Numerics.Tests/Color32Tests.cs"""
import pytest

from assetripper_numerics.color32 import Color32
from assetripper_numerics.color_float import ColorFloat


@pytest.fixture
def color() -> Color32:
    return Color32(0x0A, 0x14, 0x1E, 0x28)


def test_rgba_returns_correct_value(color):
    assert color.rgba == 0x281E140A


def test_from_rgba_returns_correct_value(color):
    assert Color32.from_rgba(0x281E140A) == color


def test_explicit_color_float_operator_returns_correct_value(color):
    color_float = color.to_color_float()
    assert color_float == ColorFloat(0.0392156877, 0.0784313753, 0.117647059, 0.156862751)


def test_explicit_color32_operator_returns_correct_value():
    color32 = Color32.from_color_float(ColorFloat(0.0392156877, 0.0784313753, 0.117647059, 0.156862751))
    assert color32 == Color32(10, 20, 30, 40)


def test_black_returns_correct_value():
    assert Color32.black() == Color32(0, 0, 0, 255)


def test_white_returns_correct_value():
    assert Color32.white() == Color32(255, 255, 255, 255)


def test_rgba_property_matches_shift_operators():
    color = Color32(33, 57, 199, 255)
    value = color.R | (color.G << 8) | (color.B << 16) | (color.A << 24)
    assert color.rgba == value


def test_conversion_to_system_drawing_color_is_correct(color):
    system_color = color.to_system_color()
    assert system_color.r == color.R
    assert system_color.g == color.G
    assert system_color.b == color.B
    assert system_color.a == color.A

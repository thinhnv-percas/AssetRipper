"""Port of Source/AssetRipper.Numerics.Tests/RangeTests.cs"""
import pytest

from assetripper_numerics.range_ import Range

ZERO_TO_TEN = Range(0, 10)
ONE_TO_TEN = Range(1, 10)
ONE_TO_ELEVEN = Range(1, 11)
ZERO_TO_ELEVEN = Range(0, 11)
TEN_TO_TWENTY = Range(10, 20)
ZERO_TO_TWENTY = Range(0, 20)


def test_intersection():
    assert ONE_TO_TEN == ZERO_TO_TEN.make_intersection(ONE_TO_ELEVEN)


def test_intersecting_union():
    assert ZERO_TO_ELEVEN == ZERO_TO_TEN.make_union(ONE_TO_ELEVEN)


def test_nonintersecting_union():
    assert ZERO_TO_TWENTY == ZERO_TO_TEN.make_union(TEN_TO_TWENTY)


def test_contains_itself():
    assert ZERO_TO_TEN.contains(ZERO_TO_TEN)


def test_contains_start():
    assert ZERO_TO_TEN.contains(0)


def test_contains_middle():
    assert ZERO_TO_TEN.contains(5)


def test_does_not_contain_end():
    assert not ZERO_TO_TEN.contains(10)


def test_does_not_contain_less():
    assert not ZERO_TO_TEN.contains(-10)


def test_does_not_contain_more():
    assert not ZERO_TO_TEN.contains(100)


def test_end_before_start_throws():
    with pytest.raises(ValueError):
        Range(4, 3)


def test_end_equals_start_throws():
    with pytest.raises(ValueError):
        Range(4, 4)


def test_strict_comparisons():
    # Correct
    assert ZERO_TO_TEN.is_strictly_less(TEN_TO_TWENTY)
    assert TEN_TO_TWENTY.is_strictly_greater(ZERO_TO_TEN)

    # Reversed
    assert not TEN_TO_TWENTY.is_strictly_less(ZERO_TO_TEN)
    assert not ZERO_TO_TEN.is_strictly_greater(TEN_TO_TWENTY)

    # Overlapping
    assert not TEN_TO_TWENTY.is_strictly_less(ZERO_TO_ELEVEN)
    assert not ZERO_TO_ELEVEN.is_strictly_less(TEN_TO_TWENTY)
    assert not TEN_TO_TWENTY.is_strictly_greater(ZERO_TO_ELEVEN)
    assert not ZERO_TO_ELEVEN.is_strictly_greater(TEN_TO_TWENTY)

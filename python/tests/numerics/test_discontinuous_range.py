"""Port of Source/AssetRipper.Numerics.Tests/DiscontinuousRangeTests.cs"""
import sys

from assetripper_numerics.discontinuous_range import DiscontinuousRange
from assetripper_numerics.range_ import Range

MIN_TO_ZERO = Range(-sys.float_info.max, 0)
ZERO_TO_THREE = Range(0, 3)
THREE_TO_FOUR = Range(3, 4)
FOUR_TO_FIVE = Range(4, 5)
FIVE_TO_SEVEN = Range(5, 7)
SEVEN_TO_NINE = Range(7, 9)
NINE_TO_TEN = Range(9, 10)
ZERO_TO_TEN = Range(0, 110)
ZERO_TO_ELEVEN = Range(0, 11)
TEN_TO_TWENTY = Range(10, 20)
ZERO_TO_TWENTY = Range(0, 20)
ZERO_TO_MAX = Range(0, sys.float_info.max)
TWENTY_TO_MAX = Range(20, sys.float_info.max)
MIN_TO_MAX = Range(-sys.float_info.max, sys.float_info.max)


def _assert_equal(actual: DiscontinuousRange, expected: DiscontinuousRange) -> None:
    assert actual == expected, f"Expected: {expected}\nBut was: {actual}"


def test_disjoint_construction_succeeds_and_has_correct_count():
    r = DiscontinuousRange([ZERO_TO_THREE, SEVEN_TO_NINE, FOUR_TO_FIVE])
    assert r.count == 3


def test_overlapping_construction_succeeds_and_has_correct_count():
    r = DiscontinuousRange([ZERO_TO_THREE, SEVEN_TO_NINE, ZERO_TO_ELEVEN, FOUR_TO_FIVE])
    assert r.count == 1


def test_empty_has_count_zero():
    assert DiscontinuousRange.empty().count == 0


def test_commutative_construction():
    range1 = DiscontinuousRange([ZERO_TO_THREE, SEVEN_TO_NINE, FOUR_TO_FIVE])
    range2 = DiscontinuousRange([SEVEN_TO_NINE, FOUR_TO_FIVE, ZERO_TO_THREE])
    _assert_equal(range1, range2)


def test_merging_construction():
    range1 = DiscontinuousRange([TEN_TO_TWENTY, TWENTY_TO_MAX, ZERO_TO_TEN])
    expected = DiscontinuousRange(ZERO_TO_MAX)
    _assert_equal(range1, expected)


def test_union():
    range1 = DiscontinuousRange([TWENTY_TO_MAX, ZERO_TO_TEN])
    range2 = DiscontinuousRange(ZERO_TO_TWENTY)
    expected = DiscontinuousRange(ZERO_TO_MAX)
    _assert_equal(range1.union(range2), expected)


def test_negation():
    range1 = DiscontinuousRange(MIN_TO_ZERO)
    expected = DiscontinuousRange(ZERO_TO_MAX)
    _assert_equal(range1.negate(-sys.float_info.max, sys.float_info.max), expected)


def test_subtract_middle():
    range1 = DiscontinuousRange(MIN_TO_MAX)
    expected = DiscontinuousRange([MIN_TO_ZERO, TWENTY_TO_MAX])
    _assert_equal(range1.subtract(DiscontinuousRange(ZERO_TO_TWENTY)), expected)


def test_subtract_left():
    range1 = DiscontinuousRange(MIN_TO_MAX)
    expected = DiscontinuousRange(ZERO_TO_MAX)
    _assert_equal(range1.subtract(DiscontinuousRange(MIN_TO_ZERO)), expected)


def test_subtract_right():
    range1 = DiscontinuousRange(MIN_TO_MAX)
    expected = DiscontinuousRange(MIN_TO_ZERO)
    _assert_equal(range1.subtract(DiscontinuousRange(ZERO_TO_MAX)), expected)


def test_subtract_all():
    range1 = DiscontinuousRange(TEN_TO_TWENTY)
    expected = DiscontinuousRange.empty()
    _assert_equal(range1.subtract(DiscontinuousRange(ZERO_TO_MAX)), expected)


def test_subtract_left_overlapping():
    range1 = DiscontinuousRange(ZERO_TO_MAX)
    range2 = DiscontinuousRange([MIN_TO_ZERO, ZERO_TO_TWENTY])
    expected = DiscontinuousRange(TWENTY_TO_MAX)
    _assert_equal(range1.subtract(range2), expected)


def test_subtract_ends():
    range1 = DiscontinuousRange(ZERO_TO_MAX)
    range2 = DiscontinuousRange([MIN_TO_ZERO, TWENTY_TO_MAX])
    expected = DiscontinuousRange(ZERO_TO_TWENTY)
    _assert_equal(range1.subtract(range2), expected)


def test_subtract_many():
    range1 = DiscontinuousRange(ZERO_TO_MAX)
    range2 = DiscontinuousRange(
        [MIN_TO_ZERO, ZERO_TO_THREE, THREE_TO_FOUR, FIVE_TO_SEVEN, SEVEN_TO_NINE, TEN_TO_TWENTY]
    )
    expected = DiscontinuousRange([FOUR_TO_FIVE, NINE_TO_TEN, TWENTY_TO_MAX])
    _assert_equal(range1.subtract(range2), expected)

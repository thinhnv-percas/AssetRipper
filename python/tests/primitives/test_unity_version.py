"""
Tests for `assetripper_primitives.UnityVersion`.

This directory sat **empty** from Phase 1 until 2026-08-03, tracked as a known gap in
ROADMAP.md's "Việc lẻ" list. `UnityVersion` comparison is what every single version-gated
branch in this port keys off -- the layout registry's `min_version`, the `>= 2017` array
alignment rule, `get_max_depth_level`'s 2020.2.0a21 boundary, and every layout module's
own internal gates. A comparison bug here would silently pick the wrong layout for a whole
Unity generation, which is precisely the class of silent failure Phase 20 just demonstrated
is real (see ROADMAP.md risk #7).

The partial-comparison behaviour (`equals(2019)` matching any 2019.x.y) gets particular
attention: it's the surprising part of the API, and it's what the registry relies on.
"""
import pytest

from assetripper_primitives import UnityVersion
from assetripper_primitives.unity_version_type import UnityVersionType


def test_default_version_is_all_zeroes():
    version = UnityVersion()
    assert version.equals(0, 0, 0)


def test_ordering_is_by_component_significance():
    assert UnityVersion(2019, 4, 0) < UnityVersion(2020, 1, 0)
    assert UnityVersion(2019, 4, 0) < UnityVersion(2019, 5, 0)
    assert UnityVersion(2019, 4, 0) < UnityVersion(2019, 4, 1)
    assert UnityVersion(5, 6, 0) < UnityVersion(2017, 1, 0), "year-style versions sort above 5.x"


def test_comparison_operators_agree_with_each_other():
    lower, higher = UnityVersion(2019, 4, 0), UnityVersion(2020, 1, 0)
    assert lower < higher and lower <= higher
    assert higher > lower and higher >= lower
    assert not (higher < lower)
    assert UnityVersion(2019, 4, 0) <= UnityVersion(2019, 4, 0)
    assert UnityVersion(2019, 4, 0) >= UnityVersion(2019, 4, 0)


def test_release_type_orders_below_the_same_numbered_release():
    """Unity's own ordering: 2020.2.0a21 (alpha) precedes 2020.2.0f1 (final)."""
    alpha = UnityVersion(2020, 2, 0, UnityVersionType.ALPHA, 21)
    final = UnityVersion(2020, 2, 0, UnityVersionType.FINAL, 1)
    assert alpha < final


def test_type_number_breaks_ties_within_the_same_type():
    assert UnityVersion(2020, 2, 0, UnityVersionType.ALPHA, 5) < UnityVersion(2020, 2, 0, UnityVersionType.ALPHA, 21)


# --- partial comparison: the surprising, load-bearing part -----------------------------------


def test_equals_with_fewer_components_matches_any_value_in_the_rest():
    version = UnityVersion(2019, 4, 7)
    assert version.equals(2019)
    assert version.equals(2019, 4)
    assert version.equals(2019, 4, 7)
    assert not version.equals(2019, 3)
    assert not version.equals(2020)


def test_greater_than_or_equals_is_the_registry_gate():
    """`registry.register(..., min_version=UnityVersion(5, 5, 0))` resolves through this, so
    the boundary must be inclusive on the low side and exclusive below it."""
    assert UnityVersion(5, 5, 0).greater_than_or_equals(5, 5, 0)
    assert UnityVersion(2019, 4, 0).greater_than_or_equals(5, 5, 0)
    assert not UnityVersion(5, 4, 9).greater_than_or_equals(5, 5, 0)


def test_greater_than_or_equals_honours_release_type_at_the_2020_2_0a21_boundary():
    """The exact boundary `get_max_depth_level` uses to choose 7 vs 10 -- an off-by-one in the
    type/type_number comparison would change serialization depth for a whole Unity generation."""
    boundary = (2020, 2, 0, UnityVersionType.ALPHA, 21)
    assert UnityVersion(2020, 2, 0, UnityVersionType.ALPHA, 21).greater_than_or_equals(*boundary)
    assert UnityVersion(2020, 2, 0, UnityVersionType.FINAL, 1).greater_than_or_equals(*boundary)
    assert UnityVersion(2021, 1, 0).greater_than_or_equals(*boundary)
    assert not UnityVersion(2020, 2, 0, UnityVersionType.ALPHA, 20).greater_than_or_equals(*boundary)
    assert not UnityVersion(2020, 1, 9).greater_than_or_equals(*boundary)


def test_less_than_is_the_inverse_of_greater_than_or_equals():
    for version in (UnityVersion(5, 4, 0), UnityVersion(5, 5, 0), UnityVersion(2019, 1, 0)):
        assert version.less_than(5, 5, 0) != version.greater_than_or_equals(5, 5, 0)


# --- parsing / formatting -------------------------------------------------------------------


def test_parse_round_trips_a_full_release_string():
    version = UnityVersion.parse("2022.3.62f2")
    assert version.equals(2022, 3, 62, UnityVersionType.FINAL, 2)
    assert str(version) == "2022.3.62f2"


def test_parse_accepts_a_bare_numeric_version():
    assert UnityVersion.parse("2019.4.0").equals(2019, 4, 0)


def test_try_parse_reports_failure_instead_of_raising():
    ok, _ = UnityVersion.try_parse("not a version")
    assert ok is False

    ok, version = UnityVersion.try_parse("2020.1.5f1")
    assert ok is True
    assert version.equals(2020, 1, 5)


def test_min_version_is_below_every_real_version():
    assert UnityVersion.MIN_VERSION < UnityVersion(3, 5, 0)
    assert UnityVersion.MIN_VERSION < UnityVersion(2022, 3, 62)


def test_min_of_two_versions_returns_the_lower_one():
    lower, higher = UnityVersion(2019, 1, 0), UnityVersion(2021, 1, 0)
    assert UnityVersion.min(lower, higher) is lower
    assert UnityVersion.min(higher, lower) is lower


def test_max_builtin_works_on_versions():
    """`GameBundle.get_max_unity_version` relies on plain `max()` over these."""
    versions = [UnityVersion(2019, 1, 0), UnityVersion(2022, 3, 62), UnityVersion(2020, 2, 0)]
    assert max(versions).equals(2022, 3, 62)


@pytest.mark.parametrize("text", ["2017.1.0f3", "5.6.7p4", "2022.3.62f2"])
def test_str_round_trips_through_parse(text):
    assert str(UnityVersion.parse(text)) == text

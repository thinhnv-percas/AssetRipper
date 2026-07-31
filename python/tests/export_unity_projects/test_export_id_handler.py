"""Port-adjacent tests for Source/AssetRipper.Export.UnityProjects/ExportIdHandler.cs.

test_xxhash_matches_dotnet_reference_vectors pins the `xxhash` PyPI package to known
XxHash32/64 reference vectors for empty input -- this is the one place upstream correctness
depends on a third-party package reproducing .NET's System.IO.Hashing exactly, so it's
worth asserting directly rather than only indirectly through get_pseudo_random_value_*.
"""
from assetripper_export_unity_projects.export_id_handler import (
    MAX_PREFIXED_CLASS_ID_32BIT,
    MAX_PREFIXED_CLASS_ID_64BIT,
    get_main_export_id,
    get_pseudo_random_value_32,
    get_pseudo_random_value_64,
)


def test_xxhash_matches_dotnet_reference_vectors():
    import xxhash

    assert xxhash.xxh64(b"", seed=0).intdigest() == 0xEF46DB3751D8E999
    assert xxhash.xxh32(b"", seed=0).intdigest() == 0x02CC5D05


def test_get_main_export_id_prefixes_by_class_id():
    assert get_main_export_id(49) == 4900000
    assert get_main_export_id(1) == 100000


def test_get_main_export_id_adds_modifier_value():
    assert get_main_export_id(49, 7) == 4900007


def test_get_main_export_id_above_prefix_limit_ignores_modifier():
    huge_class_id = MAX_PREFIXED_CLASS_ID_32BIT + 1
    assert get_main_export_id(huge_class_id) == huge_class_id


def test_get_main_export_id_is_deterministic():
    assert get_main_export_id(28) == get_main_export_id(28)


def test_get_pseudo_random_value_64_is_deterministic_and_signed():
    a = get_pseudo_random_value_64(12345)
    b = get_pseudo_random_value_64(12345)
    assert a == b
    assert -(2**63) <= a < 2**63


def test_get_pseudo_random_value_32_is_deterministic_and_signed():
    a = get_pseudo_random_value_32(12345)
    b = get_pseudo_random_value_32(12345)
    assert a == b
    assert -(2**31) <= a < 2**31


def test_max_prefixed_class_ids_match_upstream_constants():
    assert MAX_PREFIXED_CLASS_ID_64BIT == 9223
    assert MAX_PREFIXED_CLASS_ID_32BIT == 21474

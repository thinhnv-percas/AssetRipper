"""Tests for RawDataObject's dict-like read surface (added after a real-fixture audit,
Phase 13/17): confirmed against a real stripped IL2CPP Android player build
(python/input-test/demo-android.apk) that most classes come through as UnknownObject there
(no embedded type tree, no hand-written layout), and every processor/exporter that calls
`asset.get(...)` on it used to crash with AttributeError.
"""
from assetripper_assets.metadata.asset_info import AssetInfo
from assetripper_import.asset_creation.raw_data_object import UnknownObject, UnreadableObject


def _make(cls):
    return cls(AssetInfo(None, 1, 28), b"\x00\x01\x02")


def test_get_always_returns_the_default():
    asset = _make(UnknownObject)
    assert asset.get("m_Width") is None
    assert asset.get("m_Width", 0) == 0
    assert asset.get("m_Name", "fallback") == "fallback"


def test_contains_and_getitem_report_no_fields():
    asset = _make(UnreadableObject)
    assert "m_Width" not in asset
    assert list(asset.items()) == []
    assert list(asset.keys()) == []
    try:
        asset["m_Width"]
        assert False, "expected KeyError"
    except KeyError:
        pass

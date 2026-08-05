"""Port of Source/AssetRipper.Assets.Tests/PPtrAccessListTests.cs"""
import pytest

from assetripper_assets.generics import PPtrAccessList


def test_empty_list_is_immutable():
    with pytest.raises(NotImplementedError):
        PPtrAccessList.empty().add(None)
    with pytest.raises(NotImplementedError):
        PPtrAccessList.empty().add_new()


def test_empty_list_is_empty():
    assert list(PPtrAccessList.empty()) == []


def test_empty_list_throws_for_accessing_first_element():
    with pytest.raises(IndexError):
        _ = PPtrAccessList.empty()[0]

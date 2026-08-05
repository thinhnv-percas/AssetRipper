"""Port of Source/AssetRipper.Assets.Tests/AssetListTests.cs"""
from assetripper_assets.generics import AssetList


def test_empty_list_to_array():
    lst = AssetList(item_factory=int)
    array = lst.to_array()
    assert array == []


def test_nonempty_list_to_array():
    lst = AssetList(item_factory=int)
    lst.add(1)
    lst.add(2)
    array = lst.to_array()
    assert len(array) == 2

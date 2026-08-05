"""Port of Source/AssetRipper.Assets.Tests/AccessListTests.cs"""
from assetripper_assets.generics import AccessList, AssetList


def test_empty_list_to_array():
    lst = AssetList(item_factory=int)
    access_list = AccessList(lst)
    array = access_list.to_array()
    assert array == []


def test_nonempty_list_to_array():
    lst = AssetList(item_factory=int)
    lst.add(1)
    lst.add(2)
    access_list = AccessList(lst)
    array = access_list.to_array()
    assert len(array) == 2

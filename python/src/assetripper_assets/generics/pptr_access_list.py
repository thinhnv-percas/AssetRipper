"""Port of Source/AssetRipper.Assets/Generics/PPtrAccessList.cs"""
from __future__ import annotations

from .access_list_base import AccessListBase


class PPtrAccessList:
    def __init__(self, list_, collection_or_asset):
        self._list = list_
        from ..collections.asset_collection import AssetCollection

        self._collection = collection_or_asset if isinstance(collection_or_asset, AssetCollection) else collection_or_asset.collection

    @staticmethod
    def empty() -> "PPtrAccessList":
        return PPtrAccessList([], _empty_bundle().collection)

    def __getitem__(self, index: int):
        found, asset = self._list[index].try_get_asset(self._collection)
        return asset if found else None

    def __setitem__(self, index: int, value) -> None:
        self._list[index].set_asset(self._collection, value)

    def add_new(self):
        return self._get_access_list().add_new()

    def add(self, item) -> None:
        self._get_access_list().add_new().set_asset(self._collection, item)

    def add_range(self, items) -> None:
        access_list = self._get_access_list()
        for value in items:
            access_list.add_new().set_asset(self._collection, value)

    def _get_access_list(self) -> AccessListBase:
        if isinstance(self._list, AccessListBase):
            return self._list
        raise NotImplementedError

    @property
    def count(self) -> int:
        return len(self._list)

    def __len__(self) -> int:
        return self.count

    def __iter__(self):
        for i in range(self.count):
            yield self[i]

    def where_not_null(self):
        for i in range(self.count):
            asset = self[i]
            if asset is not None:
                yield asset

    def __str__(self) -> str:
        return f"Count = {self.count}"


_empty_bundle_instance = None


def _empty_bundle():
    global _empty_bundle_instance
    if _empty_bundle_instance is None:
        from ..bundles.bundle import Bundle
        from ..collections.asset_collection import AssetCollection

        class _EmptyAssetCollection(AssetCollection):
            def _is_compatible_dependency(self, dependency) -> bool:
                return False

        class _EmptyBundle(Bundle):
            def __init__(self):
                super().__init__()
                self.collection = _EmptyAssetCollection(self)

            @property
            def name(self) -> str:
                return "EmptyBundle"

            def _is_compatible_bundle(self, bundle) -> bool:
                return False

            def _is_compatible_collection(self, collection) -> bool:
                return isinstance(collection, _EmptyAssetCollection)

        _empty_bundle_instance = _EmptyBundle()
    return _empty_bundle_instance

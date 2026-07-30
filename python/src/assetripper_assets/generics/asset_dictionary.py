"""Port of Source/AssetRipper.Assets/Generics/AssetDictionary.cs"""
from __future__ import annotations

from typing import Callable

from .access_dictionary_base import AccessDictionaryBase
from .asset_pair import AssetPair


class AssetDictionary(AccessDictionaryBase):
    def __init__(self, key_factory: Callable[[], object] = lambda: None, value_factory: Callable[[], object] = lambda: None):
        self._key_factory = key_factory
        self._value_factory = value_factory
        self._pairs: list[AssetPair] = []

    @property
    def count(self) -> int:
        return len(self._pairs)

    @property
    def capacity(self) -> int:
        return len(self._pairs)

    @capacity.setter
    def capacity(self, value: int) -> None:
        if value < len(self._pairs):
            raise ValueError("capacity must not be less than count")

    def add(self, key, value) -> None:
        pair = self.add_new()
        pair.key = key
        pair.value = value

    def add_new(self) -> AssetPair:
        pair = AssetPair(self._key_factory, self._value_factory)
        self._pairs.append(pair)
        return pair

    def get_key(self, index: int):
        return self._pairs[index].key

    def set_key(self, index: int, new_key) -> None:
        self._pairs[index].key = new_key

    def get_value(self, index: int):
        return self._pairs[index].value

    def set_value(self, index: int, new_value) -> None:
        self._pairs[index].value = new_value

    def get_pair(self, index: int) -> AssetPair:
        return self._pairs[index]

    def remove_at(self, index: int) -> None:
        del self._pairs[index]

    def clear(self) -> None:
        self._pairs.clear()

    def try_get_single_pair_for_key(self, key) -> tuple[bool, AssetPair | None]:
        found = None
        for pair in reversed(self._pairs):
            if pair.key == key:
                if found is not None:
                    return False, None
                found = pair
        return (found is not None), found

    def try_get_single_pair_for_value(self, value) -> tuple[bool, AssetPair | None]:
        found = None
        for pair in reversed(self._pairs):
            if pair.value == value:
                if found is not None:
                    return False, None
                found = pair
        return (found is not None), found

    def ensure_capacity(self, capacity: int) -> int:
        if capacity < 0:
            raise ValueError("capacity must be non-negative")
        return len(self._pairs)

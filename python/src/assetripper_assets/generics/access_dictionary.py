"""
Port of Source/AssetRipper.Assets/Generics/AccessDictionary.cs

Delegating wrapper over a reference AssetDictionary, kept for structural parity (see
access_list.py for why Python doesn't need the C# covariance workaround itself).
"""
from __future__ import annotations

from .access_dictionary_base import AccessDictionaryBase
from .access_pair import AccessPair


class AccessDictionary(AccessDictionaryBase):
    def __init__(self, reference_dictionary: AccessDictionaryBase):
        self._reference_dictionary = reference_dictionary

    @property
    def count(self) -> int:
        return self._reference_dictionary.count

    @property
    def capacity(self) -> int:
        return self._reference_dictionary.capacity

    @capacity.setter
    def capacity(self, value: int) -> None:
        self._reference_dictionary.capacity = value

    def add(self, key, value) -> None:
        self._reference_dictionary.add(key, value)

    def add_new(self) -> AccessPair:
        return AccessPair(self._reference_dictionary.add_new())

    def get_key(self, index: int):
        return self._reference_dictionary.get_key(index)

    def set_key(self, index: int, new_key) -> None:
        self._reference_dictionary.set_key(index, new_key)

    def get_value(self, index: int):
        return self._reference_dictionary.get_value(index)

    def set_value(self, index: int, new_value) -> None:
        self._reference_dictionary.set_value(index, new_value)

    def get_pair(self, index: int) -> AccessPair:
        return AccessPair(self._reference_dictionary.get_pair(index))

    def remove_at(self, index: int) -> None:
        self._reference_dictionary.remove_at(index)

    def clear(self) -> None:
        self._reference_dictionary.clear()

    def try_get_single_pair_for_key(self, key) -> tuple[bool, AccessPair | None]:
        found, pair = self._reference_dictionary.try_get_single_pair_for_key(key)
        return (True, AccessPair(pair)) if found else (False, None)

    def try_get_single_pair_for_value(self, value) -> tuple[bool, AccessPair | None]:
        found, pair = self._reference_dictionary.try_get_single_pair_for_value(value)
        return (True, AccessPair(pair)) if found else (False, None)

    def ensure_capacity(self, capacity: int) -> int:
        return self._reference_dictionary.ensure_capacity(capacity)

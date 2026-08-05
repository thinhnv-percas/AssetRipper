"""Port of Source/AssetRipper.Assets/Generics/AccessDictionaryBase.cs

A dictionary-like collection supporting non-unique keys (matching the C# original, which
is index-based rather than hash-bucketed, so multiple pairs may share a key).
"""
from __future__ import annotations

from abc import ABC, abstractmethod


class AccessDictionaryBase(ABC):
    @property
    @abstractmethod
    def count(self) -> int: ...

    @property
    @abstractmethod
    def capacity(self) -> int: ...

    @capacity.setter
    @abstractmethod
    def capacity(self, value: int) -> None: ...

    @abstractmethod
    def add(self, key, value) -> None: ...

    @abstractmethod
    def add_new(self): ...

    @abstractmethod
    def get_key(self, index: int): ...

    @abstractmethod
    def get_value(self, index: int): ...

    @abstractmethod
    def get_pair(self, index: int): ...

    @abstractmethod
    def set_key(self, index: int, new_key) -> None: ...

    @abstractmethod
    def set_value(self, index: int, new_value) -> None: ...

    @abstractmethod
    def remove_at(self, index: int) -> None: ...

    @abstractmethod
    def clear(self) -> None: ...

    @abstractmethod
    def try_get_single_pair_for_key(self, key) -> tuple[bool, object]: ...

    @abstractmethod
    def try_get_single_pair_for_value(self, value) -> tuple[bool, object]: ...

    @property
    def keys(self):
        for i in range(self.count):
            yield self.get_key(i)

    @property
    def values(self):
        for i in range(self.count):
            yield self.get_value(i)

    def contains_key(self, key) -> bool:
        return key in self.keys

    def get_single_pair_for_key(self, key):
        found, pair = self.try_get_single_pair_for_key(key)
        if found:
            return pair
        raise KeyError(f"Key not found: {key}")

    def try_get_key(self, value) -> tuple[bool, object]:
        found, pair = self.try_get_single_pair_for_value(value)
        if found:
            return True, pair.key
        return False, None

    def try_get_value(self, key) -> tuple[bool, object]:
        found, pair = self.try_get_single_pair_for_key(key)
        if found:
            return True, pair.value
        return False, None

    def try_add(self, key, value) -> bool:
        if self.contains_key(key):
            return False
        self.add(key, value)
        return True

    def __getitem__(self, key):
        return self.get_single_pair_for_key(key).value

    def __setitem__(self, key, value) -> None:
        found, pair = self.try_get_single_pair_for_key(key)
        if found:
            pair.value = value
        else:
            self.add(key, value)

    def __len__(self) -> int:
        return self.count

    def __iter__(self):
        for i in range(self.count):
            yield self.get_pair(i)

    def __str__(self) -> str:
        return f"Count = {self.count}"

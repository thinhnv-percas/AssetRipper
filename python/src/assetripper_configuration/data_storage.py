"""Port of Source/AssetRipper.Configuration/DataStorage.cs"""
from __future__ import annotations

from typing import Generic, TypeVar

from .data_entry import DataEntry

T = TypeVar("T", bound=DataEntry)


class DataStorage(Generic[T]):
    def __init__(self):
        self._data: dict[str, T] = {}

    @property
    def keys(self):
        return self._data.keys()

    def __getitem__(self, key: str) -> T | None:
        return self._data.get(key)

    def try_get_value(self, key: str, cls: type | None = None):
        stored = self._data.get(key)
        if stored is None:
            return False, None
        if cls is not None and not isinstance(stored, cls):
            return False, None
        return True, stored

    def get_value(self, key: str, cls: type | None = None) -> T:
        found, value = self.try_get_value(key, cls)
        if not found:
            raise KeyError(key)
        return value

    def add(self, key: str, value: T) -> None:
        if key in self._data:
            raise ValueError(f"An entry with the key '{key}' already exists.")
        self._data[key] = value

    def clear(self) -> None:
        for value in self._data.values():
            value.clear()

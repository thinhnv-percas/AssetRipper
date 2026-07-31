"""Port of Source/AssetRipper.Configuration/SingletonDataStorage.cs"""
from __future__ import annotations

from typing import TypeVar

from .data_instance import DataInstance
from .data_storage import DataStorage
from .string_data_instance import StringDataInstance

T = TypeVar("T")


class SingletonDataStorage(DataStorage[DataInstance]):
    def add_string(self, key: str, value: str) -> None:
        self.add(key, StringDataInstance(value))

    def try_get_stored_value(self, key: str):
        stored = self[key]
        if isinstance(stored, DataInstance):
            return True, stored.value
        return False, None

    def get_stored_value(self, key: str):
        stored = self[key]
        if isinstance(stored, DataInstance):
            return stored.value
        raise KeyError(key)

    def set_stored_value(self, key: str, value) -> None:
        stored = self[key]
        if isinstance(stored, DataInstance):
            stored.value = value
        else:
            raise KeyError(key)

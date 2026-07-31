"""Port of Source/AssetRipper.Configuration/ListDataStorage.cs"""
from __future__ import annotations

from typing import Callable, TypeVar

from .data_set import DataSet
from .data_storage import DataStorage
from .parsable_data_set import ParsableDataSet
from .string_data_set import StringDataSet

T = TypeVar("T")


class ListDataStorage(DataStorage[DataSet]):
    def add_strings(self, key: str, value: list[str]) -> None:
        self.add(key, StringDataSet(value))

    def add_parsable(
        self,
        key: str,
        value: list[T],
        parse: Callable[[str], T],
        create_new: Callable[[], T],
        to_string: Callable[[T], str] = str,
    ) -> None:
        self.add(key, ParsableDataSet(parse, create_new, to_string, value))

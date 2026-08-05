"""Port of Source/AssetRipper.Configuration/DataSet.cs"""
from __future__ import annotations

from typing import Generic, Iterable, Iterator, TypeVar

from .data_entry import DataEntry
from .data_serializer import DataSerializer

T = TypeVar("T")


class _StringAccessor:
    """Port of DataSet.StringAccessor: a string-typed view over a DataSet's elements."""

    def __init__(self, data_set: "DataSet"):
        self._data_set = data_set

    def __getitem__(self, index: int) -> str:
        return self._data_set._get_as_string(index)

    def __setitem__(self, index: int, value: str) -> None:
        self._data_set._set_from_string(index, value)

    def __len__(self) -> int:
        return self._data_set.count

    def add(self, item: str) -> None:
        self._data_set._add_string(item)

    def add_range(self, items: Iterable[str]) -> None:
        self._data_set._add_strings(items)

    def clear(self) -> None:
        self._data_set.clear()

    def remove_at(self, index: int) -> None:
        self._data_set.remove_at(index)

    def __iter__(self) -> Iterator[str]:
        for i in range(self._data_set.count):
            yield self._data_set._get_as_string(i)


class DataSet(DataEntry, Generic[T]):
    def __init__(self, serializer: DataSerializer[T], items: list[T] | None = None):
        self._serializer = serializer
        self._list: list[T] = items if items is not None else []

    @property
    def strings(self) -> _StringAccessor:
        return _StringAccessor(self)

    @property
    def count(self) -> int:
        return len(self._list)

    def __len__(self) -> int:
        return self.count

    def __getitem__(self, index: int) -> T:
        return self._list[index]

    def __setitem__(self, index: int, value: T) -> None:
        self._list[index] = value

    def __iter__(self) -> Iterator[T]:
        return iter(self._list)

    def add(self, item: T) -> None:
        self._list.append(item)

    def add_new(self) -> None:
        self.add(self._serializer.create_new())

    def contains(self, item: T) -> bool:
        return item in self._list

    def clear(self) -> None:
        self._list.clear()

    def remove_at(self, index: int) -> None:
        del self._list[index]

    def _get_as_string(self, index: int) -> str:
        return self._serializer.serialize(self[index])

    def _set_from_string(self, index: int, value: str) -> None:
        self[index] = self._serializer.deserialize(value)

    def _add_string(self, value: str) -> None:
        self.add(self._serializer.deserialize(value))

    def _add_strings(self, values: Iterable[str]) -> None:
        for value in values:
            self._add_string(value)

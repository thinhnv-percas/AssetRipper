"""
Port of Source/AssetRipper.Assets/Generics/AssetList.cs

`item_factory` stands in for C#'s `where T : new()` generic constraint (used by add_new()).
Capacity is tracked only as a hint here -- Python lists grow dynamically, so there's no
real fixed-size backing array to preallocate, unlike the C# original.
"""
from __future__ import annotations

from typing import Callable

from .access_list_base import AccessListBase


class AssetList(AccessListBase):
    def __init__(self, item_factory: Callable[[], object] = lambda: None, initial=None):
        self._item_factory = item_factory
        self._items: list = list(initial) if initial is not None else []

    @property
    def count(self) -> int:
        return len(self._items)

    @property
    def capacity(self) -> int:
        return len(self._items)

    @capacity.setter
    def capacity(self, value: int) -> None:
        if value < len(self._items):
            raise ValueError("capacity must not be less than count")
        # No real preallocation needed for a Python list.

    def __getitem__(self, index: int):
        if index < 0 or index >= len(self._items):
            raise IndexError(index)
        return self._items[index]

    def __setitem__(self, index: int, value) -> None:
        if index < 0 or index >= len(self._items):
            raise IndexError(index)
        self._items[index] = value

    def add(self, item) -> None:
        self._items.append(item)

    def add_new(self):
        item = self._item_factory()
        self._items.append(item)
        return item

    def add_range(self, iterable) -> None:
        self._items.extend(iterable)

    def clear(self) -> None:
        self._items.clear()

    def contains(self, item) -> bool:
        return item in self._items

    def copy_to(self, array: list, array_index: int) -> None:
        for i, item in enumerate(self._items):
            array[array_index + i] = item

    def ensure_capacity(self, capacity: int) -> int:
        if capacity < 0:
            raise ValueError("capacity must be non-negative")
        return len(self._items)

    def index_of(self, item) -> int:
        try:
            return self._items.index(item)
        except ValueError:
            return -1

    def insert(self, index: int, item) -> None:
        if index < 0 or index > len(self._items):
            raise IndexError(index)
        self._items.insert(index, item)

    def remove(self, item) -> bool:
        try:
            self._items.remove(item)
            return True
        except ValueError:
            return False

    def remove_at(self, index: int) -> None:
        if index < 0 or index >= len(self._items):
            raise IndexError(index)
        del self._items[index]

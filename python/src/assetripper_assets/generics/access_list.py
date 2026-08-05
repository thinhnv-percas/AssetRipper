"""
Port of Source/AssetRipper.Assets/Generics/AccessList.cs

C#'s `AccessList<T, TBase>` exists to view a concrete `AssetList<T>` as its base/interface
type `TBase`, working around C# generics' lack of covariance for classes. Python doesn't
need that distinction (a plain list is already covariant at runtime), so this is a thin
delegating wrapper kept mainly for structural parity and because it's directly tested.
"""
from __future__ import annotations

from .access_list_base import AccessListBase


class AccessList(AccessListBase):
    def __init__(self, reference_list: AccessListBase):
        self._reference_list = reference_list

    @property
    def count(self) -> int:
        return self._reference_list.count

    @property
    def capacity(self) -> int:
        return self._reference_list.capacity

    @capacity.setter
    def capacity(self, value: int) -> None:
        self._reference_list.capacity = value

    def __getitem__(self, index: int):
        return self._reference_list[index]

    def __setitem__(self, index: int, value) -> None:
        self._reference_list[index] = value

    def add(self, item) -> None:
        self._reference_list.add(item)

    def add_new(self):
        return self._reference_list.add_new()

    def index_of(self, item) -> int:
        return self._reference_list.index_of(item)

    def insert(self, index: int, item) -> None:
        self._reference_list.insert(index, item)

    def remove_at(self, index: int) -> None:
        self._reference_list.remove_at(index)

    def clear(self) -> None:
        self._reference_list.clear()

    def contains(self, item) -> bool:
        return self._reference_list.contains(item)

    def copy_to(self, array: list, array_index: int) -> None:
        if array_index < 0 or array_index > len(array) - self.count:
            raise IndexError(array_index)
        for i in range(self.count):
            array[i + array_index] = self[i]

    def ensure_capacity(self, capacity: int) -> int:
        return self._reference_list.ensure_capacity(capacity)

    def remove(self, item) -> bool:
        return self._reference_list.remove(item)

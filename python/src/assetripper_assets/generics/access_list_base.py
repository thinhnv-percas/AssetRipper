"""Port of Source/AssetRipper.Assets/Generics/AccessListBase.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class AccessListBase(ABC):
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
    def __getitem__(self, index: int): ...

    @abstractmethod
    def __setitem__(self, index: int, value) -> None: ...

    @abstractmethod
    def add(self, item) -> None: ...

    @abstractmethod
    def add_new(self): ...

    @abstractmethod
    def clear(self) -> None: ...

    @abstractmethod
    def contains(self, item) -> bool: ...

    @abstractmethod
    def ensure_capacity(self, capacity: int) -> int: ...

    @abstractmethod
    def index_of(self, item) -> int: ...

    @abstractmethod
    def insert(self, index: int, item) -> None: ...

    @abstractmethod
    def remove(self, item) -> bool: ...

    @abstractmethod
    def remove_at(self, index: int) -> None: ...

    def __len__(self) -> int:
        return self.count

    def __iter__(self):
        for i in range(self.count):
            yield self[i]

    def to_array(self) -> list:
        return list(self)

    def __str__(self) -> str:
        return f"Count = {self.count}"


def to_pptr_access_list(access_list: AccessListBase, collection):
    from .pptr_access_list import PPtrAccessList

    return PPtrAccessList(access_list, collection)

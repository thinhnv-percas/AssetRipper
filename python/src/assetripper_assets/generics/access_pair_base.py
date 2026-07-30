"""Port of Source/AssetRipper.Assets/Generics/AccessPairBase.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class AccessPairBase(ABC):
    @property
    @abstractmethod
    def key(self): ...

    @key.setter
    @abstractmethod
    def key(self, value) -> None: ...

    @property
    @abstractmethod
    def value(self): ...

    @value.setter
    @abstractmethod
    def value(self, value) -> None: ...

    def __eq__(self, other: object) -> bool:
        if not isinstance(other, AccessPairBase):
            return NotImplemented
        return self.key == other.key and self.value == other.value

    def __hash__(self) -> int:
        return hash((self.key, self.value))

    def __str__(self) -> str:
        return f"{self.key} : {self.value}"

    def __iter__(self):
        yield self.key
        yield self.value

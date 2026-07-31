"""Port of Source/AssetRipper.Configuration/DataSerializer.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod
from typing import Generic, TypeVar

T = TypeVar("T")


class DataSerializer(ABC, Generic[T]):
    @abstractmethod
    def deserialize(self, text: str) -> T: ...

    @abstractmethod
    def serialize(self, value: T) -> str: ...

    @abstractmethod
    def create_new(self) -> T: ...

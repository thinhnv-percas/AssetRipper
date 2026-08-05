"""Port of Source/AssetRipper.Configuration/DataInstance.cs"""
from __future__ import annotations

from typing import Generic, TypeVar

from .data_entry import DataEntry
from .data_serializer import DataSerializer

T = TypeVar("T")


class DataInstance(DataEntry, Generic[T]):
    def __init__(self, serializer: DataSerializer[T], value: T | None = None):
        self._serializer = serializer
        self.value: T = value if value is not None else serializer.create_new()

    @property
    def text(self) -> str:
        return self._serializer.serialize(self.value)

    @text.setter
    def text(self, value: str) -> None:
        self.value = self._serializer.deserialize(value)

    def clear(self) -> None:
        self.value = self._serializer.create_new()

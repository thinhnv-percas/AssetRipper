"""
Port of Source/AssetRipper.Configuration/ParsableDataSerializer.cs

C#'s `IParsable<T>.TryParse` (a static interface member) has no Python equivalent, so
this takes `parse`/`to_string`/`create_new` callables instead of a generic type
constraint -- the natural Python substitute for "any type with a TryParse-like hook".
"""
from __future__ import annotations

from typing import Callable, Generic, TypeVar

from .data_serializer import DataSerializer

T = TypeVar("T")


class ParsableDataSerializer(DataSerializer[T], Generic[T]):
    def __init__(self, parse: Callable[[str], T], create_new: Callable[[], T], to_string: Callable[[T], str] = str):
        self._parse = parse
        self._create_new = create_new
        self._to_string = to_string

    def deserialize(self, text: str) -> T:
        if not text:
            return self.create_new()
        # Forgiving parsing, matching the C# original's TryParse-or-default behavior.
        try:
            return self._parse(text)
        except (ValueError, TypeError):
            return self.create_new()

    def serialize(self, value: T) -> str:
        return self._to_string(value)

    def create_new(self) -> T:
        return self._create_new()

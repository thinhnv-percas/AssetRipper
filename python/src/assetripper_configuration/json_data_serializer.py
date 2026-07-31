"""
Port of Source/AssetRipper.Configuration/JsonDataSerializer.cs

C#'s `JsonTypeInfo<T>` is a System.Text.Json AOT source-gen serialization context; the
natural Python substitute is a plain `to_dict`/`from_dict` callable pair passed to
Python's stdlib `json` module.
"""
from __future__ import annotations

import json
from typing import Callable, Generic, TypeVar

from .data_serializer import DataSerializer

T = TypeVar("T")


class JsonDataSerializer(DataSerializer[T], Generic[T]):
    def __init__(self, create_new: Callable[[], T], to_dict: Callable[[T], object], from_dict: Callable[[object], T]):
        self._create_new = create_new
        self._to_dict = to_dict
        self._from_dict = from_dict

    def deserialize(self, text: str) -> T:
        if not text:
            return self.create_new()
        # Forgiving parsing, matching the C# original's try/catch-or-default behavior.
        try:
            return self._from_dict(json.loads(text))
        except (ValueError, TypeError):
            return self.create_new()

    def serialize(self, value: T) -> str:
        result = json.dumps(self._to_dict(value))
        return "" if result == "null" else result

    def create_new(self) -> T:
        return self._create_new()

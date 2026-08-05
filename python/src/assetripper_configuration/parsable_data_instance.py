"""Port of Source/AssetRipper.Configuration/ParsableDataInstance.cs"""
from __future__ import annotations

from typing import Callable, TypeVar

from .data_instance import DataInstance
from .parsable_data_serializer import ParsableDataSerializer

T = TypeVar("T")


class ParsableDataInstance(DataInstance[T]):
    def __init__(self, parse: Callable[[str], T], create_new: Callable[[], T], to_string: Callable[[T], str] = str):
        super().__init__(ParsableDataSerializer(parse, create_new, to_string))

"""Port of Source/AssetRipper.Configuration/ParsableDataSet.cs"""
from __future__ import annotations

from typing import Callable, TypeVar

from .data_set import DataSet
from .parsable_data_serializer import ParsableDataSerializer

T = TypeVar("T")


class ParsableDataSet(DataSet[T]):
    def __init__(
        self,
        parse: Callable[[str], T],
        create_new: Callable[[], T],
        to_string: Callable[[T], str] = str,
        items: list[T] | None = None,
    ):
        super().__init__(ParsableDataSerializer(parse, create_new, to_string), items)

"""Port of Source/AssetRipper.Configuration/JsonDataSet.cs"""
from __future__ import annotations

from typing import Callable, TypeVar

from .data_set import DataSet
from .json_data_serializer import JsonDataSerializer

T = TypeVar("T")


class JsonDataSet(DataSet[T]):
    def __init__(
        self,
        create_new: Callable[[], T],
        to_dict: Callable[[T], object],
        from_dict: Callable[[object], T],
        items: list[T] | None = None,
    ):
        super().__init__(JsonDataSerializer(create_new, to_dict, from_dict), items)

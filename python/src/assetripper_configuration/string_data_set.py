"""Port of Source/AssetRipper.Configuration/StringDataSet.cs"""
from __future__ import annotations

from .data_set import DataSet
from .string_data_serializer import StringDataSerializer


class StringDataSet(DataSet[str]):
    def __init__(self, items: list[str] | None = None):
        super().__init__(StringDataSerializer.instance(), items)

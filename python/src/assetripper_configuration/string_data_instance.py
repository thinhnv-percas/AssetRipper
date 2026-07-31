"""Port of Source/AssetRipper.Configuration/StringDataInstance.cs"""
from __future__ import annotations

from .data_instance import DataInstance
from .string_data_serializer import StringDataSerializer


class StringDataInstance(DataInstance[str]):
    def __init__(self, value: str | None = None):
        super().__init__(StringDataSerializer.instance(), value)

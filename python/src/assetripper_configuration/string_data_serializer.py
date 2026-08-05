"""Port of Source/AssetRipper.Configuration/StringDataSerializer.cs"""
from __future__ import annotations

from .data_serializer import DataSerializer


class StringDataSerializer(DataSerializer[str]):
    _instance: "StringDataSerializer | None" = None

    def __new__(cls):
        if StringDataSerializer._instance is None:
            StringDataSerializer._instance = super().__new__(cls)
        return StringDataSerializer._instance

    @staticmethod
    def instance() -> "StringDataSerializer":
        return StringDataSerializer()

    def deserialize(self, text: str) -> str:
        return text

    def serialize(self, value: str) -> str:
        return value

    def create_new(self) -> str:
        return ""

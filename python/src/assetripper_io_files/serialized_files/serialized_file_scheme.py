"""Port of Source/AssetRipper.IO.Files/SerializedFiles/SerializedFileScheme.cs"""
from __future__ import annotations

from ..scheme import Scheme
from ..streams.smart import SmartStream
from .serialized_file import SerializedFile


class SerializedFileScheme(Scheme[SerializedFile]):
    _default: "SerializedFileScheme | None" = None

    @staticmethod
    def default() -> "SerializedFileScheme":
        if SerializedFileScheme._default is None:
            SerializedFileScheme._default = SerializedFileScheme()
        return SerializedFileScheme._default

    def can_read(self, stream: SmartStream) -> bool:
        return SerializedFile.is_serialized_file(stream)

    def _create_file(self) -> SerializedFile:
        return SerializedFile()

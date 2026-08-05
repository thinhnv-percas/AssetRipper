"""Port of Source/AssetRipper.IO.Files/WebFiles/WebFileScheme.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType

from ..scheme import Scheme
from .web_file import WebFile


class WebFileScheme(Scheme[WebFile]):
    def can_read(self, stream) -> bool:
        with EndianReader(stream, EndianType.LITTLE_ENDIAN) as reader:
            return WebFile.is_web_file(reader)

    def _create_file(self) -> WebFile:
        return WebFile()

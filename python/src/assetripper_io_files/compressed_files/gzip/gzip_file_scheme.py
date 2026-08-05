"""Port of Source/AssetRipper.IO.Files/CompressedFiles/GZip/GZipFileScheme.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType

from ...scheme import Scheme
from .gzip_file import GZipFile


class GZipFileScheme(Scheme[GZipFile]):
    def can_read(self, stream) -> bool:
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            return GZipFile.is_gzip_file(reader)

    def _create_file(self) -> GZipFile:
        return GZipFile()

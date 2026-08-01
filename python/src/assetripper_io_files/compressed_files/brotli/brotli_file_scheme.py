"""Port of Source/AssetRipper.IO.Files/CompressedFiles/Brotli/BrotliFileScheme.cs"""
from __future__ import annotations

from ...scheme import Scheme
from .brotli_file import BrotliFile


class BrotliFileScheme(Scheme[BrotliFile]):
    def can_read(self, stream) -> bool:
        return BrotliFile.is_brotli_file(stream)

    def _create_file(self) -> BrotliFile:
        return BrotliFile()

"""Port of Source/AssetRipper.IO.Files/BundleFiles/Archive/ArchiveBundleScheme.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType

from ...scheme import Scheme
from .archive_bundle_file import ArchiveBundleFile
from .archive_bundle_header import ArchiveBundleHeader


class ArchiveBundleScheme(Scheme[ArchiveBundleFile]):
    def can_read(self, stream) -> bool:
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            return ArchiveBundleHeader.is_bundle_header(reader)

    def _create_file(self) -> ArchiveBundleFile:
        return ArchiveBundleFile()

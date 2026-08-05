"""Port of Source/AssetRipper.IO.Files/BundleFiles/RawWeb/Raw/RawBundleScheme.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType

from ....scheme import Scheme
from .raw_bundle_file import RawBundleFile
from .raw_bundle_header import RawBundleHeader


class RawBundleScheme(Scheme[RawBundleFile]):
    def can_read(self, stream) -> bool:
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            return RawBundleHeader.is_bundle_header(reader)

    def _create_file(self) -> RawBundleFile:
        return RawBundleFile()

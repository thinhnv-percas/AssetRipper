"""Port of Source/AssetRipper.IO.Files/BundleFiles/RawWeb/Web/WebBundleScheme.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType

from ....scheme import Scheme
from .web_bundle_file import WebBundleFile
from .web_bundle_header import WebBundleHeader


class WebBundleScheme(Scheme[WebBundleFile]):
    def can_read(self, stream) -> bool:
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            return WebBundleHeader.is_bundle_header(reader)

    def _create_file(self) -> WebBundleFile:
        return WebBundleFile()

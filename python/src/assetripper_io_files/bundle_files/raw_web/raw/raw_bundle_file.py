"""Port of Source/AssetRipper.IO.Files/BundleFiles/RawWeb/Raw/RawBundleFile.cs"""
from __future__ import annotations

from ..raw_web_bundle_file import RawWebBundleFile
from .raw_bundle_header import RawBundleHeader


class RawBundleFile(RawWebBundleFile):
    def _create_header(self) -> RawBundleHeader:
        return RawBundleHeader()

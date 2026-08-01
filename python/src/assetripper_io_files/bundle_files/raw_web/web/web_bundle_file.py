"""Port of Source/AssetRipper.IO.Files/BundleFiles/RawWeb/Web/WebBundleFile.cs"""
from __future__ import annotations

from ..raw_web_bundle_file import RawWebBundleFile
from .web_bundle_header import WebBundleHeader


class WebBundleFile(RawWebBundleFile):
    _is_web_variant = True

    def _create_header(self) -> WebBundleHeader:
        return WebBundleHeader()

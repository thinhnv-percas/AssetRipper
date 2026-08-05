"""Port of Source/AssetRipper.IO.Files/BundleFiles/RawWeb/Raw/RawBundleHeader.cs"""
from __future__ import annotations

from ...bundle_header import BundleHeader
from ..raw_web_bundle_header import RawWebBundleHeader

_UNITY_RAW_MAGIC = "UnityRaw"


class RawBundleHeader(RawWebBundleHeader):
    @property
    def _magic_string(self) -> str:
        return _UNITY_RAW_MAGIC

    @staticmethod
    def is_bundle_header(reader) -> bool:
        return BundleHeader._is_bundle_header_signature(reader, _UNITY_RAW_MAGIC)

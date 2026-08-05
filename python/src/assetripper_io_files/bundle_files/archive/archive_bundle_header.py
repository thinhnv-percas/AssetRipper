"""Port of Source/AssetRipper.IO.Files/BundleFiles/Archive/ArchiveBundleHeader.cs"""
from __future__ import annotations

from ..bundle_header import BundleHeader

_UNITY_ARCHIVE_MAGIC = "UnityArchive"


class ArchiveBundleHeader(BundleHeader):
    @property
    def _magic_string(self) -> str:
        return _UNITY_ARCHIVE_MAGIC

    @staticmethod
    def is_bundle_header(reader) -> bool:
        return BundleHeader._is_bundle_header_signature(reader, _UNITY_ARCHIVE_MAGIC)

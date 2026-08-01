"""Port of Source/AssetRipper.IO.Files/BundleFiles/Archive/ArchiveBundle.cs"""
from __future__ import annotations

from ...file_base import FileBase
from .archive_bundle_header import ArchiveBundleHeader


class ArchiveBundleFile(FileBase):
    def __init__(self):
        super().__init__()
        self.header = ArchiveBundleHeader()

    def read(self, stream) -> None:
        raise NotImplementedError

    def write(self, stream) -> None:
        raise NotImplementedError

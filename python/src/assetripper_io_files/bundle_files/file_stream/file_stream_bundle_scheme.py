"""Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/FileStreamBundleScheme.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType

from ...scheme import Scheme
from .file_stream_bundle_file import FileStreamBundleFile
from .file_stream_bundle_header import FileStreamBundleHeader


class FileStreamBundleScheme(Scheme[FileStreamBundleFile]):
    def can_read(self, stream) -> bool:
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            return FileStreamBundleHeader.is_bundle_header(reader)

    def _create_file(self) -> FileStreamBundleFile:
        return FileStreamBundleFile()

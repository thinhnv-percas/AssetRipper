"""Port of Source/AssetRipper.IO.Files/CompressedFiles/GZip/GZipFile.cs

Python's stdlib `gzip` module reads the exact same format as .NET's `GZipStream`
(RFC 1952); `gzip.decompress` additionally handles concatenated gzip members
transparently, a superset of what upstream needs here.
"""
from __future__ import annotations

import gzip

from ...failed_file import FailedFile
from ..compressed_file import CompressedFile

_GZIP_MAGIC = 0x1F8B


class GZipFile(CompressedFile):
    def read(self, stream) -> None:
        from ...resource_files.resource_file import ResourceFile

        try:
            remaining = stream.length - stream.position
            payload = bytearray(remaining)
            stream.read_exactly(payload)
            decompressed = gzip.decompress(bytes(payload))
            self.uncompressed_file = ResourceFile.from_bytes(decompressed, self.file_path, self.name)
        except Exception as ex:  # noqa: BLE001 -- matches upstream's catch-all + FailedFile
            self.uncompressed_file = FailedFile()
            self.uncompressed_file.name = self.name
            self.uncompressed_file.file_path = self.file_path
            self.uncompressed_file.stack_trace = repr(ex)

    def write(self, stream) -> None:
        raise NotImplementedError

    @staticmethod
    def is_gzip_file(reader) -> bool:
        position = reader.base_stream.position
        remaining = reader.base_stream.length - position
        magic = reader.read_uint16() if remaining >= 2 else 0
        reader.base_stream.position = position
        return magic == _GZIP_MAGIC

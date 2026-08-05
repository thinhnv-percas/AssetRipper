"""Port of Source/AssetRipper.IO.Files/CompressedFiles/CompressedFile.cs

`read()` (decompressing the raw bytes into `uncompressed_file`, a plain `ResourceFile`) is
done by each concrete subclass (`gzip.gzip_file.GZipFile`, `brotli.brotli_file.BrotliFile`);
this base class only handles the recursive re-dispatch step common to both: once
decompressed, the bytes might themselves be a more specific format (a bundle file, a
SerializedFile, ...), so `read_contents` hands them back to `scheme_reader` to find out,
exactly like `FileContainer.read_contents` does for its nested resource files.
"""
from __future__ import annotations

from ..file_base import FileBase


class CompressedFile(FileBase):
    def __init__(self):
        super().__init__()
        self.uncompressed_file: FileBase | None = None

    def read_contents(self) -> None:
        from ..resource_files.resource_file import ResourceFile

        if isinstance(self.uncompressed_file, ResourceFile):
            from .. import scheme_reader

            self.uncompressed_file = scheme_reader.read_resource_file(self.uncompressed_file)

    def read_contents_recursively(self) -> None:
        self.read_contents()
        if self.uncompressed_file is not None:
            self.uncompressed_file.read_contents_recursively()

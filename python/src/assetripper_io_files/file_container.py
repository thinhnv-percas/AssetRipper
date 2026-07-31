"""Port of Source/AssetRipper.IO.Files/FileContainer.cs

A container of files (bundles are the concrete FileContainer subclass this port
implements -- see bundle_files/file_stream/file_stream_bundle_file.py). Remains
abstract: FileBase.read/write are still unimplemented here, same as in C#.
"""
from __future__ import annotations

from .failed_file import FailedFile
from .file_base import FileBase


class FileContainer(FileBase):
    def __init__(self):
        super().__init__()
        self._serialized_files: list = []
        self._file_lists: list["FileContainer"] = []
        self._resource_files: list = []
        self._failed_files: list[FailedFile] = []

    def fetch_serialized_files(self):
        yield from self._serialized_files
        for container in self._file_lists:
            yield from container.fetch_serialized_files()

    def add_file(self, file: FileBase | None) -> None:
        """Note: C#'s AddFile also unwraps CompressedFile.UncompressedFile, but
        CompressedFiles (gzip/brotli-wrapped files) aren't ported in this phase."""
        from .resource_files.resource_file import ResourceFile
        from .serialized_files.serialized_file import SerializedFile

        if file is None:
            return
        elif isinstance(file, SerializedFile):
            self.add_serialized_file(file)
        elif isinstance(file, ResourceFile):
            self.add_resource_file(file)
        elif isinstance(file, FileContainer):
            self.add_file_container(file)
        elif isinstance(file, FailedFile):
            self.add_failed_file(file)
        else:
            raise TypeError(type(file))

    def add_serialized_file(self, file) -> None:
        self._serialized_files.append(file)
        self._on_serialized_file_added(file)

    def add_file_container(self, container: "FileContainer") -> None:
        self._file_lists.append(container)
        self._on_file_container_added(container)

    def add_resource_file(self, resource) -> None:
        self._resource_files.append(resource)
        self._on_resource_file_added(resource)

    def add_failed_file(self, file: FailedFile) -> None:
        self._failed_files.append(file)

    def _on_serialized_file_added(self, file) -> None:
        pass

    def _on_file_container_added(self, container: "FileContainer") -> None:
        pass

    def _on_resource_file_added(self, resource) -> None:
        pass

    def read_contents(self) -> None:
        if self._resource_files:
            from . import scheme_reader

            pending = list(self._resource_files)
            self._resource_files.clear()
            for resource_file in pending:
                self.add_file(scheme_reader.read_resource_file(resource_file))

    def read_contents_recursively(self) -> None:
        self.read_contents()
        for container in self._file_lists:
            container.read_contents_recursively()

    @property
    def serialized_files(self) -> list:
        return self._serialized_files

    @property
    def file_lists(self) -> list["FileContainer"]:
        return self._file_lists

    @property
    def resource_files(self) -> list:
        return self._resource_files

    @property
    def failed_files(self) -> list[FailedFile]:
        return self._failed_files

    @property
    def all_files(self):
        yield from self._resource_files
        yield from self._serialized_files
        yield from self._file_lists
        yield from self._failed_files

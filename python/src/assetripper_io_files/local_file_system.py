"""
Port of Source/AssetRipper.IO.Files/LocalFileSystem.cs and LocalFileSystem.g.cs.

As with filesystem.py, the C# .g.cs half is machine-generated boilerplate delegating to
System.IO.* static calls; here it's written directly against Python's os/shutil/glob.
"""
from __future__ import annotations

import glob
import os
import shutil
import tempfile
import uuid

from .filesystem import DirectoryImplementation, FileImplementation, FileSystem, PathImplementation
from .streams.stream import FileStream


class _LocalFileImplementation(FileImplementation):
    def create(self, path: str) -> FileStream:
        return FileStream(path, "w+b")

    def delete(self, path: str) -> None:
        os.remove(path)

    def exists(self, path: str) -> bool:
        return os.path.isfile(path)

    def open_read(self, path: str) -> FileStream:
        return FileStream(path, "rb")

    def open_write(self, path: str) -> FileStream:
        return FileStream(path, "r+b" if os.path.exists(path) else "w+b")

    def read_all_bytes(self, path: str) -> bytes:
        with open(path, "rb") as f:
            return f.read()

    def read_all_text(self, path: str, encoding: str = "utf-8") -> str:
        with open(path, "r", encoding=encoding) as f:
            return f.read()

    def write_all_bytes(self, path: str, data: bytes) -> None:
        with open(path, "wb") as f:
            f.write(data)

    def write_all_text(self, path: str, contents: str, encoding: str = "utf-8") -> None:
        with open(path, "w", encoding=encoding) as f:
            f.write(contents)


class _LocalDirectoryImplementation(DirectoryImplementation):
    def create(self, path: str) -> None:
        os.makedirs(path, exist_ok=True)

    def delete(self, path: str) -> None:
        shutil.rmtree(path)

    def exists(self, path: str) -> bool:
        return os.path.isdir(path)

    def enumerate_directories(self, path: str, search_pattern: str = "*"):
        pattern = os.path.join(path, search_pattern)
        return (p for p in glob.glob(pattern) if os.path.isdir(p))

    def enumerate_files(self, path: str, search_pattern: str = "*"):
        pattern = os.path.join(path, search_pattern)
        return (p for p in glob.glob(pattern) if os.path.isfile(p))


class _LocalPathImplementation(PathImplementation):
    def join(self, *paths: str) -> str:
        return os.path.join(*paths)

    def get_directory_name(self, path: str) -> str | None:
        return os.path.dirname(path)

    def get_extension(self, path: str) -> str:
        return os.path.splitext(path)[1]

    def get_file_name(self, path: str) -> str:
        return os.path.basename(path)

    def get_file_name_without_extension(self, path: str) -> str:
        return os.path.splitext(os.path.basename(path))[0]

    def get_full_path(self, path: str) -> str:
        return os.path.abspath(path)

    def get_relative_path(self, relative_to: str, path: str) -> str:
        return os.path.relpath(path, relative_to)

    def is_path_rooted(self, path: str) -> bool:
        return os.path.isabs(path)


class LocalFileSystem(FileSystem):
    _instance: "LocalFileSystem | None" = None

    def __init__(self):
        super().__init__()
        self._file = _LocalFileImplementation(self)
        self._directory = _LocalDirectoryImplementation(self)
        self._path = _LocalPathImplementation(self)
        self._temporary_directory: str | None = None

    @classmethod
    def instance(cls) -> "LocalFileSystem":
        if cls._instance is None:
            cls._instance = LocalFileSystem()
        return cls._instance

    @property
    def file(self) -> _LocalFileImplementation:
        return self._file

    @property
    def directory(self) -> _LocalDirectoryImplementation:
        return self._directory

    @property
    def path(self) -> _LocalPathImplementation:
        return self._path

    @staticmethod
    def executing_directory() -> str:
        import sys

        return os.path.dirname(os.path.abspath(sys.argv[0]))

    def _local_temporary_directory(self) -> str:
        return self.path.join(self.executing_directory(), "temp", _get_random_string()[:4])

    def _system_temporary_directory(self) -> str:
        return self.path.join(tempfile.gettempdir(), "AssetRipper", _get_random_string()[:4])

    @property
    def temporary_directory(self) -> str:
        if not self._temporary_directory:
            candidate = self._local_temporary_directory()
            try:
                self.directory.create(candidate)
                self.file.write_all_text(self.path.join(candidate, ".WriteTest"), "test")
                self.directory.delete(candidate)
                self._temporary_directory = candidate
            except OSError:
                self._temporary_directory = self._system_temporary_directory()
        return self._temporary_directory

    @temporary_directory.setter
    def temporary_directory(self, value: str) -> None:
        if value and value.strip():
            self._temporary_directory = os.path.abspath(value)


def _get_random_string() -> str:
    return str(uuid.uuid4())

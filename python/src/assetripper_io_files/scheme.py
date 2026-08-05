"""Port of Source/AssetRipper.IO.Files/IScheme.cs and Scheme.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod
from typing import Generic, TypeVar

from .file_base import FileBase
from .streams.smart import SmartStream

T = TypeVar("T", bound=FileBase)


class IScheme(ABC):
    @abstractmethod
    def can_read(self, stream: SmartStream) -> bool:
        """
        Checks if the file can be read by this scheme. Implementations are expected to
        reset `stream` to its initial position.
        """
        ...

    @abstractmethod
    def read(self, stream: SmartStream, file_path: str, file_name: str) -> FileBase: ...


class Scheme(IScheme, Generic[T], ABC):
    @abstractmethod
    def can_read(self, stream: SmartStream) -> bool: ...

    def read(self, stream: SmartStream, file_path: str, file_name: str) -> T:
        file = self._create_file()
        file.file_path = file_path
        file.name = file_name
        file.read(stream)
        return file

    @abstractmethod
    def _create_file(self) -> T:
        """Port of the C# `where T : FileBase, new()` constraint via `T()`."""
        ...

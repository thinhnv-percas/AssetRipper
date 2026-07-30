"""Port of Source/AssetRipper.IO.Files/FileBase.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod

from .special_file_names import fix_file_identifier
from .streams.smart import SmartStream
from .streams.stream import MemoryStream, Stream


class FileBase(ABC):
    """The base class for files."""

    def __init__(self):
        self.file_path: str = ""
        self._name: str = ""
        self._name_fixed: str = ""

    @property
    def name(self) -> str:
        return self._name

    @name.setter
    def name(self, value: str) -> None:
        self._name = value
        self._name_fixed = fix_file_identifier(value)

    @property
    def name_fixed(self) -> str:
        return self._name_fixed

    @abstractmethod
    def read(self, stream: SmartStream) -> None: ...

    @abstractmethod
    def write(self, stream: Stream) -> None: ...

    def read_contents(self) -> None:
        pass

    def read_contents_recursively(self) -> None:
        self.read_contents()

    def to_byte_array(self) -> bytes:
        memory_stream = MemoryStream()
        self.write(memory_stream)
        return memory_stream.to_array()

    def dispose(self) -> None:
        pass

    def __str__(self) -> str:
        return self.name_fixed if self.name_fixed else super().__str__()

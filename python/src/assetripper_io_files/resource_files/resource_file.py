"""Port of Source/AssetRipper.IO.Files/ResourceFiles/ResourceFile.cs"""
from __future__ import annotations

import os

from ..file_base import FileBase
from ..streams.smart import SmartStream

_RESOURCE_FILE_EXTENSION = ".resource"
_STREAMING_FILE_EXTENSION = ".ress"


class ResourceFile(FileBase):
    def __init__(self, stream: SmartStream, file_path: str, name: str):
        super().__init__()
        self.stream = stream.create_reference()
        self.file_path = file_path
        self.name = name

    @staticmethod
    def from_bytes(data: bytes, file_path: str, name: str, writable: bool = True) -> "ResourceFile":
        return ResourceFile(SmartStream.create_memory(bytearray(data), 0, len(data), writable), file_path, name)

    def is_default_resource_file(self) -> bool:
        return ResourceFile.is_default_resource_file_name(self.name)

    @staticmethod
    def is_default_resource_file_name(file_name: str) -> bool:
        extension = os.path.splitext(file_name)[1].lower()
        return extension in (_RESOURCE_FILE_EXTENSION, _STREAMING_FILE_EXTENSION)

    def read(self, stream: SmartStream) -> None:
        raise NotImplementedError

    def write(self, stream) -> None:
        data = self.stream.to_array()
        stream.write(data, 0, len(data))

    def to_byte_array(self) -> bytes:
        return self.stream.to_array()

    def dispose(self) -> None:
        super().dispose()
        self.stream.dispose()

    def __str__(self) -> str:
        return self.name

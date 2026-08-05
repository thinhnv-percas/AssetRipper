"""Port of Source/AssetRipper.IO.Files/WebFiles/WebFileEntry.cs"""
from __future__ import annotations

from dataclasses import dataclass

from ..special_file_names import fix_file_identifier


@dataclass(slots=True)
class WebFileEntry:
    offset: int = 0
    size: int = 0
    name: str = ""

    @staticmethod
    def read(reader) -> "WebFileEntry":
        return WebFileEntry(offset=reader.read_int32(), size=reader.read_int32(), name=reader.read_string())

    def write(self, writer) -> None:
        writer.write_int32(self.offset)
        writer.write_int32(self.size)
        writer.write_string(self.name)

    def __str__(self) -> str:
        return fix_file_identifier(self.name)

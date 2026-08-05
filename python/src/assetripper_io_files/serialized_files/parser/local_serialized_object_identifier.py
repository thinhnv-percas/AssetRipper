"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/LocalSerializedObjectIdentifier.cs"""
from __future__ import annotations

from dataclasses import dataclass

from .object_info import is_long_id


@dataclass(slots=True)
class LocalSerializedObjectIdentifier:
    local_serialized_file_index: int = 0
    local_identifier_in_file: int = 0

    def read(self, reader) -> None:
        self.local_serialized_file_index = reader.read_int32()
        if is_long_id(reader.generation):
            reader.align_stream()
            self.local_identifier_in_file = reader.read_int64()
        else:
            self.local_identifier_in_file = reader.read_int32()

    def write(self, writer) -> None:
        writer.write_int32(self.local_serialized_file_index)
        if is_long_id(writer.generation):
            writer.align_stream()
            writer.write_int64(self.local_identifier_in_file)
        else:
            writer.write_int32(self.local_identifier_in_file)

    def __str__(self) -> str:
        return f"[{self.local_serialized_file_index}, {self.local_identifier_in_file}]"

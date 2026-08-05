"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/SerializedTypeBase.Hash128.cs"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass(frozen=True, slots=True)
class Hash128:
    element0: int = 0
    element1: int = 0
    element2: int = 0
    element3: int = 0

    @staticmethod
    def read(reader) -> "Hash128":
        return Hash128(reader.read_uint32(), reader.read_uint32(), reader.read_uint32(), reader.read_uint32())

    def write(self, writer) -> None:
        writer.write_uint32(self.element0)
        writer.write_uint32(self.element1)
        writer.write_uint32(self.element2)
        writer.write_uint32(self.element3)

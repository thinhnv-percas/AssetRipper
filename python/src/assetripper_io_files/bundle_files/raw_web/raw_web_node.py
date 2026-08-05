"""Port of Source/AssetRipper.IO.Files/BundleFiles/RawWeb/RawWebNode.cs"""
from __future__ import annotations

from ..node import Node


class RawWebNode(Node):
    @staticmethod
    def read(reader) -> "RawWebNode":
        node = RawWebNode()
        node.path = reader.read_string_zero_term()
        node.offset = reader.read_int32()
        node.size = reader.read_int32()
        return node

    def write(self, writer) -> None:
        writer.write_string_zero_term(self.path)
        writer.write_int32(self.offset)
        writer.write_int32(self.size)

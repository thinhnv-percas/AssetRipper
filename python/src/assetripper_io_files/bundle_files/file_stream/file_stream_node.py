"""Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/FileStreamNode.cs"""
from __future__ import annotations

from ..node import Node
from .node_flags import NodeFlags


class FileStreamNode(Node):
    def __init__(self):
        super().__init__()
        self.flags: NodeFlags = NodeFlags.DEFAULT

    @staticmethod
    def read(reader) -> "FileStreamNode":
        node = FileStreamNode()
        node.offset = reader.read_int64()
        node.size = reader.read_int64()
        node.flags = NodeFlags(reader.read_int32())
        node.path = reader.read_string_zero_term()
        return node

    def write(self, writer) -> None:
        writer.write_int64(self.offset)
        writer.write_int64(self.size)
        writer.write_int32(int(self.flags))
        writer.write_string_zero_term(self.path)

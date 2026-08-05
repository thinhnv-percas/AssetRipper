"""Port of Source/AssetRipper.IO.Files/BundleFiles/DirectoryInfo.cs

C#'s `DirectoryInfo<T> where T : Node, IEndianReadable<T>` is specialized here to
FileStreamNode directly, since FileStreamNode is the only Node subclass this port
implements (see bundle_files/__init__.py for the scope note on legacy node types).
"""
from __future__ import annotations

from dataclasses import dataclass, field
from typing import TYPE_CHECKING

if TYPE_CHECKING:
    from .file_stream.file_stream_node import FileStreamNode


@dataclass(slots=True)
class DirectoryInfo:
    nodes: "list[FileStreamNode]" = field(default_factory=list)

    @staticmethod
    def read(reader) -> "DirectoryInfo":
        from .file_stream.file_stream_node import FileStreamNode

        count = reader.read_int32()
        return DirectoryInfo([FileStreamNode.read(reader) for _ in range(count)])

    def write(self, writer) -> None:
        writer.write_int32(len(self.nodes))
        for node in self.nodes:
            node.write(writer)

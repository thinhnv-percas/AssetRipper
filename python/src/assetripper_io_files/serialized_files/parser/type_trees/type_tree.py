"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/TypeTrees/TypeTree.cs"""
from __future__ import annotations

from dataclasses import dataclass, field

from assetripper_io_endian import EndianReader, EndianType

from . import common_string
from .type_tree_node import TypeTreeNode, is_format5


@dataclass(slots=True)
class TypeTree:
    nodes: list[TypeTreeNode] = field(default_factory=list)
    string_buffer: bytes = b""

    def read(self, reader) -> None:
        if is_format5(reader.generation):
            nodes_count = reader.read_int32()
            if nodes_count < 0:
                raise ValueError(f"Node count cannot be negative: {nodes_count}")

            string_buffer_size = reader.read_int32()
            if string_buffer_size < 0:
                raise ValueError(f"String buffer size cannot be negative: {string_buffer_size}")

            self.nodes = []
            for _ in range(nodes_count):
                node = TypeTreeNode()
                node.read(reader)
                self.nodes.append(node)

            self.string_buffer = reader.read_bytes(string_buffer_size) if string_buffer_size else b""
            self._set_names_from_buffer()
        else:
            self.nodes = []
            _read_tree_node(reader, self.nodes, 0)

    def _set_names_from_buffer(self) -> None:
        custom_types: dict[int, str] = {}
        from assetripper_io_files.streams.stream import MemoryStream

        stream = MemoryStream(self.string_buffer)
        endian_reader = EndianReader(stream, EndianType.LITTLE_ENDIAN)
        while stream.position < stream.length:
            position = stream.position
            name = endian_reader.read_string_zero_term()
            custom_types[position] = name

        def get_type_name(value: int) -> str:
            is_custom_type = (value & 0x80000000) == 0
            if is_custom_type:
                return custom_types[value]
            else:
                offset = value & ~0x80000000
                name = common_string.STRING_BUFFER.get(offset)
                if name is None:
                    raise Exception(f"Unsupported asset class type name '{offset}'")
                return name

        for node in self.nodes:
            node.type = get_type_name(node.type_str_offset)
            node.name = get_type_name(node.name_str_offset)

    def build_string_buffer(self) -> None:
        """Compute `string_buffer` and each node's type/name offsets from its `type`/`name`.

        Addition beyond the C# original: upstream's `TypeTree.Write` only re-emits the
        `StringBuffer` it read from a file, so a tree whose nodes were constructed
        programmatically would be written with all offsets still zero and an empty buffer.
        Call this before `write()` when building a tree by hand.

        Names present in the shared CommonString table are referenced through it with the
        0x80000000 flag set, exactly as Unity does; anything else is appended to this
        tree's own buffer (deduplicated).
        """
        common = {name: offset for offset, name in common_string.STRING_BUFFER.items()}
        buffer = bytearray()
        local: dict[str, int] = {}

        def offset_for(value: str) -> int:
            common_offset = common.get(value)
            if common_offset is not None:
                return 0x80000000 | common_offset
            existing = local.get(value)
            if existing is not None:
                return existing
            offset = len(buffer)
            local[value] = offset
            buffer.extend(value.encode("utf-8"))
            buffer.append(0)
            return offset

        for node in self.nodes:
            node.type_str_offset = offset_for(node.type)
            node.name_str_offset = offset_for(node.name)
        self.string_buffer = bytes(buffer)

    def write(self, writer) -> None:
        if is_format5(writer.generation):
            writer.write_int32(len(self.nodes))
            writer.write_int32(len(self.string_buffer))
            for node in self.nodes:
                node.write(writer)
            writer.write_bytes(self.string_buffer)
        else:
            _write_tree_node(writer, self.nodes, [0])

    def __str__(self) -> str:
        if not self.nodes:
            return "TypeTree"
        return str(self.nodes[0])

    @property
    def dump(self) -> str:
        lines = []
        for node in self.nodes:
            lines.append("\t" * node.level + f"{node.type} {node.name}" +
                          f" // ByteSize{{{node.byte_size:x}}}, Index{{{node.index:x}}}, "
                          f"Version{{{node.version:x}}}, IsArray{{{node.type_flags}}}, "
                          f"MetaFlag{{{int(node.meta_flag):x}}}")
        return "\n".join(lines) + ("\n" if lines else "")


def _read_tree_node(reader, nodes: list[TypeTreeNode], depth: int) -> None:
    node = TypeTreeNode()
    node.read(reader)
    node.level = depth
    nodes.append(node)

    child_count = reader.read_int32()
    for _ in range(child_count):
        _read_tree_node(reader, nodes, depth + 1)


def _write_tree_node(writer, nodes: list[TypeTreeNode], index: list[int]) -> None:
    i = index[0]
    nodes[i].write(writer)
    child_count = _get_child_count(nodes, i)
    writer.write_int32(child_count)
    index[0] += 1
    for _ in range(child_count):
        _write_tree_node(writer, nodes, index)


def _get_child_count(nodes: list[TypeTreeNode], index: int) -> int:
    count = 0
    depth = nodes[index].level + 1
    for i in range(index + 1, len(nodes)):
        node_depth = nodes[i].level
        if node_depth < depth:
            break
        if node_depth == depth:
            count += 1
    return count

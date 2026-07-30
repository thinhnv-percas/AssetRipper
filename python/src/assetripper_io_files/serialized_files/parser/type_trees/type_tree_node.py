"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/TypeTrees/TypeTreeNode.cs"""
from __future__ import annotations

from dataclasses import dataclass, field

from ...format_version import FormatVersion
from ...transfer_meta_flags import TransferMetaFlags


def is_format5(generation: FormatVersion) -> bool:
    """Approximately 5.0.0a1 and greater. Generation 10 or 12+."""
    return generation == FormatVersion.UNKNOWN_10 or generation >= FormatVersion.UNKNOWN_12


def has_ref_type_hash(generation: FormatVersion) -> bool:
    """2019.1 and greater. Generation 19+."""
    return generation >= FormatVersion.TYPE_TREE_NODE_WITH_TYPE_FLAGS


@dataclass(slots=True)
class TypeTreeNode:
    version: int = 0
    """Field type version: starts with 1, incremented after significant type-info updates.
    Equal to serializedVersion in Yaml format files."""
    level: int = 0
    """Depth of the current type relative to root."""
    type_flags: int = 0
    """Array flag: set to 1 if type is "Array" or "TypelessData"."""
    type_str_offset: int = 0
    """Type offset in the TypeTree's string buffer."""
    name_str_offset: int = 0
    """Name offset in the TypeTree's string buffer."""
    type: str = ""
    """Name of the data type: any substructure or a static predefined type."""
    name: str = ""
    """Name of the field."""
    byte_size: int = 0
    """Size of the data value in bytes (-1 means an array somewhere inside its hierarchy).
    Padding for alignment is not included."""
    index: int = 0
    """Index of the field, unique within a tree. Normally starts at 0."""
    meta_flag: TransferMetaFlags = TransferMetaFlags.NO_TRANSFER_FLAGS
    ref_type_hash: int = 0

    def read(self, reader) -> None:
        if is_format5(reader.generation):
            self.version = reader.read_uint16()
            self.level = reader.read_byte()
            self.type_flags = reader.read_byte()
            self.type_str_offset = reader.read_uint32()
            self.name_str_offset = reader.read_uint32()
            self.byte_size = reader.read_int32()
            self.index = reader.read_int32()
            self.meta_flag = TransferMetaFlags(reader.read_uint32())
            if has_ref_type_hash(reader.generation):
                self.ref_type_hash = reader.read_uint64()
        else:
            self.type = reader.read_string_zero_term()
            self.name = reader.read_string_zero_term()
            self.byte_size = reader.read_int32()
            self.index = reader.read_int32()
            self.type_flags = reader.read_int32()
            self.version = reader.read_int32()
            self.meta_flag = TransferMetaFlags(reader.read_uint32())

    def write(self, writer) -> None:
        if is_format5(writer.generation):
            writer.write_uint16(self.version)
            writer.write_byte(self.level)
            writer.write_byte(self.type_flags)
            writer.write_uint32(self.type_str_offset)
            writer.write_uint32(self.name_str_offset)
            writer.write_int32(self.byte_size)
            writer.write_int32(self.index)
            writer.write_uint32(int(self.meta_flag))
            if has_ref_type_hash(writer.generation):
                writer.write_uint64(self.ref_type_hash)
        else:
            writer.write_string_zero_term(self.type)
            writer.write_string_zero_term(self.name)
            writer.write_int32(self.byte_size)
            writer.write_int32(self.index)
            writer.write_int32(self.type_flags)
            writer.write_int32(self.version)
            writer.write_uint32(int(self.meta_flag))

    def __str__(self) -> str:
        if not self.type:
            return "TypeTreeNode"
        return f"{self.type} {self.name}"

"""Port of Source/AssetRipper.IO.Files/SerializedFiles/IO/SerializedWriter.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianType, EndianWriter
from assetripper_primitives import UnityVersion

from ..format_version import FormatVersion


class SerializedWriter(EndianWriter):
    def __init__(self, stream, endianess: EndianType, generation: FormatVersion, version: UnityVersion):
        super().__init__(stream, endianess)
        self.generation = generation
        self.version = version

    def write_file_identifier_array(self, array) -> None:
        self.write_int32(len(array))
        for item in array:
            item.write(self)

    def write_local_serialized_object_identifier_array(self, array) -> None:
        self.write_int32(len(array))
        for item in array:
            item.write(self)

    def write_object_info_array(self, array) -> None:
        self.write_int32(len(array))

        byte_start = 0
        for object_info in array:
            object_info.write(self, byte_start)
            byte_start += len(object_info.object_data)

            # each object data must be aligned to 8 bytes
            remainder = byte_start & 0b111
            padding = (8 - remainder) & 0b111
            byte_start += padding

    def write_serialized_type_array(self, array, has_type_tree: bool) -> None:
        self.write_int32(len(array))
        for item in array:
            item.write(self, has_type_tree)

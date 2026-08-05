"""Port of Source/AssetRipper.IO.Files/SerializedFiles/IO/SerializedReader.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType
from assetripper_primitives import UnityVersion

from ..format_version import FormatVersion
from ..parser.file_identifier import FileIdentifier
from ..parser.local_serialized_object_identifier import LocalSerializedObjectIdentifier
from ..parser.object_info import ObjectInfo


class SerializedReader(EndianReader):
    def __init__(self, stream, endianess: EndianType, generation: FormatVersion):
        super().__init__(stream, endianess)
        self.generation = generation
        self.version: UnityVersion = UnityVersion()
        """Gets set after reading the metadata version."""

    def read_file_identifier_array(self) -> list[FileIdentifier]:
        count = self.read_int32()
        array = []
        for _ in range(count):
            instance = FileIdentifier()
            instance.read(self)
            array.append(instance)
        return array

    def read_local_serialized_object_identifier_array(self) -> list[LocalSerializedObjectIdentifier]:
        count = self.read_int32()
        array = []
        for _ in range(count):
            instance = LocalSerializedObjectIdentifier()
            instance.read(self)
            array.append(instance)
        return array

    def read_serialized_type_array(self, factory, has_type_tree: bool) -> list:
        """`factory` is the SerializedTypeBase subclass to instantiate (SerializedType or
        SerializedTypeReference) -- Python's stand-in for the C# `where T : ..., new()`
        generic constraint."""
        count = self.read_int32()
        array = []
        for _ in range(count):
            instance = factory()
            instance.read(self, has_type_tree)
            array.append(instance)
        return array

    def read_object_info_array(self, long_file_id: bool, types, data_offset: int) -> list[ObjectInfo]:
        count = self.read_int32()
        array = []
        for _ in range(count):
            instance = ObjectInfo()
            instance.read(self, long_file_id, types, data_offset)
            array.append(instance)
        return array

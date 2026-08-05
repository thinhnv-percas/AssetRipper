"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/SerializedFileMetadata.cs"""
from __future__ import annotations

from dataclasses import dataclass, field

from assetripper_primitives import UnityVersion

from assetripper_io_endian import EndianType

from ...build_target import BuildTarget
from ..format_version import FormatVersion
from ..io.serialized_reader import SerializedReader
from ..io.serialized_writer import SerializedWriter
from .file_identifier import FileIdentifier
from .local_serialized_object_identifier import LocalSerializedObjectIdentifier
from .object_info import ObjectInfo
from .serialized_file_header import SerializedFileHeader
from .serialized_type import SerializedType
from .serialized_type_reference import SerializedTypeReference


def has_endian(generation: FormatVersion) -> bool:
    """Less than 3.5.0."""
    return generation < FormatVersion.UNKNOWN_9


def is_metadata_at_the_end(generation: FormatVersion) -> bool:
    """Less than 3.5.0."""
    return generation < FormatVersion.UNKNOWN_9


def has_signature(generation: FormatVersion) -> bool:
    """3.0.0b and greater."""
    return generation >= FormatVersion.UNKNOWN_7


def has_platform(generation: FormatVersion) -> bool:
    """3.0.0 and greater."""
    return generation >= FormatVersion.UNKNOWN_8


def has_enable_type_tree(generation: FormatVersion) -> bool:
    """5.0.0Unk2 and greater."""
    return generation >= FormatVersion.HAS_TYPE_TREE_HASHES


def has_long_file_id(generation: FormatVersion) -> bool:
    """3.0.0b to 4.x.x."""
    return generation >= FormatVersion.UNKNOWN_7 and generation < FormatVersion.UNKNOWN_14


def has_script_types(generation: FormatVersion) -> bool:
    """5.0.0Unk0 and greater."""
    return generation >= FormatVersion.HAS_SCRIPT_TYPE_INDEX


def has_user_information(generation: FormatVersion) -> bool:
    """1.2.0 and greater."""
    return generation >= FormatVersion.UNKNOWN_5


def has_ref_types(generation: FormatVersion) -> bool:
    """2019.2 and greater."""
    return generation >= FormatVersion.SUPPORTS_REF_OBJECT


@dataclass(slots=True)
class SerializedFileMetadata:
    unity_version: UnityVersion = field(default_factory=UnityVersion)
    target_platform: BuildTarget = BuildTarget.NO_TARGET
    enable_type_tree: bool = False
    types: list[SerializedType] = field(default_factory=list)
    long_file_id: int = 0
    """Indicates that ObjectInfo.file_id is 8 bytes. Serialized files with this enabled
    supposedly don't exist."""
    swap_endianess: bool = False
    object: list[ObjectInfo] = field(default_factory=list)
    script_types: list[LocalSerializedObjectIdentifier] = field(default_factory=list)
    externals: list[FileIdentifier] = field(default_factory=list)
    user_information: str = ""
    ref_types: list[SerializedTypeReference] = field(default_factory=list)

    def read(self, stream, header: SerializedFileHeader) -> None:
        swap_endianess = self._read_swap_endianess(stream, header)
        endianess = EndianType.BIG_ENDIAN if swap_endianess else EndianType.LITTLE_ENDIAN
        with SerializedReader(stream, endianess, header.version) as reader:
            self._read(reader, header.data_offset)

    def _read_swap_endianess(self, stream, header: SerializedFileHeader) -> bool:
        if has_endian(header.version):
            num = stream.read_byte()
            # This is not and should not be aligned. Alignment only happens for the
            # endian boolean on version 9 and greater, coinciding with endianess being
            # stored in the header on version 9 and greater.
            if num < 0:
                raise EOFError
            self.swap_endianess = num != 0
            return self.swap_endianess
        else:
            return header.endianess

    def _read(self, reader: SerializedReader, data_offset: int) -> None:
        if has_signature(reader.generation):
            signature = reader.read_string_zero_term()
            ok, version = UnityVersion.try_parse(signature)
            if not ok:
                # Assume version is stripped if it can't be parsed.
                version = UnityVersion()
            self.unity_version = version
            reader.version = version
        if has_platform(reader.generation):
            self.target_platform = BuildTarget(reader.read_uint32())

        self.enable_type_tree = self._read_enable_type_tree(reader)

        self.types = reader.read_serialized_type_array(SerializedType, self.enable_type_tree)

        if has_long_file_id(reader.generation):
            self.long_file_id = reader.read_uint32()

        self.object = reader.read_object_info_array(self.long_file_id != 0, self.types, data_offset)

        if has_script_types(reader.generation):
            self.script_types = reader.read_local_serialized_object_identifier_array()

        self.externals = reader.read_file_identifier_array()

        if has_ref_types(reader.generation):
            self.ref_types = reader.read_serialized_type_array(SerializedTypeReference, self.enable_type_tree)
        if has_user_information(reader.generation):
            self.user_information = reader.read_string_zero_term()

    @staticmethod
    def _read_enable_type_tree(reader: SerializedReader) -> bool:
        if has_enable_type_tree(reader.generation):
            return reader.read_boolean()
        return True

    def write(self, writer: SerializedWriter) -> None:
        if has_endian(writer.generation):
            writer.write_byte(1 if writer.endian_type == EndianType.BIG_ENDIAN else 0)
        if has_signature(writer.generation):
            writer.write_string_zero_term(str(self.unity_version))
        if has_platform(writer.generation):
            writer.write_uint32(int(self.target_platform))
        if has_enable_type_tree(writer.generation):
            writer.write_boolean(self.enable_type_tree)

        enable_type_tree = not has_enable_type_tree(writer.generation) or self.enable_type_tree
        writer.write_serialized_type_array(self.types, enable_type_tree)
        if has_long_file_id(writer.generation):
            writer.write_uint32(self.long_file_id)

        writer.write_object_info_array(self.object)

        if has_script_types(writer.generation):
            writer.write_local_serialized_object_identifier_array(self.script_types)
        writer.write_file_identifier_array(self.externals)
        if has_ref_types(writer.generation):
            writer.write_serialized_type_array(self.ref_types, self.enable_type_tree)
        if has_user_information(writer.generation):
            writer.write_string_zero_term(self.user_information)

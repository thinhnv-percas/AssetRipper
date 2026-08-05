"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/ObjectInfo.cs

Contains information for a block of raw serialized object data.
"""
from __future__ import annotations

from dataclasses import dataclass, field

from ..format_version import FormatVersion


def is_long_id(generation: FormatVersion) -> bool:
    """5.0.0unk and greater / Format Version at least 14."""
    return generation >= FormatVersion.UNKNOWN_14


def has_class_id(generation: FormatVersion) -> bool:
    """Less than 5.5.0 / Format Version less than 16."""
    return generation < FormatVersion.REFACTORED_CLASS_ID


def has_is_destroyed(generation: FormatVersion) -> bool:
    """Less than 5.0.0unk / Format Version less than 11."""
    return generation < FormatVersion.HAS_SCRIPT_TYPE_INDEX


def has_script_type_index(generation: FormatVersion) -> bool:
    """5.0.0unk to 5.5.0unk exclusive / Format Version at least 11 but less than 17."""
    return generation >= FormatVersion.HAS_SCRIPT_TYPE_INDEX and generation < FormatVersion.REFACTOR_TYPE_DATA


def has_stripped(generation: FormatVersion) -> bool:
    """5.0.1 to 5.5.0unk exclusive / Format Version at least 15 but less than 17."""
    return generation >= FormatVersion.SUPPORTS_STRIPPED_OBJECT and generation < FormatVersion.REFACTOR_TYPE_DATA


def has_serialized_type_index(generation: FormatVersion) -> bool:
    """5.5.0unk and greater / Format Version at least 17."""
    return generation >= FormatVersion.REFACTOR_TYPE_DATA


def has_large_files_support(generation: FormatVersion) -> bool:
    """2020.1.0 and greater / Format Version at least 22."""
    return generation >= FormatVersion.LARGE_FILES_SUPPORT


@dataclass(slots=True)
class ObjectInfo:
    file_id: int = 0
    """ObjectID: unique ID that identifies the object. Can be used as a key for a map."""
    type_id: int = 0
    """Type ID of the object, mapped to SerializedType.type_id.
    Equal to class_id if the object is not MonoBehaviour."""
    serialized_type_index: int = 0
    """Type index in SerializedFileMetadata.types."""
    class_id: int = 0
    """Class ID of the object."""
    is_destroyed: int = 0
    script_type_index: int = 0
    stripped: bool = False
    type: object = None
    """The resolved SerializedType, if any."""
    object_data: bytes = b""
    """The data for the object."""

    def __init__(self, type=None):
        self.file_id = 0
        self.type_id = 0
        self.serialized_type_index = 0
        self.class_id = 0
        self.is_destroyed = 0
        self.script_type_index = 0
        self.stripped = False
        self.type = type
        self.object_data = b""
        if type is not None:
            self.type_id = type.type_id
            if -32768 <= type.type_id <= 32767:
                self.class_id = type.type_id
            self.script_type_index = type.script_type_index
            self.stripped = type.is_stripped_type

    def read(self, reader, long_file_id: bool, types, data_offset: int) -> None:
        if is_long_id(reader.generation):
            reader.align_stream()
            self.file_id = reader.read_int64()
        else:
            self.file_id = reader.read_int32()

        # Offset to the object data, relative to SerializedFileHeader.data_offset.
        if has_large_files_support(reader.generation):
            byte_start = reader.read_int64()
        else:
            byte_start = reader.read_uint32()

        byte_size = reader.read_int32()

        # Read object data
        current_position = reader.base_stream.position
        data_position = data_offset + byte_start
        reader.base_stream.position = data_position
        self.object_data = reader.read_bytes(byte_size)
        reader.base_stream.position = current_position

        if has_serialized_type_index(reader.generation):
            self.serialized_type_index = reader.read_int32()
        else:
            self.serialized_type_index = -1
            self.type_id = reader.read_int32()
        if has_class_id(reader.generation):
            self.class_id = reader.read_int16()
        if has_script_type_index(reader.generation):
            self.script_type_index = reader.read_int16()
        elif has_is_destroyed(reader.generation):
            self.is_destroyed = reader.read_uint16()

        stripped: bool | None
        if has_stripped(reader.generation):
            self.stripped = reader.read_boolean()
            stripped = self.stripped
        else:
            self.stripped = False
            stripped = None

        self.type = _get_serialized_type(types, self.serialized_type_index, self.type_id, self.stripped, stripped)
        if self.type is not None:
            self.type_id = self.type.type_id
            if not has_class_id(reader.generation) and -32768 <= self.type.type_id <= 32767:
                self.class_id = self.type.type_id
            if not has_script_type_index(reader.generation):
                self.script_type_index = self.type.script_type_index
            if not has_stripped(reader.generation):
                self.stripped = self.type.is_stripped_type

    def write(self, writer, byte_start: int) -> None:
        if is_long_id(writer.generation):
            writer.align_stream()
            writer.write_int64(self.file_id)
        else:
            writer.write_int32(self.file_id)

        if has_large_files_support(writer.generation):
            writer.write_int64(byte_start)
        else:
            writer.write_uint32(byte_start)

        writer.write_int32(len(self.object_data))
        if has_serialized_type_index(writer.generation):
            writer.write_int32(self.serialized_type_index)
        else:
            writer.write_int32(self.type_id)
        if has_class_id(writer.generation):
            writer.write_int16(self.class_id)
        if has_script_type_index(writer.generation):
            writer.write_int16(self.script_type_index)
        elif has_is_destroyed(writer.generation):
            writer.write_uint16(self.is_destroyed)
        if has_stripped(writer.generation):
            writer.write_boolean(self.stripped)

    def __str__(self) -> str:
        return f"{self.class_id}[{self.file_id}]"

    def __eq__(self, other: object) -> bool:
        if not isinstance(other, ObjectInfo):
            return NotImplemented
        return (
            self.file_id == other.file_id
            and self.type_id == other.type_id
            and self.serialized_type_index == other.serialized_type_index
            and self.class_id == other.class_id
            and self.is_destroyed == other.is_destroyed
            and self.script_type_index == other.script_type_index
            and self.stripped == other.stripped
            and self.type == other.type
            and self.object_data == other.object_data
        )


def _get_serialized_type(types, serialized_type_index: int, type_id: int, stripped_field: bool, stripped: bool | None):
    if serialized_type_index >= 0:
        return types[serialized_type_index]
    elif len(types) == 0:
        return None  # It's common on Unity 4 and lower for the array to be empty.
    else:
        result = None
        for t in types:
            if t.type_id == type_id:
                if stripped is not None and t.is_stripped_type != stripped:
                    pass  # caller specified a stripped value that doesn't match; skip
                elif result is None:
                    result = t
                else:
                    raise Exception(f"Multiple types with the same ID {type_id} and stripped {stripped_field} found")
        if result is None:
            raise Exception(f"Type with ID {type_id} and stripped {stripped_field} not found")
        return result

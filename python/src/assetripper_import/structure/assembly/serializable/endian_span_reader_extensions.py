"""Port of Source/AssetRipper.Import/Structure/Assembly/Serializable/EndianSpanReaderExtensions.cs

C#'s generic `ReadPrimitiveArray<T>` becomes a `key`-parameterised function here (the
`struct` format character identifying the element type), since Python has no generics to
recover the element size from.

The version-gated array alignment (`is_align_arrays`: Unity 2017+) is one of the two
alignment rules in the dynamic reader and a common source of silent corruption if missed.
The other is per-field `Field.align`, applied by SerializableValue's caller.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion


def is_align_arrays(version: UnityVersion) -> bool:
    """Arrays are aligned after being read, but only since Unity 2017."""
    return version.greater_than_or_equals(2017)


def _throw_if_negative_count(count: int) -> None:
    if count < 0:
        raise ValueError(f"Count cannot be negative: {count}")


def _throw_if_not_enough_space(reader, element_count: int, element_size: int) -> None:
    remaining = reader.length - reader.position
    if remaining < element_count * element_size:
        raise EOFError(
            f"Stream only has {remaining} bytes in the stream, so {element_count} "
            f"elements of size {element_size} cannot be read."
        )


def read_primitive_array(reader, version: UnityVersion, key: str) -> list:
    """`key` is the struct format character for the element type (e.g. 'i', 'f', 'B')."""
    count = reader.read_int32()
    _throw_if_negative_count(count)
    values = list(reader.read_primitive_bulk(key, count)) if count else []
    if is_align_arrays(version):
        reader.align()
    return values


def read_boolean_array(reader, version: UnityVersion) -> list[bool]:
    return [v != 0 for v in read_primitive_array(reader, version, "B")]


def read_char_array(reader, version: UnityVersion) -> list[str]:
    return [chr(v) for v in read_primitive_array(reader, version, "H")]


def read_primitive_array_array(reader, version: UnityVersion, key: str) -> list[list]:
    count = reader.read_int32()
    _throw_if_negative_count(count)
    _throw_if_not_enough_space(reader, count, 4)
    result = []
    for index in range(count):
        try:
            result.append(read_primitive_array(reader, version, key))
        except Exception as ex:
            raise EOFError(f"End of stream. Read {index}, expected {count} elements") from ex
    if is_align_arrays(version):
        reader.align()
    return result


def read_boolean_array_array(reader, version: UnityVersion) -> list[list[bool]]:
    return [[v != 0 for v in inner] for inner in read_primitive_array_array(reader, version, "B")]


def read_char_array_array(reader, version: UnityVersion) -> list[list[str]]:
    return [[chr(v) for v in inner] for inner in read_primitive_array_array(reader, version, "H")]


def read_utf8_string_aligned(reader) -> str:
    result = reader.read_utf8_string()
    reader.align()  # Alignment after strings has happened since 2.1.0
    return result


def read_string_array(reader, version: UnityVersion) -> list[str]:
    count = reader.read_int32()
    _throw_if_negative_count(count)
    _throw_if_not_enough_space(reader, count, 4)
    result = []
    for index in range(count):
        try:
            result.append(read_utf8_string_aligned(reader))
        except Exception as ex:
            raise EOFError(f"End of stream. Read {index}, expected {count} elements") from ex
    if is_align_arrays(version):
        reader.align()
    return result


def read_string_array_array(reader, version: UnityVersion) -> list[list[str]]:
    count = reader.read_int32()
    _throw_if_negative_count(count)
    _throw_if_not_enough_space(reader, count, 4)
    result = []
    for index in range(count):
        try:
            result.append(read_string_array(reader, version))
        except Exception as ex:
            raise EOFError(f"End of stream. Read {index}, expected {count} elements") from ex
    if is_align_arrays(version):
        reader.align()
    return result

"""Port of Source/AssetRipper.SerializationLogic/PrimitiveType.cs

The two `ToPrimitiveType` overloads taking AsmResolver's `CorLibTypeSignature`/`ElementType`
are not ported -- they map .NET metadata element types, which only matters for the IL-based
field-layout path (FieldSerializer) that this port deliberately omits. The string-based
`MonoUtils.to_primitive_type(namespace, name)` covers everything the TypeTree path needs.
"""
from __future__ import annotations

from enum import IntEnum


class PrimitiveType(IntEnum):
    VOID = 0
    BOOL = 1
    CHAR = 2
    SBYTE = 3
    BYTE = 4
    SHORT = 5
    USHORT = 6
    INT = 7
    UINT = 8
    LONG = 9
    ULONG = 10
    SINGLE = 11
    DOUBLE = 12
    STRING = 13
    PAIR = 14
    MAP_PAIR = 15
    COMPLEX = 16


_SIZES = {
    PrimitiveType.VOID: 0,
    PrimitiveType.BOOL: 1,
    PrimitiveType.BYTE: 1,
    PrimitiveType.SBYTE: 1,
    PrimitiveType.CHAR: 2,
    PrimitiveType.SHORT: 2,
    PrimitiveType.USHORT: 2,
    PrimitiveType.INT: 4,
    PrimitiveType.UINT: 4,
    PrimitiveType.SINGLE: 4,
    PrimitiveType.LONG: 8,
    PrimitiveType.ULONG: 8,
    PrimitiveType.DOUBLE: 8,
    PrimitiveType.PAIR: -1,
    PrimitiveType.MAP_PAIR: -1,
    PrimitiveType.STRING: -1,
    PrimitiveType.COMPLEX: -1,
}

_SYSTEM_TYPE_NAMES = {
    PrimitiveType.BOOL: "Boolean",
    PrimitiveType.CHAR: "Char",
    PrimitiveType.BYTE: "Byte",
    PrimitiveType.SBYTE: "SByte",
    PrimitiveType.SHORT: "Int16",
    PrimitiveType.USHORT: "UInt16",
    PrimitiveType.INT: "Int32",
    PrimitiveType.UINT: "UInt32",
    PrimitiveType.LONG: "Int64",
    PrimitiveType.ULONG: "UInt64",
    PrimitiveType.SINGLE: "Single",
    PrimitiveType.DOUBLE: "Double",
    PrimitiveType.STRING: "String",
}


def get_size(primitive_type: PrimitiveType) -> int:
    """Size in bytes, or -1 for variable-size types (String/Pair/MapPair/Complex)."""
    try:
        return _SIZES[primitive_type]
    except KeyError:
        raise NotImplementedError(str(primitive_type)) from None


def is_csharp_primitive(primitive_type: PrimitiveType) -> bool:
    return primitive_type == PrimitiveType.STRING or get_size(primitive_type) > 0


def to_system_type_name(primitive_type: PrimitiveType) -> str:
    try:
        return _SYSTEM_TYPE_NAMES[primitive_type]
    except KeyError:
        raise NotImplementedError(str(primitive_type)) from None

"""Scoped-down port of the `VertexFormat`-handling half of
Source/AssetRipper.SourceGenerated.Extensions/MeshHelper.cs

Only the modern (Unity >= 2019) `VertexFormat` ordinals are supported -- `ChannelInfo.format`
meant something different (and needed a version-gated remap) before 2019, which this port
does not implement. Meshes from older Unity versions may decode with the wrong component
type; this is an accepted, documented gap, not a silent-corruption risk, since the affected
versions are a small and shrinking fraction of real-world content.
"""
from __future__ import annotations

import struct
from enum import IntEnum


class VertexFormat(IntEnum):
    FLOAT = 0
    FLOAT16 = 1
    UNORM8 = 2
    SNORM8 = 3
    UNORM16 = 4
    SNORM16 = 5
    UINT8 = 6
    SINT8 = 7
    UINT16 = 8
    SINT16 = 9
    UINT32 = 10
    SINT32 = 11


_SIZES = {
    VertexFormat.FLOAT: 4,
    VertexFormat.UINT32: 4,
    VertexFormat.SINT32: 4,
    VertexFormat.FLOAT16: 2,
    VertexFormat.UNORM16: 2,
    VertexFormat.SNORM16: 2,
    VertexFormat.UINT16: 2,
    VertexFormat.SINT16: 2,
    VertexFormat.UNORM8: 1,
    VertexFormat.SNORM8: 1,
    VertexFormat.UINT8: 1,
    VertexFormat.SINT8: 1,
}


def to_vertex_format(format_value: int) -> VertexFormat:
    return VertexFormat(format_value)


def get_format_size(vertex_format: VertexFormat) -> int:
    return _SIZES[vertex_format]


def is_int_format(vertex_format: VertexFormat) -> bool:
    return vertex_format >= VertexFormat.UINT8


def _half_to_float(raw: int) -> float:
    return struct.unpack("<e", struct.pack("<H", raw))[0]


def bytes_to_float_array(data: bytes, vertex_format: VertexFormat) -> list:
    size = get_format_size(vertex_format)
    count = len(data) // size
    result = [0.0] * count
    for i in range(count):
        chunk = data[i * size:(i + 1) * size]
        if vertex_format == VertexFormat.FLOAT:
            result[i] = struct.unpack_from("<f", chunk)[0]
        elif vertex_format == VertexFormat.FLOAT16:
            result[i] = _half_to_float(struct.unpack_from("<H", chunk)[0])
        elif vertex_format == VertexFormat.UNORM8:
            result[i] = chunk[0] / 255.0
        elif vertex_format == VertexFormat.SNORM8:
            result[i] = max(struct.unpack_from("<b", chunk)[0] / 127.0, -1.0)
        elif vertex_format == VertexFormat.UNORM16:
            result[i] = struct.unpack_from("<H", chunk)[0] / 65535.0
        elif vertex_format == VertexFormat.SNORM16:
            result[i] = max(struct.unpack_from("<h", chunk)[0] / 32767.0, -1.0)
        else:
            result[i] = 0.0
    return result


def bytes_to_int_array(data: bytes, vertex_format: VertexFormat) -> list:
    size = get_format_size(vertex_format)
    count = len(data) // size
    result = [0] * count
    for i in range(count):
        chunk = data[i * size:(i + 1) * size]
        if vertex_format in (VertexFormat.UINT8, VertexFormat.SINT8):
            result[i] = chunk[0]
        elif vertex_format in (VertexFormat.UINT16, VertexFormat.SINT16):
            result[i] = struct.unpack_from("<h", chunk)[0]
        elif vertex_format in (VertexFormat.UINT32, VertexFormat.SINT32):
            result[i] = struct.unpack_from("<i", chunk)[0]
        else:
            result[i] = 0
    return result

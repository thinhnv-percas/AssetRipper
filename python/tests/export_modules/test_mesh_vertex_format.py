import struct

from assetripper_export_modules.meshes.vertex_format import (
    VertexFormat,
    bytes_to_float_array,
    bytes_to_int_array,
    get_format_size,
    is_int_format,
)


def test_format_sizes():
    assert get_format_size(VertexFormat.FLOAT) == 4
    assert get_format_size(VertexFormat.UINT32) == 4
    assert get_format_size(VertexFormat.SINT32) == 4
    assert get_format_size(VertexFormat.FLOAT16) == 2
    assert get_format_size(VertexFormat.UNORM16) == 2
    assert get_format_size(VertexFormat.SINT16) == 2
    assert get_format_size(VertexFormat.UNORM8) == 1
    assert get_format_size(VertexFormat.SINT8) == 1


def test_is_int_format():
    assert not is_int_format(VertexFormat.FLOAT)
    assert not is_int_format(VertexFormat.SNORM16)
    assert is_int_format(VertexFormat.UINT8)
    assert is_int_format(VertexFormat.SINT32)


def test_bytes_to_float_array_float32():
    data = struct.pack("<2f", 1.5, -2.25)
    assert bytes_to_float_array(data, VertexFormat.FLOAT) == [1.5, -2.25]


def test_bytes_to_float_array_unorm8():
    data = bytes([0, 128, 255])
    result = bytes_to_float_array(data, VertexFormat.UNORM8)
    assert result[0] == 0.0
    assert abs(result[1] - 128 / 255) < 1e-9
    assert result[2] == 1.0


def test_bytes_to_float_array_snorm8_clamps_to_minus_one():
    data = struct.pack("<b", -128)
    result = bytes_to_float_array(data, VertexFormat.SNORM8)
    assert result[0] == -1.0


def test_bytes_to_float_array_snorm16_clamps_to_minus_one():
    data = struct.pack("<h", -32768)
    result = bytes_to_float_array(data, VertexFormat.SNORM16)
    assert result[0] == -1.0


def test_bytes_to_float_array_unorm16():
    data = struct.pack("<H", 65535)
    assert bytes_to_float_array(data, VertexFormat.UNORM16) == [1.0]


def test_bytes_to_int_array_uint8():
    data = bytes([0, 255])
    assert bytes_to_int_array(data, VertexFormat.UINT8) == [0, 255]


def test_bytes_to_int_array_sint32():
    data = struct.pack("<i", -42)
    assert bytes_to_int_array(data, VertexFormat.SINT32) == [-42]

"""Port of Source/AssetRipper.Yaml.Tests/YamlScalarNodeTests.cs"""
from assetripper_yaml import ScalarStyle, YamlNodeType, YamlScalarNode


def test_null_character_is_double_quoted_and_escaped():
    node = YamlScalarNode.create("\x00")
    assert node.value == "\x00"
    assert node.node_type == YamlNodeType.SCALAR
    assert node.style == ScalarStyle.DOUBLE_QUOTED
    assert node.emit_to_string() == '"\\u0000"'


def test_end_of_text_character_causes_double_quoting():
    some_text = "Some text\x03"
    node = YamlScalarNode.create(some_text)
    assert node.value == some_text
    assert node.node_type == YamlNodeType.SCALAR
    assert node.style == ScalarStyle.DOUBLE_QUOTED
    assert node.emit_to_string() == '"Some text\\u0003"'


def test_ascii_characters_use_plain_style():
    ascii_characters = "Ascii Characters"
    node = YamlScalarNode.create(ascii_characters)
    assert node.value == ascii_characters
    assert node.node_type == YamlNodeType.SCALAR
    assert node.style == ScalarStyle.PLAIN
    assert node.emit_to_string() == ascii_characters


def _numeric_list_test(values, width_bytes, expected):
    node = YamlScalarNode.create_hex_bytes(values, width_bytes)
    assert node.value == expected
    assert node.node_type == YamlNodeType.SCALAR
    assert node.style == ScalarStyle.PLAIN
    assert node.emit_to_string() == expected


def test_byte_list():
    _numeric_list_test([0x01, 0x02, 0x03], 1, "010203")


def test_uint16_list():
    _numeric_list_test([0x0102, 0x0304, 0x0506], 2, "020104030605")


def test_uint32_list():
    _numeric_list_test([0x01020304, 0x05060708], 4, "0403020108070605")


def test_int32_list():
    _numeric_list_test([-1, 0xB0000000 - (1 << 32), -(2 ** 31)], 4, "ffffffff000000b000000080")


def test_uint64_list():
    _numeric_list_test([0x0102030405060708, 0x090A0B0C0D0E0F10], 8, "0807060504030201100f0e0d0c0b0a09")


def test_int64_list():
    _numeric_list_test([-1, -(2 ** 63)], 8, "ffffffffffffffff0000000000000080")

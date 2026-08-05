"""Port of Source/AssetRipper.Yaml.Tests/HexTests.cs"""
from assetripper_yaml import YamlScalarNode


def test_one_float():
    node = YamlScalarNode.create_hex_single(1.0)
    assert str(node) == "0x3f800000(1)"

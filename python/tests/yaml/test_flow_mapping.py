"""Port of Source/AssetRipper.Yaml.Tests/FlowMappingTests.cs"""
from assetripper_yaml import MappingStyle, YamlMappingNode


def test_vector2_flow_mapping():
    mapping_node = YamlMappingNode(MappingStyle.FLOW)
    mapping_node.add("x", 2)
    mapping_node.add("y", 3)
    assert mapping_node.emit_to_string() == "{x: 2, y: 3}"

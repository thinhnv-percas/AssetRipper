"""Port of Source/AssetRipper.Yaml/Extensions/YamlArrayExtensions.cs"""
from __future__ import annotations

from ..yaml_scalar_node import YamlScalarNode

TYPELESSDATA_NAME = "_typelessdata"


def add_typeless_data(mapping_node, name: str, data) -> None:
    mapping_node.add(name, len(data))
    mapping_node.add(TYPELESSDATA_NAME, YamlScalarNode.create_hex_bytes(data, 1))

"""Port of Source/AssetRipper.Yaml/YAMLNodeType.cs"""
from __future__ import annotations

from enum import Enum, auto


class YamlNodeType(Enum):
    MAPPING = auto()
    """The node is a YamlMappingNode."""
    SCALAR = auto()
    """The node is a YamlScalarNode."""
    SEQUENCE = auto()
    """The node is a YamlSequenceNode."""

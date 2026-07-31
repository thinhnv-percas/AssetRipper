"""Port of Source/AssetRipper.Yaml/YAMLDocument.cs"""
from __future__ import annotations

from .emitter import Emitter
from .yaml_mapping_node import YamlMappingNode
from .yaml_node import YamlNode
from .yaml_sequence_node import YamlSequenceNode


class YamlDocument:
    def __init__(self):
        self.root: YamlNode | None = None

    def create_sequence_root(self) -> YamlSequenceNode:
        root = YamlSequenceNode()
        self.root = root
        return root

    def create_mapping_root(self) -> YamlMappingNode:
        root = YamlMappingNode()
        self.root = root
        return root

    def _emit(self, emitter: Emitter, is_separator: bool) -> None:
        if is_separator:
            emitter.write("---").write_whitespace()

        if self.root is None:
            raise Exception("Root cannot be None here")
        self.root._emit(emitter)

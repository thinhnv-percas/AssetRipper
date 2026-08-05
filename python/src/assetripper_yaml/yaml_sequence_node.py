"""
Port of Source/AssetRipper.Yaml/YAMLSequenceNode.cs

C#'s typed `Add(bool/byte/short/.../string)` overloads collapse into one `add(value)`
dispatching on Python's runtime type (see yaml_mapping_node.py for the same pattern).
"""
from __future__ import annotations

from .emitter import Emitter
from .sequence_style import SequenceStyle, is_any_block
from .yaml_node import YamlNode
from .yaml_node_type import YamlNodeType
from .yaml_scalar_node import YamlScalarNode


class YamlSequenceNode(YamlNode):
    def __init__(self, style: SequenceStyle = SequenceStyle.BLOCK):
        super().__init__()
        self.style = style
        self.children: list[YamlNode] = []

    def add(self, value) -> None:
        node = value if isinstance(value, YamlNode) else YamlScalarNode.create(value)
        self.children.append(node)

    def _emit(self, emitter: Emitter) -> None:
        super()._emit(emitter)

        self._start_children(emitter)
        for child in self.children:
            self._start_child(emitter, child)
            child._emit(emitter)
            self._end_child(emitter, child)
        self._end_children(emitter)

    def _start_children(self, emitter: Emitter) -> None:
        if self.style == SequenceStyle.BLOCK:
            if len(self.children) == 0:
                emitter.write("[")
        elif self.style == SequenceStyle.BLOCK_CURVE:
            if len(self.children) == 0:
                emitter.write("{")
        elif self.style == SequenceStyle.FLOW:
            emitter.write("[")

    def _end_children(self, emitter: Emitter) -> None:
        if self.style == SequenceStyle.BLOCK:
            if len(self.children) == 0:
                emitter.write("]")
            emitter.write_line()
        elif self.style == SequenceStyle.BLOCK_CURVE:
            if len(self.children) == 0:
                emitter.write_close_char("}")
            emitter.write_line()
        elif self.style == SequenceStyle.FLOW:
            emitter.write_close_char("]")

    def _start_child(self, emitter: Emitter, next_node: YamlNode) -> None:
        if is_any_block(self.style):
            emitter.write("-").write(" ")
            if next_node.node_type == self.node_type:
                emitter.increase_indent()
        if next_node.is_indent:
            emitter.increase_indent()

    def _end_child(self, emitter: Emitter, next_node: YamlNode) -> None:
        if is_any_block(self.style):
            emitter.write_line()
            if next_node.node_type == self.node_type:
                emitter.decrease_indent()
        elif self.style == SequenceStyle.FLOW:
            emitter.write_separator().write_whitespace()
        if next_node.is_indent:
            emitter.decrease_indent()

    def __iter__(self):
        return iter(self.children)

    def __len__(self) -> int:
        return len(self.children)

    @property
    def node_type(self) -> YamlNodeType:
        return YamlNodeType.SEQUENCE

    @property
    def is_multiline(self) -> bool:
        return is_any_block(self.style) and len(self.children) > 0

    @property
    def is_indent(self) -> bool:
        return False

    def __str__(self) -> str:
        return f"Count = {len(self.children)}"

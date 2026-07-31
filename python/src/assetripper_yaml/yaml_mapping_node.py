"""
Port of Source/AssetRipper.Yaml/YAMLMappingNode.cs

C#'s dozens of typed `Add(TKey, TValue)` overloads collapse into one `add(key, value)`
dispatching on Python's runtime type, since Python has no static overload resolution.
The one real behavioral distinction preserved from the overloads: a string key is
created via `YamlScalarNode.create_plain` (unquoted, matching `Add(string key, ...)`),
while any other scalar key goes through `YamlScalarNode.create` (matching the int/uint/
long key overloads).
"""
from __future__ import annotations

from .emitter import Emitter
from .mapping_style import MappingStyle
from .yaml_node import YamlNode
from .yaml_node_type import YamlNodeType
from .yaml_scalar_node import YamlScalarNode


class YamlMappingNode(YamlNode):
    def __init__(self, style: MappingStyle = MappingStyle.BLOCK):
        super().__init__()
        self.style = style
        self.children: list[tuple[YamlNode, YamlNode]] = []

    def add(self, key, value) -> None:
        value_node = value if isinstance(value, YamlNode) else YamlScalarNode.create(value)

        if isinstance(key, YamlNode):
            key_node = key
        elif isinstance(key, str):
            key_node = YamlScalarNode.create_plain(key)
        else:
            key_node = YamlScalarNode.create(key)

        if key_node.node_type != YamlNodeType.SCALAR:
            raise Exception(f"Only {YamlNodeType.SCALAR} node as a key supported")

        self._insert_end(key_node, value_node)

    def append(self, other: "YamlMappingNode") -> None:
        for key, value in other.children:
            self.add(key, value)

    def insert_begin(self, key, value) -> None:
        value_node = value if isinstance(value, YamlNode) else YamlScalarNode.create(value)
        key_node = key if isinstance(key, YamlNode) else YamlScalarNode.create_plain(key)
        self.children.insert(0, (key_node, value_node))

    def _insert_end(self, key: YamlNode, value: YamlNode) -> None:
        self.children.append((key, value))

    def _emit(self, emitter: Emitter) -> None:
        super()._emit(emitter)

        self._start_children(emitter)
        for key, value in self.children:
            is_key = emitter.is_key
            emitter.is_key = True
            key._emit(emitter)
            emitter.is_key = False
            self._start_transition(emitter, value)
            value._emit(emitter)
            self._end_transition(emitter, value)
            emitter.is_key = is_key
        self._end_children(emitter)

    def _start_children(self, emitter: Emitter) -> None:
        if self.style == MappingStyle.BLOCK:
            if len(self.children) == 0:
                emitter.write("{")
        elif self.style == MappingStyle.FLOW:
            emitter.write("{")

    def _end_children(self, emitter: Emitter) -> None:
        if self.style == MappingStyle.BLOCK:
            if len(self.children) == 0:
                emitter.write("}")
            emitter.write_line()
        elif self.style == MappingStyle.FLOW:
            emitter.write_close_char("}")

    def _start_transition(self, emitter: Emitter, next_node: YamlNode) -> None:
        emitter.write(":").write_whitespace()
        if self.style == MappingStyle.BLOCK and next_node.is_multiline:
            emitter.write_line()
        if next_node.is_indent:
            emitter.increase_indent()

    def _end_transition(self, emitter: Emitter, next_node: YamlNode) -> None:
        if self.style == MappingStyle.BLOCK:
            emitter.write_line()
        elif self.style == MappingStyle.FLOW:
            emitter.write_separator().write_whitespace()
        if next_node.is_indent:
            emitter.decrease_indent()

    def __iter__(self):
        return iter(self.children)

    def __len__(self) -> int:
        return len(self.children)

    @property
    def node_type(self) -> YamlNodeType:
        return YamlNodeType.MAPPING

    @property
    def is_multiline(self) -> bool:
        return self.style == MappingStyle.BLOCK and len(self.children) > 0

    @property
    def is_indent(self) -> bool:
        return self.style == MappingStyle.BLOCK

    def __str__(self) -> str:
        return f"Count = {len(self.children)}"


YamlMappingNode.EMPTY = YamlMappingNode(MappingStyle.FLOW)

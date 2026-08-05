"""Port of Source/AssetRipper.Yaml/YAMLNode.cs"""
from __future__ import annotations

import io
from abc import ABC, abstractmethod

from .emitter import Emitter
from .yaml_node_type import YamlNodeType
from .yaml_tag import YamlTag


class YamlNode(ABC):
    def __init__(self):
        self.custom_tag: YamlTag = YamlTag()
        self.anchor: str = ""
        self.stripped: bool = False

    def _emit(self, emitter: Emitter) -> None:
        is_wrote = False
        if not self.custom_tag.is_empty:
            emitter.write(str(self.custom_tag)).write_whitespace()
            is_wrote = True
        if len(self.anchor) > 0:
            emitter.write("&").write(self.anchor).write_whitespace()
            is_wrote = True
        if self.stripped:
            emitter.write("stripped").write_whitespace()
            is_wrote = True

        if is_wrote and self.is_multiline:
            emitter.write_line()

    def emit_to_string(self, format_keys: bool = False) -> str:
        writer = io.StringIO()
        emitter = Emitter(writer, format_keys)
        self._emit(emitter)
        return writer.getvalue()

    @property
    @abstractmethod
    def node_type(self) -> YamlNodeType: ...

    @property
    @abstractmethod
    def is_multiline(self) -> bool: ...

    @property
    @abstractmethod
    def is_indent(self) -> bool: ...

    @property
    def tag(self) -> str:
        return self.custom_tag.content

    @tag.setter
    def tag(self, value: str) -> None:
        from .yaml_writer import DEFAULT_TAG_HANDLE

        self.custom_tag = YamlTag(DEFAULT_TAG_HANDLE, value)

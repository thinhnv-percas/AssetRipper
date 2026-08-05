"""Port of Source/AssetRipper.Yaml/YAMLWriter.cs"""
from __future__ import annotations

from .emitter import Emitter
from .meta_type import MetaType
from .yaml_document import YamlDocument
from .yaml_tag import YamlTag

DEFAULT_TAG_HANDLE = "!u!"
DEFAULT_TAG_CONTENT = "tag:unity3d.com,2011:"
VERSION = "1.1"


class YamlWriter:
    def __init__(self):
        self.default_tag = YamlTag(DEFAULT_TAG_HANDLE, DEFAULT_TAG_CONTENT)
        self.is_write_version = True
        self.is_write_default_tag = True
        self.is_format_keys = False
        self._documents: list[YamlDocument] = []
        self._tags: list[YamlTag] = []
        self._emitter: Emitter | None = None
        self._is_write_separator = False

    def add_document(self, document: YamlDocument) -> None:
        if document in self._documents:
            raise ValueError(f"Document {document} is added already")
        self._documents.append(document)

    def add_tag(self, handle: str, content: str) -> None:
        if any(t.handle == handle for t in self._tags):
            raise Exception(f"Writer already contains tag {handle}")
        self._tags.append(YamlTag(handle, content))

    def write(self, output) -> None:
        self.write_head(output)
        for doc in self._documents:
            self.write_document(doc)
        self.write_tail(output)

    def write_head(self, output) -> None:
        self._emitter = Emitter(output, self.is_format_keys)
        self._is_write_separator = False

        if self.is_write_version:
            self._emitter.write_meta(MetaType.YAML, VERSION)
            self._is_write_separator = True

        if self.is_write_default_tag:
            self._emitter.write_meta(MetaType.TAG, self.default_tag.to_header_string())
            self._is_write_separator = True

        for tag in self._tags:
            self._emitter.write_meta(MetaType.TAG, tag.to_header_string())
            self._is_write_separator = True

    def write_document(self, doc: YamlDocument) -> None:
        if self._emitter is None:
            raise ReferenceError("Emitter cannot be None")
        doc._emit(self._emitter, self._is_write_separator)
        self._is_write_separator = True

    def write_tail(self, output) -> None:
        output.write("\n")

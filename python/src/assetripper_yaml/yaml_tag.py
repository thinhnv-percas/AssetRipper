"""Port of Source/AssetRipper.Yaml/YAMLTag.cs"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass(frozen=True, slots=True)
class YamlTag:
    handle: str = ""
    content: str = ""

    def __str__(self) -> str:
        return "" if self.is_empty else f"{self.handle}{self.content}"

    def to_header_string(self) -> str:
        return "" if self.is_empty else f"{self.handle} {self.content}"

    @property
    def is_empty(self) -> bool:
        return not self.handle

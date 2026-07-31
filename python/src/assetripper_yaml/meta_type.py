"""Port of Source/AssetRipper.Yaml/MetaType.cs"""
from __future__ import annotations

from enum import Enum, auto


class MetaType(Enum):
    YAML = auto()
    TAG = auto()


def to_string_representation(meta_type: MetaType) -> str:
    if meta_type == MetaType.YAML:
        return "YAML"
    elif meta_type == MetaType.TAG:
        return "TAG"
    raise ValueError(f"Value: {meta_type}")

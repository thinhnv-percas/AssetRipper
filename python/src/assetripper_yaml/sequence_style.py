"""Port of Source/AssetRipper.Yaml/SequenceStyle.cs"""
from __future__ import annotations

from enum import Enum, auto


class SequenceStyle(Enum):
    BLOCK = auto()
    """The block sequence style."""
    BLOCK_CURVE = auto()
    """The block sequence style but with curly braces."""
    FLOW = auto()
    """The flow sequence style."""


def is_any_block(style: SequenceStyle) -> bool:
    return style in (SequenceStyle.BLOCK, SequenceStyle.BLOCK_CURVE)

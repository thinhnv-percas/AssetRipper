"""Port of Source/AssetRipper.IO.Files/Extensions/StreamExtensions.cs"""
from __future__ import annotations

from ..streams.stream import Stream


def align(stream: Stream, alignment: int = 4) -> None:
    pos = stream.position
    mod = pos % alignment
    if mod != 0:
        stream.position += alignment - mod

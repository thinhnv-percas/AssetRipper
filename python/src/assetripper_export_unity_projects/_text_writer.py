"""Minimal stand-in for C#'s `InvariantStreamWriter` (UTF-8, no BOM, invariant culture --
irrelevant in Python since str formatting here isn't locale-sensitive). Wraps one of this
port's binary `Stream` objects (assetripper_io_files.streams.stream.Stream) so
`assetripper_yaml.YamlWriter.write(output)` -- which only calls `output.write(str)` -- can
write straight to a file opened through the FileSystem abstraction.
"""
from __future__ import annotations


class Utf8TextWriter:
    def __init__(self, stream):
        self._stream = stream

    def write(self, text: str) -> None:
        data = text.encode("utf-8")
        self._stream.write(data, 0, len(data))

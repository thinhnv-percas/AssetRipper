"""Port of Source/AssetRipper.IO.Files/BundleFiles/RawWeb/BundleScene.cs

Compression info about one chunk: a (optionally LZMA-compressed) structure containing
file entries plus their data blob. Despite the name, unrelated to `SceneDefinition`.
"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass(slots=True)
class BundleScene:
    compressed_size: int = 0
    decompressed_size: int = 0

    @staticmethod
    def read(reader) -> "BundleScene":
        return BundleScene(compressed_size=reader.read_uint32(), decompressed_size=reader.read_uint32())

    def write(self, writer) -> None:
        writer.write_uint32(self.compressed_size)
        writer.write_uint32(self.decompressed_size)

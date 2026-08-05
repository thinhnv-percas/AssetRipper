"""Port of Source/AssetRipper.IO.Files/BundleFiles/Hash128.cs

A distinct 16-byte hash type from AssetRipper.IO.Files.SerializedFiles.Parser.Hash128
(that one is 4x uint32; this one is 16 raw bytes), matching the separate C# types.
"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass(slots=True)
class Hash128:
    bytes_: bytes = bytes(16)

    def __post_init__(self) -> None:
        if len(self.bytes_) != 16:
            raise ValueError("Hash128 must be exactly 16 bytes.")

    @staticmethod
    def read(reader) -> "Hash128":
        return Hash128(bytes(reader.read_byte() for _ in range(16)))

    def write(self, writer) -> None:
        for b in self.bytes_:
            writer.write_byte(b)

    def to_array(self) -> bytes:
        return self.bytes_

    def __str__(self) -> str:
        from assetripper_primitives import UnityGuid

        return str(UnityGuid.from_bytes(self.bytes_))

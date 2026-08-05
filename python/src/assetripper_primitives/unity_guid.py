"""
Port of the subset of AssetRipper.Primitives.UnityGuid used across Source/ (external
NuGet dependency, source not vendored in this repo -- reconstructed from call sites,
see task notes for the researched API surface).
"""
from __future__ import annotations

import hashlib
import uuid
from dataclasses import dataclass


@dataclass(frozen=True, slots=True)
class UnityGuid:
    data0: int = 0
    data1: int = 0
    data2: int = 0
    data3: int = 0

    @staticmethod
    def from_bytes(data: bytes) -> "UnityGuid":
        if len(data) != 16:
            raise ValueError("UnityGuid requires exactly 16 bytes")
        d0, d1, d2, d3 = (int.from_bytes(data[i:i + 4], "little") for i in range(0, 16, 4))
        return UnityGuid(d0, d1, d2, d3)

    def to_bytes(self) -> bytes:
        return b"".join(v.to_bytes(4, "little") for v in (self.data0, self.data1, self.data2, self.data3))

    @property
    def is_zero(self) -> bool:
        return self.data0 == 0 and self.data1 == 0 and self.data2 == 0 and self.data3 == 0

    @staticmethod
    def new_guid() -> "UnityGuid":
        return UnityGuid.from_bytes(uuid.uuid4().bytes)

    def __str__(self) -> str:
        return self.to_bytes().hex()

    @staticmethod
    def parse(text: str) -> "UnityGuid":
        return UnityGuid.from_bytes(bytes.fromhex(text))

    @staticmethod
    def md5_hash(*parts: bytes) -> "UnityGuid":
        """Deterministic GUID derived from the MD5 digest of the concatenated `parts`.

        Reconstructed from call sites (ScriptHashing.CalculateScriptGuid/
        CalculateAssemblyGuid in Source/AssetRipper.Export.UnityProjects/Scripts/
        ScriptHashing.cs): used where upstream wants a *stable* (not random) GUID for
        content that doesn't have one of its own, e.g. a script's namespace+class+assembly.
        """
        digest = hashlib.md5(b"".join(parts)).digest()
        return UnityGuid.from_bytes(digest)


UnityGuid.ZERO = UnityGuid(0, 0, 0, 0)

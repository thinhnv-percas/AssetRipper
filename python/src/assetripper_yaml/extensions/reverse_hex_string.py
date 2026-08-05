"""
Port of Source/AssetRipper.Yaml/Extensions/ReverseHexString.cs

The C# original manually shifts/masks nybbles into a stack-allocated char buffer for
performance; the actual effect (verified against AssetRipper.Yaml.Tests/
YamlScalarNodeTests.cs's NumericListTest cases) is simply: reinterpret the value as raw
bytes in little-endian order, then hex-encode those bytes in that order. That's exactly
`int.to_bytes(width, "little").hex()`, with no manual bit-twiddling needed in Python.
"""
from __future__ import annotations


def get_hex_string_length(width_bytes: int) -> int:
    return width_bytes * 2


def write_reverse_hex_string(value: int, width_bytes: int) -> str:
    return value.to_bytes(width_bytes, "little", signed=value < 0).hex()

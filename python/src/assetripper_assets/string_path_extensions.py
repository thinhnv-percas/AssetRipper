"""Port of Source/AssetRipper.Assets/StringPathExtensions.cs"""
from __future__ import annotations


def remove_period(s: str | None) -> str | None:
    if not s or s[0] != ".":
        return s
    return s[1:]


def not_empty(s: str | None) -> str | None:
    return s if s else None

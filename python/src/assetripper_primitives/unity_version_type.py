"""
Port of the subset of AssetRipper.Primitives.UnityVersionType actually used across
Source/ (confirmed by grep: only Alpha, Beta, Final, Patch appear; this package's
source isn't vendored in this repo, so anything beyond that usage is unconfirmed).
"""
from __future__ import annotations

from enum import IntEnum


class UnityVersionType(IntEnum):
    ALPHA = 0
    BETA = 1
    FINAL = 2
    PATCH = 3


_TO_CHARACTER = {
    UnityVersionType.ALPHA: "a",
    UnityVersionType.BETA: "b",
    UnityVersionType.FINAL: "f",
    UnityVersionType.PATCH: "p",
}
_FROM_CHARACTER = {v: k for k, v in _TO_CHARACTER.items()}


def to_character(version_type: UnityVersionType) -> str:
    return _TO_CHARACTER[version_type]


def from_character(char: str) -> UnityVersionType:
    return _FROM_CHARACTER[char]

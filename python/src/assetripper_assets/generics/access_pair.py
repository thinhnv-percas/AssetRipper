"""
Port of Source/AssetRipper.Assets/Generics/AccessPair.cs

Like AccessList, this delegates to a reference AccessPairBase -- kept for structural
parity, since Python doesn't need the C# covariance workaround.
"""
from __future__ import annotations

from .access_pair_base import AccessPairBase


class AccessPair(AccessPairBase):
    def __init__(self, reference_pair: AccessPairBase):
        self._reference_pair = reference_pair

    @property
    def key(self):
        return self._reference_pair.key

    @key.setter
    def key(self, value) -> None:
        self._reference_pair.key = value

    @property
    def value(self):
        return self._reference_pair.value

    @value.setter
    def value(self, value) -> None:
        self._reference_pair.value = value

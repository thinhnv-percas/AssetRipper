"""Port of Source/AssetRipper.Assets/Generics/AssetPair.cs"""
from __future__ import annotations

from typing import Callable

from .access_pair_base import AccessPairBase


class AssetPair(AccessPairBase):
    def __init__(self, key_factory: Callable[[], object] = lambda: None, value_factory: Callable[[], object] = lambda: None):
        self._key = key_factory()
        self._value = value_factory()

    @property
    def key(self):
        return self._key

    @key.setter
    def key(self, value) -> None:
        self._key = value

    @property
    def value(self):
        return self._value

    @value.setter
    def value(self, value) -> None:
        self._value = value

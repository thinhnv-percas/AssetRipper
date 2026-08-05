"""Port of Source/AssetRipper.Assets/INamed.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class INamed(ABC):
    @property
    @abstractmethod
    def name(self) -> str: ...

    @name.setter
    @abstractmethod
    def name(self, value: str) -> None: ...

"""Port of Source/AssetRipper.Configuration/DataEntry.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class DataEntry(ABC):
    @abstractmethod
    def clear(self) -> None: ...

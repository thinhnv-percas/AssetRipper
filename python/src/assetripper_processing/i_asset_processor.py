"""Port of Source/AssetRipper.Processing/IAssetProcessor.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IAssetProcessor(ABC):
    @abstractmethod
    def process(self, game_data) -> None: ...

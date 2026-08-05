"""Port of Source/AssetRipper.Assets/Bundles/IResourceProvider.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IResourceProvider(ABC):
    @abstractmethod
    def find_resource(self, identifier: str):
        ...

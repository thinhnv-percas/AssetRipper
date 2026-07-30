"""Port of Source/AssetRipper.Assets/Bundles/IDependencyProvider.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IDependencyProvider(ABC):
    @abstractmethod
    def find_dependency(self, identifier):
        ...

    @abstractmethod
    def report_missing_dependency(self, identifier) -> None:
        ...

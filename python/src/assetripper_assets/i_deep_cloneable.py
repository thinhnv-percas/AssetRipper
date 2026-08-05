"""Port of Source/AssetRipper.Assets/IDeepCloneable.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IDeepCloneable(ABC):
    @abstractmethod
    def deep_clone(self, converter):
        """Deep clones this object. `converter` is the PPtrConverter to use for cloning PPtrs."""
        ...

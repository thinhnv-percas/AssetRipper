"""
Port of Source/AssetRipper.Assets/Metadata/IPPtr.cs

The C# interfaces additionally extend IUnityAssetBase (concrete implementations are
per-Unity-version generated field wrappers, out of this port's scope); this keeps just
the identity/resolution contract that's actually used here.
"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IPPtr(ABC):
    @property
    @abstractmethod
    def file_id(self) -> int:
        """Zero means the asset is located within the current file."""
        ...

    @property
    @abstractmethod
    def path_id(self) -> int:
        """Sometimes sequential, sometimes more like a hash. Zero signifies a null reference."""
        ...

    @property
    def is_null(self) -> bool:
        return self.path_id == 0

    @abstractmethod
    def set_asset(self, collection, asset) -> None: ...

    @abstractmethod
    def try_get_asset(self, collection) -> tuple[bool, object]: ...

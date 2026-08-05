"""
Port of Source/AssetRipper.Assets/Metadata/PPtr.cs

A Unity pointer to an object. C# has separate `PPtr` and `PPtr<T>` record structs with
implicit/explicit conversions purely for compile-time type safety; Python has no
reified generics to preserve here, so a single class serves both roles. `cast()` is
kept (mirroring `PPtr<T>.Cast<TCast>()`) as a same-data copy for structural parity.
"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass(frozen=True, slots=True)
class PPtr:
    file_id: int = 0
    """Zero means the asset is located within the current file."""
    path_id: int = 0
    """Sometimes sequential, sometimes more like a hash. Zero signifies a null reference."""

    @staticmethod
    def from_path_id(path_id: int) -> "PPtr":
        return PPtr(0, path_id)

    @staticmethod
    def from_ipptr(pptr) -> "PPtr":
        return PPtr(pptr.file_id, pptr.path_id)

    @property
    def is_null(self) -> bool:
        return self.path_id == 0

    def cast(self) -> "PPtr":
        """No-op here (see module docstring) -- kept for parity with PPtr<T>.Cast<TCast>()."""
        return PPtr(self.file_id, self.path_id)

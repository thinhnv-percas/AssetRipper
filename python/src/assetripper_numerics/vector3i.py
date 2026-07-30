"""Port of Source/AssetRipper.Numerics/Vector3i.cs"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass(frozen=True, slots=True)
class Vector3i:
    X: int = 0
    Y: int = 0
    Z: int = 0

    def get_value_by_member(self, member: int) -> int:
        member %= 3
        if member == 0:
            return self.X
        if member == 1:
            return self.Y
        return self.Z

    def get_member_by_value(self, value: int) -> int:
        if self.X == value:
            return 0
        if self.Y == value:
            return 1
        if self.Z == value:
            return 2
        raise ValueError(f"Member with value {value} wasn't found")

    def contains_value(self, value: int) -> bool:
        return self.X == value or self.Y == value or self.Z == value

    def __str__(self) -> str:
        return f"[{self.X}, {self.Y}, {self.Z}]"

    @staticmethod
    def zero() -> "Vector3i":
        return Vector3i()

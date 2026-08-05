"""Port of Source/AssetRipper.IO.Files/Streams/Smart/SmartStream.SmartRefCount.cs"""
from __future__ import annotations


class SmartRefCount:
    __slots__ = ("_ref_count",)

    def __init__(self) -> None:
        self._ref_count = 0

    def increase(self) -> None:
        self.ref_count += 1

    def decrease(self) -> None:
        self.ref_count -= 1

    def __str__(self) -> str:
        return str(self.ref_count)

    @property
    def is_zero(self) -> bool:
        return self.ref_count == 0

    @property
    def ref_count(self) -> int:
        return self._ref_count

    @ref_count.setter
    def ref_count(self, value: int) -> None:
        if value < 0:
            raise ValueError("value must be non-negative")
        self._ref_count = value

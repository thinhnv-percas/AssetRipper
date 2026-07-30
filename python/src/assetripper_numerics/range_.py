"""
Port of Source/AssetRipper.Numerics/Range.cs

C#'s `Range<T>.Intersects(Range<T> other, out Range<T> intersection)` and
`CanUnion(Range<T> other, out Range<T> union)` overloads are ported as functions
returning `Range | None` instead of the (bool, out) pattern, since Python has no
out parameters.
"""
from __future__ import annotations

from dataclasses import dataclass
from typing import Generic, TypeVar

T = TypeVar("T")


@dataclass(frozen=True, slots=True)
class Range(Generic[T]):
    """Start is inclusive, End is exclusive. End must be greater than Start."""

    start: T
    end: T

    def __post_init__(self) -> None:
        if self.start >= self.end:
            raise ValueError(f"start {self.start} must be less than end {self.end}")

    def contains(self, value) -> bool:
        if isinstance(value, Range):
            return self.start <= value.start and self.end >= value.end
        return self.start <= value < self.end

    def is_strictly_less(self, other: "Range[T]") -> bool:
        return self.end <= other.start

    def is_strictly_greater(self, other: "Range[T]") -> bool:
        return self.start >= other.end

    def intersects(self, other: "Range[T]") -> bool:
        return self.contains(other.start) or other.contains(self.start)

    def intersects_with(self, other: "Range[T]") -> "Range[T] | None":
        if self.intersects(other):
            return self._make_intersection_internal(other)
        return None

    def can_union(self, other: "Range[T]") -> bool:
        return self.intersects(other) or self.start == other.end or self.end == other.start

    def can_union_with(self, other: "Range[T]") -> "Range[T] | None":
        if self.can_union(other):
            return self._make_union_internal(other)
        return None

    def make_union(self, other: "Range[T]") -> "Range[T]":
        if not self.can_union(other):
            raise ValueError("These ranges cannot be unioned")
        return self._make_union_internal(other)

    def _make_union_internal(self, other: "Range[T]") -> "Range[T]":
        return Range(min(self.start, other.start), max(self.end, other.end))

    def make_intersection(self, other: "Range[T]") -> "Range[T]":
        if not self.intersects(other):
            raise ValueError("These ranges do not intersect")
        return self._make_intersection_internal(other)

    def _make_intersection_internal(self, other: "Range[T]") -> "Range[T]":
        return Range(max(self.start, other.start), min(self.end, other.end))

    def __str__(self) -> str:
        return f"{self.start} : {self.end}"

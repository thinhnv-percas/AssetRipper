"""Port of Source/AssetRipper.Numerics/DiscontinuousRange.cs

An immutable structure representing a discontinuous, possibly empty, range of values.
"""
from __future__ import annotations

from typing import Generic, Iterable, Iterator, TypeVar

from .range_ import Range

T = TypeVar("T")


class DiscontinuousRange(Generic[T]):
    __slots__ = ("_ranges",)

    def __init__(self, ranges: "Range[T] | Iterable[Range[T]] | None" = None):
        self._ranges: list[Range[T]] = []
        if ranges is None:
            return
        if isinstance(ranges, Range):
            self._ranges.append(ranges)
            return
        for r in ranges:
            self._add(r)

    @staticmethod
    def empty() -> "DiscontinuousRange[T]":
        return DiscontinuousRange()

    @property
    def count(self) -> int:
        return len(self._ranges)

    def __len__(self) -> int:
        return self.count

    def __getitem__(self, index: int) -> Range[T]:
        return self._ranges[index]

    def __iter__(self) -> Iterator[Range[T]]:
        return iter(self._ranges)

    def __eq__(self, other: object) -> bool:
        if isinstance(other, DiscontinuousRange):
            return self._ranges == other._ranges
        if isinstance(other, Range):
            return self.count == 1 and self[0] == other
        return NotImplemented

    def __hash__(self) -> int:
        h = 0
        for r in reversed(self._ranges):
            h = hash((h, r))
        return h

    def contains(self, item) -> bool:
        if isinstance(item, DiscontinuousRange):
            return all(self.contains(r) for r in item._ranges)
        return any(r.contains(item) for r in self._ranges)

    def intersects(self, other: "Range[T] | DiscontinuousRange[T]") -> bool:
        if isinstance(other, DiscontinuousRange):
            i = j = 0
            while i < self.count and j < other.count:
                this_range, other_range = self[i], other[j]
                if this_range.intersects(other_range):
                    return True
                elif this_range.is_strictly_less(other_range):
                    i += 1
                else:
                    j += 1
            return False
        return any(r.intersects(other) for r in self._ranges)

    def _add(self, new_range: Range[T]) -> None:
        first_union_index = self.count
        last_union_index = self.count
        i = 0
        while i < self.count:
            if self._ranges[i].can_union(new_range):
                if first_union_index == self.count:
                    first_union_index = i
                last_union_index = i
            elif first_union_index < self.count:
                break
            elif self._ranges[i].is_strictly_greater(new_range):
                self._ranges.insert(i, new_range)
                return
            i += 1

        if first_union_index == self.count:
            self._ranges.append(new_range)
        else:
            self._ranges[first_union_index] = self._ranges[first_union_index].make_union(new_range)
            if first_union_index < last_union_index:
                del self._ranges[first_union_index + 1 : last_union_index + 1]

    def is_empty(self) -> bool:
        return self.count == 0

    def is_continuous(self) -> bool:
        return self.count == 1

    def continuous_range(self) -> "Range[T] | None":
        return self[0] if self.count == 1 else None

    def negate(self, minimum: T, maximum: T) -> "DiscontinuousRange[T]":
        if self.is_empty():
            return DiscontinuousRange(Range(minimum, maximum))

        new_ranges: list[Range[T]] = []
        start = self._ranges[0].start
        if start != minimum:
            new_ranges.append(Range(minimum, start))

        for i in range(self.count - 1):
            new_ranges.append(Range(self._ranges[i].end, self._ranges[i].start))

        end = self._ranges[-1].end
        if end != maximum:
            new_ranges.append(Range(end, maximum))

        return DiscontinuousRange(new_ranges)

    def union(self, other: "DiscontinuousRange[T]") -> "DiscontinuousRange[T]":
        if self.count == 0:
            return DiscontinuousRange(other._ranges)
        if other.count == 0:
            return DiscontinuousRange(self._ranges)
        merged = list(self._ranges)
        result = DiscontinuousRange.__new__(DiscontinuousRange)
        result._ranges = merged
        for r in other._ranges:
            result._add(r)
        return result

    def intersect(self, other: "DiscontinuousRange[T]") -> "DiscontinuousRange[T]":
        ranges: list[Range[T]] = []
        i = j = 0
        while i < self.count and j < other.count:
            this_range, other_range = self[i], other[j]
            intersection = this_range.intersects_with(other_range)
            if intersection is not None:
                ranges.append(intersection)
                if this_range.end <= other_range.end:
                    i += 1
                else:
                    j += 1
            elif this_range.is_strictly_less(other_range):
                i += 1
            else:
                j += 1
        return DiscontinuousRange(ranges)

    def subtract(self, other: "DiscontinuousRange[T]") -> "DiscontinuousRange[T]":
        ranges: list[Range[T]] = []
        i = j = 0
        ended_inside = False
        next_starting_point = None
        while i < self.count and j < other.count:
            this_range, other_range = self[i], other[j]
            if this_range.is_strictly_less(other_range):
                if ended_inside:
                    ranges.append(Range(next_starting_point, this_range.end))
                    ended_inside = False
                    next_starting_point = None
                i += 1
            elif this_range.is_strictly_greater(other_range):
                j += 1
            else:
                if this_range.start < other_range.start:
                    if ended_inside:
                        ranges.append(Range(next_starting_point, other_range.start))
                        ended_inside = False
                        next_starting_point = None
                    else:
                        ranges.append(Range(this_range.start, other_range.start))
                if this_range.end <= other_range.end:
                    i += 1
                else:
                    if j < other.count - 1:
                        ended_inside = True
                        next_starting_point = other_range.end
                    else:
                        ranges.append(Range(other_range.end, this_range.end))
                    j += 1
        return DiscontinuousRange(ranges)

    def __str__(self) -> str:
        if self.count == 0:
            return "Empty"
        return ", ".join(str(r) for r in self._ranges)

    def __repr__(self) -> str:
        return f"DiscontinuousRange({self._ranges!r})"

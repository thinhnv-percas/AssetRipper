"""Port of Source/AssetRipper.IO.Files/Streams/SplitNameComparer.cs"""
from __future__ import annotations

import functools


def _get_split_index(value: str | None) -> int:
    if not value:
        return -1
    i = len(value) - 1
    while i >= 0 and value[i].isdigit():
        i -= 1
    i += 1
    return int(value[i:])


def compare(x: str | None, y: str | None) -> int:
    x_number, y_number = _get_split_index(x), _get_split_index(y)
    return (x_number > y_number) - (x_number < y_number)


sort_key = functools.cmp_to_key(compare)

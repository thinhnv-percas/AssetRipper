"""Port of Source/AssetRipper.Export.UnityProjects/ExportIdHandler.cs

Uses the `xxhash` PyPI package for XxHash32/64 -- verified to reproduce .NET's
`System.IO.Hashing.XxHash32/64.HashToUInt32/64` for empty input against known reference
vectors (XxHash64("", seed=0) == 0xEF46DB3751D8E999, XxHash32("", seed=0) == 0x02CC5D05).
"""
from __future__ import annotations

import xxhash

_TEN_TO_THE_FIFTEENTH = 1_000_000_000_000_000
_TEN_TO_THE_FIFTH = 100_000

_INT64_MAX = 2**63 - 1
_INT32_MAX = 2**31 - 1
_UINT64_MASK = 2**64 - 1
_UINT32_MASK = 2**32 - 1

MAX_PREFIXED_CLASS_ID_64BIT = _INT64_MAX // _TEN_TO_THE_FIFTEENTH
"""9223 -- the maximum class ID usable as a prefix for export IDs on 64-bit-export-ID
Unity versions."""
MAX_PREFIXED_CLASS_ID_32BIT = _INT32_MAX // _TEN_TO_THE_FIFTH
"""21474 -- same, for 32-bit-export-ID Unity versions."""


def get_main_export_id(class_id_or_asset, value: int = 0) -> int:
    """Overload collapse of GetMainExportID(int)/GetMainExportID(int, uint)/
    GetMainExportID(IUnityObjectBase)/GetMainExportID(IUnityObjectBase, uint)."""
    class_id = class_id_or_asset if isinstance(class_id_or_asset, int) else class_id_or_asset.class_id
    if class_id > MAX_PREFIXED_CLASS_ID_32BIT:
        if value != 0:
            raise ValueError("Unique asset type with non unique modifier")
        return class_id

    assert value < _TEN_TO_THE_FIFTH, f"Value {value} for main export ID must have no more than 5 digits"
    return class_id * _TEN_TO_THE_FIFTH + value


def get_pseudo_random_export_id(asset, seed: int) -> int:
    """Generates an export id that looks random but is reproducible from `seed`. Upstream
    doesn't check for collisions either -- the probability is treated as negligible."""
    if asset.collection.version.greater_than_or_equals(5, 5):
        if asset.class_id > MAX_PREFIXED_CLASS_ID_64BIT:
            export_id = get_pseudo_random_value_64(seed)
        else:
            prefix = asset.class_id * _TEN_TO_THE_FIFTEENTH
            value = get_pseudo_random_value_64(seed) & _UINT64_MASK
            export_id = prefix + (value % _TEN_TO_THE_FIFTEENTH)
    else:
        if asset.class_id > MAX_PREFIXED_CLASS_ID_32BIT:
            export_id = get_pseudo_random_value_32(seed)
        else:
            prefix = asset.class_id * _TEN_TO_THE_FIFTH
            value = get_pseudo_random_value_32(seed) & _UINT32_MASK
            export_id = prefix + (value % _TEN_TO_THE_FIFTH)

    return _to_signed_64(export_id)


def get_pseudo_random_value_64(seed: int) -> int:
    """A random-looking signed 64-bit int derived from `seed` via XxHash64([], seed)."""
    return _to_signed_64(xxhash.xxh64(b"", seed=_to_unsigned_64(seed)).intdigest())


def get_pseudo_random_value_32(seed: int) -> int:
    """A random-looking signed 32-bit int derived from `seed` via XxHash32([], seed)."""
    return _to_signed_32(xxhash.xxh32(b"", seed=_to_unsigned_32(seed)).intdigest())


def _to_unsigned_64(value: int) -> int:
    return value & _UINT64_MASK


def _to_unsigned_32(value: int) -> int:
    return value & _UINT32_MASK


def _to_signed_64(value: int) -> int:
    value &= _UINT64_MASK
    return value - 2**64 if value > _INT64_MAX else value


def _to_signed_32(value: int) -> int:
    value &= _UINT32_MASK
    return value - 2**32 if value > _INT32_MAX else value

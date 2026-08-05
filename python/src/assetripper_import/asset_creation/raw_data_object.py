"""Port of Source/AssetRipper.Import/AssetCreation/{RawDataObject,UnknownObject,UnreadableObject}.cs

Fallbacks for assets whose field layout could not be determined: the raw bytes are kept so
they can still be inspected and round-tripped, but no fields are exposed.

`UnknownObject` means "no layout available for this class ID" -- with the dynamic reader that
happens when a SerializedFile embeds no type tree and no hand-written layout covers the
class. `UnreadableObject` means a layout existed but reading against it failed.

**`.get`/`.items`/`.keys`/`__contains__`/`__getitem__` (added after a real-fixture audit,
Phase 13/17):** a real shipped Unity player build routinely strips embedded type trees from
release builds -- this is not an edge case. Every processor/exporter in this port that calls
`asset.get(field_name)` (the established dynamic-field-access idiom used throughout, e.g.
`scene_helpers.py`, `original_path_processor.py`) previously assumed that always succeeds,
and crashed with `AttributeError` the moment a real asset came through as `RawDataObject`
instead of `TypeTreeObject` -- confirmed against `python/input-test/demo-android.apk`, a real
stripped IL2CPP Android build. Rather than hunting down and guarding every call site
individually, `RawDataObject` exposes the same read-only surface `TypeTreeObject` does
(`get`/`items`/`keys`/`__contains__`/`__getitem__`), always reporting "no fields" -- which is
the truthful answer for an asset whose layout genuinely couldn't be determined. `__setitem__`
is deliberately *not* added: writing a field to an asset with an unknown layout is a real bug
in the caller, not something to silently swallow.
"""
from __future__ import annotations

import zlib

from assetripper_assets.null_object import NullObject

from ..class_id_type import ClassIDType


class RawDataObject(NullObject):
    def __init__(self, asset_info, data: bytes):
        super().__init__(asset_info)
        self.raw_data = data
        self.raw_data_hash = zlib.crc32(data) & 0xFFFFFFFF
        """A CRC32 hash of raw_data (upstream uses AssetRipper.Checksum's Crc32Algorithm;
        zlib.crc32 is the same standard CRC-32)."""

    @property
    def class_name(self) -> str:
        try:
            return ClassIDType(self.class_id).name
        except ValueError:
            # Upstream casts unconditionally, which yields the bare number for class IDs
            # absent from the enum (it has abstract classes removed).
            return str(self.class_id)

    def reset(self) -> None:
        pass

    def get(self, name: str, default=None):
        return default

    def items(self):
        return ()

    def keys(self):
        return ()

    def __contains__(self, name: str) -> bool:
        return False

    def __getitem__(self, name: str):
        raise KeyError(name)


class UnknownObject(RawDataObject):
    @property
    def name(self) -> str:
        return f"Unknown{self.class_name}_{self.raw_data_hash:X}"


class UnreadableObject(RawDataObject):
    def __init__(self, asset_info, data: bytes):
        super().__init__(asset_info, data)
        self._name: str | None = None

    @property
    def name(self) -> str:
        return self._name if self._name else f"Unreadable{self.class_name}_{self.raw_data_hash:X}"

    @name.setter
    def name(self, value: str | None) -> None:
        self._name = value

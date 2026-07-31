"""Port of Source/AssetRipper.Import/AssetCreation/{RawDataObject,UnknownObject,UnreadableObject}.cs

Fallbacks for assets whose field layout could not be determined: the raw bytes are kept so
they can still be inspected and round-tripped, but no fields are exposed.

`UnknownObject` means "no layout available for this class ID" -- with the dynamic reader that
happens when a SerializedFile embeds no type tree and no hand-written layout covers the
class. `UnreadableObject` means a layout existed but reading against it failed.
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

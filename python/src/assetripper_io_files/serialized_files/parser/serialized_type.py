"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/SerializedType.cs"""
from __future__ import annotations

from assetripper_primitives import UnityVersion, UnityVersionType

from ..format_version import FormatVersion
from .serialized_type_base import SerializedTypeBase

_WRITE_ID_HASH_FOR_SCRIPT_TYPE_VERSION = UnityVersion(2018, 3, 0, UnityVersionType.ALPHA, 1)


class SerializedType(SerializedTypeBase):
    def __init__(self):
        super().__init__()
        self.type_dependencies: list[int] = []

    def _ignore_script_type_for_hash(self, format_version: FormatVersion, unity_version: UnityVersion) -> bool:
        # This code is most likely correct, but not guaranteed.
        # Reverse engineering it was painful, and it's possible that mistakes were made.
        return not unity_version.equals(0, 0, 0) and unity_version < _WRITE_ID_HASH_FOR_SCRIPT_TYPE_VERSION

    def _read_type_dependencies(self, reader) -> None:
        self.type_dependencies = reader.read_int32_array()

    def _write_type_dependencies(self, writer) -> None:
        writer.write_int32_array(self.type_dependencies)

    def __eq__(self, other: object) -> bool:
        if not isinstance(other, SerializedType):
            return NotImplemented
        return (
            self.raw_type_id == other.raw_type_id
            and self.is_stripped_type == other.is_stripped_type
            and self.script_type_index == other.script_type_index
            and self.old_type == other.old_type
            and self.script_id == other.script_id
            and self.old_type_hash == other.old_type_hash
            and self.type_dependencies == other.type_dependencies
        )

    def __hash__(self) -> int:
        return hash((
            self.raw_type_id, self.is_stripped_type, self.script_type_index,
            self.old_type_hash, tuple(self.type_dependencies),
        ))

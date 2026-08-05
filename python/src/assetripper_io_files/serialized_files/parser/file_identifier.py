"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/FileIdentifier.cs

A serialized file may be linked with other serialized files to create shared dependencies.
"""
from __future__ import annotations

from dataclasses import dataclass

from assetripper_primitives import UnityGuid

from ...asset_type import AssetType
from ...special_file_names import fix_file_identifier
from ..format_version import FormatVersion
from .endian_extensions import read_unity_guid, write_unity_guid


def has_asset_path(generation: FormatVersion) -> bool:
    """2.1.0 and greater."""
    return generation >= FormatVersion.UNKNOWN_6


def has_hash(generation: FormatVersion) -> bool:
    """1.2.0 and greater."""
    return generation >= FormatVersion.UNKNOWN_5


@dataclass(slots=True)
class FileIdentifier:
    path_name: str = ""
    """File path without such prefixes as archive:/directory/fileName."""
    asset_path: str = ""
    """Virtual asset path. Used for cached files, otherwise empty.
    The file at this path usually doesn't exist, so it's probably an alias."""
    type: AssetType = AssetType.INTERNAL
    """The type of the file."""
    path_name_origin: str = ""
    """Actual file path, relative to the path of the current file. The folder "library"
    often needs to be translated to "resources" to find the file on the file system."""
    guid: UnityGuid = None  # type: ignore[assignment]

    def __post_init__(self) -> None:
        if self.guid is None:
            self.guid = UnityGuid()

    def is_file(self, file) -> bool:
        return file is not None and file.name_fixed == self.path_name

    def read(self, reader) -> None:
        if has_asset_path(reader.generation):
            self.asset_path = reader.read_string_zero_term()
        if has_hash(reader.generation):
            self.guid = read_unity_guid(reader)
            self.type = AssetType(reader.read_int32())
        self.path_name_origin = reader.read_string_zero_term()
        self.path_name = fix_file_identifier(self.path_name_origin)

    def write(self, writer) -> None:
        if has_asset_path(writer.generation):
            writer.write_string_zero_term(self.asset_path)
        if has_hash(writer.generation):
            write_unity_guid(writer, self.guid)
            writer.write_int32(int(self.type))
        writer.write_string_zero_term(self.path_name_origin)

    def get_file_path(self) -> str:
        if self.type == AssetType.META:
            return str(self.guid)
        return self.path_name

    def __str__(self) -> str:
        if self.type == AssetType.META:
            return str(self.guid)
        return self.path_name_origin or super().__str__()

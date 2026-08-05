"""Port of Source/AssetRipper.IO.Files/SerializedFiles/SerializedFileBuilder.cs"""
from __future__ import annotations

from dataclasses import dataclass, field

from assetripper_io_endian import EndianType
from assetripper_primitives import UnityVersion

from ..build_target import BuildTarget
from .format_version import FormatVersion
from .parser.file_identifier import FileIdentifier
from .parser.local_serialized_object_identifier import LocalSerializedObjectIdentifier
from .parser.object_info import ObjectInfo
from .parser.serialized_type import SerializedType
from .parser.serialized_type_reference import SerializedTypeReference


@dataclass(slots=True)
class SerializedFileBuilder:
    generation: FormatVersion = FormatVersion.UNSUPPORTED
    version: UnityVersion = field(default_factory=UnityVersion)
    platform: BuildTarget = BuildTarget.NO_TARGET
    endian_type: EndianType = EndianType.LITTLE_ENDIAN
    dependencies: list[FileIdentifier] = field(default_factory=list)
    script_types: list[LocalSerializedObjectIdentifier] = field(default_factory=list)
    objects: list[ObjectInfo] = field(default_factory=list)
    types: list[SerializedType] = field(default_factory=list)
    ref_types: list[SerializedTypeReference] = field(default_factory=list)
    has_type_tree: bool = False
    user_information: str = ""

    def build(self):
        from .serialized_file import SerializedFile

        return SerializedFile.from_builder(self)

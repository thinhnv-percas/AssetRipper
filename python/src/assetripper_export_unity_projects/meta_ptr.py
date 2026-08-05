"""Port of Source/AssetRipper.Export.UnityProjects/MetaPtr.cs

A serialized pointer: `{fileID: ..., guid: ..., type: ...}` in exported YAML.
"""
from __future__ import annotations

from assetripper_io_files.asset_type import AssetType
from assetripper_primitives import UnityGuid
from assetripper_yaml import MappingStyle, YamlMappingNode

_FILE_ID_NAME = "fileID"
_GUID_NAME = "guid"
_TYPE_NAME = "type"


class MetaPtr:
    __slots__ = ("file_id", "guid", "asset_type")

    def __init__(self, file_id: int, guid: UnityGuid | None = None, asset_type: AssetType = AssetType.SERIALIZED):
        self.file_id = file_id
        self.guid = guid if guid is not None else UnityGuid.ZERO
        self.asset_type = asset_type

    def export_yaml(self, export_version) -> YamlMappingNode:
        node = YamlMappingNode(MappingStyle.FLOW)
        node.add(_FILE_ID_NAME, self.file_id)
        if not self.guid.is_zero:
            node.add(_GUID_NAME, str(self.guid))
            if export_version.greater_than_or_equals(4) or self.asset_type != AssetType.META:
                node.add(_TYPE_NAME, int(self.asset_type))
            else:
                # For Unity 3, type 3 (Meta) is only used for 3d models. All other imported
                # assets (images, audio) use type 1 (Cached). Since we only export yaml
                # meshes and have no plans to change that, redirect type 3 to type 1.
                # https://github.com/AssetRipper/AssetRipper/issues/1827
                # https://github.com/AssetRipper/AssetRipper/issues/1329
                node.add(_TYPE_NAME, int(AssetType.CACHED))
        return node

    def __str__(self) -> str:
        if self.guid.is_zero:
            return f"{{{_FILE_ID_NAME}: {self.file_id}}}"
        return f"{{{_FILE_ID_NAME}: {self.file_id}, {_GUID_NAME}: {self.guid}, {_TYPE_NAME}: {int(self.asset_type)}}}"

    def __eq__(self, other: object) -> bool:
        if not isinstance(other, MetaPtr):
            return NotImplemented
        return self.file_id == other.file_id and self.guid == other.guid and self.asset_type == other.asset_type

    def __hash__(self) -> int:
        return hash((self.file_id, self.guid, self.asset_type))


NULL_PTR = MetaPtr(0)


def create_missing_reference(class_id: int, asset_type: AssetType) -> MetaPtr:
    from .export_id_handler import get_main_export_id

    return MetaPtr(get_main_export_id(class_id), _missing_reference_guid(), asset_type)


def _missing_reference_guid() -> UnityGuid:
    """Upstream's `UnityGuid.MissingReference` sentinel. AssetRipper.Primitives isn't
    vendored in this repo (see assetripper_primitives/unity_guid.py's own disclaimer), so
    the exact bytes are unverified -- this only affects the rare case of a PPtr pointing at
    an asset that can't be found, not normal export correctness.
    """
    return UnityGuid(0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF)

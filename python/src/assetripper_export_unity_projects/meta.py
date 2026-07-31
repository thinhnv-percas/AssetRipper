"""Port of Source/AssetRipper.Export.UnityProjects/Meta.cs

The `.meta` file: a GUID plus an importer object (see project/native_format_importer.py
for the one importer shape currently implemented).
"""
from __future__ import annotations

import os
import time

from assetripper_primitives import UnityGuid
from assetripper_yaml import YamlDocument

_FILE_FORMAT_VERSION_NAME = "fileFormatVersion"
_GUID_NAME = "guid"
_FOLDER_ASSET_NAME = "folderAsset"
_TIME_CREATED_NAME = "timeCreated"
_LICENSE_TYPE_NAME = "licenseType"

_FILE_FORMAT_VERSION = 2
"""Has been 2 for a long time upstream; if Unity 3 used version 1, nobody has recorded
when 2 started."""

_UNITY_EPOCH = 0x089F7FF5F7B58000


class Meta:
    def __init__(self, guid: UnityGuid, importer, has_license: bool = True, is_folder: bool = False):
        if guid.is_zero:
            raise ValueError("guid must not be zero")
        if importer is None:
            raise ValueError("importer must not be None")
        self.guid = guid
        self.importer = importer
        self.has_license_data = has_license
        self.is_folder_asset = is_folder

    def export_yaml_document(self, container) -> YamlDocument:
        from .project.project_yaml_walker import ProjectYamlWalker

        document = YamlDocument()
        root = document.create_mapping_root()
        root.add(_FILE_FORMAT_VERSION_NAME, _FILE_FORMAT_VERSION)
        root.add(_GUID_NAME, str(self.guid))
        if self.is_folder_asset:
            root.add(_FOLDER_ASSET_NAME, True)
        if self.has_license_data:
            root.add(_TIME_CREATED_NAME, _current_tick())
            root.add(_LICENSE_TYPE_NAME, "Free")

        walker = ProjectYamlWalker(container)
        walker.exporting_asset_importer = True
        root.add(self.importer.class_name, walker.export_yaml_node(self.importer))
        return document


def _current_tick() -> int:
    """A Unix-time-ish Unity timestamp. Honors SOURCE_DATE_EPOCH for reproducible builds,
    matching upstream (see https://reproducible-builds.org/docs/source-date-epoch/)."""
    source_date_epoch = os.environ.get("SOURCE_DATE_EPOCH")
    if source_date_epoch is not None:
        try:
            seconds = int(source_date_epoch)
        except ValueError:
            seconds = None
        if seconds is not None:
            return _system_time_to_unity_time(seconds)
    return _system_time_to_unity_time(int(time.time()))


def _system_time_to_unity_time(unix_seconds: int) -> int:
    dotnet_ticks = (unix_seconds + 62135596800) * 10_000_000
    return (dotnet_ticks - _UNITY_EPOCH) // 10_000_000

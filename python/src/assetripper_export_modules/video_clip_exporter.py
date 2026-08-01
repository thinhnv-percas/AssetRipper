"""Port of Source/AssetRipper.Export.UnityProjects/Miscellaneous/
{VideoClipExporter, VideoClipExportCollection}.cs (Phase 13a)

VideoClip's actual video bytes live outside the SerializedFile, in `m_ExternalResources` --
a `StreamingInfo` struct (`path`/`offset`/`size`), the exact shape Texture2D's
`m_StreamData` uses (see `assetripper_import.streamed_resource`, Phase 9) -- so this reuses
that resolver rather than reimplementing it. The output file extension is taken from
`m_OriginalPath`'s own extension (matching upstream's `GetExtensionFromPath`), falling back
to `"bytes"` when there isn't one, since a video's real container format (`.mp4`, `.webm`,
...) isn't otherwise recoverable from the asset data itself.

Two class IDs both mean "VideoClip" across Unity versions (327 and 329, per
`class_id_type.py`'s enum -- same pattern as `AvatarMask_319`/`AvatarMask_1011` or
`LightProbes_197`/`LightProbes_258`); both are wired to this exporter.

Not ported: upstream's `VideoClipExportCollection.CreateImporter` builds a real
`VideoClipImporter` (EndFrame/OriginalHeight/OriginalWidth/SourceFileSize/FrameRate/
ImportAudio) -- a generated importer class this port has no vendored shape for. Same
fallback already used for `MovieTextureAssetExporter` (see that module's docstring): the
base `AssetExportCollection._create_importer` gives a `NativeFormatImporter` instead, which
opens fine in Unity but won't reproduce these importer-specific inspector settings.
"""
from __future__ import annotations

import os

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection
from assetripper_import.streamed_resource import check_integrity, get_streaming_info_content

from .binary_asset_exporter import BinaryAssetExporter

VIDEO_CLIP_CLASS_IDS = (327, 329)
_DEFAULT_EXTENSION = "bytes"


def _external_resources(asset):
    return asset.get("m_ExternalResources")


class VideoClipExporter(BinaryAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        external = _external_resources(asset)
        if external is None:
            return False, None
        path = external.get("path")
        offset = external.get("offset") or 0
        size = external.get("size") or 0
        if not check_integrity(path, offset, size, asset.collection):
            return False, None
        return True, VideoClipExportCollection(self, asset)

    def export(self, container, asset, path: str, file_system) -> bool:
        data = get_streaming_info_content(_external_resources(asset), asset.collection)
        if not self.is_valid_data(data):
            return False
        file_system.file.write_all_bytes(path, data)
        return True


class VideoClipExportCollection(AssetExportCollection):
    def _get_export_extension(self, asset) -> str:
        original_path = asset.get("m_OriginalPath") or ""
        extension = os.path.splitext(original_path)[1]
        return extension[1:] if extension else _DEFAULT_EXTENSION

"""Scoped-down port of Source/AssetRipper.Export.UnityProjects/Audio/
{AudioClipExporter, AudioClipExportCollection, NativeAudioExporter}.cs

Collapses upstream's two audio exporters (the FSB5-decoding `AudioClipExporter` and the
always-raw `NativeAudioExporter`) into one, since this port never actually decodes FSB5
(see audio_clip_decoder.py) -- both would produce the same output here. `m_Resource`
(external `.resS`/StreamedResource) is not wired up, matching the precedent set by
texture2d_exporter.py's `m_StreamData` handling: export is declined rather than guessed at,
so only clips with their audio data directly embedded in `m_AudioData` are exported.
"""
from __future__ import annotations

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection

from .audio_clip_decoder import get_export_extension
from .binary_asset_exporter import BinaryAssetExporter

_AUDIO_CLIP_CLASS_ID = 83


class AudioClipExporter(BinaryAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _AUDIO_CLIP_CLASS_ID and self.is_valid_data(_audio_data_bytes(asset)):
            return True, AudioClipExportCollection(self, asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        data = _audio_data_bytes(asset)
        with file_system.file.create(path) as stream:
            stream.write(data, 0, len(data))
        return True


class AudioClipExportCollection(AssetExportCollection):
    def _get_export_extension(self, asset) -> str:
        return get_export_extension(_audio_data_bytes(asset), asset.get("m_CompressionFormat"))


def _audio_data_bytes(asset) -> bytes:
    """m_AudioData is a TypelessData field, read as list[int] by the dynamic reader."""
    return bytes(asset.get("m_AudioData") or ())

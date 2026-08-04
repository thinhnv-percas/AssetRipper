"""Scoped-down port of Source/AssetRipper.Export.UnityProjects/Audio/
{AudioClipExporter, AudioClipExportCollection, NativeAudioExporter}.cs

Collapses upstream's two audio exporters (the FSB5-decoding `AudioClipExporter` and the
always-raw `NativeAudioExporter`) into one: `audio_clip_decoder.decode` handles both cases
itself (rebuild when the codec is supported, verbatim `.fsb` dump when it isn't), so the two
upstream classes would differ only in which branch of that single function they reach.

`m_Resource` (external `.resS`/StreamedResource) is resolved as a fallback when `m_AudioData` is
empty -- see assetripper_import/streamed_resource.py (Phase 9). Before that, this exporter
declined outright whenever `m_AudioData` was empty, which is the common case: most player
builds stream audio from `.resS` rather than embedding it.

`AudioExportFormat` (Phase 10): accepted for parity with upstream's constructor, but still
has no observable effect. Upstream's `PreferWav` re-encodes a rebuilt `.ogg` as `.wav`, which
needs a Vorbis *decoder* plus a PCM re-encode -- `fsb5` only rebuilds the Ogg stream, it
doesn't decode it, so there is nothing here to convert. `.ogg` is emitted as-is (Unity imports
it natively). See ROADMAP.md Phase 18. Upstream's `Yaml`/`Native` values don't apply either.
"""
from __future__ import annotations

from assetripper_export_configuration.audio_export_format import AudioExportFormat
from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection
from assetripper_import.streamed_resource import get_streamed_resource_content

from .audio_clip_decoder import decode, get_export_extension
from .binary_asset_exporter import BinaryAssetExporter

_AUDIO_CLIP_CLASS_ID = 83


class AudioClipExporter(BinaryAssetExporter):
    def __init__(self, audio_export_format: AudioExportFormat = AudioExportFormat.DEFAULT):
        self.audio_export_format = audio_export_format

    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _AUDIO_CLIP_CLASS_ID and self.is_valid_data(_audio_data_bytes(asset)):
            return True, AudioClipExportCollection(self, asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        data, _extension = decode(_audio_data_bytes(asset), asset.get("m_CompressionFormat"))
        with file_system.file.create(path) as stream:
            stream.write(data, 0, len(data))
        return True


class AudioClipExportCollection(AssetExportCollection):
    def _get_export_extension(self, asset) -> str:
        return get_export_extension(_audio_data_bytes(asset), asset.get("m_CompressionFormat"))


def _audio_data_bytes(asset) -> bytes:
    """m_AudioData is a TypelessData field, read as list[int] by the dynamic reader.
    Falls back to the external m_Resource (StreamedResource) when empty."""
    data = bytes(asset.get("m_AudioData") or ())
    if data:
        return data

    resource = asset.get("m_Resource")
    if resource is not None:
        return get_streamed_resource_content(resource, asset.collection)
    return b""

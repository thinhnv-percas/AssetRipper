"""Port of Source/AssetRipper.Export/Configuration/AudioExportFormat.cs

None of the four modes currently change AudioClipExporter's behavior: `Yaml` would need
YamlAudioExportCollection (not ported, same reasoning as shaders' Yaml mode), and
`PreferWav` needs Ogg-to-WAV transcoding (not ported, see audio_clip_decoder.py's module
docstring -- this port never decodes FSB5 at all, so there's nothing to re-encode).
`Native`/`Default` already match this port's only behavior: dump the container's raw
bytes. The enum is still exposed here (accepted by AudioClipExporter, stored, and
selectable from the Settings page) so the setting round-trips correctly once those modes
are implemented, rather than being silently dropped.
"""
from __future__ import annotations

from enum import IntEnum


class AudioExportFormat(IntEnum):
    YAML = 0
    NATIVE = 1
    DEFAULT = 2
    PREFER_WAV = 3

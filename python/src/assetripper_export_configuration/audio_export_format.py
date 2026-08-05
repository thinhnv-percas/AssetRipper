"""Port of Source/AssetRipper.Export/Configuration/AudioExportFormat.cs

Which modes actually change `AudioClipExporter`'s behavior:

- `Native`/`Default`: dump whatever the FSB5 rebuild produced -- a real `.wav` for PCM modes, a
  real `.ogg` for Vorbis (see audio_clip_decoder.py).
- `PreferWav` (implemented 2026-08-03): additionally transcodes a rebuilt Ogg Vorbis stream to
  PCM-16 WAV. `fsb5` only *rebuilds* the Ogg headers FMOD strips; it does not decode Vorbis, so
  this needs a real decoder -- `soundfile`, whose PyPI wheels bundle libsndfile (Ogg Vorbis
  support since 1.0.29), so unlike `fsb5`'s own native `libvorbis` requirement there is no
  system package to install. Degrades to the `.ogg` with a warning if the decoder is missing.
- `Yaml`: still not implemented -- it would need a `YamlAudioExportCollection`, the same
  reasoning as shaders' Yaml mode.

The enum is exposed in full (accepted by `AudioClipExporter`, stored, and selectable from the
Settings page) so the setting round-trips correctly rather than being silently dropped.
"""
from __future__ import annotations

from enum import IntEnum


class AudioExportFormat(IntEnum):
    YAML = 0
    NATIVE = 1
    DEFAULT = 2
    PREFER_WAV = 3

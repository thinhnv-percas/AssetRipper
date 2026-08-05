"""Port of Source/AssetRipper.SourceGenerated.Extensions/AudioCompressionFormatExtentions.cs

`AudioCompressionFormat` itself is not vendored here (it lives in the un-generated
`AssetRipper.SourceGenerated.Enums`), but it is also Unity's own public scripting enum
(https://docs.unity3d.com/ScriptReference/AudioCompressionFormat.html) with stable,
documented ordinals -- unlike the internal FMOD-native enums this module deliberately
avoids (see audio_clip_decoder.py's module docstring), so reconstructing it here carries
much less risk of being silently wrong.
"""
from __future__ import annotations

from enum import IntEnum


class AudioCompressionFormat(IntEnum):
    PCM = 0
    VORBIS = 1
    ADPCM = 2
    MP3 = 3
    VAG = 4
    HEVAG = 5
    XMA = 6
    AAC = 7
    GCADPCM = 8
    ATRAC9 = 9


_RAW_EXTENSIONS = {
    AudioCompressionFormat.PCM: "fsb",
    AudioCompressionFormat.VORBIS: "fsb",
    AudioCompressionFormat.ADPCM: "fsb",
    AudioCompressionFormat.MP3: "fsb",
    AudioCompressionFormat.GCADPCM: "fsb",
    AudioCompressionFormat.VAG: "vag",
    AudioCompressionFormat.HEVAG: "vag",
    AudioCompressionFormat.XMA: "wav",
    AudioCompressionFormat.AAC: "m4a",
    AudioCompressionFormat.ATRAC9: "at9",
}


def to_raw_extension(compression_format: "int | AudioCompressionFormat | None") -> str:
    try:
        return _RAW_EXTENSIONS.get(AudioCompressionFormat(compression_format), "audioClip")
    except ValueError:
        return "audioClip"

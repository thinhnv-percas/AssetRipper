"""
Test-only builder for a minimal but *genuinely valid* FSB5 container, following the same
hand-build-both-sides-of-the-contract discipline as `import_/_tree_builder.py` and
`io_files_bundle/_bundle_builder.py`.

PCM16 mode specifically, because that's the one real codec `fsb5` can rebuild with no native
library present -- Vorbis rebuilds need `libvorbis.so`, which is a system package and can't be
assumed in CI. So this fixture keeps the *decode* path (not just the fallback path) covered
deterministically. The Vorbis path is covered instead by the real-fixture test on
`demo-android.apk`, whose 11 clips are all Vorbis.

Header layout is taken from FSB5's own structure as parsed by the `fsb5` package: a 60-byte
header (`4s I I I I I I 8s 16s 8s`), then one 8-byte packed sample header per sample, then the
optional name table, then sample data.
"""
from __future__ import annotations

import struct

_FSB5_HEADER_FORMAT = "<4sIIIIII8s16s8s"
_PCM16_MODE = 2

# The frequency table FSB5 packs into the sample header's 4-bit frequency field; index 8 is
# 44100 Hz. Anything not in that table needs an explicit FREQUENCY metadata chunk instead.
_FREQUENCY_44100 = 8


def build_pcm16_fsb5(pcm_frames: bytes, *, channels: int = 1) -> bytes:
    """A one-sample PCM16 FSB5 container wrapping `pcm_frames` (raw little-endian 16-bit PCM).

    `fsb5` decodes this to a real RIFF/WAVE file, so a test can assert on actual audio output
    rather than on a fallback dump.
    """
    if len(pcm_frames) % 2:
        raise ValueError("PCM16 data must be an even number of bytes")
    sample_count = len(pcm_frames) // 2 // channels

    # Packed 64-bit sample header: next_chunk(1) | frequency(4) | channels(1) | offset(28) |
    # samples(30). next_chunk is 0 (no metadata chunks) and dataOffset is 0 (first sample).
    packed = (
        (0)
        | (_FREQUENCY_44100 << 1)
        | ((channels - 1) << 5)
        | (0 << 6)
        | (sample_count << 34)
    )
    sample_headers = struct.pack("<Q", packed)

    # Sample data must be padded to a 16-byte boundary, since dataOffset is stored in 16-byte
    # units (the parser multiplies it by 16).
    data = pcm_frames + b"\x00" * (-len(pcm_frames) % 16)

    header = struct.pack(
        _FSB5_HEADER_FORMAT,
        b"FSB5",
        1,  # version (non-zero, so no extra 'unknown' uint32 follows)
        1,  # numSamples
        len(sample_headers),  # sampleHeadersSize
        0,  # nameTableSize -- samples fall back to their index-based name ("0000")
        len(data),  # dataSize
        _PCM16_MODE,
        b"\x00" * 8,
        b"\x00" * 16,
        b"\x00" * 8,
    )
    return header + sample_headers + data

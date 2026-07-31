"""Scoped-down port of Source/AssetRipper.Export.Modules.Audio/AudioClipDecoder.cs

Upstream decodes the FMOD FSB5 container via the Fmod5Sharp NuGet package: for supported
codecs (PCM variants, Vorbis via a bundled setup-header reconstruction, ...) it rebuilds a
standard .wav/.ogg file; for anything Fmod5Sharp doesn't recognize, it falls back to a raw
`.fsb` dump. This port does not attempt the FSB5 rebuild at all -- the per-sample header in
that container packs channel count/frequency/loop-points into extended chunks whose exact
layout isn't documented in this repo and isn't safe to guess (an off-by-one here would
silently produce a corrupt or mislabeled audio file, exactly what this project's testing
discipline exists to avoid -- see e.g. md4.py's insistence on verifying against real RFC
vectors before trusting a hash implementation). So every FSB5-detected clip is treated the
same way upstream treats an *unsupported* codec: dumped verbatim as `.fsb`.

What IS ported at full fidelity: the container-sniffing magic-byte checks upstream uses for
the tracker-module formats (IT/XM/S3M/MOD), which Unity/FMOD store un-transcoded -- these
are simple, well-defined byte patterns with no risk of misinterpretation, so raw passthrough
with the right extension is both safe and correct.
"""
from __future__ import annotations

from .audio_compression_format import to_raw_extension

_FSB5_EXTENSION = "fsb"
_IT_MAGIC = b"IMPM"
_IT_EXTENSION = "it"
_XM_MAGIC = b"Extended Module: "
_XM_EXTENSION = "xm"
_S3M_MAGIC = b"SCRM"
_S3M_MAGIC_OFFSET = 156
_S3M_EXTENSION = "s3m"
_MOD_MAGICS = (b"M.K.", b"M!K!", b"FLT4", b"FLT8", b"4CHN", b"6CHN", b"8CHN")
_MOD_MAGIC_OFFSET = 1080
_MOD_EXTENSION = "mod"


def get_export_extension(raw_data: bytes, compression_format: "int | None" = None) -> str:
    """The file extension `raw_data` should be dumped under. `raw_data` is always written
    back out unmodified -- see this module's docstring for why no FSB5 rebuild is attempted."""
    if _check_magic(raw_data, b"FSB5"):
        return _FSB5_EXTENSION
    if _check_magic(raw_data, _IT_MAGIC):
        return _IT_EXTENSION
    if _check_magic(raw_data, _XM_MAGIC):
        return _XM_EXTENSION
    if _check_magic(raw_data, _S3M_MAGIC, _S3M_MAGIC_OFFSET):
        return _S3M_EXTENSION
    if any(_check_magic(raw_data, magic, _MOD_MAGIC_OFFSET) for magic in _MOD_MAGICS):
        return _MOD_EXTENSION
    return to_raw_extension(compression_format)


def _check_magic(data: bytes, magic: bytes, start_index: int = 0) -> bool:
    return len(data) >= start_index + len(magic) and data[start_index:start_index + len(magic)] == magic

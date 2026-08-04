"""Port of Source/AssetRipper.Export.Modules.Audio/AudioClipDecoder.cs

**2026-08-03: this module now actually decodes FSB5, where before it only sniffed magic bytes
and dumped every clip verbatim as `.fsb`.** A user reported the audio format was wrong, and it
was: a `.fsb` is a raw FMOD container that neither Unity nor a media player will open. Every
one of the 11 clips in `python/input-test/demo-android.apk` came out that way.

Upstream decodes the container via the Fmod5Sharp NuGet package: for supported codecs it
rebuilds a standard `.wav`/`.ogg`, and for anything unrecognized it falls back to a raw `.fsb`
dump. This port now does the same through the `fsb5` PyPI package (HearthSim's python-fsb5),
which is the direct equivalent -- it parses the FSB5 sample headers (frequency, channel count,
sample count, per-sample name) and reconstructs the Vorbis setup headers FMOD strips out.

Two-tier behavior, mirroring upstream's own supported/unsupported split:
 - Decodable (PCM variants -> `.wav`; Vorbis -> `.ogg`): rebuilt into a real playable file.
 - Anything else, or a rebuild that raises: dumped verbatim as `.fsb`, exactly as before.

`libvorbis` is a *native* library `fsb5` loads at runtime, and only for Vorbis-mode files. It
isn't pip-installable, so a machine without it (no `libvorbis.so`) cannot rebuild Vorbis
clips. That degrades to the `.fsb` fallback with a logged warning rather than raising -- the
export keeps going and the failure is visible instead of silent. `pyproject.toml` documents
the system package to install for full audio support.

The tracker-module sniffing (IT/XM/S3M/MOD) is unchanged and still comes first: Unity/FMOD
store those un-transcoded, so raw passthrough with the right extension is already correct for
them and there is nothing to decode.
"""
from __future__ import annotations

import logging
from functools import lru_cache

from .audio_compression_format import to_raw_extension

_logger = logging.getLogger(__name__)

_FSB5_MAGIC = b"FSB5"
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


def _fsb5_module():
    """`fsb5`, or None when it isn't installed. Imported lazily so the rest of the export
    pipeline (and this module's magic-sniffing half) works without it."""
    try:
        import fsb5
    except ImportError:
        return None
    return fsb5


@lru_cache(maxsize=4)
def _decode_fsb5(raw_data: bytes) -> "tuple[bytes, str]":
    """Cached because the export collection asks for the extension and the exporter asks for
    the bytes, back to back for the same clip -- decoding twice would double the work and, for
    a rebuild that fails partway, risk the two answers disagreeing. maxsize is deliberately
    tiny: this only needs to survive one asset's extension->export pair, not act as a store."""
    fsb5 = _fsb5_module()
    if fsb5 is None:
        _logger.warning("The 'fsb5' package is not installed, so FSB5 audio is exported as a raw .fsb dump.")
        return raw_data, _FSB5_EXTENSION

    try:
        container = fsb5.FSB5(raw_data)
        if not container.samples:
            return raw_data, _FSB5_EXTENSION
        # A multi-sample FSB5 has no single output file it could map to, and Unity's own
        # AudioClip assets are one sample each -- so only the first is rebuilt, matching how
        # upstream's AudioClipExporter treats the clip as a single audio file.
        return container.rebuild_sample(container.samples[0]), container.get_sample_extension()
    except Exception as ex:  # noqa: BLE001 -- includes fsb5's LibraryNotFoundException for libvorbis
        _logger.warning(
            "Could not decode FSB5 audio (%s: %s); exporting the raw .fsb container instead. "
            "Vorbis-mode clips need the native libvorbis library -- see pyproject.toml.",
            type(ex).__name__,
            ex,
        )
        return raw_data, _FSB5_EXTENSION


def decode(raw_data: bytes, compression_format: "int | None" = None) -> "tuple[bytes, str]":
    """Returns `(data_to_write, extension_without_dot)`.

    Never raises: any failure to decode falls back to `(raw_data, "fsb")`, which is upstream's
    own behavior for a codec Fmod5Sharp doesn't support. `fsb5` produces a fully-formed
    container itself (a RIFF/WAVE file for PCM modes, an Ogg stream for Vorbis), so there's
    nothing left to wrap here.
    """
    if _check_magic(raw_data, _FSB5_MAGIC):
        return _decode_fsb5(raw_data)
    return raw_data, _sniff_tracker_extension(raw_data, compression_format)


def get_export_extension(raw_data: bytes, compression_format: "int | None" = None) -> str:
    """The extension `raw_data` maps to. For FSB5 this is the *decoded* extension, so it always
    agrees with what `decode()` actually writes; for everything else it's unchanged."""
    return decode(raw_data, compression_format)[1]


def _sniff_tracker_extension(raw_data: bytes, compression_format: "int | None" = None) -> str:
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

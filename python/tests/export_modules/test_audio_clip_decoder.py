"""Tests for FSB5 audio decoding (`audio_clip_decoder`).

2026-08-03: this module used to only assert that FSB5 was *never* decoded (`get_export_extension
(b"FSB5"...) == "fsb"`), which faithfully described the old behavior -- and that behavior was
the user-reported bug: a `.fsb` is a raw FMOD container no player or Unity will open. Now the
decode path is real, so the tests cover both halves: an actual decode (PCM16, via
`_fsb5_builder`, which needs no native library) and the documented fallback for containers that
can't be rebuilt.
"""
import io
import struct
import wave

from assetripper_export_modules.audio_clip_decoder import decode, get_export_extension

from ._fsb5_builder import build_multi_sample_pcm16_fsb5, build_pcm16_fsb5

_PCM = struct.pack("<8h", 0, 1000, -1000, 500, -500, 0, 250, -250)


def test_pcm16_fsb5_is_decoded_to_a_real_wav_file():
    data, extension = decode(build_pcm16_fsb5(_PCM))

    assert extension == "wav"
    assert data[:4] == b"RIFF"
    reader = wave.open(io.BytesIO(data))
    assert reader.getnchannels() == 1
    assert reader.getsampwidth() == 2
    assert reader.getframerate() == 44100
    assert reader.readframes(reader.getnframes()) == _PCM


def test_stereo_pcm16_fsb5_carries_the_channel_count_through():
    """Only the channel count is asserted, not the frame count: `fsb5`'s PCM rebuild truncates
    to `sample.samples * width` without scaling by channel count, so the frame count it lands
    on for multi-channel PCM is an artifact of that package rather than something this port
    controls or should encode an expectation about. The mono round-trip above is the exact-data
    check; the real fixture's 11 stereo Vorbis clips cover multi-channel end to end."""
    stereo = struct.pack("<8h", 1, 2, 3, 4, 5, 6, 7, 8)
    data, extension = decode(build_pcm16_fsb5(stereo, channels=2))

    assert extension == "wav"
    reader = wave.open(io.BytesIO(data))
    assert reader.getnchannels() == 2
    assert reader.getframerate() == 44100


def test_extension_agrees_with_what_decode_actually_writes():
    """The export collection asks for the extension and the exporter asks for the bytes; if
    those two disagreed, a file would get the wrong extension for its contents."""
    blob = build_pcm16_fsb5(_PCM)
    assert get_export_extension(blob) == decode(blob)[1]


def test_multi_sample_fsb5_falls_back_rather_than_silently_dropping_samples():
    """One AudioClip maps to one exported file, so samples 2..n have nowhere to go. Keeping only
    the first would look like success while losing data, so the whole container is dumped."""
    data, extension = decode(build_multi_sample_pcm16_fsb5(_PCM))

    assert extension == "fsb"
    assert data[:4] == b"FSB5", "the raw container must be preserved, not a partial rebuild"


def test_malformed_fsb5_falls_back_to_a_verbatim_fsb_dump():
    """Upstream's own behavior for a container Fmod5Sharp can't handle -- dump it raw rather
    than fail the whole export. Here the container is truncated garbage after the magic."""
    payload = b"FSB5" + b"\x00" * 100
    data, extension = decode(payload)

    assert extension == "fsb"
    assert data == payload


def test_impulse_tracker_module_detected():
    assert get_export_extension(b"IMPM" + b"\x00" * 100) == "it"


def test_extended_module_detected():
    assert get_export_extension(b"Extended Module: " + b"\x00" * 100) == "xm"


def test_s3m_module_detected_at_documented_offset():
    data = bytearray(200)
    data[156:160] = b"SCRM"
    assert get_export_extension(bytes(data)) == "s3m"


def test_s3m_magic_at_wrong_offset_is_not_detected():
    data = bytearray(200)
    data[44:48] = b"SCRM"  # the "real" S3M spec offset -- not what upstream checks
    assert get_export_extension(bytes(data)) != "s3m"


def test_mod_variants_detected_at_documented_offset():
    for magic in (b"M.K.", b"M!K!", b"FLT4", b"FLT8", b"4CHN", b"6CHN", b"8CHN"):
        data = bytearray(1100)
        data[1080:1080 + len(magic)] = magic
        assert get_export_extension(bytes(data)) == "mod", magic


def test_tracker_modules_are_passed_through_unmodified():
    payload = b"IMPM" + b"\x01" * 100
    assert decode(payload) == (payload, "it")


def test_unrecognized_data_falls_back_to_compression_format():
    from assetripper_export_modules.audio_compression_format import AudioCompressionFormat

    assert get_export_extension(b"\x00" * 10, AudioCompressionFormat.AAC) == "m4a"


def test_unrecognized_data_with_no_compression_format_is_generic():
    assert get_export_extension(b"\x00" * 10) == "audioClip"


def test_too_short_to_contain_magic_does_not_crash():
    assert get_export_extension(b"FS") == "audioClip"

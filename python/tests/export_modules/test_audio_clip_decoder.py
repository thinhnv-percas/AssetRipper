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

import pytest

from assetripper_export_modules.audio_clip_decoder import decode, get_export_extension

from ._fsb5_builder import build_multi_sample_pcm16_fsb5, build_pcm16_fsb5

_PCM = struct.pack("<8h", 0, 1000, -1000, 500, -500, 0, 250, -250)


@pytest.fixture(autouse=True)
def _clear_decode_caches():
    """`decode` memoizes on the raw payload so the extension and the bytes can never be derived
    twice and disagree (see `_decode_fsb5`). That is right in production -- the key is the real
    audio data -- but across tests the same short stub payload would return an earlier test's
    result, so the caches are cleared around every test."""
    import assetripper_export_modules.audio_clip_decoder as module

    module._decode_fsb5.cache_clear()
    module._decode_fsb5_preferring_wav.cache_clear()
    yield
    module._decode_fsb5.cache_clear()
    module._decode_fsb5_preferring_wav.cache_clear()


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


# -- AudioExportFormat.PreferWav (2026-08-03) ---------------------------------------------


def _ogg_bytes() -> bytes:
    """A real Ogg Vorbis stream, encoded here rather than checked in as a fixture so the test
    stays readable and cannot drift from what the decoder is asked to consume."""
    soundfile = pytest.importorskip("soundfile")
    import io

    import numpy

    frames = 4410  # 0.1s at 44.1 kHz
    tone = (numpy.sin(numpy.arange(frames) * 0.05) * 8000).astype(numpy.int16).reshape(-1, 1)
    buffer = io.BytesIO()
    soundfile.write(buffer, tone, 44100, format="OGG", subtype="VORBIS")
    return buffer.getvalue()


def test_prefer_wav_transcodes_a_vorbis_clip_to_a_real_wav(monkeypatch):
    """The gap this closes: `fsb5` only rebuilds the Ogg headers FMOD strips, it never decodes
    Vorbis, so PreferWav needed an actual decoder."""
    import assetripper_export_modules.audio_clip_decoder as module

    ogg = _ogg_bytes()
    monkeypatch.setattr(module, "_decode_fsb5", lambda raw: (ogg, "ogg"))

    data, extension = module.decode(b"FSB5" + b"\x00" * 60, None, True)

    assert extension == "wav"
    assert data[:4] == b"RIFF" and data[8:12] == b"WAVE"
    reader = wave.open(io.BytesIO(data))
    assert reader.getframerate() == 44100
    assert reader.getsampwidth() == 2, "PCM-16, which is what Unity imports audio as by default"
    assert reader.getnframes() > 0


def test_without_prefer_wav_a_vorbis_clip_stays_ogg(monkeypatch):
    import assetripper_export_modules.audio_clip_decoder as module

    monkeypatch.setattr(module, "_decode_fsb5", lambda raw: (b"OggS-stub", "ogg"))

    assert module.decode(b"FSB5" + b"\x00" * 60, None, False) == (b"OggS-stub", "ogg")


def test_prefer_wav_leaves_an_already_wav_pcm_clip_untouched():
    """PCM modes already come back as WAV from `fsb5`, so PreferWav must not re-encode them --
    a needless decode/encode round trip on data that is already in the target format."""
    blob = build_pcm16_fsb5(_PCM)

    plain = decode(blob)
    preferred = decode(blob, None, True)

    assert preferred == plain
    assert preferred[1] == "wav"


def test_prefer_wav_does_not_touch_an_fsb_fallback():
    """A container that could not be rebuilt has nothing to transcode, and must still come out as
    the verbatim `.fsb` rather than being mangled."""
    payload = b"FSB5" + b"\x00" * 100

    assert decode(payload, None, True) == (payload, "fsb")


def test_prefer_wav_falls_back_to_ogg_when_no_decoder_is_available(monkeypatch, caplog):
    """`soundfile` is a real dependency, but a broken install (missing bundled libsndfile) must
    cost the WAV transcode only, not the whole audio export."""
    import assetripper_export_modules.audio_clip_decoder as module

    monkeypatch.setattr(module, "_decode_fsb5", lambda raw: (b"OggS-stub", "ogg"))
    monkeypatch.setattr(module, "_soundfile_module", lambda: None)

    with caplog.at_level("WARNING"):
        data, extension = module.decode(b"FSB5" + b"\x00" * 60, None, True)

    assert (data, extension) == (b"OggS-stub", "ogg")
    assert "soundfile" in caplog.text


def test_prefer_wav_falls_back_to_ogg_on_a_corrupt_stream(monkeypatch, caplog):
    import assetripper_export_modules.audio_clip_decoder as module

    monkeypatch.setattr(module, "_decode_fsb5", lambda raw: (b"OggS" + b"\xff" * 200, "ogg"))

    with caplog.at_level("WARNING"):
        data, extension = module.decode(b"FSB5" + b"\x00" * 60, None, True)

    assert extension == "ogg"
    assert data[:4] == b"OggS"


def test_the_extension_still_agrees_with_the_bytes_under_prefer_wav(monkeypatch):
    """The export collection asks for the extension and the exporter asks for the bytes; under
    PreferWav they go through a second transcode step, so the two must still agree."""
    import assetripper_export_modules.audio_clip_decoder as module

    ogg = _ogg_bytes()
    monkeypatch.setattr(module, "_decode_fsb5", lambda raw: (ogg, "ogg"))
    blob = b"FSB5" + b"\x00" * 60

    assert module.get_export_extension(blob, None, True) == module.decode(blob, None, True)[1]


def test_the_exporter_only_prefers_wav_for_that_format():
    from assetripper_export_configuration.audio_export_format import AudioExportFormat
    from assetripper_export_modules.audio_clip_exporter import AudioClipExporter

    assert AudioClipExporter(AudioExportFormat.PREFER_WAV).prefer_wav is True
    for other in (AudioExportFormat.DEFAULT, AudioExportFormat.NATIVE, AudioExportFormat.YAML):
        assert AudioClipExporter(other).prefer_wav is False

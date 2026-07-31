from assetripper_export_modules.audio_clip_decoder import get_export_extension


def test_fsb5_container_is_dumped_as_fsb():
    assert get_export_extension(b"FSB5" + b"\x00" * 100) == "fsb"


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


def test_unrecognized_data_falls_back_to_compression_format():
    from assetripper_export_modules.audio_compression_format import AudioCompressionFormat

    assert get_export_extension(b"\x00" * 10, AudioCompressionFormat.AAC) == "m4a"


def test_unrecognized_data_with_no_compression_format_is_generic():
    assert get_export_extension(b"\x00" * 10) == "audioClip"


def test_too_short_to_contain_magic_does_not_crash():
    assert get_export_extension(b"FS") == "audioClip"

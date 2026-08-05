from assetripper_export_modules.audio_compression_format import AudioCompressionFormat, to_raw_extension


def test_known_formats_map_to_documented_extensions():
    assert to_raw_extension(AudioCompressionFormat.PCM) == "fsb"
    assert to_raw_extension(AudioCompressionFormat.VORBIS) == "fsb"
    assert to_raw_extension(AudioCompressionFormat.ADPCM) == "fsb"
    assert to_raw_extension(AudioCompressionFormat.MP3) == "fsb"
    assert to_raw_extension(AudioCompressionFormat.GCADPCM) == "fsb"
    assert to_raw_extension(AudioCompressionFormat.VAG) == "vag"
    assert to_raw_extension(AudioCompressionFormat.HEVAG) == "vag"
    assert to_raw_extension(AudioCompressionFormat.XMA) == "wav"
    assert to_raw_extension(AudioCompressionFormat.AAC) == "m4a"
    assert to_raw_extension(AudioCompressionFormat.ATRAC9) == "at9"


def test_unknown_ordinal_falls_back_to_generic_extension():
    assert to_raw_extension(999) == "audioClip"


def test_none_falls_back_to_generic_extension():
    assert to_raw_extension(None) == "audioClip"


def test_plain_int_ordinal_works_like_the_enum_member():
    assert to_raw_extension(0) == to_raw_extension(AudioCompressionFormat.PCM)

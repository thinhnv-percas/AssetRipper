"""Phase 14: `CompressedFiles/Brotli/{BrotliFile,BrotliFileScheme}.cs` port.

`is_brotli_file`'s detection heuristic doesn't run a real Brotli decoder -- it partially
parses the Brotli meta-block header to recover the length Unity's uncompressed signature
meta-block declares, and compares it against the known signature length. The synthetic byte
sequence below is a hand-built instance of that header shape (see the module docstring in
`brotli_file.py` for the exact bit layout this reverses), not a byte-for-byte replica of
what a real Brotli encoder produces -- there is no publicly documented way to force Python's
`brotli` encoder to emit Unity's specific "plaintext signature as first uncompressed
meta-block" framing, so the heuristic and the decompression path are tested independently.
"""
from assetripper_io_files.compressed_files.brotli.brotli_file import _BROTLI_SIGNATURE, BrotliFile
from assetripper_io_files.compressed_files.brotli.brotli_file_scheme import BrotliFileScheme
from assetripper_io_files.streams.smart import SmartStream

# byte0: skipped entirely. byte1 (=145): low 2 bits = 1 (sizeBytes=1), bits 2-7 = 36 (0x24).
# byte2 (=0): low 2 bits = 0, contributes nothing extra -- so length == 36 == len(signature).
_HEURISTIC_HEADER = bytes([0, 145, 0])


def test_is_brotli_file_recognizes_the_unity_signature_header():
    stream = SmartStream.create_memory(bytearray(_HEURISTIC_HEADER + _BROTLI_SIGNATURE + b"tail"))
    assert BrotliFile.is_brotli_file(stream)
    assert stream.position == 0  # detection must not consume the stream


def test_is_brotli_file_rejects_wrong_length():
    wrong_length_header = bytes([0, 149, 0])  # still declares length 37
    stream = SmartStream.create_memory(bytearray(wrong_length_header + b"not the signature, wrong content!!!!"))
    assert not BrotliFile.is_brotli_file(stream)


def test_is_brotli_file_rejects_too_short_stream():
    stream = SmartStream.create_memory(bytearray(b"\x00\x01"))
    assert not BrotliFile.is_brotli_file(stream)


def test_brotli_scheme_can_read_matches_is_brotli_file():
    stream = SmartStream.create_memory(bytearray(_HEURISTIC_HEADER + _BROTLI_SIGNATURE))
    assert BrotliFileScheme().can_read(stream)


def test_brotli_file_decompresses_real_brotli_data():
    import brotli

    original = b"hello world" * 50
    payload = brotli.compress(original)
    stream = SmartStream.create_memory(bytearray(payload))

    brotli_file = BrotliFile()
    brotli_file.file_path = "/game/level0.data.br"
    brotli_file.name = "level0.data.br"
    brotli_file.read(stream)

    assert brotli_file.uncompressed_file is not None
    assert brotli_file.uncompressed_file.to_byte_array() == original


def test_brotli_file_becomes_a_failed_file_on_corrupt_data():
    from assetripper_io_files.failed_file import FailedFile

    stream = SmartStream.create_memory(bytearray(b"definitely not valid brotli data at all"))
    brotli_file = BrotliFile()
    brotli_file.file_path = "/game/bad.br"
    brotli_file.name = "bad.br"
    brotli_file.read(stream)

    assert isinstance(brotli_file.uncompressed_file, FailedFile)
    assert brotli_file.uncompressed_file.stack_trace

"""Phase 14: `CompressedFiles/GZip/{GZipFile,GZipFileScheme}.cs` port -- a WebGL `.data.gz`
style file: the whole stream is one gzip member wrapping a `ResourceFile`.
"""
import gzip

from assetripper_io_files.compressed_files.gzip.gzip_file_scheme import GZipFileScheme
from assetripper_io_files.streams.smart import SmartStream


def test_gzip_scheme_recognizes_a_gzip_stream():
    payload = gzip.compress(b"hello world" * 10)
    stream = SmartStream.create_memory(bytearray(payload))
    assert GZipFileScheme().can_read(stream)
    assert stream.position == 0  # can_read must not consume the stream


def test_gzip_scheme_rejects_non_gzip_data():
    stream = SmartStream.create_memory(bytearray(b"just some plain text"))
    assert not GZipFileScheme().can_read(stream)


def test_gzip_file_decompresses_to_a_resource_file():
    original = b"hello world" * 50
    payload = gzip.compress(original)
    stream = SmartStream.create_memory(bytearray(payload))

    scheme = GZipFileScheme()
    assert scheme.can_read(stream)
    stream.position = 0
    gzip_file = scheme.read(stream, "/game/level0.data.gz", "level0.data.gz")

    assert gzip_file.uncompressed_file is not None
    assert gzip_file.uncompressed_file.to_byte_array() == original


def test_gzip_file_becomes_a_failed_file_on_corrupt_data():
    payload = gzip.compress(b"data")
    corrupted = bytearray(payload)
    corrupted[-1] ^= 0xFF  # corrupt the trailing CRC/size footer... may still decompress
    corrupted[10] ^= 0xFF  # corrupt inside the compressed stream itself
    stream = SmartStream.create_memory(corrupted)

    gzip_file = GZipFileScheme().read(stream, "/game/bad.data.gz", "bad.data.gz")

    from assetripper_io_files.failed_file import FailedFile

    assert isinstance(gzip_file.uncompressed_file, FailedFile)
    assert gzip_file.uncompressed_file.stack_trace

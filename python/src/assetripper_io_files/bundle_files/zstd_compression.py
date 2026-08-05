"""Port of Source/AssetRipper.IO.Files/BundleFiles/ZstdCompression.cs

Some real-world UnityFS bundles carry Zstandard-compressed blocks tagged with a
`CompressionType` value this port's enum doesn't name (Unity added Zstd support after the
upstream `CompressionType` enum was last extended) -- upstream itself detects this case by
signature-sniffing the block's first 4 bytes against the standard Zstd frame magic rather
than trusting the declared compression type, so this does the same (see
file_stream/bundle_file_block_reader.py's dispatch, mirroring the C# `default:` branch).
"""
from __future__ import annotations

from ..streams.stream import MemoryStream

_ZSTD_MAGIC = bytes((0x28, 0xB5, 0x2F, 0xFD))


def is_zstd(stream) -> bool:
    position = stream.position
    buffer = bytearray(4)
    stream.read_exactly(buffer)
    stream.position = position
    return bytes(buffer) == _ZSTD_MAGIC


def decompress_stream(compressed_stream, compressed_size: int, decompressed_stream, decompressed_size: int) -> None:
    import zstandard

    base_position = compressed_stream.position
    payload = bytearray(compressed_size)
    compressed_stream.read_exactly(payload)
    compressed_stream.position = base_position + compressed_size

    decompressor = zstandard.ZstdDecompressor()
    output = decompressor.decompress(bytes(payload), max_output_size=decompressed_size)
    decompressed_stream.write(output)

"""Port of Source/AssetRipper.IO.Files/BundleFiles/LzmaCompression.cs

Unity's bundle LZMA blocks use the legacy "LZMA_alone" header layout without the
8-byte uncompressed-size field: 5 properties bytes followed directly by a raw LZMA1
stream. Python's stdlib `lzma` module doesn't expose that layout directly, but
`lzma.FORMAT_RAW` with an explicit LZMA1 filter (dict_size/lc/lp/pb decoded from the
5 properties bytes, per the classic 7-Zip SDK format) produces byte-identical results
-- verified against Python's own FORMAT_ALONE compressor round-trip.

Only decompression is ported: the C# FileStreamBundleFile.WriteFileStreamMetadata
itself throws NotImplementedException for CompressionType.Lzma, so there is no
compression path to port from AssetRipper for this format.
"""
from __future__ import annotations

import lzma

from ..exceptions import DecompressionFailedException
from .compression_type import CompressionType

_PROPERTIES_SIZE = 5


def _parse_properties(properties: bytes) -> tuple[int, int, int, int]:
    d = properties[0]
    lc = d % 9
    d //= 9
    lp = d % 5
    pb = d // 5
    dict_size = int.from_bytes(properties[1:5], "little")
    return lc, lp, pb, dict_size


def decompress_lzma_stream(compressed_stream, compressed_size: int, decompressed_stream, decompressed_size: int) -> None:
    """Reads LZMA properties and decompresses LZMA data."""
    base_position = compressed_stream.position

    properties = bytearray(_PROPERTIES_SIZE)
    compressed_stream.read_exactly(properties)

    head_size = compressed_stream.position - base_position
    headless_size = compressed_size - head_size

    _decompress_lzma_stream(bytes(properties), compressed_stream, headless_size, decompressed_stream, decompressed_size)

    if compressed_stream.position > base_position + compressed_size:
        DecompressionFailedException.throw_read_more_than_expected(
            compressed_size, compressed_stream.position - base_position, compression=CompressionType.LZMA
        )
    compressed_stream.position = base_position + compressed_size


def _decompress_lzma_stream(properties: bytes, compressed_stream, headless_size: int, decompressed_stream, decompressed_size: int) -> None:
    lc, lp, pb, dict_size = _parse_properties(properties)
    filters = [{"id": lzma.FILTER_LZMA1, "dict_size": dict_size, "lc": lc, "lp": lp, "pb": pb}]

    payload = bytearray(headless_size)
    compressed_stream.read_exactly(payload)

    decompressor = lzma.LZMADecompressor(format=lzma.FORMAT_RAW, filters=filters)
    output = decompressor.decompress(bytes(payload), max_length=decompressed_size)
    decompressed_stream.write(output)

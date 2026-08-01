"""
Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/BundleFileBlockReader.cs

Simplified relative to the C# original: rather than lazily decompressing and caching
each StorageBlock as entries are read (which needs ArrayPool rentals and PartialStream
indirection to avoid holding the whole decompressed bundle in memory at once), this
port decompresses every StorageBlock up front into one concatenated in-memory buffer,
then slices each FileStreamNode's entry out of it by offset/size. This trades memory
efficiency for much simpler, obviously-correct code -- reasonable for a research/
inspection tool, but not something you'd want for extracting multi-gigabyte bundles.

Zstd (Phase 14): a block whose declared `CompressionType` doesn't match any of the 4 named
values falls through to a Zstd signature sniff, exactly like upstream's own `default:`
branch -- Unity tags Zstd-compressed blocks with a numeric CompressionType value newer than
this (and upstream's own) enum, so both detect it by content instead of by that tag.
"""
from __future__ import annotations

from ...exceptions import DecompressionFailedException, UnsupportedBundleDecompression
from ...streams.smart import SmartStream
from ...streams.stream import MemoryStream
from .. import zstd_compression
from ..compression_type import CompressionType
from ..lzma_compression import decompress_lzma_stream
from .blocks_info import BlocksInfo
from .file_stream_node import FileStreamNode


def decompress_blocks(stream, blocks_info: BlocksInfo) -> bytes:
    output = MemoryStream()
    for block in blocks_info.storage_blocks:
        compression_type = block.compression_type
        if compression_type == CompressionType.NONE:
            payload = bytearray(block.compressed_size)
            stream.read_exactly(payload)
            output.write(payload)
        elif compression_type == CompressionType.LZMA:
            decompress_lzma_stream(stream, block.compressed_size, output, block.uncompressed_size)
        elif compression_type in (CompressionType.LZ4, CompressionType.LZ4_HC):
            import lz4.block

            compressed = bytearray(block.compressed_size)
            stream.read_exactly(compressed)
            decompressed = lz4.block.decompress(bytes(compressed), uncompressed_size=block.uncompressed_size)
            if len(decompressed) != block.uncompressed_size:
                DecompressionFailedException.throw_incorrect_number_bytes_written(
                    "", compression_type, block.uncompressed_size, len(decompressed)
                )
            output.write(decompressed)
        elif compression_type == CompressionType.LZHAM:
            UnsupportedBundleDecompression.throw_lzham("")
        elif zstd_compression.is_zstd(stream):
            zstd_compression.decompress_stream(stream, block.compressed_size, output, block.uncompressed_size)
        else:
            UnsupportedBundleDecompression.throw("", compression_type)
    return output.to_array()


def read_entry(data: bytes, entry: FileStreamNode) -> SmartStream:
    chunk = data[entry.offset : entry.offset + entry.size]
    if len(chunk) != entry.size:
        from ...exceptions import InvalidFormatException

        raise InvalidFormatException(f"Entry '{entry.path_fixed}' extends beyond the end of the decompressed data.")
    return SmartStream.create_memory(bytearray(chunk))

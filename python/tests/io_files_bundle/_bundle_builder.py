"""
Test-only helper for building synthetic UnityFS bundle byte layouts by hand, since no
real Unity-produced bundle fixtures are available in this environment. Verified against
the real FileStreamBundleFile/FileStreamBundleScheme port for round-trip correctness
across all CompressionType combinations before being used in the test suite.
"""
from __future__ import annotations

from assetripper_io_endian import EndianWriter, EndianType
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_io_files.bundle_files.bundle_version import BundleVersion
from assetripper_io_files.bundle_files.bundle_flags import BundleFlags
from assetripper_io_files.bundle_files.compression_type import CompressionType
from assetripper_io_files.bundle_files.hash128 import Hash128
from assetripper_io_files.bundle_files.file_stream.storage_block import StorageBlock
from assetripper_io_files.bundle_files.file_stream.storage_block_flags import StorageBlockFlags
from assetripper_io_files.bundle_files.file_stream.file_stream_node import FileStreamNode
from assetripper_io_files.bundle_files.file_stream.node_flags import NodeFlags


def _compress(data, compression):
    if compression == CompressionType.NONE:
        return data
    elif compression in (CompressionType.LZ4, CompressionType.LZ4_HC):
        import lz4.block
        return lz4.block.compress(data, store_size=False)
    elif compression == CompressionType.LZMA:
        import lzma
        comp = lzma.LZMACompressor(format=lzma.FORMAT_ALONE)
        alone = comp.compress(data) + comp.flush()
        return alone[:5] + alone[13:]
    raise ValueError(compression)


def build_bundle(data_compression, entries, metadata_compression=CompressionType.NONE, version=BundleVersion.BF_LARGE_FILES_SUPPORT):
    data_blob = b"".join(entries.values())
    file_nodes = []
    offset = 0
    for name, content in entries.items():
        file_nodes.append((name, offset, len(content)))
        offset += len(content)

    compressed_data = _compress(data_blob, data_compression)
    storage_block = StorageBlock(uncompressed_size=len(data_blob), compressed_size=len(compressed_data), flags=StorageBlockFlags(int(data_compression)))

    metadata_stream = MemoryStream()
    with EndianWriter(metadata_stream, EndianType.BIG_ENDIAN) as w:
        Hash128().write(w)
        w.write_int32(1)
        storage_block.write(w)
        w.write_int32(len(file_nodes))
        for name, off, size in file_nodes:
            node = FileStreamNode()
            node.offset = off
            node.size = size
            node.flags = NodeFlags.DEFAULT
            node.path = name
            node.write(w)
    metadata_uncompressed = metadata_stream.to_array()
    metadata_bytes = _compress(metadata_uncompressed, metadata_compression)

    header_stream = MemoryStream()
    flags = BundleFlags.BLOCKS_AND_DIRECTORY_INFO_COMBINED | BundleFlags(int(metadata_compression))
    with EndianWriter(header_stream, EndianType.BIG_ENDIAN) as w:
        w.write_string_zero_term("UnityFS")
        w.write_int32(int(version))
        w.write_string_zero_term("5.x.x")
        w.write_string_zero_term("5.x.x")
        w.write_int64(0)
        w.write_int32(len(metadata_bytes))
        w.write_int32(len(metadata_uncompressed))
        w.write_int32(int(flags))
    header_bytes = header_stream.to_array()
    if version >= BundleVersion.BF_LARGE_FILES_SUPPORT:
        pad = (16 - len(header_bytes) % 16) % 16
        header_bytes += bytes(pad)

    return header_bytes + metadata_bytes + compressed_data


def build_bundle_multiblock(data_compression, entries, block_sizes, version=BundleVersion.BF_LARGE_FILES_SUPPORT):
    """block_sizes: list of uncompressed byte counts per storage block, must sum to total data length."""
    data_blob = b"".join(entries.values())
    assert sum(block_sizes) == len(data_blob)

    file_nodes = []
    offset = 0
    for name, content in entries.items():
        file_nodes.append((name, offset, len(content)))
        offset += len(content)

    storage_blocks = []
    compressed_data = b""
    pos = 0
    for size in block_sizes:
        chunk = data_blob[pos : pos + size]
        pos += size
        compressed_chunk = _compress(chunk, data_compression)
        storage_blocks.append(StorageBlock(uncompressed_size=size, compressed_size=len(compressed_chunk), flags=StorageBlockFlags(int(data_compression))))
        compressed_data += compressed_chunk

    metadata_stream = MemoryStream()
    with EndianWriter(metadata_stream, EndianType.BIG_ENDIAN) as w:
        Hash128().write(w)
        w.write_int32(len(storage_blocks))
        for block in storage_blocks:
            block.write(w)
        w.write_int32(len(file_nodes))
        for name, off, size in file_nodes:
            node = FileStreamNode()
            node.offset = off
            node.size = size
            node.flags = NodeFlags.DEFAULT
            node.path = name
            node.write(w)
    metadata_bytes = metadata_stream.to_array()

    header_stream = MemoryStream()
    flags = BundleFlags.BLOCKS_AND_DIRECTORY_INFO_COMBINED
    with EndianWriter(header_stream, EndianType.BIG_ENDIAN) as w:
        w.write_string_zero_term("UnityFS")
        w.write_int32(int(version))
        w.write_string_zero_term("5.x.x")
        w.write_string_zero_term("5.x.x")
        w.write_int64(0)
        w.write_int32(len(metadata_bytes))
        w.write_int32(len(metadata_bytes))
        w.write_int32(int(flags))
    header_bytes = header_stream.to_array()
    if version >= BundleVersion.BF_LARGE_FILES_SUPPORT:
        pad = (16 - len(header_bytes) % 16) % 16
        header_bytes += bytes(pad)

    return header_bytes + metadata_bytes + compressed_data

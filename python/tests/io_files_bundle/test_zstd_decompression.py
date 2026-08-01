"""Phase 14: Zstd block decompression (`bundle_files/zstd_compression.py`), wired into
`file_stream/bundle_file_block_reader.py`'s fallback branch -- exactly like upstream's own
`default:` case in `BundleFileBlockReader.cs`, a storage block is treated as Zstd only when
its declared `CompressionType` doesn't match any of the 4 named values *and* its bytes sniff
as a Zstd frame (Unity tags Zstd blocks with a numeric value newer than this enum, so it has
no named member here -- see zstd_compression.py's module docstring).
"""
import zstandard

from assetripper_io_endian import EndianType, EndianWriter
from assetripper_io_files.bundle_files.bundle_flags import BundleFlags
from assetripper_io_files.bundle_files.bundle_version import BundleVersion
from assetripper_io_files.bundle_files.file_stream import FileStreamBundleScheme
from assetripper_io_files.bundle_files.file_stream.file_stream_node import FileStreamNode
from assetripper_io_files.bundle_files.file_stream.node_flags import NodeFlags
from assetripper_io_files.bundle_files.file_stream.storage_block import StorageBlock
from assetripper_io_files.bundle_files.file_stream.storage_block_flags import StorageBlockFlags
from assetripper_io_files.bundle_files.hash128 import Hash128
from assetripper_io_files.streams.smart import SmartStream
from assetripper_io_files.streams.stream import MemoryStream

_UNRECOGNIZED_ZSTD_COMPRESSION_TYPE = 5  # not one of CompressionType's 5 named values (0-4)


def _build_zstd_bundle(entries: dict) -> bytes:
    data_blob = b"".join(entries.values())
    file_nodes = []
    offset = 0
    for name, content in entries.items():
        file_nodes.append((name, offset, len(content)))
        offset += len(content)

    compressed_data = zstandard.ZstdCompressor().compress(data_blob)
    storage_block = StorageBlock(
        uncompressed_size=len(data_blob),
        compressed_size=len(compressed_data),
        flags=StorageBlockFlags(_UNRECOGNIZED_ZSTD_COMPRESSION_TYPE),
    )

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
    metadata_bytes = metadata_stream.to_array()

    header_stream = MemoryStream()
    flags = BundleFlags.BLOCKS_AND_DIRECTORY_INFO_COMBINED
    version = BundleVersion.BF_LARGE_FILES_SUPPORT
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
    pad = (16 - len(header_bytes) % 16) % 16
    header_bytes += bytes(pad)

    return header_bytes + metadata_bytes + compressed_data


def test_zstd_compressed_block_decompresses_via_signature_sniff():
    entries = {"CAB-abc": b"hello world" * 20, "CAB-abc.resS": bytes(range(256))}
    data = _build_zstd_bundle(entries)
    stream = SmartStream.create_memory(bytearray(data))

    bundle_file = FileStreamBundleScheme().read(stream, "/game/level0", "level0")

    assert not bundle_file.failed_files
    results = {resource.name: resource.to_byte_array() for resource in bundle_file.resource_files}
    assert results == entries

"""
No C# test project exercises FileStreamBundleFile's actual data-decompression path
against real compressed content (FileStreamTests.cs only covers an empty/uncompressed
bundle -- see test_file_stream.py). These are original tests (not a port) that build
synthetic UnityFS bundle byte layouts by hand (via _bundle_builder) and verify entries
decompress correctly across every supported CompressionType combination.
"""
import pytest
from assetripper_io_files.bundle_files.compression_type import CompressionType
from assetripper_io_files.bundle_files.file_stream import FileStreamBundleScheme
from assetripper_io_files.streams.smart import SmartStream

from ._bundle_builder import build_bundle, build_bundle_multiblock

_ENTRIES = {"CAB-abc": b"hello world" * 10, "CAB-abc.resS": bytes(range(256))}


@pytest.mark.parametrize("data_compression", [CompressionType.NONE, CompressionType.LZ4, CompressionType.LZ4_HC, CompressionType.LZMA])
@pytest.mark.parametrize("metadata_compression", [CompressionType.NONE, CompressionType.LZ4])
def test_bundle_entries_round_trip(data_compression, metadata_compression):
    data = build_bundle(data_compression, _ENTRIES, metadata_compression=metadata_compression)
    stream = SmartStream.create_memory(bytearray(data))

    scheme = FileStreamBundleScheme()
    assert scheme.can_read(stream)
    stream.position = 0

    bundle_file = scheme.read(stream, "/game/level0", "level0")

    assert not bundle_file.failed_files
    results = {resource.name: resource.to_byte_array() for resource in bundle_file.resource_files}
    assert results == _ENTRIES


def test_bundle_entries_spanning_multiple_storage_blocks_round_trip():
    entries = {"a.txt": b"alpha" * 30, "b.bin": bytes(range(256)), "c.dat": b"gamma" * 40}
    data = build_bundle_multiblock(CompressionType.LZ4, entries, block_sizes=[150, 256, 200])
    stream = SmartStream.create_memory(bytearray(data))

    bundle_file = FileStreamBundleScheme().read(stream, "/game/level0", "level0")

    assert not bundle_file.failed_files
    results = {resource.name: resource.to_byte_array() for resource in bundle_file.resource_files}
    assert results == entries


def test_non_bundle_data_is_not_recognized():
    garbage = SmartStream.create_memory(bytearray(b"just some plain text, not a bundle file at all here"))
    assert not FileStreamBundleScheme().can_read(garbage)


def test_read_contents_recursively_detects_embedded_serialized_file():
    from assetripper_io_files.build_target import BuildTarget
    from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
    from assetripper_io_files.streams.stream import MemoryStream
    from assetripper_primitives import UnityVersion

    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2021, 3, 5),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
    )
    serialized_file = builder.build()
    serialized_file.name = "CAB-abc"
    sf_stream = MemoryStream()
    serialized_file.write(sf_stream)

    data = build_bundle(CompressionType.NONE, {"CAB-abc": sf_stream.to_array()})
    stream = SmartStream.create_memory(bytearray(data))
    bundle_file = FileStreamBundleScheme().read(stream, "/game/level0", "level0")

    assert [r.name for r in bundle_file.resource_files] == ["CAB-abc"]
    assert bundle_file.serialized_files == []

    bundle_file.read_contents()

    assert bundle_file.resource_files == []
    assert [f.name for f in bundle_file.serialized_files] == ["CAB-abc"]

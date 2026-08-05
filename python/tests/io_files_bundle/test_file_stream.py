"""Port of Source/AssetRipper.IO.Files.Tests/FileStreamTests.cs"""
import pytest
from assetripper_io_files.bundle_files.bundle_flags import BundleFlags
from assetripper_io_files.bundle_files.bundle_version import BundleVersion
from assetripper_io_files.bundle_files.compression_type import CompressionType
from assetripper_io_files.bundle_files.file_stream import FileStreamBundleFile, FileStreamBundleHeader, FileStreamBundleScheme
from assetripper_io_files.streams.smart import SmartStream

_EMPTY_BUNDLE_CASES = [
    (BundleVersion.BF_260_340, "3.4.0"),
    (BundleVersion.BF_350_4X, "4.2.0"),
    (BundleVersion.BF_520A1, "5.2.0a1"),
    (BundleVersion.BF_520AUNK, "5.2.0a10"),
    (BundleVersion.BF_520_X, "5.3.0f1"),
    (BundleVersion.BF_520_X, "2018.4.40f1"),
    (BundleVersion.BF_LARGE_FILES_SUPPORT, "2022.1.0f1"),
    (BundleVersion.BF_LARGE_FILES_SUPPORT, "2022.1.10f1"),
    (BundleVersion.BF_2022_2, "2022.2.0f1"),
]


def _make_empty_bundle(bundle_version, unity_version) -> FileStreamBundleFile:
    bundle = FileStreamBundleFile()
    header = bundle.header
    header.version = bundle_version
    header.unity_web_bundle_version = "5.x.x"
    header.unity_web_minimum_revision = unity_version
    return bundle


@pytest.mark.parametrize("bundle_version,unity_version", _EMPTY_BUNDLE_CASES)
def test_read_is_symmetric_to_write_for_empty_bundle(bundle_version, unity_version):
    scheme = FileStreamBundleScheme()
    bundle = _make_empty_bundle(bundle_version, unity_version)
    stream = SmartStream.create_memory()

    bundle.write(stream)
    position_after_write = stream.position
    stream.position = 0

    assert position_after_write > 0
    assert scheme.can_read(stream)

    read_bundle = scheme.read(stream, bundle.file_path, bundle.name)
    position_after_read = stream.position

    assert read_bundle.header.version == bundle.header.version
    assert read_bundle.header.unity_web_bundle_version == bundle.header.unity_web_bundle_version
    assert read_bundle.header.unity_web_minimum_revision == bundle.header.unity_web_minimum_revision
    assert read_bundle.header.flags == bundle.header.flags
    assert position_after_read == position_after_write


def test_compress_type_works():
    header = FileStreamBundleHeader()
    header.flags = BundleFlags.BLOCK_INFO_NEED_PADDING_AT_START | BundleFlags.BLOCKS_INFO_AT_THE_END
    assert header.compression_type == CompressionType.NONE

    header.compression_type = CompressionType.LZMA
    assert header.compression_type == CompressionType.LZMA
    assert header.flags == (
        BundleFlags.BLOCK_INFO_NEED_PADDING_AT_START | BundleFlags.BLOCKS_INFO_AT_THE_END | BundleFlags.COMPRESSION_BIT_1
    )

    header.compression_type = CompressionType.LZ4
    assert header.compression_type == CompressionType.LZ4
    assert header.flags == (
        BundleFlags.BLOCK_INFO_NEED_PADDING_AT_START | BundleFlags.BLOCKS_INFO_AT_THE_END | BundleFlags.COMPRESSION_BIT_2
    )

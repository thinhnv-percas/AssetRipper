"""Phase 14: `BundleFiles/Archive/{ArchiveBundleFile,ArchiveBundleHeader,ArchiveBundleScheme}.cs`
port. Upstream itself never actually implements reading these (see archive/__init__.py's
docstring) -- so the only correct behavior to port is: recognize the "UnityArchive" magic
during scheme detection, but raise on an actual read attempt, exactly like upstream's own
`throw new NotSupportedException()`.
"""
import pytest

from assetripper_io_files.bundle_files.archive.archive_bundle_file import ArchiveBundleFile
from assetripper_io_files.bundle_files.archive.archive_bundle_scheme import ArchiveBundleScheme
from assetripper_io_files.streams.smart import SmartStream


def _minimal_archive_header() -> bytes:
    from assetripper_io_endian import EndianType, EndianWriter
    from assetripper_io_files.streams.stream import MemoryStream

    stream = MemoryStream()
    with EndianWriter(stream, EndianType.BIG_ENDIAN) as w:
        w.write_string_zero_term("UnityArchive")
        w.write_int32(1)
        w.write_string_zero_term("2.x.x")
        w.write_string_zero_term("2.x.x")
    return stream.to_array()


def test_archive_scheme_recognizes_the_signature():
    stream = SmartStream.create_memory(bytearray(_minimal_archive_header() + b"\x00" * 32))
    assert ArchiveBundleScheme().can_read(stream)
    assert stream.position == 0


def test_archive_scheme_rejects_non_archive_data():
    stream = SmartStream.create_memory(bytearray(b"just some plain text, not a bundle file at all here"))
    assert not ArchiveBundleScheme().can_read(stream)


def test_archive_bundle_file_read_is_not_implemented():
    stream = SmartStream.create_memory(bytearray(_minimal_archive_header()))
    with pytest.raises(NotImplementedError):
        ArchiveBundleFile().read(stream)

"""
Python port of Source/AssetRipper.IO.Files/BundleFiles.

The modern "UnityFS" bundle format (bundle_files.file_stream --
FileStreamBundleFile/FileStreamBundleHeader/FileStreamBundleScheme) is what every current
Unity build produces. Phase 14 added the legacy pre-Unity5 bundle variants too
(bundle_files.raw_web -- "UnityRaw"/"UnityWeb", and bundle_files.archive -- "UnityArchive",
recognized-but-unreadable at the same fidelity as upstream itself, see that module's
docstring) and Zstd block decompression (zstd_compression.py, wired into
file_stream/bundle_file_block_reader.py).
"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType

from .bundle_flags import BundleFlags
from .bundle_header import BundleHeader
from .bundle_version import BundleVersion
from .compression_type import CompressionType
from .directory_info import DirectoryInfo
from .hash128 import Hash128
from .node import Node


def is_bundle_header(path: str, file_system) -> bool:
    """Port of BundleHeader.IsBundleHeader(string, FileSystem)."""
    from ..streams.smart import SmartStream
    from .file_stream.file_stream_bundle_header import FileStreamBundleHeader
    from .raw_web.raw.raw_bundle_header import RawBundleHeader
    from .raw_web.web.web_bundle_header import WebBundleHeader

    with SmartStream.open_read(path, file_system) as stream:
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            return (
                FileStreamBundleHeader.is_bundle_header(reader)
                or RawBundleHeader.is_bundle_header(reader)
                or WebBundleHeader.is_bundle_header(reader)
            )


__all__ = [
    "BundleFlags",
    "BundleHeader",
    "BundleVersion",
    "CompressionType",
    "DirectoryInfo",
    "Hash128",
    "Node",
    "is_bundle_header",
]

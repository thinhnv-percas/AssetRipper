"""
Python port of Source/AssetRipper.IO.Files/BundleFiles.

Only the modern "UnityFS" bundle format is ported (bundle_files.file_stream --
FileStreamBundleFile/FileStreamBundleHeader/FileStreamBundleScheme), since it's what
every current Unity build produces. The legacy pre-Unity5 bundle variants (Archive/
RawWeb/Web -- BundleFiles/Archive and BundleFiles/RawWeb in the C# source) are not
ported: they only matter for asset bundles built with Unity 3.x/4.x, which is well
outside this project's scope.

Zstd decompression (ZstdCompression.cs) is also not ported -- it's an unofficial/
experimental compression mode with no first-party Python binding used elsewhere in
this port; bundles using it raise UnsupportedBundleDecompression, same as Lzham
(unsupported in the C# original too).
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
    """Port of BundleHeader.IsBundleHeader(string, FileSystem), narrowed to only the
    ported FileStreamBundleHeader (UnityFS) check."""
    from ..streams.smart import SmartStream
    from .file_stream.file_stream_bundle_header import FileStreamBundleHeader

    with SmartStream.open_read(path, file_system) as stream:
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            return FileStreamBundleHeader.is_bundle_header(reader)


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

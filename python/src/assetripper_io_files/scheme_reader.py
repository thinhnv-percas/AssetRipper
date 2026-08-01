"""Port of Source/AssetRipper.IO.Files/SchemeReader.cs

All schemes upstream registers are now ported: SerializedFileScheme, FileStreamBundleScheme
(modern "UnityFS"), RawBundleScheme/WebBundleScheme (legacy "UnityRaw"/"UnityWeb", Phase 14),
ArchiveBundleScheme ("UnityArchive", Phase 14 -- recognized but unreadable, see
bundle_files/archive/__init__.py), WebFileScheme ("UnityWebData1.0" WebGL data archive,
Phase 14), and GZipFileScheme/BrotliFileScheme (Phase 14, for `.data.gz`/`.data.br`/
brotli-wrapped WebGL/WebPlayer delivery). An entry that doesn't match any registered scheme
falls back to a plain ResourceFile, matching the C# fallback behavior.

Order matches upstream's effective try-order exactly: upstream's own `schemes` collection is
a `Stack<IScheme>` built via a collection initializer (each entry literally `Push`ed in
listed order), and `foreach` over a `Stack<T>` enumerates LIFO -- so the *last*-listed entry
(`FileStreamBundleScheme`) is actually tried *first*, and the *first*-listed entry
(`SerializedFileScheme.Default`) is tried *last*, right before the ResourceFile fallback.
This module's tuple is written in that same effective (LIFO-resolved) order directly, since
Python has no equivalent implicit stack-initializer gotcha to reproduce.
"""
from __future__ import annotations

from .resource_files.resource_file import ResourceFile
from .streams.multi_file_stream import MultiFileStream
from .streams.smart import SmartStream


def _schemes():
    from .bundle_files.archive.archive_bundle_scheme import ArchiveBundleScheme
    from .bundle_files.file_stream.file_stream_bundle_scheme import FileStreamBundleScheme
    from .bundle_files.raw_web.raw.raw_bundle_scheme import RawBundleScheme
    from .bundle_files.raw_web.web.web_bundle_scheme import WebBundleScheme
    from .compressed_files.brotli.brotli_file_scheme import BrotliFileScheme
    from .compressed_files.gzip.gzip_file_scheme import GZipFileScheme
    from .serialized_files.serialized_file_scheme import SerializedFileScheme
    from .web_files.web_file_scheme import WebFileScheme

    return (
        FileStreamBundleScheme(),
        RawBundleScheme(),
        WebBundleScheme(),
        ArchiveBundleScheme(),
        WebFileScheme(),
        BrotliFileScheme(),
        GZipFileScheme(),
        SerializedFileScheme.default(),
    )


def load_file(file_path: str, file_system):
    stream = SmartStream.open_read_multi(file_path, file_system)
    return read_file(stream, MultiFileStream.get_file_path(file_path), MultiFileStream.get_file_name(file_path))


def read_file(stream: SmartStream, file_path: str, file_name: str):
    for scheme in _schemes():
        if scheme.can_read(stream):
            return scheme.read(stream, file_path, file_name)
    return ResourceFile(stream, file_path, file_name)


def read_resource_file(file: ResourceFile):
    return read_file(file.stream.create_reference(), file.file_path, file.name)

"""Port of Source/AssetRipper.IO.Files/SchemeReader.cs

Only the schemes ported so far are registered: SerializedFileScheme and
FileStreamBundleScheme. GZip/Brotli/WebFile schemes and the legacy Archive/RawWeb
bundle schemes are not ported. An entry that doesn't match any registered scheme
falls back to a plain ResourceFile, matching the C# fallback behavior.
"""
from __future__ import annotations

from .resource_files.resource_file import ResourceFile
from .streams.multi_file_stream import MultiFileStream
from .streams.smart import SmartStream


def _schemes():
    from .bundle_files.file_stream.file_stream_bundle_scheme import FileStreamBundleScheme
    from .serialized_files.serialized_file_scheme import SerializedFileScheme

    return (SerializedFileScheme.default(), FileStreamBundleScheme())


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

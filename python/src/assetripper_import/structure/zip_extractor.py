"""Port of Source/AssetRipper.Import/Structure/ZipExtractor.cs

Upstream uses SharpCompress; this uses the stdlib `zipfile` module instead. Archive bytes
are read fully into memory via the `FileSystem` stream API (rather than assuming a real OS
path exists) and handed to `zipfile.ZipFile` through a `BytesIO` wrapper.

`process`'s optional `created_directories` (2026-08-03 fix): every `create_temporary()` call
here was previously untracked and never cleaned up anywhere -- `GameStructure`/`ExportHandler`/
`game_file_loader.py` now pass a list through so they can delete these directories once the
extracted files are no longer needed (see `cleanup()` below, and each caller's own docstring
for exactly when it's safe to call it -- streamed resources, e.g. `.resS`, are read lazily
from these files throughout export, so cleanup can't happen until export actually finishes).
Optional and additive: omitting it keeps `process`'s existing return shape and behavior
exactly as before, for the tests that already call it directly.
"""
from __future__ import annotations

import io
import struct
import zipfile
from collections.abc import Iterable

from assetripper_io_files.filesystem import fix_invalid_file_name_characters

_ZIP_EXTENSION = ".zip"
_APK_EXTENSION = ".apk"
_APKS_EXTENSION = ".apks"
_APK_PLUS_EXTENSION = ".apk+"
_OBB_EXTENSION = ".obb"
_XAPK_EXTENSION = ".xapk"
_VPK_EXTENSION = ".vpk"  # PS Vita
_IPA_EXTENSION = ".ipa"  # iOS App Store Package
_XAP_EXTENSION = ".xap"  # Windows Phone App Package
_APPX_EXTENSION = ".appx"  # Windows 8/10 App Package

_ZIP_NORMAL_MAGIC = 0x04034B50
_ZIP_EMPTY_MAGIC = 0x06054B50
_ZIP_SPANNED_MAGIC = 0x08074B50

_DIRECT_EXTRACT_EXTENSIONS = frozenset(
    {_ZIP_EXTENSION, _APK_EXTENSION, _OBB_EXTENSION, _VPK_EXTENSION, _IPA_EXTENSION, _XAP_EXTENSION, _APPX_EXTENSION}
)
_NESTED_EXTRACT_EXTENSIONS = frozenset({_APKS_EXTENSION, _APK_PLUS_EXTENSION, _XAPK_EXTENSION})


class ExtractionError(Exception):
    pass


def process(paths: Iterable[str], file_system, created_directories: "list[str] | None" = None) -> list[str]:
    result: list[str] = []
    for path in paths:
        extension = _get_file_extension(path, file_system)
        if extension in _DIRECT_EXTRACT_EXTENSIONS:
            result.append(_extract_zip(path, file_system, created_directories))
        elif extension in _NESTED_EXTRACT_EXTENSIONS:
            result.append(_extract_xapk(path, file_system, created_directories))
        else:
            result.append(path)
    return result


def cleanup(directories: "Iterable[str]", file_system) -> None:
    """Deletes every directory `process` created via `created_directories`. Safe to call with
    directories that no longer exist (already cleaned up, or never created) -- silently
    skipped rather than raising, since cleanup failing shouldn't fail whatever operation
    triggered it (export, or loading the next game in the GUI)."""
    for directory in directories:
        try:
            if file_system.directory.exists(directory):
                file_system.directory.delete(directory)
        except OSError:
            pass


def _extract_zip(zip_file_path: str, file_system, created_directories: "list[str] | None" = None) -> str:
    if not _has_compatible_magic(zip_file_path, file_system):
        return zip_file_path

    output_directory = file_system.directory.create_temporary()
    if created_directories is not None:
        created_directories.append(output_directory)
    _decompress_zip_archive(zip_file_path, output_directory, file_system)
    return output_directory


def _extract_xapk(xapk_file_path: str, file_system, created_directories: "list[str] | None" = None) -> str:
    if not _has_compatible_magic(xapk_file_path, file_system):
        return xapk_file_path

    intermediate_directory = file_system.directory.create_temporary()
    output_directory = file_system.directory.create_temporary()
    if created_directories is not None:
        created_directories.append(intermediate_directory)
        created_directories.append(output_directory)
    _decompress_zip_archive(xapk_file_path, intermediate_directory, file_system)
    for file_path in file_system.directory.get_files(intermediate_directory):
        if _get_file_extension(file_path, file_system) == _APK_EXTENSION:
            _decompress_zip_archive(file_path, output_directory, file_system)
    return output_directory


def _decompress_zip_archive(zip_file_path: str, output_directory: str, file_system) -> None:
    data = _read_all_bytes(zip_file_path, file_system)
    with zipfile.ZipFile(io.BytesIO(data)) as archive:
        for entry in archive.infolist():
            _write_entry_to_directory(archive, entry, output_directory, file_system)


def _write_entry_to_directory(archive: zipfile.ZipFile, entry: zipfile.ZipInfo, output_directory: str, file_system) -> None:
    full_output_directory = file_system.path.get_full_path(output_directory)

    if not file_system.directory.exists(full_output_directory):
        raise ExtractionError(f"Directory does not exist to extract to: {full_output_directory}")

    entry_key = entry.filename
    file_name = file_system.path.get_file_name(entry_key)
    file_name = fix_invalid_file_name_characters(file_name)

    directory = file_system.path.get_directory_name(entry_key)
    full_directory = file_system.path.get_full_path(file_system.path.join(full_output_directory, directory or ""))

    if not file_system.directory.exists(full_directory):
        if not full_directory.startswith(full_output_directory):
            raise ExtractionError("Entry is trying to create a directory outside of the destination directory.")
        file_system.directory.create(full_directory)

    file_path = file_system.path.join(full_directory, file_name)

    if not entry.is_dir():
        file_path = file_system.path.get_full_path(file_path)
        if not file_path.startswith(full_output_directory):
            raise ExtractionError("Entry is trying to write a file outside of the destination directory.")

        with archive.open(entry) as source, file_system.file.create(file_path) as stream:
            stream.write(source.read())
    elif not file_system.directory.exists(file_path):
        file_system.directory.create(file_path)


def _get_file_extension(path: str, file_system) -> str | None:
    if file_system.file.exists(path):
        return file_system.path.get_extension(path)
    return None


def _has_compatible_magic(path: str, file_system) -> bool:
    magic = _get_magic_number(path, file_system)
    return magic in (_ZIP_NORMAL_MAGIC, _ZIP_EMPTY_MAGIC, _ZIP_SPANNED_MAGIC)


def _get_magic_number(path: str, file_system) -> int:
    with file_system.file.open_read(path) as stream:
        buffer = bytearray(4)
        stream.read_exactly(buffer)
        return struct.unpack("<I", buffer)[0]


def _read_all_bytes(path: str, file_system) -> bytes:
    with file_system.file.open_read(path) as stream:
        buffer = bytearray(stream.length)
        stream.read_exactly(buffer)
        return bytes(buffer)

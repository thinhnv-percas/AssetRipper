"""CLI implementation for the `assetripper-inspect` command."""
from __future__ import annotations

import sys

from assetripper_io_files.bundle_files.file_stream import FileStreamBundleScheme
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import SerializedFile, SerializedFileScheme
from assetripper_io_files.streams.smart import SmartStream

_VERSION = "0.1.0"


def main(argv: list[str] | None = None) -> int:
    argv = sys.argv[1:] if argv is None else argv

    if argv and argv[0] in ("-v", "--version"):
        print(f"assetripper-inspect {_VERSION} (Python port of AssetRipper, partial)")
        return 0

    if not argv or argv[0] in ("-h", "--help"):
        print("Usage: assetripper-inspect <file> [<file> ...]")
        print()
        print("Reads each file and, if it's a recognized Unity SerializedFile or")
        print("UnityFS bundle (.assets/.sharedAssets/level*/*.bundle/etc.), prints")
        print("its header and metadata. Legacy pre-Unity5 bundles and Compressed/Web")
        print("files are not yet supported by this build.")
        return 0 if argv else 1

    file_system = LocalFileSystem.instance()
    exit_code = 0
    for path in argv:
        if not _inspect_one(path, file_system):
            exit_code = 1
    return exit_code


def _inspect_one(path: str, file_system: LocalFileSystem) -> bool:
    print(path)
    stream = None
    try:
        stream = SmartStream.open_read(path, file_system)
        file_name = file_system.path.get_file_name(path)
        bundle_scheme = FileStreamBundleScheme()

        if bundle_scheme.can_read(stream):
            stream.position = 0
            bundle_file = bundle_scheme.read(stream, path, file_name)
            _print_bundle(bundle_file)
            return True

        stream.position = 0
        if not SerializedFile.is_serialized_file(stream):
            print("  Not a recognized SerializedFile or UnityFS bundle.")
            print("  (legacy bundles/compressed/web files aren't supported by this build yet)")
            return True

        stream.position = 0
        serialized_file = SerializedFileScheme.default().read(stream, path, file_name)
        _print_serialized_file(serialized_file)
        return True
    except Exception as ex:  # noqa: BLE001 -- top-level CLI error boundary, reported per-file
        print(f"  Error: {ex!r}")
        return False
    finally:
        if stream is not None:
            stream.dispose()


def _print_serialized_file(serialized_file, indent: str = "  ") -> None:
    print(f"{indent}Generation:   {serialized_file.generation.name} ({int(serialized_file.generation)})")
    print(f"{indent}Unity version: {serialized_file.version}")
    print(f"{indent}Platform:     {serialized_file.platform.name}")
    print(f"{indent}Endian:       {serialized_file.endian_type.name}")
    print(f"{indent}Has type tree: {serialized_file.has_type_tree}")
    print(f"{indent}Types:        {len(list(serialized_file.types))}")
    print(f"{indent}Objects:      {len(list(serialized_file.objects))}")
    print(f"{indent}Dependencies: {len(list(serialized_file.dependencies))}")


def _print_bundle(bundle_file) -> None:
    print(f"  UnityFS bundle, format version {int(bundle_file.header.version)}")
    print(f"  Compression:  {bundle_file.header.compression_type.name}")

    bundle_file.read_contents_recursively()
    for serialized_file in bundle_file.fetch_serialized_files():
        print(f"  - SerializedFile '{serialized_file.name}':")
        _print_serialized_file(serialized_file, indent="      ")
    for resource_file in bundle_file.resource_files:
        print(f"  - ResourceFile '{resource_file.name}' ({len(resource_file.to_byte_array())} bytes)")
    for failed_file in bundle_file.failed_files:
        print(f"  - FailedFile '{failed_file.name}'")


if __name__ == "__main__":
    sys.exit(main())

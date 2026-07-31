"""CLI implementation for the `assetripper-inspect` command."""
from __future__ import annotations

import sys

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
        print("Reads each file and, if it's a recognized Unity SerializedFile")
        print("(.asset/.assets/.sharedAssets/etc.), prints its header and metadata.")
        print("Other AssetRipper formats (bundles, compressed files) are not yet")
        print("supported by this build.")
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
        if not SerializedFile.is_serialized_file(stream):
            print("  Not a recognized SerializedFile.")
            print("  (bundles/compressed/resource files aren't supported by this build yet)")
            return True

        stream.position = 0
        file_name = file_system.path.get_file_name(path)
        serialized_file = SerializedFileScheme.default().read(stream, path, file_name)

        print(f"  Generation:   {serialized_file.generation.name} ({int(serialized_file.generation)})")
        print(f"  Unity version: {serialized_file.version}")
        print(f"  Platform:     {serialized_file.platform.name}")
        print(f"  Endian:       {serialized_file.endian_type.name}")
        print(f"  Has type tree: {serialized_file.has_type_tree}")
        print(f"  Types:        {len(list(serialized_file.types))}")
        print(f"  Objects:      {len(list(serialized_file.objects))}")
        print(f"  Dependencies: {len(list(serialized_file.dependencies))}")
        return True
    except Exception as ex:  # noqa: BLE001 -- top-level CLI error boundary, reported per-file
        print(f"  Error: {ex!r}")
        return False
    finally:
        if stream is not None:
            stream.dispose()


if __name__ == "__main__":
    sys.exit(main())

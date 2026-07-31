"""CLI implementation for the `assetripper-inspect` command.

Two subcommands:
- `inspect` (also the default when no subcommand is given, for back-compat with the
  original single-purpose CLI): prints a SerializedFile/UnityFS bundle's header and
  metadata without running the full Import/Processing/Export pipeline.
- `export`: the pipeline itself, via `ExportHandler` (see
  assetripper_export_unity_projects/export_handler.py) -- full platform/game-structure
  discovery, all four default processors, then a real Unity project export.
"""
from __future__ import annotations

import sys

from assetripper_io_files.bundle_files.file_stream import FileStreamBundleScheme
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import SerializedFile, SerializedFileScheme
from assetripper_io_files.streams.smart import SmartStream

_VERSION = "0.1.0"

_TOP_LEVEL_USAGE = """\
Usage: assetripper-inspect <file> [<file> ...]
       assetripper-inspect inspect <file> [<file> ...]
       assetripper-inspect export <path> [<path> ...] -o <output_dir>

inspect (default if no subcommand is given): reads each file and, if it's a
recognized Unity SerializedFile or UnityFS bundle (.assets/.sharedAssets/
level*/*.bundle/etc.), prints its header and metadata. Legacy pre-Unity5
bundles and Compressed/Web files are not yet supported by this build.

export: loads the given file(s)/folder(s) as a full Unity game (platform
discovery + every SerializedFile/bundle found), runs the standard asset
processors, and exports a Unity project to -o/--output."""

_EXPORT_USAGE = (
    "Usage: assetripper-inspect export <path> [<path> ...] -o <output_dir> [--config <settings.json>]"
)


def main(argv: list[str] | None = None) -> int:
    argv = sys.argv[1:] if argv is None else argv

    if argv and argv[0] in ("-v", "--version"):
        print(f"assetripper-inspect {_VERSION} (Python port of AssetRipper, partial)")
        return 0

    if not argv or argv[0] in ("-h", "--help"):
        print(_TOP_LEVEL_USAGE)
        return 0 if argv else 1

    if argv[0] == "inspect":
        return _run_inspect(argv[1:])
    if argv[0] == "export":
        return _run_export(argv[1:])

    # Back-compat: no recognized subcommand, so treat every argument as a file to inspect
    # (the CLI's original, single-purpose behavior before the `export` subcommand existed).
    return _run_inspect(argv)


def _run_inspect(argv: list[str]) -> int:
    if not argv or argv[0] in ("-h", "--help"):
        print("Usage: assetripper-inspect inspect <file> [<file> ...]")
        return 0 if argv else 1

    file_system = LocalFileSystem.instance()
    exit_code = 0
    for path in argv:
        if not _inspect_one(path, file_system):
            exit_code = 1
    return exit_code


def _run_export(argv: list[str]) -> int:
    if not argv or argv[0] in ("-h", "--help"):
        print(_EXPORT_USAGE)
        return 0 if argv else 1

    input_paths: list[str] = []
    output_directory: str | None = None
    config_path: str | None = None
    i = 0
    while i < len(argv):
        arg = argv[i]
        if arg in ("-o", "--output"):
            i += 1
            if i >= len(argv):
                print("Error: -o/--output requires a value")
                return 1
            output_directory = argv[i]
        elif arg == "--config":
            i += 1
            if i >= len(argv):
                print("Error: --config requires a value")
                return 1
            config_path = argv[i]
        else:
            input_paths.append(arg)
        i += 1

    if not input_paths:
        print("Error: no input paths given")
        print(_EXPORT_USAGE)
        return 1
    if not output_directory:
        print("Error: -o/--output is required")
        print(_EXPORT_USAGE)
        return 1

    from assetripper_export_configuration.full_configuration import FullConfiguration
    from assetripper_export_unity_projects.export_handler import ExportHandler

    settings = FullConfiguration.load(config_path) if config_path else None

    file_system = LocalFileSystem.instance()
    handler = ExportHandler()
    try:
        print(f"Loading {len(input_paths)} path(s)...")
        game_data = handler.load_and_process(input_paths, file_system, settings=settings)
        if not game_data.game_bundle.has_any_asset_collections():
            print("Error: no valid Unity assets found in the given path(s)")
            return 1
        print(f"Exporting to {output_directory} (Unity {game_data.project_version})...")
        handler.export(game_data, output_directory, file_system, settings=settings)
        print("Done.")
        return 0
    except Exception as ex:  # noqa: BLE001 -- top-level CLI error boundary
        print(f"Error: {ex!r}")
        return 1


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
    _print_decoded_assets(serialized_file, indent)


def _print_decoded_assets(serialized_file, indent: str) -> None:
    """Decodes each object against the file's embedded type tree and prints its fields.

    Objects in files with no type tree can't be decoded, and are reported as such rather
    than dumped as bytes here (use the GUI's hex view for those).
    """
    from assetripper_assets.bundles.game_bundle import GameBundle
    from assetripper_import.asset_creation import GameAssetFactory, TypeTreeObject

    try:
        bundle = GameBundle()
        collection = bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    except Exception as ex:  # noqa: BLE001 -- inspection should never be fatal
        print(f"{indent}Assets:       <could not decode: {ex!r}>")
        return

    if not collection.assets:
        return

    print(f"{indent}Assets:")
    for path_id, asset in collection.assets.items():
        if isinstance(asset, TypeTreeObject):
            print(f"{indent}  [{path_id}] {asset.class_name}")
            for name, value in asset.items():
                print(f"{indent}      {name} = {_summarize(value)}")
        else:
            print(f"{indent}  [{path_id}] {asset.class_name} <no type tree; {len(getattr(asset, 'raw_data', b''))} raw bytes>")


def _summarize(value, limit: int = 100) -> str:
    """Renders a field value compactly -- long lists and strings would otherwise flood the
    terminal for things like mesh vertex buffers."""
    if isinstance(value, list):
        if len(value) > 8:
            return f"[{', '.join(_summarize(v, 20) for v in value[:8])}, ... {len(value) - 8} more]"
        return f"[{', '.join(_summarize(v, 20) for v in value)}]"
    if hasattr(value, "items") and hasattr(value, "keys"):
        return "{" + ", ".join(f"{n}: {_summarize(v, 20)}" for n, v in value.items()) + "}"
    text = repr(value)
    return text if len(text) <= limit else text[: limit - 3] + "..."


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

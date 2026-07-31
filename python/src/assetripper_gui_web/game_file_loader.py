"""
Stand-in for Source/AssetRipper.GUI.Web/GameFileLoader.cs.

Two loading paths, kept side by side because they serve different pages:

- `load_file(path)`: one raw file (SerializedFile or UnityFS bundle) straight into a bare
  GameBundle, for quick browsing of a single .assets/.bundle file's raw metadata (the
  Bundles/Collections/Assets pages). No platform discovery, no processors -- this is what
  the GUI used exclusively before Phase 8.
- `load_paths(paths)`: the real thing, via `ExportHandler.load_and_process` (see
  assetripper_export_unity_projects/export_handler.py) -- full platform/game-structure
  discovery across every file under the given path(s), dependency resolution, and the
  standard asset processors. This is what `/LoadFolder` and `/Export/UnityProject` need;
  `load_file`'s bare GameBundle has no platform_structure and never ran a processor, so it
  can't be exported into a real Unity project.

BundleFiles.Archive/RawWeb (legacy pre-Unity5 bundles) and CompressedFiles/WebFiles aren't
ported, so those formats still fall through to a load error either way.
"""
from __future__ import annotations

import os

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_io_files.bundle_files.file_stream import FileStreamBundleScheme
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import SerializedFile, SerializedFileScheme
from assetripper_io_files.streams.smart import SmartStream

from assetripper_import.asset_creation import GameAssetFactory

_factory = GameAssetFactory()


class _State:
    def __init__(self):
        self.game_bundle: GameBundle | None = None
        self.game_data = None
        """Only set by `load_paths` -- the GameData a real Export needs (platform_structure,
        processed assets). `None` when the currently loaded bundle came from `load_file`."""
        self.load_errors: list[str] = []


_state = _State()


def is_loaded() -> bool:
    return _state.game_bundle is not None


def game_bundle() -> GameBundle:
    if _state.game_bundle is None:
        raise RuntimeError("No files loaded.")
    return _state.game_bundle


def has_game_data() -> bool:
    return _state.game_data is not None


def game_data():
    if _state.game_data is None:
        raise RuntimeError("No game structure loaded (use Load Folder, not Load File, before exporting).")
    return _state.game_data


def load_errors() -> list[str]:
    return _state.load_errors


def reset() -> None:
    _state.game_bundle = None
    _state.game_data = None
    _state.load_errors = []


def load_paths(paths: list[str]) -> None:
    """Loads one or more files/folders as a full Unity game: platform discovery, every
    SerializedFile/bundle found, dependency resolution, and the standard processors --
    everything `ExportHandler.load_and_process` does. Populates `game_data()`, which
    `/Export/UnityProject` needs; `load_file` never does."""
    reset()

    from assetripper_export_unity_projects.export_handler import ExportHandler

    file_system = LocalFileSystem.instance()
    handler = ExportHandler()
    try:
        data = handler.load_and_process(list(paths), file_system)
    except Exception as ex:  # noqa: BLE001 -- GUI error boundary, reported to the user via flash
        _state.load_errors.append(f"Failed to load: {ex!r}")
        return

    if not data.game_bundle.has_any_asset_collections():
        _state.load_errors.append("No valid Unity assets found in the given path(s).")
        return

    _state.game_data = data
    _state.game_bundle = data.game_bundle


def load_file(path: str) -> None:
    """Loads a single file at `path` into a fresh GameBundle -- either a raw
    SerializedFile or a UnityFS bundle (see module docstring). Anything else is
    recorded as a load error rather than added as a FailedFile."""
    reset()
    bundle = GameBundle()
    _state.game_bundle = bundle

    if not os.path.isfile(path):
        _state.load_errors.append(f"File not found: {path}")
        return

    file_system = LocalFileSystem.instance()
    file_name = os.path.basename(path)
    bundle_scheme = FileStreamBundleScheme()
    stream = SmartStream.open_read(path, file_system)
    try:
        if bundle_scheme.can_read(stream):
            stream.position = 0
            bundle_file = bundle_scheme.read(stream, path, file_name)
            bundle_file.read_contents_recursively()
            for serialized_file in bundle_file.fetch_serialized_files():
                bundle.add_collection_from_serialized_file(serialized_file, _factory)
            _add_remaining_files(bundle, bundle_file)
            return

        stream.position = 0
        if not SerializedFile.is_serialized_file(stream):
            _state.load_errors.append(
                f"'{file_name}' is not a recognized SerializedFile or UnityFS bundle "
                "(legacy pre-Unity5 bundles and CompressedFiles/WebFiles are not "
                "supported by this Python port yet)."
            )
            return

        stream.position = 0
        serialized_file = SerializedFileScheme.default().read(stream, path, file_name)
        bundle.add_collection_from_serialized_file(serialized_file, _factory)
    finally:
        stream.dispose()


def _add_remaining_files(bundle: GameBundle, container) -> None:
    """Recursively copies whatever a FileContainer couldn't classify as a
    SerializedFile (plain ResourceFiles, FailedFiles) onto the GameBundle so they're
    still browsable."""
    for resource_file in container.resource_files:
        bundle.add_resource(resource_file)
    for failed_file in container.failed_files:
        bundle.add_failed(failed_file)
    for child_container in container.file_lists:
        _add_remaining_files(bundle, child_container)

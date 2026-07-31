"""
A greatly simplified stand-in for Source/AssetRipper.GUI.Web/GameFileLoader.cs.

The real GameFileLoader.LoadAndProcess() runs the full Import -> Processing pipeline
(assembly loading, asset factories per Unity version, dependency resolution, scene
building, etc.), none of which is ported to Python yet. This module can load:

- A raw SerializedFile (.assets/.sharedAssets/level* files), directly into a GameBundle
  as one collection. Objects are decoded field-by-field against the file's embedded
  type tree via GameAssetFactory; objects in files with no type tree become UnknownObject.
- A UnityFS bundle file (the modern AssetBundle container -- see
  assetripper_io_files.bundle_files.file_stream), whose entries are recursively
  classified via FileContainer.read_contents_recursively() and mapped onto the
  GameBundle: embedded SerializedFiles become collections (again via GameAssetFactory),
  plain ResourceFiles and FailedFiles are added directly.

BundleFiles.Archive/RawWeb (legacy pre-Unity5 bundles) and CompressedFiles/WebFiles
aren't ported, so those formats still fall through to a load error.
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
        self.load_errors: list[str] = []


_state = _State()


def is_loaded() -> bool:
    return _state.game_bundle is not None


def game_bundle() -> GameBundle:
    if _state.game_bundle is None:
        raise RuntimeError("No files loaded.")
    return _state.game_bundle


def load_errors() -> list[str]:
    return _state.load_errors


def reset() -> None:
    _state.game_bundle = None
    _state.load_errors = []


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

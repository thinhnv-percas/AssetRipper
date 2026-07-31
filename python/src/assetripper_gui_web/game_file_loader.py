"""
A greatly simplified stand-in for Source/AssetRipper.GUI.Web/GameFileLoader.cs.

The real GameFileLoader.LoadAndProcess() runs the full Import -> Processing pipeline
(assembly loading, asset factories per Unity version, dependency resolution, scene
building, etc.), none of which is ported to Python yet. This module can only load raw
SerializedFiles (.assets/.sharedAssets/level* files, recognized by
SerializedFile.is_serialized_file) directly into a GameBundle, one collection per file,
using RawAssetFactory so objects are browsable but not decoded into typed classes.
"""
from __future__ import annotations

import os

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import SerializedFile, SerializedFileScheme
from assetripper_io_files.streams.smart import SmartStream

from .raw_asset import RawAssetFactory

_factory = RawAssetFactory()


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
    """Loads a single serialized file at `path` into a fresh GameBundle. Non-serialized
    files (bundle files, compressed archives, etc.) are recorded as load errors rather
    than added as FailedFiles, since BundleFiles/CompressedFiles are not ported yet."""
    reset()
    bundle = GameBundle()
    _state.game_bundle = bundle

    if not os.path.isfile(path):
        _state.load_errors.append(f"File not found: {path}")
        return

    file_system = LocalFileSystem.instance()
    stream = SmartStream.open_read(path, file_system)
    try:
        if not SerializedFile.is_serialized_file(stream):
            _state.load_errors.append(
                f"'{os.path.basename(path)}' is not a recognized SerializedFile "
                "(BundleFiles/CompressedFiles/WebFiles are not supported by this Python port yet)."
            )
            return

        stream.position = 0
        file_name = os.path.basename(path)
        serialized_file = SerializedFileScheme.default().read(stream, path, file_name)
        bundle.add_collection_from_serialized_file(serialized_file, _factory)
    finally:
        stream.dispose()

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

**Phase 17 (`exported_project_dir`):** this is a *new* feature, not upstream port -- upstream's
GUI exports to disk and stops; the user opens the result with their OS file explorer. This adds
"browse the just-exported (or a previously exported) project's tree right in the GUI" (see
routes/projects.py). Scoped to the simpler "17a-lite" option from python/ROADMAP.md Phase 17: no
`VirtualFileSystem` -- when the GUI's OutputPath is left blank, `start_export` exports into a
real `tempfile.mkdtemp` directory instead of an in-memory tree, and `/Project` just walks that
directory with `os.walk` like any other folder on disk. Simpler, and the same code path also
serves loading a project someone exported to disk in an earlier run (`load_exported_project`).
"""
from __future__ import annotations

import atexit
import os
import shutil
import tempfile
import threading

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_io_files.bundle_files.file_stream import FileStreamBundleScheme
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import SerializedFile, SerializedFileScheme
from assetripper_io_files.streams.smart import SmartStream

from assetripper_export_configuration.full_configuration import FullConfiguration
from assetripper_import.asset_creation import GameAssetFactory

_factory = GameAssetFactory()


class _State:
    def __init__(self):
        self.game_bundle: GameBundle | None = None
        self.game_data = None
        """Only set by `load_paths` -- the GameData a real Export needs (platform_structure,
        processed assets). `None` when the currently loaded bundle came from `load_file`."""
        self.load_errors: list[str] = []
        self.settings = FullConfiguration()
        """Session-only (Phase 10): kept in this module's state for the lifetime of the GUI
        process, not persisted to disk. `/Settings/Edit` reads/writes it directly; `load_paths`
        and `/Export/UnityProject` both use it. Use `FullConfiguration.save`/`.load` (see
        assetripper_export_configuration/full_configuration.py) if a caller wants persistence."""
        self.export_progress: dict = {"running": False, "current": 0, "total": 0, "current_name": "", "error": None}
        """(Phase 11) Updated by `start_export`'s background thread via
        `ProjectExporter.export`'s `progress_callback`; `/Export/Progress` polls this so the
        GUI can show a live progress bar instead of blocking the whole request on a large
        export."""
        self.exported_project_dir: str | None = None
        """(Phase 17) Root directory of a completed export that can be browsed via `/Project` --
        either a `tempfile.mkdtemp` this module owns (see `_owned_temp_dir`) or a real directory
        the user pointed at (either as this export's OutputPath, or via `load_exported_project`
        for a project exported in an earlier run/process). `None` until an export finishes or
        `load_exported_project` succeeds."""
        self._owned_temp_dir: str | None = None
        """Set only when `exported_project_dir` is a temp dir this module created and therefore
        must clean up itself (on `reset()` or process exit) -- a user-supplied OutputPath is
        never deleted out from under them."""


_state = _State()


def _cleanup_owned_temp_dir() -> None:
    if _state._owned_temp_dir is not None:
        shutil.rmtree(_state._owned_temp_dir, ignore_errors=True)
        _state._owned_temp_dir = None


atexit.register(_cleanup_owned_temp_dir)


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


def settings() -> FullConfiguration:
    return _state.settings


def set_settings(new_settings: FullConfiguration) -> None:
    _state.settings = new_settings


def export_progress() -> dict:
    return dict(_state.export_progress)


def start_export(output_directory: "str | None") -> None:
    """Runs the real export (`ExportHandler.export`) on a background thread so the POST
    handler can return immediately and the GUI can poll `export_progress()` for a live
    progress bar (Phase 11) instead of blocking on a large export. Raises if an export from
    this process is already running -- overlapping exports would race on `export_progress`.

    `output_directory` falsy (Phase 17): exports into a fresh `tempfile.mkdtemp` this module
    owns instead, so it can be browsed afterward via `/Project` without the user having to
    pick a disk location first. Either way, a *successful* export sets `exported_project_dir()`
    once it finishes -- see `_run`."""
    if _state.export_progress["running"]:
        raise RuntimeError("An export is already running.")
    if _state.game_data is None:
        raise RuntimeError("No game structure loaded (use Load Folder, not Load File, before exporting).")

    _cleanup_owned_temp_dir()
    owned_temp_dir = None
    if not output_directory:
        owned_temp_dir = tempfile.mkdtemp(prefix="assetripper_exported_")
        output_directory = owned_temp_dir

    _state.export_progress = {"running": True, "current": 0, "total": 0, "current_name": "", "error": None}
    _state.exported_project_dir = None
    _state._owned_temp_dir = owned_temp_dir
    game_data = _state.game_data
    settings = _state.settings

    def _on_progress(current: int, total: int, name: str) -> None:
        _state.export_progress["current"] = current
        _state.export_progress["total"] = total
        _state.export_progress["current_name"] = name

    def _run() -> None:
        from assetripper_export_unity_projects.export_handler import ExportHandler
        from assetripper_io_files.local_file_system import LocalFileSystem

        try:
            ExportHandler().export(
                game_data,
                output_directory,
                LocalFileSystem.instance(),
                settings=settings,
                progress_callback=_on_progress,
            )
            _state.exported_project_dir = output_directory
        except Exception as ex:  # noqa: BLE001 -- reported via export_progress()["error"], not raised
            _state.export_progress["error"] = repr(ex)
        finally:
            _state.export_progress["running"] = False

    threading.Thread(target=_run, daemon=True).start()


def has_exported_project() -> bool:
    return _state.exported_project_dir is not None


def exported_project_dir() -> str:
    if _state.exported_project_dir is None:
        raise RuntimeError("No exported project to browse (export or load one first).")
    return _state.exported_project_dir


def load_exported_project(path: str) -> None:
    """(Phase 17d) Points `/Project` at a project directory exported in an earlier run --
    e.g. via the CLI, or a previous GUI session that used a real OutputPath -- without
    running a fresh export. Doesn't touch `game_bundle`/`game_data`; browsing an old export
    doesn't require the source game to still be loaded."""
    if not os.path.isdir(path):
        raise FileNotFoundError(f"Directory not found: {path}")
    _cleanup_owned_temp_dir()
    _state.exported_project_dir = path


def reset() -> None:
    _state.game_bundle = None
    _state.game_data = None
    _state.load_errors = []
    _state.export_progress = {"running": False, "current": 0, "total": 0, "current_name": "", "error": None}
    _cleanup_owned_temp_dir()
    _state.exported_project_dir = None


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
        data = handler.load_and_process(list(paths), file_system, settings=_state.settings)
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

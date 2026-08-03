"""
Stand-in for Source/AssetRipper.GUI.Web/GameFileLoader.cs.

Two loading functions exist, but only one is wired to the GUI's primary Load button as of
Phase 19a:

- `load_paths(paths)`: the real thing, via `ExportHandler.load_and_process` (see
  assetripper_export_unity_projects/export_handler.py) -- full platform/game-structure
  discovery across every file under the given path(s), dependency resolution, and the
  standard asset processors. Handles a single file *or* a directory identically (archive
  formats like `.apk`/`.ipa`/`.obb`/`.zip` are classified and extracted by `zip_extractor`/
  `platform_checker`, a loose `.assets`/bundle file by `MixedGameStructure` -- no
  format-detection logic needed at this layer). Both `/LoadFile` and `/LoadFolder` call this
  now (Phase 19a): the previous split, where "Load File" called `load_file` below instead,
  meant handing a `.apk`/`.ipa` to the button a user would naturally reach for always failed
  with "not a recognized SerializedFile or UnityFS bundle", even though `load_paths` has
  handled those formats correctly since Phase 3/14 -- a GUI wiring bug, not an engine gap.
- `load_file(path)`: one raw file (SerializedFile or UnityFS bundle) straight into a bare
  GameBundle -- no platform discovery, no processors, so it can't be exported or previewed.
  No longer reachable from any GUI route as of Phase 19a (kept, not deleted, since a future
  "raw single-file debug load" affordance for Phase 18's asset-layout debugging could still
  want it -- see ROADMAP Phase 19b).

BundleFiles.Archive/RawWeb (legacy pre-Unity5 bundles) and CompressedFiles/WebFiles aren't
ported, so those formats still fall through to a load error either way.

**Phase 17 (rewritten, `get_export_plan`):** a *new* feature, not upstream port -- upstream's
GUI exports to disk and stops; the user opens the result with their OS file explorer. The
correct goal (corrected after the first, wrong-goal implementation in commit `37db9bf`): preview
the files that *would* be exported -- assets and code -- right after loading, with **no** export
step required first. `get_export_plan()` builds an `ExportPlan` (Phase 17b) by running the real
`ExportHandler.export()` into an in-memory `VirtualFileSystem` (Phase 17a), cached against the
`(game_data, settings)` identity pair that produced it so repeated `/Project` browsing doesn't
re-run a full export on every request, and rebuilt automatically the moment either changes (a
new `load_paths()`, or a `/Settings/Edit` save -- both always produce a new object, so an
identity comparison is enough; no explicit invalidation call needed).

`exported_project_dir`/`load_exported_project` (secondary path, `/Project/Load`): browsing a
*real* directory already exported to disk in an earlier run/process -- still useful ("exported
yesterday, want to look again"), but no longer the primary way to reach `/Project`. Takes
priority over the `ExportPlan` preview whenever set, since loading one is an explicit,
deliberate user action; a fresh `load_paths()` (`reset()`) clears it, falling back to the
`ExportPlan` preview of the newly loaded game.
"""
from __future__ import annotations

import os
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
        """(Phase 17, `/Project/Load` only) A real directory the user explicitly pointed at via
        `load_exported_project` -- a project exported to disk in an earlier run/process. `None`
        until that succeeds; a fresh `load_paths()` clears it. Deliberately *not* set by
        `start_export` (a real disk export no longer doubles as this module's `/Project` browse
        source -- the `ExportPlan` preview already shows the same content without writing
        anything to disk, see `get_export_plan`)."""
        self._export_plan = None
        self._export_plan_key: tuple | None = None
        """`(id(game_data), id(settings))` the cached `_export_plan` was built from -- both
        `load_paths` and `/Settings/Edit` always produce a brand-new object, never mutate one
        in place, so comparing identity is enough to detect staleness without an explicit
        invalidation call from either call site."""
        self.load_progress: dict = {"running": False, "message": "", "error": None}
        """(Phase 19c) Updated by `start_load`'s background thread via `load_paths`'s
        `progress_callback`; `/Load/Progress` polls this so the GUI can show live milestones
        instead of blocking the whole request -- a real `.ipa` takes ~38s (see ROADMAP Phase
        19), which used to hang the browser with no feedback at all. Deliberately **not**
        cleared by `reset()`: `load_paths` calls `reset()` as its own first step, and `reset()`
        running mid-load (from inside the very background thread `start_load` spawned) must
        not stomp the `running: True` flag that same call is currently reporting under."""


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


def settings() -> FullConfiguration:
    return _state.settings


def set_settings(new_settings: FullConfiguration) -> None:
    _state.settings = new_settings


def export_progress() -> dict:
    return dict(_state.export_progress)


def start_export(output_directory: str) -> None:
    """Runs the real export (`ExportHandler.export`) on a background thread so the POST
    handler can return immediately and the GUI can poll `export_progress()` for a live
    progress bar (Phase 11) instead of blocking on a large export. Raises if an export from
    this process is already running -- overlapping exports would race on `export_progress`.

    `output_directory` is required (Phase 17 rewrite): the old "blank = export into an owned
    temp dir, then browse it" behavior is gone -- `get_export_plan()`'s in-memory preview covers
    that need without writing anything to disk, so a real disk export now always needs a real
    path, exactly like before Phase 17 existed."""
    if not output_directory:
        raise RuntimeError("An output directory is required.")
    if _state.export_progress["running"]:
        raise RuntimeError("An export is already running.")
    if _state.game_data is None:
        raise RuntimeError("No game structure loaded (use Load Folder, not Load File, before exporting).")

    _state.export_progress = {"running": True, "current": 0, "total": 0, "current_name": "", "error": None}
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
        except Exception as ex:  # noqa: BLE001 -- reported via export_progress()["error"], not raised
            _state.export_progress["error"] = repr(ex)
        finally:
            _state.export_progress["running"] = False

    threading.Thread(target=_run, daemon=True).start()


def get_export_plan():
    """Builds (or returns the still-valid cached) `ExportPlan` for the currently loaded game --
    see the module docstring for the cache-key rationale. Raises the same error `game_data()`
    would if nothing's loaded via `load_paths`."""
    current_game_data = game_data()
    key = (id(current_game_data), id(_state.settings))
    if _state._export_plan is None or _state._export_plan_key != key:
        from .export_plan import build_export_plan

        _state._export_plan = build_export_plan(current_game_data, _state.settings)
        _state._export_plan_key = key
    return _state._export_plan


def has_browsable_project() -> bool:
    """Whether `/Project` has anything to show: either an explicitly loaded disk export
    (`exported_project_dir`) or a freshly loaded game with an `ExportPlan` preview available."""
    return _state.exported_project_dir is not None or has_game_data()


def has_exported_project() -> bool:
    return _state.exported_project_dir is not None


def exported_project_dir() -> str:
    if _state.exported_project_dir is None:
        raise RuntimeError("No exported project to browse (export or load one first).")
    return _state.exported_project_dir


def load_exported_project(path: str) -> None:
    """Points `/Project` at a project directory exported to disk in an earlier run -- e.g. via
    the CLI, or a previous GUI session's real `OutputPath` export -- without running a fresh
    export. Doesn't touch `game_bundle`/`game_data`; browsing an old export doesn't require the
    source game to still be loaded."""
    if not os.path.isdir(path):
        raise FileNotFoundError(f"Directory not found: {path}")
    _state.exported_project_dir = path


def reset() -> None:
    if _state.game_data is not None and _state.game_data.temp_directories:
        # 2026-08-03 fix: an archive (.apk/.ipa/...) extracted while loading the game we're
        # about to discard leaks its temp directory forever otherwise -- nothing else in the
        # GUI holds a reference to it once game_data is replaced below. Safe here specifically
        # because we're replacing the whole loaded game (a fresh load_paths, or an explicit
        # reset): the ExportPlan/preview built from the old game_data is cleared in this same
        # call, so nothing downstream reads from those files again.
        from assetripper_import.structure import zip_extractor

        zip_extractor.cleanup(_state.game_data.temp_directories, LocalFileSystem.instance())

    _state.game_bundle = None
    _state.game_data = None
    _state.load_errors = []
    _state.export_progress = {"running": False, "current": 0, "total": 0, "current_name": "", "error": None}
    _state.exported_project_dir = None
    _state._export_plan = None
    _state._export_plan_key = None


def load_paths(paths: list[str], progress_callback=None) -> None:
    """Loads one or more files/folders as a full Unity game: platform discovery, every
    SerializedFile/bundle found, dependency resolution, and the standard processors --
    everything `ExportHandler.load_and_process` does. Populates `game_data()`, which
    `/Export/UnityProject` needs; `load_file` never does.

    Synchronous -- blocks until the whole load finishes. `start_load` below wraps this on a
    background thread with a live `progress_callback` for the GUI; call this directly (as
    tests and the CLI do) when blocking is fine."""
    reset()

    from assetripper_export_unity_projects.export_handler import ExportHandler

    file_system = LocalFileSystem.instance()
    handler = ExportHandler()
    try:
        data = handler.load_and_process(
            list(paths), file_system, settings=_state.settings, progress_callback=progress_callback
        )
    except Exception as ex:  # noqa: BLE001 -- GUI error boundary, reported to the user via flash
        _state.load_errors.append(f"Failed to load: {ex!r}")
        return

    if not data.game_bundle.has_any_asset_collections():
        _state.load_errors.append("No valid Unity assets found in the given path(s).")
        return

    _state.game_data = data
    _state.game_bundle = data.game_bundle


def load_progress() -> dict:
    return dict(_state.load_progress)


def start_load(paths: list[str]) -> None:
    """Runs `load_paths` on a background thread (Phase 19c) so the POST handler can return
    immediately and the GUI can poll `load_progress()` for live milestones instead of blocking
    the whole request -- a real `.ipa` takes ~38s to extract and read (see ROADMAP Phase 19),
    which used to hang the browser with zero feedback. Raises if a load from this process is
    already running -- overlapping loads would race on `load_progress` (and on `reset()`)."""
    if _state.load_progress["running"]:
        raise RuntimeError("A load is already running.")

    _state.load_progress = {"running": True, "message": "Starting...", "error": None}

    def _on_progress(message: str) -> None:
        _state.load_progress["message"] = message

    def _run() -> None:
        try:
            load_paths(paths, progress_callback=_on_progress)
        except Exception as ex:  # noqa: BLE001 -- reported via load_progress()["error"], not raised
            _state.load_progress["error"] = repr(ex)
        finally:
            _state.load_progress["running"] = False

    threading.Thread(target=_run, daemon=True).start()


def load_file(path: str) -> None:
    """Loads a single file at `path` into a fresh GameBundle -- either a raw
    SerializedFile or a UnityFS bundle (see module docstring). Anything else is
    recorded as a load error rather than added as a FailedFile.

    Phase 19b: builds the bundle in a local variable and only assigns it to
    `_state.game_bundle` once reading actually succeeds -- previously this assigned the
    (still-empty) bundle to `_state.game_bundle` *before* validating the file, so a failed
    load left `is_loaded() == True` with nothing in it: a contradictory state (`is_loaded()`
    true, `has_game_data()` false, no load error visibly tied to "nothing is actually
    loaded"). A failed load now leaves state exactly as `reset()` left it."""
    reset()

    if not os.path.isfile(path):
        _state.load_errors.append(f"File not found: {path}")
        return

    bundle = GameBundle()
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
            _state.game_bundle = bundle
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
        _state.game_bundle = bundle
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

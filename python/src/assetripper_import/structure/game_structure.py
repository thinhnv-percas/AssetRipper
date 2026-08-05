"""Port of Source/AssetRipper.Import/Structure/GameStructure.cs

Two things upstream does are intentionally not ported here:
- `InitializeAssemblyManager`'s full generality (Mono/IL2Cpp/Base manager selection +
  `OnRequestAssembly` callback wiring). Phase 16f ports the Mono half of this: if any `.dll`
  files were found under `Managed/` (or scattered across a `MixedGameStructure`), a
  `MonoAssemblyManager` (`structure.assembly.managers.mono_assembly_manager`) is built and
  assigned to `assembly_manager`, and used both by `GameAssetFactory` while reading (to park
  `UnloadedMonoBehaviour` placeholders) and by this class afterward (to resolve them for
  real -- see `resolve_unloaded_mono_behaviours`'s own docstring for why that has to be a
  second pass). `assembly_manager` stays `None` -- matching the pre-16f contract every
  existing caller (e.g. `DllPostExporter`) already checks for -- when no assemblies are
  found at all, or the scripting backend is IL2CPP (16d/16e, not implemented).
- `CoreConfiguration`/`ImportSettings` -- not ported (see assetripper_configuration's
  scope). `load()` takes the handful of settings it actually needs as keyword arguments
  instead of a configuration object.
"""
from __future__ import annotations

import logging
from collections.abc import Iterable

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_primitives import UnityVersion

from ..asset_creation.game_asset_factory import GameAssetFactory
from ..platforms.platform_checker import check_platform
from . import zip_extractor
from .assembly.managers.mono_assembly_manager import MonoAssemblyManager
from .assembly.managers.unloaded_structure import resolve_unloaded_mono_behaviours
from .game_initializer import GameInitializer

_logger = logging.getLogger(__name__)


class GameStructure:
    def __init__(
        self,
        paths: list[str],
        file_system,
        *,
        default_version: UnityVersion | None = None,
        target_version: UnityVersion | None = None,
        ignore_streaming_assets: bool = False,
        script_content_level=None,
        progress_callback=None,
        temp_directories: list[str] | None = None,
        assembly_directories: Iterable[str] = (),
    ):
        """`script_content_level` (Phase 16f): a `ScriptContentLevel`
        (`assetripper_export_configuration`) or plain `int`/`None` -- kept untyped here to
        avoid this package depending on the export-configuration one. `LEVEL_0` (0) disables
        Mono script recovery entirely (`assembly_manager` stays `None` even if `.dll` files
        were found, matching upstream's "don't load scripts at all"); any other value
        (including the default, `None`) attempts recovery. Upstream's `LEVEL_1`
        ("stub method bodies") vs `LEVEL_2` ("default") distinction isn't modeled -- this
        port's recovery is single-tier (declaration + real field layout, never method
        bodies -- see ROADMAP.md Phase 16g), so both behave like `LEVEL_2`.

        `temp_directories` (2026-08-03 fix): directories `zip_extractor.process` created while
        unpacking an archive to get to `paths`, if this instance was built via `load()` -- kept
        so `dispose()` (and callers that read `.temp_directories` directly, e.g. `GameData`)
        can clean them up once the extracted files are no longer needed. Empty when `load()`
        wasn't used (`paths` were already plain files/directories, nothing was extracted).

        `assembly_directories` (ROADMAP 16c-alt): directories of user-supplied `.dll` files to
        recover scripts from, in addition to any assemblies found inside the build itself. An
        explicitly supplied assembly **wins** over a same-named one discovered in the build:
        passing the directory at all is a deliberate act, so it's read as "use these". In
        practice they rarely collide -- an IL2CPP build has no `Managed/` directory for the
        discovery pass to find anything in, which is the case this option exists for.
        `script_content_level=0` disables these too, same as build-discovered assemblies."""
        self.file_system = file_system
        self.temp_directories: list[str] = temp_directories if temp_directories is not None else []

        if progress_callback:
            progress_callback("Discovering platform structure...")
        self.platform_structure, self.mixed_structure = check_platform(paths, file_system)
        if self.platform_structure is not None:
            self.platform_structure.collect_files(ignore_streaming_assets)
        # MixedStructure.collect_files() is intentionally not called here either -- upstream
        # leaves the equivalent call commented out, and PlatformGameStructure.collect_files()
        # is a no-op for MixedGameStructure anyway (it already collected files in __init__).

        self.assembly_manager = None
        if script_content_level is None or script_content_level != 0:
            self.assembly_manager = _create_assembly_manager(
                self.platform_structure, self.mixed_structure, file_system, assembly_directories
            )

        default_version = default_version if default_version is not None else UnityVersion()
        target_version = target_version if target_version is not None else UnityVersion()

        asset_factory = GameAssetFactory(assembly_manager=self.assembly_manager)
        file_paths = _get_file_paths(self.platform_structure, self.mixed_structure)
        if progress_callback:
            progress_callback(f"Reading {len(file_paths)} file(s)...")
        self.file_collection = GameBundle.from_paths(
            file_paths,
            asset_factory,
            file_system,
            GameInitializer(self.platform_structure, self.mixed_structure, file_system, default_version, target_version),
        )

        if self.assembly_manager is not None:
            resolve_unloaded_mono_behaviours(self.file_collection, self.assembly_manager)

        if not self.file_collection.has_any_asset_collections():
            _logger.warning("The game structure processor could not find any valid assets.")

    @property
    def is_valid(self) -> bool:
        return self.file_collection.has_any_asset_collections()

    @property
    def name(self) -> str | None:
        if self.platform_structure is not None:
            return self.platform_structure.name
        if self.mixed_structure is not None:
            return self.mixed_structure.name
        return None

    @staticmethod
    def load(
        paths: Iterable[str],
        file_system,
        *,
        default_version: UnityVersion | None = None,
        target_version: UnityVersion | None = None,
        ignore_streaming_assets: bool = False,
        script_content_level=None,
        progress_callback=None,
        assembly_directories: Iterable[str] = (),
    ) -> "GameStructure":
        """`progress_callback(message: str)` (Phase 19c), optional: reports coarse milestones
        only ("Extracting archive...", "Discovering platform structure...", "Reading N
        file(s)...") -- there's no cheap way to know a numeric total/current up front (unlike
        `ProjectExporter.export`'s per-asset progress), so this is a status message, not a
        percentage. `script_content_level` (Phase 16f) and `assembly_directories` (16c-alt):
        see `__init__`'s docstring."""
        if progress_callback:
            progress_callback("Extracting archive...")
        temp_directories: list[str] = []
        to_process = zip_extractor.process(paths, file_system, temp_directories)
        if not to_process:
            raise ValueError("Game files not found")

        return GameStructure(
            to_process,
            file_system,
            default_version=default_version,
            target_version=target_version,
            ignore_streaming_assets=ignore_streaming_assets,
            script_content_level=script_content_level,
            progress_callback=progress_callback,
            temp_directories=temp_directories,
            assembly_directories=assembly_directories,
        )

    def dispose(self) -> None:
        if self.file_collection is not None:
            self.file_collection.dispose()
        if self.temp_directories:
            zip_extractor.cleanup(self.temp_directories, self.file_system)
            self.temp_directories = []


def _get_file_paths(platform_structure, mixed_structure) -> list[str]:
    if platform_structure is None or mixed_structure is None:
        structure = platform_structure if platform_structure is not None else mixed_structure
        return [path for _, path in structure.files] if structure is not None else []

    seen: set[tuple[str, str]] = set()
    paths: list[str] = []
    for name, path in (*platform_structure.files, *mixed_structure.files):
        key = (name, path)
        if key not in seen:
            seen.add(key)
            paths.append(path)
    return paths


def _get_assemblies(platform_structure, mixed_structure) -> dict[str, str]:
    """assembly-file-name (with '.dll') -> path, merged the same way `_get_file_paths`
    merges `.files` -- both `platform_structure`/`mixed_structure` are `PlatformGameStructure`
    instances (or `None`) and each independently exposes its own `.assemblies`."""
    if platform_structure is None or mixed_structure is None:
        structure = platform_structure if platform_structure is not None else mixed_structure
        return dict(structure.assemblies) if structure is not None else {}

    merged = dict(platform_structure.assemblies)
    merged.update(mixed_structure.assemblies)
    return merged


def _create_assembly_manager(
    platform_structure, mixed_structure, file_system, extra_assembly_directories=()
) -> "MonoAssemblyManager | None":
    assemblies = _get_assemblies(platform_structure, mixed_structure)
    assemblies.update(_collect_assemblies_in_directories(extra_assembly_directories, file_system))
    if not assemblies:
        return None
    return MonoAssemblyManager(assemblies, file_system)


def _collect_assemblies_in_directories(directories, file_system) -> dict[str, str]:
    """ROADMAP 16c-alt: `.dll` files the *user* supplied, rather than ones discovered inside the
    game build. The intended source is a dummy-assembly directory produced by an external tool
    (Il2CppDumper / Cpp2IL / DevX-GameRecovery) -- those dummies carry real .NET metadata with
    real field declarations, which is exactly what the 16c reader consumes, so they give the
    whole of Phase 16's output for an IL2CPP build without this port having to parse
    `global-metadata.dat` itself (16d/16e). Upstream offers the same route by letting the user
    point at assemblies directly.

    Non-recursive, and `.dll` only: a dumper's output directory holds the assemblies flat, and
    walking into subdirectories would start picking up unrelated native libraries.
    """
    collected: dict[str, str] = {}
    for directory in directories:
        if not file_system.directory.exists(directory):
            _logger.warning("Assembly directory does not exist, ignoring: %s", directory)
            continue
        found = 0
        for path in file_system.directory.enumerate_files(directory):
            if file_system.path.get_extension(path).lower() != ".dll":
                continue
            collected[file_system.path.get_file_name(path)] = path
            found += 1
        if found:
            _logger.info("Found %d user-supplied assembly file(s) in %s", found, directory)
        else:
            _logger.warning("No .dll files found in assembly directory: %s", directory)
    return collected

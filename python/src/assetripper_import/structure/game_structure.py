"""Port of Source/AssetRipper.Import/Structure/GameStructure.cs

Two things upstream does are intentionally not ported here:
- `InitializeAssemblyManager` (Mono/IL2Cpp/Base manager selection + `OnRequestAssembly`
  callback wiring) -- this port's `GameAssetFactory` never touches an assembly manager
  (see asset_creation/game_asset_factory.py's module docstring: MonoBehaviour fields with
  no embedded type tree become UnknownObject rather than resolving through IL), so there
  is nothing for an assembly manager to do. `assembly_manager` is always `None`, matching
  upstream's own "Unknown scripting backend" fallback path (`BaseManager`).
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
    ):
        self.file_system = file_system
        self.assembly_manager = None

        self.platform_structure, self.mixed_structure = check_platform(paths, file_system)
        if self.platform_structure is not None:
            self.platform_structure.collect_files(ignore_streaming_assets)
        # MixedStructure.collect_files() is intentionally not called here either -- upstream
        # leaves the equivalent call commented out, and PlatformGameStructure.collect_files()
        # is a no-op for MixedGameStructure anyway (it already collected files in __init__).

        default_version = default_version if default_version is not None else UnityVersion()
        target_version = target_version if target_version is not None else UnityVersion()

        asset_factory = GameAssetFactory()
        file_paths = _get_file_paths(self.platform_structure, self.mixed_structure)
        self.file_collection = GameBundle.from_paths(
            file_paths,
            asset_factory,
            file_system,
            GameInitializer(self.platform_structure, self.mixed_structure, file_system, default_version, target_version),
        )

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
    ) -> "GameStructure":
        to_process = zip_extractor.process(paths, file_system)
        if not to_process:
            raise ValueError("Game files not found")

        return GameStructure(
            to_process,
            file_system,
            default_version=default_version,
            target_version=target_version,
            ignore_streaming_assets=ignore_streaming_assets,
        )

    def dispose(self) -> None:
        if self.file_collection is not None:
            self.file_collection.dispose()


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

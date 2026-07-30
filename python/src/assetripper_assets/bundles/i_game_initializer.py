"""Port of Source/AssetRipper.Assets/Bundles/IGameInitializer.cs"""
from __future__ import annotations

from abc import ABC

from assetripper_primitives import UnityVersion


class IGameInitializer(ABC):
    dependency_provider = None
    resource_provider = None
    default_version: UnityVersion = UnityVersion()

    def on_created(self, game_bundle, asset_factory) -> None:
        pass

    def on_paths_loaded(self, game_bundle, asset_factory) -> None:
        pass

    def on_dependencies_initialized(self, game_bundle, asset_factory) -> None:
        pass

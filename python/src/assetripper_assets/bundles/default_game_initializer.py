"""Port of Source/AssetRipper.Assets/Bundles/DefaultGameInitializer.cs"""
from __future__ import annotations

from dataclasses import dataclass, field

from assetripper_primitives import UnityVersion

from .i_game_initializer import IGameInitializer


@dataclass
class DefaultGameInitializer(IGameInitializer):
    dependency_provider: object = None
    resource_provider: object = None
    default_version: UnityVersion = field(default_factory=UnityVersion)

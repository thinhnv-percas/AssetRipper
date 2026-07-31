"""Port of Source/AssetRipper.Processing/GameData.cs"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass
class GameData:
    game_bundle: object
    project_version: object
    assembly_manager: object
    platform_structure: object

    def add_new_processed_collection(self, name: str):
        return self.game_bundle.add_new_processed_collection(name, self.project_version)

    @staticmethod
    def from_game_structure(game_structure) -> "GameData":
        return GameData(
            game_structure.file_collection,
            game_structure.file_collection.get_max_unity_version(),
            game_structure.assembly_manager,
            game_structure.platform_structure,
        )

"""Port of Source/AssetRipper.Processing/GameData.cs"""
from __future__ import annotations

from dataclasses import dataclass, field


@dataclass
class GameData:
    game_bundle: object
    project_version: object
    assembly_manager: object
    platform_structure: object
    temp_directories: "list[str]" = field(default_factory=list)
    """Directories `zip_extractor.process` created while unpacking an archive to reach this
    game's files (2026-08-03 fix) -- carried from `GameStructure.temp_directories` so
    `ExportHandler.export()`/`game_file_loader.reset()` can clean them up once the extracted
    files are no longer needed. Never populated before that point (`GameStructure` itself goes
    out of scope right after `from_game_structure` runs, so this is the only surviving handle
    to them)."""

    def add_new_processed_collection(self, name: str):
        return self.game_bundle.add_new_processed_collection(name, self.project_version)

    @staticmethod
    def from_game_structure(game_structure) -> "GameData":
        return GameData(
            game_structure.file_collection,
            game_structure.file_collection.get_max_unity_version(),
            game_structure.assembly_manager,
            game_structure.platform_structure,
            list(getattr(game_structure, "temp_directories", ())),
        )

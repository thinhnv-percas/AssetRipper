"""Port of Source/AssetRipper.Import/Platforms/SwitchGameStructure.cs"""
from __future__ import annotations

from ..structure.assembly.scripting_backend import ScriptingBackend
from .platform_game_structure import (
    DATA_FOLDER_NAME,
    DEFAULT_GLOBAL_METADATA_NAME,
    MANAGED_NAME,
    METADATA_NAME,
    RESOURCES_NAME,
    STREAMING_NAME,
    PlatformGameStructure,
)

_EXEFS_NAME = "exefs"
_ROM_NAME = "romfs"
_MAIN_NAME = "main"


class SwitchGameStructure(PlatformGameStructure):
    def __init__(self, root_path: str, file_system):
        super().__init__(file_system, root_path)

        found, data_path = _get_data_switch_directory(self.root_path, file_system)
        if not found:
            raise FileNotFoundError("Data directory wasn't found")

        self.name = file_system.path.get_file_name(root_path)
        self.game_data_path = data_path
        self.streaming_assets_path = file_system.path.join(self.game_data_path, STREAMING_NAME)
        self.resources_path = file_system.path.join(self.game_data_path, RESOURCES_NAME)
        self.managed_path = file_system.path.join(self.game_data_path, MANAGED_NAME)
        self.unity_player_path = None
        self.version = self._get_unity_version_from_data_directory(self.game_data_path)
        self.il2cpp_game_assembly_path = file_system.path.join(root_path, _EXEFS_NAME, _MAIN_NAME)
        self.il2cpp_metadata_path = file_system.path.join(self.managed_path, METADATA_NAME, DEFAULT_GLOBAL_METADATA_NAME)
        self.backend = ScriptingBackend.IL2CPP if self._has_il2cpp_files() else ScriptingBackend.UNKNOWN

        self.data_paths = [self.game_data_path]

    @staticmethod
    def exists(path: str, file_system) -> bool:
        found, _ = _get_data_switch_directory(path, file_system)
        return (
            file_system.directory.exists(path)
            and file_system.directory.exists(file_system.path.join(path, _EXEFS_NAME))
            and found
        )


def _get_data_switch_directory(root_directory: str, file_system) -> tuple[bool, str | None]:
    rom_path = file_system.path.join(root_directory, _ROM_NAME)
    if not file_system.directory.exists(rom_path):
        return False, None

    ldata_path = file_system.path.join(rom_path, DATA_FOLDER_NAME)
    if not file_system.directory.exists(ldata_path):
        return False, None

    return True, ldata_path

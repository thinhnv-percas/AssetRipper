"""Port of Source/AssetRipper.Import/Platforms/PS4GameStructure.cs"""
from __future__ import annotations

from ..structure.assembly.scripting_backend import ScriptingBackend
from .platform_game_structure import (
    DEFAULT_GLOBAL_METADATA_NAME,
    GLOBAL_GAME_MANAGERS_NAME,
    MANAGED_NAME,
    METADATA_NAME,
    RESOURCES_NAME,
    PlatformGameStructure,
)

_PS4_EXECUTABLE_NAME = "eboot.bin"
_PS4_DATA_FOLDER_NAME = "Media"
_MODULES_NAME = "Modules"
_PS4_IL2CPP_GAME_ASSEMBLY_NAME = "Il2CppUserAssemblies.prx"


class PS4GameStructure(PlatformGameStructure):
    def __init__(self, root_path: str, file_system):
        super().__init__(file_system, root_path)

        found, data_path = _get_data_directory(self.root_path, file_system)
        if not found:
            raise FileNotFoundError("Data directory wasn't found")

        self.name = file_system.path.get_file_name(root_path)
        self.game_data_path = data_path
        self.resources_path = file_system.path.join(self.game_data_path, RESOURCES_NAME)
        self.managed_path = file_system.path.join(self.game_data_path, MANAGED_NAME)
        self.modules_path = file_system.path.join(self.game_data_path, _MODULES_NAME)
        self.unity_player_path = None
        global_game_managers_path = file_system.path.join(self.game_data_path, GLOBAL_GAME_MANAGERS_NAME)
        self.version = self._get_unity_version_from_data_directory(global_game_managers_path)
        self.il2cpp_game_assembly_path = file_system.path.join(self.modules_path, _PS4_IL2CPP_GAME_ASSEMBLY_NAME)
        self.il2cpp_metadata_path = file_system.path.join(self.game_data_path, METADATA_NAME, DEFAULT_GLOBAL_METADATA_NAME)

        if self._has_il2cpp_files():
            self.backend = ScriptingBackend.IL2CPP
        elif self._has_mono_assemblies(self.managed_path):
            self.backend = ScriptingBackend.MONO
        else:
            self.backend = ScriptingBackend.UNKNOWN

        self.data_paths = [self.game_data_path]

    @staticmethod
    def exists(path: str, file_system) -> bool:
        if not file_system.directory.exists(path):
            return False
        found, _ = _get_data_directory(path, file_system)
        return found


def _get_data_directory(root_directory: str, file_system) -> tuple[bool, str | None]:
    for file in file_system.directory.enumerate_files(root_directory):
        if file_system.path.get_file_name(file) == _PS4_EXECUTABLE_NAME:
            data_path = file_system.path.join(root_directory, _PS4_DATA_FOLDER_NAME)
            if file_system.directory.exists(data_path):
                return True, data_path

    return False, None

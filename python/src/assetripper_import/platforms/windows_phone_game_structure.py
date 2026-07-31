"""Port of Source/AssetRipper.Import/Platforms/WindowsPhoneGameStructure.cs"""
from __future__ import annotations

from ..structure.assembly.scripting_backend import ScriptingBackend
from .platform_game_structure import (
    DATA_FOLDER_NAME,
    DEFAULT_GAME_ASSEMBLY_NAME,
    DEFAULT_GLOBAL_METADATA_NAME,
    DEFAULT_UNITY_PLAYER_NAME,
    METADATA_NAME,
    RESOURCES_NAME,
    STREAMING_NAME,
    PlatformGameStructure,
)


class WindowsPhoneGameStructure(PlatformGameStructure):
    def __init__(self, root_path: str, file_system):
        super().__init__(file_system, root_path)

        found, data_path, name = _get_data_directory(self.root_path, file_system)
        if not found:
            raise FileNotFoundError("Data directory wasn't found")

        self.name = name
        self.game_data_path = data_path
        self.streaming_assets_path = file_system.path.join(self.game_data_path, STREAMING_NAME)
        self.resources_path = file_system.path.join(self.game_data_path, RESOURCES_NAME)
        self.managed_path = file_system.path.join(self.root_path)
        self.unity_player_path = file_system.path.join(self.root_path, DEFAULT_UNITY_PLAYER_NAME)
        self.version = self._get_unity_version_from_data_directory(self.game_data_path)
        self.il2cpp_game_assembly_path = file_system.path.join(self.root_path, DEFAULT_GAME_ASSEMBLY_NAME)
        self.il2cpp_metadata_path = file_system.path.join(self.game_data_path, "il2cpp_data", METADATA_NAME, DEFAULT_GLOBAL_METADATA_NAME)

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
        found, _, _ = _get_data_directory(path, file_system)
        return found


def _get_data_directory(root_directory: str, file_system) -> tuple[bool, str | None, str | None]:
    assets_path = file_system.path.join(root_directory, "Assets")
    if not file_system.directory.exists(assets_path):
        return False, None, None

    data_path = file_system.path.join(root_directory, DATA_FOLDER_NAME)
    if not file_system.directory.exists(data_path):
        return False, None, None

    executable_path = None
    for file in file_system.directory.get_files(root_directory, "*.exe"):
        if executable_path is None:
            executable_path = file
        else:
            executable_path = None
            break

    if executable_path is not None:
        app_name = file_system.path.get_file_name_without_extension(executable_path)
        return True, data_path, app_name
    return False, None, None

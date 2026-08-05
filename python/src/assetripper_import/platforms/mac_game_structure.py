"""Port of Source/AssetRipper.Import/Platforms/MacGameStructure.cs"""
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

_CONTENTS_NAME = "Contents"
_FRAMEWORKS_NAME = "Frameworks"
_MAC_UNITY_PLAYER_NAME = "UnityPlayer.dylib"
_APP_EXTENSION = ".app"


class MacGameStructure(PlatformGameStructure):
    def __init__(self, root_path: str, file_system):
        super().__init__(file_system, root_path)

        resource_path = file_system.path.join(root_path, _CONTENTS_NAME, RESOURCES_NAME)
        if not file_system.directory.exists(resource_path):
            raise FileNotFoundError("Resources directory wasn't found")
        data_path = file_system.path.join(resource_path, DATA_FOLDER_NAME)
        if not file_system.directory.exists(data_path):
            raise FileNotFoundError("Data directory wasn't found")
        self.data_paths = [data_path, resource_path]

        assert root_path.endswith(_APP_EXTENSION)
        self.name = file_system.path.get_file_name_without_extension(root_path)
        self.game_data_path = data_path
        self.streaming_assets_path = file_system.path.join(self.game_data_path, STREAMING_NAME)
        self.resources_path = file_system.path.join(self.game_data_path, RESOURCES_NAME)
        self.managed_path = file_system.path.join(self.game_data_path, MANAGED_NAME)
        self.unity_player_path = file_system.path.join(self.root_path, _CONTENTS_NAME, _FRAMEWORKS_NAME, _MAC_UNITY_PLAYER_NAME)
        self.version = None

        self.il2cpp_game_assembly_path = file_system.path.join(self.root_path, _CONTENTS_NAME, _FRAMEWORKS_NAME, "GameAssembly.dylib")
        self.il2cpp_metadata_path = file_system.path.join(self.game_data_path, "il2cpp_data", METADATA_NAME, DEFAULT_GLOBAL_METADATA_NAME)

        if self._has_il2cpp_files():
            self.backend = ScriptingBackend.IL2CPP
        elif self._has_mono_assemblies(self.managed_path):
            self.backend = ScriptingBackend.MONO
        else:
            self.backend = ScriptingBackend.UNKNOWN

    @staticmethod
    def exists(path: str, file_system) -> bool:
        if not file_system.directory.exists(path):
            return False
        if file_system.path.get_extension(path) != _APP_EXTENSION:
            return False

        data_path = file_system.path.join(path, _CONTENTS_NAME, RESOURCES_NAME, DATA_FOLDER_NAME)
        if not file_system.directory.exists(data_path):
            return False
        resource_path = file_system.path.join(path, _CONTENTS_NAME, RESOURCES_NAME)
        return file_system.directory.exists(resource_path)

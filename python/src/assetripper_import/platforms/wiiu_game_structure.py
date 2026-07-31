"""Port of Source/AssetRipper.Import/Platforms/WiiUGameStructure.cs"""
from __future__ import annotations

from ..structure.assembly.scripting_backend import ScriptingBackend
from .platform_game_structure import DATA_FOLDER_NAME, MANAGED_NAME, RESOURCES_NAME, STREAMING_NAME, PlatformGameStructure

_CONTENT_NAME = "content"


class WiiUGameStructure(PlatformGameStructure):
    def __init__(self, root_path: str, file_system):
        super().__init__(file_system, root_path)

        self.name = file_system.path.get_file_name(root_path)
        self.game_data_path = file_system.path.join(self.root_path, _CONTENT_NAME, DATA_FOLDER_NAME)
        if not file_system.directory.exists(self.game_data_path):
            raise FileNotFoundError("Data directory wasn't found")
        self.streaming_assets_path = file_system.path.join(self.game_data_path, STREAMING_NAME)
        self.resources_path = file_system.path.join(self.game_data_path, RESOURCES_NAME)
        self.managed_path = file_system.path.join(self.game_data_path, MANAGED_NAME)
        self.unity_player_path = None
        self.version = None
        self.il2cpp_game_assembly_path = None
        self.il2cpp_metadata_path = None
        # WiiU doesn't support IL2Cpp.
        # See https://docs.unity3d.com/2017.4/Documentation/Manual/ScriptingRestrictions.html

        if self._has_mono_assemblies(self.managed_path):
            self.backend = ScriptingBackend.MONO
        else:
            self.backend = ScriptingBackend.UNKNOWN

        self.data_paths = [self.game_data_path]

    @staticmethod
    def exists(root_path: str, file_system) -> bool:
        game_data_path = file_system.path.join(root_path, _CONTENT_NAME, DATA_FOLDER_NAME)
        return file_system.directory.exists(game_data_path)

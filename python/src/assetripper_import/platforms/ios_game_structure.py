"""Port of Source/AssetRipper.Import/Platforms/iOSGameStructure.cs"""
from __future__ import annotations

from ..structure.assembly.scripting_backend import ScriptingBackend
from .platform_game_structure import DATA_FOLDER_NAME, MANAGED_NAME, METADATA_NAME, RESOURCES_NAME, PlatformGameStructure

_IOS_STREAMING_NAME = "Raw"
_PAYLOAD_NAME = "Payload"
_APP_EXTENSION = ".app"


class iOSGameStructure(PlatformGameStructure):  # noqa: N801 -- matches Unity/upstream's own casing
    def __init__(self, root_path: str, file_system):
        super().__init__(file_system, root_path)

        found, data_path, app_path, name = _get_data_ios_directory(root_path, file_system)
        if not found:
            raise FileNotFoundError("Data directory wasn't found")

        self.name = name
        self.game_data_path = data_path
        self.streaming_assets_path = file_system.path.join(root_path, _IOS_STREAMING_NAME)
        self.resources_path = file_system.path.join(data_path, RESOURCES_NAME)
        self.managed_path = file_system.path.join(data_path, MANAGED_NAME)
        self.unity_player_path = None
        self.version = self._get_unity_version_from_data_directory(self.game_data_path)
        self.il2cpp_game_assembly_path = file_system.path.join(app_path, name)
        self.il2cpp_metadata_path = file_system.path.join(self.managed_path, METADATA_NAME, "global-metadata.dat")

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
        found, _, _, _ = _get_data_ios_directory(path, file_system)
        return found


def _get_data_ios_directory(root_directory: str, file_system) -> tuple[bool, str | None, str | None, str | None]:
    payload_path = file_system.path.join(root_directory, _PAYLOAD_NAME)
    if not file_system.directory.exists(payload_path):
        return False, None, None, None

    for directory in file_system.directory.enumerate_directories(payload_path):
        name = file_system.path.get_file_name(directory)
        if name.endswith(_APP_EXTENSION):
            app_path = directory
            app_name = name[: -len(_APP_EXTENSION)]
            data_path = file_system.path.join(directory, DATA_FOLDER_NAME)
            if file_system.directory.exists(data_path):
                return True, data_path, app_path, app_name

    return False, None, None, None

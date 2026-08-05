"""Port of Source/AssetRipper.Import/Platforms/LinuxGameStructure.cs"""
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

_X86_EXTENSION = ".x86"
_X64_EXTENSION = ".x64"
_X86_64_EXTENSION = ".x86_64"


class LinuxGameStructure(PlatformGameStructure):
    def __init__(self, root_path: str, file_system):
        super().__init__(file_system, _get_actual_root_path(root_path, file_system))

        found, data_path, name = _get_data_directory(self.root_path, file_system)
        if not found:
            raise FileNotFoundError("Data directory wasn't found")

        self.name = name
        self.game_data_path = data_path
        self.streaming_assets_path = file_system.path.join(self.game_data_path, STREAMING_NAME)
        self.resources_path = file_system.path.join(self.game_data_path, RESOURCES_NAME)
        self.managed_path = file_system.path.join(self.game_data_path, MANAGED_NAME)
        self.unity_player_path = file_system.path.join(self.root_path, "UnityPlayer.so")
        self.version = None
        self.il2cpp_game_assembly_path = file_system.path.join(self.root_path, "GameAssembly.so")
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
        if _is_executable_file(path, file_system):
            directory = file_system.path.get_directory_name(path)
            if directory is None:
                raise ValueError("Could not get file directory")
        elif _is_unity_data_directory(path, file_system):
            return True
        else:
            directory = path

        return file_system.directory.exists(directory) and _is_root_directory(directory, file_system)


def _is_unity_data_directory(folder_path: str, file_system) -> bool:
    suffix = f"_{DATA_FOLDER_NAME}"
    if not folder_path or not folder_path.endswith(suffix):
        return False
    if not file_system.directory.exists(folder_path):
        return False

    folder_name = file_system.path.get_file_name(folder_path)
    game_name = folder_name[: -len(suffix)]
    root_path = file_system.path.get_directory_name(folder_path)
    candidates = (
        game_name + _X86_EXTENSION,
        game_name + _X64_EXTENSION,
        game_name + _X86_64_EXTENSION,
        game_name,
    )
    return any(file_system.file.exists(file_system.path.join(root_path, candidate)) for candidate in candidates)


def _is_executable_file(file_path: str, file_system) -> bool:
    return bool(file_path) and file_path.endswith((_X86_EXTENSION, _X64_EXTENSION, _X86_64_EXTENSION)) and file_system.file.exists(file_path)


def _get_actual_root_path(root_path: str, file_system) -> str:
    if not root_path:
        raise ValueError("root_path must not be empty")
    if _is_executable_file(root_path, file_system):
        directory = file_system.path.get_directory_name(root_path)
        if directory is None:
            raise ValueError("Could not get file directory")
        return directory
    elif _is_unity_data_directory(root_path, file_system):
        directory = file_system.path.get_directory_name(root_path)
        if directory is None:
            raise ValueError("Could not get parent directory")
        return directory
    else:
        return root_path


def _is_root_directory(root_directory: str, file_system) -> bool:
    found, _, _ = _get_data_directory(root_directory, file_system)
    return found


def _get_data_directory(root_directory: str, file_system) -> tuple[bool, str | None, str | None]:
    for file in file_system.directory.enumerate_files(root_directory):
        extension = file_system.path.get_extension(file)
        if extension in (_X86_EXTENSION, _X64_EXTENSION, _X86_64_EXTENSION, ""):
            name = file_system.path.get_file_name_without_extension(file)
            data_folder = f"{name}_{DATA_FOLDER_NAME}"
            data_path = file_system.path.join(root_directory, data_folder)
            if file_system.directory.exists(data_path):
                return True, data_path, name

    return False, None, None

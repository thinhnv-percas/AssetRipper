"""Port of Source/AssetRipper.Import/Platforms/AndroidGameStructure.cs"""
from __future__ import annotations

from ..structure.assembly.scripting_backend import ScriptingBackend
from .platform_game_structure import DATA_FOLDER_NAME, LIB_NAME, MANAGED_NAME, METADATA_NAME, RESOURCES_NAME, PlatformGameStructure

_ASSET_NAME = "assets"
_META_NAME = "META-INF"
_BIN_NAME = "bin"
_IL2CPP_GAME_ASSEMBLY_NAME = "libil2cpp.so"


class AndroidGameStructure(PlatformGameStructure):
    def __init__(self, root_path: str, obb_path: str | None, file_system):
        super().__init__(file_system, root_path)

        apk_data_path = file_system.path.join(root_path, _ASSET_NAME, _BIN_NAME, DATA_FOLDER_NAME)
        if not file_system.directory.exists(apk_data_path):
            raise FileNotFoundError("Data directory hasn't been found")
        data_paths = [apk_data_path]

        self.game_data_path = apk_data_path
        self.streaming_assets_path = None
        self.resources_path = file_system.path.join(self.game_data_path, RESOURCES_NAME)
        self.managed_path = file_system.path.join(self.game_data_path, MANAGED_NAME)
        self.lib_path = file_system.path.join(self.root_path, LIB_NAME)
        self.il2cpp_game_assembly_path = self._get_il2cpp_game_assembly_path(self.lib_path)
        self.il2cpp_metadata_path = file_system.path.join(self.managed_path, METADATA_NAME, "global-metadata.dat")
        self.unity_player_path = None
        self.version = self._get_unity_version_from_data_directory(self.game_data_path)

        if self._has_il2cpp_files():
            self.backend = ScriptingBackend.IL2CPP
        elif self._is_mono(self.managed_path):
            self.backend = ScriptingBackend.MONO
        else:
            self.backend = ScriptingBackend.UNKNOWN

        self._obb_root: str | None = None
        if obb_path:
            self._obb_root = obb_path
            if not file_system.directory.exists(obb_path):
                raise FileNotFoundError(f"Obb directory '{obb_path}' doesn't exist")

            obb_data_path = file_system.path.join(obb_path, _ASSET_NAME, _BIN_NAME, DATA_FOLDER_NAME)
            if not file_system.directory.exists(obb_data_path):
                raise FileNotFoundError(f"Obb data directory '{obb_data_path}' wasn't found")
            data_paths.append(obb_data_path)
        self.data_paths = data_paths

    def collect_files(self, skip_streaming_assets: bool) -> None:
        super().collect_files(skip_streaming_assets)
        self._collect_apk_asset_bundles(self.files)

    @staticmethod
    def is_android_structure(path: str, file_system) -> bool:
        if not file_system.directory.exists(path):
            return False
        match = _get_root_android_directory_match(path, file_system)
        if match <= 8:
            return False
        data_path = file_system.path.join(path, _ASSET_NAME, _BIN_NAME, DATA_FOLDER_NAME)
        return file_system.directory.exists(data_path)

    @staticmethod
    def is_android_obb_structure(path: str, file_system) -> bool:
        if not file_system.directory.exists(path):
            return False
        match = _get_root_android_directory_match(path, file_system)
        if match != 8:
            return False
        data_path = file_system.path.join(path, _ASSET_NAME, _BIN_NAME, DATA_FOLDER_NAME)
        return file_system.directory.exists(data_path)

    def _collect_apk_asset_bundles(self, files: list[tuple[str, str]]) -> None:
        asset_path = self.file_system.path.join(self.root_path, _ASSET_NAME)

        self._collect_asset_bundles(asset_path, files)
        for sub_directory in self.file_system.directory.enumerate_directories(asset_path):
            if self.file_system.path.get_file_name(sub_directory) == _BIN_NAME:
                continue
            self._collect_asset_bundles_recursively(sub_directory, files)

    def _get_il2cpp_game_assembly_path(self, lib_directory: str | None) -> str | None:
        if not lib_directory or not self.file_system.directory.exists(lib_directory):
            return None
        for file in _enumerate_files_recursively(self.file_system, lib_directory):
            if self.file_system.path.get_file_name(file) == _IL2CPP_GAME_ASSEMBLY_NAME:
                return file
        return None

    def _is_mono(self, managed_directory: str | None) -> bool:
        if not managed_directory or not self.file_system.directory.exists(managed_directory):
            return False
        return len(self.file_system.directory.get_files(managed_directory, "*.dll")) > 0


def _get_root_android_directory_match(directory: str, file_system) -> int:
    matches = 0
    for sub_directory in file_system.directory.enumerate_directories(directory):
        name = file_system.path.get_file_name(sub_directory)
        if name == _ASSET_NAME:
            matches |= 8
        elif name == _META_NAME:
            matches |= 4
        elif name == LIB_NAME:
            matches |= 2
    return matches


def _enumerate_files_recursively(file_system, directory: str):
    for file in file_system.directory.enumerate_files(directory):
        yield file
    for sub_directory in file_system.directory.enumerate_directories(directory):
        yield from _enumerate_files_recursively(file_system, sub_directory)

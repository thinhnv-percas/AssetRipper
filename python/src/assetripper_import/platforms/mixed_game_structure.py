"""Port of Source/AssetRipper.Import/Platforms/MixedGameStructure.cs

Fallback platform structure used by PlatformChecker when none of the recognized
platform layouts matches: every remaining path is either a standalone serialized
file/bundle or a directory that gets recursively scanned for such files.
"""
from __future__ import annotations

from collections.abc import Iterable

from assetripper_io_files.streams.multi_file_stream import MultiFileStream

from ..structure.assembly.scripting_backend import ScriptingBackend
from . import webgl_game_structure
from .platform_game_structure import PlatformGameStructure


class MixedGameStructure(PlatformGameStructure):
    def __init__(self, paths: Iterable[str], file_system):
        super().__init__(file_system)

        data_paths: set[str] = set()
        for path in _select_unique_paths(paths):
            if MultiFileStream.exists(path, file_system):
                name = MultiFileStream.get_file_name(path)
                self._add_file(self.files, name, path)
                directory = file_system.path.get_directory_name(path)
                if directory is None:
                    raise ValueError("Could not get directory name")
                data_paths.add(directory)
            elif file_system.directory.exists(path):
                self._collect_from_directory(path, self.files, data_paths)
            else:
                raise FileNotFoundError(f"Neither file nor directory at '{path}' exists")

        self.data_paths = list(data_paths)
        self.name = self.files[0][0] if self.files else ""
        self.game_data_path = None
        self.managed_path = None
        self.unity_player_path = None
        self.version = None
        self.il2cpp_game_assembly_path = None
        self.il2cpp_metadata_path = None
        self.backend = ScriptingBackend.MONO if self.assemblies else ScriptingBackend.UNKNOWN

    def _collect_from_directory(self, root: str, files: list[tuple[str, str]], data_paths: set[str]) -> None:
        count = len(files)
        self._collect_all_serialized_files(root, files)
        self._collect_web_files(root, files)
        self._collect_asset_bundles(root, files)
        self._collect_assemblies(root)
        if len(files) != count:
            data_paths.add(root)

        for sub_directory in self.file_system.directory.enumerate_directories(root):
            self._collect_from_directory(sub_directory, files, data_paths)

    def _collect_web_files(self, root: str, files: list[tuple[str, str]]) -> None:
        for level_file in self.file_system.directory.enumerate_files(root):
            extension = self.file_system.path.get_extension(level_file)
            if extension in (webgl_game_structure.DATA_EXTENSION, webgl_game_structure.DATA_GZ_EXTENSION):
                name = self.file_system.path.get_file_name_without_extension(level_file)
                self._add_file(files, name, level_file)
            elif extension == webgl_game_structure.UNITY_WEB_EXTENSION:
                file_name = self.file_system.path.get_file_name(level_file)
                if file_name.endswith(webgl_game_structure.DATA_WEB_EXTENSION):
                    name = file_name[: -len(webgl_game_structure.DATA_WEB_EXTENSION)]
                    self._add_file(files, name, level_file)


def _select_unique_paths(paths: Iterable[str]) -> list[str]:
    return list(dict.fromkeys(MultiFileStream.get_file_path(path) for path in paths))

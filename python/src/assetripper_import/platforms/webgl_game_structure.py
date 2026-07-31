"""Port of Source/AssetRipper.Import/Platforms/WebGLGameStructure.cs"""
from __future__ import annotations

from ..structure.assembly.scripting_backend import ScriptingBackend
from .platform_game_structure import PlatformGameStructure

_DEVELOPMENT_NAME = "Development"
_RELEASE_NAME = "Release"
_BUILD_NAME = "Build"

_HTML_EXTENSION = ".html"
DATA_EXTENSION = ".data"
DATA_GZ_EXTENSION = ".datagz"
UNITY_WEB_EXTENSION = ".unityweb"
DATA_WEB_EXTENSION = DATA_EXTENSION + UNITY_WEB_EXTENSION


class WebGLGameStructure(PlatformGameStructure):
    def __init__(self, root_path: str, file_system):
        super().__init__(file_system, root_path)

        build_path = file_system.path.join(root_path, _BUILD_NAME)
        if file_system.directory.exists(build_path):
            for file in file_system.directory.enumerate_files(build_path):
                if file.endswith(DATA_WEB_EXTENSION):
                    self.name = file_system.path.get_file_name(file)[: -len(DATA_WEB_EXTENSION)]
                    self.files.append((self.name, file))
                    break
            self.data_paths = [root_path, build_path]
        else:
            development_path = file_system.path.join(root_path, _DEVELOPMENT_NAME)
            if file_system.directory.exists(development_path):
                for file in file_system.directory.enumerate_files(development_path):
                    if file.endswith(DATA_EXTENSION):
                        self.name = file_system.path.get_file_name(file)[: -len(DATA_EXTENSION)]
                        self.files.append((self.name, file))
                        break
                self.data_paths = [root_path, development_path]
            else:
                release_path = file_system.path.join(root_path, _RELEASE_NAME)
                if file_system.directory.exists(release_path):
                    for file in file_system.directory.enumerate_files(release_path):
                        if file.endswith(DATA_GZ_EXTENSION):
                            self.name = file_system.path.get_file_name(file)[: -len(DATA_GZ_EXTENSION)]
                            self.files.append((self.name, file))
                            break
                    self.data_paths = [root_path, release_path]
                else:
                    raise FileNotFoundError("Build directory wasn't found")

        self.name = file_system.path.get_file_name(root_path)
        self.game_data_path = root_path
        self.streaming_assets_path = root_path
        self.resources_path = None
        self.managed_path = None
        self.unity_player_path = None
        self.version = None
        self.il2cpp_game_assembly_path = None
        self.il2cpp_metadata_path = None
        self.backend = ScriptingBackend.UNKNOWN

        if not self.files:
            raise ValueError("No files were found")

    @staticmethod
    def exists(root: str, file_system) -> bool:
        if not file_system.directory.exists(root):
            return False

        for html_file in file_system.directory.enumerate_files(root):
            if not html_file.endswith(_HTML_EXTENSION):
                continue

            for directory in file_system.directory.enumerate_directories(root):
                name = file_system.path.get_file_name(directory)
                if name == _DEVELOPMENT_NAME:
                    for file in file_system.directory.enumerate_files(directory):
                        if file.endswith(DATA_EXTENSION):
                            return True
                elif name == _RELEASE_NAME:
                    for file in file_system.directory.enumerate_files(directory):
                        if file.endswith(DATA_GZ_EXTENSION):
                            return True
                elif name == _BUILD_NAME:
                    for file in file_system.directory.enumerate_files(directory):
                        if file.endswith(DATA_WEB_EXTENSION):
                            return True

            return False
        return False

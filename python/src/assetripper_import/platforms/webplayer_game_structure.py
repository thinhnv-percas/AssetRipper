"""Port of Source/AssetRipper.Import/Platforms/WebPlayerGameStructure.cs"""
from __future__ import annotations

from ..structure.assembly.scripting_backend import ScriptingBackend
from .platform_game_structure import ASSET_BUNDLE_EXTENSION, PlatformGameStructure

_HTML_EXTENSION = ".html"


class WebPlayerGameStructure(PlatformGameStructure):
    def __init__(self, root_path: str, file_system):
        super().__init__(file_system, root_path)

        found, name = _get_web_player_name(self.root_path, file_system)
        if not found:
            raise ValueError("Web player asset bundle data wasn't found")

        self.name = name
        self.game_data_path = None
        self.streaming_assets_path = None
        self.resources_path = None
        self.managed_path = None
        self.unity_player_path = None
        self.il2cpp_game_assembly_path = None
        self.il2cpp_metadata_path = None
        self.version = None
        self.backend = ScriptingBackend.UNKNOWN

        self.data_paths = [self.root_path]

        asset_bundle_path = file_system.path.join(self.root_path, name + ASSET_BUNDLE_EXTENSION)
        self.files.append((name, asset_bundle_path))

    @staticmethod
    def exists(path: str, file_system) -> bool:
        found, _ = _get_web_player_name(path, file_system)
        return file_system.directory.exists(path) and found


def _get_web_player_name(root: str, file_system) -> tuple[bool, str | None]:
    for file in file_system.directory.enumerate_files(root):
        if file_system.path.get_extension(file) == _HTML_EXTENSION:
            name = file_system.path.get_file_name_without_extension(file)
            asset_bundle_path = file_system.path.join(root, name + ASSET_BUNDLE_EXTENSION)
            if file_system.file.exists(asset_bundle_path):
                return True, name
    return False, None

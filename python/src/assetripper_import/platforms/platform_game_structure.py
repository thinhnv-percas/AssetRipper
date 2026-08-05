"""Port of Source/AssetRipper.Import/Structure/Platforms/PlatformGameStructure.cs

The base class every platform-specific game structure (Windows/Linux/Mac/Android/...)
inherits from: standard path fields (GameDataPath/StreamingAssetsPath/ManagedPath/...),
game/bundle file collection, and assembly-directory scanning.

`RequestAssembly`/`CollectMainAssemblies`/`CollectAssemblies` are ported (they only decide
which files *look like* Mono assemblies, via `mono_assembly_predicate.is_mono_assembly`);
actually loading and parsing those assemblies via IL analysis is out of scope for this port.
"""
from __future__ import annotations

import re

from assetripper_io_files.bundle_files import is_bundle_header
from assetripper_io_files.serialized_files.serialized_file import SerializedFile
from assetripper_io_files.streams.multi_file_stream import MultiFileStream
from assetripper_io_files import special_file_names
from assetripper_primitives import UnityVersion

from ..structure.assembly.managers.mono_assembly_predicate import ASSEMBLY_EXTENSION, is_mono_assembly
from ..structure.assembly.scripting_backend import ScriptingBackend

DATA_FOLDER_NAME = "Data"
MANAGED_NAME = "Managed"
LIB_NAME = "lib"
RESOURCES_NAME = "Resources"
UNITY_NAME = "unity"
STREAMING_NAME = "StreamingAssets"
METADATA_NAME = "Metadata"
DEFAULT_UNITY_PLAYER_NAME = "UnityPlayer.dll"
DEFAULT_GAME_ASSEMBLY_NAME = "GameAssembly.dll"
DEFAULT_GLOBAL_METADATA_NAME = "global-metadata.dat"

DATA_NAME = "data"
ASSET_BUNDLE_EXTENSION = ".unity3d"
ALTERNATE_BUNDLE_EXTENSION = ".bundle"
DATA_BUNDLE_NAME = DATA_NAME + ASSET_BUNDLE_EXTENSION
DATA_PACK_BUNDLE_NAME = DATA_NAME + "pack" + ASSET_BUNDLE_EXTENSION
MAIN_DATA_NAME = "mainData"
GLOBAL_GAME_MANAGERS_NAME = "globalgamemanagers"
GLOBAL_GAME_MANAGER_ASSETS_NAME = "globalgamemanagers.assets"
RESOURCES_ASSETS_NAME = "resources.assets"
LEVEL_PREFIX = "level"

_LEVEL_TEMPLATE_RE = re.compile(r"^level(?:0|[1-9][0-9]*)(?:\.split0)?$")
_SHARED_ASSET_TEMPLATE_RE = re.compile(r"^sharedassets[0-9]+\.assets")


class PlatformGameStructure:
    def __init__(self, file_system, root_path: str | None = None):
        self.file_system = file_system
        if root_path is not None:
            if not root_path:
                raise ValueError("root_path must not be empty")
            if not file_system.directory.exists(root_path):
                raise FileNotFoundError(f"Root directory '{root_path}' doesn't exist")
        self.root_path = root_path

        self.name: str | None = None
        self.game_data_path: str | None = None
        self.streaming_assets_path: str | None = None
        self.resources_path: str | None = None
        self.backend: ScriptingBackend = ScriptingBackend.UNKNOWN
        self.managed_path: str | None = None
        self.il2cpp_game_assembly_path: str | None = None
        self.il2cpp_metadata_path: str | None = None
        self.unity_player_path: str | None = None
        self.version: UnityVersion | None = None
        self.data_paths: list[str] = []

        self.files: list[tuple[str, str]] = []
        """(name, full_path) pairs, in insertion order -- matches C#'s List<KeyValuePair>."""
        self.assemblies: dict[str, str] = {}
        """assembly_name -> assembly_path."""

    @staticmethod
    def is_primary_engine_file(file_name: str) -> bool:
        return (
            file_name == MAIN_DATA_NAME
            or file_name == GLOBAL_GAME_MANAGERS_NAME
            or file_name == GLOBAL_GAME_MANAGER_ASSETS_NAME
            or file_name == RESOURCES_ASSETS_NAME
            or bool(_LEVEL_TEMPLATE_RE.match(file_name))
            or bool(_SHARED_ASSET_TEMPLATE_RE.match(file_name))
        )

    def request_dependency(self, dependency: str) -> str | None:
        """Attempts to find the path for the dependency with that name."""
        for name, path in self.files:
            if name == dependency:
                return path

        for data_path in self.data_paths:
            file_path = self.file_system.path.join(data_path, dependency)
            if MultiFileStream.exists(file_path, self.file_system):
                return file_path

            if special_file_names.is_default_resource(dependency):
                return self._find_engine_dependency(
                    data_path, special_file_names.DEFAULT_RESOURCE_NAME_1
                ) or self._find_engine_dependency(data_path, special_file_names.DEFAULT_RESOURCE_NAME_2)
            elif special_file_names.is_builtin_extra(dependency):
                return self._find_engine_dependency(
                    data_path, special_file_names.BUILTIN_EXTRA_NAME_1
                ) or self._find_engine_dependency(data_path, special_file_names.BUILTIN_EXTRA_NAME_2)
        return None

    def request_assembly(self, assembly: str) -> str | None:
        return self.assemblies.get(f"{assembly}{ASSEMBLY_EXTENSION}")

    def request_resource(self, resource: str) -> str | None:
        for data_path in self.data_paths:
            path = self.file_system.path.join(data_path, resource)
            if MultiFileStream.exists(path, self.file_system):
                return path
        return None

    def collect_files(self, skip_streaming_assets: bool) -> None:
        from .mixed_game_structure import MixedGameStructure

        if isinstance(self, MixedGameStructure):
            return

        for data_path in self.data_paths:
            self._collect_game_files(data_path, self.files)
        self._collect_main_assemblies()
        if not skip_streaming_assets:
            self._collect_streaming_assets()

    def _collect_game_files(self, root: str, files: list[tuple[str, str]]) -> None:
        self._collect_compressed_game_files(root, files)
        self._collect_default_serialized_files(root, files)

    def _collect_compressed_game_files(self, root: str, files: list[tuple[str, str]]) -> None:
        """Finds data.unity3d and datapack.unity3d when LZ4 compressed.

        Per comments in Unity's own source (PlatformDependent/AndroidPlayer/Source/
        ApkFile.cpp:268), the datapack asset is only present if Gradle built an AAB with a
        Unity data asset pack inside and bundletool then converted the AAB into a
        universal APK.
        """
        data_bundle_path = self.file_system.path.join(root, DATA_BUNDLE_NAME)
        if MultiFileStream.exists(data_bundle_path, self.file_system):
            self._add_asset_bundle(files, DATA_BUNDLE_NAME, data_bundle_path)

        data_pack_bundle_path = self.file_system.path.join(root, DATA_PACK_BUNDLE_NAME)
        if MultiFileStream.exists(data_pack_bundle_path, self.file_system):
            self._add_asset_bundle(files, DATA_PACK_BUNDLE_NAME, data_pack_bundle_path)

    def _collect_default_serialized_files(self, root: str, files: list[tuple[str, str]]) -> None:
        """Collects globalgamemanagers and all the level files (selected by file name,
        using a regex for level files)."""
        file_path = self.file_system.path.join(root, GLOBAL_GAME_MANAGERS_NAME)
        if MultiFileStream.exists(file_path, self.file_system):
            self._add_file(files, GLOBAL_GAME_MANAGERS_NAME, file_path)
        else:
            file_path = self.file_system.path.join(root, MAIN_DATA_NAME)
            if MultiFileStream.exists(file_path, self.file_system):
                self._add_file(files, MAIN_DATA_NAME, file_path)

        for level_file in self.file_system.directory.enumerate_files(root):
            name = self.file_system.path.get_file_name(level_file)
            if _LEVEL_TEMPLATE_RE.match(name):
                level_name = MultiFileStream.get_file_name(name)
                self._add_file(files, level_name, level_file)

    def _collect_all_serialized_files(self, root: str, files: list[tuple[str, str]]) -> None:
        """Collects all serialized files in the directory (top-level only, selected by
        file header)."""
        for path in self.file_system.directory.enumerate_files(root):
            if SerializedFile.is_serialized_file_path(path, self.file_system):
                name = self.file_system.path.get_file_name(path)
                actual_name = MultiFileStream.get_file_name(name)
                self._add_file(files, actual_name, path)

    def _collect_streaming_assets(self) -> None:
        if not self.streaming_assets_path:
            return
        if self.file_system.directory.exists(self.streaming_assets_path):
            self._collect_asset_bundles_recursively(self.streaming_assets_path, self.files)

    def _collect_asset_bundles(self, root: str, files: list[tuple[str, str]]) -> None:
        """Collect asset bundles only from this directory."""
        for file in self.file_system.directory.enumerate_files(root):
            if is_bundle_header(file, self.file_system):
                name = self.file_system.path.get_file_name_without_extension(file).lower()
                self._add_asset_bundle(files, name, file)

    def _collect_asset_bundles_recursively(self, root: str, files: list[tuple[str, str]]) -> None:
        """Collect asset bundles from this directory and all subdirectories."""
        self._collect_asset_bundles(root, files)
        for directory in self.file_system.directory.enumerate_directories(root):
            self._collect_asset_bundles_recursively(directory, files)

    def _collect_assemblies(self, root: str) -> None:
        for file in self.file_system.directory.enumerate_files(root):
            name = self.file_system.path.get_file_name(file)
            if is_mono_assembly(name):
                if name not in self.assemblies:
                    self.assemblies[name] = file

    def _collect_main_assemblies(self) -> None:
        if self.backend != ScriptingBackend.MONO:
            return  # Only needed for Mono
        elif self.managed_path and self.file_system.directory.exists(self.managed_path):
            self._collect_assemblies(self.managed_path)
        elif self.game_data_path:
            lib_path = self.file_system.path.join(self.file_system.path.get_full_path(self.game_data_path), LIB_NAME)
            if self.file_system.directory.exists(lib_path):
                self._collect_assemblies(self.game_data_path)
                self._collect_assemblies(lib_path)

    def _find_engine_dependency(self, path: str, dependency: str) -> str | None:
        file_path = self.file_system.path.join(path, dependency)
        if self.file_system.file.exists(file_path):
            return file_path

        resource_path = self.file_system.path.join(path, RESOURCES_NAME)
        file_path = self.file_system.path.join(resource_path, dependency)
        if self.file_system.file.exists(file_path):
            return file_path

        # Really old versions contain the file in this directory.
        unity_path = self.file_system.path.join(path, UNITY_NAME)
        file_path = self.file_system.path.join(unity_path, dependency)
        if self.file_system.file.exists(file_path):
            return file_path
        return None

    @staticmethod
    def _add_file(files: list[tuple[str, str]], name: str, path: str) -> None:
        files.append((name, path))

    @staticmethod
    def _add_asset_bundle(files: list[tuple[str, str]], name: str, path: str) -> None:
        files.append((name, path))

    def _get_unity_version_from_serialized_file(self, file_path: str) -> UnityVersion:
        return SerializedFile.from_file(file_path, self.file_system).version

    def _get_unity_version_from_bundle_file(self, file_path: str) -> UnityVersion:
        from assetripper_io_files.bundle_files.file_stream.file_stream_bundle_header import FileStreamBundleHeader

        with self.file_system.file.open_read(file_path) as stream:
            header = FileStreamBundleHeader()
            header.read_from_stream(stream)
        return UnityVersion.parse(header.unity_web_minimum_revision)

    def _get_unity_version_from_data_directory(self, data_directory_path: str) -> UnityVersion | None:
        global_game_managers_path = self.file_system.path.join(data_directory_path, GLOBAL_GAME_MANAGERS_NAME)
        if self.file_system.file.exists(global_game_managers_path):
            return self._get_unity_version_from_serialized_file(global_game_managers_path)
        data_bundle_path = self.file_system.path.join(data_directory_path, DATA_BUNDLE_NAME)
        if self.file_system.file.exists(data_bundle_path):
            return self._get_unity_version_from_bundle_file(data_bundle_path)
        return None

    def _has_mono_assemblies(self, managed_directory: str | None) -> bool:
        if not managed_directory or not self.file_system.directory.exists(managed_directory):
            return False
        return len(self.file_system.directory.get_files(managed_directory, "*.dll")) > 0

    def _has_il2cpp_files(self) -> bool:
        return bool(
            self.il2cpp_game_assembly_path
            and self.il2cpp_metadata_path
            and self.file_system.file.exists(self.il2cpp_game_assembly_path)
            and self.file_system.file.exists(self.il2cpp_metadata_path)
        )

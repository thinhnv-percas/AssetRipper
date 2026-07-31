"""
Port of Source/AssetRipper.Assets/Bundles/GameBundle.cs + GameBundle.FromPaths.cs

A Bundle encompassing an entire game.

`from_paths` skips the C# `while (file is CompressedFile compressedFile)` unwrap loop:
gzip/Brotli-compressed files (`CompressedFile`) aren't ported in this port, so
`scheme_reader.load_file` can never produce one -- the loop would be unreachable.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .bundle import Bundle


class GameBundle(Bundle):
    def __init__(self):
        super().__init__()
        self.resource_provider = None

    @staticmethod
    def from_paths(paths, asset_factory, file_system, initializer=None) -> "GameBundle":
        game_bundle = GameBundle()
        if initializer is not None:
            initializer.on_created(game_bundle, asset_factory)
        game_bundle._initialize_from_paths(paths, asset_factory, file_system, initializer)
        if initializer is not None:
            initializer.on_paths_loaded(game_bundle, asset_factory)
        game_bundle.initialize_all_dependency_lists(initializer.dependency_provider if initializer is not None else None)
        if initializer is not None:
            initializer.on_dependencies_initialized(game_bundle, asset_factory)
        return game_bundle

    def _initialize_from_paths(self, paths, asset_factory, file_system, initializer) -> None:
        from assetripper_io_files.failed_file import FailedFile
        from assetripper_io_files.file_container import FileContainer
        from assetripper_io_files.resource_files.resource_file import ResourceFile
        from assetripper_io_files.serialized_files.serialized_file import SerializedFile

        from .serialized_bundle import SerializedBundle

        self.resource_provider = initializer.resource_provider if initializer is not None else None
        dependency_provider = initializer.dependency_provider if initializer is not None else None
        file_stack = _load_files_and_dependencies(paths, file_system, dependency_provider)
        default_version = initializer.default_version if initializer is not None else UnityVersion()

        while file_stack:
            file = file_stack.pop()
            if isinstance(file, SerializedFile):
                self.add_collection_from_serialized_file(file, asset_factory, default_version)
            elif isinstance(file, FileContainer):
                serialized_bundle = SerializedBundle.from_file_container(file, asset_factory, default_version)
                self.add_bundle(serialized_bundle)
            elif isinstance(file, ResourceFile):
                self.add_resource(file)
            elif isinstance(file, FailedFile):
                self.add_failed(file)

    @property
    def name(self) -> str:
        return "GameBundle"

    def _is_compatible_bundle(self, bundle: Bundle) -> bool:
        return not isinstance(bundle, GameBundle)

    def _resolve_external_resource(self, original_name: str):
        if self.resource_provider is not None:
            resource_file = self.resource_provider.find_resource(original_name)
            if resource_file is not None:
                self.add_resource(resource_file)
            return resource_file
        return super()._resolve_external_resource(original_name)

    def initialize_all_dependency_lists(self, dependency_provider=None) -> None:
        super().initialize_all_dependency_lists(dependency_provider)

    def has_any_asset_collections(self) -> bool:
        return any(True for _ in self.fetch_asset_collections())

    def add_new_processed_collection(self, name: str, version: UnityVersion):
        from assetripper_assets.collections.processed_asset_collection import ProcessedAssetCollection

        processed_collection = ProcessedAssetCollection(self)
        processed_collection.name = name
        processed_collection.set_layout(version)
        return processed_collection

    def add_new_processed_bundle(self, name: str | None = None):
        from .processed_bundle import ProcessedBundle

        processed_bundle = ProcessedBundle(name)
        self.add_bundle(processed_bundle)
        return processed_bundle

    def get_max_unity_version(self) -> UnityVersion:
        versions = [c.version for c in self.fetch_asset_collections()]
        versions.append(UnityVersion.MIN_VERSION)
        return max(versions)


def _load_files_and_dependencies(paths, file_system, dependency_provider) -> list:
    from assetripper_io_files import scheme_reader
    from assetripper_io_files.failed_file import FailedFile
    from assetripper_io_files.file_container import FileContainer
    from assetripper_io_files.resource_files.resource_file import ResourceFile
    from assetripper_io_files.serialized_files.serialized_file import SerializedFile

    files: list = []
    serialized_file_names: set[str] = set()  # Includes missing dependencies

    for path in paths:
        try:
            file = scheme_reader.load_file(path, file_system)
            file.read_contents_recursively()
        except Exception as ex:  # noqa: BLE001 -- mirrors C#'s catch (Exception ex)
            file = FailedFile()
            file.name = file_system.path.get_file_name(path)
            file.file_path = path
            file.stack_trace = str(ex)

        if isinstance(file, (ResourceFile, FailedFile)):
            files.append(file)
        elif isinstance(file, SerializedFile):
            files.append(file)
            serialized_file_names.add(file.name_fixed)
        elif isinstance(file, FileContainer):
            files.append(file)
            for serialized_file_in_container in file.fetch_serialized_files():
                serialized_file_names.add(serialized_file_in_container.name_fixed)

    index = 0
    while index < len(files):
        file = files[index]
        if isinstance(file, SerializedFile):
            _load_dependencies(file, files, serialized_file_names, dependency_provider)
        elif isinstance(file, FileContainer):
            for serialized_file_in_container in file.fetch_serialized_files():
                _load_dependencies(serialized_file_in_container, files, serialized_file_names, dependency_provider)
        index += 1

    return files


def _load_dependencies(serialized_file, files: list, serialized_file_names: set[str], dependency_provider) -> None:
    for file_identifier in serialized_file.dependencies:
        name = file_identifier.get_file_path()
        if name not in serialized_file_names:
            serialized_file_names.add(name)
            if dependency_provider is not None:
                dependency = dependency_provider.find_dependency(file_identifier)
                if dependency is not None:
                    files.append(dependency)

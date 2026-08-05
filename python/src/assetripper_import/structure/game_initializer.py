"""Port of Source/AssetRipper.Import/Structure/GameInitializer.cs
(+ .CustomResourceProvider.cs, .StructureDependencyProvider.cs partials)

`on_paths_loaded`/`on_dependencies_initialized` are intentionally no-ops here, unlike
upstream:
- Upstream's `on_paths_loaded` calls `EngineResourceInjector.InjectEngineFilesIfNecessary`,
  which relies on the `type_tree.tpk` database to synthesize missing engine resources
  (Resources/unity_builtin_extra, etc). That database isn't available in this port (see
  the project plan's "Out of scope" table), so there is nothing to inject.
- Upstream's `on_dependencies_initialized` calls `VersionChanger.ChangeVersions` to retarget
  every collection to `TargetVersion`. This is an advanced/optional feature, deferred along
  with the rest of the processors.
"""
from __future__ import annotations

import logging

from assetripper_assets.bundles.default_game_initializer import DefaultGameInitializer
from assetripper_assets.bundles.i_dependency_provider import IDependencyProvider
from assetripper_assets.bundles.i_resource_provider import IResourceProvider
from assetripper_io_files import scheme_reader, special_file_names
from assetripper_io_files.resource_files.resource_file import ResourceFile
from assetripper_primitives import UnityVersion

_logger = logging.getLogger(__name__)


class StructureDependencyProvider(IDependencyProvider):
    def __init__(self, platform_structure, mixed_structure, file_system):
        self.platform_structure = platform_structure
        self.mixed_structure = mixed_structure
        self.file_system = file_system

    def find_dependency(self, identifier):
        system_file_path = self._request_dependency(identifier.path_name)
        if system_file_path is None:
            return None
        return scheme_reader.load_file(system_file_path, self.file_system)

    def _request_dependency(self, dependency: str) -> str | None:
        if self.platform_structure is not None:
            path = self.platform_structure.request_dependency(dependency)
            if path is not None:
                return path
        if self.mixed_structure is not None:
            return self.mixed_structure.request_dependency(dependency)
        return None

    def report_missing_dependency(self, identifier) -> None:
        _logger.warning("Dependency '%s' wasn't found", identifier)


class CustomResourceProvider(IResourceProvider):
    def __init__(self, platform_structure, mixed_structure, file_system):
        self.platform_structure = platform_structure
        self.mixed_structure = mixed_structure
        self.file_system = file_system

    def find_resource(self, res_name: str):
        fixed_name = special_file_names.fix_resource_path(res_name)
        res_path = self._request_resource(fixed_name)
        if res_path is None:
            _logger.warning("Resource file '%s' hasn't been found", res_name)
            return None

        resource_file = ResourceFile.from_path(res_path, fixed_name, self.file_system)
        _logger.info("Resource file '%s' has been loaded", res_name)
        return resource_file

    def _request_resource(self, resource: str) -> str | None:
        if self.platform_structure is not None:
            path = self.platform_structure.request_resource(resource)
            if path is not None:
                return path
        if self.mixed_structure is not None:
            return self.mixed_structure.request_resource(resource)
        return None


class GameInitializer(DefaultGameInitializer):
    def __init__(self, platform_structure, mixed_structure, file_system, default_version: UnityVersion, target_version: UnityVersion):
        super().__init__(
            dependency_provider=StructureDependencyProvider(platform_structure, mixed_structure, file_system),
            resource_provider=CustomResourceProvider(platform_structure, mixed_structure, file_system),
            default_version=default_version,
        )
        self.target_version = target_version

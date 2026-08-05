"""Port of Source/AssetRipper.Export.UnityProjects/Project/PackageManifestPostExporter.cs"""
from __future__ import annotations

from ..i_post_exporter import IPostExporter
from .package_manifest import create_default_manifest, save_manifest


class PackageManifestPostExporter(IPostExporter):
    def do_post_export(self, game_data, output_directory: str, unity_version, file_system, settings=None) -> None:
        packages_directory = file_system.path.join(output_directory, "Packages")
        file_system.directory.create(packages_directory)
        path = file_system.path.join(packages_directory, "manifest.json")
        with file_system.file.create(path) as stream:
            save_manifest(create_default_manifest(unity_version), stream)

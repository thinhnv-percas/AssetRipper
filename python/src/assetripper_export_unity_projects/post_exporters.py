"""Port of the `IPostExporter` pipeline `ExportHandler.GetPostExporters()` wires up
(Source/AssetRipper.Export.UnityProjects/ExportHandler.cs:133-140), run after the main
asset export finishes.

Not ported: `PathIdMapExporter` -- a diagnostic dump of every asset's export ID, not
project scaffolding a Unity Editor needs to open the exported project (out of the scope
the plan set for this phase).
"""
from __future__ import annotations

from assetripper_export_modules.scripts.dll_post_exporter import DllPostExporter

from .project.package_manifest_post_exporter import PackageManifestPostExporter
from .project.project_version_post_exporter import ProjectVersionPostExporter
from .project.streaming_assets_post_exporter import StreamingAssetsPostExporter

DEFAULT_POST_EXPORTERS = (
    ProjectVersionPostExporter(),
    PackageManifestPostExporter(),
    StreamingAssetsPostExporter(),
    DllPostExporter(),
)


def run_default_post_exporters(game_data, output_directory: str, unity_version, file_system) -> None:
    for post_exporter in DEFAULT_POST_EXPORTERS:
        post_exporter.do_post_export(game_data, output_directory, unity_version, file_system)

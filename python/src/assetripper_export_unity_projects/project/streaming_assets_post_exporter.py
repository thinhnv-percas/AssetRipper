"""Port of Source/AssetRipper.Export.UnityProjects/Project/StreamingAssetsPostExporter.cs

Copies the platform's StreamingAssets directory (if any) into the exported project's
Assets/StreamingAssets -- these files aren't inside any SerializedFile/bundle, so nothing
else in the pipeline would otherwise carry them over.

Upstream enumerates with `SearchOption.AllDirectories` (recursive); this port's
`FileSystem.directory.enumerate_directories/enumerate_files` are single-level only (see
their `LocalFileSystem` implementation), so `_walk` recurses manually to match.
"""
from __future__ import annotations

from assetripper_export_configuration.streaming_assets_mode import StreamingAssetsMode

from ..i_post_exporter import IPostExporter


def _walk(directory_impl, root: str, path_join):
    """Yields every directory and file beneath `root`, matching AllDirectories order:
    all files directly in a directory before descending into its subdirectories."""
    subdirectories = list(directory_impl.enumerate_directories(root, "*"))
    for file in directory_impl.enumerate_files(root, "*"):
        yield "file", file
    for subdirectory in subdirectories:
        yield "directory", subdirectory
        yield from _walk(directory_impl, subdirectory, path_join)


class StreamingAssetsPostExporter(IPostExporter):
    def do_post_export(self, game_data, output_directory: str, unity_version, file_system, settings=None) -> None:
        if settings is not None and settings.import_settings.streaming_assets_mode == StreamingAssetsMode.IGNORE:
            return

        platform = game_data.platform_structure
        if platform is None:
            return

        input_directory = getattr(platform, "streaming_assets_path", None)
        if not input_directory or not platform.file_system.directory.exists(input_directory):
            return

        output_streaming_assets = file_system.path.join(output_directory, "Assets", "StreamingAssets")
        file_system.directory.create(output_streaming_assets)

        for kind, entry in _walk(platform.file_system.directory, input_directory, platform.file_system.path.join):
            relative_path = platform.file_system.path.get_relative_path(input_directory, entry)
            destination = file_system.path.join(output_streaming_assets, relative_path)
            if kind == "directory":
                file_system.directory.create(destination)
            else:
                data = platform.file_system.file.read_all_bytes(entry)
                file_system.file.write_all_bytes(destination, data)

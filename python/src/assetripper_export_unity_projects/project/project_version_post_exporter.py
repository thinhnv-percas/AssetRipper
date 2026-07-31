"""Port of Source/AssetRipper.Export.UnityProjects/Project/ProjectVersionPostExporter.cs

Writes ProjectSettings/ProjectVersion.txt -- the file the Unity Editor reads to decide
(and warn about) which version to reopen an exported project with.
"""
from __future__ import annotations

from .._text_writer import Utf8TextWriter
from ..i_post_exporter import IPostExporter


class ProjectVersionPostExporter(IPostExporter):
    def do_post_export(self, game_data, output_directory: str, unity_version, file_system) -> None:
        project_settings_path = file_system.path.join(output_directory, "ProjectSettings")
        file_system.directory.create(project_settings_path)
        file_path = file_system.path.join(project_settings_path, "ProjectVersion.txt")
        with file_system.file.create(file_path) as stream:
            writer = Utf8TextWriter(stream)
            writer.write(f"m_EditorVersion: {unity_version}\n")
            if unity_version.equals(5):
                # Unity 5 has an extra line; always zero, even on beta versions.
                writer.write("m_StandardAssetsVersion: 0\n")

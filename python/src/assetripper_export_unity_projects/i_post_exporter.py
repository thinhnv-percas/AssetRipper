"""Port of Source/AssetRipper.Export.UnityProjects/IPostExporter.cs

Scoped down: upstream's `FullConfiguration settings` becomes plain `output_directory` +
`unity_version` parameters, matching how project_exporter.py already replaced the settings
object with direct arguments (see its module docstring). The optional `settings` parameter
(Phase 10) is a narrower addition on top of that -- it carries only the small set of
behavior flags (e.g. `StreamingAssetsMode`) that a post-exporter actually branches on;
`output_directory`/`unity_version` stay as their own arguments rather than being folded
back into `settings.ProjectSettingsPath`/`settings.Version` as upstream has it.
"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IPostExporter(ABC):
    @abstractmethod
    def do_post_export(
        self, game_data, output_directory: str, unity_version, file_system, settings=None
    ) -> None: ...

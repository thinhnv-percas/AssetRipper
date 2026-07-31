"""Port of Source/AssetRipper.Export.UnityProjects/IPostExporter.cs

Scoped down: upstream's `FullConfiguration settings` becomes plain `output_directory` +
`unity_version` parameters, matching how project_exporter.py already replaced the settings
object with direct arguments (see its module docstring).
"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IPostExporter(ABC):
    @abstractmethod
    def do_post_export(self, game_data, output_directory: str, unity_version, file_system) -> None: ...

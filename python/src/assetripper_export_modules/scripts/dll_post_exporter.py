"""Port of Source/AssetRipper.Export.UnityProjects/Scripts/DllPostExporter.cs

Upstream saves each assembly `IAssemblyManager.GetAssemblies()` knows about to
AuxiliaryFiles/GameAssemblies/. This port's assembly manager is always `None` (see
assetripper_import/structure/game_structure.py's module docstring -- no IL-based script
support is implemented), so there are never any assemblies to save; this is a documented
no-op kept only so the post-exporter pipeline shape matches upstream's.
"""
from __future__ import annotations

from assetripper_export_unity_projects.i_post_exporter import IPostExporter


class DllPostExporter(IPostExporter):
    def do_post_export(self, game_data, output_directory: str, unity_version, file_system) -> None:
        if game_data.assembly_manager is None:
            return
        raise NotImplementedError("Assembly saving is not implemented in this port.")

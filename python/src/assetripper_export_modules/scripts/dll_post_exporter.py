"""Port of Source/AssetRipper.Export.UnityProjects/Scripts/DllPostExporter.cs

Upstream saves each assembly `IAssemblyManager.GetAssemblies()` knows about to
AuxiliaryFiles/GameAssemblies/. Since Phase 16f, `game_data.assembly_manager` can be a real
`MonoAssemblyManager` (previously always `None` -- see
assetripper_import/structure/game_structure.py's module docstring), so this is no longer a
guaranteed no-op: `MonoAssemblyManager.get_assembly_file_paths()` exposes exactly the
name->path map needed to copy each `.dll` over, unchanged, from wherever it was discovered.
"""
from __future__ import annotations

from assetripper_export_unity_projects.i_post_exporter import IPostExporter

_AUXILIARY_FILES_DIRECTORY = "AuxiliaryFiles"
_GAME_ASSEMBLIES_DIRECTORY = "GameAssemblies"


class DllPostExporter(IPostExporter):
    def do_post_export(self, game_data, output_directory: str, unity_version, file_system, settings=None) -> None:
        if game_data.assembly_manager is None:
            return
        assembly_paths = game_data.assembly_manager.get_assembly_file_paths()
        if not assembly_paths:
            return

        target_directory = file_system.path.join(output_directory, _AUXILIARY_FILES_DIRECTORY, _GAME_ASSEMBLIES_DIRECTORY)
        file_system.directory.create(target_directory)
        for name, path in assembly_paths.items():
            data = file_system.file.read_all_bytes(path)
            file_system.file.write_all_bytes(file_system.path.join(target_directory, name), data)

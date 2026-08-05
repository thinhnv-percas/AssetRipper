"""Port of Source/AssetRipper.Export.UnityProjects/Project/ManagerExportCollection.cs

Exports a single Global Game Manager singleton (see manager_asset_exporter.py) to
`ProjectSettings/<Name>.asset` instead of `Assets/<ClassName>/<BestName>.asset`, and --
unlike `AssetExportCollection` -- writes no `.meta` file: real Unity projects never have one
for anything under `ProjectSettings/`. `get_export_id` is hard-coded to `1` (upstream's own
convention, matched by every real Unity `ProjectSettings/*.asset` file), and
`create_export_pointer` is intentionally unsupported, exactly like upstream -- nothing in
this port resolves cross-references into these files by pointer either.
"""
from __future__ import annotations

from ..asset_export_collection import AssetExportCollection

_PROJECT_SETTINGS_DIR = "ProjectSettings"

# Type-name renames upstream applies so files land under the names real Unity actually uses.
_PLAYER_SETTINGS_NAME = "PlayerSettings"
_NAV_MESH_PROJECT_SETTINGS_NAME = "NavMeshProjectSettings"
_PHYSICS_MANAGER_NAME = "PhysicsManager"

_PROJECT_SETTINGS_NAME = "ProjectSettings"
_NAV_MESH_AREAS_NAME = "NavMeshAreas"
_DYNAMICS_MANAGER_NAME = "DynamicsManager"


def _get_correct_name(type_name: str) -> str:
    # "129" is upstream's fallback for a stripped type tree whose ClassName is just the
    # numeric class ID -- PlayerSettings' class ID has no named ClassIDType entry to compare
    # against instead (see class_id_type.py's docstring on abstract classes being removed).
    if type_name in (_PLAYER_SETTINGS_NAME, "129"):
        return _PROJECT_SETTINGS_NAME
    if type_name == _NAV_MESH_PROJECT_SETTINGS_NAME:
        return _NAV_MESH_AREAS_NAME
    if type_name == _PHYSICS_MANAGER_NAME:
        return _DYNAMICS_MANAGER_NAME
    return type_name


class ManagerExportCollection(AssetExportCollection):
    def export(self, container, project_directory: str, file_system) -> bool:
        sub_path = file_system.path.join(project_directory, _PROJECT_SETTINGS_DIR)
        name = _get_correct_name(self.asset.class_name)
        file_path = file_system.path.join(sub_path, f"{name}.asset")

        file_system.directory.create(sub_path)
        return self._export_inner(container, file_path, project_directory, file_system)

    def get_export_id(self, container, asset) -> int:
        if asset.asset_info == self.asset.asset_info:
            return 1
        raise ValueError(f"{asset} is not part of this collection")

    def create_export_pointer(self, container, asset, is_local: bool):
        raise NotImplementedError(
            "ManagerExportCollection does not support export pointers (matches upstream)"
        )

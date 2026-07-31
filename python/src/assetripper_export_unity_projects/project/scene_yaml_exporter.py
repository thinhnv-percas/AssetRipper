"""Port of Source/AssetRipper.Export.UnityProjects/Project/SceneYamlExporter.cs

Registered on `UnityObjectBase` with `allow_inheritance=True` (see project_exporter.py's
`__init__`), tried *before* `DefaultYamlExporter` -- for every asset whose `main_asset` was
stamped by `GameObjectHierarchyObject.set_main_asset()` (a `SceneHierarchyObject` or
`PrefabHierarchyObject`), this builds the matching multi-asset export collection instead of
DefaultYamlExporter's one-asset-per-file default; everything else declines and falls
through. Dispatch is on `asset.main_asset`'s Python type, not class ID -- `PrefabHierarchyObject`
deliberately reuses the real `PrefabInstance` class ID (see that module's docstring), so
class-ID-keyed dispatch can't tell them apart, matching why upstream itself dispatches on
`asset.MainAsset` rather than `asset.ClassID` here too.
"""
from __future__ import annotations

from assetripper_processing.prefabs.prefab_hierarchy_object import PrefabHierarchyObject
from assetripper_processing.prefabs.scene_hierarchy_object import SceneHierarchyObject

from ..i_asset_exporter import IAssetExporter
from .prefab_export_collection import PrefabExportCollection
from .scene_export_collection import SceneExportCollection


class SceneYamlExporter(IAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        main_asset = asset.main_asset
        if isinstance(main_asset, SceneHierarchyObject):
            return True, SceneExportCollection(self, main_asset)
        if isinstance(main_asset, PrefabHierarchyObject):
            return True, PrefabExportCollection(self, main_asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        from ..asset_exporter import export_asset

        return export_asset(container, asset, path, file_system)

    def to_export_type(self, asset):
        from assetripper_io_files.asset_type import AssetType

        return AssetType.SERIALIZED

    def to_unknown_export_type(self, type_: type) -> "tuple[bool, object]":
        from assetripper_io_files.asset_type import AssetType

        return True, AssetType.SERIALIZED

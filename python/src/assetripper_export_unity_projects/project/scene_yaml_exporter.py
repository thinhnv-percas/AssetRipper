"""Port of Source/AssetRipper.Export.UnityProjects/Project/SceneYamlExporter.cs, broadened to
also cover Source/AssetRipper.Export.UnityProjects/Project/ScriptableObjectGroupExporter.cs
(Phase 13h) -- upstream keeps these as two separate exporter classes registered for different
generated types (`IPrefabInstance`/`IGameObject`/`IComponent`/`ILevelGameManager` vs.
`IMonoBehaviour`/`ScriptableObjectGroup`), but both do the exact same thing: build a
multi-asset-per-file collection for whichever grouping marker stamped `asset.main_asset`.
Since this port already dispatches every such marker by `asset.main_asset`'s Python type
(class-ID-keyed dispatch can't tell `PrefabHierarchyObject` apart from a real PrefabInstance --
see that module's docstring), one exporter checking all three marker types is the same
behavior upstream gets from two, without a redundant second class.

Registered on `UnityObjectBase` with `allow_inheritance=True` (see project_exporter.py's
`__init__`), tried *before* `DefaultYamlExporter` -- for every asset whose `main_asset` was
stamped by `GameObjectHierarchyObject.set_main_asset()`/`ScriptableObjectGroup.set_main_asset()`
(a `SceneHierarchyObject`, `PrefabHierarchyObject`, or `ScriptableObjectGroup`), this builds the
matching multi-asset export collection instead of DefaultYamlExporter's one-asset-per-file
default; everything else declines and falls through.
"""
from __future__ import annotations

from assetripper_processing.prefabs.prefab_hierarchy_object import PrefabHierarchyObject
from assetripper_processing.prefabs.scene_hierarchy_object import SceneHierarchyObject
from assetripper_processing.scriptable_object.scriptable_object_group import ScriptableObjectGroup

from ..i_asset_exporter import IAssetExporter
from .prefab_export_collection import PrefabExportCollection
from .scene_export_collection import SceneExportCollection
from .scriptable_object_group_export_collection import ScriptableObjectGroupExportCollection


class SceneYamlExporter(IAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        main_asset = asset.main_asset
        if isinstance(main_asset, SceneHierarchyObject):
            return True, SceneExportCollection(self, main_asset)
        if isinstance(main_asset, PrefabHierarchyObject):
            return True, PrefabExportCollection(self, main_asset)
        if isinstance(main_asset, ScriptableObjectGroup):
            return True, ScriptableObjectGroupExportCollection(self, main_asset)
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

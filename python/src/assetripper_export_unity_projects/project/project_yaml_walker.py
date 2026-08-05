"""Port of Source/AssetRipper.Export.UnityProjects/Project/ProjectYamlWalker.cs

The real, container-aware YamlWalker: resolves PPtrs to actual export pointers instead of
YamlWalker's raw m_FileID/m_PathID/m_TargetClassID fallback.

Not ported: the `SceneObjectIdentifier` special case in `EnterAsset` (Source/.../Subclasses/
SceneObjectIdentifier -- a generated class for `[fileID, guid]`-based scene object stripping
support). Out of scope until Phase 5 provides real scene/prefab processing to produce one.
"""
from __future__ import annotations

from assetripper_assets.null_object import NullObject
from assetripper_io_files.asset_type import AssetType

from ..meta_ptr import create_missing_reference
from ..yaml_walker import YamlWalker


class ProjectYamlWalker(YamlWalker):
    def __init__(self, container):
        super().__init__()
        self.container = container
        self.with_unity_version(container.export_version)
        self.current_asset = None

    def export_yaml_document(self, asset, export_id: int | None = None):
        self.current_asset = asset
        if export_id is None:
            export_id = self.container.get_export_id(asset)
        return super().export_yaml_document(asset, export_id)

    def export_yaml_node(self, asset):
        self.current_asset = asset
        return super().export_yaml_node(asset)

    def create_yaml_node_for_pptr(self, pptr):
        if pptr.path_id == 0:
            from ..meta_ptr import NULL_PTR

            return NULL_PTR.export_yaml(self.container.export_version)

        # cls=NullObject: every asset this port produces (TypeTreeObject, UnknownObject,
        # UnreadableObject, ...) derives from NullObject, which AssetCollection.get_asset
        # otherwise filters out by design (see assetripper_assets/null_object.py). Without
        # this, no PPtr in this port could ever resolve.
        asset = self.current_asset.collection.get_asset_by_pptr(pptr, NullObject)
        if asset is not None:
            return self.container.create_export_pointer(asset).export_yaml(self.container.export_version)

        # Unlike upstream, the target class ID is unknowable here (see yaml_walker.py's
        # module docstring) -- a broken reference exports as class ID 0 (Object).
        pointer = create_missing_reference(0, AssetType.SERIALIZED)
        return pointer.export_yaml(self.container.export_version)

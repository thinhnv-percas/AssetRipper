"""Port of Source/AssetRipper.Export.UnityProjects/Textures/YamlSpriteExporter.cs (Phase 13b)

Sprite (213) exports as a plain `.asset` YAML -- the same generic path `DefaultYamlExporter`
already produces, just explicitly registered here so 13c (SpriteProcessor, atlas coordinate
recovery -- not yet ported) has a stable place to hook the corrected `m_RD` once that
exists. SpriteAtlas (687078895) is skipped entirely via `EmptyExportCollection` (Phase 15):
exporting it as a generic `.asset` would make the Unity Editor try to re-pack an
already-packed atlas, exactly the reason upstream skips it too.
"""
from __future__ import annotations

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection
from assetripper_export_unity_projects.empty_export_collection import INSTANCE as _EMPTY_EXPORT_COLLECTION
from assetripper_export_unity_projects.project.yaml_exporter_base import YamlExporterBase

SPRITE_CLASS_ID = 213
SPRITE_ATLAS_CLASS_ID = 687078895


class YamlSpriteExporter(YamlExporterBase):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == SPRITE_CLASS_ID:
            return True, AssetExportCollection(self, asset)
        if asset.class_id == SPRITE_ATLAS_CLASS_ID:
            return True, _EMPTY_EXPORT_COLLECTION
        return False, None

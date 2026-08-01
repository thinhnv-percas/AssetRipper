"""Port of the private `ScriptableObjectGroupExportCollection` nested class in
Source/AssetRipper.Export.UnityProjects/Project/ScriptableObjectGroupExporter.cs (Phase 13h)

A `ScriptableObjectGroup`'s `root` becomes the designated `asset` (used for path/name
resolution, same as `PrefabExportCollection`); `children` are added as extras sharing the
same file. The group marker itself is deliberately *not* added via `add_asset` -- it must
never be treated as part of `exportable_assets` (it's not a real serialized Unity object), but
it still has to appear in `assets` so `ProjectExporter._create_collections`'s "already queued"
bookkeeping marks it claimed and doesn't try to build a second collection for it the next time
it's encountered while iterating `game_bundle.fetch_assets()` (every child/`root`'s
`main_asset` -- and the group's own `main_asset` -- all point back at this same group).
"""
from __future__ import annotations

from .assets_export_collection import AssetsExportCollection


class ScriptableObjectGroupExportCollection(AssetsExportCollection):
    def __init__(self, asset_exporter, group):
        super().__init__(asset_exporter, group.root)
        self.group = group
        self.add_assets(group.children)

    def _get_export_extension(self, asset) -> str:
        return self.group.file_extension or super()._get_export_extension(asset)

    @property
    def assets(self):
        yield self.group
        yield from super().assets

    @property
    def exportable_assets(self):
        yield from super().assets

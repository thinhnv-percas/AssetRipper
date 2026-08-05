"""Port of Source/AssetRipper.Processing/ScriptableObject/ScriptableObjectGroup.cs

A marker asset -- never itself written verbatim to YAML (see
assetripper_export_unity_projects/project/scriptable_object_group_export_collection.py) --
that groups a "root" MonoBehaviour (a TimelineAsset or PostProcessProfile, per
scriptable_object_processor.py) together with the other MonoBehaviours it privately owns
(tracks/clips/markers, or profile settings) so they all land in one exported file. Same
`main_asset`-marker idea as Phase 12's `GameObjectHierarchyObject`/`PrefabHierarchyObject`,
reused for a different processor's grouping. `class_id=-1`: not a real Unity ClassID, exactly
like those two -- this is why the "construct a new asset instance from scratch" gap that
blocks 13d/13e/13i does *not* apply here (see python/ROADMAP.md Phase 13d note): a
`ScriptableObjectGroup` never needs a fabricated real-Unity-typed field layout, only a plain
Python grouping container.

Scoped down from `AssetGroup`/`INamed`: upstream also proxies `OriginalPath`/`OverridePath`/
`OriginalDirectory`/etc. from `Root`, but `PrefabHierarchyObject` (the closest existing
precedent in this port) never bothered proxying those either -- only `name`, which is all
`ScriptableObjectGroupExportCollection`/path-naming actually reads. Not carried over here for
the same reason it wasn't carried over there.
"""
from __future__ import annotations

from assetripper_assets.unity_object_base import UnityObjectBase


class ScriptableObjectGroup(UnityObjectBase):
    def __init__(self, asset_info, root):
        super().__init__(asset_info)
        self.main_asset = self
        self.root = root
        self.children: list = []
        self.file_extension: str | None = None

    @property
    def name(self) -> str:
        return getattr(self.root, "name", None) or ""

    @property
    def assets(self):
        yield self.root
        yield from self.children

    def set_main_asset(self) -> None:
        for asset in self.assets:
            asset.main_asset = self

    def fetch_dependencies(self):
        yield "root", self.collection.force_create_pptr(self.root)
        for child in self.children:
            yield "children[]", self.collection.force_create_pptr(child)

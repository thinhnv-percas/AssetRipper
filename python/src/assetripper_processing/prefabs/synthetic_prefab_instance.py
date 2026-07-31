"""Stand-in for the `IPrefabInstance` `GameObjectExtensions.CreatePrefabForRoot` synthesizes
(`Source/AssetRipper.SourceGenerated.Extensions/GameObjectExtensions.cs:210-230`) for a
loose root GameObject that has no real PrefabInstance asset of its own.

Scoped down: upstream's synthesized instance can be either the modern `PrefabInstance`
marker (hidden from YAML export entirely, `EmitPrefabAsset == false` -- the 2018.3+
behavior) or, for pre-2018.3 projects, an actual serialized `Prefab` asset written into the
`.prefab` file (`m_RootGameObject`, `m_IsPrefabParent`, ...). This port always behaves like
the modern case regardless of the source Unity version: the marker is never serialized, so
its exact field shape is irrelevant to the exported bytes -- it exists purely as a stable
PPtr identity + path-naming anchor for `PrefabExportCollection`. A pre-2018.3 project's
`.prefab` file will therefore look like a modern one rather than byte-for-byte matching
upstream's old-style output; the GameObject/Component content is unaffected either way.
This is a deliberate, documented fidelity reduction, not a guess -- see
python/ROADMAP.md Phase 12.
"""
from __future__ import annotations

from assetripper_assets.unity_object_base import UnityObjectBase


class SyntheticPrefabInstance(UnityObjectBase):
    def __init__(self, asset_info, root_game_object):
        super().__init__(asset_info)
        self.root_game_object = root_game_object

    @property
    def class_name(self) -> str:
        return "PrefabInstance"

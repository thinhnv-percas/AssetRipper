"""Port of Source/AssetRipper.GUI.Web/Paths/CollectionPath.cs"""
from __future__ import annotations

import json
from dataclasses import dataclass

from .bundle_path import BundlePath


@dataclass(frozen=True)
class CollectionPath:
    bundle_path: BundlePath
    index: int

    def get_asset(self, path_id: int) -> "AssetPath":
        from .asset_path import AssetPath

        return AssetPath(self, path_id)

    def to_json(self) -> str:
        return json.dumps({"B": {"P": list(self.bundle_path.path)}, "I": self.index})

    @staticmethod
    def from_json(text: str) -> "CollectionPath":
        data = json.loads(text)
        return CollectionPath(BundlePath(tuple(data["B"].get("P") or ())), data["I"])

    def __str__(self) -> str:
        return self.to_json()

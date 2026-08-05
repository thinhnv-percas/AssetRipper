"""Port of Source/AssetRipper.GUI.Web/Paths/AssetPath.cs"""
from __future__ import annotations

import json
from dataclasses import dataclass

from .bundle_path import BundlePath
from .collection_path import CollectionPath


@dataclass(frozen=True)
class AssetPath:
    collection_path: CollectionPath
    path_id: int

    def to_json(self) -> str:
        c = self.collection_path
        return json.dumps({"C": {"B": {"P": list(c.bundle_path.path)}, "I": c.index}, "D": self.path_id})

    @staticmethod
    def from_json(text: str) -> "AssetPath":
        data = json.loads(text)
        c = data["C"]
        collection_path = CollectionPath(BundlePath(tuple(c["B"].get("P") or ())), c["I"])
        return AssetPath(collection_path, data["D"])

    def __str__(self) -> str:
        return self.to_json()

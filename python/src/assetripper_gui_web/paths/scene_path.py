"""Port of Source/AssetRipper.GUI.Web/Paths/ScenePath.cs"""
from __future__ import annotations

import json
from dataclasses import dataclass

from .bundle_path import BundlePath
from .collection_path import CollectionPath


@dataclass(frozen=True)
class ScenePath:
    first_collection: CollectionPath

    def to_json(self) -> str:
        c = self.first_collection
        return json.dumps({"C": {"B": {"P": list(c.bundle_path.path)}, "I": c.index}})

    @staticmethod
    def from_json(text: str) -> "ScenePath":
        data = json.loads(text)
        c = data["C"]
        return ScenePath(CollectionPath(BundlePath(tuple(c["B"].get("P") or ())), c["I"]))

    def __str__(self) -> str:
        return self.to_json()

"""Port of Source/AssetRipper.GUI.Web/Paths/BundlePath.cs

A BundlePath is an index path from the root GameBundle down to some descendant
Bundle, e.g. (1, 0, 2) means "bundles[1].bundles[0].bundles[2]".
"""
from __future__ import annotations

import json
from dataclasses import dataclass


@dataclass(frozen=True)
class BundlePath:
    path: tuple[int, ...] = ()

    def __post_init__(self) -> None:
        if not isinstance(self.path, tuple):
            object.__setattr__(self, "path", tuple(self.path))

    @property
    def depth(self) -> int:
        return len(self.path)

    @property
    def is_root(self) -> bool:
        return self.depth == 0

    @property
    def parent(self) -> "BundlePath":
        """The path of the parent bundle. Root if this path has depth <= 1."""
        if self.depth > 1:
            return BundlePath(self.path[:-1])
        return BundlePath()

    def get_child(self, index: int) -> "BundlePath":
        return BundlePath(self.path + (index,))

    def get_collection(self, index: int) -> "CollectionPath":
        from .collection_path import CollectionPath

        return CollectionPath(self, index)

    def get_failed_file(self, index: int) -> "FailedFilePath":
        from .failed_file_path import FailedFilePath

        return FailedFilePath(self, index)

    def get_resource(self, index: int) -> "ResourcePath":
        from .resource_path import ResourcePath

        return ResourcePath(self, index)

    def to_json(self) -> str:
        return json.dumps({"P": list(self.path)})

    @staticmethod
    def from_json(text: str) -> "BundlePath":
        data = json.loads(text)
        return BundlePath(tuple(data.get("P") or ()))

    def __str__(self) -> str:
        return self.to_json()

"""Port of Source/AssetRipper.GUI.Web/Paths/FailedFilePath.cs"""
from __future__ import annotations

import json
from dataclasses import dataclass

from .bundle_path import BundlePath


@dataclass(frozen=True)
class FailedFilePath:
    bundle_path: BundlePath
    index: int

    def to_json(self) -> str:
        return json.dumps({"B": {"P": list(self.bundle_path.path)}, "I": self.index})

    @staticmethod
    def from_json(text: str) -> "FailedFilePath":
        data = json.loads(text)
        return FailedFilePath(BundlePath(tuple(data["B"].get("P") or ())), data["I"])

    def __str__(self) -> str:
        return self.to_json()

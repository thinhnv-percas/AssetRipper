"""Port of Source/AssetRipper.Assets/Metadata/AssetInfo.cs"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass(frozen=True, slots=True)
class AssetInfo:
    collection: object
    path_id: int
    class_id: int

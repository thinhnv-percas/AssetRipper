"""Port of Source/AssetRipper.Numerics/BoneWeight1.cs and BoneWeight4.cs"""
from __future__ import annotations

from dataclasses import dataclass


@dataclass(slots=True)
class BoneWeight1:
    weight: float
    index: int


@dataclass(slots=True)
class BoneWeight4:
    COUNT = 4

    weight0: float = 0.0
    weight1: float = 0.0
    weight2: float = 0.0
    weight3: float = 0.0
    index0: int = 0
    index1: int = 0
    index2: int = 0
    index3: int = 0

    @property
    def any_weights_negative(self) -> bool:
        return self.weight0 < 0.0 or self.weight1 < 0.0 or self.weight2 < 0.0 or self.weight3 < 0.0

    @property
    def sum(self) -> float:
        return self.weight0 + self.weight1 + self.weight2 + self.weight3

    @property
    def normalized(self) -> bool:
        return self.sum == 1.0

    def normalize_weights(self) -> "BoneWeight4":
        total = self.sum
        if total == 0.0:
            return BoneWeight4(0.25, 0.25, 0.25, 0.25, self.index0, self.index1, self.index2, self.index3)
        else:
            inv_sum = 1.0 / total
            return BoneWeight4(
                self.weight0 * inv_sum,
                self.weight1 * inv_sum,
                self.weight2 * inv_sum,
                self.weight3 * inv_sum,
                self.index0,
                self.index1,
                self.index2,
                self.index3,
            )

    def __str__(self) -> str:
        weights = (self.weight0, self.weight1, self.weight2, self.weight3)
        indices = (self.index0, self.index1, self.index2, self.index3)
        return f"BoneWeight4: {{ weights = {list(weights)}, indices = {list(indices)} }}"

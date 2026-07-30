"""Port of Source/AssetRipper.IO.Files.Tests/RandomData.cs"""
from __future__ import annotations

import random


def make_random_data(size: int) -> bytes:
    return bytes(random.getrandbits(8) for _ in range(size))

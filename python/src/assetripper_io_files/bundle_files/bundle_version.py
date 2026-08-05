"""Port of Source/AssetRipper.IO.Files/BundleFiles/BundleVersion.cs"""
from __future__ import annotations

from enum import IntEnum


class BundleVersion(IntEnum):
    UNKNOWN = 0

    BF_100_250 = 1
    BF_260_340 = 2
    BF_350_4X = 3
    BF_520A1 = 4
    BF_520AUNK = 5
    BF_520_X = 6
    BF_LARGE_FILES_SUPPORT = 7
    """Several 4-byte integers were upgraded to 8-byte integers to support files larger
    than 2 GB."""
    BF_2022_2 = 8
    """This seems to be exactly the same as BF_LARGE_FILES_SUPPORT."""

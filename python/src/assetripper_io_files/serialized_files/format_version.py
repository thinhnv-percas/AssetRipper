"""Port of Source/AssetRipper.IO.Files/SerializedFiles/FormatVersion.cs"""
from __future__ import annotations

from enum import IntEnum


class FormatVersion(IntEnum):
    """SerializedFileFormatVersion in the pdb."""

    UNSUPPORTED = 1
    UNKNOWN_2 = 2
    UNKNOWN_3 = 3
    UNKNOWN_5 = 5
    """1.2.0 to 2.0.0"""
    UNKNOWN_6 = 6
    """2.1.0 to 2.6.1"""
    UNKNOWN_7 = 7
    """3.0.0b"""
    UNKNOWN_8 = 8
    """3.0.0 to 3.4.2"""
    UNKNOWN_9 = 9
    """3.5.0 to 4.7.2"""
    UNKNOWN_10 = 10
    """5.0.0aunk1"""
    HAS_SCRIPT_TYPE_INDEX = 11
    """5.0.0aunk2"""
    UNKNOWN_12 = 12
    """5.0.0aunk3"""
    HAS_TYPE_TREE_HASHES = 13
    """5.0.0aunk4"""
    UNKNOWN_14 = 14
    """5.0.0unk"""
    SUPPORTS_STRIPPED_OBJECT = 15
    """5.0.1 to 5.4.0"""
    REFACTORED_CLASS_ID = 16
    """5.5.0a"""
    REFACTOR_TYPE_DATA = 17
    """5.5.0unk to 2018.4"""
    REFACTOR_SHAREABLE_TYPE_TREE_DATA = 18
    """2019.1a"""
    TYPE_TREE_NODE_WITH_TYPE_FLAGS = 19
    """2019.1unk"""
    SUPPORTS_REF_OBJECT = 20
    """2019.2"""
    STORES_TYPE_DEPENDENCIES = 21
    """2019.3 to 2019.4"""
    LARGE_FILES_SUPPORT = 22
    """2020.1 to x"""

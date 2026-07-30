"""Port of Source/AssetRipper.Assets/NullObject.cs

An object that, if referenced by a PPtr, returns null unless explicitly searched for.
"""
from __future__ import annotations

from .unity_object_base import UnityObjectBase


class NullObject(UnityObjectBase):
    pass

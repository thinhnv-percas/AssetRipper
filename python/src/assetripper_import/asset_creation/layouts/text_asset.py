"""
Hand-written layout for TextAsset (class ID 49): m_Name, m_Script. Both are plain strings;
this is one of the simplest and most stable layouts in Unity's serialization format, and has
been unchanged across every version this port is aware of.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import root, string_field

_CLASS_ID = 49


def _build(version: UnityVersion):
    return root("TextAsset", string_field("m_Name"), string_field("m_Script"))


def register(registry) -> None:
    registry.register(_CLASS_ID, _build)

"""
Hand-written layout for MonoScript (class ID 115).

Restricted to the fields needed to identify which script/class a MonoScript asset points
to (m_Name, m_ClassName, m_Namespace, m_AssemblyName), which is the layout's primary
purpose -- resolving a MonoScript is how MonoBehaviour fields would eventually be typed via
IL (not implemented in this port; see the phase plan). Deliberately NOT modeled:
m_ExecutionOrder, m_PropertiesHash, and m_IsEditorScript exist on the real asset but their
exact type/position/version range isn't known with enough confidence here to include
safely -- see the layouts package docstring on why a wrong guess fails safely (byte-count
mismatch -> UnreadableObject) rather than silently, but a wrong field in the *middle* of a
layout still corrupts every field that follows it, so the fields this layout is least sure
about are placed nowhere -- omitted entirely -- rather than guessed at.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import root, string_field

_CLASS_ID = 115


def _build(version: UnityVersion):
    return root(
        "MonoScript",
        string_field("m_Name"),
        string_field("m_ClassName"),
        string_field("m_Namespace"),
        string_field("m_AssemblyName"),
    )


def register(registry) -> None:
    registry.register(_CLASS_ID, _build)

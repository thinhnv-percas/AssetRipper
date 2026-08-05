"""`m_SubMeshes[].topology`'s enum. Not vendored here (it's Unity's internal
`GfxPrimitiveType`, not the public `UnityEngine.MeshTopology` scripting enum, which has
different ordinals and no `TriangleStrip` member) -- these ordinals are reconstructed from
cross-referencing several independent public Unity-asset tools (UnityPy, AssetStudio) that
agree on this exact ordering, so confidence is high, but treat it as reconstructed rather
than vendored.
"""
from __future__ import annotations

from enum import IntEnum


class MeshTopology(IntEnum):
    TRIANGLES = 0
    TRIANGLE_STRIP = 1
    QUADS = 2
    LINES = 3
    LINE_STRIP = 4
    POINTS = 5

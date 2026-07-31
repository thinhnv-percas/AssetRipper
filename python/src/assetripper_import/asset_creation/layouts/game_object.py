"""
Hand-written layout for GameObject (class ID 1).

Targets the modern Unity era (roughly 5.5 onward, covering the overwhelming majority of
real-world files); no attempt is made to model pre-5.5 layouts (which used a differently
shaped m_Component list and an integer m_Tag instead of m_TagString). See the layouts
package docstring for the general caveat on hand-authored layouts.

Field set restricted to fields with real runtime effect (release-format fields):
m_Component (pairs of (int, PPtr<Component>)), m_Layer, m_Name, m_TagString, m_IsActive.
Editor-only fields (m_Icon, m_StaticEditorFlags, and possibly m_NavMeshLayer) are
deliberately NOT modeled: this registry exists specifically for files with no embedded type
tree, which in practice means a stripped release player build, whose binary data doesn't
carry editor-only fields at all. Since SerializableStructure.read requires the layout to
consume the object's exact byte count, guessing at editor-only fields here would make the
common (release) case fail while barely helping the rare (editor-format, no type tree) case.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import leaf, pair_field, pptr_field, root, string_field, vector_field

_CLASS_ID = 1


def _build(version: UnityVersion):
    component_pair = pair_field("data", leaf("int", "first"), pptr_field("second", "Component"))
    return root(
        "GameObject",
        vector_field("m_Component", component_pair),
        leaf("int", "m_Layer"),
        string_field("m_Name"),
        string_field("m_TagString"),
        leaf("bool", "m_IsActive", align=True),
    )


def register(registry) -> None:
    registry.register(_CLASS_ID, _build, min_version=UnityVersion(5, 5, 0))

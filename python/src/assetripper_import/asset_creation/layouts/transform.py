"""
Hand-written layout for Transform (class ID 4).

Field order (m_GameObject, m_LocalRotation, m_LocalPosition, m_LocalScale, m_Children,
m_Father) has been stable since Unity's earliest versions and is high-confidence. The one
version-dependent detail modeled here is `m_RootOrder`: an int field present before Unity
2018.3 and removed from then on (child order became implicit in m_Children's own order).
`m_LocalEulerAnglesHint` is deliberately NOT modeled -- it is restored by upstream's
EditorFormatProcessor rather than read from release-format binary data, so including it
here would assume bytes that the file doesn't actually contain.

See the layouts package docstring for the general caveat on hand-authored layouts.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import leaf, pptr_field, root, struct_, vector_field

_CLASS_ID = 4

_QUATERNION_FIELDS = (leaf("float", "x"), leaf("float", "y"), leaf("float", "z"), leaf("float", "w"))
_VECTOR3_FIELDS = (leaf("float", "x"), leaf("float", "y"), leaf("float", "z"))


def _fields(with_root_order: bool):
    fields = [
        pptr_field("m_GameObject", "GameObject"),
        struct_("Quaternionf", "m_LocalRotation", *_QUATERNION_FIELDS),
        struct_("Vector3f", "m_LocalPosition", *_VECTOR3_FIELDS),
        struct_("Vector3f", "m_LocalScale", *_VECTOR3_FIELDS),
        vector_field("m_Children", pptr_field("data", "Transform")),
        pptr_field("m_Father", "Transform"),
    ]
    if with_root_order:
        fields.append(leaf("int", "m_RootOrder"))
    return fields


def _build(version: UnityVersion):
    with_root_order = version.less_than(2018, 3, 0)
    return root("Transform", *_fields(with_root_order))


def register(registry) -> None:
    registry.register(_CLASS_ID, _build)

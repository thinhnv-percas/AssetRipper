"""
Hand-written layout for GameObject (class ID 1).

**Byte-verified against `python/input-test/demo-android.apk` (Unity 2022.3.62f2) on
2026-08-03 -- and that verification found the previous version of this layout was WRONG on
two fields at once.** 407 GameObjects in the real fixture failed `try_read` and became
`UnreadableObject` (losing their name, layer, and component list entirely). See ROADMAP.md
Phase 18.

What the old layout got wrong, and what the real bytes actually say:
 1. `m_Component` elements were modeled as `pair<int, PPtr<Component>>` (16 bytes each). In
    a release build from 5.5+ the `int first` is gone -- each element is a bare
    `PPtr<Component>` (12 bytes: int32 m_FileID + int64 m_PathID). The old module docstring
    even claimed to target "5.5 onward" while modeling the pre-5.5 element shape.
 2. `m_TagString` (a string) is editor-format only. Release bytes carry `m_Tag` as a
    **UInt16** instead.

Real byte evidence (two samples, offsets exact):
    len=35: count=1 @0; one 12-byte PPtr{0,440} @4; m_Layer @16; m_Name len=7 "Content" @20;
            pad to 32; m_Tag u16 @32; m_IsActive @34  -> consumes exactly 35
    len=83: count=4 @0; four 12-byte PPtrs @4..51; m_Layer @52; m_Name len=18 @56;
            18 chars @60..77; pad to 80; m_Tag u16 @80; m_IsActive @82 -> exactly 83

Editor-only fields (m_Icon, m_StaticEditorFlags, m_NavMeshLayer, m_TagString) remain
deliberately NOT modeled: this registry exists specifically for files with no embedded type
tree, which in practice means a stripped release player build, whose binary data doesn't
carry editor-only fields at all. Since SerializableStructure.read requires the layout to
consume the object's exact byte count, guessing at editor-only fields here would make the
common (release) case fail while barely helping the rare (editor-format, no type tree) case.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import leaf, pptr_field, root, string_field, vector_field

_CLASS_ID = 1


def _build(version: UnityVersion):
    return root(
        "GameObject",
        vector_field("m_Component", pptr_field("data", "Component")),
        leaf("int", "m_Layer"),
        string_field("m_Name"),
        leaf("unsigned short", "m_Tag"),
        # No trailing align, unlike most Unity bool fields: m_IsActive is the *last* field, and
        # a real object's stored data is not padded past its final field (verified -- the 35 and
        # 83-byte samples above both end exactly on m_IsActive). An align here rounded 35 -> 36
        # and made `try_read`'s exact-byte-count check fail on every GameObject. Inter-object
        # padding in the file is the SerializedFile's business, not the object payload's.
        leaf("bool", "m_IsActive"),
    )


def register(registry) -> None:
    registry.register(_CLASS_ID, _build, min_version=UnityVersion(5, 5, 0))

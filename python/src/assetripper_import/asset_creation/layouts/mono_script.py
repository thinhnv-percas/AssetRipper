"""
Hand-written layout for MonoScript (class ID 115).

**Byte-verified against `python/input-test/demo-android.apk` (Unity 2022.3.62f2) on
2026-08-03 -- and that verification found the previous version of this layout was WRONG.**

The old layout listed only m_Name/m_ClassName/m_Namespace/m_AssemblyName, deliberately
omitting m_ExecutionOrder and m_PropertiesHash on the theory that "the fields this layout is
least sure about are placed nowhere -- omitted entirely -- rather than guessed at". That
reasoning only holds for fields at the *end* of a layout. These two sit in the **middle**,
between m_Name and m_ClassName, so omitting them misaligned everything after them: all 2076
MonoScripts in the real fixture failed `try_read` and became `UnreadableObject`. Because
`ProjectExporter` dispatches `RawDataObject` subclasses by Python type rather than class ID,
those never reached `ScriptExporter` at all -- so a real game exported **zero** `.cs` files,
with no error surfaced anywhere. See ROADMAP.md Phase 18.

Real byte evidence (three separate samples, offsets exact):
    m_Name="TemplateAsset"   -> 4+13, pad to 20, then 20 more bytes, then m_ClassName @40
    m_Name="VisualTreeAsset" -> 4+15, pad to 20, then 4 zero + 16 hash bytes, m_ClassName @40
    m_Name="StyleSheet"      -> 4+10, pad to 16, then 4 zero + 16 hash bytes, m_ClassName @36
i.e. exactly 20 bytes between the aligned m_Name and m_ClassName in every case = int32
m_ExecutionOrder + 16-byte m_PropertiesHash (Hash128, four uint32s -- the modern shape; Unity
used a plain uint32 m_PropertiesHash before 5.0, which this layout does not target).

m_IsEditorScript is still not modeled, and that IS correct: it's editor-only and genuinely
absent from release-build bytes (confirmed -- the samples above consume their full length
without it).
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import leaf, root, string_field, struct_

_CLASS_ID = 115


def _hash128(name: str):
    """Unity's Hash128, serialized as four uint32s (16 bytes, no trailing align)."""
    return struct_(
        "Hash128",
        name,
        leaf("unsigned int", "m_u32_0"),
        leaf("unsigned int", "m_u32_1"),
        leaf("unsigned int", "m_u32_2"),
        leaf("unsigned int", "m_u32_3"),
    )


def _build(version: UnityVersion):
    return root(
        "MonoScript",
        string_field("m_Name"),
        leaf("int", "m_ExecutionOrder"),
        _hash128("m_PropertiesHash"),
        string_field("m_ClassName"),
        string_field("m_Namespace"),
        string_field("m_AssemblyName"),
    )


def register(registry) -> None:
    # 5.0 is where m_PropertiesHash became a Hash128 (it was a uint32 before), which is the
    # only version-sensitive part of the shape above -- so this layout claims 5.0+ only
    # rather than silently misreading an older file the way the previous version did.
    registry.register(_CLASS_ID, _build, min_version=UnityVersion(5, 0, 0))

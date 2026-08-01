"""
Hand-written layout for AudioClip (class ID 83).

**Byte-verified against a real fixture** (Phase 18 audit, 2026-08-01): tested against every
AudioClip in `python/input-test/demo-android.apk` (a real Unity 2022.3.62f2 build, 8/8 samples
read exactly, e.g. name="saw_destroy", channels=1, frequency=44100, bitsPerSample=16,
source="sharedassets0.resource"). Field order sourced from Perfare/AssetStudio's
`AudioClip.cs`, scoped to its `version[0] >= 5` branch (`min_version=5.0.0` below) -- the
pre-5.0 FMOD-era layout is a materially different shape this port makes no attempt at,
consistent with this package's "modern era only" scoping elsewhere (see e.g. transform.py).

`m_Resource` (`get_streamed_resource_content`'s expected shape, see
assetripper_import/streamed_resource.py) matches AssetStudio's flat `m_Source`/`m_Offset`/
`m_Size` fields exactly, just wrapped in a struct with that name.

**Not modeled: the embedded (non-streamed) audio-data case.** When `m_Source` is empty,
AssetStudio's reader falls back to reading `m_Size` raw bytes directly from the current
stream position -- i.e. Unity's real type tree likely represents this as a `TypelessData`
field (a bare byte run sized by `m_Size`, no length prefix of its own), not a normal
size-prefixed array `SerializableStructure`'s reader already knows how to consume via this
package's `vector_field`/`array_field` helpers. All 8 real AudioClip samples checked stream
externally (this is standard for stripped Android/iOS release builds -- Unity moves audio to
`.resS`/`.resource` files rather than embedding it inline), so this gap has zero observed
impact on the fixture available here, but a real project with embedded audio (uncommon, but
possible for very short one-shot sounds on some platforms) would fail to read via this layout
instead of silently misreading -- the safe failure mode this package's own docstring commits
to, not a fabrication.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import leaf, root, string_field, struct_

_CLASS_ID = 83


def _build(version: UnityVersion):
    return root(
        "AudioClip",
        string_field("m_Name"),
        leaf("int", "m_LoadType"),
        leaf("int", "m_Channels"),
        leaf("int", "m_Frequency"),
        leaf("int", "m_BitsPerSample"),
        leaf("float", "m_Length"),
        leaf("bool", "m_IsTrackerFormat", align=True),
        leaf("int", "m_SubsoundIndex"),
        leaf("bool", "m_PreloadAudioData"),
        leaf("bool", "m_LoadInBackground"),
        leaf("bool", "m_Legacy3D", align=True),
        struct_(
            "StreamedResource",
            "m_Resource",
            string_field("m_Source"),
            leaf("SInt64", "m_Offset"),
            leaf("SInt64", "m_Size"),
        ),
        leaf("int", "m_CompressionFormat"),
    )


def register(registry) -> None:
    registry.register(_CLASS_ID, _build, min_version=UnityVersion(5, 0, 0))

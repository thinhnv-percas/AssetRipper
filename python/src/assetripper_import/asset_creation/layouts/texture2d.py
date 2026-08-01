"""
Hand-written layout for Texture2D (class ID 28).

**Byte-verified against a real fixture** (Phase 18 audit, 2026-08-01): unlike every other
layout in this package (sourced from public documentation only, never checked against real
bytes because no real fixture existed), this one was reverse-engineered by reading the actual
Texture2D bytes in `python/input-test/demo-android.apk` (a real Unity 2022.3.62f2 build) and
adjusting field-by-field until `SerializableStructure.try_read` consumed the *exact* byte
count with plausible values (name="EmojiOne", 512x512, mip_count=10, image data length
matching `m_CompleteImageSize` exactly). This is the highest-confidence layout in this
package as a direct result -- see `tests/import_/test_texture2d_layout.py` for the exact
byte fixture used.

Field order and version gates below the >=2022.2 branch are sourced from Perfare/AssetStudio's
`Texture2D.cs` (a long-established, widely-used reference implementation for this exact
purpose) but are **not independently byte-verified here** -- only the >=2022.2 shape is.
Scoped to `min_version=2019.3` (where `m_IgnoreMasterTextureLimit` first appears in a shape
this layout can represent in one branch point) rather than attempting the full historical
range back to Unity 2.x: this port has no fixture for anything older, and guessing at
1very old field shapes has exactly the "plausible but wrong" risk this package's docstring
warns about.

Two version-gated shapes are modeled for the tail before m_StreamingMipmaps:
- **2019.3 - 2022.1**: `m_IgnoreMasterTextureLimit` (bool).
- **>=2022.2 (byte-verified)**: `m_IgnoreMipmapLimit` (bool) + `m_MipmapLimitGroupName`
  (aligned string) -- Unity's Mipmap Limit Groups feature replaced the single bool with a
  per-group name at this version, confirmed via the real fixture (see module docstring above).

Not modeled: `m_ForcedFallbackFormat`/`m_DownscaleFallback` version range below 2017.3 (this
layout's min_version is already 2019.3, so those are unconditionally present); anything
before 2019.3 at all.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import array_field, leaf, pptr_field, root, string_field, struct_, vector_field

_CLASS_ID = 28

_GL_TEXTURE_SETTINGS_FIELDS = (
    leaf("int", "m_FilterMode"),
    leaf("int", "m_Aniso"),
    leaf("float", "m_MipBias"),
    leaf("int", "m_WrapU"),
    leaf("int", "m_WrapV"),
    leaf("int", "m_WrapW"),
)


def _build(version: UnityVersion):
    fields = [
        string_field("m_Name"),
        leaf("int", "m_ForcedFallbackFormat"),
        leaf("bool", "m_DownscaleFallback"),
        leaf("bool", "m_IsAlphaChannelOptional", align=True),
        leaf("int", "m_Width"),
        leaf("int", "m_Height"),
        leaf("int", "m_CompleteImageSize"),
        leaf("int", "m_MipsStripped"),
        leaf("int", "m_TextureFormat"),
        leaf("int", "m_MipCount"),
        leaf("bool", "m_IsReadable"),
        leaf("bool", "m_IsPreProcessed"),
    ]
    if version.less_than(2022, 2, 0):
        fields.append(leaf("bool", "m_IgnoreMasterTextureLimit", align=True))
    else:
        fields.append(leaf("bool", "m_IgnoreMipmapLimit"))
        fields.append(string_field("m_MipmapLimitGroupName"))
    fields += [
        leaf("bool", "m_StreamingMipmaps", align=True),
        leaf("int", "m_StreamingMipmapsPriority"),
        leaf("int", "m_ImageCount"),
        leaf("int", "m_TextureDimension"),
        struct_("GLTextureSettings", "m_TextureSettings", *_GL_TEXTURE_SETTINGS_FIELDS),
        leaf("int", "m_LightmapFormat"),
        leaf("int", "m_ColorSpace"),
        vector_field("m_PlatformBlob", leaf("UInt8", "data")),
        vector_field("image data", leaf("UInt8", "data"), align=False),
        struct_(
            "StreamingInfo",
            "m_StreamData",
            leaf("SInt64", "offset"),
            leaf("unsigned int", "size"),
            string_field("path"),
        ),
    ]
    return root("Texture2D", *fields)


def register(registry) -> None:
    registry.register(_CLASS_ID, _build, min_version=UnityVersion(2019, 3, 0))

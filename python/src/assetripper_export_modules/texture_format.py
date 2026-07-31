"""Unity's `UnityEngine.TextureFormat` enum, reconstructed from Unity's public scripting
API docs (https://docs.unity3d.com/ScriptReference/TextureFormat.html) -- this is not a
port: the real definition lives in AssetRipper.SourceGenerated (Tpk-derived, not vendored
in this repo), same situation as assetripper_primitives/unity_guid.py's own disclaimer.

Only the values this port's texture_converter.py actually decodes are listed; every other
real TextureFormat value is deliberately absent rather than guessed at, so an unhandled
format fails an `is not None` / dict-lookup check instead of silently mismatching.
"""
from __future__ import annotations

from enum import IntEnum


class TextureFormat(IntEnum):
    ALPHA8 = 1
    ARGB4444 = 2
    RGB24 = 3
    RGBA32 = 4
    ARGB32 = 5
    RGB565 = 7
    R16 = 9
    DXT1 = 10
    DXT5 = 12
    RGBA4444 = 13
    BGRA32 = 14
    RHALF = 15
    RGHALF = 16
    RGBAHALF = 17
    RFLOAT = 18
    RGFLOAT = 19
    RGBAFLOAT = 20
    RGB9E5FLOAT = 22
    BC6H = 24
    BC7 = 25
    BC4 = 26
    BC5 = 27
    DXT1_CRUNCHED = 28
    DXT5_CRUNCHED = 29
    PVRTC_RGB2 = 30
    PVRTC_RGBA2 = 31
    PVRTC_RGB4 = 32
    PVRTC_RGBA4 = 33
    ETC_RGB4 = 34
    ATC_RGB4 = 35
    ATC_RGBA8 = 36
    EAC_R = 41
    EAC_R_SIGNED = 42
    EAC_RG = 43
    EAC_RG_SIGNED = 44
    ETC2_RGB = 45
    ETC2_RGBA1 = 46
    ETC2_RGBA8 = 47
    ASTC_RGB_4X4 = 48
    ASTC_RGB_5X5 = 49
    ASTC_RGB_6X6 = 50
    ASTC_RGB_8X8 = 51
    ASTC_RGB_10X10 = 52
    ASTC_RGB_12X12 = 53
    ASTC_RGBA_4X4 = 54
    ASTC_RGBA_5X5 = 55
    ASTC_RGBA_6X6 = 56
    ASTC_RGBA_8X8 = 57
    ASTC_RGBA_10X10 = 58
    ASTC_RGBA_12X12 = 59
    RG16 = 62
    R8 = 63
    ETC_RGB4_CRUNCHED = 64
    ETC2_RGBA8_CRUNCHED = 65


CRUNCHED_FORMATS = frozenset(
    {
        TextureFormat.DXT1_CRUNCHED,
        TextureFormat.DXT5_CRUNCHED,
        TextureFormat.ETC_RGB4_CRUNCHED,
        TextureFormat.ETC2_RGBA8_CRUNCHED,
    }
)

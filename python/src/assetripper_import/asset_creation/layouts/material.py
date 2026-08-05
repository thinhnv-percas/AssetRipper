"""
Hand-written layout for Material (class ID 21).

**Byte-verified against a real fixture** (Phase 18 audit, 2026-08-01): tested against all 8
Materials in `python/input-test/demo-android.apk` (a real Unity 2022.3.62f2 build) -- every
sample's `SerializableStructure.try_read` consumed the exact byte count, with fully plausible
content (a "TextMeshPro/Sprite" material with its real `_ColorMask`/`_Stencil*`/`_ClipRect`/
`_Color` properties intact). Field order sourced from Perfare/AssetStudio's `Material.cs`
(`Material`/`UnityPropertySheet`/`UnityTexEnv`).

Scoped to `min_version=2021.3.0`, matching this port's real fixture exactly: at 2021.3,
`m_ShaderKeywords` (a single string in 5.0-2021.2) was split into `m_ValidKeywords`/
`m_InvalidKeywords` (two string arrays), and `m_SavedProperties.m_Ints` was added. Older
Material versions have a different shape this layout does not attempt -- unlike some other
layouts in this package, this scoping is not "modern era, high confidence anyway": Material
has changed shape at several points (4.3, 5.1, 5.6, 2021.1, 2021.3), and only the >=2021.3
shape has actually been checked against real bytes here.

`m_BuildTextureStacks` (>=2020, added after `m_SavedProperties`): every real sample here has
this empty (count 0), so its element shape (a name plus some per-layer texture reference, per
public discussion of the feature) is an unverified best-effort guess, not a confirmed
structure -- a material that actually uses texture stacks (a rare packing optimization) may
fail to read via this layout instead of silently misreading.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import array_field, leaf, pptr_field, root, string_field, struct_, vector_field

_CLASS_ID = 21


def _string_pair_array(name: str, value_field):
    return vector_field(name, struct_("pair", "data", string_field("first"), value_field))


def _tex_env():
    return struct_(
        "UnityTexEnv",
        "second",
        pptr_field("m_Texture", "Texture"),
        struct_("Vector2f", "m_Scale", leaf("float", "x"), leaf("float", "y")),
        struct_("Vector2f", "m_Offset", leaf("float", "x"), leaf("float", "y")),
    )


def _texenv_pair():
    return struct_("pair", "data", string_field("first"), _tex_env())


def _color4():
    return struct_("ColorRGBA", "second", leaf("float", "r"), leaf("float", "g"), leaf("float", "b"), leaf("float", "a"))


def _build_texture_stack_element():
    """See module docstring: not confirmed against a non-empty real sample."""
    return struct_(
        "TextureStackReference", "data",
        string_field("m_Name"),
        vector_field("m_TextureStackNameToLayer", struct_("pair", "data", string_field("first"), pptr_field("second", "Texture"))),
    )


def _build(version: UnityVersion):
    return root(
        "Material",
        string_field("m_Name"),
        pptr_field("m_Shader", "Shader"),
        vector_field("m_ValidKeywords", string_field("data")),
        vector_field("m_InvalidKeywords", string_field("data")),
        leaf("unsigned int", "m_LightmapFlags"),
        leaf("bool", "m_EnableInstancingVariants", align=True),
        leaf("int", "m_CustomRenderQueue"),
        vector_field("stringTagMap", struct_("pair", "data", string_field("first"), string_field("second"))),
        vector_field("disabledShaderPasses", string_field("data")),
        struct_(
            "UnityPropertySheet",
            "m_SavedProperties",
            vector_field("m_TexEnvs", _texenv_pair()),
            vector_field("m_Ints", struct_("pair", "data", string_field("first"), leaf("int", "second"))),
            vector_field("m_Floats", struct_("pair", "data", string_field("first"), leaf("float", "second"))),
            vector_field("m_Colors", struct_("pair", "data", string_field("first"), _color4())),
        ),
        vector_field("m_BuildTextureStacks", _build_texture_stack_element()),
    )


def register(registry) -> None:
    registry.register(_CLASS_ID, _build, min_version=UnityVersion(2021, 3, 0))

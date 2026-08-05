"""
Hand-written layout for Sprite (class ID 213).

**Byte-verified against a real fixture** (Phase 18 audit, 2026-08-01): tested against all 8
Sprites in `python/input-test/demo-android.apk` (a real Unity 2022.3.62f2 build) -- every
sample's `SerializableStructure.try_read` consumed the exact byte count, with plausible
`m_Rect`/`m_Pivot`/mesh-vertex-count values. Field order sourced from Perfare/AssetStudio's
`Sprite.cs` (`Sprite`/`SpriteRenderData`/`SubMesh`/`VertexData`/`ChannelInfo`/`SpriteSettings`).

Scoped to `min_version=2017.0.0`: at that version Unity already has `m_RenderDataKey`/
`m_AtlasTags`/`m_SpriteAtlas`/`m_PhysicsShape` (all read unconditionally below) and the
modern `SubMesh`+`VertexData` shape for `m_RD` (the pre-5.6 `vertices`/`indices` legacy shape
is NOT modeled at all, matching this package's "modern era only" scoping elsewhere).

**Two sub-structures are honestly lower-confidence than the rest, because every real sample
here has them empty (count 0) and so never actually exercises their element shape:**
- `secondaryTextures` (>=2019, `SecondarySpriteTexture`: name + `PPtr<Texture2D>`) --
  field order guessed from the type's public name/purpose, not confirmed against a real
  non-empty sample.
- `m_Bones` (>=2018, `SpriteBone`-like: name, a GUID-shaped struct, position, rotation,
  length, parentId) -- Unity's public `SpriteBone` scripting API documents these members but
  not their exact serialized order/types; guessed by best-effort analogy to Transform's own
  `m_LocalPosition`/`m_LocalRotation` shapes.
A sprite that has non-empty content in either of these (packable secondary textures, or a 2D
Animation "Sprite Skin" rig) may fail to read via this layout -- the safe failure mode this
package's docstring commits to (`UnreadableObject`), not silent corruption. Every other field
here was directly confirmed byte-for-byte against the real fixture.

`m_RenderDataKey`'s `GUID` half is modeled as 4 raw `unsigned int` fields (matching how a real
Unity type tree represents a `GUID` struct) with placeholder names -- nothing in this port
reads `m_RenderDataKey` by name (see sprite_processor.py's own docstring on why atlas-lookup
via this key isn't attempted), so only its byte width matters here, not its field names.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import leaf, pair_field, pptr_field, root, string_field, struct_, vector_field

_CLASS_ID = 213

_RECTF_FIELDS = (leaf("float", "x"), leaf("float", "y"), leaf("float", "width"), leaf("float", "height"))
_VECTOR2_FIELDS = (leaf("float", "x"), leaf("float", "y"))
_VECTOR3_FIELDS = (leaf("float", "x"), leaf("float", "y"), leaf("float", "z"))
_VECTOR4_FIELDS = (leaf("float", "x"), leaf("float", "y"), leaf("float", "z"), leaf("float", "w"))
_QUATERNION_FIELDS = (leaf("float", "x"), leaf("float", "y"), leaf("float", "z"), leaf("float", "w"))
_GUID_FIELDS = (
    leaf("unsigned int", "data0"),
    leaf("unsigned int", "data1"),
    leaf("unsigned int", "data2"),
    leaf("unsigned int", "data3"),
)


def _rectf(name: str):
    return struct_("Rectf", name, *_RECTF_FIELDS)


def _vector2(name: str):
    return struct_("Vector2f", name, *_VECTOR2_FIELDS)


def _vector4(name: str):
    return struct_("Vector4f", name, *_VECTOR4_FIELDS)


def _channel_info():
    return struct_(
        "ChannelInfo", "data",
        leaf("UInt8", "stream"), leaf("UInt8", "offset"), leaf("UInt8", "format"), leaf("UInt8", "dimension"),
    )


def _sub_mesh():
    return struct_(
        "SubMesh", "data",
        leaf("unsigned int", "firstByte"),
        leaf("unsigned int", "indexCount"),
        leaf("int", "topology"),
        leaf("unsigned int", "baseVertex"),
        leaf("unsigned int", "firstVertex"),
        leaf("unsigned int", "vertexCount"),
        struct_("AABB", "localAABB", struct_("Vector3f", "m_Center", *_VECTOR3_FIELDS), struct_("Vector3f", "m_Extent", *_VECTOR3_FIELDS)),
    )


def _vertex_data():
    return struct_(
        "VertexData",
        "m_VertexData",
        leaf("unsigned int", "m_VertexCount"),
        vector_field("m_Channels", _channel_info()),
        vector_field("m_DataSize", leaf("UInt8", "data")),
    )


def _matrix4x4():
    return struct_("Matrix4x4f", "data", *(leaf("float", f"e{i}") for i in range(16)))


def _secondary_sprite_texture():
    """`SecondarySpriteTexture` (>=2019) -- see module docstring: order not confirmed
    against a non-empty real sample."""
    return struct_("SecondarySpriteTexture", "data", pptr_field("texture", "Texture2D"), string_field("name"))


def _sprite_bone():
    """See module docstring: not confirmed against a non-empty real sample."""
    return struct_(
        "SpriteBone",
        "data",
        string_field("name"),
        struct_("GUID", "guid", *_GUID_FIELDS),
        struct_("Vector3f", "position", *_VECTOR3_FIELDS),
        struct_("Quaternionf", "rotation", *_QUATERNION_FIELDS),
        leaf("float", "length"),
        leaf("int", "parentId"),
    )


def _sprite_render_data(version: UnityVersion):
    fields = [
        pptr_field("texture", "Texture2D"),
        pptr_field("alphaTexture", "Texture2D"),
    ]
    if version.greater_than_or_equals(2019, 1, 0):
        fields.append(vector_field("secondaryTextures", _secondary_sprite_texture()))
    fields += [
        vector_field("m_SubMeshes", _sub_mesh()),
        vector_field("m_IndexBuffer", leaf("UInt8", "data")),
        _vertex_data(),
    ]
    if version.greater_than_or_equals(2018, 1, 0):
        fields.append(vector_field("m_Bindpose", _matrix4x4()))
    fields += [
        _rectf("textureRect"),
        _vector2("textureRectOffset"),
        _vector2("atlasRectOffset"),
        leaf("unsigned int", "settingsRaw"),
        _vector4("uvTransform"),
        leaf("float", "downscaleMultiplier"),
    ]
    return struct_("SpriteRenderData", "m_RD", *fields)


def _build(version: UnityVersion):
    fields = [
        string_field("m_Name"),
        _rectf("m_Rect"),
        _vector2("m_Offset"),
        _vector4("m_Border"),
        leaf("float", "m_PixelsToUnits"),
        _vector2("m_Pivot"),
        leaf("unsigned int", "m_Extrude"),
        leaf("bool", "m_IsPolygon", align=True),
        pair_field("m_RenderDataKey", struct_("GUID", "first", *_GUID_FIELDS), leaf("SInt64", "second")),
        vector_field("m_AtlasTags", string_field("data")),
        pptr_field("m_SpriteAtlas", "SpriteAtlas"),
        _sprite_render_data(version),
        vector_field("m_PhysicsShape", vector_field("data", _vector2("data"))),
    ]
    if version.greater_than_or_equals(2018, 1, 0):
        fields.append(vector_field("m_Bones", _sprite_bone()))
    return root("Sprite", *fields)


def register(registry) -> None:
    registry.register(_CLASS_ID, _build, min_version=UnityVersion(2017, 1, 0))

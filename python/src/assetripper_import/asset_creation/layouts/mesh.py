"""
Hand-written layout for Mesh (class ID 43).

**Byte-verified against a real fixture** (Phase 18 audit, 2026-08-01): tested against all 29
Meshes in `python/input-test/demo-android.apk` (a real Unity 2022.3.62f2 build) by first
hand-tracing every field with a throwaway Python script (not this DSL) offset-by-offset and
confirming it consumes the **exact** byte count for every single sample, then encoding the
same field order here and re-confirming via `SerializableStructure.try_read` through the real
`GameAssetFactory`. Field order sourced from Perfare/AssetStudio's `Mesh.cs` (`Mesh`, `SubMesh`,
`BlendShapeData`/`MeshBlendShape`/`MeshBlendShapeChannel`/`BlendShapeVertex`, `VertexData`/
`ChannelInfo`, `CompressedMesh`, `MinMaxAABB`) and `AnimationClip.cs` (`PackedFloatVector`,
`PackedIntVector` -- oddly defined there upstream, reused by Mesh's `CompressedMesh`).

Scoped to `min_version=2019.1.0`: that's where `m_BonesAABB`/`m_VariableBoneCountWeights` were
added (read unconditionally below, since versions before that aren't modeled at all -- matching
this package's "modern era only" precedent elsewhere). `m_CookingOptions` (Unity 2022.1+) is the
one field within the supported range that's still conditional.

**Two things confirmed present but NOT independently verified for their non-empty shape**,
because every real sample here has them empty and so never exercises the element layout:
- `m_Shapes` (`BlendShapeData`): `vertices`/`shapes`/`channels`/`fullWeights` all had count 0 in
  every sample. The wrapping vector-of-count-0 shape is verified (byte-exact across all 29
  samples); `BlendShapeVertex`/`MeshBlendShape`/`MeshBlendShapeChannel`'s internal field order is
  taken from AssetStudio's `Mesh.cs` on trust, not confirmed against real bytes. A mesh with
  actual blend shapes may fail to read via this layout (`UnreadableObject`, the safe failure mode).
- `m_CompressedMesh`: `m_MeshCompression` was `0` (uncompressed) in every real sample, so every
  `PackedFloatVector`/`PackedIntVector` sub-field was empty (`m_NumItems=0`). The empty-shape byte
  layout is verified; the packed-bit-vector *content* format (relevant only for compressed
  meshes, which `assetripper_export_modules.meshes.mesh_data`'s own docstring already declines
  entirely as "a substantial separate subsystem") is out of scope regardless.

Every other field -- `m_SubMeshes`, `m_BindPose`, `m_BoneNameHashes`, `m_RootBoneNameHash`,
`m_BonesAABB`, `m_VariableBoneCountWeights`, `m_MeshCompression`/`m_IsReadable`/`m_KeepVertices`/
`m_KeepIndices`, `m_IndexFormat`, `m_IndexBuffer`, `m_VertexData` (consumed directly by
`mesh_data.py`), `m_LocalAABB`, `m_MeshUsageFlags`, `m_CookingOptions`, both baked collision mesh
byte blobs, `m_MeshMetrics`, `m_StreamData` -- was directly confirmed byte-for-byte, including
plausible values (`m_LocalAABB` extents matching real model bounds, `m_IsReadable`/
`m_KeepVertices`/`m_KeepIndices` varying 0/1 per mesh rather than being stuck at a single value,
`m_CookingOptions` a constant `30` across every sample -- a real Unity default cooking-options
bitmask, not a plausible coincidence of a misaligned read).
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import leaf, root, string_field, struct_, vector_field

_CLASS_ID = 43

_VECTOR3_FIELDS = (leaf("float", "x"), leaf("float", "y"), leaf("float", "z"))


def _vector3(name: str):
    return struct_("Vector3f", name, *_VECTOR3_FIELDS)


def _aabb(name: str):
    return struct_("AABB", name, _vector3("m_Center"), _vector3("m_Extent"))


def _sub_mesh():
    return struct_(
        "SubMesh", "data",
        leaf("unsigned int", "firstByte"),
        leaf("unsigned int", "indexCount"),
        leaf("int", "topology"),
        leaf("unsigned int", "baseVertex"),
        leaf("unsigned int", "firstVertex"),
        leaf("unsigned int", "vertexCount"),
        _aabb("localAABB"),
    )


def _min_max_aabb():
    return struct_("MinMaxAABB", "data", _vector3("m_Min"), _vector3("m_Max"))


def _matrix4x4():
    return struct_("Matrix4x4f", "data", *(leaf("float", f"e{i}") for i in range(16)))


def _channel_info():
    return struct_(
        "ChannelInfo", "data",
        leaf("UInt8", "stream"), leaf("UInt8", "offset"), leaf("UInt8", "format"), leaf("UInt8", "dimension"),
    )


def _vertex_data():
    return struct_(
        "VertexData", "m_VertexData",
        leaf("unsigned int", "m_VertexCount"),
        vector_field("m_Channels", _channel_info()),
        vector_field("m_DataSize", leaf("UInt8", "data")),
    )


def _blend_shape_vertex():
    return struct_(
        "BlendShapeVertex", "data",
        _vector3("vertex"), _vector3("normal"), _vector3("tangent"), leaf("unsigned int", "index"),
    )


def _mesh_blend_shape():
    return struct_(
        "MeshBlendShape", "data",
        leaf("unsigned int", "firstVertex"),
        leaf("unsigned int", "vertexCount"),
        leaf("bool", "hasNormals"),
        leaf("bool", "hasTangents", align=True),
    )


def _mesh_blend_shape_channel():
    return struct_(
        "MeshBlendShapeChannel", "data",
        string_field("name"),
        leaf("unsigned int", "nameHash"),
        leaf("int", "frameIndex"),
        leaf("int", "frameCount"),
    )


def _blend_shape_data():
    return struct_(
        "BlendShapeData", "m_Shapes",
        vector_field("vertices", _blend_shape_vertex()),
        vector_field("shapes", _mesh_blend_shape()),
        vector_field("channels", _mesh_blend_shape_channel()),
        vector_field("fullWeights", leaf("float", "data")),
    )


def _packed_float_vector(name: str):
    return struct_(
        "PackedFloatVector", name,
        leaf("unsigned int", "m_NumItems"),
        leaf("float", "m_Range"),
        leaf("float", "m_Start"),
        vector_field("m_Data", leaf("UInt8", "data")),
        leaf("UInt8", "m_BitSize", align=True),
    )


def _packed_int_vector(name: str):
    return struct_(
        "PackedIntVector", name,
        leaf("unsigned int", "m_NumItems"),
        vector_field("m_Data", leaf("UInt8", "data")),
        leaf("UInt8", "m_BitSize", align=True),
    )


def _compressed_mesh():
    return struct_(
        "CompressedMesh", "m_CompressedMesh",
        _packed_float_vector("m_Vertices"),
        _packed_float_vector("m_UV"),
        _packed_float_vector("m_Normals"),
        _packed_float_vector("m_Tangents"),
        _packed_int_vector("m_Weights"),
        _packed_int_vector("m_NormalSigns"),
        _packed_int_vector("m_TangentSigns"),
        _packed_float_vector("m_FloatColors"),
        _packed_int_vector("m_BoneIndices"),
        _packed_int_vector("m_Triangles"),
        leaf("unsigned int", "m_UVInfo"),
    )


def _build(version: UnityVersion):
    fields = [
        string_field("m_Name"),
        vector_field("m_SubMeshes", _sub_mesh()),
        _blend_shape_data(),
        vector_field("m_BindPose", _matrix4x4()),
        vector_field("m_BoneNameHashes", leaf("unsigned int", "data")),
        leaf("unsigned int", "m_RootBoneNameHash"),
        vector_field("m_BonesAABB", _min_max_aabb()),
        vector_field("m_VariableBoneCountWeights", leaf("unsigned int", "data")),
        leaf("UInt8", "m_MeshCompression"),
        leaf("bool", "m_IsReadable"),
        leaf("bool", "m_KeepVertices"),
        leaf("bool", "m_KeepIndices", align=True),
        leaf("int", "m_IndexFormat"),
        vector_field("m_IndexBuffer", leaf("UInt8", "data")),
        _vertex_data(),
        _compressed_mesh(),
        _aabb("m_LocalAABB"),
        leaf("int", "m_MeshUsageFlags"),
    ]
    if version.greater_than_or_equals(2022, 1, 0):
        fields.append(leaf("int", "m_CookingOptions"))
    fields += [
        vector_field("m_BakedConvexCollisionMesh", leaf("UInt8", "data")),
        vector_field("m_BakedTriangleCollisionMesh", leaf("UInt8", "data")),
        leaf("float", "m_MeshMetrics_0"),
        leaf("float", "m_MeshMetrics_1", align=True),
        struct_("StreamingInfo", "m_StreamData", leaf("SInt64", "offset"), leaf("unsigned int", "size"), string_field("path")),
    ]
    return root("Mesh", *fields)


def register(registry) -> None:
    registry.register(_CLASS_ID, _build, min_version=UnityVersion(2019, 1, 0))

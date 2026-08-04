"""
Tests for the hand-written layouts in assetripper_import.asset_creation.layouts.

No upstream counterpart -- this registry doesn't exist in AssetRipper (see the layouts
package docstring for why: upstream resolves this case from the Tpk type-tree database).
Each test builds a payload matching what the layout module claims to expect and verifies
the interpreter consumes it exactly, the same shape of test used throughout
test_serializable_structure.py.
"""
import struct

from assetripper_import.asset_creation.layouts import default_registry
from assetripper_import.structure.assembly.type_trees import SerializableTreeType
from assetripper_io_endian.endian_span_reader import EndianSpanReader
from assetripper_io_files.serialized_files.transfer_instruction_flags import TransferInstructionFlags
from assetripper_primitives import UnityVersion

from ._tree_builder import unity_string

_NO_FLAGS = TransferInstructionFlags.NO_TRANSFER_INSTRUCTION_FLAGS


def _read_via_registry(class_id: int, version: UnityVersion, data: bytes):
    registry = default_registry()
    node = registry.get(class_id, version)
    assert node is not None, f"no layout registered for class {class_id} at {version}"
    structure = SerializableTreeType.from_root_node(node).create_serializable_structure()
    reader = EndianSpanReader(data)
    structure.read(reader, version, _NO_FLAGS)
    return structure, reader


def test_registry_has_no_entry_for_an_unregistered_class():
    assert default_registry().get(999999, UnityVersion(2019, 4, 0)) is None


def test_registry_has_no_entry_for_monobehaviour():
    """MonoBehaviour is deliberately never registered -- its layout is user-defined and
    can't be guessed from the class ID alone."""
    assert default_registry().get(114, UnityVersion(2019, 4, 0)) is None


def test_text_asset_layout():
    data = unity_string("Name") + unity_string("Script contents")
    structure, reader = _read_via_registry(49, UnityVersion(2019, 4, 0), data)
    assert structure["m_Name"] == "Name"
    assert structure["m_Script"] == "Script contents"
    assert reader.position == len(data)


def test_mono_script_layout():
    """Shape byte-verified against the real fixture on 2026-08-03 -- m_ExecutionOrder and
    m_PropertiesHash sit *between* m_Name and m_ClassName. This test previously encoded the
    old, wrong shape (those two fields omitted), which is exactly why the bug it would have
    caught went unnoticed: both sides of the contract were wrong in the same way. See
    layouts/mono_script.py's docstring for the real offsets."""
    data = (
        unity_string("MyScript")
        + struct.pack("<i", 7)  # m_ExecutionOrder
        + struct.pack("<4I", 1, 2, 3, 4)  # m_PropertiesHash (Hash128 == four uint32s)
        + unity_string("MyBehaviour")
        + unity_string("MyGame")
        + unity_string("Assembly-CSharp")
    )
    structure, reader = _read_via_registry(115, UnityVersion(2019, 4, 0), data)
    assert structure["m_Name"] == "MyScript"
    assert structure["m_ExecutionOrder"] == 7
    assert structure["m_PropertiesHash"]["m_u32_0"] == 1
    assert structure["m_PropertiesHash"]["m_u32_3"] == 4
    assert structure["m_ClassName"] == "MyBehaviour"
    assert structure["m_Namespace"] == "MyGame"
    assert structure["m_AssemblyName"] == "Assembly-CSharp"
    assert reader.position == len(data)


def test_mono_script_layout_is_not_registered_before_5_0():
    assert default_registry().get(115, UnityVersion(4, 7, 0)) is None


def test_game_object_layout():
    """Shape byte-verified against the real fixture on 2026-08-03: m_Component elements are
    bare 12-byte PPtrs (no `int first` -- that's the pre-5.5 shape), the tag is a UInt16
    m_Tag (not a m_TagString string, which is editor-format only), and m_IsActive carries no
    trailing align. Like test_mono_script_layout above, the previous version of this test
    encoded the same wrong shape the layout did."""
    data = (
        struct.pack("<i", 2)  # m_Component count
        + struct.pack("<i", 0) + struct.pack("<q", 100)  # first component (bare PPtr)
        + struct.pack("<i", 0) + struct.pack("<q", 200)  # second component
        + struct.pack("<i", 5)  # m_Layer
        + unity_string("Player")  # m_Name
        + struct.pack("<H", 3)  # m_Tag (UInt16)
        + b"\x01"  # m_IsActive -- last field, no trailing pad
    )
    structure, reader = _read_via_registry(1, UnityVersion(2019, 4, 0), data)
    components = structure["m_Component"]
    assert len(components) == 2
    assert components[0].path_id == 100
    assert components[1].path_id == 200
    assert structure["m_Layer"] == 5
    assert structure["m_Name"] == "Player"
    assert structure["m_Tag"] == 3
    assert structure["m_IsActive"] is True
    assert reader.position == len(data)


def test_game_object_layout_is_not_registered_before_5_5():
    assert default_registry().get(1, UnityVersion(5, 4, 0)) is None


def test_transform_layout_modern_has_no_root_order():
    data = (
        struct.pack("<i", 0) + struct.pack("<q", 42)  # m_GameObject
        + struct.pack("<4f", 0.0, 0.0, 0.0, 1.0)  # m_LocalRotation
        + struct.pack("<3f", 1.0, 2.0, 3.0)  # m_LocalPosition
        + struct.pack("<3f", 1.0, 1.0, 1.0)  # m_LocalScale
        + struct.pack("<i", 1) + struct.pack("<i", 0) + struct.pack("<q", 7)  # m_Children (1 entry)
        + struct.pack("<i", 0) + struct.pack("<q", 0)  # m_Father (null)
    )
    structure, reader = _read_via_registry(4, UnityVersion(2019, 4, 0), data)
    assert structure["m_GameObject"].path_id == 42
    assert structure["m_LocalPosition"]["x"] == 1.0
    assert len(structure["m_Children"]) == 1
    assert structure["m_Children"][0].path_id == 7
    assert structure["m_Father"].path_id == 0
    assert reader.position == len(data)


def test_transform_layout_legacy_has_root_order():
    data = (
        struct.pack("<i", 0) + struct.pack("<q", 42)  # m_GameObject
        + struct.pack("<4f", 0.0, 0.0, 0.0, 1.0)  # m_LocalRotation
        + struct.pack("<3f", 1.0, 2.0, 3.0)  # m_LocalPosition
        + struct.pack("<3f", 1.0, 1.0, 1.0)  # m_LocalScale
        + struct.pack("<i", 0)  # m_Children (empty)
        + struct.pack("<i", 0) + struct.pack("<q", 0)  # m_Father (null)
        + struct.pack("<i", 3)  # m_RootOrder
    )
    structure, reader = _read_via_registry(4, UnityVersion(2017, 4, 0), data)
    assert structure["m_RootOrder"] == 3
    assert reader.position == len(data)


def test_texture2d_layout_modern_mipmap_limit_group():
    """>=2022.2 shape -- byte-verified against a real fixture (see layouts/texture2d.py's
    docstring); this test uses a small synthetic payload of the same shape."""
    pixel_bytes = b"\xff" * 64  # 4x4 RGBA32
    data = (
        unity_string("MyTexture")
        + struct.pack("<i", 4)  # m_ForcedFallbackFormat
        + b"\x00\x00"  # m_DownscaleFallback, m_IsAlphaChannelOptional
        + b"\x00\x00"  # align to 4
        + struct.pack("<i", 4)  # m_Width
        + struct.pack("<i", 4)  # m_Height
        + struct.pack("<i", 64)  # m_CompleteImageSize
        + struct.pack("<i", 0)  # m_MipsStripped
        + struct.pack("<i", 4)  # m_TextureFormat (RGBA32)
        + struct.pack("<i", 1)  # m_MipCount
        + b"\x00\x00"  # m_IsReadable, m_IsPreProcessed
        + b"\x00"  # m_IgnoreMipmapLimit
        + unity_string("") + b"\x00"  # m_MipmapLimitGroupName (starts unaligned at offset 51,
        # so its own trailing align pad is 1 byte here, not the 0 unity_string("") computes on
        # its own assuming a 4-aligned start)
        + b"\x00"  # m_StreamingMipmaps
        + b"\x00\x00\x00"  # align to 4
        + struct.pack("<i", 0)  # m_StreamingMipmapsPriority
        + struct.pack("<i", 1)  # m_ImageCount
        + struct.pack("<i", 2)  # m_TextureDimension
        + struct.pack("<iif", 1, 1, 0.0) + struct.pack("<iii", 0, 0, 0)  # GLTextureSettings
        + struct.pack("<i", 0)  # m_LightmapFormat
        + struct.pack("<i", 1)  # m_ColorSpace
        + struct.pack("<i", 0)  # m_PlatformBlob (empty)
        + struct.pack("<i", 64) + pixel_bytes  # "image data"
        + struct.pack("<q", 0) + struct.pack("<I", 0) + unity_string("")  # m_StreamData
    )
    structure, reader = _read_via_registry(28, UnityVersion(2022, 3, 62), data)
    assert structure["m_Name"] == "MyTexture"
    assert structure["m_Width"] == 4
    assert structure["m_Height"] == 4
    assert structure["m_TextureFormat"] == 4
    assert bytes(structure["image data"]) == pixel_bytes
    assert structure["m_StreamData"]["path"] == ""
    assert reader.position == len(data)


def test_texture2d_layout_is_not_registered_before_2019_3():
    assert default_registry().get(28, UnityVersion(2018, 4, 0)) is None


def test_audio_clip_layout():
    data = (
        unity_string("MySound")
        + struct.pack("<i", 0)  # m_LoadType
        + struct.pack("<i", 1)  # m_Channels
        + struct.pack("<i", 44100)  # m_Frequency
        + struct.pack("<i", 16)  # m_BitsPerSample
        + struct.pack("<f", 1.5)  # m_Length
        + b"\x00\x00\x00\x00"  # m_IsTrackerFormat + align
        + struct.pack("<i", 0)  # m_SubsoundIndex
        + b"\x01\x00\x01\x00"  # m_PreloadAudioData, m_LoadInBackground, m_Legacy3D, align
        + unity_string("test.resource")  # m_Resource.m_Source
        + struct.pack("<q", 100)  # m_Resource.m_Offset
        + struct.pack("<q", 200)  # m_Resource.m_Size
        + struct.pack("<i", 1)  # m_CompressionFormat
    )
    structure, reader = _read_via_registry(83, UnityVersion(2022, 3, 62), data)
    assert structure["m_Name"] == "MySound"
    assert structure["m_Channels"] == 1
    assert structure["m_Frequency"] == 44100
    resource = structure["m_Resource"]
    assert resource["m_Source"] == "test.resource"
    assert resource["m_Offset"] == 100
    assert resource["m_Size"] == 200
    assert structure["m_CompressionFormat"] == 1
    assert reader.position == len(data)


def test_audio_clip_layout_is_not_registered_before_5_0():
    assert default_registry().get(83, UnityVersion(4, 7, 0)) is None


def test_sprite_layout_minimal():
    """All optional child arrays empty -- exercises the full field sequence without needing
    to hand-construct SubMesh/VertexData/PhysicsShape element payloads. See
    layouts/sprite.py's docstring for what's byte-verified against a real fixture (this
    synthetic payload mirrors that shape, not the real bytes)."""
    data = (
        unity_string("MySprite")
        + struct.pack("<4f", 0.0, 0.0, 32.0, 32.0)  # m_Rect
        + struct.pack("<2f", 0.0, 0.0)  # m_Offset
        + struct.pack("<4f", 0.0, 0.0, 0.0, 0.0)  # m_Border
        + struct.pack("<f", 100.0)  # m_PixelsToUnits
        + struct.pack("<2f", 0.5, 0.5)  # m_Pivot
        + struct.pack("<I", 1)  # m_Extrude
        + b"\x00\x00\x00\x00"  # m_IsPolygon + align
        + struct.pack("<4I", 1, 2, 3, 4) + struct.pack("<q", 99)  # m_RenderDataKey
        + struct.pack("<i", 0)  # m_AtlasTags (empty)
        + struct.pack("<i", 0) + struct.pack("<q", 0)  # m_SpriteAtlas (null)
        # m_RD (SpriteRenderData)
        + struct.pack("<i", 0) + struct.pack("<q", 10)  # texture
        + struct.pack("<i", 0) + struct.pack("<q", 0)  # alphaTexture
        + struct.pack("<i", 0)  # secondaryTextures (empty)
        + struct.pack("<i", 0)  # m_SubMeshes (empty)
        + struct.pack("<i", 0)  # m_IndexBuffer (empty) -- no align needed, already aligned
        + struct.pack("<I", 4)  # m_VertexData.m_VertexCount
        + struct.pack("<i", 0)  # m_VertexData.m_Channels (empty)
        + struct.pack("<i", 0)  # m_VertexData.m_DataSize (empty)
        + struct.pack("<i", 0)  # m_Bindpose (empty)
        + struct.pack("<4f", 0.0, 0.0, 32.0, 32.0)  # textureRect
        + struct.pack("<2f", 0.0, 0.0)  # textureRectOffset
        + struct.pack("<2f", 0.0, 0.0)  # atlasRectOffset
        + struct.pack("<I", 0)  # settingsRaw
        + struct.pack("<4f", 0.0, 0.0, 0.0, 0.0)  # uvTransform
        + struct.pack("<f", 1.0)  # downscaleMultiplier
        + struct.pack("<i", 0)  # m_PhysicsShape (empty)
        + struct.pack("<i", 0)  # m_Bones (empty)
    )
    structure, reader = _read_via_registry(213, UnityVersion(2022, 3, 62), data)
    assert structure["m_Name"] == "MySprite"
    assert structure["m_Rect"]["width"] == 32.0
    assert structure["m_Pivot"]["x"] == 0.5
    assert structure["m_RD"]["texture"].path_id == 10
    assert structure["m_RD"]["m_VertexData"]["m_VertexCount"] == 4
    assert reader.position == len(data)


def test_sprite_layout_is_not_registered_before_2017():
    assert default_registry().get(213, UnityVersion(5, 6, 0)) is None


def test_material_layout_minimal():
    """All optional arrays empty -- see layouts/material.py's docstring for what's
    byte-verified against a real fixture."""
    data = (
        unity_string("MyMaterial")
        + struct.pack("<i", 0) + struct.pack("<q", 1)  # m_Shader
        + struct.pack("<i", 0)  # m_ValidKeywords (empty)
        + struct.pack("<i", 0)  # m_InvalidKeywords (empty)
        + struct.pack("<I", 0)  # m_LightmapFlags
        + b"\x01\x00\x00\x00"  # m_EnableInstancingVariants + align
        + struct.pack("<i", -1)  # m_CustomRenderQueue
        + struct.pack("<i", 0)  # stringTagMap (empty)
        + struct.pack("<i", 0)  # disabledShaderPasses (empty)
        + struct.pack("<i", 0)  # m_SavedProperties.m_TexEnvs (empty)
        + struct.pack("<i", 0)  # m_SavedProperties.m_Ints (empty)
        + struct.pack("<i", 0)  # m_SavedProperties.m_Floats (empty)
        + struct.pack("<i", 0)  # m_SavedProperties.m_Colors (empty)
        + struct.pack("<i", 0)  # m_BuildTextureStacks (empty)
    )
    structure, reader = _read_via_registry(21, UnityVersion(2022, 3, 62), data)
    assert structure["m_Name"] == "MyMaterial"
    assert structure["m_Shader"].path_id == 1
    assert structure["m_CustomRenderQueue"] == -1
    assert structure["m_SavedProperties"]["m_Floats"] == []
    assert reader.position == len(data)


def test_material_layout_is_not_registered_before_2021_3():
    assert default_registry().get(21, UnityVersion(2021, 2, 0)) is None


def test_asset_bundle_layout():
    data = (
        unity_string("MyBundle")  # m_Name
        + struct.pack("<i", 1) + struct.pack("<i", 0) + struct.pack("<q", 55)  # m_PreloadTable (1 entry)
        + struct.pack("<i", 1)  # m_Container count
        + unity_string("assets/prefab.prefab")  # key
        + struct.pack("<ii", 0, 1) + struct.pack("<i", 0) + struct.pack("<q", 55)  # AssetInfo
        + struct.pack("<ii", 0, 0) + struct.pack("<i", 0) + struct.pack("<q", 55)  # m_MainAsset
        + struct.pack("<I", 5)  # m_RuntimeCompatibility
        + unity_string("mybundle")  # m_AssetBundleName
        + struct.pack("<i", 0)  # m_Dependencies (empty)
    )
    structure, reader = _read_via_registry(142, UnityVersion(2019, 4, 0), data)
    assert structure["m_Name"] == "MyBundle"
    assert len(structure["m_PreloadTable"]) == 1
    container = structure["m_Container"]
    assert len(container) == 1
    assert container[0].first.value == "assets/prefab.prefab"
    assert container[0].second.value["asset"].path_id == 55
    assert structure["m_MainAsset"]["asset"].path_id == 55
    assert structure["m_RuntimeCompatibility"] == 5
    assert structure["m_AssetBundleName"] == "mybundle"
    assert structure["m_Dependencies"] == []
    assert reader.position == len(data)


def _empty_packed_float_vector() -> bytes:
    return struct.pack("<Iff", 0, 0.0, 0.0) + struct.pack("<i", 0) + b"\x00" + b"\x00\x00\x00"


def _empty_packed_int_vector() -> bytes:
    return struct.pack("<I", 0) + struct.pack("<i", 0) + b"\x00" + b"\x00\x00\x00"


def test_mesh_layout_minimal():
    """All optional arrays/sub-structures empty -- see layouts/mesh.py's docstring for what's
    byte-verified against a real fixture (29 real Meshes; this synthetic payload mirrors that
    shape, not the real bytes). Uses `UnityVersion(2022, 3, 62)` so the `m_CookingOptions`
    (2022.1+) branch is exercised too."""
    data = (
        unity_string("MyMesh")  # m_Name
        + struct.pack("<i", 0)  # m_SubMeshes (empty)
        + struct.pack("<i", 0) * 4  # m_Shapes: vertices/shapes/channels/fullWeights all empty
        + struct.pack("<i", 0)  # m_BindPose (empty)
        + struct.pack("<i", 0)  # m_BoneNameHashes (empty)
        + struct.pack("<I", 0)  # m_RootBoneNameHash
        + struct.pack("<i", 0)  # m_BonesAABB (empty)
        + struct.pack("<i", 0)  # m_VariableBoneCountWeights (empty)
        + b"\x00\x01\x00\x00"  # m_MeshCompression=0, m_IsReadable=1, m_KeepVertices=0, m_KeepIndices=0 + align (no-op)
        + struct.pack("<i", 0)  # m_IndexFormat
        + struct.pack("<i", 0)  # m_IndexBuffer (empty)
        + struct.pack("<I", 4)  # VertexData.m_VertexCount
        + struct.pack("<i", 0)  # VertexData.m_Channels (empty)
        + struct.pack("<i", 0)  # VertexData.m_DataSize (empty)
        # CompressedMesh: 5 PackedFloatVector, then 5 PackedIntVector, then m_UVInfo
        + _empty_packed_float_vector() * 4  # m_Vertices, m_UV, m_Normals, m_Tangents
        + _empty_packed_int_vector() * 3  # m_Weights, m_NormalSigns, m_TangentSigns
        + _empty_packed_float_vector()  # m_FloatColors
        + _empty_packed_int_vector() * 2  # m_BoneIndices, m_Triangles
        + struct.pack("<I", 0)  # m_UVInfo
        + struct.pack("<3f", 0.0, 0.0, 0.0) + struct.pack("<3f", 1.0, 1.0, 1.0)  # m_LocalAABB
        + struct.pack("<i", 0)  # m_MeshUsageFlags
        + struct.pack("<i", 30)  # m_CookingOptions (2022.1+)
        + struct.pack("<i", 0)  # m_BakedConvexCollisionMesh (empty)
        + struct.pack("<i", 0)  # m_BakedTriangleCollisionMesh (empty)
        + struct.pack("<2f", 12.5, 1.0)  # m_MeshMetrics
        + struct.pack("<q", 0) + struct.pack("<I", 0) + struct.pack("<i", 0)  # m_StreamData (offset, size, empty path)
    )
    structure, reader = _read_via_registry(43, UnityVersion(2022, 3, 62), data)
    assert structure["m_Name"] == "MyMesh"
    assert structure["m_SubMeshes"] == []
    assert structure["m_VertexData"]["m_VertexCount"] == 4
    assert structure["m_MeshUsageFlags"] == 0
    assert reader.position == len(data)


def test_mesh_layout_with_a_submesh():
    """Exercises the one non-trivial repeated struct (`SubMesh`) that real Meshes always have
    at least one of."""
    data = (
        unity_string("MyMesh")
        + struct.pack("<i", 1)  # m_SubMeshes count
        + struct.pack("<II", 0, 6)  # firstByte, indexCount
        + struct.pack("<i", 0)  # topology (Triangles)
        + struct.pack("<III", 0, 0, 4)  # baseVertex, firstVertex, vertexCount
        + struct.pack("<3f", 0.0, 0.0, 0.0) + struct.pack("<3f", 1.0, 1.0, 1.0)  # localAABB
        + struct.pack("<i", 0) * 4  # m_Shapes (empty)
        + struct.pack("<i", 0)  # m_BindPose (empty)
        + struct.pack("<i", 0)  # m_BoneNameHashes (empty)
        + struct.pack("<I", 0)  # m_RootBoneNameHash
        + struct.pack("<i", 0)  # m_BonesAABB (empty)
        + struct.pack("<i", 0)  # m_VariableBoneCountWeights (empty)
        + b"\x00\x00\x00\x00"  # compression/readable/keepverts/keepindices
        + struct.pack("<i", 0)  # m_IndexFormat
        + struct.pack("<i", 12) + b"\x00" * 12  # m_IndexBuffer (12 bytes, already aligned)
        + struct.pack("<I", 4)  # VertexData.m_VertexCount
        + struct.pack("<i", 0)  # VertexData.m_Channels (empty)
        + struct.pack("<i", 0)  # VertexData.m_DataSize (empty)
        + _empty_packed_float_vector() * 4
        + _empty_packed_int_vector() * 3
        + _empty_packed_float_vector()
        + _empty_packed_int_vector() * 2
        + struct.pack("<I", 0)
        + struct.pack("<3f", 0.0, 0.0, 0.0) + struct.pack("<3f", 1.0, 1.0, 1.0)
        + struct.pack("<i", 0)
        + struct.pack("<i", 30)
        + struct.pack("<i", 0)
        + struct.pack("<i", 0)
        + struct.pack("<2f", 5.0, 1.0)
        + struct.pack("<q", 0) + struct.pack("<I", 0) + struct.pack("<i", 0)
    )
    structure, reader = _read_via_registry(43, UnityVersion(2022, 3, 62), data)
    submeshes = structure["m_SubMeshes"]
    assert len(submeshes) == 1
    assert submeshes[0]["indexCount"] == 6
    assert submeshes[0]["vertexCount"] == 4
    assert reader.position == len(data)


def test_mesh_layout_is_not_registered_before_2019_1():
    assert default_registry().get(43, UnityVersion(2018, 4, 0)) is None

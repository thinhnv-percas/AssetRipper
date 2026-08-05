"""End-to-end tests for Phase 9 (streamed data): Texture2D/AudioClip/Mesh assets whose
inline payload field is empty and whose actual bytes live in an external ResourceFile
(`.resS`), referenced via `m_StreamData` (StreamingInfo) or `m_Resource` (StreamedResource).
Before this phase, all three exporters declined outright whenever the inline field was
empty -- which is the common case on real Unity player builds.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.resource_files.resource_file import ResourceFile
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion
from PIL import Image
import io

from import_._tree_builder import node, pad_to_4, string_nodes, tree, unity_array, unity_string, vector_nodes

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)


def _build_bundle(class_id: int, tree_nodes, payload: bytes) -> GameBundle:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = class_id
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = tree_nodes

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = payload

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return game_bundle


def _export(game_bundle, tmp_path):
    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)


# --- Texture2D (class 28): m_Width, m_Height, m_TextureFormat, "image data" (empty),
# m_StreamData {offset, size, path}. ---
_TEXTURE_2D_STREAMED_TREE = tree(
    node("Texture2D", "Base", 0),
    node("int", "m_Width", 1),
    node("int", "m_Height", 1),
    node("int", "m_TextureFormat", 1),
    node("vector", "image data", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    node("UInt8", "data", 3),
    node("StreamingInfo", "m_StreamData", 1),
    node("unsigned int", "offset", 2),
    node("unsigned int", "size", 2),
    *string_nodes("path", 2),
)


def test_texture2d_falls_back_to_stream_data_when_image_data_is_empty(tmp_path):
    # 2x1 RGBA32 texture: red pixel, green pixel.
    pixel_data = bytes([255, 0, 0, 255, 0, 255, 0, 255])
    resource_bytes = b"junk-prefix" + pixel_data
    offset = len(b"junk-prefix")

    payload = (
        struct.pack("<iii", 2, 1, 4)  # width, height, TextureFormat.RGBA32
        + unity_array("B", b"")  # "image data" is empty
        + struct.pack("<II", offset, len(pixel_data))
        + unity_string("CAB-tex.resS")
    )
    game_bundle = _build_bundle(28, _TEXTURE_2D_STREAMED_TREE, payload)
    game_bundle.add_resource(ResourceFile.from_bytes(resource_bytes, "/does/not/matter", "CAB-tex.resS"))

    _export(game_bundle, tmp_path)

    png_files = [p for p in tmp_path.rglob("*.png") if p.is_file()]
    assert len(png_files) == 1
    image = Image.open(io.BytesIO(png_files[0].read_bytes()))
    assert image.convert("RGBA").getpixel((0, 0)) == (255, 0, 0, 255)
    assert image.convert("RGBA").getpixel((1, 0)) == (0, 255, 0, 255)


def test_texture2d_with_no_resolvable_resource_is_not_exported(tmp_path):
    payload = (
        struct.pack("<iii", 2, 1, 4)
        + unity_array("B", b"")
        + struct.pack("<II", 0, 8)
        + unity_string("missing.resS")
    )
    game_bundle = _build_bundle(28, _TEXTURE_2D_STREAMED_TREE, payload)
    # No ResourceFile added -- resolve_resource will fail.

    _export(game_bundle, tmp_path)

    assert [p for p in tmp_path.rglob("*.png") if p.is_file()] == []


# --- AudioClip (class 83): m_Name, m_AudioData (empty), m_CompressionFormat,
# m_Resource {m_Source, m_Offset, m_Size}. ---
_AUDIO_CLIP_STREAMED_TREE = tree(
    node("AudioClip", "Base", 0),
    *string_nodes("m_Name", 1),
    *vector_nodes("m_AudioData", "UInt8", 1),
    node("int", "m_CompressionFormat", 1),
    node("StreamedResource", "m_Resource", 1),
    *string_nodes("m_Source", 2),
    node("unsigned int", "m_Offset", 2),
    node("unsigned int", "m_Size", 2),
)


def test_audio_clip_falls_back_to_resource_when_audio_data_is_empty(tmp_path):
    fsb_bytes = b"FSB5" + b"\x00" * 20
    resource_bytes = b"header-junk" + fsb_bytes
    offset = len(b"header-junk")

    payload = (
        unity_string("Explosion")
        + pad_to_4(unity_array("B", b""))  # m_AudioData is empty
        + struct.pack("<i", 0)  # m_CompressionFormat
        + unity_string("CAB-audio.resS")
        + struct.pack("<II", offset, len(fsb_bytes))
    )
    game_bundle = _build_bundle(83, _AUDIO_CLIP_STREAMED_TREE, payload)
    game_bundle.add_resource(ResourceFile.from_bytes(resource_bytes, "/does/not/matter", "CAB-audio.resS"))

    _export(game_bundle, tmp_path)

    fsb_files = [p for p in tmp_path.rglob("*.fsb") if p.is_file()]
    assert len(fsb_files) == 1
    assert fsb_files[0].read_bytes() == fsb_bytes


def test_audio_clip_with_no_resolvable_resource_is_not_exported(tmp_path):
    payload = (
        unity_string("Explosion")
        + pad_to_4(unity_array("B", b""))
        + struct.pack("<i", 0)
        + unity_string("missing.resS")
        + struct.pack("<II", 0, 24)
    )
    game_bundle = _build_bundle(83, _AUDIO_CLIP_STREAMED_TREE, payload)

    _export(game_bundle, tmp_path)

    assert [p for p in tmp_path.rglob("*.fsb") if p.is_file()] == []


# --- Mesh (class 43): m_SubMeshes, m_IndexBuffer, m_IndexFormat, m_VertexData (with
# m_DataSize empty), m_StreamData {offset, size, path}. ---
_MESH_STREAMED_TREE = tree(
    node("Mesh", "Base", 0),
    *string_nodes("m_Name", 1),
    node("vector", "m_SubMeshes", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    node("SubMesh", "data", 3),
    node("int", "firstByte", 4),
    node("int", "indexCount", 4),
    node("int", "topology", 4),
    *vector_nodes("m_IndexBuffer", "UInt8", 1),
    node("int", "m_IndexFormat", 1),
    node("VertexData", "m_VertexData", 1),
    node("int", "m_VertexCount", 2),
    node("vector", "m_Channels", 2),
    node("Array", "Array", 3),
    node("int", "size", 4),
    node("ChannelInfo", "data", 4),
    node("UInt8", "stream", 5),
    node("UInt8", "offset", 5),
    node("UInt8", "format", 5),
    node("UInt8", "dimension", 5),
    *vector_nodes("m_DataSize", "UInt8", 2),
    node("StreamingInfo", "m_StreamData", 1),
    node("unsigned int", "offset", 2),
    node("unsigned int", "size", 2),
    *string_nodes("path", 2),
)


def _one_submesh(first_byte: int, index_count: int, topology: int) -> bytes:
    return struct.pack("<i", 1) + struct.pack("<3i", first_byte, index_count, topology)


def _one_channel(stream: int, offset: int, format_: int, dimension: int) -> bytes:
    return struct.pack("<i", 1) + struct.pack("<4B", stream, offset, format_, dimension)


def test_mesh_falls_back_to_stream_data_when_data_size_is_empty(tmp_path):
    positions = [(0.0, 0.0, 0.0), (1.0, 0.0, 0.0), (0.0, 1.0, 0.0)]
    position_bytes = b"".join(struct.pack("<3f", *p) for p in positions)
    resource_bytes = b"leading-junk-bytes" + position_bytes
    offset = len(b"leading-junk-bytes")

    index_bytes = b"".join(struct.pack("<H", i) for i in (0, 1, 2))

    payload = (
        unity_string("TriangleMesh")
        + _one_submesh(0, 3, 0)  # topology 0 = TRIANGLES
        + pad_to_4(unity_array("B", index_bytes))
        + struct.pack("<i", 0)  # m_IndexFormat = UInt16
        + struct.pack("<i", 3)  # m_VertexData.m_VertexCount
        + _one_channel(0, 0, 0, 3)  # position channel: stream 0, offset 0, FLOAT, dim 3
        + pad_to_4(unity_array("B", b""))  # m_VertexData.m_DataSize is empty
        + struct.pack("<II", offset, len(position_bytes))
        + unity_string("CAB-mesh.resS")
    )
    game_bundle = _build_bundle(43, _MESH_STREAMED_TREE, payload)
    game_bundle.add_resource(ResourceFile.from_bytes(resource_bytes, "/does/not/matter", "CAB-mesh.resS"))

    _export(game_bundle, tmp_path)

    glb_files = [p for p in tmp_path.rglob("*.glb") if p.is_file()]
    assert len(glb_files) == 1


def test_mesh_with_no_resolvable_resource_is_not_exported(tmp_path):
    index_bytes = b"".join(struct.pack("<H", i) for i in (0, 1, 2))
    payload = (
        unity_string("TriangleMesh")
        + _one_submesh(0, 3, 0)
        + pad_to_4(unity_array("B", index_bytes))
        + struct.pack("<i", 0)
        + struct.pack("<i", 3)
        + _one_channel(0, 0, 0, 3)
        + pad_to_4(unity_array("B", b""))
        + struct.pack("<II", 0, 36)
        + unity_string("missing.resS")
    )
    game_bundle = _build_bundle(43, _MESH_STREAMED_TREE, payload)

    _export(game_bundle, tmp_path)

    assert [p for p in tmp_path.rglob("*.glb") if p.is_file()] == []

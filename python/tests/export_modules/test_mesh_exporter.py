"""End-to-end test for the Mesh content exporter (Export phase 6c-4): a synthetic,
uncompressed single-triangle Mesh driven through the real dynamic reader and the full
ProjectExporter pipeline, verifying a valid .glb + .meta pair is produced.
"""
import json
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, pad_to_4, string_nodes, tree, unity_array, unity_string, vector_nodes

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)
_MESH_CLASS_ID = 43

_MESH_TREE = tree(
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
)


def _one_submesh(first_byte: int, index_count: int, topology: int) -> bytes:
    return struct.pack("<i", 1) + struct.pack("<3i", first_byte, index_count, topology)


def _one_channel(stream: int, offset: int, format_: int, dimension: int) -> bytes:
    return struct.pack("<i", 1) + struct.pack("<4B", stream, offset, format_, dimension)


def _build_mesh_payload(name: str, positions, index_format: int, index_buffer_ushorts):
    vertex_count = len(positions)
    position_bytes = b"".join(struct.pack("<3f", *p) for p in positions)
    index_bytes = b"".join(struct.pack("<H", i) for i in index_buffer_ushorts) if index_format == 0 else \
        b"".join(struct.pack("<I", i) for i in index_buffer_ushorts)

    return (
        unity_string(name)
        + _one_submesh(0, len(index_buffer_ushorts), 0)  # topology 0 = TRIANGLES
        # Unity >= 2017 4-byte-aligns every primitive vector after it's read (a version-gated
        # rule baked into the reader itself, independent of the ALIGN_BYTES meta flag) --
        # see endian_span_reader_extensions.is_align_arrays. m_IndexBuffer/m_DataSize are
        # vector<UInt8>, so this test's hand-packed bytes must include that trailing padding.
        + pad_to_4(unity_array("B", index_bytes))
        + struct.pack("<i", index_format)
        + struct.pack("<i", vertex_count)  # m_VertexData.m_VertexCount
        + _one_channel(0, 0, 0, 3)  # stream=0, offset=0, format=FLOAT, dimension=3 (position)
        + pad_to_4(unity_array("B", position_bytes))  # m_VertexData.m_DataSize
    )


def _build_and_export(tmp_path, payload: bytes):
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = _MESH_CLASS_ID
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _MESH_TREE

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

    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)


def _parse_glb(data: bytes):
    _magic, _version, _total_length = struct.unpack_from("<III", data, 0)
    json_length, _json_type = struct.unpack_from("<II", data, 12)
    document = json.loads(data[20:20 + json_length])
    offset = 20 + json_length
    bin_length, _bin_type = struct.unpack_from("<II", data, offset)
    binary_data = data[offset + 8:offset + 8 + bin_length]
    return document, binary_data


def test_triangle_mesh_exports_as_valid_glb(tmp_path):
    payload = _build_mesh_payload(
        "TriangleMesh",
        positions=[(0.0, 0.0, 0.0), (1.0, 0.0, 0.0), (0.0, 1.0, 0.0)],
        index_format=0,
        index_buffer_ushorts=[0, 1, 2],
    )
    _build_and_export(tmp_path, payload)

    glb_files = [p for p in tmp_path.rglob("*.glb") if p.is_file()]
    assert len(glb_files) == 1

    document, binary_data = _parse_glb(glb_files[0].read_bytes())
    assert document["asset"]["version"] == "2.0"
    assert document["nodes"][0]["name"] == "TriangleMesh"
    assert len(document["meshes"]) == 1

    primitive = document["meshes"][0]["primitives"][0]
    assert set(primitive["attributes"]) == {"POSITION"}
    position_accessor = document["accessors"][primitive["attributes"]["POSITION"]]
    assert position_accessor["count"] == 3

    meta_path = glb_files[0].with_name(glb_files[0].name + ".meta")
    assert meta_path.exists()


def test_mesh_with_32_bit_indices_exports_correctly(tmp_path):
    payload = _build_mesh_payload(
        "BigMesh",
        positions=[(0.0, 0.0, 0.0), (1.0, 0.0, 0.0), (0.0, 1.0, 0.0)],
        index_format=1,
        index_buffer_ushorts=[0, 1, 2],
    )
    _build_and_export(tmp_path, payload)

    glb_files = [p for p in tmp_path.rglob("*.glb") if p.is_file()]
    assert len(glb_files) == 1
    document, _binary_data = _parse_glb(glb_files[0].read_bytes())
    assert document["accessors"][0]["count"] == 3

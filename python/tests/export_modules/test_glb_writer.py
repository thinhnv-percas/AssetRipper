import json
import struct

from assetripper_export_modules.meshes.glb_writer import build_glb
from assetripper_export_modules.meshes.mesh_data import MeshData, SubMeshInfo
from assetripper_export_modules.meshes.mesh_topology import MeshTopology


def _parse_glb(data: bytes):
    magic, version, total_length = struct.unpack_from("<III", data, 0)
    assert magic == 0x46546C67
    assert version == 2
    assert total_length == len(data)

    offset = 12
    json_length, json_type = struct.unpack_from("<II", data, offset)
    assert json_type == 0x4E4F534A
    offset += 8
    json_bytes = data[offset:offset + json_length]
    document = json.loads(json_bytes)
    offset += json_length

    binary_data = b""
    if offset < len(data):
        bin_length, bin_type = struct.unpack_from("<II", data, offset)
        assert bin_type == 0x004E4942
        offset += 8
        binary_data = data[offset:offset + bin_length]

    return document, binary_data


def _triangle_mesh() -> MeshData:
    return MeshData(
        vertices=[(0.0, 0.0, 0.0), (1.0, 0.0, 0.0), (0.0, 1.0, 0.0)],
        index_buffer=[0, 1, 2],
        submeshes=[SubMeshInfo(first_index=0, index_count=3, topology=MeshTopology.TRIANGLES)],
    )


def test_glb_header_and_chunk_alignment():
    data = build_glb("Triangle", _triangle_mesh())
    assert data[:4] == b"glTF"
    assert len(data) % 4 == 0

    document, binary_data = _parse_glb(data)
    assert document["asset"]["version"] == "2.0"
    assert len(binary_data) % 4 == 0


def test_glb_position_only_mesh_has_one_mesh_and_primitive():
    data = build_glb("Triangle", _triangle_mesh())
    document, _binary_data = _parse_glb(data)

    assert len(document["meshes"]) == 1
    primitive = document["meshes"][0]["primitives"][0]
    assert set(primitive["attributes"]) == {"POSITION"}
    assert primitive["mode"] == 4  # TRIANGLES

    position_accessor = document["accessors"][primitive["attributes"]["POSITION"]]
    assert position_accessor["count"] == 3
    assert position_accessor["type"] == "VEC3"


def test_glb_coordinate_conversion_negates_x():
    data = build_glb("Triangle", _triangle_mesh())
    document, binary_data = _parse_glb(data)

    primitive = document["meshes"][0]["primitives"][0]
    accessor = document["accessors"][primitive["attributes"]["POSITION"]]
    view = document["bufferViews"][accessor["bufferView"]]
    raw = binary_data[view["byteOffset"]:view["byteOffset"] + view["byteLength"]]
    positions = [struct.unpack_from("<3f", raw, i * 12) for i in range(3)]

    assert positions[0] == (0.0, 0.0, 0.0)
    assert positions[1] == (-1.0, 0.0, 0.0)  # Unity's +X becomes glTF's -X
    assert positions[2] == (0.0, 1.0, 0.0)


def test_glb_indices_are_reversed_and_unsigned_int():
    data = build_glb("Triangle", _triangle_mesh())
    document, binary_data = _parse_glb(data)

    primitive = document["meshes"][0]["primitives"][0]
    accessor = document["accessors"][primitive["indices"]]
    assert accessor["componentType"] == 5125  # UNSIGNED_INT
    view = document["bufferViews"][accessor["bufferView"]]
    raw = binary_data[view["byteOffset"]:view["byteOffset"] + view["byteLength"]]
    indices = struct.unpack_from("<3I", raw)
    assert indices == (2, 1, 0)


def test_glb_node_hierarchy_has_root_and_submesh_child():
    data = build_glb("MyMesh", _triangle_mesh())
    document, _binary_data = _parse_glb(data)

    assert document["nodes"][0]["name"] == "MyMesh"
    assert document["nodes"][0]["children"] == [1]
    assert document["nodes"][1]["name"] == "SubMesh_0"
    assert document["nodes"][1]["mesh"] == 0


def test_glb_with_normals_and_uv_adds_attributes():
    mesh_data = MeshData(
        vertices=[(0.0, 0.0, 0.0), (1.0, 0.0, 0.0), (0.0, 1.0, 0.0)],
        normals=[(0.0, 0.0, 1.0)] * 3,
        index_buffer=[0, 1, 2],
        submeshes=[SubMeshInfo(first_index=0, index_count=3, topology=MeshTopology.TRIANGLES)],
    )
    mesh_data.uvs[0] = [(0.1, 0.2), (0.3, 0.4), (0.5, 0.6)]

    data = build_glb("Triangle", mesh_data)
    document, _binary_data = _parse_glb(data)
    attributes = document["meshes"][0]["primitives"][0]["attributes"]
    assert "NORMAL" in attributes
    assert "TEXCOORD_0" in attributes
    assert "COLOR_0" not in attributes  # no real colors and UV count < 3


def test_glb_high_uv_count_adds_default_white_color():
    mesh_data = MeshData(
        vertices=[(0.0, 0.0, 0.0)] * 3,
        index_buffer=[0, 1, 2],
        submeshes=[SubMeshInfo(first_index=0, index_count=3, topology=MeshTopology.TRIANGLES)],
    )
    for i in range(3):
        mesh_data.uvs[i] = [(0.0, 0.0)] * 3

    data = build_glb("Triangle", mesh_data)
    document, binary_data = _parse_glb(data)
    attributes = document["meshes"][0]["primitives"][0]["attributes"]
    assert "COLOR_0" in attributes

    accessor = document["accessors"][attributes["COLOR_0"]]
    view = document["bufferViews"][accessor["bufferView"]]
    raw = binary_data[view["byteOffset"]:view["byteOffset"] + view["byteLength"]]
    assert struct.unpack_from("<4f", raw, 0) == (1.0, 1.0, 1.0, 1.0)


def test_glb_multiple_submeshes_produce_multiple_meshes_and_nodes():
    mesh_data = MeshData(
        vertices=[(0.0, 0.0, 0.0), (1.0, 0.0, 0.0), (0.0, 1.0, 0.0), (1.0, 1.0, 0.0)],
        index_buffer=[0, 1, 2, 1, 2, 3],
        submeshes=[
            SubMeshInfo(first_index=0, index_count=3, topology=MeshTopology.TRIANGLES),
            SubMeshInfo(first_index=3, index_count=3, topology=MeshTopology.TRIANGLES),
        ],
    )

    data = build_glb("MultiSub", mesh_data)
    document, _binary_data = _parse_glb(data)
    assert len(document["meshes"]) == 2
    assert document["nodes"][0]["children"] == [1, 2]

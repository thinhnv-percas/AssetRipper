"""Hand-written glTF 2.0 / GLB writer -- there is no C# counterpart to port here; upstream
delegates entirely to the SharpGLTF NuGet package (GlbWriter.cs just calls
`sceneBuilder.ToGltf2().WriteGLB(stream)`). Unlike the FSB5 container this port declines to
rebuild (see audio_clip_decoder.py), the glTF 2.0 / GLB binary layout is a public,
versioned, stable specification (https://registry.khronos.org/glTF/specs/2.0/), so writing
it by hand carries none of that format's guesswork risk.

Simplification versus upstream's SharpGLTF-based output (documented, not a fidelity loss
in the exported geometry itself): every submesh becomes its own glTF mesh with ONE
primitive, whose attribute accessors span the *entire* Mesh asset's vertex arrays rather
than a deduplicated, submesh-local vertex buffer -- valid per spec (an accessor may be
referenced by multiple primitives; the "indices" accessor need not start at 0), just
larger than a fully compacted export.

Indices are always emitted as UNSIGNED_INT (glTF component type 5125) regardless of vertex
count, rather than upstream's implicit 16-bit-when-possible sizing -- purely a storage
choice, not a data change.
"""
from __future__ import annotations

import json
import struct

from .mesh_data import MeshData, expand_submesh_primitives

_GLTF_MAGIC = 0x46546C67
_GLTF_VERSION = 2
_JSON_CHUNK_TYPE = 0x4E4F534A
_BIN_CHUNK_TYPE = 0x004E4942

_COMPONENT_TYPE_UNSIGNED_SHORT = 5123
_COMPONENT_TYPE_UNSIGNED_INT = 5125
_COMPONENT_TYPE_FLOAT = 5126

_MODE_POINTS = 0
_MODE_LINES = 1
_MODE_TRIANGLES = 4

_ARRAY_BUFFER = 34962
_ELEMENT_ARRAY_BUFFER = 34963


def _gltf_position(v: tuple) -> tuple:
    return (-v[0], v[1], v[2])


def _normalize3(v: tuple) -> tuple:
    length = (v[0] ** 2 + v[1] ** 2 + v[2] ** 2) ** 0.5
    if length == 0:
        return v
    return (v[0] / length, v[1] / length, v[2] / length)


def _gltf_normal(v: tuple) -> tuple:
    x, y, z = _normalize3(v)
    return (-x, y, z)


def _gltf_tangent(v: tuple) -> tuple:
    x, y, z = _normalize3((v[0], v[1], v[2]))
    return (-x, y, z, -v[3])


class _BufferBuilder:
    def __init__(self):
        self._chunks = bytearray()
        self.buffer_views = []
        self.accessors = []

    def _add_buffer_view(self, data: bytes, target: "int | None") -> int:
        view = {"buffer": 0, "byteOffset": len(self._chunks), "byteLength": len(data)}
        if target is not None:
            view["target"] = target
        self.buffer_views.append(view)
        self._chunks.extend(data)
        while len(self._chunks) % 4 != 0:
            self._chunks.append(0)
        return len(self.buffer_views) - 1

    def add_vec_accessor(self, vectors: list, component_type: int, dimension: str, fmt: str, with_bounds: bool = False) -> int:
        n = {"VEC2": 2, "VEC3": 3, "VEC4": 4}[dimension]
        data = bytearray()
        for vec in vectors:
            data.extend(struct.pack(f"<{n}{fmt}", *vec))
        view_index = self._add_buffer_view(bytes(data), _ARRAY_BUFFER)
        accessor = {
            "bufferView": view_index,
            "componentType": component_type,
            "count": len(vectors),
            "type": dimension,
        }
        if with_bounds and vectors:
            accessor["min"] = [min(v[i] for v in vectors) for i in range(n)]
            accessor["max"] = [max(v[i] for v in vectors) for i in range(n)]
        self.accessors.append(accessor)
        return len(self.accessors) - 1

    def add_scalar_index_accessor(self, indices: list) -> int:
        data = b"".join(struct.pack("<I", i) for i in indices)
        view_index = self._add_buffer_view(data, _ELEMENT_ARRAY_BUFFER)
        self.accessors.append({
            "bufferView": view_index,
            "componentType": _COMPONENT_TYPE_UNSIGNED_INT,
            "count": len(indices),
            "type": "SCALAR",
        })
        return len(self.accessors) - 1

    @property
    def data(self) -> bytes:
        return bytes(self._chunks)


def build_glb(mesh_name: str, mesh_data: MeshData) -> bytes:
    builder = _BufferBuilder()

    positions = [_gltf_position(v) for v in mesh_data.vertices]
    position_accessor = builder.add_vec_accessor(positions, _COMPONENT_TYPE_FLOAT, "VEC3", "f", with_bounds=True)

    attributes_template = {"POSITION": position_accessor}

    if mesh_data.has_normals:
        normals = [_gltf_normal(v) for v in mesh_data.normals]
        attributes_template["NORMAL"] = builder.add_vec_accessor(normals, _COMPONENT_TYPE_FLOAT, "VEC3", "f")

        if mesh_data.has_tangents:
            tangents = [_gltf_tangent(v) for v in mesh_data.tangents]
            attributes_template["TANGENT"] = builder.add_vec_accessor(tangents, _COMPONENT_TYPE_FLOAT, "VEC4", "f")

    uv_count = mesh_data.uv_count
    emit_color = mesh_data.has_colors or uv_count >= 3
    if emit_color:
        colors = mesh_data.colors if mesh_data.has_colors else [(1.0, 1.0, 1.0, 1.0)] * len(mesh_data.vertices)
        attributes_template["COLOR_0"] = builder.add_vec_accessor(colors, _COMPONENT_TYPE_FLOAT, "VEC4", "f")

    for i in range(uv_count):
        attributes_template[f"TEXCOORD_{i}"] = builder.add_vec_accessor(
            mesh_data.uvs[i], _COMPONENT_TYPE_FLOAT, "VEC2", "f"
        )

    if mesh_data.has_skin:
        joints = [indices for indices, _weights in mesh_data.skin]
        weights = [weights for _indices, weights in mesh_data.skin]
        attributes_template["JOINTS_0"] = builder.add_vec_accessor(joints, _COMPONENT_TYPE_UNSIGNED_SHORT, "VEC4", "H")
        attributes_template["WEIGHTS_0"] = builder.add_vec_accessor(weights, _COMPONENT_TYPE_FLOAT, "VEC4", "f")

    meshes = []
    nodes = [{"name": mesh_name, "children": []}]
    for i, submesh in enumerate(mesh_data.submeshes):
        kind, primitive_indices = expand_submesh_primitives(mesh_data.index_buffer, submesh)
        if not primitive_indices:
            continue

        flat_indices = [index for tup in primitive_indices for index in tup]
        indices_accessor = builder.add_scalar_index_accessor(flat_indices)
        mode = {"triangles": _MODE_TRIANGLES, "lines": _MODE_LINES, "points": _MODE_POINTS}[kind]

        mesh_index = len(meshes)
        meshes.append({
            "primitives": [{
                "attributes": dict(attributes_template),
                "indices": indices_accessor,
                "mode": mode,
            }]
        })

        node_index = len(nodes)
        nodes.append({"name": f"SubMesh_{i}", "mesh": mesh_index})
        nodes[0]["children"].append(node_index)

    document = {
        "asset": {"version": "2.0", "generator": "AssetRipper Python port"},
        "scene": 0,
        "scenes": [{"nodes": [0]}],
        "nodes": nodes,
        "meshes": meshes,
        "accessors": builder.accessors,
        "bufferViews": builder.buffer_views,
        "buffers": [{"byteLength": len(builder.data)}],
    }

    return _write_glb(document, builder.data)


def _write_glb(document: dict, binary_data: bytes) -> bytes:
    json_bytes = json.dumps(document, separators=(",", ":")).encode("utf-8")
    while len(json_bytes) % 4 != 0:
        json_bytes += b" "

    binary_data = bytes(binary_data)
    while len(binary_data) % 4 != 0:
        binary_data += b"\x00"

    json_chunk = struct.pack("<II", len(json_bytes), _JSON_CHUNK_TYPE) + json_bytes
    bin_chunk = struct.pack("<II", len(binary_data), _BIN_CHUNK_TYPE) + binary_data if binary_data else b""

    total_length = 12 + len(json_chunk) + len(bin_chunk)
    header = struct.pack("<III", _GLTF_MAGIC, _GLTF_VERSION, total_length)
    return header + json_chunk + bin_chunk

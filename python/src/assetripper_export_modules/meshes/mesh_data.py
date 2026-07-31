"""Scoped-down port of the vertex-stream-unpacking half of Mesh export
(Source/AssetRipper.SourceGenerated.Extensions/{MeshData,VertexDataBlob,MeshHelper,
SubMeshExtensions}.cs and AssetRipper.Export.Modules.Models/MeshDataExtensions.cs).

What's ported: the uncompressed `m_VertexData` channel/stream layout (Unity >= 2018's
"only m_Channels, no explicit m_Streams" shape -- by far the common case for current
content), decoded exactly as VertexDataBlob.ReadData does: per-channel byte gather, format
conversion, the channel-index-to-attribute mapping (0=vertex, 1=normal, 2=tangent, 3=color,
4-11=UV0-7, 12=blend weight, 13=blend indices), tangent W-sign normalization, UV Y-flip, and
skin-weight validation/normalization -- all copied field-for-field from MeshData.cs's
TryGetTangentAtIndex/TryGetSkinAtIndex/FlipY.

What's declined (matching this project's precedent of declining an uncertain path rather
than guessing at it -- see texture2d_exporter.py's m_StreamData, audio_clip_exporter.py's
m_Resource): meshes whose only vertex data lives in `m_CompressedMesh` (Unity's mobile-
oriented Low/Medium/High MeshCompression settings). That container packs every channel
through a shared bit-packed `PackedBitVector` scheme with per-channel bit-width metadata;
decoding it is a substantial separate subsystem in its own right, and this repo does not
vendor enough of it to implement with confidence.

Also not ported: blend shapes, bind poses/skeleton hierarchy (the skin weight/index
*vertex attributes* are read, but no glTF `skin` object or joint-node hierarchy is
synthesized -- there is no scene graph to attach one to for a standalone per-Mesh export),
and pre-2018 (`m_Streams`-based) vertex layouts -- see vertex_format.py's docstring for the
same version cutoff and rationale.
"""
from __future__ import annotations

from dataclasses import dataclass, field

from .mesh_topology import MeshTopology
from .vertex_format import VertexFormat, bytes_to_float_array, bytes_to_int_array, get_format_size, is_int_format

_VERTEX_STREAM_ALIGN = 16


@dataclass
class SubMeshInfo:
    first_index: int
    index_count: int
    topology: MeshTopology


@dataclass
class MeshData:
    vertices: list
    normals: "list | None" = None
    tangents: "list | None" = None
    colors: "list | None" = None
    uvs: list = field(default_factory=lambda: [None] * 8)
    skin: "list | None" = None
    """list of (indices: tuple[int,int,int,int], weights: tuple[float,float,float,float])"""
    index_buffer: list = field(default_factory=list)
    submeshes: list = field(default_factory=list)

    @property
    def has_normals(self) -> bool:
        return self.normals is not None and len(self.normals) == len(self.vertices)

    @property
    def has_tangents(self) -> bool:
        return self.tangents is not None and len(self.tangents) == len(self.vertices)

    @property
    def has_colors(self) -> bool:
        return self.colors is not None and len(self.colors) == len(self.vertices)

    @property
    def has_skin(self) -> bool:
        return self.skin is not None and len(self.skin) == len(self.vertices)

    @property
    def uv_count(self) -> int:
        for i in range(8):
            if self.uvs[i] is None or len(self.uvs[i]) != len(self.vertices):
                return i
        return 8


def get_mesh_data(mesh) -> "MeshData | None":
    """Returns None when the mesh has no readable (uncompressed) vertex data -- see this
    module's docstring for what that excludes."""
    vertex_data = mesh.get("m_VertexData")
    if vertex_data is None:
        return None

    vertex_count = vertex_data.get("m_VertexCount") or 0
    channels = vertex_data.get("m_Channels")
    data = bytes(vertex_data.get("m_DataSize") or ())
    if not channels or vertex_count == 0 or not data:
        return None

    streams = _convert_channels_to_streams(channels, vertex_count)
    vertices, normals, tangents, colors, uvs, skin = _decode_channels(data, channels, streams, vertex_count)
    if vertices is None:
        return None

    tangents = [_fix_tangent_w(t) for t in tangents] if tangents is not None else None
    uvs = [[(u, 1.0 - v) for (u, v) in uv] if uv is not None else None for uv in uvs]
    skin = [_fix_skin(indices, weights) for indices, weights in skin] if skin is not None else None

    index_buffer = _read_index_buffer(mesh)
    submeshes = _read_submeshes(mesh)

    return MeshData(
        vertices=vertices,
        normals=normals,
        tangents=tangents,
        colors=colors,
        uvs=uvs,
        skin=skin,
        index_buffer=index_buffer,
        submeshes=submeshes,
    )


def _get_channel_dimension(channel) -> int:
    return (channel.get("dimension") or 0) & 0x0F


def _convert_channels_to_streams(channels, vertex_count: int) -> list:
    if not channels:
        return []

    stream_count = max((c.get("stream") or 0) for c in channels) + 1
    streams = [{"channel_mask": 0, "offset": 0, "stride": 0} for _ in range(stream_count)]
    offset = 0
    for s in range(stream_count):
        channel_mask = 0
        stride = 0
        for chn, channel in enumerate(channels):
            if (channel.get("stream") or 0) != s:
                continue
            dimension = _get_channel_dimension(channel)
            if dimension == 0:
                continue
            channel_mask |= 1 << chn
            vertex_format = VertexFormat(channel.get("format") or 0)
            stride += dimension * get_format_size(vertex_format)
        streams[s] = {"channel_mask": channel_mask, "offset": offset, "stride": stride}
        offset += vertex_count * stride
        offset = _align(offset)
    return streams


def _align(offset: int) -> int:
    return (offset + _VERTEX_STREAM_ALIGN - 1) & ~(_VERTEX_STREAM_ALIGN - 1)


def _decode_channels(data: bytes, channels, streams: list, vertex_count: int):
    vertices = normals = tangents = colors = None
    uvs = [None] * 8
    skin_weights = None
    skin_indices = None

    for chn, channel in enumerate(channels):
        dimension = _get_channel_dimension(channel)
        if dimension == 0:
            continue
        stream_index = channel.get("stream") or 0
        if stream_index >= len(streams):
            continue
        stream = streams[stream_index]
        if not (stream["channel_mask"] & (1 << chn)):
            continue

        vertex_format = VertexFormat(channel.get("format") or 0)
        component_size = get_format_size(vertex_format)
        channel_offset = channel.get("offset") or 0
        stride = stream["stride"]
        stream_offset = stream["offset"]

        component_bytes = bytearray(vertex_count * dimension * component_size)
        for v in range(vertex_count):
            vertex_offset = stream_offset + channel_offset + stride * v
            for d in range(dimension):
                src = vertex_offset + component_size * d
                dst = component_size * (v * dimension + d)
                component_bytes[dst:dst + component_size] = data[src:src + component_size]

        if is_int_format(vertex_format):
            ints = bytes_to_int_array(bytes(component_bytes), vertex_format)
            floats = None
        else:
            floats = bytes_to_float_array(bytes(component_bytes), vertex_format)
            ints = None

        if chn == 0:
            vertices = _floats_to_vectors(floats, dimension, 3)
        elif chn == 1:
            normals = _floats_to_vectors(floats, dimension, 3)
        elif chn == 2:
            tangents = _floats_to_vectors(floats, dimension, 4)
        elif chn == 3:
            colors = _floats_to_vectors(floats, dimension, 4)
        elif 4 <= chn <= 11:
            uvs[chn - 4] = _floats_to_vectors(floats, dimension, 2)
        elif chn == 12:  # kShaderChannelBlendWeight
            skin_weights = skin_weights or [[0.0, 0.0, 0.0, 0.0] for _ in range(vertex_count)]
            for i in range(vertex_count):
                for j in range(min(dimension, 4)):
                    skin_weights[i][j] = floats[i * dimension + j]
        elif chn == 13:  # kShaderChannelBlendIndices
            skin_indices = skin_indices or [[0, 0, 0, 0] for _ in range(vertex_count)]
            for i in range(vertex_count):
                for j in range(min(dimension, 4)):
                    skin_indices[i][j] = ints[i * dimension + j]

    skin = None
    if skin_weights is not None or skin_indices is not None:
        skin_weights = skin_weights or [[0.0, 0.0, 0.0, 0.0] for _ in range(vertex_count)]
        skin_indices = skin_indices or [[0, 0, 0, 0] for _ in range(vertex_count)]
        skin = list(zip((tuple(i) for i in skin_indices), (tuple(w) for w in skin_weights)))

    return vertices, normals, tangents, colors, uvs, skin


def _floats_to_vectors(flat: "list | None", dimension: int, target_dim: int) -> "list | None":
    if flat is None:
        return None
    count = len(flat) // dimension
    result = [None] * count
    for i in range(count):
        comps = flat[i * dimension:i * dimension + dimension]
        vec = list(comps[:target_dim])
        vec.extend([0.0] * (target_dim - len(vec)))
        result[i] = tuple(vec)
    return result


def _fix_tangent_w(tangent: tuple) -> tuple:
    x, y, z, w = tangent
    if w in (1.0, -1.0):
        return tangent
    return (x, y, z, -1.0 if w < 0 else 1.0)


def _fix_skin(indices: tuple, weights: tuple) -> "tuple[tuple, tuple]":
    if all(w == 0 for w in weights) and all(i == 0 for i in indices):
        return ((0, 0, 0, 0), (0.25, 0.25, 0.25, 0.25))
    if any(w < 0 for w in weights):
        return ((0, 0, 0, 0), (0.25, 0.25, 0.25, 0.25))
    total = sum(weights)
    if total != 1:
        if total == 0:
            weights = (0.25, 0.25, 0.25, 0.25)
        else:
            weights = tuple(w / total for w in weights)
    return (indices, weights)


def _read_index_buffer(mesh) -> list:
    data = bytes(mesh.get("m_IndexBuffer") or ())
    index_format = mesh.get("m_IndexFormat") or 0
    if index_format == 0:  # UInt16
        count = len(data) // 2
        return [int.from_bytes(data[i * 2:i * 2 + 2], "little") for i in range(count)]
    count = len(data) // 4
    return [int.from_bytes(data[i * 4:i * 4 + 4], "little") for i in range(count)]


def _read_submeshes(mesh) -> "list[SubMeshInfo]":
    submeshes = mesh.get("m_SubMeshes") or ()
    is_16_bit = (mesh.get("m_IndexFormat") or 0) == 0
    result = []
    for sub in submeshes:
        first_byte = sub.get("firstByte") or 0
        first_index = first_byte // (2 if is_16_bit else 4)
        index_count = sub.get("indexCount") or 0
        topology = MeshTopology(sub.get("topology") or 0)
        result.append(SubMeshInfo(first_index=first_index, index_count=index_count, topology=topology))
    return result


def expand_submesh_primitives(index_buffer: list, submesh: SubMeshInfo) -> "tuple[str, list]":
    """Returns (`'triangles'` | `'lines'` | `'points'`, list of index tuples), matching
    GlbSubMeshBuilder.BuildSubMesh's per-topology conversion into flat primitive lists
    (including its de-stripification and Unity->glTF winding-order reversal)."""
    first = submesh.first_index
    count = submesh.index_count
    topology = submesh.topology

    if topology == MeshTopology.TRIANGLES:
        triangles = []
        for i in range(0, count, 3):
            a, b, c = index_buffer[first + i], index_buffer[first + i + 1], index_buffer[first + i + 2]
            triangles.append((c, b, a))
        return "triangles", triangles

    if topology == MeshTopology.TRIANGLE_STRIP:
        triangles = []
        for i in range(count - 2):
            a = index_buffer[first + i + 2]
            b = index_buffer[first + i + 1]
            c = index_buffer[first + i]
            if a == b or a == c or b == c:
                continue
            if i & 1:
                triangles.append((b, a, c))
            else:
                triangles.append((a, b, c))
        return "triangles", triangles

    if topology == MeshTopology.QUADS:
        triangles = []
        for q in range(0, count, 4):
            a, b, c, d = (
                index_buffer[first + q],
                index_buffer[first + q + 1],
                index_buffer[first + q + 2],
                index_buffer[first + q + 3],
            )
            # Upstream calls SharpGLTF's AddQuadrangle(d, c, b, a); that library's exact
            # split isn't vendored here, so this assumes the common "fan from the first
            # vertex" convention: (d,c,b) + (d,b,a). Quads are a legacy, rare Unity
            # topology (deprecated in modern Unity versions), so this is a low-impact,
            # unverified assumption rather than a load-bearing one.
            triangles.append((d, c, b))
            triangles.append((d, b, a))
        return "triangles", triangles

    if topology == MeshTopology.LINES:
        lines = []
        for line_start in range(0, count, 2):
            a, b = index_buffer[first + line_start], index_buffer[first + line_start + 1]
            lines.append((b, a))
        return "lines", lines

    if topology == MeshTopology.LINE_STRIP:
        lines = []
        if count > 1:
            previous = index_buffer[first]
            for i in range(1, count):
                current = index_buffer[first + i]
                lines.append((current, previous))
                previous = current
        return "lines", lines

    # POINTS
    points = [(index_buffer[first + p],) for p in range(count)]
    return "points", points

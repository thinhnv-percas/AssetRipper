from assetripper_export_modules.meshes.mesh_data import (
    MeshData,
    SubMeshInfo,
    _fix_skin,
    _fix_tangent_w,
    _floats_to_vectors,
    expand_submesh_primitives,
)
from assetripper_export_modules.meshes.mesh_topology import MeshTopology


def test_floats_to_vectors_pads_lower_dimensions_with_zero():
    assert _floats_to_vectors([1.0, 2.0], 1, 3) == [(1.0, 0.0, 0.0), (2.0, 0.0, 0.0)]
    assert _floats_to_vectors([1.0, 2.0, 3.0, 4.0], 2, 3) == [(1.0, 2.0, 0.0), (3.0, 4.0, 0.0)]


def test_floats_to_vectors_truncates_higher_dimensions():
    # 4D normals: the extra (always-zero) 4th component is dropped for a Vector3 target.
    assert _floats_to_vectors([1.0, 2.0, 3.0, 0.0], 4, 3) == [(1.0, 2.0, 3.0)]


def test_floats_to_vectors_exact_dimension_passthrough():
    assert _floats_to_vectors([1.0, 2.0, 3.0], 3, 3) == [(1.0, 2.0, 3.0)]


def test_floats_to_vectors_none_input_returns_none():
    assert _floats_to_vectors(None, 3, 3) is None


def test_fix_tangent_w_preserves_exact_plus_or_minus_one():
    assert _fix_tangent_w((1.0, 2.0, 3.0, 1.0)) == (1.0, 2.0, 3.0, 1.0)
    assert _fix_tangent_w((1.0, 2.0, 3.0, -1.0)) == (1.0, 2.0, 3.0, -1.0)


def test_fix_tangent_w_snaps_other_values_to_sign():
    assert _fix_tangent_w((1.0, 2.0, 3.0, -0.3)) == (1.0, 2.0, 3.0, -1.0)
    assert _fix_tangent_w((1.0, 2.0, 3.0, 0.7)) == (1.0, 2.0, 3.0, 1.0)
    assert _fix_tangent_w((1.0, 2.0, 3.0, 0.0)) == (1.0, 2.0, 3.0, 1.0)


def test_fix_skin_default_becomes_uniform_quarter_weights():
    indices, weights = _fix_skin((0, 0, 0, 0), (0.0, 0.0, 0.0, 0.0))
    assert indices == (0, 0, 0, 0)
    assert weights == (0.25, 0.25, 0.25, 0.25)


def test_fix_skin_negative_weight_is_replaced():
    indices, weights = _fix_skin((1, 2, 3, 4), (-0.1, 0.5, 0.3, 0.3))
    assert weights == (0.25, 0.25, 0.25, 0.25)


def test_fix_skin_normalizes_when_sum_is_not_one():
    indices, weights = _fix_skin((1, 2, 0, 0), (0.5, 0.5, 0.0, 0.0))
    assert weights == (0.5, 0.5, 0.0, 0.0)  # already sums to 1, unchanged

    indices, weights = _fix_skin((1, 2, 0, 0), (1.0, 1.0, 0.0, 0.0))
    assert abs(sum(weights) - 1.0) < 1e-9
    assert weights == (0.5, 0.5, 0.0, 0.0)


def test_fix_skin_already_valid_is_unchanged():
    indices, weights = _fix_skin((1, 2, 3, 4), (0.25, 0.25, 0.25, 0.25))
    assert indices == (1, 2, 3, 4)
    assert weights == (0.25, 0.25, 0.25, 0.25)


def _submesh(topology, first_index=0, count=None, index_buffer=None):
    return SubMeshInfo(first_index=first_index, index_count=count, topology=topology)


def test_expand_triangles_reverses_winding():
    kind, tris = expand_submesh_primitives([0, 1, 2], _submesh(MeshTopology.TRIANGLES, count=3))
    assert kind == "triangles"
    assert tris == [(2, 1, 0)]


def test_expand_triangle_strip_destripifies_with_winding_flip_flop():
    # A simple 4-vertex strip, each triangle pre-reversed for the Unity->glTF handedness
    # flip and alternating in raw winding per the strip's even/odd position.
    kind, tris = expand_submesh_primitives([0, 1, 2, 3], _submesh(MeshTopology.TRIANGLE_STRIP, count=4))
    assert kind == "triangles"
    assert tris == [(2, 1, 0), (2, 3, 1)]


def test_expand_triangle_strip_skips_degenerates():
    # Index 2 repeats (degenerate triangle at i=1: indices are 1,2,2).
    kind, tris = expand_submesh_primitives([0, 1, 2, 2, 3], _submesh(MeshTopology.TRIANGLE_STRIP, count=5))
    assert kind == "triangles"
    assert all(len({*t}) == 3 for t in tris)  # no degenerate triangle survived


def test_expand_quads_splits_into_two_triangles():
    kind, tris = expand_submesh_primitives([0, 1, 2, 3], _submesh(MeshTopology.QUADS, count=4))
    assert kind == "triangles"
    assert tris == [(3, 2, 1), (3, 1, 0)]


def test_expand_lines_reverses_pair_order():
    kind, lines = expand_submesh_primitives([0, 1, 2, 3], _submesh(MeshTopology.LINES, count=4))
    assert kind == "lines"
    assert lines == [(1, 0), (3, 2)]


def test_expand_line_strip_connects_consecutive_vertices():
    kind, lines = expand_submesh_primitives([0, 1, 2], _submesh(MeshTopology.LINE_STRIP, count=3))
    assert kind == "lines"
    assert lines == [(1, 0), (2, 1)]


def test_expand_points_passthrough():
    kind, points = expand_submesh_primitives([5, 6, 7], _submesh(MeshTopology.POINTS, count=3))
    assert kind == "points"
    assert points == [(5,), (6,), (7,)]


def test_mesh_data_has_normals_requires_matching_length():
    data = MeshData(vertices=[(0, 0, 0), (1, 1, 1)], normals=[(0, 1, 0)])
    assert not data.has_normals

    data = MeshData(vertices=[(0, 0, 0)], normals=[(0, 1, 0)])
    assert data.has_normals


def test_mesh_data_uv_count_stops_at_first_gap():
    data = MeshData(vertices=[(0, 0, 0)])
    data.uvs[0] = [(0.0, 0.0)]
    data.uvs[2] = [(0.0, 0.0)]  # a "hole" at index 1
    assert data.uv_count == 1

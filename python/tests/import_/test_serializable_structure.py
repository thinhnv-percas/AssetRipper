"""
Reader tests for the TypeTree-driven dynamic asset reader.

`test_spherical_harmonics_l2_can_be_read` is a port of
Source/AssetRipper.Tests/SerializableStructureTests.cs -- note its pattern (build a
SerializableType by hand, create a structure, read bytes, assert the reader ended exactly at
the end of the data) is the one every other test here follows.

The rest have no upstream counterpart: upstream has no coverage of reading real data through
a real type tree, which is precisely where a dynamic reader is most likely to be silently
wrong. Alignment gets dedicated tests because it is the single easiest thing to get wrong,
and a drift of one byte corrupts every field after it.
"""
import struct

import pytest
from assetripper_import.structure.assembly.serializable import SerializableStructure
from assetripper_import.structure.assembly.type_trees import SerializableTreeType, TypeTreeNodeStruct
from assetripper_io_endian.endian_span_reader import EndianSpanReader
from assetripper_io_files.serialized_files.transfer_instruction_flags import TransferInstructionFlags
from assetripper_primitives import UnityVersion
from assetripper_serialization_logic import Field, PrimitiveType, SerializableType

from ._tree_builder import node, pptr_nodes, string_nodes, tree, unity_array, unity_string, vector_nodes

_NO_FLAGS = TransferInstructionFlags.NO_TRANSFER_INSTRUCTION_FLAGS
_V2019 = UnityVersion(2019, 4, 0)
_V5_6 = UnityVersion(5, 6, 0)


def _read(tree_nodes, data: bytes, version: UnityVersion = _V2019, mono_behaviour: bool = False):
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree(*tree_nodes))
    assert ok
    structure = SerializableTreeType.from_root_node(root, mono_behaviour).create_serializable_structure()
    reader = EndianSpanReader(data)
    structure.read(reader, version, _NO_FLAGS)
    return structure, reader


# -- port of SerializableStructureTests.cs ------------------------------------------------


def test_engine_struct_without_fields_is_a_known_divergence_from_upstream():
    """Adapted from SerializableStructureTests.SphericalHarmonicsL2CanBeRead, which is NOT
    portable as written -- documenting the divergence rather than asserting a weaker claim.

    Upstream regression test for AssetRipper issue #1970: SphericalHarmonicsL2's fields are
    serialized by Unity but invisible to the IL-based field-serializer algorithm (private,
    no [SerializeField]), so the SerializableType has no fields. Upstream still consumes all
    27 floats, because `CreateInstance` sees `IsEngineStruct()` and substitutes the
    *generated* SphericalHarmonicsL2 class, which carries the real layout. That generated
    class does not exist in this port, so a fieldless type consumes nothing.

    This only affects IL-derived types, which this port never produces: types built by
    SerializableTreeType have `namespace is None`, so `is_engine_struct()` is always False
    for them and the tree supplies the real layout instead (a Vector3f node has x/y/z
    sub-nodes). See test_nested_structure, which covers that path working correctly.
    """

    class SphericalHarmonicsType(SerializableType):
        def __init__(self):
            super().__init__("UnityEngine.Rendering", PrimitiveType.COMPLEX, "SphericalHarmonicsL2")
            self.max_depth = 0

    class ParentType(SerializableType):
        def __init__(self):
            super().__init__("Namespace", PrimitiveType.COMPLEX, "Name")
            self.fields = [Field(SphericalHarmonicsType(), 0, "field", False)]
            self.max_depth = 1

    serializable_type = ParentType()
    assert len(serializable_type.fields) == 1
    assert serializable_type.fields[0].type.is_engine_struct(), (
        "the engine-struct predicate itself is ported and must still recognise this type"
    )

    structure = serializable_type.create_serializable_structure()
    data = bytes(27 * 4)
    reader = EndianSpanReader(data)
    structure.read(reader, UnityVersion(6000), _NO_FLAGS)

    # Upstream would assert reader.position == len(data) here, via the generated class.
    assert reader.position == 0, "fieldless engine struct consumes nothing without generated layouts"


# -- primitives ---------------------------------------------------------------------------


@pytest.mark.parametrize(
    "type_name,fmt,value",
    [
        ("bool", "<?", True),
        ("SInt8", "<b", -5),
        ("UInt8", "<B", 200),
        ("char", "<B", 65),
        ("short", "<h", -300),
        ("SInt16", "<h", -300),
        ("UInt16", "<H", 40000),
        ("int", "<i", -123456),
        ("SInt32", "<i", -123456),
        ("unsigned int", "<I", 4000000000),
        ("UInt32", "<I", 4000000000),
        ("SInt64", "<q", -1234567890123),
        ("UInt64", "<Q", 12345678901234567890),
        ("FileSize", "<Q", 999),
        ("float", "<f", 1.5),
        ("double", "<d", 2.25),
    ],
)
def test_each_primitive_reads_its_exact_width_and_value(type_name, fmt, value):
    data = struct.pack(fmt, value)
    structure, reader = _read([node("T", "Base", 0), node(type_name, "m_Value", 1)], data)
    assert reader.position == len(data), f"{type_name} consumed the wrong number of bytes"
    assert structure["m_Value"] == value


def test_ushort_with_char_property_mask_reads_as_a_character():
    from assetripper_io_files.serialized_files.transfer_meta_flags import TransferMetaFlags

    data = struct.pack("<H", ord("Z"))
    structure, reader = _read(
        [node("T", "Base", 0), node("UInt16", "m_Char", 1, extra_flags=TransferMetaFlags.CHAR_PROPERTY_MASK)],
        data,
    )
    assert reader.position == 2, "PrimitiveType.CHAR is a 2-byte ushort, not a 1-byte char"
    assert structure["m_Char"] == "Z"


def test_unity_char_is_a_single_byte():
    """Unity's type-tree "char" maps to PrimitiveType.BYTE (1 byte), unlike .NET's 2-byte char."""
    structure, reader = _read([node("T", "Base", 0), node("char", "m_Byte", 1)], b"\x41")
    assert reader.position == 1
    assert structure["m_Byte"] == 0x41


# -- strings ------------------------------------------------------------------------------


def test_string_reads_and_always_aligns_afterwards():
    data = unity_string("hi") + struct.pack("<i", 777)
    structure, reader = _read([node("T", "Base", 0), *string_nodes("m_Name", 1), node("int", "m_After", 1)], data)
    assert structure["m_Name"] == "hi"
    # 4 length + 2 content = 6, aligned up to 8, then the int -> 12
    assert reader.position == 12
    assert structure["m_After"] == 777, "string alignment was not applied, shifting the next field"


def test_empty_string():
    structure, reader = _read([node("T", "Base", 0), *string_nodes("m_Name", 1)], struct.pack("<i", 0))
    assert structure["m_Name"] == ""
    assert reader.position == 4


# -- arrays and the version-gated alignment rule ------------------------------------------


def test_int_array():
    data = unity_array("i", [7, 8, 9])
    structure, reader = _read([node("T", "Base", 0), *vector_nodes("m_Ints", "int", 1)], data)
    assert structure["m_Ints"] == [7, 8, 9]
    assert reader.position == len(data)


def test_empty_array():
    structure, reader = _read([node("T", "Base", 0), *vector_nodes("m_Ints", "int", 1)], struct.pack("<i", 0))
    assert structure["m_Ints"] == []
    assert reader.position == 4


def test_byte_array_is_aligned_after_on_2017_and_later():
    """Arrays align after reading, but only since Unity 2017 (`is_align_arrays`).

    A 3-byte array is the discriminating case: on 2017+ a pad byte must be consumed, on
    older versions it must not be.
    """
    nodes = [node("T", "Base", 0), *vector_nodes("m_Bytes", "UInt8", 1), node("int", "m_Sentinel", 1)]
    sentinel = struct.pack("<i", 999)

    aligned = unity_array("B", [1, 2, 3]) + b"\x00" + sentinel
    structure, reader = _read(nodes, aligned, version=UnityVersion(2017, 1, 0))
    assert structure["m_Bytes"] == [1, 2, 3]
    assert structure["m_Sentinel"] == 999
    assert reader.position == len(aligned)

    unaligned = unity_array("B", [1, 2, 3]) + sentinel
    structure, reader = _read(nodes, unaligned, version=_V5_6)
    assert structure["m_Bytes"] == [1, 2, 3]
    assert structure["m_Sentinel"] == 999
    assert reader.position == len(unaligned)


def test_array_alignment_is_actually_applied_not_merely_tolerated():
    """Guards against the rule being a no-op: applying the 2017 rule to a layout written
    without the pad byte must overrun, proving a byte really is being skipped."""
    nodes = [node("T", "Base", 0), *vector_nodes("m_Bytes", "UInt8", 1), node("int", "m_Sentinel", 1)]
    unaligned = unity_array("B", [1, 2, 3]) + struct.pack("<i", 999)
    with pytest.raises(EOFError):
        _read(nodes, unaligned, version=UnityVersion(2017, 1, 0))


def test_per_field_align_flag():
    """`Field.align` aligns after the field, independently of the array rule."""
    data = b"\x01" + b"\x00\x00\x00" + struct.pack("<i", 555)
    structure, reader = _read(
        [node("T", "Base", 0), node("bool", "m_Flag", 1, align=True), node("int", "m_After", 1)], data
    )
    assert structure["m_Flag"] is True
    assert structure["m_After"] == 555
    assert reader.position == len(data)


def test_string_array():
    """vector<string>: the element must itself carry the 4-node string shape, otherwise it
    reads as an opaque Complex rather than a string."""
    nodes = [
        node("T", "Base", 0),
        node("vector", "m_Strings", 1),
        node("Array", "Array", 2),
        node("int", "size", 3),
        node("string", "data", 3),
        node("Array", "Array", 4),
        node("int", "size", 5),
        node("char", "data", 5),
    ]
    data = struct.pack("<i", 2) + unity_string("ab") + unity_string("cde")
    structure, reader = _read(nodes, data, version=_V5_6)
    assert structure["m_Strings"] == ["ab", "cde"]
    assert reader.position == len(data)


def test_nested_array_of_arrays():
    inner_a = unity_array("i", [1, 2])
    inner_b = unity_array("i", [3])
    data = struct.pack("<i", 2) + inner_a + inner_b
    nodes = [
        node("T", "Base", 0),
        node("vector", "m_Outer", 1),
        node("Array", "Array", 2),
        node("int", "size", 3),
        node("vector", "data", 3),
        node("Array", "Array", 4),
        node("int", "size", 5),
        node("int", "data", 5),
    ]
    structure, reader = _read(nodes, data, version=_V5_6)
    assert structure["m_Outer"] == [[1, 2], [3]]
    assert reader.position == len(data)


# -- nested structures, pptrs, pairs -------------------------------------------------------


def test_nested_structure():
    data = struct.pack("<fff", 1.0, 2.0, 3.0) + struct.pack("<i", 42)
    nodes = [
        node("T", "Base", 0),
        node("Vector3f", "m_Position", 1),
        node("float", "x", 2),
        node("float", "y", 2),
        node("float", "z", 2),
        node("int", "m_Extra", 1),
    ]
    structure, reader = _read(nodes, data)
    position = structure["m_Position"]
    assert position["x"] == 1.0
    assert position["y"] == 2.0
    assert position["z"] == 3.0
    assert structure["m_Extra"] == 42
    assert reader.position == len(data)


def test_pptr_with_64bit_path_id():
    data = struct.pack("<i", 3) + struct.pack("<q", 1234567890123)
    structure, reader = _read([node("T", "Base", 0), *pptr_nodes("m_Ptr")], data)
    pptr = structure["m_Ptr"]
    assert (pptr.file_id, pptr.path_id) == (3, 1234567890123)
    assert reader.position == 12


def test_pptr_with_32bit_path_id_uses_the_width_from_the_tree():
    """Older Unity versions use a 32-bit m_PathID. The width comes from the tree's own
    m_PathID node rather than a version heuristic."""
    data = struct.pack("<i", 3) + struct.pack("<i", 99)
    structure, reader = _read([node("T", "Base", 0), *pptr_nodes("m_Ptr", path_id_type="int")], data)
    pptr = structure["m_Ptr"]
    assert (pptr.file_id, pptr.path_id) == (3, 99)
    assert reader.position == 8


def test_array_of_nested_structures():
    element = struct.pack("<ff", 1.0, 2.0)
    data = struct.pack("<i", 2) + element + struct.pack("<ff", 3.0, 4.0)
    nodes = [
        node("T", "Base", 0),
        node("vector", "m_Points", 1),
        node("Array", "Array", 2),
        node("int", "size", 3),
        node("Vector2f", "data", 3),
        node("float", "x", 4),
        node("float", "y", 4),
    ]
    structure, reader = _read(nodes, data, version=_V5_6)
    points = structure["m_Points"]
    assert len(points) == 2
    assert (points[0]["x"], points[0]["y"]) == (1.0, 2.0)
    assert (points[1]["x"], points[1]["y"]) == (3.0, 4.0)
    assert reader.position == len(data)


def test_map_of_int_to_float():
    data = struct.pack("<i", 2) + struct.pack("<if", 1, 1.5) + struct.pack("<if", 2, 2.5)
    nodes = [
        node("T", "Base", 0),
        node("map", "m_Map", 1),
        node("Array", "Array", 2),
        node("int", "size", 3),
        node("pair", "data", 3),
        node("int", "first", 4),
        node("float", "second", 4),
    ]
    structure, reader = _read(nodes, data, version=_V5_6)
    pairs = structure["m_Map"]
    assert len(pairs) == 2
    assert (pairs[0].first.value, pairs[0].second.value) == (1, 1.5)
    assert (pairs[1].first.value, pairs[1].second.value) == (2, 2.5)
    assert reader.position == len(data)


# -- field access and structure behaviour --------------------------------------------------


def test_field_access_api():
    data = struct.pack("<i", 5) + struct.pack("<f", 0.5)
    structure, _ = _read([node("T", "Base", 0), node("int", "a", 1), node("float", "b", 1)], data)

    assert structure["a"] == 5
    assert "a" in structure
    assert "nope" not in structure
    assert structure.get("nope", "fallback") == "fallback"
    assert structure.keys() == ["a", "b"]
    assert list(structure.items()) == [("a", 5), ("b", 0.5)]
    assert len(structure) == 2

    structure["a"] = 6
    assert structure["a"] == 6

    with pytest.raises(KeyError):
        structure["nope"]


def test_mono_behaviour_structure_skips_the_engine_prefix_fields():
    """For MonoBehaviours, upstream starts fields after m_Name/m_EditorClassIdentifier,
    because those are read by the engine part of the object, not the script part."""
    nodes = [
        node("MyScript", "Base", 0),
        *pptr_nodes("m_GameObject", level=1),
        node("UInt8", "m_Enabled", 1),
        *pptr_nodes("m_Script", target="MonoScript", level=1),
        *string_nodes("m_Name", 1),
        node("int", "myField", 1),
    ]
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree(*nodes))
    assert ok
    script_type = SerializableTreeType.from_root_node(root, mono_behaviour_structure=True)
    assert [f.name for f in script_type.fields] == ["myField"]


def test_serialized_version_and_class_name_come_from_the_type():
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree(node("TextAsset", "Base", 0), node("int", "a", 1)))
    assert ok
    root = TypeTreeNodeStruct("TextAsset", "Base", 7, root.meta_flag, root.sub_nodes)
    structure = SerializableTreeType.from_root_node(root).create_serializable_structure()
    assert structure.class_name == "TextAsset"
    assert structure.serialized_version == 7


def test_try_read_reports_a_layout_mismatch():
    """A layout that doesn't consume exactly the available bytes is the signal that the
    structure didn't match the data."""
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree(node("T", "Base", 0), node("int", "a", 1)))
    assert ok
    structure = SerializableTreeType.from_root_node(root).create_serializable_structure()

    reader = EndianSpanReader(struct.pack("<i", 1) + b"leftover")
    read_ok, error = structure.try_read(reader, _V2019, _NO_FLAGS)
    assert not read_ok
    assert "expected" in error

    structure2 = SerializableTreeType.from_root_node(root).create_serializable_structure()
    read_ok, error = structure2.try_read(EndianSpanReader(struct.pack("<i", 1)), _V2019, _NO_FLAGS)
    assert read_ok
    assert error is None


def test_max_depth_level_matches_unity_versions():
    from assetripper_import.structure.assembly.serializable import get_max_depth_level
    from assetripper_primitives import UnityVersionType

    assert get_max_depth_level(UnityVersion(2019, 4, 0)) == 7
    assert get_max_depth_level(UnityVersion(2020, 2, 0, UnityVersionType.ALPHA, 21)) == 10
    assert get_max_depth_level(UnityVersion(2021, 1, 0)) == 10

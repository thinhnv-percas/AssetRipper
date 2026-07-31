"""Tests for YamlWalker (Source/AssetRipper.Export.UnityProjects/YamlWalker.cs port),
driven through the real dynamic-reader pipeline (TypeTree -> SerializableStructure) rather
than hand-built IUnityAssetBase stand-ins, since that's the only path this port produces.
"""
import struct

from assetripper_export_unity_projects.yaml_walker import YamlWalker
from assetripper_import.structure.assembly.type_trees import SerializableTreeType, TypeTreeNodeStruct
from assetripper_io_endian.endian_span_reader import EndianSpanReader
from assetripper_io_files.serialized_files.transfer_instruction_flags import TransferInstructionFlags
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, pad_to_4, pptr_nodes, string_nodes, tree, unity_array, unity_string, vector_nodes

_NO_FLAGS = TransferInstructionFlags.NO_TRANSFER_INSTRUCTION_FLAGS
_V2019 = UnityVersion(2019, 4, 0)


def _read_and_walk(tree_nodes, data: bytes, version: UnityVersion = _V2019):
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree(*tree_nodes))
    assert ok
    structure = SerializableTreeType.from_root_node(root).create_serializable_structure()
    reader = EndianSpanReader(data)
    structure.read(reader, version, _NO_FLAGS)
    assert reader.position == reader.length

    walker = YamlWalker()
    node_result = walker.export_yaml_node(structure)
    return node_result.emit_to_string()


def test_scalar_fields():
    tree_nodes = [node("T", "Base", 0), node("int", "m_Int", 1), node("bool", "m_Bool", 1), node("float", "m_Float", 1)]
    data = struct.pack("<i", -7) + struct.pack("<?", True) + struct.pack("<f", 1.5)
    text = _read_and_walk(tree_nodes, data)
    assert "m_Int: -7" in text
    assert "m_Bool: 1" in text
    assert "m_Float: 1.5" in text


def test_string_field():
    tree_nodes = [node("T", "Base", 0), *string_nodes("m_Name", 1)]
    text = _read_and_walk(tree_nodes, unity_string("hello world"))
    assert "m_Name: hello world" in text


def test_char_scalar_serializes_as_numeric_code_unit():
    tree_nodes = [node("T", "Base", 0), node("char", "m_Char", 1)]
    text = _read_and_walk(tree_nodes, b"A")
    # 'A' is codepoint 65, not the letter, matching Unity/.NET's char-as-number behavior.
    assert "m_Char: 65" in text


def test_int_array_serializes_as_hex_string():
    tree_nodes = [node("T", "Base", 0), *vector_nodes("m_Ints", "int", 1)]
    text = _read_and_walk(tree_nodes, unity_array("i", [1, 2, 3]))
    assert "m_Ints: 010000000200000003000000" in text


def test_bool_array_serializes_as_hex_string():
    tree_nodes = [node("T", "Base", 0), *vector_nodes("m_Flags", "bool", 1)]
    text = _read_and_walk(tree_nodes, pad_to_4(unity_array("?", [True, False, True])))
    assert "m_Flags: 010001" in text


def test_float_array_serializes_as_block_sequence_not_hex():
    tree_nodes = [node("T", "Base", 0), *vector_nodes("m_Floats", "float", 1)]
    text = _read_and_walk(tree_nodes, unity_array("f", [1.0, 2.0]))
    assert "m_Floats:" in text
    assert "- 1" in text
    assert "- 2" in text


def test_pptr_field():
    tree_nodes = [node("T", "Base", 0), *pptr_nodes("m_Ptr")]
    data = struct.pack("<iq", 0, 12345)
    text = _read_and_walk(tree_nodes, data)
    assert "m_Ptr: {m_FileID: 0, m_PathID: 12345, m_TargetClassID: 0}" in text


def test_nested_struct_field():
    tree_nodes = [
        node("T", "Base", 0),
        node("Vector3f", "m_Position", 1),
        node("float", "x", 2),
        node("float", "y", 2),
        node("float", "z", 2),
    ]
    data = struct.pack("<fff", 1.0, 2.0, 3.0)
    text = _read_and_walk(tree_nodes, data)
    assert "m_Position:" in text
    assert "x: 1" in text
    assert "y: 2" in text
    assert "z: 3" in text

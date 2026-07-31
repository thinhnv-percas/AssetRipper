"""Port of Source/AssetRipper.Tests/TypeTreeNodeStructTests.cs

Only `NamedVectorTest` is ported. The other upstream test,
`PrimitiveTypeRoundTripIsTheSame`, drives `TypeTreeNodeStruct.FromSerializableType` -- the
reverse direction (SerializableType -> tree), which this port doesn't implement because it
only exists upstream to emit type trees for IL-derived script types.

The remaining tests here have no upstream counterpart and cover the shape predicates
directly, since every layout decision in the reader depends on them.
"""
from assetripper_import.structure.assembly.type_trees import TypeTreeNodeStruct

from ._tree_builder import node, pptr_nodes, string_nodes, tree, vector_nodes


def test_named_vector():
    t = tree(
        node("MonoBehaviour", "Base", 0),
        node("SerializableClass", "fieldName", 1, align=True),
        node("Array", "Array", 2),
        node("int", "size", 3),
        node("SerializableClass", "data", 3, align=True),
        node("float", "subFieldName1", 4),
        node("bool", "subFieldName2", 4, align=True),
    )

    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(t)
    assert ok
    assert len(root.sub_nodes) == 1
    main_node = root.sub_nodes[0]
    assert main_node.is_named_vector


def test_empty_tree_is_rejected():
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree())
    assert not ok
    assert root is None


def test_flat_list_is_rebuilt_into_a_tree_by_level():
    t = tree(
        node("Base", "Base", 0),
        node("int", "a", 1),
        node("Nested", "b", 1),
        node("float", "b1", 2),
        node("float", "b2", 2),
        node("int", "c", 1),
    )
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(t)
    assert ok
    assert [n.name for n in root.sub_nodes] == ["a", "b", "c"]
    assert [n.name for n in root["b"].sub_nodes] == ["b1", "b2"]
    assert root["a"].count == 0


def test_string_predicate():
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree(node("T", "Base", 0), *string_nodes("m_Name", 1)))
    assert ok
    assert root["m_Name"].is_string


def test_vector_predicate():
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree(node("T", "Base", 0), *vector_nodes("m_Ints", "int", 1)))
    assert ok
    m_ints = root["m_Ints"]
    assert m_ints.is_vector
    assert m_ints.sub_nodes[0].is_array
    assert not m_ints.is_named_vector


def test_pptr_predicate():
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree(node("T", "Base", 0), *pptr_nodes("m_Ptr")))
    assert ok
    assert root["m_Ptr"].is_pptr


def test_pptr_predicate_accepts_mono_behaviour_dollar_form():
    # Custom MonoBehaviour fields render as PPtr<$MyType>
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(
        tree(node("T", "Base", 0), *pptr_nodes("m_Ptr", target="$MyType"))
    )
    assert ok
    assert root["m_Ptr"].is_pptr


def test_pptr_predicate_rejects_wrong_field_names():
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(
        tree(
            node("T", "Base", 0),
            node("PPtr<GameObject>", "m_Ptr", 1),
            node("int", "m_NotFileID", 2),
            node("SInt64", "m_PathID", 2),
        )
    )
    assert ok
    assert not root["m_Ptr"].is_pptr


def test_pair_and_map_predicates():
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(
        tree(
            node("T", "Base", 0),
            node("map", "m_Map", 1),
            node("Array", "Array", 2),
            node("int", "size", 3),
            node("pair", "data", 3),
            node("int", "first", 4),
            node("float", "second", 4),
        )
    )
    assert ok
    m_map = root["m_Map"]
    assert m_map.is_map
    assert m_map.sub_nodes[0].sub_nodes[1].is_pair


def test_typeless_data_predicate():
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(
        tree(
            node("T", "Base", 0),
            node("TypelessData", "image data", 1),
            node("int", "size", 2),
            node("UInt8", "data", 2),
        )
    )
    assert ok
    image_data = root["image data"]
    assert image_data.is_array
    assert image_data.is_typeless_data


def test_meta_flag_shortcuts():
    from assetripper_io_files.serialized_files.transfer_meta_flags import TransferMetaFlags

    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(
        tree(
            node("T", "Base", 0),
            node("int", "aligned", 1, align=True),
            node("UInt16", "as_char", 1, extra_flags=TransferMetaFlags.CHAR_PROPERTY_MASK),
            node("T2", "flow", 1, extra_flags=TransferMetaFlags.TRANSFER_USING_FLOW_MAPPING_STYLE),
        )
    )
    assert ok
    assert root["aligned"].align_bytes
    assert root["as_char"].treat_integer_as_char
    assert root["flow"].flow_mapped_in_yaml
    assert not root["aligned"].treat_integer_as_char


def test_indexing_and_equality():
    ok, root = TypeTreeNodeStruct.try_make_from_type_tree(
        tree(node("T", "Base", 0), node("int", "a", 1), node("int", "b", 1))
    )
    assert ok
    assert root[0].name == "a"
    assert root["b"] is root[1]
    assert root.index_of_name("b") == 1
    assert root.index_of_name("nope") == -1

    ok2, root2 = TypeTreeNodeStruct.try_make_from_type_tree(
        tree(node("T", "Base", 0), node("int", "a", 1), node("int", "b", 1))
    )
    assert ok2
    assert root == root2
    assert hash(root) == hash(root2)

"""Port of Source/AssetRipper.Import/Structure/Assembly/TypeTrees/SerializableTreeType.cs

Converts a TypeTreeNodeStruct into a SerializableType. This is the abstraction boundary
that lets the rest of the reader stay ignorant of where a field layout came from: upstream
can produce a SerializableType either from IL (FieldSerializer) or from a type tree, and
this port only does the latter.
"""
from __future__ import annotations

from assetripper_serialization_logic.primitive_type import PrimitiveType
from assetripper_serialization_logic.serializable_pointer_type import SerializablePointerType
from assetripper_serialization_logic.serializable_type import Field, SerializableType

from .type_tree_node_struct import TypeTreeNodeStruct

_PRIMITIVE_LEAF_NAMES = {
    "bool": PrimitiveType.BOOL,
    # Unity's "char" is a single byte -- PrimitiveType.CHAR is reserved for a 2-byte
    # ushort carrying the CHAR_PROPERTY_MASK flag, handled separately below.
    "char": PrimitiveType.BYTE,
    "UInt8": PrimitiveType.BYTE,
    "SInt8": PrimitiveType.SBYTE,
    "short": PrimitiveType.SHORT,
    "SInt16": PrimitiveType.SHORT,
    "int": PrimitiveType.INT,
    "SInt32": PrimitiveType.INT,
    "Type*": PrimitiveType.INT,
    "uint": PrimitiveType.UINT,
    "UInt32": PrimitiveType.UINT,
    "unsigned int": PrimitiveType.UINT,
    "SInt64": PrimitiveType.LONG,
    "long long": PrimitiveType.LONG,
    "UInt64": PrimitiveType.ULONG,
    "FileSize": PrimitiveType.ULONG,
    "unsigned long long": PrimitiveType.ULONG,
    "float": PrimitiveType.SINGLE,
    "double": PrimitiveType.DOUBLE,
}

_USHORT_NAMES = frozenset({"ushort", "UInt16", "unsigned short"})


class SerializableTreeType(SerializableType):
    def __init__(self, name: str, type: PrimitiveType, version: int, flow_mapped_in_yaml: bool):
        super().__init__(None, type, name)
        self.version = version
        self.flow_mapped_in_yaml = flow_mapped_in_yaml

    def _set_max_depth(self) -> None:
        max_depth = 0
        for field in self.fields:
            assert field.type.is_max_depth_known, "The depth of this type is not known."
            max_depth = max(max_depth, field.type.max_depth + 1)
        self.max_depth = max_depth

    @staticmethod
    def from_root_node(root_node: TypeTreeNodeStruct, mono_behaviour_structure: bool = False) -> "SerializableTreeType":
        type_name, primitive_type, array_depth, _align, primitive_node = _to_primitive_type(root_node)
        assert array_depth == 0, "Array depth should be 0 for root node"
        assert primitive_node is root_node, "Primitive node should be the same as root node"
        assert not mono_behaviour_structure or primitive_type == PrimitiveType.COMPLEX, (
            "MonoBehaviour structure should be complex type"
        )

        result = SerializableTreeType(type_name, primitive_type, root_node.version, root_node.flow_mapped_in_yaml)

        fields: list[Field] = []
        start_index = _find_starting_index_for_mono_behaviour(root_node) if mono_behaviour_structure else 0
        for i in range(start_index, len(root_node.sub_nodes)):
            _add_node(root_node.sub_nodes[i], fields)
        result.fields = fields
        result._set_max_depth()
        return result


def _add_node(node: TypeTreeNodeStruct, fields: list[Field]) -> None:
    type_name, primitive_type, array_depth, align_bytes, primitive_node = _to_primitive_type(node)

    if primitive_type in (PrimitiveType.COMPLEX, PrimitiveType.PAIR, PrimitiveType.MAP_PAIR):
        if primitive_node.is_pptr:
            serializable_type: SerializableType = _pointer_type_for(primitive_node)
        else:
            serializable_type = _from_structure_node(type_name, primitive_node, primitive_type)
    else:
        serializable_type = SerializableTreeType(
            type_name, primitive_type, primitive_node.version, primitive_node.flow_mapped_in_yaml
        )
        serializable_type.max_depth = 0

    fields.append(Field(serializable_type, array_depth, node.name, align_bytes))


_PATH_ID_64BIT_TYPE_NAMES = frozenset({"SInt64", "UInt64", "long long", "unsigned long long", "FileSize"})


def _pointer_type_for(node: TypeTreeNodeStruct) -> SerializablePointerType:
    """A pointer type that remembers m_PathID's width, read from the type tree.

    Upstream substitutes the shared `SerializablePointerType` singleton here and relies on a
    generated per-version PPtr class to know whether m_PathID is 32- or 64-bit. Since that
    generated class isn't available, the width is taken from the tree's own m_PathID node
    instead -- which is exact, rather than inferred from the Unity version.
    """
    path_id_node = node["m_PathID"]
    pointer_type = SerializablePointerType()
    pointer_type.path_id_is_64bit = path_id_node.type_name in _PATH_ID_64BIT_TYPE_NAMES
    return pointer_type


def _from_structure_node(name: str, node: TypeTreeNodeStruct, type: PrimitiveType) -> SerializableTreeType:
    result = SerializableTreeType(name, type, node.version, node.flow_mapped_in_yaml)
    fields: list[Field] = []
    for sub_node in node.sub_nodes:
        _add_node(sub_node, fields)
    result.fields = fields
    result._set_max_depth()
    return result


def _find_starting_index_for_mono_behaviour(root_node: TypeTreeNodeStruct) -> int:
    name_index = root_node.index_of_name("m_Name")
    editor_class_id_index = root_node.index_of_name("m_EditorClassIdentifier")
    return max(name_index, editor_class_id_index) + 1


def _to_primitive_type(node: TypeTreeNodeStruct):
    """Unwraps array/vector/map layers, accumulating the alignment flag as it descends.

    Returns (type_name, primitive_type, array_depth, align_bytes, primitive_node).
    C# returns these via five `out` parameters.
    """
    is_map = False
    align_bytes = False
    type_name = ""
    array_depth = 0

    while True:
        align_bytes |= node.align_bytes
        if node.is_array:
            array_depth += 1
            node = node[1]
        elif node.is_vector:
            align_bytes |= node[0].align_bytes
            array_depth += 1
            node = node[0][1]
        elif node.is_named_vector:
            # It's important that type_name is set before node is reassigned.
            if not type_name:
                type_name = node.type_name
            align_bytes |= node[0].align_bytes
            array_depth += 1
            node = node[0][1]
        elif node.is_map:
            is_map = True
            align_bytes |= node[0].align_bytes
            array_depth += 1
            node = node[0][1]
        else:
            if not type_name:
                type_name = node.type_name
            break

    if node.count == 0:
        if node.type_name in _USHORT_NAMES:
            primitive_type = PrimitiveType.CHAR if node.treat_integer_as_char else PrimitiveType.USHORT
        else:
            primitive_type = _PRIMITIVE_LEAF_NAMES.get(node.type_name, PrimitiveType.COMPLEX)
    elif node.is_string:
        primitive_type = PrimitiveType.STRING
    elif node.is_pair:
        primitive_type = PrimitiveType.MAP_PAIR if is_map else PrimitiveType.PAIR
    else:
        primitive_type = PrimitiveType.COMPLEX

    return type_name, primitive_type, array_depth, align_bytes, node

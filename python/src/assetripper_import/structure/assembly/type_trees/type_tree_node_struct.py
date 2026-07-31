"""Port of Source/AssetRipper.Import/Structure/Assembly/TypeTrees/TypeTreeNodeStruct.cs

A recursive, immutable view over a Unity TypeTree, with the shape predicates that identify
Unity's serialization idioms (arrays, vectors, maps, pairs, strings, PPtrs). This is what
turns the flat, level-encoded node list produced by
assetripper_io_files.serialized_files.parser.type_trees.TypeTree into a tree.

Not ported: `TryMakeFromTpk`/`FromTpkNode` (the Tpk type-tree database is a separate
unvendored NuGet package, unavailable here) and `FromSerializableType` (the reverse
direction, used upstream only to emit type trees for IL-derived script types).
"""
from __future__ import annotations

from assetripper_io_files.serialized_files.transfer_meta_flags import (
    TransferMetaFlags,
    is_align_bytes,
    is_char_property_mask,
    is_transfer_using_flow_mapping_style,
)


class TypeTreeNodeStruct:
    __slots__ = ("type_name", "name", "version", "meta_flag", "sub_nodes")

    def __init__(
        self,
        type_name: str,
        name: str,
        version: int,
        meta_flags: TransferMetaFlags,
        sub_nodes: "tuple[TypeTreeNodeStruct, ...]" = (),
    ):
        self.type_name = type_name
        self.name = name
        self.version = version
        self.meta_flag = meta_flags
        self.sub_nodes = tuple(sub_nodes)

    # -- indexing / sequence surface (C# implements IReadOnlyList<TypeTreeNodeStruct>) --

    def __len__(self) -> int:
        return len(self.sub_nodes)

    @property
    def count(self) -> int:
        return len(self.sub_nodes)

    def __iter__(self):
        return iter(self.sub_nodes)

    def __getitem__(self, key: "int | str") -> "TypeTreeNodeStruct":
        """Port of both indexers: `this[int index]` and `this[string name]`."""
        if isinstance(key, str):
            for node in self.sub_nodes:
                if node.name == key:
                    return node
            raise KeyError(key)
        return self.sub_nodes[key]

    def index_of_name(self, name: str) -> int:
        """Port of the `SubNodes.IndexOf(node => node.Name == ...)` extension used by
        SerializableTreeType.FindStartingIndexForMonoBehaviour. Returns -1 if absent."""
        for i, node in enumerate(self.sub_nodes):
            if node.name == name:
                return i
        return -1

    # -- meta flag shortcuts --

    @property
    def align_bytes(self) -> bool:
        return is_align_bytes(self.meta_flag)

    @property
    def treat_integer_as_char(self) -> bool:
        return is_char_property_mask(self.meta_flag)

    @property
    def flow_mapped_in_yaml(self) -> bool:
        return is_transfer_using_flow_mapping_style(self.meta_flag)

    # -- shape predicates --

    @property
    def is_array(self) -> bool:
        if self.type_name in ("Array", "TypelessData") and len(self.sub_nodes) == 2:
            size_node = self.sub_nodes[0]
            return size_node.name == "size" and len(size_node.sub_nodes) == 0 and self.sub_nodes[1].name == "data"
        return False

    @property
    def is_typeless_data(self) -> bool:
        if self.type_name == "TypelessData" and len(self.sub_nodes) == 2:
            size_node = self.sub_nodes[0]
            return size_node.name == "size" and len(size_node.sub_nodes) == 0 and self.sub_nodes[1].name == "data"
        return False

    @property
    def is_vector(self) -> bool:
        return self.type_name in ("vector", "staticvector", "set") and len(self.sub_nodes) == 1 and self.sub_nodes[0].is_array

    @property
    def is_named_vector(self) -> bool:
        """A vector whose type name is the element type's rather than "vector".

        First noticed on a ScriptableObject field of type List<T> where T is a
        serializable class. "Generic Mono" has only been found on Unity 3.
        """
        if len(self.sub_nodes) == 1 and self.sub_nodes[0].is_array and self.sub_nodes[0].name == "Array":
            element_type_name = self.sub_nodes[0].sub_nodes[1].type_name
            return element_type_name == self.type_name or element_type_name == "Generic Mono"
        return False

    @property
    def is_pair(self) -> bool:
        return (
            self.type_name == "pair"
            and len(self.sub_nodes) == 2
            and self.sub_nodes[0].name == "first"
            and self.sub_nodes[1].name == "second"
        )

    @property
    def is_map(self) -> bool:
        return (
            self.type_name == "map"
            and len(self.sub_nodes) == 1
            and self.sub_nodes[0].is_array
            and self.sub_nodes[0].sub_nodes[1].is_pair
        )

    @property
    def is_managed_references_registry(self) -> bool:
        """Holds an asset's [SerializeReference] fields; the last top-level field."""
        return self.type_name == "ManagedReferencesRegistry" and self.name == "references" and len(self.sub_nodes) > 1

    @property
    def is_referenced_object_data(self) -> bool:
        """A [SerializeReference] object reference; the last entry in a flattened tree."""
        return self.type_name == "ReferencedObjectData" and self.name == "data" and len(self.sub_nodes) == 0

    @property
    def is_byte(self) -> bool:
        return len(self.sub_nodes) == 0 and self.type_name in ("char", "UInt8")

    @property
    def is_string(self) -> bool:
        return (
            len(self.sub_nodes) == 1
            and self.type_name == "string"
            and self.sub_nodes[0].is_array
            and self.sub_nodes[0].sub_nodes[1].is_byte
        )

    @property
    def is_pptr(self) -> bool:
        if len(self.sub_nodes) != 2:
            return False
        file_id_node = self.sub_nodes[0]
        if file_id_node.name != "m_FileID" or len(file_id_node.sub_nodes) > 0:
            return False
        path_id_node = self.sub_nodes[1]
        if path_id_node.name != "m_PathID" or len(path_id_node.sub_nodes) > 0:
            return False
        # Note: custom MonoBehaviour fields have a '$' after the '<', eg PPtr<$GameObject>
        return self.type_name.startswith("PPtr<") and self.type_name.endswith(">")

    # -- construction --

    @staticmethod
    def from_type_tree_node(node, sub_nodes: "tuple[TypeTreeNodeStruct, ...]") -> "TypeTreeNodeStruct":
        """Port of the private `TypeTreeNodeStruct(TypeTreeNode, TypeTreeNodeStruct[])`."""
        return TypeTreeNodeStruct(node.type, node.name, node.version, node.meta_flag, sub_nodes)

    @staticmethod
    def try_make_from_type_tree(tree) -> "tuple[bool, TypeTreeNodeStruct | None]":
        """Returns (success, root_node). C# uses a bool return plus an out parameter."""
        if len(tree.nodes) == 0:
            return False, None
        return True, TypeTreeNodeStruct.from_node_list(tree.nodes, 0)

    @staticmethod
    def from_node_list(nodes: list, index: int) -> "TypeTreeNodeStruct":
        """Rebuilds the subtree rooted at `index` from the flat, level-encoded node list."""
        node = nodes[index]
        level = node.level
        if index + 1 == len(nodes) or nodes[index + 1].level <= level:
            return TypeTreeNodeStruct.from_type_tree_node(node, ())

        sub_nodes = []
        for i in range(index + 1, len(nodes)):
            sub_level = nodes[i].level
            if sub_level == level + 1:
                sub_nodes.append(TypeTreeNodeStruct.from_node_list(nodes, i))
            elif sub_level <= level:
                break
        return TypeTreeNodeStruct.from_type_tree_node(node, tuple(sub_nodes))

    # -- equality / display (C# is a readonly struct implementing IEquatable) --

    def __eq__(self, other: object) -> bool:
        if not isinstance(other, TypeTreeNodeStruct):
            return NotImplemented
        return (
            self.type_name == other.type_name
            and self.name == other.name
            and self.version == other.version
            and self.meta_flag == other.meta_flag
            and self.sub_nodes == other.sub_nodes
        )

    def __hash__(self) -> int:
        return hash((self.type_name, self.name, self.version, self.meta_flag, self.sub_nodes))

    def __str__(self) -> str:
        return f"{self.type_name} {self.name} ({len(self.sub_nodes)} SubNodes)"

    __repr__ = __str__

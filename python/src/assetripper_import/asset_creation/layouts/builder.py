"""
Helpers for hand-authoring TypeTreeNodeStruct trees directly, for the layouts registered in
this package.

A layout produced this way skips the usual round trip through the binary TypeTree format
(TypeTreeNode -> flat level-encoded list -> TypeTreeNodeStruct): a hand-written layout is
synthesized at read time, never stored in a file, so there is nothing to flatten or
re-parse. These helpers build the same node *shapes* SerializableTreeType.from_root_node
already knows how to interpret (is_array/is_vector/is_string/is_pptr/... in
type_tree_node_struct.py), so Phase 1's interpreter is reused completely unchanged.

IMPORTANT: layouts built with these helpers are hand-authored from public knowledge of
Unity's serialization formats, not derived from an authoritative source (Unity itself, or
the Tpk type-tree database -- see the phase plan for why that isn't available here). Treat
every layout's field set and version range as a best-effort approximation. This is safe
in the sense that a wrong guess fails loudly rather than silently: SerializableStructure.read
requires the exact byte count implied by the layout, and GameAssetFactory reports a mismatch
as UnreadableObject rather than returning plausible-looking garbage.
"""
from __future__ import annotations

from assetripper_io_files.serialized_files.transfer_meta_flags import TransferMetaFlags

from ...structure.assembly.type_trees.type_tree_node_struct import TypeTreeNodeStruct

_NONE = TransferMetaFlags.NO_TRANSFER_FLAGS


def leaf(type_name: str, name: str, *, align: bool = False, treat_as_char: bool = False) -> TypeTreeNodeStruct:
    """A node with no sub-nodes: a primitive field, or the empty leaf inside an array shape."""
    flags = _NONE
    if align:
        flags |= TransferMetaFlags.ALIGN_BYTES
    if treat_as_char:
        flags |= TransferMetaFlags.CHAR_PROPERTY_MASK
    return TypeTreeNodeStruct(type_name, name, 1, flags, ())


def struct_(type_name: str, name: str, *fields: TypeTreeNodeStruct, align: bool = False) -> TypeTreeNodeStruct:
    """A nested Complex-typed field (a struct with its own sub-fields)."""
    flags = TransferMetaFlags.ALIGN_BYTES if align else _NONE
    return TypeTreeNodeStruct(type_name, name, 1, flags, fields)


def root(type_name: str, *fields: TypeTreeNodeStruct) -> TypeTreeNodeStruct:
    """The tree's root node, matching what SerializableTreeType.from_root_node expects
    (a node whose own type/name are discarded; only its sub-nodes become fields)."""
    return TypeTreeNodeStruct(type_name, "Base", 1, _NONE, fields)


def string_field(name: str, *, align: bool = True) -> TypeTreeNodeStruct:
    """The 4-node shape TypeTreeNodeStruct.is_string requires: string { Array { size; data } }.
    Unity always aligns after a string, so `align` defaults on."""
    return TypeTreeNodeStruct(
        "string",
        name,
        1,
        TransferMetaFlags.ALIGN_BYTES if align else _NONE,
        (
            TypeTreeNodeStruct(
                "Array",
                "Array",
                1,
                _NONE,
                (leaf("int", "size"), leaf("char", "data")),
            ),
        ),
    )


def array_field(name: str, element: TypeTreeNodeStruct, *, align: bool = True) -> TypeTreeNodeStruct:
    """The `is_array` shape used inside a `vector`/`map`/named-vector wrapper: Array { size; data }.
    `element` becomes the "data" node -- pass any node shape (leaf, struct_, string_field, ...).
    """
    data = TypeTreeNodeStruct(element.type_name, "data", element.version, element.meta_flag, element.sub_nodes)
    return TypeTreeNodeStruct(
        "Array",
        name,
        1,
        TransferMetaFlags.ALIGN_BYTES if align else _NONE,
        (leaf("int", "size"), data),
    )


def vector_field(name: str, element: TypeTreeNodeStruct, *, align: bool = True) -> TypeTreeNodeStruct:
    """The `is_vector` shape: vector { Array { size; data } }. This is what a C# `List<T>` or
    array field serializes as."""
    return TypeTreeNodeStruct(
        "vector",
        name,
        1,
        TransferMetaFlags.ALIGN_BYTES if align else _NONE,
        (array_field("Array", element, align=False),),
    )


def pptr_field(name: str, target: str = "Object", *, path_id_64: bool = True) -> TypeTreeNodeStruct:
    """The `is_pptr` shape: PPtr<target> { int m_FileID; (SInt64|int) m_PathID }.

    path_id_64 selects the m_PathID width the layout declares -- SerializableTreeType reads
    the actual width from this node's type name (see
    structure/assembly/type_trees/serializable_tree_type.py:_pointer_type_for), so this must
    match the file's real generation. 64-bit path IDs have been the default since very early
    (format version >= BF_LargeFilesSupport is unrelated to this -- path ID width is
    determined per-object-format, not per-bundle-format); default True covers the modern and
    overwhelmingly common case.
    """
    path_id_type = "SInt64" if path_id_64 else "int"
    return TypeTreeNodeStruct(
        f"PPtr<{target}>",
        name,
        1,
        _NONE,
        (leaf("int", "m_FileID"), leaf(path_id_type, "m_PathID")),
    )


def pair_field(name: str, first: TypeTreeNodeStruct, second: TypeTreeNodeStruct) -> TypeTreeNodeStruct:
    """The `is_pair` shape: pair { first; second }."""
    first_node = TypeTreeNodeStruct(first.type_name, "first", first.version, first.meta_flag, first.sub_nodes)
    second_node = TypeTreeNodeStruct(second.type_name, "second", second.version, second.meta_flag, second.sub_nodes)
    return TypeTreeNodeStruct("pair", name, 1, _NONE, (first_node, second_node))


def map_field(name: str, key: TypeTreeNodeStruct, value: TypeTreeNodeStruct, *, align: bool = True) -> TypeTreeNodeStruct:
    """The `is_map` shape: map { Array { size; pair { first=key; second=value } } }."""
    return TypeTreeNodeStruct(
        "map",
        name,
        1,
        TransferMetaFlags.ALIGN_BYTES if align else _NONE,
        (array_field("Array", pair_field("data", key, value), align=False),),
    )

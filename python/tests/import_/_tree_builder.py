"""
Test-only helpers for building Unity TypeTrees and matching serialized bytes by hand.

No real Unity assets are available in this environment, so the dynamic reader is verified
by constructing both sides of the contract: a type tree describing a layout, and bytes laid
out according to that layout. Mirrors the approach in tests/io_files_bundle/_bundle_builder.py.
"""
from __future__ import annotations

import struct

from assetripper_io_files.serialized_files.parser.type_trees.type_tree import TypeTree
from assetripper_io_files.serialized_files.parser.type_trees.type_tree_node import TypeTreeNode
from assetripper_io_files.serialized_files.transfer_meta_flags import TransferMetaFlags


def node(type_name: str, name: str, level: int, align: bool = False, extra_flags=None) -> TypeTreeNode:
    """Equivalent of C#'s `new TypeTreeNode(type, name, level, align)` test constructor."""
    result = TypeTreeNode()
    result.type = type_name
    result.name = name
    result.level = level
    flags = TransferMetaFlags.NO_TRANSFER_FLAGS
    if align:
        flags |= TransferMetaFlags.ALIGN_BYTES
    if extra_flags is not None:
        flags |= extra_flags
    result.meta_flag = flags
    return result


def tree(*nodes: TypeTreeNode) -> TypeTree:
    result = TypeTree()
    result.nodes = list(nodes)
    return result


def string_nodes(name: str, level: int, align: bool = False) -> list[TypeTreeNode]:
    """The 4-node shape Unity uses for a string field."""
    return [
        node("string", name, level, align),
        node("Array", "Array", level + 1),
        node("int", "size", level + 2),
        node("char", "data", level + 2),
    ]


def vector_nodes(name: str, element_type: str, level: int, align: bool = False) -> list[TypeTreeNode]:
    """The 4-node shape Unity uses for a vector<element_type> field."""
    return [
        node("vector", name, level, align),
        node("Array", "Array", level + 1),
        node("int", "size", level + 2),
        node(element_type, "data", level + 2),
    ]


def pptr_nodes(name: str, target: str = "GameObject", level: int = 1, path_id_type: str = "SInt64") -> list[TypeTreeNode]:
    return [
        node(f"PPtr<{target}>", name, level),
        node("int", "m_FileID", level + 1),
        node(path_id_type, "m_PathID", level + 1),
    ]


def rect_nodes(name: str, level: int) -> list[TypeTreeNode]:
    """The 5-node shape Unity uses for a `Rectf` field: {x, y, width, height}."""
    return [
        node("Rectf", name, level),
        node("float", "x", level + 1),
        node("float", "y", level + 1),
        node("float", "width", level + 1),
        node("float", "height", level + 1),
    ]


def vector2_nodes(name: str, level: int) -> list[TypeTreeNode]:
    """The 3-node shape Unity uses for a `Vector2f` field: {x, y}."""
    return [
        node("Vector2f", name, level),
        node("float", "x", level + 1),
        node("float", "y", level + 1),
    ]


def vector4_nodes(name: str, level: int) -> list[TypeTreeNode]:
    """The 5-node shape Unity uses for a `Vector4f` field: {x, y, z, w}."""
    return [
        node("Vector4f", name, level),
        node("float", "x", level + 1),
        node("float", "y", level + 1),
        node("float", "z", level + 1),
        node("float", "w", level + 1),
    ]


def unity_string(value: str) -> bytes:
    """int32 length + UTF-8 bytes + padding to a 4-byte boundary (strings always align)."""
    encoded = value.encode("utf-8")
    out = struct.pack("<i", len(encoded)) + encoded
    return out + b"\x00" * (-len(out) % 4)


def unity_array(fmt: str, values) -> bytes:
    """int32 count + packed elements, with NO trailing alignment.

    Callers add the alignment padding themselves when targeting Unity >= 2017, so tests can
    exercise the version-gated array alignment rule in both directions.
    """
    return struct.pack("<i", len(values)) + struct.pack(f"<{len(values)}{fmt}", *values)


def pad_to_4(data: bytes) -> bytes:
    return data + b"\x00" * (-len(data) % 4)

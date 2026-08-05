"""ECMA-335 II.23.2 compressed integer encoding.

Used both for the length prefix of every #Blob heap entry, and inside signature blobs (element
counts, TypeDefOrRefEncoded tokens, generic argument counts, ...).
"""
from __future__ import annotations


def read_compressed_uint(data: bytes, offset: int) -> "tuple[int, int]":
    """Returns (value, next_offset)."""
    first = data[offset]
    if first & 0x80 == 0:
        return first, offset + 1
    if first & 0xC0 == 0x80:
        value = ((first & 0x3F) << 8) | data[offset + 1]
        return value, offset + 2
    if first & 0xE0 == 0xC0:
        value = ((first & 0x1F) << 24) | (data[offset + 1] << 16) | (data[offset + 2] << 8) | data[offset + 3]
        return value, offset + 4
    raise ValueError(f"Invalid compressed integer prefix byte 0x{first:02X} at offset {offset}")


# Signed compressed integers (II.23.2.2) are deliberately not implemented -- nothing in this
# reader needs to interpret one. The only place they appear is `ARRAY`'s per-dimension lower
# bounds in a type signature (signature.py), which this reader skips over uninterpreted (byte
# length is identical whether read as signed or unsigned, since the sign only affects how the
# already-read bits are interpreted, not how many bytes are consumed).


def encode_type_def_or_ref(table_index: int, row_index_zero_based: int) -> int:
    """TypeDefOrRefEncoded (II.23.2.8): tag in the low 2 bits (0=TypeDef, 1=TypeRef,
    2=TypeSpec), row index (1-based) in the rest."""
    return ((row_index_zero_based + 1) << 2) | table_index


def decode_type_def_or_ref(encoded: int) -> "tuple[int, int]":
    """Returns (tag 0/1/2, row_index_zero_based)."""
    tag = encoded & 0x3
    row_index = (encoded >> 2) - 1
    return tag, row_index

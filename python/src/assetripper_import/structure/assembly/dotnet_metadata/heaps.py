"""The four metadata heap kinds (ECMA-335 II.24.2.3), each a random-access-by-index reader
over a slice of the metadata root's bytes. All indexes are byte offsets into the heap
(0-based), except GuidHeap which is 1-based per spec (index 0 means "no guid")."""
from __future__ import annotations

from .compressed_integer import read_compressed_uint


class StringsHeap:
    """#Strings: UTF-8, NUL-terminated entries."""

    def __init__(self, data: bytes):
        self._data = data

    def get(self, index: int) -> str:
        if index == 0:
            return ""
        end = self._data.index(b"\x00", index)
        return self._data[index:end].decode("utf-8")


class UserStringsHeap:
    """#US: compressed-length-prefixed UTF-16LE entries (plus a trailing has-special-char
    byte this reader ignores -- not needed for field/type declaration recovery)."""

    def __init__(self, data: bytes):
        self._data = data

    def get(self, index: int) -> str:
        if index == 0:
            return ""
        length, string_start = read_compressed_uint(self._data, index)
        if length == 0:
            return ""
        # `length` includes the trailing 1-byte has-special-char marker.
        utf16_byte_count = length - 1
        return self._data[string_start:string_start + utf16_byte_count].decode("utf-16-le")


class GuidHeap:
    """#GUID: a flat array of 16-byte GUIDs, 1-based index (0 means "no guid")."""

    def __init__(self, data: bytes):
        self._data = data

    def get(self, index: int) -> "bytes | None":
        if index == 0:
            return None
        start = (index - 1) * 16
        return self._data[start:start + 16]


class BlobHeap:
    """#Blob: compressed-length-prefixed opaque byte entries."""

    def __init__(self, data: bytes):
        self._data = data

    def get(self, index: int) -> bytes:
        if index == 0:
            return b""
        length, start = read_compressed_uint(self._data, index)
        return self._data[start:start + length]

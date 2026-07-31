"""
Port of AssetRipper.IO.Endian.EndianSpanReader (external NuGet dependency, source not
vendored in this repo -- reconstructed from its call sites in AssetRipper.Import).

C# declares this as a `ref struct` cursor over a `ReadOnlySpan<byte>` and threads it
through the reader as `ref EndianSpanReader`. Python has no ref-struct, so this is a
plain mutable class -- callers pass the object rather than a reference, which is
equivalent in effect.

Performance note: this is invoked per-field across potentially hundreds of thousands of
assets, so reads go through pre-built `struct.Struct` objects using `unpack_from` against
the backing buffer. Primitive arrays are unpacked in one bulk call rather than element by
element, which is a deliberate improvement over the C# loop.
"""
from __future__ import annotations

import struct

from .endian_type import EndianType


def _formats(prefix: str) -> dict[str, struct.Struct]:
    return {
        "b": struct.Struct(prefix + "b"),
        "B": struct.Struct(prefix + "B"),
        "h": struct.Struct(prefix + "h"),
        "H": struct.Struct(prefix + "H"),
        "i": struct.Struct(prefix + "i"),
        "I": struct.Struct(prefix + "I"),
        "q": struct.Struct(prefix + "q"),
        "Q": struct.Struct(prefix + "Q"),
        "f": struct.Struct(prefix + "f"),
        "d": struct.Struct(prefix + "d"),
    }


_LITTLE = _formats("<")
_BIG = _formats(">")


class EndianSpanReader:
    __slots__ = ("_data", "_position", "endian_type", "_s", "_prefix")

    def __init__(self, data, endian: EndianType = EndianType.LITTLE_ENDIAN, offset: int = 0):
        self._data = data
        self._position = offset
        self.endian_type = endian
        big = endian == EndianType.BIG_ENDIAN
        self._s = _BIG if big else _LITTLE
        self._prefix = ">" if big else "<"

    @property
    def position(self) -> int:
        return self._position

    @position.setter
    def position(self, value: int) -> None:
        self._position = value

    @property
    def length(self) -> int:
        return len(self._data)

    @property
    def remaining(self) -> int:
        return len(self._data) - self._position

    def _unpack(self, key: str) -> int | float:
        s = self._s[key]
        try:
            value = s.unpack_from(self._data, self._position)[0]
        except struct.error as ex:
            raise EOFError(
                f"End of stream reading {key} at {self._position} of {len(self._data)}"
            ) from ex
        self._position += s.size
        return value

    def read_boolean(self) -> bool:
        return self._unpack("B") != 0

    def read_byte(self) -> int:
        return self._unpack("B")

    def read_sbyte(self) -> int:
        return self._unpack("b")

    def read_char(self) -> str:
        """A 2-byte UTF-16 code unit.

        Note this is only reached for `PrimitiveType.CHAR`, which SerializableTreeType
        produces from a `ushort`/`UInt16` node carrying the CHAR_PROPERTY_MASK meta flag.
        A Unity type tree node literally named "char" maps to PrimitiveType.BYTE (1 byte)
        instead, matching .NET where `char` is 2 bytes wide.
        """
        return chr(self._unpack("H"))

    def read_int16(self) -> int:
        return self._unpack("h")

    def read_uint16(self) -> int:
        return self._unpack("H")

    def read_int32(self) -> int:
        return self._unpack("i")

    def read_uint32(self) -> int:
        return self._unpack("I")

    def read_int64(self) -> int:
        return self._unpack("q")

    def read_uint64(self) -> int:
        return self._unpack("Q")

    def read_single(self) -> float:
        return self._unpack("f")

    def read_double(self) -> float:
        return self._unpack("d")

    def read_bytes(self, count: int) -> bytes:
        if count < 0:
            raise ValueError(f"Count cannot be negative: {count}")
        end = self._position + count
        if end > len(self._data):
            raise EOFError(f"End of stream reading {count} bytes at {self._position} of {len(self._data)}")
        result = bytes(self._data[self._position:end])
        self._position = end
        return result

    def read_utf8_string(self) -> str:
        """Unity string: int32 byte-length followed by that many UTF-8 bytes.

        Does NOT align -- callers use `read_utf8_string_aligned` for that, matching the
        C# split between `ReadUtf8String()` and the `ReadUtf8StringAligned()` extension.
        """
        count = self.read_int32()
        if count < 0:
            raise ValueError(f"String length cannot be negative: {count}")
        return self.read_bytes(count).decode("utf-8", errors="replace")

    def align(self, alignment: int = 4) -> None:
        mod = self._position % alignment
        if mod != 0:
            self._position += alignment - mod

    def read_primitive_bulk(self, key: str, count: int) -> tuple:
        """Unpack `count` values of format `key` in a single call."""
        size = self._s[key].size
        end = self._position + count * size
        if end > len(self._data):
            raise EOFError(
                f"Stream only has {len(self._data) - self._position} bytes, so {count} "
                f"elements of size {size} cannot be read."
            )
        values = struct.unpack_from(f"{self._prefix}{count}{key}", self._data, self._position)
        self._position = end
        return values

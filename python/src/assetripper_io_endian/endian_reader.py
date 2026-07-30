"""
Port of the subset of AssetRipper.IO.Endian.EndianReader used across Source/ (external
NuGet dependency, source not vendored in this repo -- reconstructed from call sites).

Duck-typed over any stream-like object exposing read()/read_exactly()/position, so this
package has no dependency on assetripper_io_files's own Stream hierarchy (matching the
C# packages, where AssetRipper.IO.Files depends on AssetRipper.IO.Endian, not the
other way around).
"""
from __future__ import annotations

import struct

from .endian_type import EndianType


class EndianReader:
    def __init__(self, stream, endian: EndianType, leave_open: bool = True):
        self.base_stream = stream
        self.endian_type = endian
        self._leave_open = leave_open
        self._byteorder = "big" if endian == EndianType.BIG_ENDIAN else "little"

    def _read_exact(self, size: int) -> bytes:
        buffer = bytearray(size)
        self.base_stream.read_exactly(buffer)
        return bytes(buffer)

    def read(self, buffer: bytearray, offset: int = 0, count: int | None = None) -> int:
        return self.base_stream.read(buffer, offset, count)

    def read_bytes(self, count: int) -> bytes:
        return self._read_exact(count)

    def read_byte(self) -> int:
        return self._read_exact(1)[0]

    def read_sbyte(self) -> int:
        return int.from_bytes(self._read_exact(1), "little", signed=True)

    def read_boolean(self) -> bool:
        return self.read_byte() != 0

    def read_char(self) -> str:
        return self._read_exact(1).decode("latin-1")

    def read_int16(self) -> int:
        return int.from_bytes(self._read_exact(2), self._byteorder, signed=True)

    def read_uint16(self) -> int:
        return int.from_bytes(self._read_exact(2), self._byteorder, signed=False)

    def read_int32(self) -> int:
        return int.from_bytes(self._read_exact(4), self._byteorder, signed=True)

    def read_uint32(self) -> int:
        return int.from_bytes(self._read_exact(4), self._byteorder, signed=False)

    def read_int64(self) -> int:
        return int.from_bytes(self._read_exact(8), self._byteorder, signed=True)

    def read_uint64(self) -> int:
        return int.from_bytes(self._read_exact(8), self._byteorder, signed=False)

    def read_single(self) -> float:
        fmt = ">f" if self.endian_type == EndianType.BIG_ENDIAN else "<f"
        return struct.unpack(fmt, self._read_exact(4))[0]

    def read_double(self) -> float:
        fmt = ">d" if self.endian_type == EndianType.BIG_ENDIAN else "<d"
        return struct.unpack(fmt, self._read_exact(8))[0]

    def read_int32_array(self) -> list[int]:
        count = self.read_int32()
        return [self.read_int32() for _ in range(count)]

    def read_string_zero_term(self) -> str:
        raw = bytearray()
        while True:
            b = self.read_byte()
            if b == 0:
                break
            raw.append(b)
        return raw.decode("utf-8")

    def align_stream(self, alignment: int = 4) -> None:
        pos = self.base_stream.position
        mod = pos % alignment
        if mod != 0:
            self.base_stream.position += alignment - mod

    def dispose(self) -> None:
        if not self._leave_open:
            self.base_stream.dispose()

    def __enter__(self) -> "EndianReader":
        return self

    def __exit__(self, exc_type, exc, tb) -> None:
        self.dispose()

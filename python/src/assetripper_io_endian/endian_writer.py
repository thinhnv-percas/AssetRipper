"""
Port of the subset of AssetRipper.IO.Endian.EndianWriter used across Source/ (external
NuGet dependency, source not vendored in this repo -- reconstructed from call sites).

C#'s single overloaded `Write(...)` is split into type-named methods here (write_byte,
write_int32, write_uint32, ...) since Python has no static overload resolution; each
call site in the ported code picks the method matching the field's declared C# type.
"""
from __future__ import annotations

import struct

from .endian_type import EndianType


class EndianWriter:
    def __init__(self, stream, endian: EndianType, leave_open: bool = True):
        self.base_stream = stream
        self.endian_type = endian
        self._leave_open = leave_open
        self._byteorder = "big" if endian == EndianType.BIG_ENDIAN else "little"

    def write_boolean(self, value: bool) -> None:
        self.base_stream.write(bytes((1 if value else 0,)))

    def write_byte(self, value: int) -> None:
        self.base_stream.write(bytes((value & 0xFF,)))

    def write_sbyte(self, value: int) -> None:
        self.base_stream.write((value & 0xFF).to_bytes(1, "little"))

    def write_int16(self, value: int) -> None:
        self.base_stream.write(value.to_bytes(2, self._byteorder, signed=True))

    def write_uint16(self, value: int) -> None:
        self.base_stream.write(value.to_bytes(2, self._byteorder, signed=False))

    def write_int32(self, value: int) -> None:
        self.base_stream.write(value.to_bytes(4, self._byteorder, signed=True))

    def write_uint32(self, value: int) -> None:
        self.base_stream.write(value.to_bytes(4, self._byteorder, signed=False))

    def write_int64(self, value: int) -> None:
        self.base_stream.write(value.to_bytes(8, self._byteorder, signed=True))

    def write_uint64(self, value: int) -> None:
        self.base_stream.write(value.to_bytes(8, self._byteorder, signed=False))

    def write_single(self, value: float) -> None:
        fmt = ">f" if self.endian_type == EndianType.BIG_ENDIAN else "<f"
        self.base_stream.write(struct.pack(fmt, value))

    def write_double(self, value: float) -> None:
        fmt = ">d" if self.endian_type == EndianType.BIG_ENDIAN else "<d"
        self.base_stream.write(struct.pack(fmt, value))

    def write_bytes(self, data: bytes | bytearray) -> None:
        self.base_stream.write(data, 0, len(data))

    def write_int32_array(self, values: list[int]) -> None:
        self.write_int32(len(values))
        for v in values:
            self.write_int32(v)

    def write_string_zero_term(self, value: str) -> None:
        encoded = value.encode("utf-8")
        self.base_stream.write(encoded, 0, len(encoded))
        self.write_byte(0)

    def align_stream(self, alignment: int = 4) -> None:
        pos = self.base_stream.position
        mod = pos % alignment
        if mod != 0:
            self.base_stream.write(bytes(alignment - mod))

    def dispose(self) -> None:
        if not self._leave_open:
            self.base_stream.dispose()

    def __enter__(self) -> "EndianWriter":
        return self

    def __exit__(self, exc_type, exc, tb) -> None:
        self.dispose()

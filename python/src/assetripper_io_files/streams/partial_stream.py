"""Port of Source/AssetRipper.IO.Files/Streams/PartialStream.cs"""
from __future__ import annotations

from .stream import SeekOrigin, Stream


class PartialStream(Stream):
    """A stream implementation for accessing a subset of another stream."""

    def __init__(self, base_stream: Stream, offset: int, length: int, leave_open: bool = True):
        if offset + length > base_stream.length:
            raise ValueError("The base stream is not long enough for the given offset and length.")
        self._stream = base_stream
        self._base_offset = offset
        self._length = length
        self._leave_open = leave_open
        self._is_disposed = False

    def flush(self) -> None:
        self._stream.flush()

    def read(self, buffer: bytearray, offset: int = 0, count: int | None = None) -> int:
        count = len(buffer) - offset if count is None else count
        count = max(min(count, self._length - self.position), 0)
        return self._stream.read(buffer, offset, count)

    def read_byte(self) -> int:
        return self._stream.read_byte()

    def seek(self, offset: int, origin: SeekOrigin = SeekOrigin.BEGIN) -> int:
        if origin == SeekOrigin.BEGIN:
            return self._stream.seek(self._base_offset + offset, SeekOrigin.BEGIN) - self._base_offset
        elif origin == SeekOrigin.END:
            return self._stream.seek(self._base_offset + self._length + offset, SeekOrigin.BEGIN) - self._base_offset
        else:
            return self._stream.seek(offset, origin) - self._base_offset

    def set_length(self, value: int) -> None:
        raise NotImplementedError

    def write(self, buffer: bytes | bytearray, offset: int = 0, count: int | None = None) -> None:
        count = len(buffer) - offset if count is None else count
        if self.position + count > self._length:
            raise Exception("Partial stream's position is out of range")
        self._stream.write(buffer, offset, count)

    def dispose(self) -> None:
        if self._leave_open:
            self._is_disposed = True
        else:
            self._stream.dispose()

    @property
    def can_read(self) -> bool:
        return self._stream.can_read

    @property
    def can_seek(self) -> bool:
        return self._stream.can_seek

    @property
    def can_write(self) -> bool:
        return self._stream.can_write

    @property
    def length(self) -> int:
        return self._length

    @property
    def position(self) -> int:
        return self._stream.position - self._base_offset

    @position.setter
    def position(self, value: int) -> None:
        if value < 0:
            raise ValueError("Non-negative number required")
        self._stream.position = self._base_offset + value

"""
Port of Source/AssetRipper.IO.Files/Streams/RandomAccessStream.cs

Read a slice of a file using a raw file descriptor directly with os.pread. This allows
a container file with multiple logical files (eg, AssetBundles) to be streamed as if
they are separate files, without buffering the entire file at once or moving the shared
file descriptor's position (os.pread, like .NET's RandomAccess.Read, reads at an explicit
offset without disturbing any other position tracking on that descriptor).
"""
from __future__ import annotations

import os

from .stream import FileStream, SeekOrigin, Stream


class RandomAccessStream(Stream):
    def __init__(self, parent: FileStream, offset: int, length: int):
        if parent.length < offset + length:
            raise ValueError("The parent stream is not long enough for the given offset and length.")
        self.parent = parent
        self.fd = parent.fileno()
        self.base_offset = offset
        self._length = length
        self._position = self.base_offset

    def flush(self) -> None:
        pass  # Read-only streams shouldn't flush.

    def read(self, buffer: bytearray, offset: int = 0, count: int | None = None) -> int:
        count = len(buffer) - offset if count is None else count
        to_read = min(count, self._length - self.position)
        if to_read <= 0:
            return 0
        data = os.pread(self.fd, to_read, self._position)
        buffer[offset:offset + len(data)] = data
        self._position += len(data)
        return len(data)

    def read_byte(self) -> int:
        if self.position >= self._length:
            return -1
        data = os.pread(self.fd, 1, self._position)
        if data:
            self._position += 1
            return data[0]
        return -1

    def seek(self, offset: int, origin: SeekOrigin = SeekOrigin.BEGIN) -> int:
        if origin == SeekOrigin.CURRENT:
            self.position += offset
        elif origin == SeekOrigin.BEGIN:
            self.position = offset
        else:
            self._position = (self._length - offset) + self.base_offset
        return self.position

    def set_length(self, value: int) -> None:
        raise NotImplementedError

    def write(self, buffer: bytes | bytearray, offset: int = 0, count: int | None = None) -> None:
        raise NotImplementedError

    @property
    def can_read(self) -> bool:
        return True

    @property
    def can_seek(self) -> bool:
        return True

    @property
    def can_write(self) -> bool:
        return False

    @property
    def length(self) -> int:
        return self._length

    @property
    def position(self) -> int:
        return self._position - self.base_offset

    @position.setter
    def position(self, value: int) -> None:
        self._position = value + self.base_offset

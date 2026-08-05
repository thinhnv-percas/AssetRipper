"""
Minimal port of the subset of System.IO.Stream that AssetRipper.IO.Files relies on.

Method names are snake_case per Python convention, but kept 1:1 with their C#
counterparts (Read -> read, ReadByte -> read_byte, SetLength -> set_length, ...)
so call sites stay traceable back to the original.
"""
from __future__ import annotations

from enum import Enum


class SeekOrigin(Enum):
    BEGIN = 0
    CURRENT = 1
    END = 2


class Stream:
    """Abstract base, mirroring System.IO.Stream."""

    def flush(self) -> None:
        pass

    def read(self, buffer: bytearray, offset: int = 0, count: int | None = None) -> int:
        raise NotImplementedError

    def read_byte(self) -> int:
        buffer = bytearray(1)
        read = self.read(buffer, 0, 1)
        return buffer[0] if read > 0 else -1

    def read_exactly(self, buffer: bytearray, offset: int = 0, count: int | None = None) -> None:
        count = len(buffer) - offset if count is None else count
        total_read = 0
        while total_read < count:
            read = self.read(buffer, offset + total_read, count - total_read)
            if read == 0:
                raise EOFError("Unable to read beyond the end of the stream.")
            total_read += read

    def seek(self, offset: int, origin: SeekOrigin = SeekOrigin.BEGIN) -> int:
        raise NotImplementedError

    def set_length(self, value: int) -> None:
        raise NotImplementedError

    def write(self, buffer: bytes | bytearray, offset: int = 0, count: int | None = None) -> None:
        raise NotImplementedError

    def write_byte(self, value: int) -> None:
        self.write(bytes((value & 0xFF,)), 0, 1)

    def close(self) -> None:
        self.dispose()

    def dispose(self) -> None:
        pass

    def __enter__(self) -> "Stream":
        return self

    def __exit__(self, exc_type, exc, tb) -> None:
        self.dispose()

    @property
    def can_read(self) -> bool:
        raise NotImplementedError

    @property
    def can_seek(self) -> bool:
        raise NotImplementedError

    @property
    def can_write(self) -> bool:
        raise NotImplementedError

    @property
    def length(self) -> int:
        raise NotImplementedError

    @property
    def position(self) -> int:
        raise NotImplementedError

    @position.setter
    def position(self, value: int) -> None:
        raise NotImplementedError


class MemoryStream(Stream):
    """Port of the subset of System.IO.MemoryStream used here, backed by a bytearray."""

    def __init__(self, buffer: bytes | bytearray | None = None, writable: bool = True):
        self._buffer: bytearray = bytearray(buffer) if buffer is not None else bytearray()
        self._position = 0
        self._writable = writable

    def read(self, buffer: bytearray, offset: int = 0, count: int | None = None) -> int:
        count = len(buffer) - offset if count is None else count
        available = max(min(count, len(self._buffer) - self._position), 0)
        buffer[offset:offset + available] = self._buffer[self._position:self._position + available]
        self._position += available
        return available

    def write(self, buffer: bytes | bytearray, offset: int = 0, count: int | None = None) -> None:
        if not self._writable:
            raise IOError("Stream is not writable.")
        count = len(buffer) - offset if count is None else count
        end = self._position + count
        if end > len(self._buffer):
            self._buffer.extend(bytes(end - len(self._buffer)))
        self._buffer[self._position:end] = buffer[offset:offset + count]
        self._position = end

    def seek(self, offset: int, origin: SeekOrigin = SeekOrigin.BEGIN) -> int:
        if origin == SeekOrigin.BEGIN:
            self._position = offset
        elif origin == SeekOrigin.CURRENT:
            self._position += offset
        else:
            self._position = len(self._buffer) + offset
        return self._position

    def set_length(self, value: int) -> None:
        if value < len(self._buffer):
            del self._buffer[value:]
        else:
            self._buffer.extend(bytes(value - len(self._buffer)))

    def to_array(self) -> bytes:
        return bytes(self._buffer)

    @property
    def can_read(self) -> bool:
        return True

    @property
    def can_seek(self) -> bool:
        return True

    @property
    def can_write(self) -> bool:
        return self._writable

    @property
    def length(self) -> int:
        return len(self._buffer)

    @property
    def position(self) -> int:
        return self._position

    @position.setter
    def position(self, value: int) -> None:
        self._position = value


class FileStream(Stream):
    """Port of the subset of System.IO.FileStream used here, backed by a real OS file handle."""

    def __init__(self, path: str, mode: str = "rb"):
        import io

        self._path = path
        self._file: io.BufferedIOBase = open(path, mode)  # noqa: SIM115

    @property
    def name(self) -> str:
        return self._path

    def fileno(self) -> int:
        return self._file.fileno()

    def read(self, buffer: bytearray, offset: int = 0, count: int | None = None) -> int:
        count = len(buffer) - offset if count is None else count
        data = self._file.read(count)
        buffer[offset:offset + len(data)] = data
        return len(data)

    def write(self, buffer: bytes | bytearray, offset: int = 0, count: int | None = None) -> None:
        count = len(buffer) - offset if count is None else count
        self._file.write(bytes(buffer[offset:offset + count]))

    def seek(self, offset: int, origin: SeekOrigin = SeekOrigin.BEGIN) -> int:
        return self._file.seek(offset, origin.value)

    def set_length(self, value: int) -> None:
        self._file.truncate(value)

    def flush(self) -> None:
        self._file.flush()

    def dispose(self) -> None:
        self._file.close()

    @property
    def can_read(self) -> bool:
        return self._file.readable()

    @property
    def can_seek(self) -> bool:
        return self._file.seekable()

    @property
    def can_write(self) -> bool:
        return self._file.writable()

    @property
    def length(self) -> int:
        import os

        return os.fstat(self._file.fileno()).st_size

    @property
    def position(self) -> int:
        return self._file.tell()

    @position.setter
    def position(self, value: int) -> None:
        self._file.seek(value, 0)

"""Port of Source/AssetRipper.IO.Files/Streams/Smart/SmartStream.cs"""
from __future__ import annotations

from ..multi_file_stream import MultiFileStream
from ..random_access_stream import RandomAccessStream
from ..stream import FileStream, MemoryStream, SeekOrigin, Stream
from .smart_ref_count import SmartRefCount
from .smart_stream_type import SmartStreamType


class SmartStream(Stream):
    def __init__(self, base_stream: Stream | None = None, _copy_from: "SmartStream | None" = None):
        if _copy_from is not None:
            self._stream: Stream | None = None
            self._ref_counter = SmartRefCount()
            self.assign(_copy_from)
        elif base_stream is not None:
            self._stream = base_stream
            self._ref_counter = SmartRefCount()
            self._ref_counter.increase()
        else:
            self._stream = None
            self._ref_counter = SmartRefCount()

    @staticmethod
    def open_read(path: str, file_system) -> "SmartStream":
        return SmartStream(file_system.file.open_read(path))

    @staticmethod
    def open_read_multi(path: str, file_system) -> "SmartStream":
        return SmartStream(MultiFileStream.open_read(path, file_system))

    @staticmethod
    def create_temp() -> "SmartStream":
        """
        Note: unlike the C# original (FileOptions.DeleteOnClose), the temp file here is
        not auto-deleted on dispose -- that flag has no direct cross-platform Python
        equivalent. Callers are responsible for cleanup via LocalFileSystem.
        """
        from ...local_file_system import LocalFileSystem

        temp_file = LocalFileSystem.instance().file.create_temporary()
        return SmartStream(FileStream(temp_file, "r+b"))

    @staticmethod
    def create_memory(buffer: bytes | bytearray | None = None, offset: int = 0, size: int | None = None, writable: bool = True) -> "SmartStream":
        if buffer is None:
            return SmartStream(MemoryStream())
        size = len(buffer) - offset if size is None else size
        return SmartStream(MemoryStream(buffer[offset:offset + size], writable=writable))

    @staticmethod
    def create_null() -> "SmartStream":
        return SmartStream()

    def assign(self, source: "SmartStream") -> None:
        """Copy the reference from another SmartStream."""
        self.free_reference()
        self._stream = source._stream
        self._ref_counter = source._ref_counter
        if not self.is_null:
            self._ref_counter.increase()

    def move(self, source: "SmartStream") -> None:
        """Move the reference from another SmartStream to this one, freeing `source`."""
        self.assign(source)
        source.free_reference()

    def create_reference(self) -> "SmartStream":
        """Create a new reference to the backing stream."""
        return SmartStream(_copy_from=self)

    def create_partial(self, offset: int, size: int) -> "SmartStream":
        self._throw_if_null()

        partial_stream: RandomAccessStream | None = None
        if isinstance(self._stream, FileStream):
            partial_stream = RandomAccessStream(self._stream, offset, size)
        elif isinstance(self._stream, RandomAccessStream):
            partial_stream = RandomAccessStream(self._stream.parent, self._stream.base_offset + offset, size)

        if partial_stream is not None:
            result = SmartStream(_copy_from=self)
            result._stream = partial_stream
            return result

        # Copy otherwise.
        buffer = bytearray(size)
        initial_position = self._stream.position
        self._stream.position = offset
        self._stream.read_exactly(buffer)
        self._stream.position = initial_position
        return SmartStream.create_memory(buffer)

    def flush(self) -> None:
        if self._stream is not None:
            self._stream.flush()

    def read(self, buffer: bytearray, offset: int = 0, count: int | None = None) -> int:
        self._throw_if_null()
        return self._stream.read(buffer, offset, count)

    def read_byte(self) -> int:
        self._throw_if_null()
        return self._stream.read_byte()

    def seek(self, offset: int, origin: SeekOrigin = SeekOrigin.BEGIN) -> int:
        self._throw_if_null()
        return self._stream.seek(offset, origin)

    def set_length(self, value: int) -> None:
        self._throw_if_null()
        self._stream.set_length(value)

    def write(self, buffer: bytes | bytearray, offset: int = 0, count: int | None = None) -> None:
        self._throw_if_null()
        self._stream.write(buffer, offset, count)

    def free_reference(self) -> None:
        """Free the reference to the backing stream and become null."""
        if not self.is_null:
            self._ref_counter.decrease()
            if self._ref_counter.is_zero:
                self._stream.dispose()
            self._stream = None

    def dispose(self) -> None:
        self.free_reference()

    @property
    def can_read(self) -> bool:
        return self._stream.can_read if self._stream is not None else False

    @property
    def can_seek(self) -> bool:
        return self._stream.can_seek if self._stream is not None else False

    @property
    def can_write(self) -> bool:
        return self._stream.can_write if self._stream is not None else False

    @property
    def position(self) -> int:
        return self._stream.position if self._stream is not None else 0

    @position.setter
    def position(self, value: int) -> None:
        self._throw_if_null()
        self._stream.position = value

    @property
    def length(self) -> int:
        return self._stream.length if self._stream is not None else 0

    @property
    def stream_type(self) -> SmartStreamType:
        if self._stream is None:
            return SmartStreamType.NULL
        if isinstance(self._stream, MemoryStream):
            return SmartStreamType.MEMORY
        if isinstance(self._stream, (FileStream, MultiFileStream)):
            return SmartStreamType.FILE
        raise ValueError("Invalid stream type")

    def to_array(self) -> bytes:
        """Write the contents to a byte array, regardless of Position."""
        self._throw_if_null()
        if isinstance(self._stream, MemoryStream):
            return self._stream.to_array()

        initial_position = self._stream.position
        self._stream.position = 0
        data = bytearray(self._stream.length)
        self._stream.read_exactly(data)
        self._stream.position = initial_position
        return bytes(data)

    def _throw_if_null(self) -> None:
        if self.is_null:
            raise ReferenceError("Stream")

    @property
    def is_null(self) -> bool:
        """If true, this has no backing stream."""
        return self._stream is None

    @property
    def ref_count(self) -> int:
        return self._ref_counter.ref_count

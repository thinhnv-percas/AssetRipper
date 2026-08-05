"""Port of Source/AssetRipper.IO.Files/Streams/MultiFileStream.cs"""
from __future__ import annotations

import re

from .split_name_comparer import sort_key
from .stream import SeekOrigin, Stream

_SPLIT_FILE_REGEX = re.compile(r".+\.split[0-9]+$")


class MultiFileStream(Stream):
    def __init__(self, streams):
        self._streams = list(streams)
        if len(self._streams) == 0:
            raise ValueError("No streams were provided.")

        for stream in self._streams:
            if not stream.can_seek:
                raise Exception(f"Stream {stream} isn't seekable")

        self._length = sum(s.length for s in self._streams)
        self._can_read = all(s.can_read for s in self._streams)
        self._can_write = all(s.can_write for s in self._streams)
        self._position = 0
        self._stream_index = 0
        self._current_begin = 0
        self._current_end = 0
        self._current_stream = self._streams[0]
        self._update_current_stream()

    @staticmethod
    def is_multi_file(path: str) -> bool:
        return _SPLIT_FILE_REGEX.match(path) is not None

    @staticmethod
    def exists(path: str, file_system) -> bool:
        if MultiFileStream.is_multi_file(path):
            directory, file = _split_path_without_extension(path, file_system)
            return _exists(directory, file, file_system)
        elif file_system.file.exists(path):
            return True
        else:
            directory, file = _split_path(path, file_system, allow_null_return=True)
            if not file:
                return False
            return _exists(directory, file, file_system)

    @staticmethod
    def open_read(path: str, file_system) -> Stream:
        if MultiFileStream.is_multi_file(path):
            directory, file = _split_path_without_extension(path, file_system)
            return _open_read(directory, file, file_system)
        elif file_system.file.exists(path):
            return file_system.file.open_read(path)
        else:
            directory, file = _split_path(path, file_system)
            return _open_read(directory, file, file_system)

    @staticmethod
    def get_file_path(path: str) -> str:
        if MultiFileStream.is_multi_file(path):
            return path[:path.rindex(".")]
        return path

    @staticmethod
    def get_file_name(path: str) -> str:
        if MultiFileStream.is_multi_file(path):
            return _file_name_without_extension(path)
        return _file_name(path)

    @staticmethod
    def get_files(path: str, file_system) -> list[str]:
        if MultiFileStream.is_multi_file(path):
            directory, file = _split_path_without_extension(path, file_system)
            return _get_files(directory, file, file_system)
        if file_system.file.exists(path):
            return [path]
        return []

    @staticmethod
    def is_name_equals(file_name: str, compare: str) -> bool:
        return MultiFileStream.get_file_name(file_name) == compare

    def flush(self) -> None:
        self._current_stream.flush()

    def seek(self, offset: int, origin: SeekOrigin = SeekOrigin.BEGIN) -> int:
        if origin == SeekOrigin.BEGIN:
            self.position = offset
        elif origin == SeekOrigin.CURRENT:
            self.position += offset
        else:
            self.position = self._length - offset
        return self.position

    def set_length(self, value: int) -> None:
        raise NotImplementedError

    def read_byte(self) -> int:
        value = self._current_stream.read_byte()
        if value >= 0:
            self._position += 1
            if self._position == self._current_end:
                self._next_stream()
        return value

    def read(self, buffer: bytearray, offset: int = 0, count: int | None = None) -> int:
        count = len(buffer) - offset if count is None else count
        read = self._current_stream.read(buffer, offset, count)
        self._position += read
        if self._position == self._current_end:
            self._next_stream()
        return read

    def write_byte(self, value: int) -> None:
        self._current_stream.write_byte(value)
        self._position += 1
        if self._position == self._current_end:
            self._next_stream()

    def write(self, buffer: bytes | bytearray, offset: int = 0, count: int | None = None) -> None:
        count = len(buffer) - offset if count is None else count
        while count > 0:
            available = self._current_end - self._position
            to_write = count if count < available else int(available)
            self._current_stream.write(buffer, offset, to_write)
            self._position += to_write
            if self._position == self._current_end:
                self._next_stream()
            offset += to_write
            count -= to_write

    def dispose(self) -> None:
        for stream in self._streams:
            stream.dispose()

    def _next_stream(self) -> None:
        next_stream_index = self._stream_index + 1
        if next_stream_index < len(self._streams):
            self._current_begin += self._current_stream.length
            self._stream_index = next_stream_index
            self._current_stream = self._streams[self._stream_index]
            self._current_stream.position = 0
            self._current_end += self._current_stream.length

    def _update_current_stream(self) -> None:
        self._current_begin = 0
        self._current_end = 0
        for i, stream in enumerate(self._streams):
            self._stream_index = i
            self._current_stream = stream
            self._current_end = self._current_begin + self._current_stream.length
            if self._current_end > self._position:
                self._current_stream.position = self._position - self._current_begin
                return
            self._current_begin += self._current_stream.length
        self._current_begin -= self._current_stream.length
        self._current_stream.position = self._position - self._current_begin

    @property
    def position(self) -> int:
        return self._position

    @position.setter
    def position(self, value: int) -> None:
        if value < 0:
            raise ValueError("value must be non-negative")
        self._position = value
        if value < self._current_begin or value >= self._current_end:
            self._update_current_stream()
        else:
            self._current_stream.position = value - self._current_begin

    @property
    def length(self) -> int:
        return self._length

    @property
    def can_read(self) -> bool:
        return self._can_read

    @property
    def can_write(self) -> bool:
        return self._can_write

    @property
    def can_seek(self) -> bool:
        return True


def _split_path(path: str, file_system, allow_null_return: bool = False) -> tuple[str, str]:
    directory = file_system.path.get_directory_name(path)
    if directory is None:
        raise Exception("Could not get directory name")
    directory = directory if directory else "."
    file = file_system.path.get_file_name(path)
    if not file and not allow_null_return:
        raise Exception(f"Can't determine file name for {path}")
    return directory, file


def _split_path_without_extension(path: str, file_system) -> tuple[str, str]:
    directory = file_system.path.get_directory_name(path)
    if directory is None:
        raise Exception("Could not get directory name")
    directory = directory if directory else "."
    file = file_system.path.get_file_name_without_extension(path)
    if not file:
        raise Exception(f"Can't determine file name for {path}")
    return directory, file


def _exists(dir_path: str, file_name: str, file_system) -> bool:
    split_file_path = file_system.path.join(dir_path, file_name) + ".split"
    split_files = _get_files(dir_path, file_name, file_system)
    if len(split_files) == 0:
        return False
    for i in range(len(split_files)):
        if f"{split_file_path}{i}" not in split_files:
            return False
    return True


def _get_files(dir_path: str, file_name: str, file_system) -> list[str]:
    if not file_system.directory.exists(dir_path):
        return []
    file_pattern = file_name + ".split*"
    return file_system.directory.get_files(dir_path, file_pattern)


def _open_read(dir_path: str, file_name: str, file_system) -> Stream:
    file_path = file_system.path.join(dir_path, file_name)
    split_file_path = file_path + ".split"

    split_files = _get_files(dir_path, file_name, file_system)
    for i in range(len(split_files)):
        index_file_name = f"{split_file_path}{i}"
        if index_file_name not in split_files:
            raise Exception(
                f"Try to open splited file part '{file_path}' but file part '{index_file_name}' wasn't found"
            )

    split_files = sorted(split_files, key=sort_key)
    streams = []
    try:
        for f in split_files:
            streams.append(file_system.file.open_read(f))
        return MultiFileStream(streams)
    except Exception:
        for stream in streams:
            stream.dispose()
        raise


def _file_name(path: str) -> str:
    import ntpath

    return ntpath.basename(path)


def _file_name_without_extension(path: str) -> str:
    import ntpath

    base = ntpath.basename(path)
    root, _ = ntpath.splitext(base)
    return root

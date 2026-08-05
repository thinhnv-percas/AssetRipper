"""
Port of Source/AssetRipper.IO.Files/VirtualFileSystem.cs and VirtualFileSystem.g.cs.

An in-memory `FileSystem`, backed by a directory-entry tree instead of the OS -- mirrors
upstream's `DirectoryEntry`/`FileEntry` design. Phase 17 (GUI preview) uses this to run the
*real* `ExportHandler.export()` without writing to disk: the resulting tree IS the "files that
would be exported" preview. `get_unique_name` (inherited unmodified from `FileSystem`) is what
makes this trustworthy -- it's the same method real disk export uses to dodge file-name
collisions, so a `VirtualFileSystem` export and a `LocalFileSystem` export of the same game
must produce the exact same path set (see test_virtual_file_system.py's equivalence test).

One deliberate divergence from upstream: `directory.delete` stays unimplemented
(`NotImplementedError`), matching `VirtualDirectoryImplementation` never overriding the base
`DirectoryImplementation.Delete`'s `throw new NotSupportedException()`. Nothing in this port
calls `file_system.directory.delete` (grep-confirmed) so there was no real gap to close.

`directory.enumerate_files`/`enumerate_directories` on a path that doesn't exist return empty
rather than raising -- upstream's `OpenDirectory` throws `DirectoryNotFoundException` here, but
`LocalFileSystem`'s glob-based implementation returns nothing for a missing directory instead,
and Phase 17c's browse endpoint takes `path` straight from a URL query string, where "nothing
found" is the correct response to a bad path, not a 500.
"""
from __future__ import annotations

import fnmatch
import posixpath

from .filesystem import DirectoryImplementation, FileImplementation, FileSystem, PathImplementation
from .streams.stream import MemoryStream


def _path_parts(path: str | None) -> list[str]:
    normalized = (path or "").replace("\\", "/")
    return [part for part in normalized.split("/") if part]


class _DirectoryEntry:
    __slots__ = ("name", "parent", "children", "files")

    def __init__(self, name: str, parent: "_DirectoryEntry | None"):
        self.name = name
        self.parent = parent
        self.children: dict[str, "_DirectoryEntry"] = {}
        self.files: dict[str, "_FileEntry"] = {}

    @property
    def is_root(self) -> bool:
        return self.parent is None

    @property
    def full_name(self) -> str:
        if self.is_root:
            return "/"
        if self.parent.is_root:
            return f"/{self.name}"
        return f"{self.parent.full_name}/{self.name}"

    def create_directory(self, name: str) -> "_DirectoryEntry":
        child = self.children.get(name)
        if child is None:
            child = _DirectoryEntry(name, self)
            self.children[name] = child
        return child

    def create_file(self, name: str) -> "_FileEntry":
        file = self.files.get(name)
        if file is None:
            file = _FileEntry(name, self)
            self.files[name] = file
        else:
            file.data = bytearray()
        return file


class _FileEntry:
    __slots__ = ("name", "parent", "data")

    def __init__(self, name: str, parent: _DirectoryEntry):
        self.name = name
        self.parent = parent
        self.data = bytearray()

    @property
    def full_name(self) -> str:
        if self.parent.is_root:
            return f"/{self.name}"
        return f"{self.parent.full_name}/{self.name}"


class _VirtualFileStream(MemoryStream):
    """A `MemoryStream` whose buffer *is* a `_FileEntry`'s bytes, shared by reference rather
    than copied, so writes through this stream are immediately visible to every other handle
    on the same virtual file -- mirrors upstream's `SmartStream.CreateReference()`."""

    def __init__(self, entry: _FileEntry, writable: bool = True):
        super().__init__(writable=writable)
        self._buffer = entry.data


class _VirtualFileImplementation(FileImplementation):
    def create(self, path: str) -> _VirtualFileStream:
        parts = _path_parts(path)
        if not parts:
            raise ValueError("Path cannot be empty.")
        directory = self._parent._open_directory(parts[:-1])
        entry = directory.create_file(parts[-1])
        return _VirtualFileStream(entry, writable=True)

    def delete(self, path: str) -> None:
        parts = _path_parts(path)
        if not parts:
            raise ValueError("Path cannot be empty.")
        directory = self._parent._open_directory(parts[:-1])
        if directory.files.pop(parts[-1], None) is None:
            raise FileNotFoundError(f"File '{path}' not found.")

    def exists(self, path: str) -> bool:
        parts = _path_parts(path)
        if not parts:
            return False
        directory = self._parent._try_open_directory(parts[:-1])
        return directory is not None and parts[-1] in directory.files

    def open_read(self, path: str) -> _VirtualFileStream:
        return _VirtualFileStream(self._entry_for(path), writable=False)

    def open_write(self, path: str) -> _VirtualFileStream:
        parts = _path_parts(path)
        if not parts:
            raise ValueError("Path cannot be empty.")
        directory = self._parent._open_directory(parts[:-1])
        entry = directory.files.get(parts[-1])
        if entry is None:
            return self.create(path)
        return _VirtualFileStream(entry, writable=True)

    def read_all_bytes(self, path: str) -> bytes:
        return bytes(self._entry_for(path).data)

    def read_all_text(self, path: str, encoding: str = "utf-8") -> str:
        return self.read_all_bytes(path).decode(encoding)

    def write_all_bytes(self, path: str, data: bytes) -> None:
        with self.create(path) as stream:
            stream.write(data)

    def write_all_text(self, path: str, contents: str, encoding: str = "utf-8") -> None:
        self.write_all_bytes(path, contents.encode(encoding))

    def _entry_for(self, path: str) -> _FileEntry:
        parts = _path_parts(path)
        if not parts:
            raise ValueError("Path cannot be empty.")
        directory = self._parent._open_directory(parts[:-1])
        entry = directory.files.get(parts[-1])
        if entry is None:
            raise FileNotFoundError(f"File '{path}' not found.")
        return entry


class _VirtualDirectoryImplementation(DirectoryImplementation):
    def create(self, path: str) -> None:
        current = self._parent._root
        for part in _path_parts(path):
            current = current.create_directory(part)

    def delete(self, path: str) -> None:
        raise NotImplementedError(
            "VirtualFileSystem.directory.delete is not supported -- matches upstream "
            "VirtualFileSystem.cs, which never overrides the base DirectoryImplementation's "
            "NotSupportedException, and nothing in this port calls it."
        )

    def exists(self, path: str) -> bool:
        return self._parent._try_open_directory(_path_parts(path)) is not None

    def enumerate_directories(self, path: str, search_pattern: str = "*"):
        directory = self._parent._try_open_directory(_path_parts(path))
        if directory is None:
            return
        for child in directory.children.values():
            if fnmatch.fnmatch(child.name, search_pattern):
                yield child.full_name

    def enumerate_files(self, path: str, search_pattern: str = "*"):
        directory = self._parent._try_open_directory(_path_parts(path))
        if directory is None:
            return
        for file in directory.files.values():
            if fnmatch.fnmatch(file.name, search_pattern):
                yield file.full_name


class _VirtualPathImplementation(PathImplementation):
    def join(self, *paths: str) -> str:
        return self.get_full_path(posixpath.join(*paths)) if paths else "/"

    def get_directory_name(self, path: str) -> str | None:
        return posixpath.dirname(path)

    def get_extension(self, path: str) -> str:
        return posixpath.splitext(path)[1]

    def get_file_name(self, path: str) -> str:
        return posixpath.basename(path)

    def get_file_name_without_extension(self, path: str) -> str:
        return posixpath.splitext(posixpath.basename(path))[0]

    def get_full_path(self, path: str | None) -> str:
        # The "current directory" is always the root directory; "." and ".." aren't supported.
        if path is None or path in ("", "/", "\\"):
            return "/"
        normalized = path.replace("\\", "/")
        if normalized.endswith("/"):
            normalized = normalized[:-1]
        return normalized if normalized.startswith("/") else f"/{normalized}"

    def get_relative_path(self, relative_to: str, path: str) -> str:
        return posixpath.relpath(path, relative_to)

    def is_path_rooted(self, path: str) -> bool:
        return len(path) > 0 and path[0] in ("/", "\\")


class VirtualFileSystem(FileSystem):
    def __init__(self):
        super().__init__()
        self._root = _DirectoryEntry("", None)
        self._file = _VirtualFileImplementation(self)
        self._directory = _VirtualDirectoryImplementation(self)
        self._path = _VirtualPathImplementation(self)
        self._temporary_directory = "/temp"

    @property
    def file(self) -> _VirtualFileImplementation:
        return self._file

    @property
    def directory(self) -> _VirtualDirectoryImplementation:
        return self._directory

    @property
    def path(self) -> _VirtualPathImplementation:
        return self._path

    @property
    def temporary_directory(self) -> str:
        return self._temporary_directory

    @temporary_directory.setter
    def temporary_directory(self, value: str) -> None:
        if value and value.strip():
            self._temporary_directory = self._path.get_full_path(value)

    def clear(self) -> None:
        self._root.children.clear()
        self._root.files.clear()

    def iter_all_files(self):
        """Every file's absolute path currently in the tree. Not part of the `FileSystem` ABC
        (upstream has no equivalent either) -- added because Phase 17b's `ExportPlan` needs to
        index the whole "would be exported" tree, and the path-set equivalence test (17a/17e)
        needs to compare this tree's full file list against a real `LocalFileSystem` export."""

        def _walk(directory: _DirectoryEntry):
            for file in directory.files.values():
                yield file.full_name
            for child in directory.children.values():
                yield from _walk(child)

        yield from _walk(self._root)

    def _open_directory(self, parts: list[str]) -> _DirectoryEntry:
        current = self._root
        for part in parts:
            child = current.children.get(part)
            if child is None:
                raise NotADirectoryError(f"Directory '{part}' not found.")
            current = child
        return current

    def _try_open_directory(self, parts: list[str]) -> _DirectoryEntry | None:
        current = self._root
        for part in parts:
            current = current.children.get(part)
            if current is None:
                return None
        return current

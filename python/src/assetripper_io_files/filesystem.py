"""
Port of Source/AssetRipper.IO.Files/FileSystem.cs and FileSystem.g.cs.

The C# FileSystem.g.cs is machine-generated boilerplate that delegates each method to the
matching global::System.IO.* static call; here that's just written directly rather than
generated, since Python has no source-generator step.
"""
from __future__ import annotations

import os
import re
import uuid
from abc import ABC, abstractmethod

ACTUAL_MAX_FILE_NAME_LENGTH = 255
"""https://en.wikipedia.org/wiki/Comparison_of_file_systems#Limits"""

RESERVED_CHARACTER_COUNT = 10
"""Reserved for handling file name conflicts: an underscore and up to 9 digits."""

MAX_FILE_NAME_LENGTH = ACTUAL_MAX_FILE_NAME_LENGTH - RESERVED_CHARACTER_COUNT

_RESERVED_NAMES = {
    "aux", "con", "nul", "prn",
    "com1", "com2", "com3", "com4", "com5", "com6", "com7", "com8", "com9",
    "lpt1", "lpt2", "lpt3", "lpt4", "lpt5", "lpt6", "lpt7", "lpt8", "lpt9",
}

def _default_invalid_filename_chars() -> str:
    """Mirrors System.IO.Path.GetInvalidFileNameChars() per platform (Windows vs POSIX)."""
    if os.name == "nt":
        return '"<>|\0' + "".join(chr(c) for c in range(1, 32)) + ":*?\\/"
    return "\0/"


def _invalid_filename_chars_including_colon() -> str:
    """Port of FileSystem.GetInvalidFileNameChars(): also reserves ':' on platforms
    (e.g. Linux) where the OS itself allows it in file names."""
    chars = _default_invalid_filename_chars()
    return chars if ":" in chars else chars + ":"


_FILE_NAME_REGEX = re.compile(f"[{re.escape(_invalid_filename_chars_including_colon())},\\[\\]\\x00-\\x1F]")
_PATH_INVALID_CHARS = "".join(c for c in _default_invalid_filename_chars() if c not in ("\\", "/"))
_PATH_REGEX = re.compile(f"[{re.escape(_PATH_INVALID_CHARS)},\\[\\]\\x00-\\x1F]")


class FileImplementation(ABC):
    def __init__(self, file_system: "FileSystem"):
        self._parent = file_system

    def create(self, path: str):
        raise NotImplementedError

    def delete(self, path: str) -> None:
        raise NotImplementedError

    def exists(self, path: str) -> bool:
        raise NotImplementedError

    def open_read(self, path: str):
        raise NotImplementedError

    def open_write(self, path: str):
        raise NotImplementedError

    def read_all_bytes(self, path: str) -> bytes:
        raise NotImplementedError

    def read_all_text(self, path: str, encoding: str = "utf-8") -> str:
        raise NotImplementedError

    def write_all_bytes(self, path: str, data: bytes) -> None:
        raise NotImplementedError

    def write_all_text(self, path: str, contents: str, encoding: str = "utf-8") -> None:
        raise NotImplementedError

    def create_temporary(self) -> str:
        self._parent.directory.create(self._parent.temporary_directory)
        path = self._parent.path.join(self._parent.temporary_directory, _get_random_string())
        self.create(path).dispose()
        return path


class DirectoryImplementation(ABC):
    def __init__(self, file_system: "FileSystem"):
        self._parent = file_system

    def create(self, path: str) -> None:
        raise NotImplementedError

    def delete(self, path: str) -> None:
        raise NotImplementedError

    def exists(self, path: str) -> bool:
        raise NotImplementedError

    def enumerate_directories(self, path: str, search_pattern: str = "*"):
        raise NotImplementedError

    def enumerate_files(self, path: str, search_pattern: str = "*"):
        raise NotImplementedError

    def get_directories(self, path: str, search_pattern: str = "*") -> list[str]:
        return list(self.enumerate_directories(path, search_pattern))

    def get_files(self, path: str, search_pattern: str = "*") -> list[str]:
        return list(self.enumerate_files(path, search_pattern))

    def create_temporary(self) -> str:
        path = self._parent.path.join(self._parent.temporary_directory, _get_random_string()[:8])
        self.create(path)
        return path


class PathImplementation(ABC):
    def __init__(self, file_system: "FileSystem"):
        self._parent = file_system

    def join(self, *paths: str) -> str:
        raise NotImplementedError

    def get_directory_name(self, path: str) -> str | None:
        raise NotImplementedError

    def get_extension(self, path: str) -> str:
        raise NotImplementedError

    def get_file_name(self, path: str) -> str:
        raise NotImplementedError

    def get_file_name_without_extension(self, path: str) -> str:
        raise NotImplementedError

    def get_full_path(self, path: str) -> str:
        raise NotImplementedError

    def get_relative_path(self, relative_to: str, path: str) -> str:
        raise NotImplementedError

    def is_path_rooted(self, path: str) -> bool:
        raise NotImplementedError


class FileSystem(ABC):
    """Port of Source/AssetRipper.IO.Files/FileSystem.cs and FileSystem.g.cs."""

    def __init__(self):
        self._unique_names_by_initial_path: dict[str, int] = {}

    @property
    @abstractmethod
    def file(self) -> FileImplementation: ...

    @property
    @abstractmethod
    def directory(self) -> DirectoryImplementation: ...

    @property
    @abstractmethod
    def path(self) -> PathImplementation: ...

    @property
    @abstractmethod
    def temporary_directory(self) -> str: ...

    @temporary_directory.setter
    def temporary_directory(self, value: str) -> None: ...

    def delete_temporary_directory(self) -> None:
        if self.directory.exists(self.temporary_directory):
            self.directory.delete(self.temporary_directory)

    def get_unique_name(self, dir_path: str, file_name: str, max_name_length: int) -> str:
        ext: str | None = None
        name: str | None = None
        valid_file_name = file_name
        if len(file_name.encode("utf-8")) > max_name_length:
            from .utf8_truncation import truncate_to_utf8_byte_length

            ext = self.path.get_extension(valid_file_name)
            name = truncate_to_utf8_byte_length(file_name, max_name_length - len(ext.encode("utf-8")))
            valid_file_name = name + ext

        if not self.directory.exists(dir_path):
            return valid_file_name

        if name is None:
            name = self.path.get_file_name_without_extension(valid_file_name)
        if not is_reserved_name(name):
            if not self.file.exists(self.path.join(dir_path, valid_file_name)):
                return valid_file_name

        if ext is None:
            ext = self.path.get_extension(valid_file_name)

        key = self.path.join(dir_path, f"{name}{ext}")
        counter = self._unique_names_by_initial_path.get(key, 0)

        while True:
            proposed_name = f"{name}_{counter}{ext}"
            if not self.file.exists(self.path.join(dir_path, proposed_name)):
                self._unique_names_by_initial_path[key] = counter
                return proposed_name
            counter += 1


def remove_clone_suffixes(path: str) -> str:
    return path.replace("(Clone)", "")


def remove_instance_suffixes(path: str) -> str:
    return path.replace("(Instance)", "")


def fix_invalid_file_name_characters(path: str) -> str:
    return _FILE_NAME_REGEX.sub("_", path)


def fix_invalid_path_characters(path: str) -> str:
    replaced = _PATH_REGEX.sub("_", path)
    if " /" in replaced or "/ " in replaced:
        entries = [e.strip() for e in replaced.split("/") if e.strip()]
        return "/".join(entries)
    return replaced.strip()


def is_reserved_name(name: str) -> bool:
    import platform

    return platform.system() == "Windows" and len(name) in (3, 4) and name.lower() in _RESERVED_NAMES


def _get_random_string() -> str:
    return str(uuid.uuid4())

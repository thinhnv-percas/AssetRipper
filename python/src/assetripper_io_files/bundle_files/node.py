"""Port of Source/AssetRipper.IO.Files/BundleFiles/Node.cs

Only FileStreamNode (the modern UnityFS format) is ported as a concrete subclass --
see file_stream/file_stream_node.py. The legacy Archive/RawWeb node types are not
ported (see bundle_files/__init__.py module docstring for the full scope note).
"""
from __future__ import annotations

from abc import ABC, abstractmethod

from ..special_file_names import fix_file_identifier


class Node(ABC):
    def __init__(self):
        self._path: str = ""
        self._path_fixed: str = ""
        self.offset: int = 0
        self.size: int = 0

    @property
    def path(self) -> str:
        return self._path

    @path.setter
    def path(self, value: str) -> None:
        self._path = value
        self._path_fixed = fix_file_identifier(value)

    @property
    def path_fixed(self) -> str:
        return self._path_fixed

    @abstractmethod
    def write(self, writer) -> None: ...

    def __str__(self) -> str:
        return self.path_fixed

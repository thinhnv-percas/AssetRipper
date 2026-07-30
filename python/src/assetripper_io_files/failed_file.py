"""Port of Source/AssetRipper.IO.Files/FailedFile.cs"""
from __future__ import annotations

from .file_base import FileBase
from .streams.smart import SmartStream
from .streams.stream import Stream


class FailedFile(FileBase):
    def __init__(self):
        super().__init__()
        self.stack_trace: str = ""

    def read(self, stream: SmartStream) -> None:
        pass

    def write(self, stream: Stream) -> None:
        raise NotImplementedError

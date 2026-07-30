"""Port of Source/AssetRipper.IO.Files/SerializedFiles/SerializedFileException.cs"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from ..build_target import BuildTarget


class SerializedFileException(Exception):
    def __init__(
        self,
        message: str,
        version: UnityVersion,
        platform: BuildTarget,
        class_id_type: int,
        file_name: str,
        file_path: str,
        inner_exception: Exception | None = None,
    ):
        if not file_name:
            raise ValueError("file_name must not be empty")
        if not file_path:
            raise ValueError("file_path must not be empty")

        super().__init__(message, inner_exception) if inner_exception else super().__init__(message)
        self.message = message
        self.version = version
        self.platform = platform
        self.class_id_type = class_id_type
        self.file_name = file_name
        self.file_path = file_path
        self.__cause__ = inner_exception

    def __str__(self) -> str:
        lines = [
            "SerializedFileException:",
            f" v:{self.version} p:{self.platform.name} t:{self.class_id_type} n:{self.file_name}",
            f"Path:{self.file_path}",
            f"Message: {self.message}",
        ]
        if self.__cause__ is not None:
            lines.append(f"Inner: {self.__cause__}")
        return "\n".join(lines)

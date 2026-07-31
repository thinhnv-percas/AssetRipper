"""Port of Source/AssetRipper.SerializationLogic/SerializablePointerType.cs"""
from __future__ import annotations

from .primitive_type import PrimitiveType
from .serializable_type import SerializableType


class SerializablePointerType(SerializableType):
    _shared: "SerializablePointerType | None" = None

    def __init__(self):
        super().__init__("UnityEngine", PrimitiveType.COMPLEX, "Object")
        self.max_depth = 0

    @staticmethod
    def shared() -> "SerializablePointerType":
        if SerializablePointerType._shared is None:
            SerializablePointerType._shared = SerializablePointerType()
        return SerializablePointerType._shared

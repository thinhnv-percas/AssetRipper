"""Port of Source/AssetRipper.SerializationLogic/SerializablePrimitiveType.cs"""
from __future__ import annotations

from .primitive_type import PrimitiveType, to_system_type_name
from .serializable_type import SerializableType

_cache: dict[PrimitiveType, "SerializablePrimitiveType"] = {}


class SerializablePrimitiveType(SerializableType):
    def __init__(self, primitive_type: PrimitiveType):
        super().__init__("System", primitive_type, to_system_type_name(primitive_type))
        self.max_depth = 0

    @staticmethod
    def get_or_create(primitive_type: PrimitiveType) -> "SerializablePrimitiveType":
        result = _cache.get(primitive_type)
        if result is None:
            result = SerializablePrimitiveType(primitive_type)
            _cache[primitive_type] = result
        return result

"""
Python port of the IL-free slice of Source/AssetRipper.SerializationLogic.

Upstream this project has two halves: a small set of data models describing serializable
field layouts, and `FieldSerializer`, which derives those layouts from .NET metadata via
AsmResolver. Only the data models are ported -- the layouts in this port come from Unity
TypeTrees instead (see assetripper_import.structure.assembly.type_trees), so nothing here
needs to read IL.

Not ported: FieldSerializer.cs, FieldSerializer.Logic.cs, MonoType.cs, AsmUtils.cs,
EngineTypePredicates.cs, Extensions/, ResolutionException.cs.
"""
from .mono_utils import to_primitive_type
from .primitive_type import PrimitiveType, get_size, is_csharp_primitive, to_system_type_name
from .serializable_pointer_type import SerializablePointerType
from .serializable_primitive_type import SerializablePrimitiveType
from .serializable_type import Field, SerializableType

__all__ = [
    "PrimitiveType",
    "get_size",
    "is_csharp_primitive",
    "to_system_type_name",
    "to_primitive_type",
    "SerializableType",
    "Field",
    "SerializablePrimitiveType",
    "SerializablePointerType",
]

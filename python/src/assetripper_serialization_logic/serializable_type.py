"""Port of Source/AssetRipper.SerializationLogic/SerializableType.cs

The central abstraction of the dynamic reading path: a field layout description that
downstream code consumes without knowing whether it came from IL analysis (upstream's
FieldSerializer) or from a Unity TypeTree (SerializableTreeType, which is what this
port uses).
"""
from __future__ import annotations

from dataclasses import dataclass

from . import mono_utils
from .primitive_type import PrimitiveType, is_csharp_primitive


@dataclass(frozen=True, slots=True)
class Field:
    """Port of the nested `SerializableType.Field` record struct."""

    type: "SerializableType"
    array_depth: int
    name: str
    align: bool

    @property
    def is_array(self) -> bool:
        return self.array_depth == 1

    def __str__(self) -> str:
        return f"{self.type}{'[]' * self.array_depth} {self.name}"


class SerializableType:
    def __init__(self, namespace: str | None, type: PrimitiveType, name: str):
        if name is None:
            raise ValueError("name must not be None")
        self.namespace = namespace
        self.type = type
        self.name = name
        self.fields: list[Field] = []
        self.version: int = 1
        """C#'s `virtual int Version => 1`, overridden by SerializableTreeType."""
        self.flow_mapped_in_yaml: bool = False
        """C#'s `virtual bool FlowMappedInYaml => false`, overridden by SerializableTreeType."""
        self.max_depth: int = -1
        """The maximum depth of the structure.

        A type with no fields has a depth of 0, such as a primitive type, including
        strings. A type with a single field has a depth of 1 + the depth of that field.
        Arrays do not increase depth -- a type with a `string[]` field has depth 1, not 2.
        Despite technically having two numeric fields, PPtrs are treated as primitive
        types with a depth of 0. A negative value means the depth is not yet known.
        """
        self._cyclic_references: set[int] | None = None

    def is_primitive(self) -> bool:
        return is_csharp_primitive(self.type)

    def is_engine_struct(self) -> bool:
        return mono_utils.is_engine_struct(self.namespace, self.name)

    def is_engine_pointer(self) -> bool:
        return mono_utils.is_object(self.namespace, self.name) or mono_utils.is_mono_prime(self.namespace, self.name)

    @property
    def full_name(self) -> str:
        return self.name if not self.namespace else f"{self.namespace}.{self.name}"

    @property
    def is_max_depth_known(self) -> bool:
        return self.max_depth >= 0

    def add_cyclic_reference(self, other: "SerializableType") -> None:
        if self._cyclic_references is None:
            self._cyclic_references = set()
        # Keyed by identity: C# uses a HashSet<SerializableType> with reference equality,
        # and SerializableType instances are not value-comparable here either.
        self._cyclic_references.add(id(other))

    def is_cyclic_reference(self, other: "SerializableType") -> bool:
        return self._cyclic_references is not None and id(other) in self._cyclic_references

    def create_serializable_structure(self):
        """Port of the `CreateSerializableStructure()` extension method from
        AssetRipper.SourceGenerated.Extensions -- a plain function here, since that
        package is a generated-code dependency this port doesn't have."""
        from assetripper_import.structure.assembly.serializable.serializable_structure import SerializableStructure

        return SerializableStructure.create(self, 0)

    def __str__(self) -> str:
        return self.full_name

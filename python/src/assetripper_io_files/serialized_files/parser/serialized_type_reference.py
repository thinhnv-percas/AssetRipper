"""
Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/SerializedTypeReference.cs

A reference type for a serializable C# type, used for fields with the
[SerializeReference] attribute.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from ..format_version import FormatVersion
from .serialized_type_base import SerializedTypeBase


class SerializedTypeReference(SerializedTypeBase):
    def __init__(self):
        super().__init__()
        self.class_name: str = ""
        self.namespace: str = ""
        self.asm_name: str = ""

    @property
    def full_name(self) -> str:
        return self.class_name if not self.namespace else f"{self.namespace}.{self.class_name}"

    def _ignore_script_type_for_hash(self, format_version: FormatVersion, unity_version: UnityVersion) -> bool:
        return False

    def _read_type_dependencies(self, reader) -> None:
        self.class_name = reader.read_string_zero_term()
        self.namespace = reader.read_string_zero_term()
        self.asm_name = reader.read_string_zero_term()

    def _write_type_dependencies(self, writer) -> None:
        writer.write_string_zero_term(self.class_name)
        writer.write_string_zero_term(self.namespace)
        writer.write_string_zero_term(self.asm_name)

    def __eq__(self, other: object) -> bool:
        if not isinstance(other, SerializedTypeReference):
            return NotImplemented
        return (
            self.raw_type_id == other.raw_type_id
            and self.is_stripped_type == other.is_stripped_type
            and self.script_type_index == other.script_type_index
            and self.old_type == other.old_type
            and self.script_id == other.script_id
            and self.old_type_hash == other.old_type_hash
            and self.class_name == other.class_name
            and self.namespace == other.namespace
            and self.asm_name == other.asm_name
        )

    def __hash__(self) -> int:
        return hash((
            self.raw_type_id, self.is_stripped_type, self.script_type_index,
            self.old_type_hash, self.class_name, self.namespace, self.asm_name,
        ))

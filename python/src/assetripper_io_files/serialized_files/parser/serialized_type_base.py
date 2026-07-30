"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/SerializedTypeBase.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod

from assetripper_primitives import UnityVersion

from ..format_version import FormatVersion
from .hash128 import Hash128
from .type_trees.type_tree import TypeTree


class SerializedTypeBase(ABC):
    def __init__(self):
        self.raw_type_id: int = 0
        self.is_stripped_type: bool = False
        self.script_type_index: int = 0
        """For MonoBehaviour, this specifies script type."""
        self.old_type: TypeTree = TypeTree()
        """The type of the class."""
        self.script_id: Hash128 = Hash128()
        self.old_type_hash: Hash128 = Hash128()

    @property
    def type_id(self) -> int:
        return self.raw_type_id

    @type_id.setter
    def type_id(self, value: int) -> None:
        self.raw_type_id = value

    @property
    def original_type_id(self) -> int:
        """For versions less than 17, specifies TypeID or -ScriptTypeIndex - 1 for MonoBehaviour."""
        return self.raw_type_id

    @original_type_id.setter
    def original_type_id(self, value: int) -> None:
        self.raw_type_id = value

    def read(self, reader, has_type_tree: bool) -> None:
        self.raw_type_id = reader.read_int32()
        if reader.generation < FormatVersion.REFACTORED_CLASS_ID:
            type_id_local = -1 if self.raw_type_id < 0 else self.raw_type_id
            self.is_stripped_type = False
            self.script_type_index = -1
        else:
            type_id_local = self.raw_type_id
            self.is_stripped_type = reader.read_boolean()

        if reader.generation >= FormatVersion.REFACTOR_TYPE_DATA:
            self.script_type_index = reader.read_int16()

        if reader.generation >= FormatVersion.HAS_TYPE_TREE_HASHES:
            read_script_id = (
                type_id_local == -1
                or type_id_local == 114
                or (not self._ignore_script_type_for_hash(reader.generation, reader.version) and self.script_type_index >= 0)
            )
            if read_script_id:
                self.script_id = Hash128.read(reader)
            self.old_type_hash = Hash128.read(reader)

        if has_type_tree:
            self.old_type.read(reader)
            if reader.generation < FormatVersion.HAS_TYPE_TREE_HASHES:
                pass  # OldTypeHash gets recalculated here in a complicated way on 2023.
            elif reader.generation >= FormatVersion.STORES_TYPE_DEPENDENCIES:
                self._read_type_dependencies(reader)

    @abstractmethod
    def _read_type_dependencies(self, reader) -> None: ...

    @abstractmethod
    def _ignore_script_type_for_hash(self, format_version: FormatVersion, unity_version: UnityVersion) -> bool: ...

    @abstractmethod
    def _write_type_dependencies(self, writer) -> None: ...

    def write(self, writer, has_type_tree: bool) -> None:
        writer.write_int32(self.raw_type_id)
        if has_is_stripped_type(writer.generation):
            writer.write_boolean(self.is_stripped_type)
        if has_script_type_index(writer.generation):
            writer.write_int16(self.script_type_index)
        if has_hash(writer.generation):
            write_script_id = (
                self.raw_type_id == -1
                or self.raw_type_id == 114
                or (not self._ignore_script_type_for_hash(writer.generation, writer.version) and self.script_type_index >= 0)
            )
            if write_script_id:
                self.script_id.write(writer)
            self.old_type_hash.write(writer)

        if has_type_tree:
            self.old_type.write(writer)
            if has_type_dependencies(writer.generation):
                self._write_type_dependencies(writer)

    def __str__(self) -> str:
        return str(self.type_id)


def has_is_stripped_type(generation: FormatVersion) -> bool:
    """5.5.0a and greater, ie format version 16+."""
    return generation >= FormatVersion.REFACTORED_CLASS_ID


def has_script_type_index(generation: FormatVersion) -> bool:
    """5.5.0 and greater, ie format version 17+."""
    return generation >= FormatVersion.REFACTOR_TYPE_DATA


def has_hash(generation: FormatVersion) -> bool:
    """5.0.0unk2 and greater, ie format version 13+."""
    return generation >= FormatVersion.HAS_TYPE_TREE_HASHES


def has_type_dependencies(generation: FormatVersion) -> bool:
    """2019.3 and greater, ie format version 21+."""
    return generation >= FormatVersion.STORES_TYPE_DEPENDENCIES

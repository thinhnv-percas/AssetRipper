"""Port of Source/AssetRipper.Import/Structure/Assembly/Serializable/SerializablePair.cs"""
from __future__ import annotations

from assetripper_serialization_logic.primitive_type import PrimitiveType

from .serializable_value import SerializableValue


class SerializablePair:
    __slots__ = ("depth", "type", "first", "second")

    def __init__(self, type, depth: int):
        if len(type.fields) != 2:
            raise ValueError("Pair type must have exactly two fields")
        self.type = type
        self.depth = depth
        self.first = SerializableValue()
        self.second = SerializableValue()

    @property
    def first_field(self):
        return self.type.fields[0]

    @property
    def second_field(self):
        return self.type.fields[1]

    def read(self, reader, version, flags) -> None:
        self.first.read(reader, version, flags, self.depth, self.first_field)
        self.second.read(reader, version, flags, self.depth, self.second_field)

    def walk_editor(self, walker) -> None:
        if self.type.type == PrimitiveType.MAP_PAIR:
            # Upstream note: needs to also handle GUID and Hash128, but those are not
            # used in PlayerSettings, so it doesn't matter right now.
            if self.first_field.type.type == PrimitiveType.STRING:
                pair = (self.first.value, self.second)
                if walker.enter_dictionary_pair(pair):
                    walker.visit_primitive(pair[0])
                    walker.divide_pair(pair)
                    self.second.walk_editor(walker, self.second_field)
                    walker.exit_dictionary_pair(pair)
            else:
                pair = (self.first, self.second)
                if walker.enter_dictionary_pair(pair):
                    self.first.walk_editor(walker, self.first_field)
                    walker.divide_dictionary_pair(pair)
                    self.second.walk_editor(walker, self.second_field)
                    walker.exit_dictionary_pair(pair)
        else:
            pair = (self.first, self.second)
            if walker.enter_pair(pair):
                self.first.walk_editor(walker, self.first_field)
                walker.divide_pair(pair)
                self.second.walk_editor(walker, self.second_field)
                walker.exit_pair(pair)

    def initialize(self, version) -> None:
        self.first.initialize(version, self.depth, self.first_field)
        self.second.initialize(version, self.depth, self.second_field)

    def reset(self) -> None:
        self.first.reset()
        self.second.reset()

    def __str__(self) -> str:
        return f"({self.first.value}, {self.second.value})"

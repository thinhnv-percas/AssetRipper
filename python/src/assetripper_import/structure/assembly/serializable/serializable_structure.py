"""Port of Source/AssetRipper.Import/Structure/Assembly/Serializable/SerializableStructure.cs

The structure half of the dynamic reader: a whole object (or nested struct), holding one
SerializableValue per field of its SerializableType.

This is the class that makes the rest of the pipeline work without generated code, because
it implements `walk_editor(AssetWalker)` -- which is exactly what the YAML exporter
consumes. See the phase plan for why that matters.
"""
from __future__ import annotations

from assetripper_assets.unity_asset_base import UnityAssetBase
from assetripper_primitives import UnityVersion, UnityVersionType
from assetripper_serialization_logic import mono_utils
from assetripper_serialization_logic.primitive_type import PrimitiveType

from .serializable_value import SerializableValue


def get_max_depth_level(version: UnityVersion) -> int:
    """Unity's maximum serialization depth, which prevents infinite recursion on cyclic
    references. 7 before 2020.2.0a21, 10 from then on."""
    return 10 if version.greater_than_or_equals(2020, 2, 0, UnityVersionType.ALPHA, 21) else 7


class SerializableStructure(UnityAssetBase):
    def __init__(self, type, depth: int):
        if type is None:
            raise ValueError("type must not be None")
        self.depth = depth
        self.type = type
        self.fields: list[SerializableValue] = [SerializableValue() for _ in type.fields]
        self._version = UnityVersion()

    @staticmethod
    def create(type, depth: int = 0) -> "SerializableStructure":
        """Port of the `CreateSerializableStructure()` extension method."""
        return SerializableStructure(type, depth)

    @property
    def serialized_version(self) -> int:
        return self.type.version

    @property
    def flow_mapped_in_yaml(self) -> bool:
        return self.type.flow_mapped_in_yaml

    @property
    def class_name(self) -> str:
        return self.type.name

    # -- reading ---------------------------------------------------------------

    def read(self, reader, version: UnityVersion, flags) -> None:
        self._version = version
        for i, etalon in enumerate(self.type.fields):
            if self._is_available(etalon):
                self.fields[i].read(reader, version, flags, self.depth, etalon)

    def try_read(self, reader, version: UnityVersion, flags) -> "tuple[bool, str | None]":
        """Port of `TryRead(ref reader, IMonoBehaviour)`, returning (ok, error_message)
        instead of logging -- callers here decide how to surface the failure.

        A layout that doesn't consume exactly the available bytes means the structure
        didn't match the data, which is the main signal that a MonoBehaviour's script
        type was guessed wrong.
        """
        try:
            self.read(reader, version, flags)
        except Exception as ex:  # noqa: BLE001 -- mirrors the C# catch-all
            return False, (
                f"Unable to read structure, because script {self} layout mismatched "
                f"binary content ({type(ex).__name__}: {ex})."
            )
        if reader.position != reader.length:
            return False, (
                f"Unable to read structure, because script {self} layout mismatched binary "
                f"content (read {reader.position} bytes, expected {reader.length} bytes)."
            )
        return True, None

    def _is_available(self, field) -> bool:
        if self.depth <= get_max_depth_level(self._version):
            return True
        if field.array_depth > 0:
            return False
        if field.type.type == PrimitiveType.COMPLEX:
            return mono_utils.is_engine_struct(field.type.namespace, field.type.name)
        return True

    # -- traversal -------------------------------------------------------------

    def walk_editor(self, walker) -> None:
        if walker.enter_asset(self):
            has_emitted_first_field = False
            for i, etalon in enumerate(self.type.fields):
                if not self._is_available(etalon):
                    continue
                if has_emitted_first_field:
                    walker.divide_asset(self)
                else:
                    has_emitted_first_field = True
                if walker.enter_field(self, etalon.name):
                    self.fields[i].walk_editor(walker, etalon)
                    walker.exit_field(self, etalon.name)
            walker.exit_asset(self)

    # Upstream note: for now, only the editor version is implemented.
    def walk_release(self, walker) -> None:
        self.walk_editor(walker)

    def walk_standard(self, walker) -> None:
        self.walk_editor(walker)

    def fetch_dependencies(self):
        for i, etalon in enumerate(self.type.fields):
            if self._is_available(etalon):
                yield from self.fields[i].fetch_dependencies(etalon)

    # -- field access ----------------------------------------------------------

    def try_get_index(self, name: str) -> int:
        for i, field in enumerate(self.type.fields):
            if field.name == name:
                return i
        return -1

    def contains_field(self, name: str) -> bool:
        return self.try_get_index(name) >= 0

    def __contains__(self, name: str) -> bool:
        return self.contains_field(name)

    def __getitem__(self, name: str):
        """Returns the field's *value*, not its SerializableValue wrapper.

        This is the primary access API for downstream exporters and processors, standing in
        for the generated typed properties upstream code uses (`textAsset.Script_C49`
        becomes `asset["m_Script"]`).
        """
        index = self.try_get_index(name)
        if index < 0:
            raise KeyError(f"Field {name} wasn't found in {self.type.name}")
        return self.fields[index].value

    def __setitem__(self, name: str, value) -> None:
        index = self.try_get_index(name)
        if index < 0:
            raise KeyError(f"Field {name} wasn't found in {self.type.name}")
        self.fields[index].value = value

    def get(self, name: str, default=None):
        index = self.try_get_index(name)
        return default if index < 0 else self.fields[index].value

    def items(self):
        """Ordered (name, value) pairs, in serialized field order."""
        for i, field in enumerate(self.type.fields):
            yield field.name, self.fields[i].value

    def keys(self):
        return [field.name for field in self.type.fields]

    def __len__(self) -> int:
        return len(self.fields)

    # -- lifecycle -------------------------------------------------------------

    def initialize_fields(self, version: UnityVersion) -> None:
        self._version = version
        for i, etalon in enumerate(self.type.fields):
            if self._is_available(etalon):
                self.fields[i].initialize(version, self.depth, etalon)

    def reset(self) -> None:
        for field in self.fields:
            field.reset()

    def __str__(self) -> str:
        return self.type.full_name

    __repr__ = __str__

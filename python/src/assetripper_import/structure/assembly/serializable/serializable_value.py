"""Port of Source/AssetRipper.Import/Structure/Assembly/Serializable/SerializableValue.cs

The value half of the dynamic reader: one field's data, interpreted according to the
`Field` describing it.

C# declares this as a struct with two slots -- a `ulong PValue` holding primitive bits and
an `object? CValue` holding references -- plus ~60 typed `AsXxx` properties that reinterpret
those slots. That layout exists purely to avoid boxing primitives. Nothing in the read,
write, or walk paths ever reinterprets the same bits as a different primitive type: the
type is always determined by `etalon.Type.Type`, and the same case reads and writes through
the same typed accessor. So this port collapses all of it to a single `value` attribute.

Alignment (the easiest thing to get wrong here) has three sources, all preserved:
  1. per-field  -- `if etalon.align: reader.align()` at the very end of `read()`
  2. per-array  -- inside read_primitive_array/read_string_array, gated on Unity >= 2017
  3. per-string -- always, via read_utf8_string_aligned
"""
from __future__ import annotations

from typing import Any

from assetripper_serialization_logic.primitive_type import PrimitiveType

from . import endian_span_reader_extensions as ext

# PrimitiveType -> (scalar reader attribute name, struct format char for bulk array reads)
_SCALAR_READERS = {
    PrimitiveType.BOOL: "read_boolean",
    PrimitiveType.CHAR: "read_char",
    PrimitiveType.SBYTE: "read_sbyte",
    PrimitiveType.BYTE: "read_byte",
    PrimitiveType.SHORT: "read_int16",
    PrimitiveType.USHORT: "read_uint16",
    PrimitiveType.INT: "read_int32",
    PrimitiveType.UINT: "read_uint32",
    PrimitiveType.LONG: "read_int64",
    PrimitiveType.ULONG: "read_uint64",
    PrimitiveType.SINGLE: "read_single",
    PrimitiveType.DOUBLE: "read_double",
}

_ARRAY_KEYS = {
    PrimitiveType.SBYTE: "b",
    PrimitiveType.BYTE: "B",
    PrimitiveType.SHORT: "h",
    PrimitiveType.USHORT: "H",
    PrimitiveType.INT: "i",
    PrimitiveType.UINT: "I",
    PrimitiveType.LONG: "q",
    PrimitiveType.ULONG: "Q",
    PrimitiveType.SINGLE: "f",
    PrimitiveType.DOUBLE: "d",
}


class SerializableValue:
    __slots__ = ("value",)

    def __init__(self, value: Any = None):
        self.value = value

    # -- reading ---------------------------------------------------------------

    def read(self, reader, version, flags, depth: int, etalon) -> None:
        array_depth = etalon.array_depth
        primitive_type = etalon.type.type

        if array_depth == 0:
            self.value = self._read_scalar(reader, version, flags, depth, etalon, primitive_type)
        elif array_depth == 1:
            self.value = self._read_array(reader, version, flags, depth, etalon, primitive_type)
        elif array_depth == 2:
            self.value = self._read_array_array(reader, version, flags, depth, etalon, primitive_type)
        else:
            raise NotImplementedError(f"Array depth {array_depth}")

        if etalon.align:
            reader.align()

    @staticmethod
    def _read_scalar(reader, version, flags, depth: int, etalon, primitive_type):
        scalar = _SCALAR_READERS.get(primitive_type)
        if scalar is not None:
            return getattr(reader, scalar)()
        if primitive_type == PrimitiveType.STRING:
            return ext.read_utf8_string_aligned(reader)
        if primitive_type == PrimitiveType.COMPLEX:
            return _create_and_read_complex(reader, version, flags, depth, etalon)
        if primitive_type in (PrimitiveType.PAIR, PrimitiveType.MAP_PAIR):
            from .serializable_pair import SerializablePair

            pair = SerializablePair(etalon.type, depth + 1)
            pair.read(reader, version, flags)
            return pair
        raise NotImplementedError(str(primitive_type))

    @staticmethod
    def _read_array(reader, version, flags, depth: int, etalon, primitive_type):
        if primitive_type == PrimitiveType.BOOL:
            return ext.read_boolean_array(reader, version)
        if primitive_type == PrimitiveType.CHAR:
            return ext.read_char_array(reader, version)
        key = _ARRAY_KEYS.get(primitive_type)
        if key is not None:
            return ext.read_primitive_array(reader, version, key)
        if primitive_type == PrimitiveType.STRING:
            return ext.read_string_array(reader, version)
        if primitive_type in (PrimitiveType.PAIR, PrimitiveType.MAP_PAIR):
            from .serializable_pair import SerializablePair

            count = reader.read_int32()
            _throw_if_not_enough_space(reader, etalon, count)
            pairs = []
            for _ in range(count):
                pair = SerializablePair(etalon.type, depth + 1)
                pair.read(reader, version, flags)
                pairs.append(pair)
            return pairs
        if primitive_type == PrimitiveType.COMPLEX:
            count = reader.read_int32()
            _throw_if_not_enough_space(reader, etalon, count)
            return [_create_and_read_complex(reader, version, flags, depth, etalon) for _ in range(count)]
        raise NotImplementedError(str(primitive_type))

    @staticmethod
    def _read_array_array(reader, version, flags, depth: int, etalon, primitive_type):
        if primitive_type == PrimitiveType.BOOL:
            return ext.read_boolean_array_array(reader, version)
        if primitive_type == PrimitiveType.CHAR:
            return ext.read_char_array_array(reader, version)
        key = _ARRAY_KEYS.get(primitive_type)
        if key is not None:
            return ext.read_primitive_array_array(reader, version, key)
        if primitive_type == PrimitiveType.STRING:
            return ext.read_string_array_array(reader, version)
        if primitive_type == PrimitiveType.COMPLEX:
            outer_count = reader.read_int32()
            _throw_if_not_enough_space(reader, etalon, outer_count)
            result = []
            for _ in range(outer_count):
                inner_count = reader.read_int32()
                _throw_if_not_enough_space(reader, etalon, inner_count)
                result.append(
                    [_create_and_read_complex(reader, version, flags, depth, etalon) for _ in range(inner_count)]
                )
                # Note: unlike every other case, the per-field align is applied per outer
                # element here as well as once at the end of read(). This matches C#.
                if etalon.align:
                    reader.align()
            return result
        raise NotImplementedError(str(primitive_type))

    # -- traversal -------------------------------------------------------------

    def walk_editor(self, walker, etalon) -> None:
        array_depth = etalon.array_depth
        primitive_type = etalon.type.type

        if array_depth == 0:
            if primitive_type == PrimitiveType.COMPLEX:
                self.value.walk_editor(walker)
            elif primitive_type in (PrimitiveType.PAIR, PrimitiveType.MAP_PAIR):
                self.value.walk_editor(walker)
            else:
                walker.visit_primitive(self.value)
            return

        inner_etalon = _element_etalon(etalon)
        if walker.enter_list(self.value):
            for i, item in enumerate(self.value or ()):
                if i > 0:
                    walker.divide_list(self.value)
                if array_depth == 1 and primitive_type in (
                    PrimitiveType.COMPLEX,
                    PrimitiveType.PAIR,
                    PrimitiveType.MAP_PAIR,
                ):
                    item.walk_editor(walker)
                elif array_depth == 1:
                    walker.visit_primitive(item)
                else:
                    SerializableValue(item).walk_editor(walker, inner_etalon)
            walker.exit_list(self.value)

    def fetch_dependencies(self, etalon):
        """Yields (path, PPtr) pairs. Only Complex fields can contain dependencies."""
        if etalon.type.type != PrimitiveType.COMPLEX:
            return
        if etalon.is_array:
            for i, structure in enumerate(self.value or ()):
                for path, pptr in structure.fetch_dependencies():
                    yield f"{etalon.name}[{i}].{path}", pptr
        else:
            assert etalon.array_depth == 0
            if self.value is not None:
                for path, pptr in self.value.fetch_dependencies():
                    yield f"{etalon.name}.{path}", pptr

    # -- lifecycle -------------------------------------------------------------

    def initialize(self, version, depth: int, etalon) -> None:
        if etalon.array_depth > 0:
            self.value = []
        elif etalon.type.type == PrimitiveType.STRING:
            self.value = ""
        elif etalon.type.type == PrimitiveType.COMPLEX:
            self.value = _create_instance(etalon.type, depth + 1, version)
        elif etalon.type.type in (PrimitiveType.PAIR, PrimitiveType.MAP_PAIR):
            from .serializable_pair import SerializablePair

            pair = SerializablePair(etalon.type, depth + 1)
            pair.initialize(version)
            self.value = pair
        elif etalon.type.type == PrimitiveType.BOOL:
            self.value = False
        elif etalon.type.type == PrimitiveType.CHAR:
            self.value = "\0"
        elif etalon.type.type in (PrimitiveType.SINGLE, PrimitiveType.DOUBLE):
            self.value = 0.0
        else:
            self.value = 0

    def reset(self) -> None:
        value = self.value
        if value is None:
            return
        if isinstance(value, str):
            self.value = ""
        elif isinstance(value, list):
            self.value = []
        elif hasattr(value, "reset"):
            value.reset()
        else:
            self.value = type(value)()

    def __str__(self) -> str:
        return str(self.value)

    __repr__ = __str__


def _element_etalon(etalon):
    """The Field describing one element of an array field: same type, one less depth."""
    from assetripper_serialization_logic.serializable_type import Field

    return Field(etalon.type, etalon.array_depth - 1, etalon.name, False)


def _throw_if_not_enough_space(reader, etalon, count: int) -> None:
    remaining = reader.length - reader.position
    if remaining < count:
        raise EOFError(
            f"When reading field {etalon.name}, Stream only has {remaining} bytes remaining, "
            f"so {count} complex elements of type {etalon.type.name} cannot be read."
        )


def _create_and_read_complex(reader, version, flags, depth: int, etalon):
    """Port of the local `CreateAndReadComplexStructure` function."""
    from .serializable_structure import SerializableStructure

    asset = _create_instance(etalon.type, depth + 1, version)
    if isinstance(asset, SerializableStructure):
        asset.read(reader, version, flags)
    else:
        asset.read(reader, flags)
    return asset


def _create_instance(type, depth: int, version):
    """Port of SerializableTypeExtensions.CreateInstance.

    Upstream has three branches: engine struct -> `GameAssetFactory.CreateEngineAsset` (a
    generated class such as Vector3 or SphericalHarmonicsL2), engine pointer -> a generated
    PPtr, otherwise a plain SerializableStructure.

    The engine-struct branch is not implemented here because it needs those generated
    classes. It is only ever *reached* by IL-derived types, whose Namespace is set; types
    produced by SerializableTreeType always have `namespace is None`, so engine structs
    arrive as ordinary Complex types and the type tree supplies their real layout (a Vector3f
    node carries x/y/z sub-nodes). Consequence: a fieldless engine struct consumes no bytes
    here where upstream would consume its generated layout -- see
    tests/import_/test_serializable_structure.py::
    test_engine_struct_without_fields_is_a_known_divergence_from_upstream.
    """
    from .serializable_structure import SerializableStructure

    if type.is_engine_pointer():
        from .serializable_pptr import SerializablePPtr

        return SerializablePPtr(getattr(type, "path_id_is_64bit", True))
    structure = SerializableStructure(type, depth)
    structure.initialize_fields(version)
    return structure

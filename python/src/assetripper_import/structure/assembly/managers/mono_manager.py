"""Phase 16c: the Mono backend -- reads a managed `.dll` via `dotnet_metadata` and produces
`RecoveredType`/`RecoveredField` (`..recovered_model`) instances for `csharp_emitter` (16b).

Phase 16f: `get_serializable_type` builds an actual `SerializableType`
(`assetripper_serialization_logic`) graph for a recovered type -- the same abstraction
`SerializableTreeType` builds from an embedded TypeTree -- so a MonoBehaviour with no embedded
type tree can be read for real instead of becoming `UnknownObject`. This is a separate walk of
the same field signatures `RecoveredField.type_name` is built from, because the two consumers
need different things: `RecoveredType` needs display-ready C# text, `SerializableType` needs a
resolvable, byte-layout-accurate type graph (primitive vs PPtr vs nested struct, with an actual
array depth) -- text can't be safely parsed back into that.

Folds in a pragmatic subset of 16a's `WillUnitySerialize` gating (ROADMAP.md Phase 16a notes
this can't be built as a standalone pure function -- it needs a real type-resolution graph,
which is exactly what this module has). Simplifications from the full upstream
`FieldSerializer.Logic.cs`/`EngineTypePredicates.cs`, documented rather than silently assumed:

- A field is treated as serialized if it is non-static, non-const, not `[NonSerialized]`, and
  either public or carries a `SerializeField`/`SerializeReference` custom attribute. Upstream's
  full logic additionally special-cases generics (version-gated), delegates, and several
  built-in engine types (`AnimationCurve`, `LayerMask`, ...) -- none of that is implemented
  here; a field of one of those types is still emitted (in `RecoveredType`), just without the
  extra Unity-specific serialization nuance those types carry upstream.
- Compiler-generated auto-property backing fields (name containing `<`) are skipped outright,
  rather than replicated with their `CompilerGeneratedAttribute` intact -- Unity does not
  serialize these unless explicitly annotated, and upstream's own MonoBehaviour recovery
  filters generated members separately.
- Enum `TypeDef`s (base type `System.Enum`) never become a `RecoveredType` (it only models
  class/struct shapes, see recovered_model.py) -- but a *field* of enum type is supported by
  `get_serializable_type`, always as `PrimitiveType.INT` (Unity's default enum backing field;
  an enum declared `: byte`/`: long` is not distinguished, a documented simplification).
- Nested types are read but not connected to their enclosing type (no nested-class C# syntax);
  each still comes out as its own top-level `RecoveredType`, which is enough for `MonoScript`
  lookup by (namespace, class_name) even though the emitted `.cs` won't nest it visually.

`get_serializable_type`'s own simplifications, beyond the ones above:
- Only fields resolvable with total confidence produce a result -- if ANY field's type can't be
  resolved (an external type this port hasn't loaded, an unsupported signature shape, an
  un-hardcoded built-in Unity struct -- see `unity_engine_structs.py`), the *whole containing
  type* is declined (returns `None`), not just that one field. A partially-correct byte layout
  is worse than none: every field after a misread one would misalign too. This matches this
  port's standing rule (see e.g. Phase 18's Shader deferral) of declining rather than guessing.
- A field whose resolved type derives (directly, or transitively through other locally-defined
  types) from `UnityEngine.Object`/`MonoBehaviour`/`Behaviour`/`Component` becomes a PPtr
  (`SerializablePointerType.shared()`), matching real Unity behaviour -- any such reference is
  serialized as a pointer, never inlined. The chain walk only follows base types declared in
  *this same assembly*; a chain that leaves the assembly (e.g. extends a type from another
  loaded `.dll`) is not currently followed -- cross-assembly resolution is future work.
- A user-defined base class *in this same assembly* has its own gated fields collected too, in
  base-to-derived order (matching real Unity serialization of an inheritance chain) -- this is
  the one piece of "16a" that genuinely required a type-resolution graph to get right at all.
- `List<T>` is recognized as a one-level array (matching how Unity actually serializes it); any
  other generic instantiation is unresolvable. Non-generic external reference types not in
  `unity_engine_structs.py` and not a `UnityEngine.Object` descendant are unresolvable too.
"""
from __future__ import annotations

from assetripper_serialization_logic import mono_utils
from assetripper_serialization_logic.primitive_type import PrimitiveType
from assetripper_serialization_logic.serializable_pointer_type import SerializablePointerType
from assetripper_serialization_logic.serializable_type import Field, SerializableType

from ..dotnet_metadata.compressed_integer import decode_type_def_or_ref, read_compressed_uint
from ..dotnet_metadata.metadata_reader import DotNetMetadataReader
from ..dotnet_metadata.signature import decode_field_signature
from ..dotnet_metadata.table_ids import TableId
from ..recovered_model import RecoveredField, RecoveredType
from . import unity_engine_structs

_FIELD_ACCESS_MASK = 0x0007
_FIELD_PUBLIC = 0x0006
_FIELD_STATIC = 0x0010
_FIELD_LITERAL = 0x0040
_FIELD_NOT_SERIALIZED = 0x0080

_SERIALIZE_ATTRIBUTE_NAMES = {"SerializeField", "SerializeReference"}

_FIELD_SIG_CALLING_CONVENTION = 0x06
_ELEMENT_TYPE_VALUETYPE = 0x11
_ELEMENT_TYPE_CLASS = 0x12
_ELEMENT_TYPE_GENERICINST = 0x15
_ELEMENT_TYPE_SZARRAY = 0x1D
_ELEMENT_TYPE_CMOD_REQD = 0x1F
_ELEMENT_TYPE_CMOD_OPT = 0x20
_ELEMENT_TYPE_PINNED = 0x45

_PRIMITIVE_ELEMENT_TYPES = {
    0x02: PrimitiveType.BOOL,
    0x03: PrimitiveType.CHAR,
    0x04: PrimitiveType.SBYTE,
    0x05: PrimitiveType.BYTE,
    0x06: PrimitiveType.SHORT,
    0x07: PrimitiveType.USHORT,
    0x08: PrimitiveType.INT,
    0x09: PrimitiveType.UINT,
    0x0A: PrimitiveType.LONG,
    0x0B: PrimitiveType.ULONG,
    0x0C: PrimitiveType.SINGLE,
    0x0D: PrimitiveType.DOUBLE,
}
_ELEMENT_TYPE_STRING = 0x0E

_LIST_FULL_NAME = "System.Collections.Generic.List`1"

_primitive_singletons: "dict[PrimitiveType, SerializableType]" = {}
_string_singleton: "SerializableType | None" = None


def _primitive_type_instance(primitive_type: PrimitiveType) -> SerializableType:
    result = _primitive_singletons.get(primitive_type)
    if result is None:
        result = SerializableType(None, primitive_type, str(primitive_type.name).lower())
        result.max_depth = 0
        _primitive_singletons[primitive_type] = result
    return result


def _string_type_instance() -> SerializableType:
    global _string_singleton
    if _string_singleton is None:
        _string_singleton = SerializableType(None, PrimitiveType.STRING, "string")
        _string_singleton.max_depth = 0
    return _string_singleton


class MonoAssembly:
    """One read `.dll`'s recovered types, keyed by (namespace, class_name) to match how a
    `MonoScript` asset identifies the type it points to (see `mono_script_info.py`)."""

    def __init__(self, reader: DotNetMetadataReader):
        self._reader = reader
        self._types: "dict[tuple[str, str], RecoveredType]" = {}
        self._type_def_by_name: "dict[tuple[str, str], dict]" = {}
        self._row_numbers: "dict[int, int]" = {}
        """id(type_def_row) -> 1-based TypeDef row number, precomputed once in _build()."""
        self._serializable_cache: "dict[tuple[str, str], SerializableType | None]" = {}
        self._build()

    def get_type(self, namespace: str, class_name: str) -> "RecoveredType | None":
        return self._types.get((namespace or "", class_name))

    def all_types(self) -> "tuple[RecoveredType, ...]":
        return tuple(self._types.values())

    def get_serializable_type(self, namespace: str, class_name: str) -> "SerializableType | None":
        key = (namespace or "", class_name)
        if key in self._serializable_cache:
            return self._serializable_cache[key]
        type_def_row = self._type_def_by_name.get(key)
        if type_def_row is None:
            self._serializable_cache[key] = None
            return None
        return self._build_serializable_type(type_def_row, key)

    # -- RecoveredType (16b/16c) -------------------------------------------------

    def _build(self) -> None:
        reader = self._reader
        type_defs = reader.tables.rows(TableId.TYPE_DEF)
        for i, row in enumerate(type_defs):
            self._row_numbers[id(row)] = i + 1

            name = reader.strings.get(row["name"])
            namespace = reader.strings.get(row["namespace"])
            self._type_def_by_name[(namespace or "", name)] = row
            if name == "<Module>":
                continue
            base_text = reader.resolve_coded_type_def_or_ref(row["extends"])
            if base_text == "System.Enum":
                continue
            is_struct = base_text == "System.ValueType"
            base_type_name = None
            if base_text is not None and base_text not in ("System.Object", "System.ValueType"):
                base_type_name = base_text.rsplit(".", 1)[-1]

            recovered_type = RecoveredType(
                namespace=namespace or None,
                name=name,
                base_type_name=base_type_name,
                fields=self._recover_fields(row),
                is_struct=is_struct,
            )
            self._types[(namespace or "", name)] = recovered_type

    def _own_field_row_numbers(self, type_def_row: dict) -> range:
        reader = self._reader
        field_rows = reader.tables.rows(TableId.FIELD)
        type_defs = reader.tables.rows(TableId.TYPE_DEF)
        index = self._row_numbers[id(type_def_row)] - 1
        start = type_def_row["field_list"]
        end = type_defs[index + 1]["field_list"] if index + 1 < len(type_defs) else len(field_rows) + 1
        return range(start, end)

    def _serialized_field_row_numbers(self, type_def_row: dict) -> "list[int]":
        """WillUnitySerialize gating (see module docstring), applied to one TypeDef's own
        (non-inherited) field range."""
        reader = self._reader
        result = []
        for row_number in self._own_field_row_numbers(type_def_row):
            row = reader.tables.row(TableId.FIELD, row_number)
            if row is None:
                continue
            flags = row["flags"]
            name = reader.strings.get(row["name"])
            if "<" in name:
                continue
            if flags & _FIELD_STATIC or flags & _FIELD_LITERAL or flags & _FIELD_NOT_SERIALIZED:
                continue
            is_public = (flags & _FIELD_ACCESS_MASK) == _FIELD_PUBLIC
            if not is_public:
                attributes = self._custom_attribute_names(TableId.FIELD, row_number)
                if not (set(attributes) & _SERIALIZE_ATTRIBUTE_NAMES):
                    continue
            result.append(row_number)
        return result

    def _recover_fields(self, type_def_row: dict) -> "tuple[RecoveredField, ...]":
        reader = self._reader
        generic_params = self._generic_param_names(type_def_row)
        fields = []
        for row_number in self._serialized_field_row_numbers(type_def_row):
            row = reader.tables.row(TableId.FIELD, row_number)
            flags = row["flags"]
            is_public = (flags & _FIELD_ACCESS_MASK) == _FIELD_PUBLIC
            attributes = self._custom_attribute_names(TableId.FIELD, row_number)
            type_name = decode_field_signature(
                reader.blobs.get(row["signature"]), reader.resolve_type_def_or_ref, generic_params
            )
            name = reader.strings.get(row["name"])
            fields.append(RecoveredField(name=name, type_name=type_name, is_public=is_public, attributes=attributes))
        return tuple(fields)

    def _generic_param_names(self, type_def_row: dict) -> "tuple[str, ...]":
        reader = self._reader
        row_number = self._row_numbers[id(type_def_row)]
        matches = [
            row for row in reader.tables.rows(TableId.GENERIC_PARAM)
            if row["owner"].table == TableId.TYPE_DEF and row["owner"].row_number == row_number
        ]
        matches.sort(key=lambda row: row["number"])
        return tuple(reader.strings.get(row["name"]) for row in matches)

    def _custom_attribute_names(self, table: TableId, row_number: int) -> "tuple[str, ...]":
        reader = self._reader
        names = []
        for row in reader.tables.rows(TableId.CUSTOM_ATTRIBUTE):
            parent = row["parent"]
            if parent.table == table and parent.row_number == row_number:
                name = reader.custom_attribute_type_name(row)
                if name is not None:
                    names.append(name)
        return tuple(names)

    # -- SerializableType (16f) ---------------------------------------------------

    def _build_serializable_type(self, type_def_row: dict, key: "tuple[str, str]") -> "SerializableType | None":
        name = self._reader.strings.get(type_def_row["name"])
        result = SerializableType(key[0] or None, PrimitiveType.COMPLEX, name)
        self._serializable_cache[key] = result  # inserted before recursing, for cyclic types

        fields: "list[Field]" = []
        for ancestor_row in self._local_base_chain(type_def_row):
            for row_number in self._serialized_field_row_numbers(ancestor_row):
                row = self._reader.tables.row(TableId.FIELD, row_number)
                field_type, array_depth = self._resolve_field_type(self._reader.blobs.get(row["signature"]))
                if field_type is None:
                    self._serializable_cache[key] = None
                    return None
                fields.append(Field(field_type, array_depth, self._reader.strings.get(row["name"]), False))

        result.fields = fields
        result.max_depth = max((field.type.max_depth + 1 for field in fields), default=0)
        return result

    def _local_base_chain(self, type_def_row: dict) -> "list[dict]":
        """This type plus every ancestor declared in this same assembly, base-first -- so
        inherited fields serialize in Unity's actual order (base class fields, then derived)."""
        chain = [type_def_row]
        seen = {id(type_def_row)}
        current = type_def_row
        while True:
            extends = current["extends"]
            if extends.is_null() or extends.table != TableId.TYPE_DEF:
                break
            base_row = self._reader.tables.row(TableId.TYPE_DEF, extends.row_number)
            if base_row is None or id(base_row) in seen:
                break
            chain.append(base_row)
            seen.add(id(base_row))
            current = base_row
        chain.reverse()
        return chain

    def _is_unity_object_descendant(self, type_def_row: dict) -> bool:
        seen = {id(type_def_row)}
        current = type_def_row
        while True:
            extends = current["extends"]
            if extends.is_null():
                return False
            if extends.table == TableId.TYPE_DEF:
                base_row = self._reader.tables.row(TableId.TYPE_DEF, extends.row_number)
                if base_row is None or id(base_row) in seen:
                    return False
                seen.add(id(base_row))
                current = base_row
                continue
            if extends.table == TableId.TYPE_REF:
                ref_row = self._reader.tables.row(TableId.TYPE_REF, extends.row_number)
                if ref_row is None:
                    return False
                namespace = self._reader.strings.get(ref_row["namespace"])
                name = self._reader.strings.get(ref_row["name"])
                return mono_utils.is_prime(namespace, name)
            return False

    def _resolve_field_type(self, blob: bytes) -> "tuple[SerializableType | None, int]":
        if not blob or blob[0] != _FIELD_SIG_CALLING_CONVENTION:
            return None, 0
        offset = 1
        array_depth = 0
        while True:
            element_type = blob[offset]
            while element_type in (_ELEMENT_TYPE_CMOD_REQD, _ELEMENT_TYPE_CMOD_OPT):
                offset += 1
                _, offset = read_compressed_uint(blob, offset)
                element_type = blob[offset]
            if element_type == _ELEMENT_TYPE_PINNED:
                offset += 1
                continue
            if element_type == _ELEMENT_TYPE_SZARRAY:
                offset += 1
                array_depth += 1
                continue
            if element_type == _ELEMENT_TYPE_GENERICINST:
                new_offset = self._try_unwrap_list_generic(blob, offset)
                if new_offset is None:
                    return None, 0
                offset = new_offset
                array_depth += 1
                continue
            break
        leaf = self._resolve_leaf_type(blob, offset)
        return leaf, array_depth

    def _try_unwrap_list_generic(self, blob: bytes, offset: int) -> "int | None":
        pos = offset + 1  # skip the GENERICINST byte itself
        pos += 1  # skip the following CLASS/VALUETYPE byte -- irrelevant, List<T> is a class
        encoded, pos = read_compressed_uint(blob, pos)
        tag, row_index = decode_type_def_or_ref(encoded)
        if tag != 1:  # List<T> is always an external TypeRef in a game's own assembly
            return None
        if self._reader.resolve_type_def_or_ref(tag, row_index) != _LIST_FULL_NAME:
            return None
        arg_count, pos = read_compressed_uint(blob, pos)
        if arg_count != 1:
            return None
        return pos

    def _resolve_leaf_type(self, blob: bytes, offset: int) -> "SerializableType | None":
        element_type = blob[offset]
        primitive = _PRIMITIVE_ELEMENT_TYPES.get(element_type)
        if primitive is not None:
            return _primitive_type_instance(primitive)
        if element_type == _ELEMENT_TYPE_STRING:
            return _string_type_instance()
        if element_type in (_ELEMENT_TYPE_VALUETYPE, _ELEMENT_TYPE_CLASS):
            encoded, _ = read_compressed_uint(blob, offset + 1)
            tag, row_index = decode_type_def_or_ref(encoded)
            return self._resolve_type_def_or_ref_for_field(tag, row_index)
        return None

    def _resolve_type_def_or_ref_for_field(self, tag: int, row_index: int) -> "SerializableType | None":
        if tag == 0:  # local TypeDef
            type_def_row = self._reader.tables.row(TableId.TYPE_DEF, row_index + 1)
            if type_def_row is None:
                return None
            if self._is_unity_object_descendant(type_def_row):
                return SerializablePointerType.shared()
            extends = type_def_row["extends"]
            if extends.table == TableId.TYPE_REF:
                ref_row = self._reader.tables.row(TableId.TYPE_REF, extends.row_number)
                if (
                    ref_row is not None
                    and self._reader.strings.get(ref_row["namespace"]) == "System"
                    and self._reader.strings.get(ref_row["name"]) == "Enum"
                ):
                    return _primitive_type_instance(PrimitiveType.INT)
            namespace = self._reader.strings.get(type_def_row["namespace"]) or None
            name = self._reader.strings.get(type_def_row["name"])
            return self.get_serializable_type(namespace, name)
        if tag == 1:  # TypeRef -- external
            row = self._reader.tables.row(TableId.TYPE_REF, row_index + 1)
            if row is None:
                return None
            namespace = self._reader.strings.get(row["namespace"])
            name = self._reader.strings.get(row["name"])
            if mono_utils.is_engine_struct(namespace, name):
                return unity_engine_structs.get(namespace, name)
            if mono_utils.is_prime(namespace, name):
                return SerializablePointerType.shared()
            return None
        return None  # TypeSpec -- not supported for a bare field, decline


def read_assembly(data: bytes) -> MonoAssembly:
    return MonoAssembly(DotNetMetadataReader(data))

"""Phase 16c: the Mono backend -- reads a managed `.dll` via `dotnet_metadata` and produces
`RecoveredType`/`RecoveredField` (`..recovered_model`) instances for `csharp_emitter` (16b) and,
eventually, MonoBehaviour field recovery (16f).

Folds in a pragmatic subset of 16a's `WillUnitySerialize` gating (ROADMAP.md Phase 16a notes
this can't be built as a standalone pure function -- it needs a real type-resolution graph,
which is exactly what this module has). Simplifications from the full upstream
`FieldSerializer.Logic.cs`/`EngineTypePredicates.cs`, documented rather than silently assumed:

- A field is treated as serialized if it is non-static, non-const, not `[NonSerialized]`, and
  either public or carries a `SerializeField`/`SerializeReference` custom attribute. Upstream's
  full logic additionally special-cases generics (version-gated), delegates, and several
  built-in engine types (`AnimationCurve`, `LayerMask`, ...) -- none of that is implemented
  here; a field of one of those types is still emitted, just without the extra Unity-specific
  serialization nuance those types carry upstream.
- Compiler-generated auto-property backing fields (name containing `<`) are skipped outright,
  rather than replicated with their `CompilerGeneratedAttribute` intact -- Unity does not
  serialize these unless explicitly annotated, and upstream's own MonoBehaviour recovery
  filters generated members separately.
- Enum `TypeDef`s (base type `System.Enum`) are skipped entirely: `RecoveredType` only models
  class/struct shapes (see recovered_model.py), and emitting an enum as a struct would produce
  wrong C#. A real enum emitter is future work, not attempted here.
- Nested types are read but not connected to their enclosing type (no nested-class C# syntax);
  each still comes out as its own top-level `RecoveredType`, which is enough for `MonoScript`
  lookup by (namespace, class_name) even though the emitted `.cs` won't nest it visually.
"""
from __future__ import annotations

from ..dotnet_metadata.metadata_reader import DotNetMetadataReader
from ..dotnet_metadata.signature import decode_field_signature
from ..dotnet_metadata.table_ids import TableId
from ..recovered_model import RecoveredField, RecoveredType

_FIELD_ACCESS_MASK = 0x0007
_FIELD_PUBLIC = 0x0006
_FIELD_STATIC = 0x0010
_FIELD_LITERAL = 0x0040
_FIELD_NOT_SERIALIZED = 0x0080

_SERIALIZE_ATTRIBUTE_NAMES = {"SerializeField", "SerializeReference"}


class MonoAssembly:
    """One read `.dll`'s recovered types, keyed by (namespace, class_name) to match how a
    `MonoScript` asset identifies the type it points to (see `mono_script_info.py`)."""

    def __init__(self, reader: DotNetMetadataReader):
        self._reader = reader
        self._types: "dict[tuple[str, str], RecoveredType]" = {}
        self._build()

    def get_type(self, namespace: str, class_name: str) -> "RecoveredType | None":
        return self._types.get((namespace or "", class_name))

    def all_types(self) -> "tuple[RecoveredType, ...]":
        return tuple(self._types.values())

    def _build(self) -> None:
        reader = self._reader
        type_defs = reader.tables.rows(TableId.TYPE_DEF)
        for row in type_defs:
            name = reader.strings.get(row["name"])
            if name == "<Module>":
                continue
            namespace = reader.strings.get(row["namespace"])
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

    def _recover_fields(self, type_def_row: dict) -> "tuple[RecoveredField, ...]":
        reader = self._reader
        field_rows = reader.tables.rows(TableId.FIELD)
        start = type_def_row["field_list"]
        type_defs = reader.tables.rows(TableId.TYPE_DEF)
        index = type_defs.index(type_def_row)
        end = type_defs[index + 1]["field_list"] if index + 1 < len(type_defs) else len(field_rows) + 1

        generic_params = self._generic_param_names(type_def_row)

        fields = []
        for row_number in range(start, end):
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
            attributes = self._custom_attribute_names(TableId.FIELD, row_number)
            if not is_public and not (set(attributes) & _SERIALIZE_ATTRIBUTE_NAMES):
                continue
            type_name = decode_field_signature(
                reader.blobs.get(row["signature"]), reader.resolve_type_def_or_ref, generic_params
            )
            fields.append(RecoveredField(name=name, type_name=type_name, is_public=is_public, attributes=attributes))
        return tuple(fields)

    def _generic_param_names(self, type_def_row: dict) -> "tuple[str, ...]":
        reader = self._reader
        type_defs = reader.tables.rows(TableId.TYPE_DEF)
        row_number = type_defs.index(type_def_row) + 1
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


def read_assembly(data: bytes) -> MonoAssembly:
    return MonoAssembly(DotNetMetadataReader(data))

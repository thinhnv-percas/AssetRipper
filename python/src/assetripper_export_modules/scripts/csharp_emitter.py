"""Phase 16b: emits real `.cs` text from a `RecoveredType`
(`assetripper_import.structure.assembly.recovered_model`) -- the piece that replaces
`empty_script.get_content`'s dummy-class stub once a script backend (16c Mono / 16d-e
IL2CPP) has actually resolved a type's fields.

No upstream C# file to port: upstream never needs this step because it works the other way
around -- `ScriptExportCollection`/`ScriptDecompiler` hand a *real* `AssemblyDefinition` to
`ICSharpCode.Decompiler`, an off-the-shelf IL decompiler, and get `.cs` text back for free.
This port has no IL decompiler (see ROADMAP.md Phase 16g: method bodies are permanently out
of scope), so the reader supplies structure (fields, base type) and this module is
responsible for turning that structure into valid C# syntax by hand.

Method bodies are never emitted here -- there is no method-body model in `RecoveredType` at
all (see that module's docstring) -- so every emitted type is fields-only, exactly matching
the "declaration only" ceiling documented in ROADMAP.md Phase 16.
"""
from __future__ import annotations

from assetripper_import.structure.assembly.recovered_model import RecoveredField, RecoveredType

from .mono_script_extensions import is_generic


def emit(recovered_type: RecoveredType) -> str:
    is_gen, generic_name, generic_count = is_generic(recovered_type.name)
    if is_gen:
        generic_params = ", ".join(f"T{i}" for i in range(1, generic_count + 1))
        display_name = f"{generic_name}<{generic_params}>"
    else:
        display_name = recovered_type.name

    keyword = "struct" if recovered_type.is_struct else "class"
    base_clause = f" : {recovered_type.base_type_name}" if recovered_type.base_type_name else ""
    header = f"public {keyword} {display_name}{base_clause}"

    field_lines = _field_lines(recovered_type.fields)

    if not recovered_type.namespace:
        body = "".join(f"\t{line}\n" for line in field_lines)
        return f"using UnityEngine;\n\n{header}\n{{\n{body}}}\n"

    body = "".join(f"\t\t{line}\n" for line in field_lines)
    return (
        "using UnityEngine;\n\n"
        f"namespace {recovered_type.namespace}\n"
        "{\n"
        f"\t{header}\n"
        "\t{\n"
        f"{body}"
        "\t}\n"
        "}\n"
    )


def _field_lines(fields: "tuple[RecoveredField, ...]") -> list[str]:
    lines = []
    for recovered_field in fields:
        for attribute in recovered_field.attributes:
            lines.append(f"[{attribute}]")
        visibility = "public" if recovered_field.is_public else "private"
        lines.append(f"{visibility} {recovered_field.type_name} {recovered_field.name};")
    return lines

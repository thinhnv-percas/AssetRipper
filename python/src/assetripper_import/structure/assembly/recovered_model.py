"""Phase 16b: a neutral, backend-agnostic model of "one recovered .NET type", produced by
whichever script backend actually resolved it (Mono's ECMA-335 reader, 16c; or IL2CPP's
metadata+binary reader, 16d/16e) and consumed by `assetripper_export_modules.scripts.
csharp_emitter` to emit real `.cs` text.

This has no upstream C# file to port -- upstream's equivalent is the live AsmResolver
object graph (`TypeDefinition`/`FieldDefinition`/`TypeSignature`) that `FieldSerializer.
Logic.cs` (see ROADMAP.md Phase 16a) walks directly. This port needs its own intermediate
model because two independent, structurally different readers (Mono metadata vs IL2CPP
metadata+binary) both need to produce something `csharp_emitter.py` can consume without
knowing which backend produced it -- and because `WillUnitySerialize`'s type-resolution
logic (IsAssignableTo base-type walks, generic-instance checks, enum underlying types, ...)
genuinely needs a resolvable type graph, not a single isolated field: that logic belongs
with whichever reader actually builds that graph (16c/16d), not here. This module only
carries the *result* of that resolution: a field's already-decided, display-ready C# type
text and whether Unity would serialize it -- not the reasoning that produced it.

Field type names are pre-formatted, already-valid C# text (e.g. `"int"`, `"System.String"`,
`"List<Foo>"`, `"Foo[]"`) chosen by the reader, not re-derived here -- keeping this model
(and the emitter built on it) trivially testable without a real metadata reader behind it.
"""
from __future__ import annotations

from dataclasses import dataclass, field


@dataclass(slots=True, frozen=True)
class RecoveredField:
    """One serialized field, as Unity would see it after `WillUnitySerialize` gating --
    i.e. only fields that survive that check should become a `RecoveredField` at all."""

    name: str
    type_name: str
    """Already-formatted C# type text (see module docstring) -- not a type descriptor."""
    is_public: bool = True
    attributes: tuple[str, ...] = ()
    """Attribute names with no leading `[`/`Attribute` suffix, e.g. `("SerializeField",)`.
    A non-public field with no `SerializeField` here would not actually be Unity-visible;
    callers are expected to have already applied `WillUnitySerialize`'s own rule (public,
    or `[SerializeField]`/`[SerializeReference]`) before constructing one of these."""


@dataclass(slots=True, frozen=True)
class RecoveredType:
    """One recovered class/struct -- typically a MonoBehaviour or ScriptableObject
    subclass, but the model doesn't require that (a plain serializable data class works
    too, e.g. something only ever referenced from a `[SerializeField]` field elsewhere)."""

    namespace: str | None
    name: str
    """Raw type name, exactly as Unity/the CLR spell it -- for a generic type this is the
    mangled form (`"Foo`2"`), matching `MonoScript.m_ClassName` and consumed the same way
    `assetripper_export_modules.scripts.empty_script` already does via
    `mono_script_extensions.is_generic`."""
    base_type_name: str | None = None
    """e.g. `"MonoBehaviour"`/`"ScriptableObject"`, or `None` for no base clause."""
    fields: tuple[RecoveredField, ...] = field(default_factory=tuple)
    is_struct: bool = False

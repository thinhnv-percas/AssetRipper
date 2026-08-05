"""Port of the IsGeneric/GetNonGenericClassName parts of
Source/AssetRipper.SourceGenerated.Extensions/MonoScriptExtensions.cs

Matches the CLR's mangled generic type name format (e.g. "MyClass`2" for a 2-parameter
generic type).
"""
from __future__ import annotations

import re

_GENERIC_RE = re.compile(r"^(\w+)`([1-9][0-9]*)$")


def is_generic(class_name: str) -> "tuple[bool, str, int]":
    """Returns (is_generic, generic_name, generic_count). When not generic,
    generic_name == class_name and generic_count == 0."""
    match = _GENERIC_RE.match(class_name)
    if match:
        return True, match.group(1), int(match.group(2))
    return False, class_name, 0


def get_non_generic_class_name(class_name: str) -> str:
    _, generic_name, _ = is_generic(class_name)
    return generic_name

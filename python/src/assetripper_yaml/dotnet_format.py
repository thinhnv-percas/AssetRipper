"""
Small helper shared by Emitter and YamlScalarNode's numeric nodes: formats a Python
float the way .NET's `float`/`double.ToString()` does under InvariantCulture -- the
shortest round-trippable representation, but *without* a forced trailing ".0" for whole
numbers (Python's `repr()` always includes one). This matters for YAML output fidelity,
e.g. `1f.ToString()` is "1", not "1.0".
"""
from __future__ import annotations

import math


def format_float(value: float) -> str:
    if math.isnan(value):
        return "NaN"
    if math.isinf(value):
        return "-Infinity" if value < 0 else "Infinity"
    if value == int(value) and abs(value) < 1e17:
        return str(int(value))
    return repr(value)

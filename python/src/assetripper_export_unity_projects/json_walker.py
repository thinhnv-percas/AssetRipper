"""Port of Source/AssetRipper.Export.PrimaryContent/DefaultJsonWalker.cs (2026-08-03).

Emits an asset as JSON by walking it the same way `YamlWalker` does. Upstream lives in
`AssetRipper.Export.PrimaryContent`, a package this port does not have, so it sits next to
`yaml_walker.py` -- the walker it shares every structural assumption with.

What it is for: the GUI's Json tab (`/Assets/Json`), which is the one view that shows an asset's
decoded fields in a form you can paste into another tool. The Fields table is easier to skim but
lossy (values are stringified for display); this is the lossless one.

Two places where a strict 1:1 port is impossible, both stemming from the same root cause -- C#
recovers an element's static type from a generic parameter even for an empty collection, and a
Python method parameter cannot carry that:

- `IsString<TKey>()` decides whether a dictionary becomes a JSON object (string keys) or an array
  of `{"Key":…,"Value":…}` pairs. Here the decision is made from the *runtime* keys instead, and
  an empty dictionary is emitted as `{}` -- upstream would emit `[]` for an empty dictionary with
  non-string keys. A JSON object is the friendlier default for an empty mapping, and no consumer
  can distinguish the two cases for an empty collection anyway.
- `VisitPrimitive<T>`'s long `typeof` chain becomes runtime type dispatch. The one behavioral
  difference is `char`: upstream knows a `char` from an `int` statically and quotes it, while here
  a `char` arrives as a Python `int` unless the caller passes `PrimitiveType.CHAR`. The walker
  honors `primitive_type` when given (`SerializableValue.walk_editor` does pass it, same as for
  YAML) and falls back to runtime type otherwise.

Float formatting uses `repr`, which gives the shortest string that round-trips -- the same
guarantee C#'s `float`/`double` `ToString()` has had since .NET Core 3.0.
"""
from __future__ import annotations

import base64
import json

from assetripper_assets.traversal.asset_walker import AssetWalker
from assetripper_serialization_logic.primitive_type import PrimitiveType

_INDENT = "\t"

_QUOTED_PRIMITIVE_TYPES = frozenset({PrimitiveType.STRING, PrimitiveType.CHAR})


class DefaultJsonWalker(AssetWalker):
    def __init__(self):
        self._parts: list[str] = []
        self._indent = 0
        self._at_line_start = True

    def to_string(self) -> str:
        return "".join(self._parts)

    # -- output primitives --

    def _write(self, text: str) -> None:
        if self._at_line_start and text:
            self._parts.append(_INDENT * self._indent)
            self._at_line_start = False
        self._parts.append(text)

    def _write_line(self, text: str = "") -> None:
        self._write(text)
        self._parts.append("\n")
        self._at_line_start = True

    # -- assets --

    def enter_asset(self, asset) -> bool:
        self._write_line("{")
        self._indent += 1
        return True

    def divide_asset(self, asset) -> None:
        self._write_line(",")

    def exit_asset(self, asset) -> None:
        self._write_line()
        self._indent -= 1
        self._write("}")

    # -- fields --

    def enter_field(self, asset, name: str) -> bool:
        self._write(f"{json.dumps(name)}: ")
        return True

    # -- lists --

    def enter_list(self, list_, primitive_type=None) -> bool:
        if len(list_) == 0:
            self._write("[]")
            return False
        self._write_line("[")
        self._indent += 1
        return True

    def divide_list(self, list_, primitive_type=None) -> None:
        self._write_line(",")

    def exit_list(self, list_, primitive_type=None) -> None:
        self._write_line()
        self._indent -= 1
        self._write("]")

    # -- dictionaries --

    def enter_dictionary(self, dictionary) -> bool:
        self._string_keyed = _has_string_keys(dictionary)
        if len(dictionary) == 0:
            # See the module docstring: upstream emits `[]` here for non-string keys, which is
            # indistinguishable from `{}` to any consumer of an empty collection.
            self._write("{}")
            return False
        self._write_line("{" if self._string_keyed else "[")
        self._indent += 1
        return True

    def divide_dictionary(self, dictionary) -> None:
        self._write_line(",")

    def exit_dictionary(self, dictionary) -> None:
        self._write_line()
        self._indent -= 1
        self._write("}" if _has_string_keys(dictionary) else "]")

    def enter_dictionary_pair(self, pair) -> bool:
        if _is_string_key(pair):
            return True
        return self.enter_pair(pair)

    def divide_dictionary_pair(self, pair) -> None:
        if _is_string_key(pair):
            self._write(": ")
        else:
            self.divide_pair(pair)

    def exit_dictionary_pair(self, pair) -> None:
        if not _is_string_key(pair):
            self.exit_pair(pair)

    # -- pairs --

    def enter_pair(self, pair) -> bool:
        self._write_line("{")
        self._indent += 1
        self._write('"Key": ')
        return True

    def divide_pair(self, pair) -> None:
        self._write_line(",")
        self._write('"Value": ')

    def exit_pair(self, pair) -> None:
        self._write_line()
        self._indent -= 1
        self._write("}")

    # -- leaves --

    def visit_primitive(self, value, primitive_type=None) -> None:
        if isinstance(value, (bytes, bytearray)):
            self._write(json.dumps(base64.b64encode(bytes(value)).decode("ascii")))
        elif isinstance(value, str):
            self._write(json.dumps(value))
        elif isinstance(value, bool):
            # Before the int branch: bool is an int subclass in Python.
            self._write("true" if value else "false")
        elif primitive_type in _QUOTED_PRIMITIVE_TYPES:
            # A `char` reaches here as an int; upstream quotes it because it knows the static
            # type. Only reachable when the caller threads the field's PrimitiveType through.
            self._write(json.dumps(chr(value) if isinstance(value, int) else str(value)))
        elif isinstance(value, int):
            self._write(str(value))
        elif isinstance(value, float):
            self._write(repr(value))
        else:
            self._write(json.dumps("" if value is None else str(value)))

    def visit_pptr(self, pptr) -> None:
        self._write(f'{{ "m_FileID": {pptr.file_id}, "m_PathID": {pptr.path_id} }}')


def _has_string_keys(dictionary) -> bool:
    for pair in _pairs(dictionary):
        return _is_string_key(pair)
    return True


def _is_string_key(pair) -> bool:
    return isinstance(_key_of(pair), str)


def _pairs(dictionary):
    items = getattr(dictionary, "items", None)
    return items() if callable(items) else dictionary


def _key_of(pair):
    key = getattr(pair, "key", None)
    if key is not None:
        return key
    try:
        return pair[0]
    except (TypeError, IndexError, KeyError):
        return None


def export_json(asset) -> str:
    """The whole document for one asset, newline-terminated like upstream's writer."""
    walker = DefaultJsonWalker()
    asset.walk_standard(walker)
    return walker.to_string()

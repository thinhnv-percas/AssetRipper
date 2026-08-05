"""
Port of Source/AssetRipper.Yaml/YamlScalarNode.{Base,Creation,BooleanNode,NumericNode,
StringNode,FloatingPointHexNode,BoolListNode,CharListNode,NumericListNode}.cs

C#'s `YamlScalarNode` is an abstract class with a private constructor and several
private nested subclasses, only reachable through static factory methods (Create/CreateHex).
The private-nested-subclass structure is collapsed into one module with leading-underscore
"private" classes, since Python doesn't have C#'s nested-private-class visibility control
and there's no value in spreading one cohesive factory + hierarchy across many files.

Generic type parameters (NumericNode<T>, NumericListNode<T>, FloatingPointHexNode<T>) become
explicit width/kind arguments, since Python's `int`/`float` don't carry a C#-style static
type -- see create_hex_bytes/create_hex_single/create_hex_double below.
"""
from __future__ import annotations

import re
import struct
from abc import abstractmethod

from .dotnet_format import format_float
from .emitter import Emitter
from .extensions.reverse_hex_string import get_hex_string_length, write_reverse_hex_string
from .scalar_style import ScalarStyle
from .yaml_node import YamlNode
from .yaml_node_type import YamlNodeType

_ILLEGAL_STRINGS_RE = re.compile(
    r"""(^\s)|(^-\s)|(^-$)|(^[\:\[\]'"*&!@#%{}?<>,\`])|([:@]\s)|([\n\r])|([:\s]$)"""
)


class YamlScalarNode(YamlNode):
    @property
    def is_multiline(self) -> bool:
        return False

    @property
    def is_indent(self) -> bool:
        return False

    @property
    def node_type(self) -> YamlNodeType:
        return YamlNodeType.SCALAR

    @property
    def style(self) -> ScalarStyle:
        return ScalarStyle.PLAIN

    @property
    @abstractmethod
    def value(self) -> str: ...

    @abstractmethod
    def _emit_core(self, emitter: Emitter) -> None: ...

    def _emit(self, emitter: Emitter) -> None:
        super()._emit(emitter)

        style = self.style
        if style == ScalarStyle.PLAIN:
            self._emit_core(emitter)
        elif style == ScalarStyle.SINGLE_QUOTED:
            emitter.write("'")
            self._emit_core(emitter)
            emitter.write("'")
        elif style == ScalarStyle.DOUBLE_QUOTED:
            emitter.write('"')
            self._emit_core(emitter)
            emitter.write('"')
        else:
            raise Exception(f"Unsupported scalar style {style}")

    def __str__(self) -> str:
        return self.value

    # --- Factory methods (port of YamlScalarNode.Creation.cs) ---

    @staticmethod
    def create(value) -> "YamlScalarNode":
        if isinstance(value, bool):
            return _BooleanNode(value)
        if isinstance(value, str):
            return _StringNode(value)
        if isinstance(value, (int, float)):
            return _NumericNode(value)
        raise TypeError(f"Unsupported scalar value type: {type(value)!r}")

    @staticmethod
    def create_plain(value: str) -> "YamlScalarNode":
        return _StringNode(value, ScalarStyle.PLAIN)

    @staticmethod
    def create_hex_bytes(values, width_bytes: int) -> "YamlScalarNode":
        """Port of `CreateHex<T>(IReadOnlyList<T> list)` for integer element types
        (byte/short/ushort/int/uint/long/ulong); `width_bytes` stands in for T."""
        return _NumericListNode(values, width_bytes)

    @staticmethod
    def create_hex_bool_list(values) -> "YamlScalarNode":
        return _BoolListNode(values)

    @staticmethod
    def create_hex_char_list(values) -> "YamlScalarNode":
        return _CharListNode(values)

    @staticmethod
    def create_hex_single(value: float) -> "YamlScalarNode":
        return _FloatingPointHexNode(value, is_double=False)

    @staticmethod
    def create_hex_double(value: float) -> "YamlScalarNode":
        return _FloatingPointHexNode(value, is_double=True)


class _BooleanNode(YamlScalarNode):
    def __init__(self, value: bool):
        super().__init__()
        self._value = value

    def _emit_core(self, emitter: Emitter) -> None:
        emitter.write(1 if self._value else 0)

    @property
    def value(self) -> str:
        return "true" if self._value else "false"


class _NumericNode(YamlScalarNode):
    def __init__(self, value):
        super().__init__()
        self._value = value

    def _emit_core(self, emitter: Emitter) -> None:
        emitter.write(self._value)

    @property
    def value(self) -> str:
        return format_float(self._value) if isinstance(self._value, float) else str(self._value)


class _StringNode(YamlScalarNode):
    def __init__(self, value: str, style: ScalarStyle | None = None):
        super().__init__()
        self._value = value
        self._style = style if style is not None else _get_string_style(value)

    def _emit_core(self, emitter: Emitter) -> None:
        self._write_string(emitter)

    @property
    def value(self) -> str:
        return self._value

    @property
    def style(self) -> ScalarStyle:
        return self._style

    def _write_string(self, emitter: Emitter) -> None:
        if self._style == ScalarStyle.PLAIN:
            if emitter.is_format_keys and emitter.is_key:
                emitter.write_format(self._value)
            else:
                emitter.write(self._value)
        elif self._style == ScalarStyle.SINGLE_QUOTED:
            emitter.write_delayed()
            for c in self._value:
                emitter.write_raw(c)
                if c == "'":
                    emitter.write_raw(c)
                elif c == "\n":
                    emitter.write_raw("\n\t")
        elif self._style == ScalarStyle.DOUBLE_QUOTED:
            emitter.write_delayed()
            for c in self._value:
                if c == "\\":
                    emitter.write_raw("\\").write_raw("\\")
                elif c == "\n":
                    emitter.write_raw("\\").write_raw("n")
                elif c == "\r":
                    emitter.write_raw("\\").write_raw("r")
                elif c == "\t":
                    emitter.write_raw("\\").write_raw("t")
                elif c == '"':
                    emitter.write_raw("\\").write_raw('"')
                elif _is_control(c):
                    emitter.write_raw_unicode(c)
                else:
                    emitter.write_raw(c)
        else:
            raise NotImplementedError(str(self._style))


def _is_control(c: str) -> bool:
    code = ord(c)
    return code < 0x20 or code == 0x7F


def _get_string_style(value: str) -> ScalarStyle:
    if not value:
        return ScalarStyle.PLAIN
    elif any(_is_control(c) for c in value):
        return ScalarStyle.DOUBLE_QUOTED
    elif _ILLEGAL_STRINGS_RE.search(value):
        return ScalarStyle.DOUBLE_QUOTED if "\n " in value else ScalarStyle.SINGLE_QUOTED
    return ScalarStyle.PLAIN


class _FloatingPointHexNode(YamlScalarNode):
    """Hexadecimal representation of a floating point number: the only lossless way to
    represent one in YAML, though less readable than the default representation."""

    def __init__(self, value: float, is_double: bool):
        super().__init__()
        self._value = value
        self._is_double = is_double

    def _emit_core(self, emitter: Emitter) -> None:
        emitter.write(self.value)

    @property
    def value(self) -> str:
        if self._is_double:
            hex_value = struct.unpack("<Q", struct.pack("<d", self._value))[0]
            return f"0x{hex_value:016x}({format_float(self._value)})"
        else:
            single = struct.unpack("<f", struct.pack("<f", self._value))[0]
            hex_value = struct.unpack("<I", struct.pack("<f", single))[0]
            return f"0x{hex_value:08x}({format_float(single)})"


class _BoolListNode(YamlScalarNode):
    def __init__(self, values):
        super().__init__()
        self._values = list(values)

    def _emit_core(self, emitter: Emitter) -> None:
        for v in self._values:
            emitter.write(write_reverse_hex_string(1 if v else 0, 1))

    @property
    def value(self) -> str:
        return str(self._values)


class _CharListNode(YamlScalarNode):
    def __init__(self, values):
        super().__init__()
        self._values = list(values)

    def _emit_core(self, emitter: Emitter) -> None:
        for v in self._values:
            emitter.write(write_reverse_hex_string(ord(v), 2))

    @property
    def value(self) -> str:
        return str(self._values)


class _NumericListNode(YamlScalarNode):
    def __init__(self, values, width_bytes: int):
        super().__init__()
        self._values = list(values)
        self._width_bytes = width_bytes

    def _emit_core(self, emitter: Emitter) -> None:
        emitter.write(self.value)

    @property
    def value(self) -> str:
        return "".join(write_reverse_hex_string(v, self._width_bytes) for v in self._values)


assert get_hex_string_length  # re-exported for parity with the C# static helper; silences unused-import lints

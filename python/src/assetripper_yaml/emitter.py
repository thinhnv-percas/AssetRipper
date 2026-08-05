"""Port of Source/AssetRipper.Yaml/Emitter.cs"""
from __future__ import annotations

from .dotnet_format import format_float
from .meta_type import MetaType, to_string_representation


class Emitter:
    def __init__(self, writer, format_keys: bool):
        if writer is None:
            raise ValueError("writer must not be None")
        self._stream = writer
        self.is_format_keys = format_keys
        self.is_key = False
        self._indent = 0
        self._need_whitespace = False
        self._need_separator = False
        self._need_line_break = False

    def increase_indent(self) -> "Emitter":
        self._indent += 1
        return self

    def decrease_indent(self) -> "Emitter":
        if self._indent == 0:
            raise Exception("Increase/decrease indent mismatch")
        self._indent -= 1
        return self

    def write(self, value) -> "Emitter":
        """Port of the many Write(char/byte/short/int/long/float/double/string) overloads:
        a single dispatching method, since Python has no static overload resolution."""
        if isinstance(value, str) and value == "":
            return self
        self.write_delayed()
        if isinstance(value, bool):
            self._stream.write("1" if value else "0")
        elif isinstance(value, float):
            self._stream.write(format_float(value))
        else:
            self._stream.write(str(value))
        return self

    def write_raw(self, value) -> "Emitter":
        self._stream.write(str(value))
        return self

    def write_raw_unicode(self, char: str) -> "Emitter":
        """Writes a unicode character in the format \\uXXXX. Only used in DOUBLE_QUOTED strings."""
        self._stream.write(f"\\u{ord(char):04X}")
        return self

    def write_format(self, value: str) -> "Emitter":
        if len(value) > 0:
            self.write_delayed()
            if len(value) > 2 and value.startswith("m_"):
                rest = value[2:]
                if rest[0].isupper():
                    rest = rest[0].lower() + rest[1:]
                self._stream.write(rest)
            else:
                self._stream.write(value)
        return self

    def write_close_char(self, char: str) -> "Emitter":
        self._need_separator = False
        self._need_whitespace = False
        self._need_line_break = False
        return self.write(char)

    def write_close_str(self, value: str) -> "Emitter":
        self._need_separator = False
        self._need_whitespace = False
        return self.write(value)

    def write_whitespace(self) -> "Emitter":
        self._need_whitespace = True
        return self

    def write_separator(self) -> "Emitter":
        self._need_separator = True
        return self

    def write_line(self) -> "Emitter":
        self._need_line_break = True
        return self

    def write_meta(self, meta_type: MetaType, value: str) -> None:
        self.write("%").write(to_string_representation(meta_type)).write_whitespace()
        self.write(value).write_line()

    def write_delayed(self) -> None:
        if self._need_line_break:
            self._stream.write("\n")
            self._need_separator = False
            self._need_whitespace = False
            self._need_line_break = False
            self._write_indent()
        if self._need_separator:
            self._stream.write(",")
            self._need_separator = False
        if self._need_whitespace:
            self._stream.write(" ")
            self._need_whitespace = False

    def _write_indent(self) -> None:
        if self._indent > 0:
            if self._indent > 1000:
                raise ValueError(f"indent {self._indent} exceeds maximum of 1000")
            self._stream.write(" " * (self._indent * 2))

"""Port of Source/AssetRipper.Yaml/YamlEscaping.cs

https://yaml.org/spec/1.1/current.html#escaping%20in%20double-quoted%20style/
"""
from __future__ import annotations

_HEX_CHARACTERS = "0123456789ABCDEF"


def escape(value: str | None) -> str | None:
    if value is None:
        return None
    if value == "":
        return ""

    index = index_of_first_character_to_escape(value)
    if index < 0:
        return value

    parts = [value[:index]]
    for c in value[index:]:
        parts.append(_write_character(c))
    return "".join(parts)


def try_escape(c: str) -> tuple[bool, str | None]:
    if _needs_escaped(c):
        if c == "\\":
            return True, "\\\\"
        elif c == '"':
            return True, '\\"'
        elif c == "\n":
            return True, "\\n"
        elif c == "\r":
            return True, "\\r"
        elif c == "\t":
            return True, "\\t"
        else:
            return True, _escape_as_hex(c)
    return False, None


def _write_character(c: str) -> str:
    if _needs_escaped(c):
        if c == "\\":
            return "\\\\"
        elif c == '"':
            return '\\"'
        elif c == "\n":
            return "\\n"
        elif c == "\r":
            return "\\r"
        elif c == "\t":
            return "\\t"
        else:
            return _escape_as_hex(c)
    return c


def index_of_first_character_to_escape(value: str) -> int:
    for i, c in enumerate(value):
        if _needs_escaped(c):
            return i
    return -1


def _needs_escaped(c: str) -> bool:
    # A large portion of Unicode does not need escaping, but it's simpler to escape all
    # non-ascii characters. https://en.wikipedia.org/wiki/ASCII
    return not (0x20 <= ord(c) <= 0x7E) or c in ('"', "\\")


def _escape_as_hex(c: str) -> str:
    value = ord(c)
    if value > 0xFF:
        return f"\\u{_HEX_CHARACTERS[(value & 0xF000) >> 12]}{_HEX_CHARACTERS[(value & 0xF00) >> 8]}{_HEX_CHARACTERS[(value & 0xF0) >> 4]}{_HEX_CHARACTERS[value & 0xF]}"
    else:
        return f"\\x{_HEX_CHARACTERS[(value & 0xF0) >> 4]}{_HEX_CHARACTERS[value & 0xF]}"

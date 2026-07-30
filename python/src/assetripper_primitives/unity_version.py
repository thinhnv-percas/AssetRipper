"""
Port of the subset of AssetRipper.Primitives.UnityVersion used across Source/. This
package's source isn't vendored in this repo (external NuGet dependency), so this is a
best-effort reconstruction from call-site usage rather than a line-by-line port -- see
the task notes for the researched API surface (constructors, comparison overloads,
ToString/Parse round-tripping through strings like "2019.4.1f1").

The N-arg Equals/GreaterThanOrEquals/LessThan overloads compare only the first N fields
(in Major, Minor, Build, Type, TypeNumber order), ignoring the rest -- e.g.
`version.greater_than_or_equals(2017)` means "Major >= 2017" regardless of the other
components, which matches how call sites use it ("is this Unity 2017 or later").
"""
from __future__ import annotations

import re
from dataclasses import dataclass

from .unity_version_type import UnityVersionType, from_character, to_character

_PARSE_RE = re.compile(
    r"^(?P<major>\d+)(?:\.(?P<minor>\d+)(?:\.(?P<build>\d+)(?:(?P<type>[abfp])(?P<type_number>\d+))?)?)?$"
)


@dataclass(frozen=True, slots=True)
class UnityVersion:
    major: int = 0
    minor: int = 0
    build: int = 0
    type: UnityVersionType = UnityVersionType.FINAL
    type_number: int = 0

    def _tuple(self, n: int = 5) -> tuple:
        full = (self.major, self.minor, self.build, self.type.value, self.type_number)
        return full[:n]

    @staticmethod
    def _other_tuple(major: int, minor: int | None, build: int | None, type: UnityVersionType | None, type_number: int | None) -> tuple:
        values = (major, minor, build, type.value if type is not None else None, type_number)
        return tuple(v for v in values if v is not None)

    def equals(self, major: int, minor: int | None = None, build: int | None = None, type: UnityVersionType | None = None, type_number: int | None = None) -> bool:
        other = self._other_tuple(major, minor, build, type, type_number)
        return self._tuple(len(other)) == other

    def greater_than_or_equals(self, major: int, minor: int | None = None, build: int | None = None, type: UnityVersionType | None = None, type_number: int | None = None) -> bool:
        other = self._other_tuple(major, minor, build, type, type_number)
        return self._tuple(len(other)) >= other

    def less_than(self, major: int, minor: int | None = None, build: int | None = None, type: UnityVersionType | None = None, type_number: int | None = None) -> bool:
        other = self._other_tuple(major, minor, build, type, type_number)
        return self._tuple(len(other)) < other

    def __lt__(self, other: "UnityVersion") -> bool:
        return self._tuple() < other._tuple()

    def __le__(self, other: "UnityVersion") -> bool:
        return self._tuple() <= other._tuple()

    def __gt__(self, other: "UnityVersion") -> bool:
        return self._tuple() > other._tuple()

    def __ge__(self, other: "UnityVersion") -> bool:
        return self._tuple() >= other._tuple()

    @staticmethod
    def min(a: "UnityVersion", b: "UnityVersion") -> "UnityVersion":
        return a if a < b else b

    def __str__(self) -> str:
        return f"{self.major}.{self.minor}.{self.build}{to_character(self.type)}{self.type_number}"

    @staticmethod
    def parse(text: str) -> "UnityVersion":
        ok, result = UnityVersion.try_parse(text)
        if not ok:
            raise ValueError(f"Could not parse '{text}' as a UnityVersion")
        return result

    @staticmethod
    def try_parse(text: str) -> tuple[bool, "UnityVersion"]:
        match = _PARSE_RE.match(text.strip())
        if not match:
            return False, UnityVersion()
        major = int(match.group("major"))
        minor = int(match.group("minor") or 0)
        build = int(match.group("build") or 0)
        type_char = match.group("type")
        type_ = from_character(type_char) if type_char else UnityVersionType.FINAL
        type_number = int(match.group("type_number") or 0)
        return True, UnityVersion(major, minor, build, type_, type_number)


UnityVersion.MIN_VERSION = UnityVersion(0, 0, 0, UnityVersionType.ALPHA, 0)

"""Phase 16f part 2: resolves `(assembly, namespace, class_name)` across every Mono assembly
discovered under `Managed/` (`PlatformGameStructure.assemblies`), lazily parsing and caching
each `.dll` on first use via `mono_manager.read_assembly`.

This is the piece `base_manager.py`'s docstring calls "one interface regardless of backend":
`GameStructure` only needs to know it has *a* manager, not that it's specifically Mono.

Assembly name resolution mirrors `PlatformGameStructure.request_assembly` (already ported,
previously unused): given a `MonoScriptInfo.assembly` name (already `fix_assembly_name`-d --
".dll" stripped, and legacy short identifiers like "CSharp" rewritten to "Assembly - CSharp"),
looks up `f"{assembly}.dll"` in the raw path dict. For an ordinary modern assembly name this
round-trips correctly; the legacy-identifier rewrite case is not specially handled here (the
same pre-existing gap `request_assembly` itself has -- not introduced by this module).

A `.dll` that fails to parse (corrupt, obfuscated, not actually ECMA-335) is cached as
"unresolvable" after the first attempt rather than retried on every lookup.
"""
from __future__ import annotations

from .base_manager import BaseManager
from .mono_manager import MonoAssembly, read_assembly


class MonoAssemblyManager(BaseManager):
    def __init__(self, assembly_paths: "dict[str, str]", file_system):
        self._assembly_paths = dict(assembly_paths)
        """assembly-file-name (with '.dll') -> path."""
        self._file_system = file_system
        self._assemblies: "dict[str, MonoAssembly | None]" = {}

    def get_assembly_file_paths(self) -> "dict[str, str]":
        return dict(self._assembly_paths)

    def get_serializable_type(self, assembly: str, namespace: str, class_name: str):
        mono_assembly = self._get_assembly(assembly)
        if mono_assembly is None:
            return None
        return mono_assembly.get_serializable_type(namespace, class_name)

    def get_recovered_type(self, assembly: str, namespace: str, class_name: str):
        mono_assembly = self._get_assembly(assembly)
        if mono_assembly is None:
            return None
        return mono_assembly.get_type(namespace, class_name)

    def _get_assembly(self, assembly_name: str) -> "MonoAssembly | None":
        if assembly_name in self._assemblies:
            return self._assemblies[assembly_name]

        path = self._assembly_paths.get(f"{assembly_name}.dll")
        result: "MonoAssembly | None" = None
        if path is not None:
            try:
                data = self._file_system.file.read_all_bytes(path)
                result = read_assembly(data)
            except Exception:  # noqa: BLE001 -- a corrupt/foreign .dll should not abort loading
                result = None

        self._assemblies[assembly_name] = result
        return result

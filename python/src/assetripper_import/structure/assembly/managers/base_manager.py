"""Phase 16f part 2: the common interface `GameStructure`/`GameAssetFactory` consume, so
neither needs to know whether the concrete backend behind it is Mono (`mono_assembly_manager.
MonoAssemblyManager`) or IL2CPP (not implemented -- see ROADMAP.md Phase 16d/16e).

No upstream C# file to port 1:1: upstream's `IAssemblyManager` is a much larger interface
(assembly loading/unloading, `IsSet`, `GetAssemblies()`, `ScriptingBackend`, ...) most of which
this port has no use for (see `assetripper_processing/default_processors.py`'s docstring on
why `GetAssemblies()`-driven processors are skipped). Only the one method every current
caller actually needs is declared here.
"""
from __future__ import annotations


class BaseManager:
    """Null-object default: returns "unresolvable" for everything. Not currently assigned to
    `GameStructure.assembly_manager` directly (that stays `None` when no assemblies were
    found, matching the pre-16f contract every existing caller -- e.g. `DllPostExporter` --
    already checks for); this exists as the common base `MonoAssemblyManager` extends, and a
    future IL2CPP manager would extend the same way."""

    def get_serializable_type(self, assembly: str, namespace: str, class_name: str):
        return None

    def get_recovered_type(self, assembly: str, namespace: str, class_name: str):
        """`RecoveredType` (16b/16c) for `.cs` text emission -- a separate lookup from
        `get_serializable_type` because `script_exporter.py` needs display text, not a
        byte-layout-accurate graph. See `mono_manager.py`'s module docstring for why the two
        are built independently rather than one derived from the other."""
        return None

    def get_assembly_file_paths(self) -> "dict[str, str]":
        """assembly-file-name (with extension) -> path, for `DllPostExporter` to copy into
        AuxiliaryFiles/GameAssemblies/. Empty by default."""
        return {}

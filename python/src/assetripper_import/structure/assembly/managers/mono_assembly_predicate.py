"""
Port of the two static, IL-free members of
Source/AssetRipper.Import/Structure/Assembly/Managers/MonoManager.cs:
`AssemblyExtension` and `IsMonoAssembly`.

The rest of MonoManager (actually loading and parsing .dll files via AsmResolver) is not
ported -- see the phase plan on why script/assembly analysis is out of scope. This much is
still useful on its own: PlatformGameStructure only needs to know whether a directory
*looks like* it holds Mono assemblies (to report ScriptingBackend.MONO), not to read them.
"""
from __future__ import annotations

ASSEMBLY_EXTENSION = ".dll"


def is_mono_assembly(file_name: str) -> bool:
    return file_name.endswith(ASSEMBLY_EXTENSION)

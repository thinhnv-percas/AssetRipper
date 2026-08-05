"""Port of Source/AssetRipper.Export.UnityProjects/Scripts/MonoScriptInfo.cs"""
from __future__ import annotations

from dataclasses import dataclass

from assetripper_io_files.special_file_names import fix_assembly_name


@dataclass(frozen=True, slots=True)
class MonoScriptInfo:
    class_name: str
    namespace: str
    assembly: str

    @staticmethod
    def from_mono_script(mono_script) -> "MonoScriptInfo":
        return MonoScriptInfo(
            mono_script.get("m_ClassName") or "",
            mono_script.get("m_Namespace") or "",
            fix_assembly_name(mono_script.get("m_AssemblyName") or ""),
        )

    def is_injected(self) -> bool:
        return not self.class_name and not self.namespace and not self.assembly

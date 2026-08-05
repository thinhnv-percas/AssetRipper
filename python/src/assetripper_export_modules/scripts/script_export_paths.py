"""Port of the folder/file-naming helpers in
Source/AssetRipper.Export.UnityProjects/Scripts/ScriptExportCollectionBase.cs
"""
from __future__ import annotations

import os

from assetripper_io_files.filesystem import fix_invalid_path_characters
from assetripper_io_files.special_file_names import remove_assembly_file_extension

_FIRSTPASS_PLUGIN_ASSEMBLIES = frozenset(
    (
        "Assembly-CSharp-firstpass",
        "Assembly - CSharp - firstpass",
        "Assembly-UnityScript-firstpass",
        "Assembly - UnityScript - firstpass",
    )
)


def get_scripts_folder_name(assembly_name: str) -> str:
    return "Plugins" if assembly_name in _FIRSTPASS_PLUGIN_ASSEMBLIES else "Scripts"


def get_export_sub_path(assembly: str, namespace: str, class_name: str) -> "tuple[str, str]":
    """Returns (folder_path, file_name) for a script with this (assembly, namespace, class)."""
    assembly_folder = remove_assembly_file_extension(assembly)
    scripts_folder = get_scripts_folder_name(assembly_folder)
    namespace_folder = namespace.replace(".", os.sep)
    folder_path = fix_invalid_path_characters(os.path.join(scripts_folder, assembly_folder, namespace_folder))
    file_name = f"{fix_invalid_path_characters(class_name)}.cs"
    return folder_path, file_name

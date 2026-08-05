"""Port of Source/AssetRipper.IO.Files/SpecialFileNames.cs"""
from __future__ import annotations

import os

LIBRARY_FOLDER = "library/"
RESOURCES_FOLDER = "resources/"
DEFAULT_RESOURCE_NAME_1 = "unity default resources"
DEFAULT_RESOURCE_NAME_2 = "unity_default_resources"
EDITOR_RESOURCE_NAME = "unity editor resources"
BUILTIN_EXTRA_NAME_1 = "unity builtin extra"
BUILTIN_EXTRA_NAME_2 = "unity_builtin_extra"
ENGINE_GENERATED_F = "0000000000000000f000000000000000"
ASSEMBLY_EXTENSION = ".dll"

_ASSEMBLY_IDENTIFIERS = {
    "Boo", "Boo - first pass",
    "CSharp", "CSharp - first pass",
    "UnityScript", "UnityScript - first pass",
}


def is_engine_resource(file_name: str | None) -> bool:
    return is_default_resource(file_name) or is_editor_resource(file_name)


def is_default_resource(file_name: str | None) -> bool:
    return file_name in (DEFAULT_RESOURCE_NAME_1, DEFAULT_RESOURCE_NAME_2)


def is_editor_resource(file_name: str | None) -> bool:
    return file_name == EDITOR_RESOURCE_NAME


def is_builtin_extra(file_name: str | None) -> bool:
    return file_name in (BUILTIN_EXTRA_NAME_1, BUILTIN_EXTRA_NAME_2)


def is_default_resource_or_builtin_extra(file_name: str | None) -> bool:
    return is_default_resource(file_name) or is_builtin_extra(file_name)


def is_engine_generated_f(file_name: str | None) -> bool:
    return file_name == ENGINE_GENERATED_F


def fix_file_identifier(name: str) -> str:
    name = name.lower()
    name = fix_dependency_name(name)
    name = fix_resource_path(name)
    return name


def fix_dependency_name(dependency: str) -> str:
    if dependency.startswith(LIBRARY_FOLDER):
        return dependency[len(LIBRARY_FOLDER):]
    elif dependency.startswith(RESOURCES_FOLDER):
        return dependency[len(RESOURCES_FOLDER):]
    return dependency


def fix_resource_path(resource_path: str) -> str:
    archive_prefix = "archive:/"
    if resource_path.startswith(archive_prefix):
        return os.path.basename(resource_path)
    return resource_path


def fix_assembly_name(assembly: str) -> str:
    """Removes the .dll extension and adds the "Assembly - " prefix if appropriate."""
    return remove_assembly_file_extension(f"Assembly - {assembly}" if _is_assembly_identifier(assembly) else assembly)


def remove_assembly_file_extension(assembly: str) -> str:
    return assembly[: -len(ASSEMBLY_EXTENSION)] if assembly.endswith(ASSEMBLY_EXTENSION) else assembly


def add_assembly_file_extension(assembly: str) -> str:
    return assembly if assembly.endswith(ASSEMBLY_EXTENSION) else assembly + ASSEMBLY_EXTENSION


def is_project_assembly(assembly: str) -> bool:
    prefix_name = "Assembly"
    return assembly.startswith(f"{prefix_name} - ") or assembly.startswith(f"{prefix_name}-")


def _is_assembly_identifier(assembly: str) -> bool:
    return assembly in _ASSEMBLY_IDENTIFIERS

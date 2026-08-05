"""Port of Source/AssetRipper.Export.UnityProjects/Project/UnityPatches.cs

Some asset types need Unity Editor scripts to complete their recovery; this copies a fixed
patch script's text into the exported project, under Assets/Editor/AssetRipperPatches/.
"""
from __future__ import annotations

_RELATIVE_PATH_TO_PATCHES_DIRECTORY = "Assets/Editor/AssetRipperPatches/"


def apply_patch_from_text(text: str, name: str, export_directory_path: str, file_system) -> None:
    patch_file_name = f"{name}.cs"
    patch_directory_path = file_system.path.join(export_directory_path, _RELATIVE_PATH_TO_PATCHES_DIRECTORY)
    patch_file_path = file_system.path.join(patch_directory_path, patch_file_name)
    if file_system.file.exists(patch_file_path):
        return

    file_system.directory.create(patch_directory_path)
    with file_system.file.create(patch_file_path) as stream:
        data = text.encode("utf-8")
        stream.write(data, 0, len(data))

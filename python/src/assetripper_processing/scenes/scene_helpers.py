"""Port of Source/AssetRipper.Processing/Scenes/SceneHelpers.cs

`build_settings` is accessed dynamically (`build_settings["m_Scenes"]`) rather than through
a generated `IBuildSettings` interface -- BuildSettings (class ID 141) is not covered by
Phase 2's hand-written layouts, but its embedded type tree is present in virtually every
real game file, so dynamic access works the same way it does for every other asset in this
port. `IsSceneCompatible` (used by the not-yet-ported PrefabProcessor) is not ported here.
"""
from __future__ import annotations

import posixpath
import re

_ASSETS_NAME = "Assets/"
_LIBRARY_PACKAGE_CACHE_NAME = "Library/PackageCache/"
_LEVEL_NAME = "level"
_MAIN_SCENE_NAME = "maindata"

_SCENE_NAME_FORMAT = re.compile(r"^level(0|([1-9][0-9]*))$")


def has_main_data(version) -> bool:
    """Less than 5.3.0."""
    return version.less_than(5, 3)


def try_get_file_name_to_scene_index(name: str, version) -> tuple[bool, int]:
    if has_main_data(version):
        if name == _MAIN_SCENE_NAME:
            return True, 0
        if _SCENE_NAME_FORMAT.match(name):
            return True, int(name[len(_LEVEL_NAME):]) + 1
    else:
        if _SCENE_NAME_FORMAT.match(name):
            return True, int(name[len(_LEVEL_NAME):])
    return False, -1


def scene_index_to_file_name(index: int, version) -> str:
    if has_main_data(version):
        if index == 0:
            return _MAIN_SCENE_NAME
        return f"{_LEVEL_NAME}{index - 1}"
    return f"{_LEVEL_NAME}{index}"


def try_get_scene_path(collection, build_settings) -> tuple[bool, str | None]:
    if build_settings is None:
        return False, None

    found, index = try_get_file_name_to_scene_index(collection.name, collection.original_version)
    if not found:
        return False, None

    scenes: list[str] = build_settings.get("m_Scenes", [])
    if index >= len(scenes):
        # A game can be built with N scenes, one gets removed from the project, and the
        # developer forgets to delete the Nth scene file on the next build -- N-1 scenes in
        # BuildSettings, but N scene files for us to find.
        return False, None

    scene_path = scenes[index]
    extension = posixpath.splitext(scene_path)[1]

    if scene_path.startswith(_ASSETS_NAME):
        return True, scene_path[: len(scene_path) - len(extension)]
    if scene_path.startswith(_LIBRARY_PACKAGE_CACHE_NAME):
        return True, scene_path[: len(scene_path) - len(extension)]
    if posixpath.isabs(scene_path) or (len(scene_path) > 1 and scene_path[1] == ":"):
        # pull/uTiny 617: an absolute project path may itself contain "Assets/" in its name,
        # so this can recover the wrong scene path in that case -- no way to avoid it.
        start_index = scene_path.find(_ASSETS_NAME)
        if start_index < 0:
            start_index = scene_path.find(_LIBRARY_PACKAGE_CACHE_NAME)
        if start_index < 0:
            return False, None
        return True, scene_path[start_index: len(scene_path) - len(extension)]
    if not scene_path:
        # If a game is built without included scenes, Unity creates one with an empty name.
        return False, None
    return True, posixpath.join("Assets", "Scenes", scene_path)


def is_scene_duplicate(scene_index: int, build_settings) -> bool:
    if build_settings is None:
        return False

    scenes: list[str] = build_settings.get("m_Scenes", [])
    scene_name = scenes[scene_index]
    return any(name == scene_name and i != scene_index for i, name in enumerate(scenes))

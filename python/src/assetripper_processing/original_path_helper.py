"""Port of Source/AssetRipper.Processing/OriginalPathHelper.cs"""
from __future__ import annotations

_DIRECTORY_SEPARATOR = "/"
_ASSETS_KEYWORD = "Assets"
_ASSETS_DIRECTORY = _ASSETS_KEYWORD + _DIRECTORY_SEPARATOR


def ensure_path_not_rooted(asset_path: str) -> str:
    if _is_path_rooted(asset_path):
        split_path = asset_path.split("/")
        for i, section in enumerate(split_path):
            if section.lower() == _ASSETS_KEYWORD.lower():
                return _DIRECTORY_SEPARATOR.join(split_path[i:])
        return ""
    return asset_path


def ensure_starts_with_assets(asset_path: str) -> str:
    if asset_path.startswith(_ASSETS_DIRECTORY):
        return asset_path
    if asset_path.lower().startswith(_ASSETS_DIRECTORY.lower()):
        return _ASSETS_DIRECTORY + asset_path[len(_ASSETS_DIRECTORY):]
    return _ASSETS_DIRECTORY + asset_path


def _is_path_rooted(path: str) -> bool:
    return path.startswith(("/", "\\")) or (len(path) > 1 and path[1] == ":")

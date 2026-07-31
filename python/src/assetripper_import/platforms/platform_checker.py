"""Port of Source/AssetRipper.Import/Platforms/PlatformChecker.cs

Upstream logs each detection via its own `Logger.Info(LogCategory.Import, ...)`; here we use
the stdlib `logging` module instead of porting that custom logging framework.
"""
from __future__ import annotations

import logging

from .android_game_structure import AndroidGameStructure
from .ios_game_structure import iOSGameStructure  # noqa: N813 -- matches upstream's own casing
from .linux_game_structure import LinuxGameStructure
from .mac_game_structure import MacGameStructure
from .mixed_game_structure import MixedGameStructure
from .platform_game_structure import PlatformGameStructure
from .ps4_game_structure import PS4GameStructure
from .switch_game_structure import SwitchGameStructure
from .webgl_game_structure import WebGLGameStructure
from .webplayer_game_structure import WebPlayerGameStructure
from .wiiu_game_structure import WiiUGameStructure
from .windows_game_structure import WindowsGameStructure
from .windows_phone_game_structure import WindowsPhoneGameStructure

_logger = logging.getLogger(__name__)


def check_platform(paths: list[str], file_system) -> tuple[PlatformGameStructure | None, MixedGameStructure | None]:
    """Tries each platform structure in turn against `paths`, removing consumed entries
    as it goes, then always runs the mixed-structure check last against whatever remains.
    """
    platform_structure: PlatformGameStructure | None = None

    windows = _check_windows(paths, file_system)
    if windows is not None:
        platform_structure = windows
    else:
        linux = _check_linux(paths, file_system)
        if linux is not None:
            platform_structure = linux
        else:
            mac = _check_mac(paths, file_system)
            if mac is not None:
                platform_structure = mac
            else:
                android = _check_android(paths, file_system)
                if android is not None:
                    platform_structure = android
                else:
                    ios = _check_ios(paths, file_system)
                    if ios is not None:
                        platform_structure = ios
                    else:
                        switch = _check_switch(paths, file_system)
                        if switch is not None:
                            platform_structure = switch
                        else:
                            ps4 = _check_ps4(paths, file_system)
                            if ps4 is not None:
                                platform_structure = ps4
                            else:
                                webgl = _check_webgl(paths, file_system)
                                if webgl is not None:
                                    platform_structure = webgl
                                else:
                                    webplayer = _check_webplayer(paths, file_system)
                                    if webplayer is not None:
                                        platform_structure = webplayer
                                    else:
                                        wiiu = _check_wiiu(paths, file_system)
                                        if wiiu is not None:
                                            platform_structure = wiiu
                                        else:
                                            platform_structure = _check_windows_phone(paths, file_system)

    mixed_structure = _check_mixed(paths, file_system)

    return platform_structure, mixed_structure


def _check_windows(paths: list[str], file_system) -> WindowsGameStructure | None:
    for path in paths:
        if WindowsGameStructure.exists(path, file_system):
            game_structure = WindowsGameStructure(path, file_system)
            paths.remove(path)
            _logger.info("Windows game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_linux(paths: list[str], file_system) -> LinuxGameStructure | None:
    for path in paths:
        if LinuxGameStructure.exists(path, file_system):
            game_structure = LinuxGameStructure(path, file_system)
            paths.remove(path)
            _logger.info("Linux game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_mac(paths: list[str], file_system) -> MacGameStructure | None:
    for path in paths:
        if MacGameStructure.exists(path, file_system):
            game_structure = MacGameStructure(path, file_system)
            paths.remove(path)
            _logger.info("Mac game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_android(paths: list[str], file_system) -> AndroidGameStructure | None:
    android_structure: str | None = None
    obb_structure: str | None = None
    for path in paths:
        if AndroidGameStructure.is_android_structure(path, file_system):
            if android_structure is None:
                android_structure = path
            else:
                raise ValueError("2 Android game stuctures has been found")
        elif AndroidGameStructure.is_android_obb_structure(path, file_system):
            if obb_structure is None:
                obb_structure = path
            else:
                raise ValueError("2 Android obb game stuctures has been found")

    if android_structure is not None:
        game_structure = AndroidGameStructure(android_structure, obb_structure, file_system)
        paths.remove(android_structure)
        _logger.info("Android game structure has been found at '%s'", android_structure)
        if obb_structure is not None:
            paths.remove(obb_structure)
            _logger.info("Android obb game structure has been found at '%s'", obb_structure)
        return game_structure

    return None


def _check_ios(paths: list[str], file_system) -> iOSGameStructure | None:
    for path in paths:
        if iOSGameStructure.exists(path, file_system):
            game_structure = iOSGameStructure(path, file_system)
            paths.remove(path)
            _logger.info("iOS game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_ps4(paths: list[str], file_system) -> PS4GameStructure | None:
    for path in paths:
        if PS4GameStructure.exists(path, file_system):
            game_structure = PS4GameStructure(path, file_system)
            paths.remove(path)
            _logger.info("PS4 game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_switch(paths: list[str], file_system) -> SwitchGameStructure | None:
    for path in paths:
        if SwitchGameStructure.exists(path, file_system):
            game_structure = SwitchGameStructure(path, file_system)
            paths.remove(path)
            _logger.info("Switch game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_webgl(paths: list[str], file_system) -> WebGLGameStructure | None:
    for path in paths:
        if WebGLGameStructure.exists(path, file_system):
            game_structure = WebGLGameStructure(path, file_system)
            paths.remove(path)
            _logger.info("WebGL game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_webplayer(paths: list[str], file_system) -> WebPlayerGameStructure | None:
    for path in paths:
        if WebPlayerGameStructure.exists(path, file_system):
            game_structure = WebPlayerGameStructure(path, file_system)
            paths.remove(path)
            _logger.info("WebPlayer game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_wiiu(paths: list[str], file_system) -> WiiUGameStructure | None:
    for path in paths:
        if WiiUGameStructure.exists(path, file_system):
            game_structure = WiiUGameStructure(path, file_system)
            paths.remove(path)
            _logger.info("WiiU game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_windows_phone(paths: list[str], file_system) -> WindowsPhoneGameStructure | None:
    for path in paths:
        if WindowsPhoneGameStructure.exists(path, file_system):
            game_structure = WindowsPhoneGameStructure(path, file_system)
            paths.remove(path)
            _logger.info("Windows Phone game structure has been found at '%s'", path)
            return game_structure
    return None


def _check_mixed(paths: list[str], file_system) -> MixedGameStructure | None:
    if paths:
        game_structure = MixedGameStructure(paths, file_system)
        if len(paths) == 1:
            _logger.info("Mixed game structure has been found at %s", paths[0])
        else:
            _logger.info("Mixed game structure has been found for %d paths", len(paths))
        paths.clear()
        return game_structure
    return None

"""
Port of Source/AssetRipper.IO.Files/BuildTarget.cs

https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/BuildTarget.cs
"""
from __future__ import annotations

from enum import IntEnum

_STANDALONE_TARGETS = frozenset()  # populated after class definition, see below


class BuildTarget(IntEnum):
    VALID_PLAYER = 1
    STANDALONE_OSX_UNIVERSAL = 2
    """Universal macOS standalone."""
    STANDALONE_OSX_PPC = 3
    """macOS standalone (PowerPC only)."""
    STANDALONE_OSX_INTEL = 4
    """macOS standalone (Intel only)."""
    STANDALONE_WIN_PLAYER = 5
    """Windows standalone."""
    WEB_PLAYER_LZMA = 6
    """Web player."""
    WEB_PLAYER_LZMA_STREAMED = 7
    """Streamed web player."""
    WII = 8
    """Nintendo Wii."""
    IOS = 9
    """iOS player."""
    PS3 = 10
    """PlayStation 3."""
    XBOX_360 = 11
    BROADCOM = 12
    ANDROID = 13
    """Android .apk standalone app."""
    WIN_GLES_EMU = 14
    WIN_GLES20_EMU = 15
    GOOGLE_NA_CL = 16
    """Google Native Client."""
    STANDALONE_LINUX = 17
    """Linux standalone."""
    FLASH = 18
    STANDALONE_WIN64_PLAYER = 19
    """Windows 64-bit standalone."""
    WEBGL = 20
    """WebGL."""
    METRO_PLAYER_X86 = 21
    """Windows Store Apps player."""
    METRO_PLAYER_X64 = 22
    """Windows Store Apps player."""
    METRO_PLAYER_ARM = 23
    """Windows Store Apps player."""
    STANDALONE_LINUX64 = 24
    """Linux 64-bit standalone."""
    STANDALONE_LINUX_UNIVERSAL = 25
    """Linux universal standalone."""
    WP8_PLAYER = 26
    """Windows Phone 8 player."""
    STANDALONE_OSX_INTEL64 = 27
    """macOS Intel 64-bit standalone."""
    BB10 = 28
    """BlackBerry."""
    TIZEN = 29
    """Tizen player."""
    PSP2 = 30
    """PS Vita Standalone."""
    PS4 = 31
    """PS4 Standalone."""
    PSM = 32
    """PlayStation Mobile."""
    XBOX_ONE = 33
    """Xbox One Standalone."""
    SAMSUNG_TV = 34
    """Samsung Smart TV."""
    N3DS = 35
    """Nintendo 3DS."""
    WII_U = 36
    """Wii U standalone."""
    TV_OS = 37
    """Apple tvOS."""
    SWITCH = 38
    """Nintendo Switch player."""
    LUMIN = 39
    STADIA = 40
    """Stadia standalone."""
    CLOUD_RENDERING = 41
    GAME_CORE_XBOX_SERIES = 42
    """Xbox Series player."""
    GAME_CORE_XBOX_ONE = 43
    """Xbox one player."""
    PS5 = 44
    """PS5 Standalone."""
    EMBEDDED_LINUX = 45
    QNX = 46
    VISION_OS = 47
    """Apple Vision OS."""
    SWITCH2 = 48
    """Nintendo Switch 2."""
    KEPLER = 49

    NO_TARGET = 0xFFFFFFFE
    """Editor."""
    ANY_PLAYER = 0xFFFFFFFF


_STANDALONE_TARGETS = frozenset({
    BuildTarget.STANDALONE_WIN_PLAYER,
    BuildTarget.STANDALONE_WIN64_PLAYER,
    BuildTarget.STANDALONE_LINUX,
    BuildTarget.STANDALONE_LINUX64,
    BuildTarget.STANDALONE_LINUX_UNIVERSAL,
    BuildTarget.STANDALONE_OSX_INTEL,
    BuildTarget.STANDALONE_OSX_INTEL64,
    BuildTarget.STANDALONE_OSX_PPC,
    BuildTarget.STANDALONE_OSX_UNIVERSAL,
})


def is_standalone(target: BuildTarget) -> bool:
    return target in _STANDALONE_TARGETS


def is_compatible(target: BuildTarget, comp: BuildTarget) -> bool:
    return target == comp or (is_standalone(target) and is_standalone(comp))

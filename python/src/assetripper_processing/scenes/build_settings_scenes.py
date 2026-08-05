"""Reads only `BuildSettings.m_Scenes` straight out of an unlayouted asset's raw bytes
(2026-08-03).

Why this exists instead of a hand-written `BuildSettings` layout. A shipped player build usually
embeds no type tree, so `BuildSettings` (class ID 141) comes through as a content-less
`RawDataObject`, and every scene then falls back to a generic name -- on the real fixture the two
scenes exported as `level0`/`level1` instead of `Loading`/`Game`. A full layout would fix that,
but it cannot be written honestly yet: a real 2022.3 `BuildSettings` has **28 bytes between
`m_Scenes` and the version string** whose fields nobody involved has been able to identify, and a
layout has to consume the object's bytes *exactly* or `try_read` rejects it (see
`SerializableStructure.try_read`). Guessing 28 bytes of field names is precisely the kind of
fabrication this port declines.

`m_Scenes` needs none of that, because it is the **first** field, so it can be read without any
claim about what follows. Three independent sources agree on both its position and its encoding:

- the real fixture's bytes, decoded field by field (see the test module for the annotated dump);
- upstream's own `SceneHelpers.cs`, which indexes `buildSettings.Scenes[sceneIndex]`;
- AssetStudio's `BuildSettings.cs`, whose reader starts with `reader.ReadStringArray()` -- from a
  much older Unity, which is the point: the leading string array has been stable throughout.

The reader stops the moment the scene list ends and never looks at the unidentified region. Any
implausible count or length makes it decline rather than return a half-read list, so a build whose
`BuildSettings` really does start with something else keeps today's generic-name behavior instead
of getting invented scene names.
"""
from __future__ import annotations

import logging
import struct

_logger = logging.getLogger(__name__)

_MAX_PLAUSIBLE_SCENE_COUNT = 4096
"""Unity's own build-settings UI does not meaningfully scale past a few hundred scenes. The bound
exists to reject a misread length before it allocates, not to enforce a real Unity limit."""

_MAX_PLAUSIBLE_PATH_LENGTH = 1024


def try_read_scenes(raw_data: bytes) -> "list[str] | None":
    """The scene paths from a raw `BuildSettings` payload, or None if it does not start with a
    plausible string array."""
    if len(raw_data) < 4:
        return None

    count = struct.unpack_from("<i", raw_data, 0)[0]
    if count < 0 or count > _MAX_PLAUSIBLE_SCENE_COUNT:
        return None

    offset = 4
    scenes: list[str] = []
    for _ in range(count):
        if offset + 4 > len(raw_data):
            return None
        length = struct.unpack_from("<i", raw_data, offset)[0]
        offset += 4
        if length < 0 or length > _MAX_PLAUSIBLE_PATH_LENGTH or offset + length > len(raw_data):
            return None
        try:
            scenes.append(raw_data[offset : offset + length].decode("utf-8"))
        except UnicodeDecodeError:
            return None
        offset += length
        # Unity aligns after every string in a release-format array.
        offset += -length % 4

    if offset > len(raw_data):
        return None
    return scenes


def scenes_of(build_settings) -> "list[str] | None":
    """`m_Scenes` for a `BuildSettings` asset, whether it has a resolved layout or not.

    Prefers the layout when there is one -- a real type tree is always better evidence than this
    module's assumption about the first field. Falls back to the raw bytes only for the
    no-type-tree case that made this necessary.
    """
    if build_settings is None:
        return None

    getter = getattr(build_settings, "get", None)
    if getter is not None:
        scenes = getter("m_Scenes", None)
        if scenes is not None:
            return list(scenes)

    raw_data = getattr(build_settings, "raw_data", None)
    if not raw_data:
        return None

    scenes = try_read_scenes(bytes(raw_data))
    if scenes is None:
        _logger.warning(
            "BuildSettings has no resolved layout and its raw bytes do not begin with a "
            "plausible scene list; scenes will keep their generic level* names"
        )
        return None
    _logger.info("Recovered %d scene path(s) from BuildSettings' raw bytes", len(scenes))
    return scenes

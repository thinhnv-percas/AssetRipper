"""Tests for `scenes/build_settings_scenes.py` (2026-08-03).

What this closes: a shipped player build embeds no type tree, so `BuildSettings` arrives as a
content-less `RawDataObject` and every scene fell back to a generic name -- on the real fixture
the two scenes exported as `level0`/`level1` instead of `Loading`/`Game`.

The reason it reads raw bytes instead of using a hand-written layout is that a layout must consume
an object's bytes *exactly*, and 28 bytes of the real 2022.3 `BuildSettings` are still
unidentified. `m_Scenes` is the first field, so it needs no claim about the rest.

The annotated real payload this was derived from (`demo-android.apk`, Unity 2022.3.62f2, 204
bytes total):

    00: 02 00 00 00                  m_Scenes count = 2
    04: 1b 00 00 00                  length 27
    08: "Assets/Scenes/Loading.unity" 27 bytes
    35: 00                           align to 4
    36: 18 00 00 00                  length 24
    40: "Assets/Scenes/Game.unity"    24 bytes, already aligned
    64: 28 unidentified bytes         00 x18, 01 01 01 01, 00 00 01, 00 00 00
    92: 0b 00 00 00 "2022.3.62f2" 00  m_Version, aligned
   108: 50 00 00 00 <80 hex chars>    an 80-character hash
   192: 02 00 00 00 15 00 00 00 0b 00 00 00   12 unidentified bytes

Everything from offset 64 on is what makes a full layout impossible to write honestly; everything
before it is what this module reads.
"""
from __future__ import annotations

import struct

import pytest
from assetripper_primitives import UnityVersion
from assetripper_processing.scenes import scene_helpers
from assetripper_processing.scenes.build_settings_scenes import scenes_of, try_read_scenes


def _payload(paths: "list[str]", *, trailing: bytes = b"") -> bytes:
    """A `BuildSettings` payload prefix in Unity's release format: count, then aligned strings."""
    data = struct.pack("<i", len(paths))
    for path in paths:
        encoded = path.encode("utf-8")
        data += struct.pack("<i", len(encoded)) + encoded
        data += b"\x00" * (-len(encoded) % 4)
    return data + trailing


class _RawAsset:
    """Stands in for a `RawDataObject`: raw bytes, and a `.get` that finds nothing (which is what
    an unlayouted asset actually behaves like)."""

    def __init__(self, raw_data: bytes):
        self.raw_data = raw_data

    def get(self, name, default=None):
        return default


class _LayoutedAsset:
    def __init__(self, scenes):
        self._scenes = scenes
        self.raw_data = b"\xff" * 32  # deliberately garbage, to prove it is not consulted

    def get(self, name, default=None):
        return self._scenes if name == "m_Scenes" else default


# -- the real payload ---------------------------------------------------------------------

_REAL_PAYLOAD = bytes.fromhex(
    "02000000"
    "1b000000" + b"Assets/Scenes/Loading.unity".hex() + "00"
    "18000000" + b"Assets/Scenes/Game.unity".hex() +
    "000000000000000000000000000000000000010101010000010000 00".replace(" ", "")
    + "0b000000" + b"2022.3.62f2".hex() + "00"
    + "50000000" + b"ec934bc49726ad316ecf4a071004a2a9ee77fff3eed7bcacddfe3ea4561eb73612731ba32d48ce12".hex()
    + "02000000" "15000000" "0b000000"
)


def test_the_real_fixture_payload_yields_its_two_scene_paths():
    """The case that motivated all of this, byte for byte."""
    assert try_read_scenes(_REAL_PAYLOAD) == [
        "Assets/Scenes/Loading.unity",
        "Assets/Scenes/Game.unity",
    ]


def test_the_real_payload_is_the_length_the_fixture_had():
    """Guards the dump in this module's docstring against drifting from the bytes below it."""
    assert len(_REAL_PAYLOAD) == 204


def test_reading_stops_before_the_unidentified_region():
    """The whole premise: replacing everything past the scene list with garbage must not change
    the result, because the reader never looks there."""
    scene_list_length = 64
    mangled = _REAL_PAYLOAD[:scene_list_length] + b"\xa5" * (len(_REAL_PAYLOAD) - scene_list_length)

    assert try_read_scenes(mangled) == try_read_scenes(_REAL_PAYLOAD)


# -- encoding details ---------------------------------------------------------------------


def test_an_unaligned_string_is_padded_to_four_bytes():
    """The Loading path is 27 bytes and needs 1 byte of padding; getting that wrong shifts every
    later entry."""
    assert try_read_scenes(_payload(["abc", "de"])) == ["abc", "de"]


@pytest.mark.parametrize("length", [1, 2, 3, 4, 5, 7, 8, 9])
def test_every_alignment_remainder_round_trips(length):
    path = "x" * length
    assert try_read_scenes(_payload([path, "second"])) == [path, "second"]


def test_an_empty_scene_list_is_an_empty_list_not_none():
    """`[]` and `None` mean different things to `scene_helpers`: a game built with no scenes
    versus BuildSettings that could not be read at all."""
    assert try_read_scenes(_payload([])) == []


def test_trailing_bytes_after_the_scene_list_are_ignored():
    assert try_read_scenes(_payload(["Assets/Scenes/A.unity"], trailing=b"\x01" * 40)) == [
        "Assets/Scenes/A.unity"
    ]


# -- declining rather than guessing -------------------------------------------------------


def test_too_short_to_hold_a_count_declines():
    assert try_read_scenes(b"\x02\x00") is None


def test_a_negative_count_declines():
    assert try_read_scenes(struct.pack("<i", -1)) is None


def test_an_absurd_count_declines():
    """A build whose BuildSettings really starts with something else must not be misread as
    having millions of scenes."""
    assert try_read_scenes(struct.pack("<i", 10_000_000)) is None


def test_a_count_that_overruns_the_payload_declines():
    assert try_read_scenes(struct.pack("<ii", 3, 4) + b"abcd") is None


def test_a_string_length_that_overruns_the_payload_declines():
    assert try_read_scenes(struct.pack("<ii", 1, 500) + b"abcd") is None


def test_a_negative_string_length_declines():
    assert try_read_scenes(struct.pack("<ii", 1, -8) + b"abcd") is None


def test_non_utf8_bytes_decline():
    """Rather than returning a mojibake path that would become a real directory name."""
    assert try_read_scenes(struct.pack("<ii", 1, 4) + b"\xff\xfe\xfd\xfc") is None


# -- scenes_of: layout wins, raw bytes are the fallback -----------------------------------


def test_a_resolved_layout_is_preferred_over_the_raw_bytes():
    """A real type tree is always better evidence than this module's assumption about the first
    field, so it must win -- the asset's raw bytes here are deliberate garbage."""
    assert scenes_of(_LayoutedAsset(["Assets/Scenes/FromLayout.unity"])) == [
        "Assets/Scenes/FromLayout.unity"
    ]


def test_raw_bytes_are_used_when_there_is_no_layout():
    assert scenes_of(_RawAsset(_REAL_PAYLOAD)) == [
        "Assets/Scenes/Loading.unity",
        "Assets/Scenes/Game.unity",
    ]


def test_none_build_settings_is_none():
    assert scenes_of(None) is None


def test_unreadable_raw_bytes_are_none_not_an_empty_list():
    """`[]` would tell `scene_helpers` the game genuinely has no scenes, which is a different and
    wrong answer -- it must fall back to the generic names instead."""
    assert scenes_of(_RawAsset(b"\xff\xff\xff\xff\x00\x00")) is None


def test_an_asset_with_neither_layout_nor_raw_bytes_is_none():
    class _Nothing:
        pass

    assert scenes_of(_Nothing()) is None


# -- integration with scene_helpers -------------------------------------------------------


class _Collection:
    """The two attributes `try_get_scene_path` reads: a `levelN` file name maps to scene index N."""

    def __init__(self, name: str):
        self.name = name
        self.original_version = UnityVersion(2022, 3, 62)


@pytest.mark.parametrize(
    ("file_name", "expected"),
    [("level0", "Assets/Scenes/Loading"), ("level1", "Assets/Scenes/Game")],
)
def test_scene_helpers_resolves_real_scene_paths_from_raw_bytes(file_name, expected):
    """The user-visible payoff, through the real public entry point: on the fixture these two
    scenes used to come out as `level0`/`level1`."""
    ok, path = scene_helpers.try_get_scene_path(_Collection(file_name), _RawAsset(_REAL_PAYLOAD))

    assert ok is True
    assert path == expected


def test_scene_helpers_declines_when_build_settings_cannot_be_read():
    ok, path = scene_helpers.try_get_scene_path(_Collection("level0"), _RawAsset(b"\x00"))

    assert ok is False
    assert path is None


def test_scene_helpers_still_reports_none_for_unreadable_build_settings():
    assert scene_helpers._scenes(_RawAsset(b"\x00")) is None


def test_is_scene_duplicate_now_works_without_a_type_tree():
    """`is_scene_duplicate` was always correct but could never fire on a release build, because
    `m_Scenes` was unreadable. It can now."""
    duplicated = _RawAsset(_payload(["Assets/A.unity", "Assets/A.unity", "Assets/B.unity"]))

    assert scene_helpers.is_scene_duplicate(0, duplicated) is True
    assert scene_helpers.is_scene_duplicate(1, duplicated) is True
    assert scene_helpers.is_scene_duplicate(2, duplicated) is False

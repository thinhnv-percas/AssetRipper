"""Port of Source/AssetRipper.SourceGenerated.Extensions/SpriteExtensions.cs's
`GetSpriteCoordinatesInAtlas`.

Deliberately isolated as a pure function over plain tuples (no `ISprite`/`ISpriteAtlas`
object, no dynamic field access) rather than folded directly into `sprite_processor.py`:
this is the highest-risk formula in Phase 13 (per ROADMAP.md's own note -- "sai một chút là
sprite lệch âm thầm", wrong by a little and the sprite silently misaligns), and there is no
real Unity SpriteAtlas fixture available to validate against. Keeping it pure means every
branch can be verified against hand-computed reference values from the exact same formula,
independent of whatever the dynamic asset-field plumbing around it turns out to do.

Upstream's own comment: sprite Rect/Pivot/Border/Offset are serialized relative to the
*original* source image; a SpriteAtlas crops and repacks that image, so those values must be
recalculated relative to the atlas's cropped rect. A sprite with no atlas (or one whose atlas
data can't be resolved -- see sprite_processor.py's own docstring for why that lookup isn't
attempted here) is treated as its own single-sprite atlas: `atlas_texture_rect`/
`atlas_texture_rect_offset` are then just the sprite's own current `m_RD.textureRect`/
`textureRectOffset`, which upstream's own code also falls back to in that situation --
this makes the whole function a no-op (returns its own inputs back out) whenever no crop
actually happened, which is the overwhelmingly common case for a sprite that isn't packed.
"""
from __future__ import annotations

import math
from dataclasses import dataclass


def _div(a: float, b: float) -> float:
    """IEEE-754 float division semantics, matching C#'s `a / b`: division by zero produces
    +-Infinity (or NaN for 0/0) instead of raising, unlike Python's native `/` operator.
    **Confirmed necessary against a real fixture** (`python/input-test/demo-android.apk`,
    Phase 13/17 audit): a Sprite whose type tree can't be resolved (`RawDataObject`) reads
    back a zero-size `m_Rect`, which used to raise `ZeroDivisionError` and abort the whole
    export -- upstream would have just produced a NaN/Infinity pivot for that one sprite and
    kept going, so that's what this port does too now."""
    if b != 0.0:
        return a / b
    if a == 0.0:
        return math.nan
    negative = (a < 0) != (math.copysign(1.0, b) < 0)
    return -math.inf if negative else math.inf


@dataclass(frozen=True, slots=True)
class SpriteCoordinatesResult:
    rect: "tuple[float, float, float, float]"
    """(x, y, width, height)."""
    pivot: "tuple[float, float]"
    """(x, y), each a 0-1 fraction of `rect`'s size."""
    border: "tuple[float, float, float, float]"
    """(left, bottom, right, top), in the same units as `rect`."""


def get_sprite_coordinates_in_atlas(
    sprite_rect: "tuple[float, float, float, float]",
    sprite_pivot: "tuple[float, float] | None",
    sprite_offset: "tuple[float, float]",
    sprite_border: "tuple[float, float, float, float] | None",
    atlas_texture_rect: "tuple[float, float, float, float]",
    atlas_texture_rect_offset: "tuple[float, float]",
) -> SpriteCoordinatesResult:
    """
    sprite_rect: the sprite's current `m_Rect` (x, y, width, height) -- relative to the
        original, unpacked source image.
    sprite_pivot: the sprite's current `m_Pivot` if the field exists on this Unity version
        (`Has_Pivot()` upstream), else `None` to derive it from `sprite_offset` instead
        (upstream's own fallback for versions before `m_Pivot` existed).
    sprite_offset: the sprite's current `m_Offset` (x, y) -- always present.
    sprite_border: the sprite's current `m_Border` if the field exists (`Has_Border()`),
        else `None` (no border recalculation; result border is all zero, matching upstream).
    atlas_texture_rect: the cropped rect within the atlas/packed texture -- either the
        resolved `SpriteAtlasData.textureRect`, or (in this port, always, since atlas
        resolution isn't attempted) the sprite's own current `m_RD.textureRect`.
    atlas_texture_rect_offset: the crop offset from the bottom-left of the original image to
        `atlas_texture_rect` -- either `SpriteAtlasData.textureRectOffset` or (here) the
        sprite's own `m_RD.textureRectOffset`.
    """
    sprite_width, sprite_height = sprite_rect[2], sprite_rect[3]
    atlas_width, atlas_height = atlas_texture_rect[2], atlas_texture_rect[3]
    crop_bot_left_x, crop_bot_left_y = atlas_texture_rect_offset

    size_delta_x = sprite_width - atlas_width
    size_delta_y = sprite_height - atlas_height
    crop_top_right_x = size_delta_x - crop_bot_left_x
    crop_top_right_y = size_delta_y - crop_bot_left_y

    if sprite_pivot is not None:
        pivot_x, pivot_y = sprite_pivot
    else:
        center_x, center_y = sprite_width / 2.0, sprite_height / 2.0
        pivot_offset_x = center_x + sprite_offset[0]
        pivot_offset_y = center_y + sprite_offset[1]
        pivot_x = _div(pivot_offset_x, sprite_width)
        pivot_y = _div(pivot_offset_y, sprite_height)

    pivot_position_x = pivot_x * sprite_width
    pivot_position_y = pivot_y * sprite_height
    atlas_pivot_position_x = pivot_position_x - crop_bot_left_x
    atlas_pivot_position_y = pivot_position_y - crop_bot_left_y
    atlas_pivot_x = _div(atlas_pivot_position_x, atlas_width)
    atlas_pivot_y = _div(atlas_pivot_position_y, atlas_height)

    if sprite_border is not None:
        border_l = 0.0 if sprite_border[0] == 0.0 else sprite_border[0] - crop_bot_left_x
        border_b = 0.0 if sprite_border[1] == 0.0 else sprite_border[1] - crop_bot_left_y
        border_r = 0.0 if sprite_border[2] == 0.0 else sprite_border[2] - crop_top_right_x
        border_t = 0.0 if sprite_border[3] == 0.0 else sprite_border[3] - crop_top_right_y
        atlas_border = (border_l, border_b, border_r, border_t)
    else:
        atlas_border = (0.0, 0.0, 0.0, 0.0)

    return SpriteCoordinatesResult(
        rect=(atlas_texture_rect[0], atlas_texture_rect[1], atlas_width, atlas_height),
        pivot=(atlas_pivot_x, atlas_pivot_y),
        border=atlas_border,
    )

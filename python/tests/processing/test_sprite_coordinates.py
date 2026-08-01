"""Phase 13c: `SpriteExtensions.GetSpriteCoordinatesInAtlas` port -- every case here is
computed by hand against the exact same formula as the C# source (see that module's
docstring for why this is kept pure and tested this way instead of round-tripped against a
real fixture, which doesn't exist in this environment).
"""
import math

from assetripper_processing.textures.sprite_coordinates import get_sprite_coordinates_in_atlas


def _assert_close(actual: float, expected: float) -> None:
    assert math.isclose(actual, expected, rel_tol=1e-9, abs_tol=1e-9), f"{actual} != {expected}"


def test_no_crop_with_explicit_pivot_is_an_identity_transform():
    result = get_sprite_coordinates_in_atlas(
        sprite_rect=(0.0, 0.0, 100.0, 50.0),
        sprite_pivot=(0.5, 0.5),
        sprite_offset=(0.0, 0.0),
        sprite_border=None,
        atlas_texture_rect=(0.0, 0.0, 100.0, 50.0),
        atlas_texture_rect_offset=(0.0, 0.0),
    )
    assert result.rect == (0.0, 0.0, 100.0, 50.0)
    assert result.pivot == (0.5, 0.5)
    assert result.border == (0.0, 0.0, 0.0, 0.0)


def test_cropped_atlas_rect_recomputes_pivot_and_border():
    # Hand-computed reference values -- see the test module's docstring for the arithmetic.
    result = get_sprite_coordinates_in_atlas(
        sprite_rect=(0.0, 0.0, 100.0, 80.0),
        sprite_pivot=(0.4, 0.6),
        sprite_offset=(0.0, 0.0),
        sprite_border=(5.0, 0.0, 8.0, 12.0),
        atlas_texture_rect=(10.0, 5.0, 60.0, 50.0),
        atlas_texture_rect_offset=(15.0, 10.0),
    )
    assert result.rect == (10.0, 5.0, 60.0, 50.0)
    _assert_close(result.pivot[0], 25.0 / 60.0)
    _assert_close(result.pivot[1], 38.0 / 50.0)
    _assert_close(result.border[0], -10.0)  # borderL = 5 - 15
    assert result.border[1] == 0.0  # borderB stays 0 -- border.y was already 0
    _assert_close(result.border[2], -17.0)  # borderR = 8 - (sizeDeltaX - cropBotLeftX) = 8 - 25
    _assert_close(result.border[3], -8.0)  # borderT = 12 - (sizeDeltaY - cropBotLeftY) = 12 - 20


def test_missing_pivot_field_is_derived_from_offset_and_rect_center():
    result = get_sprite_coordinates_in_atlas(
        sprite_rect=(0.0, 0.0, 100.0, 80.0),
        sprite_pivot=None,
        sprite_offset=(10.0, -5.0),
        sprite_border=None,
        atlas_texture_rect=(0.0, 0.0, 100.0, 80.0),
        atlas_texture_rect_offset=(0.0, 0.0),
    )
    # center=(50,40), pivotOffset=(60,35), pivot=(0.6, 0.4375) -- no crop so it round-trips.
    _assert_close(result.pivot[0], 0.6)
    _assert_close(result.pivot[1], 0.4375)


def test_missing_border_field_yields_zero_border():
    result = get_sprite_coordinates_in_atlas(
        sprite_rect=(0.0, 0.0, 100.0, 80.0),
        sprite_pivot=(0.5, 0.5),
        sprite_offset=(0.0, 0.0),
        sprite_border=None,
        atlas_texture_rect=(10.0, 5.0, 60.0, 50.0),
        atlas_texture_rect_offset=(15.0, 10.0),
    )
    assert result.border == (0.0, 0.0, 0.0, 0.0)


def test_zero_border_components_stay_zero_instead_of_getting_offset():
    # Every border component upstream special-cases 0.0 to remain exactly 0.0 rather than
    # subtracting the crop offset -- verified for all four sides independently.
    result = get_sprite_coordinates_in_atlas(
        sprite_rect=(0.0, 0.0, 100.0, 80.0),
        sprite_pivot=(0.5, 0.5),
        sprite_offset=(0.0, 0.0),
        sprite_border=(0.0, 0.0, 0.0, 0.0),
        atlas_texture_rect=(10.0, 5.0, 60.0, 50.0),
        atlas_texture_rect_offset=(15.0, 10.0),
    )
    assert result.border == (0.0, 0.0, 0.0, 0.0)

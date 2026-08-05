"""Tests for the Texture2D decode dispatch
(Source/AssetRipper.Export.Modules.Textures/TextureConverter.cs port, scoped to Texture2D).
Pixel values are checked directly against hand-constructed input bytes -- this is exactly
the kind of silent-corruption risk (wrong channel order, wrong bit packing) the module's
docstring flags, so it's worth verifying concretely rather than only checking "it ran".
"""
import struct

from assetripper_export_modules.texture_converter import decode_texture
from assetripper_export_modules.texture_format import TextureFormat


def _pixel_after_unflip(image, x, y):
    """decode_texture flips the image vertically (Unity stores bottom-to-top); undo that
    to check against input data laid out top-to-bottom, as constructed by these tests."""
    return image.getpixel((x, image.height - 1 - y))


def test_rgba32_round_trips_pixel_values():
    data = bytes([10, 20, 30, 255, 40, 50, 60, 128])
    image = decode_texture(data, 2, 1, TextureFormat.RGBA32)
    assert image is not None
    assert _pixel_after_unflip(image, 0, 0) == (10, 20, 30, 255)
    assert _pixel_after_unflip(image, 1, 0) == (40, 50, 60, 128)


def test_argb32_reorders_alpha_to_the_end():
    data = bytes([255, 10, 20, 30])  # A, R, G, B
    image = decode_texture(data, 1, 1, TextureFormat.ARGB32)
    assert _pixel_after_unflip(image, 0, 0) == (10, 20, 30, 255)


def test_bgra32_reorders_channels():
    data = bytes([30, 20, 10, 255])  # B, G, R, A
    image = decode_texture(data, 1, 1, TextureFormat.BGRA32)
    assert _pixel_after_unflip(image, 0, 0) == (10, 20, 30, 255)


def test_rgb565_decodes_pure_red():
    data = struct.pack("<H", 0b11111_000000_00000)
    image = decode_texture(data, 1, 1, TextureFormat.RGB565)
    r, g, b = _pixel_after_unflip(image, 0, 0)
    assert r == 255
    assert g == 0
    assert b == 0


def test_argb4444_decodes_all_channels():
    # A=0xF, R=0x1, G=0x2, B=0x3 packed as a little-endian uint16 (A highest nibble).
    value = (0xF << 12) | (0x1 << 8) | (0x2 << 4) | 0x3
    data = struct.pack("<H", value)
    image = decode_texture(data, 1, 1, TextureFormat.ARGB4444)
    r, g, b, a = _pixel_after_unflip(image, 0, 0)
    assert (r, g, b, a) == (0x1 * 17, 0x2 * 17, 0x3 * 17, 0xF * 17)


def test_alpha8_decodes_as_grayscale():
    image = decode_texture(bytes([200]), 1, 1, TextureFormat.ALPHA8)
    assert _pixel_after_unflip(image, 0, 0) == 200


def test_dxt1_decodes_via_texture2ddecoder():
    # A single 4x4 all-zero BC1 block decodes to opaque black -- just confirms the
    # texture2ddecoder wiring runs and produces the expected image size/shape.
    image = decode_texture(bytes(8), 4, 4, TextureFormat.DXT1)
    assert image is not None
    assert image.size == (4, 4)
    assert _pixel_after_unflip(image, 0, 0) == (0, 0, 0, 255)


def test_crunched_formats_are_unsupported():
    assert decode_texture(bytes(100), 4, 4, TextureFormat.DXT1_CRUNCHED) is None


def test_truncated_data_is_rejected():
    assert decode_texture(bytes(2), 4, 4, TextureFormat.RGBA32) is None


def test_invalid_dimensions_are_rejected():
    assert decode_texture(bytes(16), 0, 4, TextureFormat.RGBA32) is None

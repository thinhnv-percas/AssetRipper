"""Port of the Texture2D slice of Source/AssetRipper.Export.Modules.Textures/TextureConverter.cs

Scoped down to Texture2D only (Cubemap/Texture2DArray/Texture3D/CubemapArray are not
ported) and to the formats listed in texture_format.py -- see that module's docstring.
Crunch-compressed formats are explicitly unsupported, matching the plan's "skip Crunch
(native decoder)" scoping; `decode_texture` returns None for them and for anything else
not in the tables below, rather than guess.

Compressed formats decode through the `texture2ddecoder` PyPI package (the same library
UnityPy uses), which returns raw BGRA8888 bytes -- confirmed empirically in this session
against known-zero test blocks, not from a written spec. Uncompressed formats decode
through Pillow's raw-mode decoder (`Image.frombytes(..., "raw", rawmode)`); the rawmode
strings were verified against hand-constructed byte patterns in this session (see the
phase's test file) rather than assumed from documentation, since Pillow's raw-mode string
grammar is sparsely documented -- e.g. `ARGB4444` has no direct Pillow rawmode and needs a
manual nibble-unpack pass before handing off to Pillow.

Not handled here: mip levels beyond the first (only the first `width*height` pixels' worth
of data is decoded -- any trailing bytes are extra mip levels, ignored) and textures whose
pixel data lives in an external `m_StreamData`-referenced resource file rather than being
embedded in the serialized file itself (deferred, like VideoClip's external resource case
in Phase 6a).
"""
from __future__ import annotations

from PIL import Image

from .texture_format import CRUNCHED_FORMATS, TextureFormat

_RAW_MODE_BY_FORMAT = {
    TextureFormat.ALPHA8: ("L", "L", 1),
    TextureFormat.R8: ("L", "L", 1),
    TextureFormat.RGB24: ("RGB", "RGB", 3),
    TextureFormat.RGBA32: ("RGBA", "RGBA", 4),
    TextureFormat.ARGB32: ("RGBA", "ARGB", 4),
    TextureFormat.BGRA32: ("RGBA", "BGRA", 4),
    TextureFormat.RGB565: ("RGB", "BGR;16", 2),
    TextureFormat.RGBA4444: ("RGBA", "RGBA;4B", 2),
}

_ASTC_BLOCK_SIZE = {
    TextureFormat.ASTC_RGB_4X4: 4,
    TextureFormat.ASTC_RGBA_4X4: 4,
    TextureFormat.ASTC_RGB_5X5: 5,
    TextureFormat.ASTC_RGBA_5X5: 5,
    TextureFormat.ASTC_RGB_6X6: 6,
    TextureFormat.ASTC_RGBA_6X6: 6,
    TextureFormat.ASTC_RGB_8X8: 8,
    TextureFormat.ASTC_RGBA_8X8: 8,
    TextureFormat.ASTC_RGB_10X10: 10,
    TextureFormat.ASTC_RGBA_10X10: 10,
    TextureFormat.ASTC_RGB_12X12: 12,
    TextureFormat.ASTC_RGBA_12X12: 12,
}


def decode_texture(data: bytes, width: int, height: int, texture_format: TextureFormat) -> "Image.Image | None":
    """Returns a top-left-origin RGB/RGBA Pillow Image, or None if the format/data
    couldn't be decoded (unsupported format, crunched format, or truncated data)."""
    if width <= 0 or height <= 0 or not data:
        return None
    if texture_format in CRUNCHED_FORMATS:
        return None

    image = _decode_uncompressed(data, width, height, texture_format)
    if image is None:
        image = _decode_compressed(data, width, height, texture_format)
    if image is None:
        return None

    # Unity stores texture data bottom-to-top.
    return image.transpose(Image.FLIP_TOP_BOTTOM)


def _decode_uncompressed(data: bytes, width: int, height: int, texture_format: TextureFormat) -> "Image.Image | None":
    if texture_format == TextureFormat.ARGB4444:
        return _decode_argb4444(data, width, height)

    entry = _RAW_MODE_BY_FORMAT.get(texture_format)
    if entry is None:
        return None
    mode, rawmode, bytes_per_pixel = entry
    required = width * height * bytes_per_pixel
    if len(data) < required:
        return None
    try:
        return Image.frombytes(mode, (width, height), data[:required], "raw", rawmode)
    except ValueError:
        return None


def _decode_argb4444(data: bytes, width: int, height: int) -> "Image.Image | None":
    required = width * height * 2
    if len(data) < required:
        return None
    out = bytearray(width * height * 4)
    for i in range(width * height):
        value = data[2 * i] | (data[2 * i + 1] << 8)
        a = (value >> 12) & 0xF
        r = (value >> 8) & 0xF
        g = (value >> 4) & 0xF
        b = value & 0xF
        out[4 * i] = r * 17
        out[4 * i + 1] = g * 17
        out[4 * i + 2] = b * 17
        out[4 * i + 3] = a * 17
    return Image.frombytes("RGBA", (width, height), bytes(out), "raw", "RGBA")


def _decode_compressed(data: bytes, width: int, height: int, texture_format: TextureFormat) -> "Image.Image | None":
    import texture2ddecoder as t2d

    try:
        if texture_format == TextureFormat.DXT1:
            decoded = t2d.decode_bc1(data, width, height)
        elif texture_format == TextureFormat.DXT5:
            decoded = t2d.decode_bc3(data, width, height)
        elif texture_format == TextureFormat.BC4:
            decoded = t2d.decode_bc4(data, width, height)
        elif texture_format == TextureFormat.BC5:
            decoded = t2d.decode_bc5(data, width, height)
        elif texture_format == TextureFormat.BC6H:
            decoded = t2d.decode_bc6(data, width, height)
        elif texture_format == TextureFormat.BC7:
            decoded = t2d.decode_bc7(data, width, height)
        elif texture_format == TextureFormat.ETC_RGB4:
            decoded = t2d.decode_etc1(data, width, height)
        elif texture_format == TextureFormat.ETC2_RGB:
            decoded = t2d.decode_etc2(data, width, height)
        elif texture_format == TextureFormat.ETC2_RGBA1:
            decoded = t2d.decode_etc2a1(data, width, height)
        elif texture_format == TextureFormat.ETC2_RGBA8:
            decoded = t2d.decode_etc2a8(data, width, height)
        elif texture_format == TextureFormat.EAC_R:
            decoded = t2d.decode_eacr(data, width, height)
        elif texture_format == TextureFormat.EAC_R_SIGNED:
            decoded = t2d.decode_eacr_signed(data, width, height)
        elif texture_format == TextureFormat.EAC_RG:
            decoded = t2d.decode_eacrg(data, width, height)
        elif texture_format == TextureFormat.EAC_RG_SIGNED:
            decoded = t2d.decode_eacrg_signed(data, width, height)
        elif texture_format == TextureFormat.ATC_RGB4:
            decoded = t2d.decode_atc_rgb4(data, width, height)
        elif texture_format == TextureFormat.ATC_RGBA8:
            decoded = t2d.decode_atc_rgba8(data, width, height)
        elif texture_format in (TextureFormat.PVRTC_RGB2, TextureFormat.PVRTC_RGBA2):
            decoded = t2d.decode_pvrtc(data, width, height, True)
        elif texture_format in (TextureFormat.PVRTC_RGB4, TextureFormat.PVRTC_RGBA4):
            decoded = t2d.decode_pvrtc(data, width, height, False)
        elif texture_format in _ASTC_BLOCK_SIZE:
            block = _ASTC_BLOCK_SIZE[texture_format]
            decoded = t2d.decode_astc(data, width, height, block, block)
        else:
            return None
    except Exception:  # noqa: BLE001 -- a malformed/truncated block shouldn't abort the whole export
        return None

    return Image.frombytes("RGBA", (width, height), decoded, "raw", "BGRA")

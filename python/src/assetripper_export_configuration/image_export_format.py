"""Port of Source/AssetRipper.Export/Configuration/ImageExportFormat.cs

Only Bmp/Jpeg/Png/Tga are wired to an actual encoder (Pillow supports all four natively).
Exr/Hdr fall back to Png -- adding a dependency capable of writing them (e.g. OpenEXR
bindings, imageio) isn't worth it for two rarely-used lossless HDR formats, matching this
project's established policy of declining a feature rather than half-implementing it (see
e.g. Crunch textures, FSB5 rebuild). This is a real fidelity gap, not a silent one: it's
documented here and in texture2d_exporter.py.
"""
from __future__ import annotations

from enum import IntEnum


class ImageExportFormat(IntEnum):
    BMP = 0
    EXR = 1
    HDR = 2
    JPEG = 3
    PNG = 4
    TGA = 5


_PILLOW_FORMAT_AND_EXTENSION = {
    ImageExportFormat.BMP: ("BMP", "bmp"),
    ImageExportFormat.JPEG: ("JPEG", "jpeg"),
    ImageExportFormat.PNG: ("PNG", "png"),
    ImageExportFormat.TGA: ("TGA", "tga"),
}


def get_pillow_format_and_extension(image_export_format: ImageExportFormat) -> "tuple[str, str]":
    """Returns (Pillow format name, file extension) for a format Pillow can actually
    write. Exr/Hdr -- not supported by stock Pillow -- fall back to Png."""
    return _PILLOW_FORMAT_AND_EXTENSION.get(image_export_format, ("PNG", "png"))

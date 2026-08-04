"""The five `.meta` importers this port was missing (2026-08-03), tracked as an open item under
ROADMAP.md Phase 4 since that phase shipped: `TextureImporter`, `AudioImporter`,
`ModelImporter`, `TrueTypeFontImporter`, `VideoClipImporter`.

Until now every asset whose exporter produces a **non-native** file -- a `.png`, an `.ogg`, a
`.glb`, a `.ttf` -- still got a `NativeFormatImporter` block in its `.meta`, because that is the
base `AssetExportCollection._create_importer` default and nothing overrode it. `NativeFormatImporter`
is the importer Unity uses for assets serialized in *Unity's own YAML format*; pointing it at a
PNG names an importer that cannot handle the file. Naming the right importer is the single most
load-bearing thing a `.meta` does, since Unity keys off it to decide how to read the asset at all.

Field sets are deliberately minimal -- see `asset_importer_base.py`'s docstring for the full
reasoning, in short: Unity fills any omitted field with the importer's own default, so a minimal
block with the correct class name is both safe and a strict improvement, whereas inventing
plausible-looking texture/rig/compression settings would be fabricating values this port has no
way to verify.

`serializedVersion` is likewise omitted rather than guessed: it varies by Unity version and by
importer, and a wrong value is worse than an absent one (Unity treats absent as "oldest", which
it knows how to upgrade).
"""
from __future__ import annotations

from .asset_importer_base import AssetImporterBase


class TextureImporter(AssetImporterBase):
    """For `Texture2D`/`Sprite` exported as a real image file (`.png`)."""

    IMPORTER_CLASS_NAME = "TextureImporter"


class AudioImporter(AssetImporterBase):
    """For `AudioClip` exported as `.wav`/`.ogg`/`.fsb` (Phase 20c)."""

    IMPORTER_CLASS_NAME = "AudioImporter"


class ModelImporter(AssetImporterBase):
    """For `Mesh` exported as `.glb`. Unity's ModelImporter is what handles model files."""

    IMPORTER_CLASS_NAME = "ModelImporter"


class TrueTypeFontImporter(AssetImporterBase):
    """For `Font` exported as `.ttf`."""

    IMPORTER_CLASS_NAME = "TrueTypeFontImporter"


class VideoClipImporter(AssetImporterBase):
    """For `VideoClip` (Phase 13a)."""

    IMPORTER_CLASS_NAME = "VideoClipImporter"

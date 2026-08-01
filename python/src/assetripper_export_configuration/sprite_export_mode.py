"""Port of Source/AssetRipper.Export/Configuration/SpriteExportMode.cs

Consumed since Phase 13b (`assetripper_export_modules.registration`): `YAML` (the default,
matching upstream) registers `YamlSpriteExporter`. `NATIVE`/`TEXTURE_2D` have no exporter
ported yet -- no native-image Sprite exporter exists in this port (`texture2d_exporter.py`
only handles Texture2D) -- so those two modes currently fall through to
`DefaultYamlExporter`, which happens to produce the same `.asset` YAML as the `YAML` mode
minus the `SpriteAtlas` skip. See python/ROADMAP.md Phase 13b/13f."""
from __future__ import annotations

from enum import IntEnum


class SpriteExportMode(IntEnum):
    YAML = 0
    NATIVE = 1
    TEXTURE_2D = 2

"""Port of Source/AssetRipper.Export/Configuration/ExportSettings.cs

Not ported: `ScriptExportMode`/`ScriptLanguageVersion`/`ScriptTypesFullyQualified` --
those only matter for real assembly decompilation (ILSpy), which this port doesn't do
(assembly_manager is always None; ScriptExporter always takes the "no assembly manager"
empty-script path regardless of any setting -- see script_exporter.py). Also not ported:
`SaveSettingsToDisk`/`LanguageCode` (tied to upstream's localization and default-settings-
path machinery, out of scope) and `LightmapTextureExportFormat`/`PreferOriginalTextureExtension`
(no lightmap exporter exists yet to apply the former to; the latter is a minor nicety, not
wired up here).
"""
from __future__ import annotations

from dataclasses import dataclass

from .audio_export_format import AudioExportFormat
from .image_export_format import ImageExportFormat
from .shader_export_mode import ShaderExportMode
from .sprite_export_mode import SpriteExportMode
from .text_export_mode import TextExportMode


@dataclass
class ExportSettings:
    audio_export_format: AudioExportFormat = AudioExportFormat.DEFAULT
    image_export_format: ImageExportFormat = ImageExportFormat.PNG
    shader_export_mode: ShaderExportMode = ShaderExportMode.DUMMY
    sprite_export_mode: SpriteExportMode = SpriteExportMode.YAML
    text_export_mode: TextExportMode = TextExportMode.PARSE
    export_unreadable_assets: bool = False

    def to_dict(self) -> dict:
        return {
            "audio_export_format": self.audio_export_format.name,
            "image_export_format": self.image_export_format.name,
            "shader_export_mode": self.shader_export_mode.name,
            "sprite_export_mode": self.sprite_export_mode.name,
            "text_export_mode": self.text_export_mode.name,
            "export_unreadable_assets": self.export_unreadable_assets,
        }

    @staticmethod
    def from_dict(data: dict) -> "ExportSettings":
        defaults = ExportSettings()
        return ExportSettings(
            audio_export_format=AudioExportFormat[data.get("audio_export_format", defaults.audio_export_format.name)],
            image_export_format=ImageExportFormat[data.get("image_export_format", defaults.image_export_format.name)],
            shader_export_mode=ShaderExportMode[data.get("shader_export_mode", defaults.shader_export_mode.name)],
            sprite_export_mode=SpriteExportMode[data.get("sprite_export_mode", defaults.sprite_export_mode.name)],
            text_export_mode=TextExportMode[data.get("text_export_mode", defaults.text_export_mode.name)],
            export_unreadable_assets=data.get("export_unreadable_assets", defaults.export_unreadable_assets),
        )

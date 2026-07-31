"""Port of Source/AssetRipper.Import/Configuration/ImportSettings.cs"""
from __future__ import annotations

from dataclasses import dataclass

from assetripper_primitives import UnityVersion

from .script_content_level import ScriptContentLevel
from .streaming_assets_mode import StreamingAssetsMode


@dataclass
class ImportSettings:
    script_content_level: ScriptContentLevel = ScriptContentLevel.LEVEL_2
    streaming_assets_mode: StreamingAssetsMode = StreamingAssetsMode.EXTRACT
    default_version: "UnityVersion | None" = None
    target_version: "UnityVersion | None" = None

    @property
    def ignore_streaming_assets(self) -> bool:
        return self.streaming_assets_mode == StreamingAssetsMode.IGNORE

    def to_dict(self) -> dict:
        return {
            "script_content_level": self.script_content_level.name,
            "streaming_assets_mode": self.streaming_assets_mode.name,
            "default_version": str(self.default_version) if self.default_version is not None else None,
            "target_version": str(self.target_version) if self.target_version is not None else None,
        }

    @staticmethod
    def from_dict(data: dict) -> "ImportSettings":
        defaults = ImportSettings()
        default_version_text = data.get("default_version")
        target_version_text = data.get("target_version")
        return ImportSettings(
            script_content_level=ScriptContentLevel[data.get("script_content_level", defaults.script_content_level.name)],
            streaming_assets_mode=StreamingAssetsMode[data.get("streaming_assets_mode", defaults.streaming_assets_mode.name)],
            default_version=UnityVersion.parse(default_version_text) if default_version_text else None,
            target_version=UnityVersion.parse(target_version_text) if target_version_text else None,
        )

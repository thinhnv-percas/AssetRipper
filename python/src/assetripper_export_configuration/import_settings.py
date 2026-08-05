"""Port of Source/AssetRipper.Import/Configuration/ImportSettings.cs"""
from __future__ import annotations

from dataclasses import dataclass, field

from assetripper_primitives import UnityVersion

from .script_content_level import ScriptContentLevel
from .streaming_assets_mode import StreamingAssetsMode


@dataclass
class ImportSettings:
    script_content_level: ScriptContentLevel = ScriptContentLevel.LEVEL_2
    streaming_assets_mode: StreamingAssetsMode = StreamingAssetsMode.EXTRACT
    default_version: "UnityVersion | None" = None
    target_version: "UnityVersion | None" = None
    assembly_directories: list[str] = field(default_factory=list)
    """ROADMAP 16c-alt: directories of user-supplied dummy `.dll` files (Il2CppDumper / Cpp2IL /
    DevX-GameRecovery output) to recover script types from, in addition to any assemblies found
    inside the build. No upstream counterpart as a *setting* -- upstream takes assemblies as
    additional input paths instead -- but this port keeps the input-path list meaning strictly
    "game files", so the assembly directories are a setting here. Consumed by
    `GameStructure.__init__`; ignored entirely when `script_content_level` is `LEVEL_0`."""

    @property
    def ignore_streaming_assets(self) -> bool:
        return self.streaming_assets_mode == StreamingAssetsMode.IGNORE

    def to_dict(self) -> dict:
        return {
            "script_content_level": self.script_content_level.name,
            "streaming_assets_mode": self.streaming_assets_mode.name,
            "default_version": str(self.default_version) if self.default_version is not None else None,
            "target_version": str(self.target_version) if self.target_version is not None else None,
            "assembly_directories": list(self.assembly_directories),
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
            assembly_directories=list(data.get("assembly_directories") or []),
        )

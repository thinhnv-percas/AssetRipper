"""Scoped-down port of Source/AssetRipper.Export/Configuration/FullConfiguration.cs

Upstream's `FullConfiguration` extends `CoreConfiguration` and stores each settings record
through `SingletonData`/`JsonDataInstance` (assetripper_configuration's DataStorage
hierarchy), which also handles the "load/save from a fixed OS-specific default path" and
`SerializedSettings` multi-record file upstream's Settings/ConfigurationFiles pages use.
That machinery is built for a unified on-disk settings file shared across several
independent record types; wiring it up fully is unwarranted for the three small dataclasses
this port has. `FullConfiguration` here is just their container, with plain `to_dict`/
`from_dict`/`save`/`load` for JSON round-tripping -- enough for the GUI Settings page to
persist a session's choices, without the generic DataStorage indirection.
"""
from __future__ import annotations

import json
from dataclasses import dataclass, field

from .export_settings import ExportSettings
from .import_settings import ImportSettings
from .processing_settings import ProcessingSettings


@dataclass
class FullConfiguration:
    import_settings: ImportSettings = field(default_factory=ImportSettings)
    export_settings: ExportSettings = field(default_factory=ExportSettings)
    processing_settings: ProcessingSettings = field(default_factory=ProcessingSettings)

    def to_dict(self) -> dict:
        return {
            "import_settings": self.import_settings.to_dict(),
            "export_settings": self.export_settings.to_dict(),
            "processing_settings": self.processing_settings.to_dict(),
        }

    @staticmethod
    def from_dict(data: dict) -> "FullConfiguration":
        return FullConfiguration(
            import_settings=ImportSettings.from_dict(data.get("import_settings", {})),
            export_settings=ExportSettings.from_dict(data.get("export_settings", {})),
            processing_settings=ProcessingSettings.from_dict(data.get("processing_settings", {})),
        )

    def save(self, path: str) -> None:
        with open(path, "w", encoding="utf-8") as f:
            json.dump(self.to_dict(), f, indent=2)

    @staticmethod
    def load(path: str) -> "FullConfiguration":
        with open(path, encoding="utf-8") as f:
            return FullConfiguration.from_dict(json.load(f))

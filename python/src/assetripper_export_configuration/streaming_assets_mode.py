"""Port of Source/AssetRipper.Import/Configuration/StreamingAssetsMode.cs

Wired into StreamingAssetsPostExporter: `Ignore` skips the copy entirely (upstream's own
docstring notes "Including the streaming assets directory can cause some games to fail
while exporting"), matching the check `ExportHandler.cs` does before Phase 7's port of
this post-exporter existed."""
from __future__ import annotations

from enum import IntEnum


class StreamingAssetsMode(IntEnum):
    IGNORE = 0
    EXTRACT = 1

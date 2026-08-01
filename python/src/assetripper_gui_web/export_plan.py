"""
Phase 17b -- builds a preview of "the files a real export would produce", by running the
actual `ExportHandler.export()` into an in-memory `VirtualFileSystem` (Phase 17a) instead of
onto disk.

Why this has to run the real exporter rather than list expected paths some other way:
`IExportCollection.export(container, project_directory, file_system)` (see
`export_unity_projects/i_export_collection.py`) is the *only* method it has -- there's no
`get_export_paths()` or equivalent to ask "what would this write, and under what name" without
actually exporting, since the final file name depends on `file_system.get_unique_name` resolving
collisions against whatever's already been written. So "run it for real, just into RAM" is not
a workaround -- it's the only accurate way to know the answer.

**Must reuse `ExportHandler.export` unmodified, never reimplement its exporter-registration
sequence.** Two independent code paths producing "the same" export is exactly the kind of drift
this whole port has tried to avoid at every phase -- if `build_export_plan` grew its own
`ProjectExporter`/`register_default_exporters`/post-exporter sequence, a future change to real
disk export could silently stop being reflected in the preview.
"""
from __future__ import annotations

from dataclasses import dataclass

from assetripper_export_unity_projects.export_handler import ExportHandler
from assetripper_io_files.virtual_file_system import VirtualFileSystem


@dataclass
class ExportPlan:
    """A completed in-memory export. Deliberately thin: `VirtualFileSystem` already exposes
    everything a browse UI needs (`directory.get_files`/`get_directories`, `file.read_all_bytes`,
    `file.exists`) through the ordinary `FileSystem` interface, so this doesn't duplicate that
    with a separate `path -> node` index -- it just names the two things Phase 17c's routes
    need beyond the raw file system: the version string for the UI banner, and a flat file list
    for the "does this look empty" gap warning (see ROADMAP Phase 17c)."""

    file_system: VirtualFileSystem
    project_version: object

    def all_files(self) -> list[str]:
        return sorted(self.file_system.iter_all_files())


def build_export_plan(game_data, settings=None) -> ExportPlan:
    vfs = VirtualFileSystem()
    ExportHandler().export(game_data, "/", vfs, settings=settings)
    return ExportPlan(file_system=vfs, project_version=game_data.project_version)

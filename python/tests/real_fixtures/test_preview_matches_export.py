"""ROADMAP Phase 17e's deferred item, now closed: preview-vs-export equivalence asserted at the
*GUI route* level, on a real game build.

The invariant: what `/Project/Browse` shows a user (an in-memory `ExportPlan`, built by running
the real export against a `VirtualFileSystem`) must be the same set of files a real
`/Export/UnityProject` writes to disk. If the two ever drifted, the preview would be quietly
lying about what the user is going to get -- the worst failure mode a preview has, because
nothing errors.

Two lower layers already prove the invariant on synthetic games:
`test_virtual_file_system.py::test_export_path_set_matches_local_file_system_export` (17a, VFS
directly) and `test_export_plan.py::test_build_export_plan_matches_a_real_disk_export_of_the_same_game_data`
(17b, through `ExportPlan`). What neither covers is the route layer on top -- `browse()` and
`get_export_plan()` -- plus the plan cache and the disk-source precedence rule that only exist
there. And neither runs on real game data, where the export actually exercises every content
exporter (~4500 files across PNG/mat/ogg/glb/cs/prefab) rather than one hand-built TextAsset.
"""
from __future__ import annotations

import re
import time
from pathlib import Path

import pytest

_APK_PATH = Path(__file__).resolve().parents[2] / "input-test" / "demo-android.apk"
_MIN_REAL_FILE_SIZE = 1_000_000

pytestmark = pytest.mark.skipif(
    not _APK_PATH.exists() or _APK_PATH.stat().st_size < _MIN_REAL_FILE_SIZE,
    reason="real demo-android.apk not present as pulled Git LFS content",
)


@pytest.fixture
def loaded_client():
    """A Flask test client with the real APK loaded through the real `/LoadFolder` route."""
    from assetripper_gui_web import create_app, game_file_loader

    game_file_loader.reset()
    app = create_app()
    app.testing = True
    client = app.test_client()

    client.post("/LoadFolder", data={"Path": str(_APK_PATH)})
    _wait_for(lambda: not game_file_loader.load_progress()["running"], "load")
    assert game_file_loader.has_game_data(), game_file_loader.load_errors()
    try:
        yield client
    finally:
        game_file_loader.reset()


def _wait_for(predicate, what: str, timeout: float = 300.0) -> None:
    deadline = time.monotonic() + timeout
    while not predicate():
        if time.monotonic() > deadline:
            raise AssertionError(f"{what} did not finish within {timeout}s")
        time.sleep(0.05)


def _disk_export(client, output_dir: Path) -> set[str]:
    from assetripper_gui_web import game_file_loader

    client.post("/Export/UnityProject", data={"OutputPath": str(output_dir)})
    _wait_for(lambda: not game_file_loader.export_progress()["running"], "export")
    assert game_file_loader.export_progress()["error"] is None, game_file_loader.export_progress()["error"]
    return {str(p.relative_to(output_dir).as_posix()) for p in output_dir.rglob("*") if p.is_file()}


def _preview_paths() -> set[str]:
    from assetripper_gui_web import game_file_loader

    # `ExportPlan` paths are rooted at "/" (the VFS export root); the disk set is relative.
    return {path.lstrip("/") for path in game_file_loader.get_export_plan().all_files()}


def test_preview_path_set_matches_a_real_disk_export(loaded_client, tmp_path):
    """The load-bearing assertion of the whole preview feature."""
    preview = _preview_paths()
    assert len(preview) > 1000, f"expected a real export's worth of files, got {len(preview)}"

    output_dir = tmp_path / "export"
    on_disk = _disk_export(loaded_client, output_dir)

    assert preview == on_disk


def test_previewed_file_bytes_match_the_exported_file_bytes(loaded_client, tmp_path, monkeypatch):
    """Path parity alone would still allow the preview to show different *contents* -- e.g. if
    the plan were built with different settings than the export used. Samples one file per
    exported type rather than all ~4500, since each comparison reads the file twice.

    `SOURCE_DATE_EPOCH` is pinned because a `.meta`'s `timeCreated` is wall-clock time by
    default (see `meta.py`), so preview and export land on different seconds and every `.meta`
    would differ for a reason that has nothing to do with this invariant. Pinning it means the
    `.meta` comparison actually tests something -- and covers the reproducible-build path at
    the same time."""
    from assetripper_gui_web import game_file_loader

    monkeypatch.setenv("SOURCE_DATE_EPOCH", "1700000000")

    plan = game_file_loader.get_export_plan()
    output_dir = tmp_path / "export"
    _disk_export(loaded_client, output_dir)

    by_extension: dict[str, str] = {}
    for path in sorted(plan.all_files()):
        by_extension.setdefault(Path(path).suffix, path)

    interesting = [".png", ".mat", ".ogg", ".glb", ".cs", ".prefab", ".meta", ".txt", ".asset"]
    checked = 0
    for extension in interesting:
        path = by_extension.get(extension)
        if path is None:
            continue
        previewed = plan.file_system.file.read_all_bytes(path)
        exported = (output_dir / path.lstrip("/")).read_bytes()
        assert _without_guids(previewed) == _without_guids(exported), (
            f"{path} differs between preview and export"
        )
        checked += 1

    assert checked >= 6, f"expected to sample most exported types, only found {checked}"


_GUID_HEX = re.compile(rb"\b[0-9a-f]{32}\b")


def _without_guids(data: bytes) -> bytes:
    """Blanks out 32-hex-digit GUIDs before comparing.

    They are genuinely different between the two runs, and that is *not* preview-vs-export
    drift: an `AssetExportCollection` assigns its GUID with `UnityGuid.new_guid()` in its
    constructor, so every export run mints fresh random GUIDs -- and upstream does exactly the
    same (`AssetExportCollection.cs:78`, `public override UnityGuid GUID { get; } =
    UnityGuid.NewGuid();`). The preview and the disk export are two separate export runs over
    the same `GameData`, so their GUIDs cannot match by construction.

    The consequence is real but upstream's, not this port's: re-exporting the same game
    produces different `.meta` GUIDs, so references in a Unity project opened against an
    earlier export do not survive a re-export. Scripts are the exception -- those use
    `UnityGuid.md5_hash` over namespace+class+assembly and *are* stable.
    """
    return _GUID_HEX.sub(b"<guid>", data)


def test_browse_route_serves_a_previewed_file_before_any_export_happens(loaded_client):
    """The user-visible half: no export step needed for the preview to work. Goes through
    `/Project/File` (the route the preview pane's links point at), not the plan object."""
    from assetripper_gui_web import game_file_loader

    assert not game_file_loader.has_exported_project()

    a_png = next(p for p in sorted(_preview_paths()) if p.endswith(".png"))
    response = loaded_client.get("/Project/File", query_string={"path": a_png})

    assert response.status_code == 200
    assert response.data[:8] == b"\x89PNG\r\n\x1a\n"
    assert response.data == game_file_loader.get_export_plan().file_system.file.read_all_bytes("/" + a_png)


def test_browse_lists_the_same_directory_contents_the_export_wrote(loaded_client, tmp_path):
    """`browse()` renders directory listings from the plan; those are what a user navigates by,
    and a listing that omits a real file is a preview bug the path-set test above cannot see
    (it reads `all_files()` directly, bypassing the per-directory walk)."""
    output_dir = tmp_path / "export"
    _disk_export(loaded_client, output_dir)

    response = loaded_client.get("/Project/Browse", query_string={"path": "ProjectSettings"})

    assert response.status_code == 200
    text = response.data.decode("utf-8")
    for entry in (output_dir / "ProjectSettings").iterdir():
        assert entry.name in text, f"{entry.name} missing from the browse listing"


def test_disk_source_takes_over_once_a_project_is_explicitly_loaded(loaded_client, tmp_path):
    """The precedence rule that only exists at the route layer: after `/Project/Load` points at
    a real directory, `browse()` must read *that* instead of the plan. Asserted by loading a
    directory whose contents deliberately differ from the plan's."""
    from assetripper_gui_web import game_file_loader

    fake_project = tmp_path / "fake"
    (fake_project / "Assets").mkdir(parents=True)
    (fake_project / "Assets" / "not-in-the-plan.txt").write_text("sentinel")

    loaded_client.post("/Project/Load", data={"Path": str(fake_project)})
    assert game_file_loader.has_exported_project()

    response = loaded_client.get("/Project/Browse", query_string={"path": "Assets"})
    assert b"not-in-the-plan.txt" in response.data

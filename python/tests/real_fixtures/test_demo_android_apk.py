"""End-to-end test against a real, shipped Unity game build (Phase 13/17 real-fixture audit).

`python/input-test/demo-android.apk` is a real IL2CPP Android player build, checked in via
Git LFS. This is the first test in the whole project run against genuine game data rather
than a hand-built synthetic fixture -- every other test in this suite constructs its own
TypeTree + bytes by hand (see tests/import_/_tree_builder.py's own docstring on why: no real
Unity fixture was available before this file was added).

Skipped (not failed) whenever the real file isn't present as real binary content, so the rest
of the suite stays runnable without Git LFS configured: the LFS *pointer* text file is only
~130 bytes, so a low size threshold reliably tells a real pull apart from an unpulled pointer.

**Real findings from this fixture, already fixed elsewhere in this session (not re-tested in
detail here, see their own module docstrings/tests):**
- `scene_helpers.py` crashed on BuildSettings when it has no embedded type tree (a real,
  common shape for a release player build) -- fixed, see test_scene_helpers.py.
- `RawDataObject` (`UnknownObject`/`UnreadableObject`) had no `.get`/`.items`/`__contains__`,
  so literally every processor/exporter calling `asset.get(...)` on an asset with an
  unresolved layout crashed -- fixed, see test_raw_data_object.py.
- `sprite_coordinates.py` raised `ZeroDivisionError` for a degenerate (unreadable) Sprite's
  zero-size rect -- fixed, see test_sprite_coordinates.py.

**Phase 18's main gap (2026-08-01):** this build has no embedded type trees anywhere, and this
port originally only had hand-written layouts for 5 classes (GameObject/Transform/
AssetBundle/MonoScript/TextAsset), so Texture2D/Sprite/Material/AudioClip all came through as
content-less `UnknownObject` -- no crash, but no `.png`/`.mat`/`.fsb` file ever got produced.
Texture2D/AudioClip/Sprite/Material now have hand-written layouts too (see
assetripper_import/asset_creation/layouts/{texture2d,audio_clip,sprite,material}.py, each
byte-verified against every sample of that type in *this exact fixture*) --
`test_real_content_is_actually_exported` below asserts the concrete, measurable improvement:
real PNG/mat/fsb files exist in the export output, not just "didn't crash". MonoBehaviour/
Mesh/Shader/BuildSettings remain unmodeled -- see python/ROADMAP.md Phase 18.
"""
from __future__ import annotations

from pathlib import Path

import pytest

from assetripper_export_unity_projects.export_handler import ExportHandler
from assetripper_io_files.local_file_system import LocalFileSystem

_APK_PATH = Path(__file__).resolve().parents[2] / "input-test" / "demo-android.apk"
# The unpulled Git LFS pointer file is ~130 bytes of text; a real pulled APK is tens of MB.
_MIN_REAL_FILE_SIZE = 1_000_000

pytestmark = pytest.mark.skipif(
    not _APK_PATH.exists() or _APK_PATH.stat().st_size < _MIN_REAL_FILE_SIZE,
    reason="real demo-android.apk not present as pulled Git LFS content",
)

FS = LocalFileSystem()


def test_real_android_apk_loads_processes_and_exports_without_crashing(tmp_path):
    handler = ExportHandler()
    game_data = handler.load_and_process([str(_APK_PATH)], FS, settings=None)

    assert game_data.game_bundle.has_any_asset_collections()
    assert str(game_data.project_version)  # a real Unity version was recovered

    handler.export(game_data, str(tmp_path), FS, settings=None)

    all_files = list(tmp_path.rglob("*"))
    assert any(p.is_file() for p in all_files)
    assert (tmp_path / "ProjectSettings" / "ProjectVersion.txt").exists()
    assert list(tmp_path.rglob("*.prefab")), "expected at least one grouped .prefab file"


def test_real_content_is_actually_exported(tmp_path):
    """Phase 18's main gap, closed: before the Texture2D/AudioClip/Sprite/Material
    hand-written layouts existed, this same export produced zero PNG/mat/audio files (every
    one of those classes read back as content-less UnknownObject on this build). Asserts the
    concrete improvement, not just "the pipeline doesn't crash"."""
    from PIL import Image

    handler = ExportHandler()
    game_data = handler.load_and_process([str(_APK_PATH)], FS, settings=None)
    handler.export(game_data, str(tmp_path), FS, settings=None)

    png_files = list(tmp_path.rglob("*.png"))
    mat_files = list(tmp_path.rglob("*.mat"))
    audio_files = list(tmp_path.rglob("*.fsb"))
    assert len(png_files) > 50, f"expected many real textures, got {len(png_files)}"
    assert len(mat_files) > 20, f"expected many real materials, got {len(mat_files)}"
    assert len(audio_files) > 5, f"expected several real audio clips, got {len(audio_files)}"

    # Spot-check one PNG actually decodes as a real image, not a stub/placeholder.
    image = Image.open(png_files[0])
    assert image.size[0] > 0 and image.size[1] > 0

    mat_text = mat_files[0].read_text(encoding="utf-8")
    assert "m_Shader:" in mat_text
    assert "m_SavedProperties:" in mat_text


def test_real_android_apk_split_asset_files_are_reassembled(tmp_path):
    """`sharedassets0.assets`/`sharedassets1.assets` in this APK are physically split into
    `.split0`..`.splitN` pieces (Android's historical >1MB ZIP-entry-compression limit) --
    confirms `MultiFileStream` (already ported) is actually wired into real Android loading,
    not just unit-tested in isolation."""
    handler = ExportHandler()
    game_data = handler.load_and_process([str(_APK_PATH)], FS, settings=None)

    collection_names = {c.name for c in game_data.game_bundle.fetch_asset_collections()}
    assert "sharedassets0.assets" in collection_names
    assert "sharedassets1.assets" in collection_names

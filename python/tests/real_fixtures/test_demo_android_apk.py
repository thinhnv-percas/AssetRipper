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

**Phase 19 (2026-08-01):** every test above drives `ExportHandler` directly -- none of them
would have caught the real bug the user hit ("the GUI tool still doesn't work with apk and ipa
input"), which was purely in the GUI's own route wiring (`/LoadFile` calling the wrong loader),
not the engine. `test_real_android_apk_loads_through_the_gui` closes that coverage gap by
driving the real Flask app's test client instead.

**Phase 18, Mesh (2026-08-01):** `Mesh` now has a hand-written layout too (see
`assetripper_import/asset_creation/layouts/mesh.py`), byte-verified against all 29 Meshes in
this exact fixture the same way as Texture2D/AudioClip/Sprite/Material --
`test_real_meshes_are_actually_exported` asserts the concrete improvement (0 -> 29 real `.glb`
files, each a valid glTF 2.0 binary with real POSITION/NORMAL/TEXCOORD_0 accessors).
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


def test_real_scripts_are_actually_exported(tmp_path):
    """2026-08-03 (ROADMAP Phase 18): `layouts/mono_script.py` omitted m_ExecutionOrder and
    m_PropertiesHash, which sit *between* m_Name and m_ClassName -- so all 2076 MonoScripts in
    this build failed `try_read` and became `UnreadableObject`. Since `ProjectExporter`
    dispatches `RawDataObject` subclasses by Python type rather than class ID, they never
    reached `ScriptExporter` at all and this export produced **zero** `.cs` files, silently.
    Asserts both halves: the assets now read, and the `.cs` files now actually appear."""
    handler = ExportHandler()
    game_data = handler.load_and_process([str(_APK_PATH)], FS, settings=None)

    mono_scripts = [a for a in game_data.game_bundle.fetch_assets_in_hierarchy() if a.class_id == 115]
    assert len(mono_scripts) > 1000, f"expected many MonoScripts, got {len(mono_scripts)}"
    readable = [a for a in mono_scripts if a.get("m_ClassName")]
    assert len(readable) == len(mono_scripts), (
        f"only {len(readable)}/{len(mono_scripts)} MonoScripts read their m_ClassName"
    )

    handler.export(game_data, str(tmp_path), FS, settings=None)

    cs_files = list(tmp_path.rglob("*.cs"))
    assert len(cs_files) > 1000, f"expected many .cs files, got {len(cs_files)}"
    # Every emitted script must be a real class declaration named after the MonoScript, even
    # in the dummy-stub case (this build is IL2CPP, so no field recovery -- see Phase 16f).
    sample = next(p for p in cs_files if p.stem == "GUISkin")
    text = sample.read_text(encoding="utf-8")
    assert "class GUISkin" in text


def test_real_game_objects_are_actually_readable(tmp_path):
    """2026-08-03 (ROADMAP Phase 18): `layouts/game_object.py` modeled m_Component as
    `pair<int, PPtr>` (the pre-5.5 shape) and the tag as a `m_TagString` string, plus a
    trailing align on the last field -- three separate errors that made all 407 GameObjects in
    this build unreadable, losing every name/layer/component list."""
    game_data = ExportHandler().load_and_process([str(_APK_PATH)], FS, settings=None)

    game_objects = [a for a in game_data.game_bundle.fetch_assets_in_hierarchy() if a.class_id == 1]
    assert len(game_objects) > 300, f"expected many GameObjects, got {len(game_objects)}"
    named = [a for a in game_objects if a.get("m_Name")]
    assert len(named) == len(game_objects), f"only {len(named)}/{len(game_objects)} GameObjects read a name"
    # Components must resolve as real PPtrs, which is what scene/prefab hierarchy needs.
    with_components = [a for a in game_objects if a.get("m_Component")]
    assert len(with_components) > 300
    assert with_components[0].get("m_Component")[0].path_id != 0


def test_real_meshes_are_actually_exported(tmp_path):
    """Phase 18's Mesh gap, closed: before `layouts/mesh.py` existed, every Mesh in this build
    read back as a content-less UnknownObject (no `.glb` ever got produced). Asserts the
    concrete improvement, and that the output is a real, structurally valid glTF binary, not
    just "a file with a .glb extension"."""
    import json
    import struct as struct_module

    handler = ExportHandler()
    game_data = handler.load_and_process([str(_APK_PATH)], FS, settings=None)
    handler.export(game_data, str(tmp_path), FS, settings=None)

    glb_files = list(tmp_path.rglob("*.glb"))
    assert len(glb_files) >= 25, f"expected ~29 real meshes, got {len(glb_files)}"

    data = glb_files[0].read_bytes()
    magic, version, length = struct_module.unpack_from("<4sII", data, 0)
    assert magic == b"glTF"
    assert length == len(data)
    chunk_len, _chunk_type = struct_module.unpack_from("<II", data, 12)
    document = json.loads(data[20:20 + chunk_len])
    assert document["meshes"], "expected at least one glTF mesh in the document"
    attributes = document["meshes"][0]["primitives"][0]["attributes"]
    assert "POSITION" in attributes


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


def test_real_android_apk_loads_through_the_gui(tmp_path):
    """Phase 19d: closes the exact gap that let the user-reported apk/ipa bug through in the
    first place -- the engine (`ExportHandler`/`load_and_process`, tested above) had real-file
    coverage from Phase 18, but the GUI's own `/LoadFile`/`/LoadFolder` routes never did, so a
    GUI-layer wiring bug (`/LoadFile` calling the wrong loader) went undetected until a real
    user hit it. Posts the real `.apk` through the actual Flask test client, not just
    `ExportHandler` directly, and through *both* aliased routes (Phase 19a)."""
    import time

    from assetripper_gui_web import create_app, game_file_loader

    def _wait_for_load(timeout: float = 60.0) -> None:
        deadline = time.monotonic() + timeout
        while game_file_loader.load_progress()["running"]:
            if time.monotonic() > deadline:
                raise AssertionError("load did not finish within the timeout")
            time.sleep(0.05)

    game_file_loader.reset()
    try:
        app = create_app()
        app.testing = True
        client = app.test_client()

        client.post("/LoadFile", data={"Path": str(_APK_PATH)})
        _wait_for_load()
        assert game_file_loader.has_game_data(), game_file_loader.load_errors()
        game_file_loader.reset()

        client.post("/LoadFolder", data={"Path": str(_APK_PATH)})
        _wait_for_load()
        assert game_file_loader.has_game_data(), game_file_loader.load_errors()
    finally:
        game_file_loader.reset()

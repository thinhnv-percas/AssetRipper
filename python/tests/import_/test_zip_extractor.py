"""Tests for the stdlib-zipfile-based port of
Source/AssetRipper.Import/Structure/ZipExtractor.cs (Phase 3 of the port)."""
import io
import zipfile

from assetripper_import.structure import zip_extractor
from assetripper_io_files.local_file_system import LocalFileSystem

FS = LocalFileSystem()


def _make_zip(entries: dict[str, bytes]) -> bytes:
    buffer = io.BytesIO()
    with zipfile.ZipFile(buffer, "w") as archive:
        for name, data in entries.items():
            archive.writestr(name, data)
    return buffer.getvalue()


def test_process_extracts_zip_extension(tmp_path):
    zip_path = tmp_path / "game.zip"
    zip_path.write_bytes(_make_zip({"level0": b"hello", "nested/sharedassets0.assets": b"world"}))

    result = zip_extractor.process([str(zip_path)], FS)

    assert len(result) == 1
    output_dir = result[0]
    assert FS.file.exists(FS.path.join(output_dir, "level0"))
    with open(FS.path.join(output_dir, "level0"), "rb") as f:
        assert f.read() == b"hello"
    with open(FS.path.join(output_dir, "nested", "sharedassets0.assets"), "rb") as f:
        assert f.read() == b"world"


def test_process_extracts_apk_extension(tmp_path):
    apk_path = tmp_path / "game.apk"
    apk_path.write_bytes(_make_zip({"assets/bin/Data/globalgamemanagers": b"data"}))

    result = zip_extractor.process([str(apk_path)], FS)

    output_dir = result[0]
    with open(FS.path.join(output_dir, "assets", "bin", "Data", "globalgamemanagers"), "rb") as f:
        assert f.read() == b"data"


def test_process_extracts_xapk_nested_apk(tmp_path):
    inner_apk = _make_zip({"assets/bin/Data/globalgamemanagers": b"inner-data"})
    outer = _make_zip({"base.apk": inner_apk})
    xapk_path = tmp_path / "game.xapk"
    xapk_path.write_bytes(outer)

    result = zip_extractor.process([str(xapk_path)], FS)

    output_dir = result[0]
    with open(FS.path.join(output_dir, "assets", "bin", "Data", "globalgamemanagers"), "rb") as f:
        assert f.read() == b"inner-data"


def test_process_passes_through_non_archive_paths(tmp_path):
    plain_path = tmp_path / "globalgamemanagers"
    plain_path.write_bytes(b"not a zip")

    result = zip_extractor.process([str(plain_path)], FS)

    assert result == [str(plain_path)]


def test_process_passes_through_zip_extension_with_bad_magic(tmp_path):
    fake_zip_path = tmp_path / "fake.zip"
    fake_zip_path.write_bytes(b"not actually a zip file")

    result = zip_extractor.process([str(fake_zip_path)], FS)

    assert result == [str(fake_zip_path)]


def test_created_directories_tracks_the_extracted_temp_directory(tmp_path):
    """2026-08-03 fix: previously nothing tracked create_temporary() calls at all, so
    extracted archives leaked forever -- see GameStructure/ExportHandler/game_file_loader."""
    zip_path = tmp_path / "game.zip"
    zip_path.write_bytes(_make_zip({"level0": b"hello"}))

    created: list[str] = []
    result = zip_extractor.process([str(zip_path)], FS, created)

    assert created == result
    assert FS.directory.exists(created[0])


def test_created_directories_tracks_the_xapk_intermediate_directory(tmp_path):
    """The xapk path also creates an intermediate directory that never appears in process()'s
    return value at all -- it must still be tracked for cleanup or it leaks unconditionally."""
    inner_apk = _make_zip({"assets/bin/Data/globalgamemanagers": b"inner-data"})
    outer = _make_zip({"base.apk": inner_apk})
    xapk_path = tmp_path / "game.xapk"
    xapk_path.write_bytes(outer)

    created: list[str] = []
    result = zip_extractor.process([str(xapk_path)], FS, created)

    assert len(created) == 2  # intermediate + final output directory
    assert result[0] in created
    assert all(FS.directory.exists(d) for d in created)


def test_passthrough_paths_are_not_tracked_for_cleanup(tmp_path):
    plain_path = tmp_path / "globalgamemanagers"
    plain_path.write_bytes(b"not a zip")

    created: list[str] = []
    zip_extractor.process([str(plain_path)], FS, created)

    assert created == []


def test_cleanup_removes_every_tracked_directory(tmp_path):
    zip_path = tmp_path / "game.zip"
    zip_path.write_bytes(_make_zip({"level0": b"hello"}))
    created: list[str] = []
    zip_extractor.process([str(zip_path)], FS, created)
    assert FS.directory.exists(created[0])

    zip_extractor.cleanup(created, FS)

    assert not FS.directory.exists(created[0])


def test_cleanup_silently_ignores_a_directory_that_no_longer_exists(tmp_path):
    zip_extractor.cleanup([str(tmp_path / "does-not-exist")], FS)  # must not raise

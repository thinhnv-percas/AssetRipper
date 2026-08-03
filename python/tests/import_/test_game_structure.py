"""Tests for the top-level Load() orchestrator
(Source/AssetRipper.Import/Structure/GameStructure.cs), Phase 3 of the port."""
import pytest

from assetripper_import.structure.game_structure import GameStructure
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.streams.smart import SmartStream
from assetripper_primitives import UnityVersion

FS = LocalFileSystem()


def _write_serialized_file(path, *, version=UnityVersion(2019, 4, 0)) -> None:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=version,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=False,
    )
    file = builder.build()
    stream = SmartStream.create_memory()
    file.write(stream)
    stream.flush()
    path.write_bytes(stream.to_array())


def test_load_a_windows_game_directory(tmp_path):
    (tmp_path / "MyGame_Data").mkdir()
    (tmp_path / "MyGame.exe").write_bytes(b"")
    _write_serialized_file(tmp_path / "MyGame_Data" / "globalgamemanagers")

    game_structure = GameStructure.load([str(tmp_path)], FS)

    assert game_structure.name == "MyGame"
    assert game_structure.is_valid
    assert game_structure.assembly_manager is None
    collections = list(game_structure.file_collection.fetch_asset_collections())
    assert len(collections) == 1
    assert collections[0].name == "globalgamemanagers"


def test_load_raises_when_no_files_found():
    with pytest.raises(ValueError):
        GameStructure.load([], FS)


def test_load_builds_a_mono_assembly_manager_when_managed_dll_files_are_present(tmp_path):
    """Phase 16f part 2: GameStructure discovers .dll files under Managed/ and builds a real
    MonoAssemblyManager from them, instead of leaving assembly_manager at None."""
    from assetripper_import.structure.assembly.managers.mono_assembly_manager import MonoAssemblyManager

    (tmp_path / "MyGame_Data" / "Managed").mkdir(parents=True)
    (tmp_path / "MyGame.exe").write_bytes(b"")
    (tmp_path / "MyGame_Data" / "Managed" / "Assembly-CSharp.dll").write_bytes(b"not a real dll -- just needs to exist")
    _write_serialized_file(tmp_path / "MyGame_Data" / "globalgamemanagers")

    game_structure = GameStructure.load([str(tmp_path)], FS)

    assert isinstance(game_structure.assembly_manager, MonoAssemblyManager)
    assert "Assembly-CSharp.dll" in game_structure.assembly_manager.get_assembly_file_paths()


def test_script_content_level_zero_disables_the_assembly_manager(tmp_path):
    """ROADMAP.md Phase 16f: ScriptContentLevel.LEVEL_0 means "don't load scripts at all",
    even when .dll files were actually found."""
    (tmp_path / "MyGame_Data" / "Managed").mkdir(parents=True)
    (tmp_path / "MyGame.exe").write_bytes(b"")
    (tmp_path / "MyGame_Data" / "Managed" / "Assembly-CSharp.dll").write_bytes(b"not a real dll -- just needs to exist")
    _write_serialized_file(tmp_path / "MyGame_Data" / "globalgamemanagers")

    game_structure = GameStructure.load([str(tmp_path)], FS, script_content_level=0)

    assert game_structure.assembly_manager is None


def test_load_falls_back_to_mixed_structure_for_unrecognized_directory(tmp_path):
    _write_serialized_file(tmp_path / "sharedassets0.assets")

    game_structure = GameStructure.load([str(tmp_path)], FS)

    assert game_structure.platform_structure is None
    assert game_structure.mixed_structure is not None
    assert game_structure.is_valid

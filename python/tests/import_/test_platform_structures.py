"""Tests for the ported Platforms/ game structure detectors
(Source/AssetRipper.Import/Platforms/*.cs) and PlatformChecker, Phase 3 of the port.

Real directories under tmp_path are used via LocalFileSystem rather than a virtual
filesystem double -- every platform's `exists()`/constructor only touch a handful of
paths and file-existence checks, so building the real layout on disk is simplest.
"""
from assetripper_import.platforms.android_game_structure import AndroidGameStructure
from assetripper_import.platforms.ios_game_structure import iOSGameStructure
from assetripper_import.platforms.linux_game_structure import LinuxGameStructure
from assetripper_import.platforms.mac_game_structure import MacGameStructure
from assetripper_import.platforms.mixed_game_structure import MixedGameStructure
from assetripper_import.platforms.platform_checker import check_platform
from assetripper_import.platforms.ps4_game_structure import PS4GameStructure
from assetripper_import.platforms.switch_game_structure import SwitchGameStructure
from assetripper_import.platforms.webgl_game_structure import WebGLGameStructure
from assetripper_import.platforms.webplayer_game_structure import WebPlayerGameStructure
from assetripper_import.platforms.wiiu_game_structure import WiiUGameStructure
from assetripper_import.platforms.windows_game_structure import WindowsGameStructure
from assetripper_import.platforms.windows_phone_game_structure import WindowsPhoneGameStructure
from assetripper_import.structure.assembly.scripting_backend import ScriptingBackend
from assetripper_io_files.local_file_system import LocalFileSystem

FS = LocalFileSystem()


def test_windows_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "MyGame_Data").mkdir()
    (tmp_path / "MyGame.exe").write_bytes(b"")

    assert WindowsGameStructure.exists(str(tmp_path), FS)
    structure = WindowsGameStructure(str(tmp_path), FS)
    assert structure.name == "MyGame"
    assert structure.backend == ScriptingBackend.UNKNOWN
    assert structure.version is None


def test_windows_game_structure_does_not_exist_without_data_folder(tmp_path):
    (tmp_path / "MyGame.exe").write_bytes(b"")
    assert not WindowsGameStructure.exists(str(tmp_path), FS)


def test_linux_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "MyGame_Data").mkdir()
    (tmp_path / "MyGame.x86_64").write_bytes(b"")

    assert LinuxGameStructure.exists(str(tmp_path), FS)
    structure = LinuxGameStructure(str(tmp_path), FS)
    assert structure.name == "MyGame"


def test_mac_game_structure_exists_and_constructs(tmp_path):
    app_path = tmp_path / "MyGame.app"
    (app_path / "Contents" / "Resources" / "Data").mkdir(parents=True)

    assert MacGameStructure.exists(str(app_path), FS)
    structure = MacGameStructure(str(app_path), FS)
    assert structure.name == "MyGame"


def test_android_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "assets" / "bin" / "Data").mkdir(parents=True)
    (tmp_path / "META-INF").mkdir()

    assert AndroidGameStructure.is_android_structure(str(tmp_path), FS)
    structure = AndroidGameStructure(str(tmp_path), None, FS)
    assert structure.backend == ScriptingBackend.UNKNOWN


def test_ios_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "Payload" / "MyGame.app" / "Data").mkdir(parents=True)

    assert iOSGameStructure.exists(str(tmp_path), FS)
    structure = iOSGameStructure(str(tmp_path), FS)
    assert structure.name == "MyGame"


def test_ps4_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "eboot.bin").write_bytes(b"")
    (tmp_path / "Media").mkdir()

    assert PS4GameStructure.exists(str(tmp_path), FS)
    structure = PS4GameStructure(str(tmp_path), FS)
    assert structure.name == tmp_path.name


def test_switch_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "exefs").mkdir()
    (tmp_path / "romfs" / "Data").mkdir(parents=True)

    assert SwitchGameStructure.exists(str(tmp_path), FS)
    structure = SwitchGameStructure(str(tmp_path), FS)
    assert structure.backend == ScriptingBackend.UNKNOWN


def test_wiiu_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "content" / "Data").mkdir(parents=True)

    assert WiiUGameStructure.exists(str(tmp_path), FS)
    structure = WiiUGameStructure(str(tmp_path), FS)
    assert structure.game_data_path == str(tmp_path / "content" / "Data")


def test_windows_phone_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "Assets").mkdir()
    (tmp_path / "Data").mkdir()
    (tmp_path / "MyGame.exe").write_bytes(b"")

    assert WindowsPhoneGameStructure.exists(str(tmp_path), FS)
    structure = WindowsPhoneGameStructure(str(tmp_path), FS)
    assert structure.name == "MyGame"


def test_webgl_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "index.html").write_bytes(b"")
    build_dir = tmp_path / "Build"
    build_dir.mkdir()
    (build_dir / "MyGame.data.unityweb").write_bytes(b"")

    assert WebGLGameStructure.exists(str(tmp_path), FS)
    structure = WebGLGameStructure(str(tmp_path), FS)
    assert structure.name == tmp_path.name
    assert structure.files[0][0] == "MyGame"


def test_webplayer_game_structure_exists_and_constructs(tmp_path):
    (tmp_path / "MyGame.html").write_bytes(b"")
    (tmp_path / "MyGame.unity3d").write_bytes(b"")

    assert WebPlayerGameStructure.exists(str(tmp_path), FS)
    structure = WebPlayerGameStructure(str(tmp_path), FS)
    assert structure.name == "MyGame"


def test_mixed_game_structure_recurses_into_directories(tmp_path):
    sub_dir = tmp_path / "nested"
    sub_dir.mkdir()

    structure = MixedGameStructure([str(tmp_path)], FS)
    assert structure.name == ""
    assert structure.backend == ScriptingBackend.UNKNOWN


def test_platform_checker_picks_windows_structure(tmp_path):
    (tmp_path / "MyGame_Data").mkdir()
    (tmp_path / "MyGame.exe").write_bytes(b"")

    paths = [str(tmp_path)]
    platform_structure, mixed_structure = check_platform(paths, FS)

    assert isinstance(platform_structure, WindowsGameStructure)
    assert mixed_structure is None
    assert paths == []


def test_platform_checker_falls_back_to_mixed(tmp_path):
    other_dir = tmp_path / "unrecognized"
    other_dir.mkdir()

    paths = [str(other_dir)]
    platform_structure, mixed_structure = check_platform(paths, FS)

    assert platform_structure is None
    assert isinstance(mixed_structure, MixedGameStructure)
    assert paths == []

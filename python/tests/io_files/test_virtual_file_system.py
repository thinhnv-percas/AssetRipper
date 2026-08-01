"""Tests for `VirtualFileSystem` (Phase 17a) -- Source/AssetRipper.IO.Files/VirtualFileSystem.cs.

The most important test here is `test_export_path_set_matches_local_file_system_export`: Phase
17's whole premise is that a `VirtualFileSystem` export is a trustworthy stand-in for a real
disk export, so if it ever diverges from `LocalFileSystem` on which paths get written (e.g. a
`get_unique_name` collision resolving differently), the GUI preview would silently lie. Every
other test here is a more ordinary unit check of the tree operations themselves.
"""
import pytest

from assetripper_export_unity_projects.export_handler import ExportHandler
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.streams.stream import MemoryStream, SeekOrigin
from assetripper_io_files.virtual_file_system import VirtualFileSystem
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, string_nodes, tree, unity_string


def test_write_all_bytes_then_read_all_bytes_round_trips():
    vfs = VirtualFileSystem()
    vfs.directory.create("/Assets/Textures")
    vfs.file.write_all_bytes("/Assets/Textures/foo.png", b"\x89PNG\r\n")

    assert vfs.file.exists("/Assets/Textures/foo.png")
    assert vfs.file.read_all_bytes("/Assets/Textures/foo.png") == b"\x89PNG\r\n"


def test_create_stream_write_is_visible_through_open_read():
    vfs = VirtualFileSystem()
    vfs.directory.create("/Assets")
    with vfs.file.create("/Assets/a.txt") as stream:
        stream.write(b"hello world")

    with vfs.file.open_read("/Assets/a.txt") as stream:
        stream.seek(0, SeekOrigin.BEGIN)
        buffer = bytearray(11)
        stream.read_exactly(buffer)
        assert bytes(buffer) == b"hello world"


def test_open_write_creates_file_if_missing_like_local_file_system():
    vfs = VirtualFileSystem()
    vfs.directory.create("/Assets")
    with vfs.file.open_write("/Assets/new.txt") as stream:
        stream.write(b"abc")

    assert vfs.file.read_all_bytes("/Assets/new.txt") == b"abc"


def test_directory_create_makes_nested_directories_implicitly():
    vfs = VirtualFileSystem()
    vfs.directory.create("/Assets/Prefabs/Deep")

    assert vfs.directory.exists("/Assets")
    assert vfs.directory.exists("/Assets/Prefabs")
    assert vfs.directory.exists("/Assets/Prefabs/Deep")
    assert not vfs.directory.exists("/Assets/DoesNotExist")


def test_file_create_requires_parent_directory_like_local_file_system():
    vfs = VirtualFileSystem()
    with pytest.raises(NotADirectoryError):
        vfs.file.create("/Assets/foo.txt")


def test_enumerate_files_and_directories():
    vfs = VirtualFileSystem()
    vfs.directory.create("/Assets/Sub")
    vfs.file.write_all_bytes("/Assets/a.png", b"1")
    vfs.file.write_all_bytes("/Assets/b.mat", b"2")

    files = sorted(vfs.directory.get_files("/Assets"))
    assert files == ["/Assets/a.png", "/Assets/b.mat"]

    directories = vfs.directory.get_directories("/Assets")
    assert directories == ["/Assets/Sub"]

    png_only = vfs.directory.get_files("/Assets", "*.png")
    assert png_only == ["/Assets/a.png"]


def test_enumerate_on_missing_directory_returns_empty_not_raise():
    vfs = VirtualFileSystem()
    assert vfs.directory.get_files("/NoSuchDir") == []
    assert vfs.directory.get_directories("/NoSuchDir") == []


def test_get_unique_name_resolves_collision_in_virtual_file_system():
    vfs = VirtualFileSystem()
    vfs.directory.create("/Assets")
    vfs.file.write_all_bytes("/Assets/MyText.txt", b"first")

    unique = vfs.get_unique_name("/Assets", "MyText.txt", 245)
    assert unique == "MyText_0.txt"

    vfs.file.write_all_bytes(vfs.path.join("/Assets", unique), b"second")
    unique2 = vfs.get_unique_name("/Assets", "MyText.txt", 245)
    assert unique2 == "MyText_1.txt"


def test_get_unique_name_matches_when_directory_does_not_exist_yet():
    vfs = VirtualFileSystem()
    # No file/directory conflict at all -> name passes through unchanged, same as LocalFileSystem.
    assert vfs.get_unique_name("/Assets", "MyText.txt", 245) == "MyText.txt"


def test_directory_delete_is_unsupported():
    vfs = VirtualFileSystem()
    vfs.directory.create("/Assets")
    with pytest.raises(NotImplementedError):
        vfs.directory.delete("/Assets")


def test_file_delete_removes_file():
    vfs = VirtualFileSystem()
    vfs.directory.create("/Assets")
    vfs.file.write_all_bytes("/Assets/a.txt", b"x")
    vfs.file.delete("/Assets/a.txt")
    assert not vfs.file.exists("/Assets/a.txt")


def test_path_join_and_full_path_normalize_to_rooted_virtual_paths():
    vfs = VirtualFileSystem()
    assert vfs.path.join("Assets", "Textures", "a.png") == "/Assets/Textures/a.png"
    assert vfs.path.get_full_path("Assets/a.png") == "/Assets/a.png"
    assert vfs.path.get_full_path("/Assets/a.png/") == "/Assets/a.png"
    assert vfs.path.is_path_rooted("/Assets/a.png")
    assert not vfs.path.is_path_rooted("Assets/a.png")


# --- The equivalence test: the core promise of Phase 17 ------------------------------------

_TEXT_ASSET_TREE = tree(
    node("TextAsset", "Base", 0),
    *string_nodes("m_Name", 1),
    *string_nodes("m_Script", 1),
)


def _write_synthetic_game(directory) -> None:
    """Same fixture shape as tests/export_unity_projects/test_export_handler.py: one
    TextAsset, real enough to exercise ExportHandler's full load->process->export pipeline
    and produce more than one output file (asset + .meta + ProjectSettings + manifest)."""
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = 49
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _TEXT_ASSET_TREE
    type_.old_type.build_string_buffer()

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = unity_string("MyText") + unity_string("hello world")

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()

    stream = MemoryStream()
    serialized_file.write(stream)
    (directory / "sharedassets0.assets").write_bytes(stream.to_array())


def test_export_path_set_matches_local_file_system_export(tmp_path):
    game_dir = tmp_path / "game"
    game_dir.mkdir()
    _write_synthetic_game(game_dir)

    local_fs = LocalFileSystem()
    output_dir = tmp_path / "output"
    handler = ExportHandler()
    handler.load_process_and_export([str(game_dir)], str(output_dir), local_fs)
    local_relative_paths = sorted(
        str(p.relative_to(output_dir)).replace("\\", "/") for p in output_dir.rglob("*") if p.is_file()
    )
    assert local_relative_paths, "expected the synthetic game to actually export some files"

    # Reading the input is always a real disk read (the game data genuinely lives on disk --
    # for a real apk/ipa there is no alternative); only the *export* side writes into the VFS.
    # This mirrors exactly how Phase 17b's ExportPlan will use `VirtualFileSystem`.
    vfs = VirtualFileSystem()
    handler2 = ExportHandler()
    game_data2 = handler2.load_and_process([str(game_dir)], local_fs)
    handler2.export(game_data2, "/", vfs)
    virtual_relative_paths = sorted(path.lstrip("/") for path in vfs.iter_all_files())

    assert virtual_relative_paths == local_relative_paths

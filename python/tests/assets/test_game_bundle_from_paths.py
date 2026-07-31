"""Tests for GameBundle.from_paths / SerializedBundle.from_file_container
(Source/AssetRipper.Assets/Bundles/GameBundle.FromPaths.cs, SerializedBundle.cs), ported
as part of Phase 3 (game structure discovery)."""
from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.streams.smart import SmartStream
from assetripper_primitives import UnityVersion


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


def test_from_paths_reads_a_single_serialized_file(tmp_path):
    path = tmp_path / "globalgamemanagers"
    _write_serialized_file(path)

    file_system = LocalFileSystem()
    game_bundle = GameBundle.from_paths([str(path)], GameAssetFactory(), file_system)

    assert game_bundle.has_any_asset_collections()
    collections = list(game_bundle.fetch_asset_collections())
    assert len(collections) == 1
    assert collections[0].name == "globalgamemanagers"
    assert collections[0].version == UnityVersion(2019, 4, 0)


def test_from_paths_reads_a_resource_file_as_is(tmp_path):
    path = tmp_path / "sharedassets0.resource"
    path.write_bytes(b"not a serialized file, just bytes")

    file_system = LocalFileSystem()
    game_bundle = GameBundle.from_paths([str(path)], GameAssetFactory(), file_system)

    assert not game_bundle.has_any_asset_collections()
    resources = list(game_bundle.fetch_resource_files())
    assert len(resources) == 1
    assert resources[0].name == "sharedassets0.resource"
    assert resources[0].to_byte_array() == b"not a serialized file, just bytes"


def test_from_paths_records_a_failed_file_instead_of_raising(tmp_path):
    missing_path = tmp_path / "does_not_exist"

    file_system = LocalFileSystem()
    game_bundle = GameBundle.from_paths([str(missing_path)], GameAssetFactory(), file_system)

    assert not game_bundle.has_any_asset_collections()
    assert game_bundle.any_failed
    assert len(game_bundle.failed_files) == 1

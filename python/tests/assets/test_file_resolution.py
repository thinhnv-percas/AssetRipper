"""Port of Source/AssetRipper.Assets.Tests/FileResolutionTests.cs"""
import pytest

from assetripper_assets.bundles import GameBundle, IResourceProvider, ProcessedBundle
from assetripper_assets.collections import ProcessedAssetCollection
from assetripper_io_files.special_file_names import fix_resource_path
from assetripper_io_files.streams.smart import SmartStream
from assetripper_io_files.serialized_files import FormatVersion  # noqa: F401  (sanity import)


class _ResourceFile:
    """Minimal stand-in for AssetRipper.IO.Files.ResourceFiles.ResourceFile (not yet
    ported); only the members FileResolutionTests actually touches."""

    def __init__(self, stream, file_path: str, name: str):
        self.stream = stream
        self.file_path = file_path
        self.name = name
        from assetripper_io_files.special_file_names import fix_file_identifier

        self.name_fixed = fix_file_identifier(name)

    def dispose(self) -> None:
        self.stream.dispose()


def _make_resource_file(name: str) -> _ResourceFile:
    return _ResourceFile(SmartStream.create_memory(), name, name)


class _SingleResourceProvider(IResourceProvider):
    def __init__(self, resource: _ResourceFile):
        self.resource = resource

    def find_resource(self, identifier: str):
        fixed_name = fix_resource_path(identifier)
        return self.resource if fixed_name == self.resource.name_fixed else None


def test_collection_resolution_works_anywhere_in_the_hierarchy():
    name1 = "name1"
    name2 = "name2"
    game_bundle = GameBundle()

    collection1 = ProcessedAssetCollection(game_bundle)
    collection1.name = name1

    processed_bundle = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle)

    collection2 = ProcessedAssetCollection(processed_bundle)
    collection2.name = name2

    assert game_bundle.resolve_collection(name1) is collection1
    assert game_bundle.resolve_collection(name2) is collection2
    assert processed_bundle.resolve_collection(name1) is collection1
    assert processed_bundle.resolve_collection(name2) is collection2


def test_collection_resolution_is_able_to_find_the_second_file():
    name1 = "name1"
    name2 = "name2"
    game_bundle = GameBundle()

    processed_bundle1 = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle1)
    collection1 = ProcessedAssetCollection(processed_bundle1)
    collection1.name = name1

    processed_bundle2 = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle2)
    collection2 = ProcessedAssetCollection(processed_bundle2)
    collection2.name = name2

    assert game_bundle.resolve_collection(name1) is collection1
    assert game_bundle.resolve_collection(name2) is collection2


def test_collection_resolution_is_able_to_find_unity_default_resources_with_inconsistent_underscores():
    name = "unity_default_resources"
    game_bundle = GameBundle()

    collection = ProcessedAssetCollection(game_bundle)
    collection.name = name

    assert game_bundle.resolve_collection("library/unity default resources") is collection


@pytest.mark.parametrize(
    "name",
    [
        "unity default resources",
        "unity_default_resources",
        "unity editor resources",
        "unity builtin extra",
        "unity_builtin_extra",
    ],
)
def test_collection_resolution_is_able_to_find_engine_resources(name):
    game_bundle = GameBundle()

    collection = ProcessedAssetCollection(game_bundle)
    collection.name = name

    assert game_bundle.resolve_collection(name) is collection
    assert game_bundle.resolve_collection(f"library/{name}") is collection
    assert game_bundle.resolve_collection(f"resources/{name}") is collection


@pytest.mark.parametrize(
    "name",
    [
        "unity default resources",
        "unity_default_resources",
        "unity editor resources",
        "unity builtin extra",
        "unity_builtin_extra",
    ],
)
def test_collection_resolution_is_able_to_find_engine_resources_nested(name):
    game_bundle = GameBundle()

    processed_bundle = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle)

    collection = ProcessedAssetCollection(processed_bundle)
    collection.name = name

    assert game_bundle.resolve_collection(name) is collection
    assert game_bundle.resolve_collection(f"library/{name}") is collection
    assert game_bundle.resolve_collection(f"resources/{name}") is collection


def test_resource_resolution_works_anywhere_in_the_hierarchy():
    name1 = "name1"
    name2 = "name2"
    game_bundle = GameBundle()

    resource1 = _make_resource_file(name1)
    game_bundle.add_resource(resource1)

    processed_bundle = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle)

    resource2 = _make_resource_file(name2)
    processed_bundle.add_resource(resource2)

    assert game_bundle.resolve_resource(name1) is resource1
    assert game_bundle.resolve_resource(name2) is resource2
    assert processed_bundle.resolve_resource(name1) is resource1
    assert processed_bundle.resolve_resource(name2) is resource2


def test_resource_resolution_is_able_to_find_the_second_file():
    name1 = "name1"
    name2 = "name2"
    game_bundle = GameBundle()

    processed_bundle1 = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle1)
    resource1 = _make_resource_file(name1)
    processed_bundle1.add_resource(resource1)

    processed_bundle2 = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle2)
    resource2 = _make_resource_file(name2)
    processed_bundle2.add_resource(resource2)

    assert game_bundle.resolve_resource(name1) is resource1
    assert game_bundle.resolve_resource(name2) is resource2


def test_resource_resolution_is_able_to_find_an_archive_file():
    name = "archive:/name1"
    game_bundle = GameBundle()

    processed_bundle = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle)

    resource = _make_resource_file(name)
    processed_bundle.add_resource(resource)

    assert game_bundle.resolve_resource(name) is resource


def test_resource_resolution_is_able_to_find_files_with_capital_letters():
    name = "ResourceName.resS"
    game_bundle = GameBundle()

    processed_bundle = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle)

    resource = _make_resource_file(name)
    processed_bundle.add_resource(resource)

    assert game_bundle.resolve_resource(name) is resource


def test_resource_resolution_is_able_to_find_external_files_from_parent_bundles():
    resource_name = "resources.resource"
    game_bundle = GameBundle()

    processed_bundle = ProcessedBundle()
    game_bundle.add_bundle(processed_bundle)

    resource = _make_resource_file(resource_name)
    game_bundle.resource_provider = _SingleResourceProvider(resource)

    assert processed_bundle.resolve_resource(resource_name) is resource


def test_resource_resolution_is_able_to_find_external_files_from_game_bundles():
    resource_name = "resources.resource"
    game_bundle = GameBundle()

    resource = _make_resource_file(resource_name)
    game_bundle.resource_provider = _SingleResourceProvider(resource)

    assert game_bundle.resolve_resource(resource_name) is resource

"""Phase 15: `DummyAssetExporter.cs`/`EmptyExportCollection.cs`/`SkipExportCollection.cs` port.

`EmptyExportCollection` (isEmptyCollection=True): claims no assets at all -- used for the 7
GlobalGameManager singletons nothing is ever expected to reference (BuildSettings/PreloadData/
AssetBundle/AssetBundleManifest/MonoManager/ResourceManager/ShaderNameRegistry).

`SkipExportCollection` (isEmptyCollection=False): claims its one asset so pointers to it can
still resolve, but to a missing reference rather than real content -- used for UnknownObject/
UnreadableObject when the caller opts out of raw export.
"""
from assetripper_export_unity_projects.dummy_asset_exporter import DummyAssetExporter, get_dummy_asset_exporter
from assetripper_export_unity_projects.empty_export_collection import INSTANCE as EMPTY_EXPORT_COLLECTION
from assetripper_export_unity_projects.skip_export_collection import SkipExportCollection
from assetripper_io_files.asset_type import AssetType


def test_get_returns_the_same_singleton_for_the_same_flags():
    a = get_dummy_asset_exporter(is_empty_collection=True, is_meta_type=False)
    b = get_dummy_asset_exporter(is_empty_collection=True, is_meta_type=False)
    assert a is b


def test_get_returns_distinct_instances_for_distinct_flags():
    empty = get_dummy_asset_exporter(is_empty_collection=True, is_meta_type=False)
    skip = get_dummy_asset_exporter(is_empty_collection=False, is_meta_type=False)
    assert empty is not skip


def test_empty_collection_mode_returns_the_empty_singleton():
    exporter = get_dummy_asset_exporter(is_empty_collection=True, is_meta_type=False)
    created, collection = exporter.try_create_collection(object())
    assert created
    assert collection is EMPTY_EXPORT_COLLECTION
    assert collection.exportable is False
    assert collection.contains(object()) is False
    assert list(collection.assets) == []


def test_skip_mode_returns_a_collection_containing_the_asset():
    class FakeAssetInfo:
        pass

    class FakeAsset:
        class_id = 141
        asset_info = FakeAssetInfo()

    asset = FakeAsset()
    exporter = get_dummy_asset_exporter(is_empty_collection=False, is_meta_type=False)
    created, collection = exporter.try_create_collection(asset)
    assert created
    assert isinstance(collection, SkipExportCollection)
    assert collection.exportable is False
    assert collection.contains(asset) is True

    pointer = collection.create_export_pointer(None, asset, is_local=False)
    assert pointer.guid.is_zero is False  # the MissingReference sentinel, not a real GUID
    assert pointer.asset_type == AssetType.SERIALIZED


def test_to_export_type_reports_the_configured_asset_type():
    meta_exporter = DummyAssetExporter(AssetType.META, is_empty_collection=True)
    assert meta_exporter.to_export_type(None) == AssetType.META
    assert meta_exporter.to_unknown_export_type(object) == (True, AssetType.META)

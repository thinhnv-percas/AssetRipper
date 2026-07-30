"""Port of Source/AssetRipper.Assets.Tests/ProcessedBundleTests.cs"""
from assetripper_assets.bundles import ProcessedBundle


def test_default_constructor_name_should_not_be_empty():
    bundle = ProcessedBundle()
    assert bundle.name


def test_argument_constructor_none_should_not_throw_exception():
    ProcessedBundle(None)


def test_argument_constructor_empty_string_should_not_throw_exception():
    ProcessedBundle("")


def test_argument_constructor_valid_name_should_not_be_none():
    name = "TestBundleName"
    bundle = ProcessedBundle(name)
    assert bundle is not None
    assert bundle.name == name

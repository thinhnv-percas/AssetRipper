"""Port of Source/AssetRipper.GUI.Web.Tests/BundlePathTests.cs"""
from assetripper_gui_web.paths import BundlePath


def test_default_bundle_path_is_root():
    path = BundlePath()
    assert path.is_root


def test_bundle_path_parent_with_depth_one_is_root():
    path = BundlePath((0,))
    assert path.parent.is_root


def test_bundle_path_parent_with_depth_two_is_not_root():
    path = BundlePath((0, 0))
    assert not path.parent.is_root


def test_parent_has_correct_path():
    path = BundlePath((1, 2, 3))
    parent = path.parent
    assert parent.path == (1, 2)


def test_bundle_paths_are_sequence_equal():
    path1 = BundlePath((0, 0))
    path2 = BundlePath((0, 0))
    assert path1 == path2


def test_to_string_does_not_throw():
    # In C#, ToString() could once cause a StackOverflowException because BundlePath
    # was a record whose generated PrintMembers called Parent.ToString(). Not
    # applicable to this dataclass port, but kept for parity.
    bundle_path = BundlePath()
    str(bundle_path)

"""
Port of Source/AssetRipper.Assets.Tests/PPtrTests.cs

The C# original also exercises PPtr <-> PPtr<T> implicit/explicit conversions and
PPtr<T> <-> PPtr<TOther> casts, which exist purely for C#'s static type system. Since
this port uses a single PPtr class for both roles (see metadata/pptr.py), those
conversions collapse to identity/copy operations -- ported here as such.
"""
from assetripper_assets.metadata.pptr import PPtr


def test_pptr_returns_correct_values():
    file_id = 1
    path_id = 2

    pptr = PPtr(file_id, path_id)

    assert pptr.file_id == file_id
    assert pptr.path_id == path_id


def test_pptr_cast_returns_same_values():
    file_id = 1
    path_id = 2
    pptr = PPtr(file_id, path_id)

    converted_pptr = pptr.cast()

    assert converted_pptr.file_id == file_id
    assert converted_pptr.path_id == path_id

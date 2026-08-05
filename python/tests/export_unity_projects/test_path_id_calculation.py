"""Port of Source/AssetRipper.Tests/PathIDCalculationTests.cs (2026-08-03).

Unity's own algorithm for the path ID a `.meta`-referenced asset gets: MD4 over the GUID's
32-character lowercase hex text, then the `AssetType` as a little-endian int32, then the file ID
as a little-endian int64; the path ID is the first 8 bytes of the digest read as a little-endian
int64.

Upstream's test carries exactly one case, and the value in it is not derived from the formula --
it is a *real* path ID observed in a real Unity project ("BinocularsOverlay"). That makes it the
only end-to-end proof that this chain agrees with Unity: MD4 correctness, GUID text form
(lowercase hex, not the dashed .NET Guid format), `AssetType` numbering, and the endianness of
all three writes. Getting any one of those wrong still produces a plausible-looking 64-bit
number, which is exactly why the observed value matters.

`compute_64_bit_hash` lives here rather than in `src/`: upstream's is a private test helper too,
and this port has no production caller (nothing generates references *into* another project's
`.meta`). The pieces it composes -- `md4`, `UnityGuid.parse`, `AssetType`,
`get_main_export_id` -- are all production code, and they are what this pins.
"""
from __future__ import annotations

import struct

import pytest
from assetripper_export_modules.scripts.md4 import md4
from assetripper_export_unity_projects.export_id_handler import get_main_export_id
from assetripper_io_files.asset_type import AssetType
from assetripper_primitives import UnityGuid

_GUID_STRING_LENGTH = 32


def compute_64_bit_hash(guid: UnityGuid, asset_type: AssetType, file_id: int) -> int:
    guid_text = str(guid)
    assert len(guid_text) == _GUID_STRING_LENGTH, guid_text
    payload = guid_text.encode("ascii") + struct.pack("<iq", int(asset_type), file_id)
    return struct.unpack_from("<q", md4(payload))[0]


def test_binoculars_overlay():
    """Upstream's single case, verbatim -- a path ID observed in a real Unity project."""
    expected_path_id = -3447896943880403800
    guid = UnityGuid.parse("01e291bf376af4b4994f5015f73d2fe0")
    file_id = get_main_export_id(28)

    assert compute_64_bit_hash(guid, AssetType.META, file_id) == expected_path_id


def test_the_input_the_real_case_hashes_is_exactly_44_bytes():
    """Guards the layout the observed value depends on: 32 GUID characters + a 4-byte type +
    an 8-byte file ID. A padded or differently sized buffer changes the digest completely."""
    guid = UnityGuid.parse("01e291bf376af4b4994f5015f73d2fe0")
    payload = str(guid).encode("ascii") + struct.pack("<iq", int(AssetType.META), get_main_export_id(28))
    assert len(payload) == 44


def test_main_export_id_for_class_28_is_the_five_digit_shifted_form():
    """The file ID fed into the hash above. Class 28 is Texture2D; `get_main_export_id` shifts
    the class ID by 10^5, so a wrong shift would silently change every path ID."""
    assert get_main_export_id(28) == 2800000


def test_guid_text_is_lowercase_hex_with_no_separators():
    """The hash consumes the GUID's *text*, so its formatting is load-bearing. .NET's default
    `Guid.ToString()` would produce a dashed 36-character form and a different digest."""
    text = str(UnityGuid.parse("01e291bf376af4b4994f5015f73d2fe0"))
    assert text == "01e291bf376af4b4994f5015f73d2fe0"
    assert "-" not in text
    assert text == text.lower()


def test_meta_asset_type_is_three():
    """`AssetType` goes into the hash as a raw int32, so its numbering is part of the contract
    with Unity, not an internal detail."""
    assert int(AssetType.META) == 3


@pytest.mark.parametrize(
    "changed_kwargs",
    [
        {"guid": UnityGuid.parse("01e291bf376af4b4994f5015f73d2fe1")},
        {"asset_type": AssetType.SERIALIZED},
        {"file_id": get_main_export_id(28) + 1},
    ],
)
def test_every_input_changes_the_result(changed_kwargs):
    """All three inputs must actually reach the digest -- a helper that dropped one (e.g. wrote
    the type but not the file ID) would still pass the single observed case if the dropped value
    happened to be zero in it."""
    baseline_kwargs = {
        "guid": UnityGuid.parse("01e291bf376af4b4994f5015f73d2fe0"),
        "asset_type": AssetType.META,
        "file_id": get_main_export_id(28),
    }
    baseline = compute_64_bit_hash(**baseline_kwargs)

    assert compute_64_bit_hash(**{**baseline_kwargs, **changed_kwargs}) != baseline

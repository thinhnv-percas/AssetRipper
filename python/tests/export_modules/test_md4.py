"""Verifies the pure-Python MD4 implementation (assetripper_export_modules/scripts/md4.py)
against RFC 1320 Section A.5's own published test vectors -- this is the one place
correctness depends on a hand-written cryptographic primitive rather than a port or a
well-known library, so it's worth pinning to the spec's own answers directly.
"""
import pytest

from assetripper_export_modules.scripts.md4 import md4

_RFC_1320_VECTORS = [
    (b"", "31d6cfe0d16ae931b73c59d7e0c089c0"),
    (b"a", "bde52cb31de33e46245e05fbdbd6fb24"),
    (b"abc", "a448017aaf21d8525fc10ae87aa6729d"),
    (b"message digest", "d9130a8164549fe818874806e1c7014b"),
    (b"abcdefghijklmnopqrstuvwxyz", "d79e1c308aa5bbcdeea8ed63df412da9"),
    (b"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", "043f8582f241db351ce627e153e7f0e4"),
    (
        b"12345678901234567890123456789012345678901234567890123456789012345678901234567890",
        "e33b4ddc9c38f2199c3e7b164fcc0536",
    ),
]


@pytest.mark.parametrize("data,expected_hex", _RFC_1320_VECTORS)
def test_md4_matches_rfc_1320_test_vectors(data: bytes, expected_hex: str):
    assert md4(data).hex() == expected_hex


def test_md4_returns_16_bytes():
    assert len(md4(b"arbitrary length input, just checking output size")) == 16


def test_md4_is_deterministic():
    assert md4(b"repeatable") == md4(b"repeatable")


def test_md4_differs_for_different_input():
    assert md4(b"one") != md4(b"two")

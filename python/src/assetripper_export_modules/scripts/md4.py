"""Pure-Python MD4 (RFC 1320).

Unity's own script FileID algorithm (ScriptHashing.CalculateScriptFileID) hard-codes MD4.
Python's stdlib `hashlib` doesn't expose MD4 on modern OpenSSL builds (disabled as a
legacy/insecure algorithm), and pulling in a general-purpose crypto library for one legacy
hash isn't worth the dependency weight -- MD4 is small and precisely specified (RFC 1320),
so this is a direct, self-contained implementation instead. Verified against the RFC's own
test vectors in tests/export_modules/test_md4.py ("" / "a" / "abc" / "message digest" /
the alphabet / digits, all from RFC 1320 Section A.5).
"""
from __future__ import annotations

import struct

_MASK32 = 0xFFFFFFFF


def _left_rotate(x: int, count: int) -> int:
    x &= _MASK32
    return ((x << count) | (x >> (32 - count))) & _MASK32


def _f(x: int, y: int, z: int) -> int:
    return (x & y) | (~x & z)


def _g(x: int, y: int, z: int) -> int:
    return (x & y) | (x & z) | (y & z)


def _h(x: int, y: int, z: int) -> int:
    return x ^ y ^ z


_ROUND2_CONSTANT = 0x5A827999
_ROUND3_CONSTANT = 0x6ED9EBA1

_ROUND2_ORDER = (0, 4, 8, 12, 1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15)
_ROUND2_SHIFTS = (3, 5, 9, 13)
_ROUND3_ORDER = (0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15)
_ROUND3_SHIFTS = (3, 9, 11, 15)
_ROUND1_SHIFTS = (3, 7, 11, 19)


def _pad(message: bytes) -> bytes:
    bit_length = (len(message) * 8) & 0xFFFFFFFFFFFFFFFF
    padded = bytearray(message)
    padded.append(0x80)
    while len(padded) % 64 != 56:
        padded.append(0)
    padded += struct.pack("<Q", bit_length)
    return bytes(padded)


def md4(message: bytes) -> bytes:
    """Returns the 16-byte MD4 digest of `message`."""
    a0, b0, c0, d0 = 0x67452301, 0xEFCDAB89, 0x98BADCFE, 0x10325476

    padded = _pad(message)
    for offset in range(0, len(padded), 64):
        x = struct.unpack_from("<16I", padded, offset)
        a, b, c, d = a0, b0, c0, d0

        # Round 1: words in order, shifts [3, 7, 11, 19] cycling over (a, d, c, b).
        for i in range(16):
            shift = _ROUND1_SHIFTS[i % 4]
            k = x[i]
            if i % 4 == 0:
                a = _left_rotate((a + _f(b, c, d) + k) & _MASK32, shift)
            elif i % 4 == 1:
                d = _left_rotate((d + _f(a, b, c) + k) & _MASK32, shift)
            elif i % 4 == 2:
                c = _left_rotate((c + _f(d, a, b) + k) & _MASK32, shift)
            else:
                b = _left_rotate((b + _f(c, d, a) + k) & _MASK32, shift)

        # Round 2: words in _ROUND2_ORDER, + 0x5A827999, shifts [3, 5, 9, 13].
        for idx, word_index in enumerate(_ROUND2_ORDER):
            shift = _ROUND2_SHIFTS[idx % 4]
            k = x[word_index]
            if idx % 4 == 0:
                a = _left_rotate((a + _g(b, c, d) + k + _ROUND2_CONSTANT) & _MASK32, shift)
            elif idx % 4 == 1:
                d = _left_rotate((d + _g(a, b, c) + k + _ROUND2_CONSTANT) & _MASK32, shift)
            elif idx % 4 == 2:
                c = _left_rotate((c + _g(d, a, b) + k + _ROUND2_CONSTANT) & _MASK32, shift)
            else:
                b = _left_rotate((b + _g(c, d, a) + k + _ROUND2_CONSTANT) & _MASK32, shift)

        # Round 3: words in _ROUND3_ORDER, + 0x6ED9EBA1, shifts [3, 9, 11, 15].
        for idx, word_index in enumerate(_ROUND3_ORDER):
            shift = _ROUND3_SHIFTS[idx % 4]
            k = x[word_index]
            if idx % 4 == 0:
                a = _left_rotate((a + _h(b, c, d) + k + _ROUND3_CONSTANT) & _MASK32, shift)
            elif idx % 4 == 1:
                d = _left_rotate((d + _h(a, b, c) + k + _ROUND3_CONSTANT) & _MASK32, shift)
            elif idx % 4 == 2:
                c = _left_rotate((c + _h(d, a, b) + k + _ROUND3_CONSTANT) & _MASK32, shift)
            else:
                b = _left_rotate((b + _h(c, d, a) + k + _ROUND3_CONSTANT) & _MASK32, shift)

        a0 = (a0 + a) & _MASK32
        b0 = (b0 + b) & _MASK32
        c0 = (c0 + c) & _MASK32
        d0 = (d0 + d) & _MASK32

    return struct.pack("<4I", a0, b0, c0, d0)

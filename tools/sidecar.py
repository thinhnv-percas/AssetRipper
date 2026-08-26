#!/usr/bin/env python3
"""
Unpack the hash-named sidecar assemblies that sit next to DevXUnityUnpackerRun.exe
(2C74C997, 33123090, 8DAFE878, ...).

Naming
------
The loader resolves an assembly by hashing its *simple name*, lowercased:

    filename = String.GetHashCode(name.ToLower()).ToString("X")

using the CLR x86 String.GetHashCode (seed 352654597, multiplier 1566083941),
reimplemented here as `name_hash`.  Verified: name_hash("mono.cecil") == E88D01F4,
name_hash("devxunityunpackertools") == 8DAFE878, and so on for all seven files.

Cipher
------
`DevXUnityUnpackerMain` token 0x06000003 (public static byte[] 例子.测试(byte[], string)):

    num  = 1162040133 + hash(secret[:len/2])
    num2 = 2506450243 + hash(secret[len/2:])
    b    = in[0]                                  # first byte is the seed, not data
    for i in range(len(in) - 1):
        num  = (num  * 4343255 + b + 5235457)  mod 2^32 mod (2^32-2)
        num2 = (num2 * 5354354 + b + 22646641) mod 2^32 mod (2^32-2)
        out[i] = ((in[i+1] - (num2 & 0xFF)) & 0xFF) ^ (num & 0xFF)
        b = out[i]                                # chains on plaintext
    then gunzip(out), falling back to out if that fails

The interesting part: only `num & 0xFF` and `num2 & 0xFF` are ever used, and
multiplication mod 256 depends only on the operands mod 256.  So the entire
keystream is fixed by (num & 0xFF, num2 & 0xFF) -- a 16-bit effective key.  The
secret string, the two 32-bit seeds and the hash function are all irrelevant to
recovering the plaintext: 65536 trial decryptions of four bytes each is enough.
`crack` does exactly that and confirms the result by gunzipping (which CRC-checks
the whole stream).

Usage:
    python sidecar.py hash  <AssemblyName>          # name -> filename
    python sidecar.py info  <file>                  # recover key, identify payload
    python sidecar.py unpack <file> <out>           # recover and write the assembly
    python sidecar.py unpackall <dir> <outdir>      # every hash-named file in dir
"""
import ctypes, gzip, io, os, re, sys

A_LO, C1_LO = 4343255 % 256, 5235457 % 256      # 215, 1
B_LO, C2_LO = 5354354 % 256, 22646641 % 256     # 114, 113
GZIP = bytes([0x1F, 0x8B, 0x08, 0x00])


def name_hash(name):
    """CLR x86 String.GetHashCode, as reimplemented in the app (token 0x06000002)."""
    s = name.lower()
    if not s:
        return 123
    i32 = lambda x: ctypes.c_int32(x).value
    num, num2 = 0, 352654597
    num3 = num2
    i = len(s)
    while i > 0:
        if num + 1 < len(s):
            num2 = i32(i32(i32(num2 << 5) + num2 + (num2 >> 27)) ^ i32(ord(s[num]) | i32(ord(s[num + 1]) << 16)))
        elif num < len(s):
            num2 = i32(i32(i32(num2 << 5) + num2 + (num2 >> 27)) ^ ord(s[num]))
        else:
            num2 = i32(i32(num2 << 5) + num2 + (num2 >> 27))
        if i <= 2:
            break
        num += 2
        if num + 1 < len(s):
            num3 = i32(i32(i32(num3 << 5) + num3 + (num3 >> 27)) ^ i32(ord(s[num]) | i32(ord(s[num + 1]) << 16)))
        elif num < len(s):
            num3 = i32(i32(i32(num3 << 5) + num3 + (num3 >> 27)) ^ ord(s[num]))
        else:
            num3 = i32(i32(num3 << 5) + num3 + (num3 >> 27))
        num += 2
        i -= 4
    return ctypes.c_uint32(i32(num2 + i32(num3 * 1566083941))).value


def decrypt(buf, n, n2, limit=None):
    """Decrypt with the 16-bit effective key (low bytes of the two state words)."""
    b = buf[0]
    total = len(buf) - 1 if limit is None else min(limit, len(buf) - 1)
    out = bytearray(total)
    for i in range(total):
        n = (A_LO * n + b + C1_LO) & 0xFF
        n2 = (B_LO * n2 + b + C2_LO) & 0xFF
        x = ((buf[i + 1] - n2) & 0xFF) ^ n
        out[i] = x
        b = x
    return bytes(out)


def crack(buf):
    """Return (key, payload) or (None, None). Brute-forces the whole 2^16 key space."""
    for n in range(256):
        for n2 in range(256):
            if decrypt(buf, n, n2, limit=4) != GZIP:
                continue
            try:
                data = gzip.GzipFile(fileobj=io.BytesIO(decrypt(buf, n, n2))).read()
            except Exception:
                continue                      # gzip CRC rejected it: wrong key
            return (n, n2), data
    return None, None


def describe(raw):
    """Walk the PE headers properly -- searching the file for 'BSJB' finds IL, not metadata."""
    if raw[:2] != b'MZ':
        return 'not a PE image (%d bytes)' % len(raw)
    pe = int.from_bytes(raw[0x3C:0x40], 'little')
    if raw[pe:pe + 4] != b'PE\0\0':
        return 'bad PE signature'
    nsec = int.from_bytes(raw[pe + 6:pe + 8], 'little')
    opt = pe + 24
    pe32plus = int.from_bytes(raw[opt:opt + 2], 'little') == 0x20B
    dirs = opt + (112 if pe32plus else 96)
    cor_rva = int.from_bytes(raw[dirs + 14 * 8:dirs + 14 * 8 + 4], 'little')
    if not cor_rva:
        return 'native PE, %d bytes' % len(raw)

    sect = opt + int.from_bytes(raw[pe + 20:pe + 22], 'little')

    def off(rva):
        for i in range(nsec):
            s = sect + i * 40
            va = int.from_bytes(raw[s + 12:s + 16], 'little')
            vs = int.from_bytes(raw[s + 8:s + 12], 'little')
            pr = int.from_bytes(raw[s + 20:s + 24], 'little')
            if va <= rva < va + vs:
                return pr + (rva - va)
        return None

    cor = off(cor_rva)
    md = off(int.from_bytes(raw[cor + 8:cor + 12], 'little'))
    ver = '?'
    if md is not None and raw[md:md + 4] == b'BSJB':
        vlen = int.from_bytes(raw[md + 12:md + 16], 'little')
        ver = raw[md + 16:md + 16 + vlen].rstrip(b'\0').decode('ascii', 'ignore')
        ver = ''.join(c for c in ver if 32 <= ord(c) < 127) or '?'
    return '.NET assembly, runtime %s, %d bytes' % (ver, len(raw))


def main():
    if len(sys.argv) < 3:
        print(__doc__)
        return 2
    cmd = sys.argv[1]

    if cmd == 'hash':
        for n in sys.argv[2:]:
            print('%-40s -> %X' % (n, name_hash(n)))
        return 0

    if cmd == 'unpackall':
        src, dst = sys.argv[2], sys.argv[3]
        os.makedirs(dst, exist_ok=True)
        for fn in sorted(os.listdir(src)):
            p = os.path.join(src, fn)
            if not os.path.isfile(p) or not re.fullmatch(r'[0-9A-F]{1,8}', fn):
                continue
            key, data = crack(open(p, 'rb').read())
            if key is None:
                print('%-12s no key found' % fn)
                continue
            out = os.path.join(dst, fn + '.dll')
            open(out, 'wb').write(data)
            print('%-12s key=%-10s %s' % (fn, str(key), describe(data)))
        return 0

    buf = open(sys.argv[2], 'rb').read()
    key, data = crack(buf)
    if key is None:
        print('no key found in the 2^16 space -- not a sidecar file?')
        return 1
    print('key (num&0xFF, num2&0xFF) = %s' % (key,))
    print(describe(data))
    if cmd == 'unpack':
        open(sys.argv[3], 'wb').write(data)
        print('written to %s' % sys.argv[3])
    return 0


if __name__ == '__main__':
    sys.exit(main())

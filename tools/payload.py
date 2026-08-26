#!/usr/bin/env python3
"""
Pack/unpack the `0000000000` payload used by DevXUnityUnpackerRun.exe.

Format, taken verbatim from DevXUnityUnpackerRun/Program.cs:

    Memrestore(bytes):
        num2 = 10, num3 = 1
        for i in range(len):
            out[i] = in[i] ^ (byte)(num2 + num3)
            num2 += 13; num3 += 1317
        return gunzip(out)

    Assembly.Load(Memrestore(File.ReadAllBytes("0000000000"))).EntryPoint.Invoke(null, null)

So the keystream is num2+num3 = 11 + 1330*i, and 1330 % 256 == 50, i.e.

    key[i] = (11 + 50*i) & 0xFF

which is a fixed 128-byte repeating pattern -- no key material, no per-file
state.  Layered on top of that is a plain GZip stream.  Both steps are
symmetric, so packing is just the same code with gzip instead of gunzip.

Usage:
    python payload.py unpack 0000000000 payload.dll
    python payload.py pack   payload.dll 0000000000
    python payload.py info   0000000000
"""
import gzip, io, sys, os

MAGIC = bytes([0x14, 0xB6, 0x67, 0xA1])  # gzip's 1F 8B 08 00 through the keystream


def keystream(n):
    return bytes((11 + 50 * i) & 0xFF for i in range(n))


def xor(data):
    """Symmetric: applying it twice is the identity."""
    return bytes(b ^ k for b, k in zip(data, keystream(len(data))))


def unpack(blob):
    if len(blob) <= 1:                      # Memrestore returns null here
        raise ValueError("input too short; loader would return null")
    deflated = xor(blob)
    if deflated[:2] != b"\x1f\x8b":
        raise ValueError(
            "not a GZip stream after de-XOR (got %s) -- wrong file, or the "
            "loader in this build uses different constants"
            % deflated[:4].hex(" "))
    return gzip.GzipFile(fileobj=io.BytesIO(deflated)).read()


def pack(raw):
    buf = io.BytesIO()
    # mtime=0 so the output is reproducible
    with gzip.GzipFile(fileobj=buf, mode="wb", mtime=0) as g:
        g.write(raw)
    return xor(buf.getvalue())


def describe(raw):
    """Minimal PE / CLI header walk -- enough to confirm what came out."""
    out = ["size: %d bytes (%.1f MB)" % (len(raw), len(raw) / 1048576)]
    if raw[:2] != b"MZ":
        out.append("not a PE image (no MZ) -- payload is not an assembly")
        return out
    pe = int.from_bytes(raw[0x3C:0x40], "little")
    if raw[pe:pe + 4] != b"PE\0\0":
        out.append("bad PE signature")
        return out
    machine = int.from_bytes(raw[pe + 4:pe + 6], "little")
    nsec = int.from_bytes(raw[pe + 6:pe + 8], "little")
    opt = pe + 24
    magic = int.from_bytes(raw[opt:opt + 2], "little")
    pe32plus = magic == 0x20B
    out.append("machine: %s, %d sections, %s" % (
        {0x14C: "i386", 0x8664: "x64", 0x1C0: "ARM", 0xAA64: "ARM64"}.get(machine, hex(machine)),
        nsec, "PE32+" if pe32plus else "PE32"))

    dirs = opt + (112 if pe32plus else 96)
    cor_rva = int.from_bytes(raw[dirs + 14 * 8:dirs + 14 * 8 + 4], "little")
    if not cor_rva:
        out.append("native PE -- no CLI header, not a .NET assembly")
        return out

    # RVA -> file offset via the section table
    sect = opt + int.from_bytes(raw[pe + 20:pe + 22], "little")
    def off(rva):
        for i in range(nsec):
            s = sect + i * 40
            va = int.from_bytes(raw[s + 12:s + 16], "little")
            vs = int.from_bytes(raw[s + 8:s + 12], "little")
            pr = int.from_bytes(raw[s + 20:s + 24], "little")
            if va <= rva < va + vs:
                return pr + (rva - va)
        return None

    cor = off(cor_rva)
    flags = int.from_bytes(raw[cor + 16:cor + 20], "little")
    entry = int.from_bytes(raw[cor + 20:cor + 24], "little")
    md = off(int.from_bytes(raw[cor + 8:cor + 12], "little"))
    out.append(".NET assembly: yes")
    out.append("  ILONLY=%d 32BITREQUIRED=%d SIGNED=%d"
               % (flags & 1, (flags >> 1) & 1, (flags >> 3) & 1))
    out.append("  EntryPointToken: 0x%08X" % entry)
    if md and raw[md:md + 4] == b"BSJB":
        vlen = int.from_bytes(raw[md + 12:md + 16], "little")
        ver = raw[md + 16:md + 16 + vlen].rstrip(b"\0").decode("ascii", "replace")
        out.append("  runtime: %s" % ver)
    return out


def main():
    if len(sys.argv) < 3:
        print(__doc__)
        return 2
    cmd, src = sys.argv[1], sys.argv[2]
    blob = open(src, "rb").read()

    if cmd == "info":
        head = blob[:4]
        print("input : %s (%d bytes)" % (src, len(blob)))
        print("magic : %s  %s" % (head.hex(" ").upper(),
              "OK - packed payload" if head == MAGIC else "unexpected (want %s)" % MAGIC.hex(" ").upper()))
        for line in describe(unpack(blob)):
            print("       ", line)
    elif cmd == "unpack":
        raw = unpack(blob)
        open(sys.argv[3], "wb").write(raw)
        print("unpacked %d -> %d bytes into %s" % (len(blob), len(raw), sys.argv[3]))
        for line in describe(raw):
            print("   ", line)
    elif cmd == "pack":
        out = pack(blob)
        open(sys.argv[3], "wb").write(out)
        print("packed %d -> %d bytes into %s" % (len(blob), len(out), sys.argv[3]))
    else:
        print(__doc__)
        return 2
    return 0


if __name__ == "__main__":
    sys.exit(main())

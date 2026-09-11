#!/usr/bin/env bash
# Tải và kiểm tra các test fixture, một cách có thể lặp lại.
#
#   Test/Scripts/download_test_inputs.sh [android|ios|all]
#
# Không phụ thuộc file nằm sẵn trên máy developer. Mỗi fixture được verify bằng SHA256 trước khi
# giải nén, và sau khi giải nén thì script định vị il2cpp binary cùng metadata rồi báo lại trạng
# thái. Nếu không có mạng, script in NETWORK_UNAVAILABLE và trả mã khác 0 - nó không bao giờ giả vờ
# fixture đã tồn tại.
#
# Trạng thái fixture có thể là:
#   OK                  dùng được cho toàn bộ pipeline
#   FIXTURE_ENCRYPTED   binary bị DRM mã hoá; chỉ metadata đọc được, không phục hồi được thân hàm
#   MISSING             thiếu file
#   NETWORK_UNAVAILABLE không tải được

set -u

repo=$(cd "$(dirname "${BASH_SOURCE[0]}")/../.." && pwd)
which=${1:-all}
cache="$repo/artifacts/input"
mkdir -p "$cache"

ANDROID_URL="https://github.com/thinhabc01/Impostor-Sort-Puzzle-Pro/releases/download/v1/impostor-sort.apk"
ANDROID_SHA="8e5ab4a9fa42d5f25a1933cd9f931624ee95589add77b7f6381c447dd9fc8aaf"
ANDROID_DIR="$repo/Test/Input/Impostor"

IOS_URL="https://github.com/ThinhNV-x-Percas/jelly-blast/releases/download/v1/Jelly.Blast.1.1.ipa"
IOS_SHA="4992cab50741c789c566b1456d6774073dba40578e12fd79113d22b410e94c48"
IOS_DIR="$repo/Test/Input/JellyBlast"

status=0

fetch() { # $1 url, $2 file, $3 sha
    if [ -f "$2" ] && [ "$(sha256sum "$2" | cut -d' ' -f1)" = "$3" ]; then
        echo "  đã có trong cache, SHA256 khớp: $(basename "$2")"
        return 0
    fi

    echo "  đang tải $(basename "$2")..."
    if ! curl -sSL --fail --max-time 1800 -o "$2.part" "$1"; then
        echo "  NETWORK_UNAVAILABLE: không tải được $1"
        rm -f "$2.part"
        return 2
    fi

    local got
    got=$(sha256sum "$2.part" | cut -d' ' -f1)
    if [ "$got" != "$3" ]; then
        echo "  SHA256 KHÔNG KHỚP: mong $3, nhận $got"
        rm -f "$2.part"
        return 3
    fi

    mv "$2.part" "$2"
    echo "  tải xong, SHA256 khớp"
}

# In trạng thái mã hoá của một Mach-O, đọc trực tiếp LC_ENCRYPTION_INFO*.
machO_cryptid() {
    python3 - "$1" <<'PY'
import struct, sys
d = open(sys.argv[1], 'rb').read(1 << 16)
magic, = struct.unpack_from('<I', d, 0)
if magic != 0xfeedfacf:
    print("not-macho-64"); raise SystemExit
ncmds, = struct.unpack_from('<I', d, 16)
off = 32
for _ in range(ncmds):
    cmd, size = struct.unpack_from('<II', d, off)
    if cmd in (0x21, 0x2c):
        cryptoff, cryptsize, cryptid = struct.unpack_from('<III', d, off + 8)
        print(f"cryptid={cryptid} cryptoff=0x{cryptoff:x} cryptsize=0x{cryptsize:x}")
        raise SystemExit
    off += size
print("cryptid=0")
PY
}

if [ "$which" = android ] || [ "$which" = all ]; then
    echo "== Android: Impostor-Sort-Puzzle-Pro v1"
    fetch "$ANDROID_URL" "$cache/impostor-sort.apk" "$ANDROID_SHA" || status=$?

    if [ -f "$cache/impostor-sort.apk" ]; then
        [ -d "$ANDROID_DIR" ] || unzip -o -q "$cache/impostor-sort.apk" -d "$ANDROID_DIR"
        so="$ANDROID_DIR/lib/arm64-v8a/libil2cpp.so"
        md="$ANDROID_DIR/assets/bin/Data/Managed/Metadata/global-metadata.dat"
        if [ -f "$so" ] && [ -f "$md" ]; then
            echo "  il2cpp binary : $so ($(stat -c%s "$so") byte, ELF)"
            echo "  metadata      : $md ($(stat -c%s "$md") byte, v$(python3 -c "
import struct,sys; print(struct.unpack_from('<I', open('$md','rb').read(8), 4)[0])"))"
            echo "  TRẠNG THÁI    : OK"
        else
            echo "  TRẠNG THÁI    : MISSING"; status=1
        fi
    fi
fi

if [ "$which" = ios ] || [ "$which" = all ]; then
    echo "== iOS: Jelly Blast 1.1"
    fetch "$IOS_URL" "$cache/Jelly.Blast.1.1.ipa" "$IOS_SHA" || status=$?

    if [ -f "$cache/Jelly.Blast.1.1.ipa" ]; then
        [ -d "$IOS_DIR/Payload" ] || unzip -o -q "$cache/Jelly.Blast.1.1.ipa" -d "$IOS_DIR"
        app=$(find "$IOS_DIR/Payload" -maxdepth 1 -name '*.app' | head -1)
        fw="$app/Frameworks/UnityFramework.framework/UnityFramework"
        md="$app/Data/Managed/Metadata/global-metadata.dat"

        if [ -n "$app" ] && [ -f "$fw" ] && [ -f "$md" ]; then
            crypt=$(machO_cryptid "$fw")
            echo "  .app          : $app"
            echo "  il2cpp binary : $fw ($(stat -c%s "$fw") byte, Mach-O arm64)"
            echo "  metadata      : $md ($(stat -c%s "$md") byte, v$(python3 -c "
import struct; print(struct.unpack_from('<I', open('$md','rb').read(8), 4)[0])"))"
            echo "  mã hoá        : $crypt"
            case "$crypt" in
                cryptid=0) echo "  TRẠNG THÁI    : OK" ;;
                *)         echo "  TRẠNG THÁI    : FIXTURE_ENCRYPTED - chỉ metadata đọc được; xem reports/IOS_INPUT_ANALYSIS.md" ;;
            esac
        else
            echo "  TRẠNG THÁI    : MISSING"; status=1
        fi
    fi
fi

exit $status

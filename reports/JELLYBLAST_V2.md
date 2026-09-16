# Jelly Blast v2 — fingerprint đo trực tiếp, không dùng kết luận của v1

Mọi con số dưới đây đo từ chính file v2. Kết luận của v1 (`FIXTURE_ENCRYPTED`) **không áp dụng** và
đã bị lật.

```
INPUT                io.heseri.blast-1.1.ipa
SOURCE               github.com/ThinhNV-x-Percas/jelly-blast, release v2
SHA256               11093fbd6ea9a7094aff349aca838209b291818cd8a6cd772a47ea00ba6c6b7f
SIZE                 38.522.514 byte   (v1: 69.828.168)
BUNDLE               io.heseri.blast, Payload/JellyBlast.app
UNITY FRAMEWORK      Frameworks/UnityFramework.framework/UnityFramework, 51.406.160 byte
METADATA             Data/Managed/Metadata/global-metadata.dat
UNITY VERSION        2022.3.53f1
ARCH                 arm64 (cputype 16777228), Mach-O 64, filetype 6 (dylib), 73 load command
ENCRYPTION           LC_ENCRYPTION_INFO_64 cryptoff=0x8000 cryptsize=0x2C30000 cryptid=0
SC_Info/*.sinf       KHÔNG có
```

## Trạng thái: `IOS_DECRYPTED`

Ba phép đo độc lập, mỗi phép đo phân biệt ciphertext với mã máy mà không cần khoá — đúng ba phép đo
đã dùng để kết luận v1 bị mã hoá, chạy lại trên v2:

| | v1 | v2 |
|---|---|---|
| `cryptid` | 1 | **0** |
| entropy `__TEXT` (1 MiB đầu) | 7,997 / 8 | **6,541 / 8** |
| số lệnh `ret` trong 1 MiB `__TEXT` | **0** | **4225** |
| `mscorlib.dll` xuất hiện | 0 lần | **1 lần** |
| `SC_Info/*.sinf` | có | không |

`cryptid = 0` bên cạnh một `LC_ENCRYPTION_INFO_64` còn nguyên là chữ ký của một bản dump từ thiết bị
(`frida-ios-dump`, `bfdecrypt`, `DumpDecrypted` đều ghi lại cryptid 0 và giữ nguyên load command).
Không có gì trong repository này giải mã hay bỏ qua DRM: đây là một input khác, không phải một cách
đọc khác.

## Layout segment

| segment | vm | vmsize | file | filesize | sections |
|---|---|---|---|---|---|
| `__TEXT` | 0x0 | 0x2C38000 | 0x0 | 0x2C38000 | 20 |
| `__DATA` | 0x2C38000 | 0x658000 | 0x2C38000 | 0x304000 | 26 |
| `__LINKEDIT` | 0x3290000 | 0x1CC000 | 0x2F3C000 | 0x1CA550 | 0 |

`__TEXT` ở vm 0 và `__DATA` có vmaddr bằng file offset, giống v1 — nên trong `__DATA` một địa chỉ ảo
*là* một file offset. Không có `LC_DYLD_CHAINED_FIXUPS`.

## Đọc được những gì

| | v1 | v2 |
|---|---|---|
| declaration + signature | có | có |
| `CODE REGISTRATION` | không tìm được qua tên module | tìm được |
| `TYPE REGISTRATION` | tìm được (`__DATA`) | tìm được |
| `FIELD OFFSETS` | 5782/5782 trỏ vào vùng mã hoá | **đọc được** |
| `TYPE DEFINITION SIZES` | 8702/8702 trỏ vào vùng mã hoá | **đọc được** |
| `GENERIC TABLE`, `METHOD SPECS` | trong `__TEXT.__const` mã hoá | **đọc được** |
| method body | **0** | **7485 method có địa chỉ native** |
| field layout self-check | không có gì để đo | **2654 exact / 0 disagreed** |

## Phép đo phục hồi

```
file .cs                 1501
method có địa chỉ native 7485
native accounted for     2.241.332 byte
EXACT                    2200  (29,4%)
HIGH_CONFIDENCE           248  ( 3,3%)
PARTIAL                  4668  (62,4%)
FALLBACK                  369  ( 4,9%)
MISSING                     0
phục hồi không đồ thế chỗ 2448 / 7485  (32,7%)
placeholder              49487
generatorFailures           0
```

Số file `.cs` giống hệt v1 (1501) và đó là điều đáng chú ý chứ không phải trùng hợp: metadata của hai
bản là một, nên **khai báo luôn phục hồi được ở cả hai**. Cái v2 thêm vào là *thân hàm* — từ 0 lên
7485 — nên mọi con số đọc trên v1 mà không kèm `body_recovery_rate` đều là con số trên khai báo.

`PARTIAL` 62,4% cao hơn hẳn Impostor (20,8%): đây là bản rip đầu tiên của binary này, chưa iteration
nào tối ưu cho nó.

# Phân tích input iOS — Jelly Blast 1.1

Báo cáo này ghi lại fixture iOS đã được thêm vào repository, những gì nó cho phép kiểm tra, và điều
quan trọng nhất: **những gì nó không cho phép kiểm tra, cùng bằng chứng**. Fixture được tải và xác
minh bằng `Test/Scripts/download_test_inputs.sh ios`; không có đường dẫn nào phụ thuộc máy
developer.

## Nhận dạng fixture

| | |
|---|---|
| Release asset | `https://github.com/ThinhNV-x-Percas/jelly-blast/releases/download/v1/Jelly.Blast.1.1.ipa` |
| Tên file | `Jelly.Blast.1.1.ipa` |
| SHA256 | `4992cab50741c789c566b1456d6774073dba40578e12fd79113d22b410e94c48` |
| Kích thước | 69.828.168 byte |
| Bundle identifier | `io.heseri.blast` |
| Phiên bản | `CFBundleShortVersionString` 1.1, `CFBundleVersion` 0 |
| Nền tảng tối thiểu | iOS 12.0, yêu cầu `arm64` và `metal` |
| Build | SDK iOS 18.1, Xcode 1610, macOS build 24B2082 |
| Unity | **2022.3.53f1** — AssetRipper đọc được từ data directory |
| Metadata | `global-metadata.dat` 7.306.348 byte, **v31.1**, sanity `0xfab11baf` |
| Kiến trúc | `CPU_TYPE_ARM64`, Mach-O 64-bit `0xfeedfacf`, không phải FAT |
| Giải nén tại | `Test/Input/JellyBlast` (gitignored) |

Đường dẫn bên trong IPA:

```
Payload/JellyBlast.app/
    JellyBlast                                          Mach-O launcher, 70.896 byte
    Info.plist
    SC_Info/                                            JellyBlast.sinf/.supf/.supp/.supx
    Data/
        Managed/Metadata/global-metadata.dat            7.306.348 byte, v31.1
        Managed/Resources/, Managed/mono/4.0/machine.config
        data.unity3d, resources.resource, unity default resources
        Raw/                                            StreamingAssets
        boot.config, ScriptingAssemblies.json, RuntimeInitializeOnLoads.json
    Frameworks/
        UnityFramework.framework/UnityFramework         Mach-O, 51.406.160 byte  <-- il2cpp thật
        FBSDK*.framework, libswift*.dylib
```

So sánh với Android: cùng dòng metadata v31.1, nhưng Unity 2022.3.53f1 (iOS) so với 2022.3.62f2
(Android Impostor). Đây là **METADATA_DIFFERENCE** ở mức bản build Unity, không phải cùng project,
nên hai fixture không phải hai bản build của cùng một game và không thể so sánh C# sinh ra theo từng
method. Chúng chỉ dùng để kiểm tra tool trên hai codegen.

## Vấn đề thứ nhất: binary il2cpp không phải app executable — DECOMPILER_BUG, đã sửa

`iOSGameStructure` đặt `Il2CppGameAssemblyPath = Path.Join(appPath, name)`, tức
`Payload/JellyBlast.app/JellyBlast`. Trên fixture này đó là một launcher 70.896 byte với `__TEXT`
chỉ 0x8000 byte — không chứa mã managed nào. Unity 2019.3 đã chuyển player vào một framework nhúng,
nên il2cpp nằm ở `Frameworks/UnityFramework.framework/UnityFramework`, 51.406.160 byte.

Bằng chứng chuỗi `il2cpp` xuất hiện 243 lần trong UnityFramework và 0 lần trong launcher.

Hậu quả trước khi sửa, đọc từ log:

```
Cpp2IL [Error] : No codegen modules found for mscorlib! Aborting search.
Cpp2IL : Got Binary codereg: 0x0, metareg: 0x0 in 15ms.
```

Thông báo đó **gây hiểu sai**: metadata đã nạp xong trước đó ("Initialized Metadata in 260ms"), lỗi
không nằm ở metadata mà ở chỗ binary được đưa vào không phải của game.

Sau khi sửa (`GetIl2CppBinaryPath` ưu tiên UnityFramework, giữ app executable làm fallback cho các
build cũ):

```
Cpp2IL : Got Binary codereg: 0x0, metareg: 0x2D234B8 in 38ms.
```

`metareg` đi từ `0x0` lên `0x2D234B8`. Đây là phép đo chứng minh binary đúng đã được nạp:
metadata registration là một cấu trúc nằm trong `__DATA`, và `__DATA` không bị mã hoá.

## Vấn đề thứ hai: `__TEXT` bị FairPlay mã hoá — FIXTURE_ENCRYPTED, không phải bug

`codereg` vẫn là `0x0` sau khi sửa, và lý do là thuộc tính của fixture chứ không phải của tool.

UnityFramework mang `LC_ENCRYPTION_INFO_64`:

```
cryptoff = 0x8000   cryptsize = 0x2C30000   cryptid = 1
```

Vùng `0x8000 .. 0x2C38000` là đúng toàn bộ `__TEXT` từ sau header. Bảng section:

| segment | section | file offset | size | trong vùng mã hoá |
| --- | --- | --- | ---: | --- |
| `__TEXT` | *(cả segment)* | 0x0 | 0x2c38000 | không |
| `__TEXT` | `__text` | 0x8000 | 0xfb4574 | **có** |
| `__TEXT` | `__const` | 0x281df80 | 0x2d47e0 | **có** |
| `__TEXT` | `__objc_methname` | 0x2af2760 | 0x1232b | **có** |
| `__TEXT` | `__cstring` | 0x2b0ad40 | 0xaee11 | **có** |
| `__DATA` | *(cả segment)* | 0x2c38000 | 0x304000 | không |
| `__DATA` | `__got` | 0x2c38000 | 0x858 | không |
| `__DATA` | `__const` | 0x2c3b1a0 | 0x160b58 | không |
| `__DATA` | `__cfstring` | 0x2d9bcf8 | 0x8000 | không |
| `__DATA` | `__data` | 0x2dbe170 | 0x17cf3d | không |
| `__DATA` | `__bss` | 0x0 | 0xfb220 | không |
| `__LINKEDIT` | *(cả segment)* | 0x2f3c000 | 0x1ca550 | không |

Ba phép đo độc lập xác nhận vùng đó là ciphertext, không phải mã máy:

| phép đo | vùng mã hoá | `__DATA` | `__LINKEDIT` | header |
|---|---:|---:|---:|---:|
| Shannon entropy trên 64 KB | **7,997** | 3,638 | 5,581 | 5,487 |
| số lệnh `ret` (`0xD65F03C0`) trong 1 MB | **0** | — | — | — |
| `stp x29,x30,[sp,#-N]!` khớp mặt nạ 10 bit | 266/262144 ≈ 0,1% (đúng tỉ lệ ngẫu nhiên) | — | — | — |

Và quyết định hơn cả: các chuỗi tên module mà phép tìm code registration dựa vào **không tồn tại**
trong file:

| chuỗi | số lần xuất hiện trong 51 MB |
|---|---:|
| `mscorlib.dll` | 0 |
| `Assembly-CSharp.dll` | 0 |
| `UnityEngine.CoreModule.dll` | 0 |
| `System.dll` | 0 |

`__cstring` nằm ở file offset `0x2b0ad40`, bên trong vùng mã hoá. Vì `Il2CppCodeGenModule` được
nhận ra qua *tên module*, và tên module là C string trong `__cstring`, nên phép tìm codereg không
thể thành công trên một build bị mã hoá — trong khi metareg, nằm trong `__DATA`, thì tìm được.

Đây là cách một bản App Store được phát hành: `__TEXT` chỉ được kernel giải mã trên thiết bị có
ticket hợp lệ. Sự tồn tại của `SC_Info/JellyBlast.sinf` xác nhận đây là bản tải từ store.
**Không một công cụ phân tích tĩnh nào đọc được vùng này**, và repository không tìm cách giải mã nó.

### Tool giờ báo đúng chỗ

Trước đây lỗi nổi lên ở `Il2CppBinary.Init` dưới dạng "Failed to find code registration or metadata
registration!" — một thông báo không nói gì về nguyên nhân. `MachOFile` giờ đọc
`LC_ENCRYPTION_INFO*` và dừng ngay tại loader:

```
This Mach-O is encrypted: LC_ENCRYPTION_INFO names 0x2C30000 bytes from file offset 0x8000 with
cryptid 1. That range covers __TEXT, so both the code and the C strings the code registration is
found by are ciphertext on disk. This is how an App Store (FairPlay) build is distributed and no
static tool can read it; supply a build that is not store-encrypted, or one decrypted on a device.
```

Đây là nguyên tắc "báo lỗi input tại input, đừng patch tầng dưới để che": vấn đề nằm ở binary loader
nên được nói ở binary loader.

## Fixture này kiểm tra được gì

| tầng pipeline | iOS kiểm tra được | bằng chứng |
|---|---|---|
| Phát hiện cấu trúc game | **có** | `iOSGameStructure.Exists` nhận `Payload/`, log ghi "Files use the 'IL2Cpp' scripting backend" |
| Đọc Unity version từ data directory | **có** | 2022.3.53f1 |
| Container Mach-O: header, load command, segment, section | **có** | "Using binary type Mach-O File (from LibCppIL)", 73 load command, 3 segment, 46 section đọc xong |
| Đọc `LC_ENCRYPTION_INFO_64` | **có** | thông báo ở trên |
| Đọc `global-metadata.dat` v31.1 | **có** | "Initialized Metadata in 278ms" |
| Định vị il2cpp binary trong bundle | **có** | metareg 0x0 → 0x2D234B8 |
| Tìm metadata registration trong `__DATA` | **có** | 0x2D234B8 |
| Tìm code registration | **không** | tên module nằm trong `__cstring` bị mã hoá |
| Bảng codegen module, method pointer | **không** | phụ thuộc codereg |
| Lift mã máy ARM64, ISIL, SSA, type recovery, sinh C# | **không** | `__TEXT` là ciphertext |
| Field offset đo từ binary, field layout self-check | **không** | phụ thuộc codereg |

Nói cách khác: fixture này kiểm tra được **nửa đầu** của pipeline trên iOS, và nửa sau thì không.
Không được báo iOS là PASS cho những dòng "không" ở trên.

## Cần gì để kiểm tra nửa sau trên iOS

Một trong hai:

1. Một bản build iOS **không bị store mã hoá** — ad-hoc, development, hoặc TestFlight trước khi
   store ký lại — của một game IL2CPP. Lý tưởng nhất là cùng project với một bản Android để so sánh
   C# sinh ra theo từng method.
2. Một bản đã được giải mã trên thiết bị. Repository không làm việc này và không hướng dẫn làm.

Cho tới khi có một trong hai, mọi thay đổi chạm vào lift ARM64, frame/stack, hay type recovery chỉ
có thể kiểm chứng chéo trên hai fixture Android/ELF hiện có (Impostor ARM64 v31.1, Pinata x86
v24.2), và trạng thái iOS của những thay đổi đó phải ghi là `KHÔNG KIỂM TRA ĐƯỢC` chứ không phải
`PASS`.

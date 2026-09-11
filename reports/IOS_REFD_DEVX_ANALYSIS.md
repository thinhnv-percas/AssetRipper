# Audit branch `ref/devx`

Bắt buộc làm trước khi viết code iOS mới. Kết quả: `ref/devx` **có** phần liên quan trực tiếp, và
nó đã sửa một kết luận sai của iteration 033.

## 0. CLAUDE.md nói sai về branch này

CLAUDE.md (mục "The `ref/devx` branch") ghi:

> `ThinhNV-x-Percas/devx-decompile`, branch `ref/devx`, contains the IL2Cpp runtime struct database
> (742 layout files) and `tools/structdb_gen.py`, and nothing else. **It has no decompiler code.**
> Its contents are already absorbed into `StructDb/`; there is nothing further to take from it.

Cả ba mệnh đề đều sai:

1. **Branch nằm trong chính repository này**, không phải ở repo khác: `origin/ref/devx`, 39 commit,
   20473 file. Phiên trước không thấy vì clone ban đầu chỉ nạp `main` và branch làm việc; phải
   `git fetch origin 'refs/heads/*:refs/remotes/origin/*'` mới hiện ra. Cùng lúc đó hiện thêm bảy
   branch khác chưa từng được nhắc: `origin/master`, `claude/decompile-iso-support-loglnw`,
   `claude/il2cpp-csharp-unity-gui-8p1fyk`, `claude/tool-gui-unity-preview-coemaf`,
   `claude/package-cache-shader-match-ktkpii`, `claude/codegraph-csharp-setup-07l07b`,
   `claude/convert-project-python-6mee7g`.
2. **Nó có rất nhiều code decompiler** — một bản dựng lại của DevXUnity-Unpacker (37 project), kèm
   dnSpy, ICSharpCode.Decompiler, Mono.Cecil, dnlib.
3. **Còn nhiều thứ để lấy** — xem mục 3.

CLAUDE.md đã được sửa ở iteration 034.

## 1. Những gì `ref/devx` chứa

| | |
|---|---|
| `Recovered/` | DevXUnityUnpacker được decompile và dựng lại, 8/8 assembly build 0 error |
| `IL2CPP-PIPELINE.md` | 734 dòng, tiếng Việt — DevX làm gì, từng bước, file:line vào `Recovered/` |
| `IL2CPP-REBUILD-GUIDE.md` | 1795 dòng, tiếng Việt — **tự viết lại thì dùng lib nào, code ra sao** |
| `FINDINGS.md` | 544 dòng — phân tích lớp bảo vệ của chính DevX (XOR keystream, stream cipher 16 bit) |
| `ROADMAP.md`, `BUILD.md` | trạng thái build và cách tái lập |
| `structdb/`, `typetreedb/`, `tools/` | phần đã được hấp thu vào `StructDb/` |

## 2. Commit và file liên quan trực tiếp tới iOS

| | |
|---|---|
| `Recovered/DevXUnityUnpackerTools/DMP4/-.cs` | Mach-O reader của DevX, có `LC_ENCRYPTION_INFO*` |
| dòng 1766 | `case 44u:` (`LC_ENCRYPTION_INFO_64`) → `"WARNING: Mach64-O section - is encrypted (LC_ENCRYPTION_INFO_64 and cannot be processed)"` |
| dòng 1773 | `case 33u:` (`LC_ENCRYPTION_INFO`) → `"ERROR: This Mach64-O executable is encrypted and cannot be processed."` |
| dòng 1445 | bản 32-bit → `"ERROR: This Mach32-O executable is encrypted and cannot be processed."` |
| dòng 2025, 2037 | `public uint cryptid;` — hai struct, 32 và 64 bit |
| `IL2CPP-REBUILD-GUIDE.md` §6 | **tìm CodeRegistration bằng quét có ràng buộc đếm** — mục quan trọng nhất |
| `IL2CPP-REBUILD-GUIDE.md` §5.3 | Mach-O: tự viết ~200 dòng, xử lý FAT |
| `IL2CPP-REBUILD-GUIDE.md` §10.2 | `arm64-apple-ios` là một target của struct DB generator |

## 3. Code/kiến thức tái sử dụng được

### 3a. Quét code registration theo ràng buộc đếm — ĐÃ DÙNG, và nó sửa kết luận của 033

`IL2CPP-REBUILD-GUIDE.md` §6 nói rõ:

> Hai struct này giữ toàn bộ con trỏ hàm nhưng **không có symbol**. Phương pháp đáng tin nhất không
> phải "quét mù" mà là **quét có ràng buộc đếm**: bạn đã biết chính xác số image, số type, số method
> từ metadata, và các struct này chứa đúng những con số đó.
>
> * `Il2CppCodeRegistration.codeGenModulesCount == metadata.Images.Length`
> * `Il2CppMetadataRegistration.typeDefinitionsSizesCount == metadata.TypeDefs.Length`

LibCpp2IL dùng cách này cho **metadata** registration (`BinarySearcher` dòng 328,
`FindAllMappedWords((ulong)typeDefinitionsCount)`) nhưng **không** dùng cho **code** registration:
`FindCodeRegistrationPost2019` bắt đầu từ `FindAllStrings("mscorlib.dll\0")`.

Đó chính xác là lý do iteration 033 kết luận codereg không thể tìm được trên bản mã hoá — chuỗi tên
module nằm trong `__cstring` bị mã hoá. Kết luận ấy **sai**: struct thì nằm trong `__DATA` không mã
hoá, và số đếm thì metadata đã cho.

Đã cài `BinarySearcher.FindCodeRegistrationByModuleCount` làm fallback. Kết quả trên Jelly Blast:

```
trước: Got Binary codereg: 0x0,       metareg: 0x2D234B8
sau:   Got Binary codereg: 0x2C723A8, metareg: 0x2D234B8
```

Và struct tìm được là thật, đọc từng field xác nhận: 30 reverse P/Invoke wrapper, 45816 generic
method pointer, 10020 invoker pointer, 1891 unresolved virtual call, 541 interop data entry, 0
WinRT (đúng cho iOS), `codeGenModulesCount = 57` với bảng 57 con trỏ map được hết.

### 3b. DevX cũng dừng ở chỗ mã hoá — xác nhận độc lập

DevXUnity-Unpacker là sản phẩm thương mại, và nó **không giải mã**: đọc `LC_ENCRYPTION_INFO*`, thấy
`cryptid` khác 0 thì log cảnh báo rồi đi tiếp (bản 64-bit) hoặc báo lỗi (bản 32-bit). Đây là xác
nhận độc lập rằng việc lấy plaintext không thuộc phạm vi một công cụ phân tích tĩnh phía host.

Một chi tiết đáng học: DevX **cảnh báo rồi tiếp tục** ở nhánh 64-bit. Iteration 033 của repo này
`throw`, và như thế mất luôn cả phần `__DATA` đọc được. Đã sửa theo hướng của DevX.

### 3c. Bẫy đã ghi trong guide, chưa gặp nhưng cần biết

`IL2CPP-REBUILD-GUIDE.md` dòng 543: một `.so` **dump từ RAM** có `VA == file offset` và `p_offset`
bị ghi đè; Il2CppDumper gọi trường hợp này là `IsDumped` và khi đó phải hỏi người dùng base address
lúc dump. Điều này sẽ thành liên quan ngay khi có một plaintext binary lấy từ thiết bị.

## 4. Code bị thiếu trong `ref/devx`

Không có gì trong `ref/devx` giải quyết việc **lấy plaintext** từ một bản đã mã hoá. Không có
Frida script, không có `DumpDecrypted`, không có `bfdecrypt`. Nó chỉ phát hiện và báo.

## 5. Code có bug

Không phát hiện bug trong phần Mach-O của `ref/devx`. Bản đọc `LC_ENCRYPTION_INFO_64` của nó
(`base.Position += 8uL; if (ReadUInt32() != 0)`) đọc đúng cryptoff + cryptsize rồi cryptid, cùng
cấu trúc với bản đã cài ở đây.

## 6. Code cần merge/cherry-pick

Không cherry-pick gì. `ref/devx` là một codebase khác (.NET Framework, WPF, Mono.Cecil) không tương
thích với AssetRipper (.NET 10, AsmResolver, LibCpp2IL). Phần lấy được là **kiến thức**, đã port tay:
phương pháp quét theo ràng buộc đếm, và cách xử lý binary mã hoá bằng cảnh báo thay vì dừng.

## 7. Chỉ là experiment

Toàn bộ `Recovered/` là kết quả của một phiên reverse engineering DevX, không phải code sản phẩm
của repo này. Không dùng trực tiếp.

## 8. Đề xuất kiến trúc

```
IPA
 ↓ iOSGameStructure               Payload/*.app, Frameworks/UnityFramework.framework  (DECOMP-0021)
 ↓ MachOFile                      header, load command, section; LC_ENCRYPTION_INFO -> CẢNH BÁO, đi tiếp
 ↓ Il2CppMetadata                 global-metadata.dat, không bị mã hoá
 ↓ BinarySearcher                 metareg: quét theo typeDefinitionsSizesCount
 ↓                                codereg: quét theo mscorlib.dll, nếu trượt thì theo codeGenModulesCount
 ↓ Il2CppBinary.Init              mọi lần đọc dữ liệu có thể là ciphertext phải có biên, không throw
 ↓ [nếu __TEXT mã hoá]            method pointer = 0; phần khai báo và field offset vẫn phục hồi
 ↓ [nếu có plaintext]             lift mã máy, type recovery, sinh C# như Android
```

Nguyên tắc: **mọi giá trị đọc ra từ một vùng có thể không đọc được đều phải có biên kiểm tra**, và
thất bại phải là một cảnh báo có nội dung chứ không phải một exception ở tầng khác.

# Nghiên cứu iOS IL2CPP

Trả lời câu hỏi: một bản iOS IL2CPP bị store mã hoá thì phục hồi được đến đâu, và ranh giới nằm
chính xác ở chỗ nào. Kết luận quan trọng nhất: **ranh giới nằm xa hơn nhiều so với kết luận của
iteration 033**, và chính việc audit `ref/devx` là thứ phát hiện ra điều đó.

## 1. `ref/devx`

### Branch
`origin/ref/devx` — **trong chính repository này**, 39 commit, 20473 file. CLAUDE.md ghi nó ở một
repo khác và "không có code decompiler"; cả hai đều sai, đã sửa. Phải
`git fetch origin 'refs/heads/*:refs/remotes/origin/*'` mới thấy.

### Implementation
`Recovered/DevXUnityUnpackerTools/DMP4/-.cs` có Mach-O reader đọc `LC_ENCRYPTION_INFO` (case 33) và
`LC_ENCRYPTION_INFO_64` (case 44), cùng hai struct `cryptid`.
`IL2CPP-REBUILD-GUIDE.md` §6 mô tả **quét code registration theo ràng buộc đếm**.

### Kết quả
Hai thứ lấy được, chi tiết ở `reports/IOS_REFD_DEVX_ANALYSIS.md`:
1. Phương pháp quét theo `codeGenModulesCount == metadata.Images.Length` — **không cần chuỗi nào**.
   Đã cài, và nó tìm được codereg trên bản mã hoá.
2. Cách xử lý binary mã hoá: **cảnh báo rồi tiếp tục**, không dừng. DevX làm vậy; iteration 033 của
   repo này `throw` và mất luôn phần `__DATA` đọc được.

## 2. Git history

Bảy branch nữa chưa từng được nhắc trong bất kỳ tài liệu nào của repo:
`origin/master`, `claude/decompile-iso-support-loglnw`, `claude/il2cpp-csharp-unity-gui-8p1fyk`,
`claude/tool-gui-unity-preview-coemaf`, `claude/package-cache-shader-match-ktkpii`,
`claude/codegraph-csharp-setup-07l07b`, `claude/convert-project-python-6mee7g`.
Grep cả bảy cho `cryptid|LC_ENCRYPTION|fairplay|frida|dumpdecrypt|bfdecrypt`: **không branch nào có
code xử lý binary iOS mã hoá**. Các kết quả khớp đều là binary dll/exe vendored, không phải source.

## 3. Upstream AssetRipper

`iOSGameStructure` có sẵn trong upstream và nhận đúng layout `Payload/*.app`, nhưng trỏ
`Il2CppGameAssemblyPath` vào app executable — sai từ Unity 2019.3 (DECOMP-0021, iteration 033).
`LibCpp2IL/MachO/` có sẵn 26 file, đọc được header/load command/section/chained fixups, và
`LoadCommandId` **biết** `LC_ENCRYPTION_INFO*` nhưng không có gì đọc chúng (DECOMP-0021 bổ sung).
`FindCodeRegistrationPost2019` chỉ có một đường: từ chuỗi `mscorlib.dll` (DECOMP-0023 bổ sung
đường thứ hai).

## 4. Public implementations

Không có truy cập web trong container này, nên phần này dựa trên những gì `ref/devx` ghi lại và
những gì đọc được từ chính source trong repo. Ba hướng được nhắc trong yêu cầu — `frida-ios-dump`,
`DumpDecrypted`, `bfdecrypt` — đều là **acquisition phía thiết bị**: chúng lấy plaintext từ bộ nhớ
tiến trình sau khi kernel đã giải mã, rồi ghi lại một Mach-O với `cryptid` về 0. Không cái nào là
thuật toán giải mã phía host, và repo này không cài cũng không hướng dẫn cài chúng.

Điểm kiến trúc rút ra và đã áp dụng: **tách acquisition khỏi parser**. Parser phía host chỉ cần
nhận thêm một input là một Mach-O `cryptid = 0`; nó không cần biết plaintext từ đâu ra.

## 5. UnityFramework

Từ Unity 2019.3, player nằm trong `Frameworks/UnityFramework.framework/UnityFramework`. Trên fixture
Jelly Blast: 51.406.160 byte, chuỗi `il2cpp` xuất hiện 243 lần. App executable
`Payload/JellyBlast.app/JellyBlast` là launcher 70.896 byte, `il2cpp` xuất hiện 0 lần. Đây là
DECOMP-0021 và là regression test bắt buộc.

## 6. Mach-O encryption

```
LC_ENCRYPTION_INFO_64   cryptoff = 0x8000   cryptsize = 0x2C30000   cryptid = 1
```

Vùng `0x8000 .. 0x2C38000` là đúng toàn bộ `__TEXT` từ sau header. Bằng chứng là ciphertext:
entropy 7,997/8 (so với 3,638 ở `__DATA`), **0 lệnh `ret`** trong 1 MB, tỉ lệ khớp mặt nạ prologue
đúng bằng tỉ lệ ngẫu nhiên, và các chuỗi `mscorlib.dll` / `Assembly-CSharp.dll` xuất hiện **0 lần**
trong cả 51 MB.

**Ranh giới thật, đo từng con trỏ** — đây là phần iteration 033 nói chưa đủ chính xác:

| bảng | địa chỉ | section | đọc được? |
|---|---|---|---|
| `Il2CppCodeRegistration` | 0x2C723A8 | `__DATA` | **có** |
| `Il2CppMetadataRegistration` | 0x2D234B8 | `__DATA` | **có** |
| `addrCodeGenModulePtrs` | 0x2DF6468 | `__DATA` | **có** |
| `genericClasses` | 0x2CA3430 | `__DATA` | **có** |
| `genericInsts` | 0x2CC1918 | `__DATA` | **có** |
| `types` | 0x2D44778 | `__DATA` | **có** |
| `fieldOffsets` | 0x2DD4488 | `__DATA` | **có** |
| `typeDefinitionsSizes` | 0x2DE5478 | `__DATA` | có địa chỉ, **giá trị vẫn sai** — xem mục 10 |
| `genericMethodTable` | 0x296B40C | `__TEXT.__const` | **không** |
| `methodSpecs` | 0x28C5E78 | `__TEXT.__const` | **không** |
| tên codegen module | `__cstring` | `__TEXT` | **không** |
| thân method | `__text` | `__TEXT` | **không** |

Chỉ hai trong tám bảng của metareg nằm trong vùng mã hoá, và cả hai là bảng generic sharing.

## 7. Decrypted binary workflow

Kiến trúc phải nhận hai input riêng biệt và **xác minh chúng tương ứng** trước khi chạy:

```
IPA đã mã hoá  +  Mach-O plaintext tương ứng
```

Kiểm tra bắt buộc trước khi coi là cùng một binary — chưa cài, vì chưa có plaintext để test:

| kiểm tra | nguồn |
|---|---|
| `LC_UUID` giống nhau | load command 0x1B |
| `cputype` / `cpusubtype` | header |
| Mach-O file type | header |
| số load command, layout segment/section | header |
| `cryptid = 0` ở bản plaintext | `LC_ENCRYPTION_INFO*` |
| metadata tương thích: image count, type count | so với `global-metadata.dat` |
| codereg/metareg tìm được và các count khớp metadata | `BinarySearcher` |

Nếu `LC_UUID` khác nhau thì phải báo `PLAINTEXT_BINARY_MISMATCH` và **không** chạy full decompile.
Lưu ý: một số công cụ dump phía thiết bị có sửa header, nên UUID khác không tự động nghĩa là sai
binary — nhưng khi đó phải có bằng chứng khác (count khớp metadata) trước khi tiếp tục.

## 8. Kiến trúc đề xuất

Xem `reports/IOS_REFD_DEVX_ANALYSIS.md` mục 8. Nguyên tắc: **mọi giá trị đọc từ một vùng có thể
không đọc được đều phải có biên kiểm tra**, và thất bại là một cảnh báo có nội dung chứ không phải
một exception ở tầng khác. Bốn chỗ trong LibCpp2IL vi phạm nguyên tắc đó và đã sửa ở iteration 034:

| chỗ | trước | sau |
|---|---|---|
| `Il2CppBinary.Init`, adjustor thunk | `Max(adjustorThunk)` của bảng ciphertext → `OutOfMemoryException` | chặn theo số generic method pointer, cảnh báo, bỏ qua |
| `Il2CppBinary.Init`, generic method table | index âm → `ArgumentException` | bỏ qua entry ngoài biên, đếm và cảnh báo |
| `GetCodegenModuleByName` | `_dict[name]` → `KeyNotFoundException` | `GetValueOrDefault`, trả null (kiểu trả về vốn đã nullable) |
| `GetMethodPointer` | `_codeGenModuleMethodPointers[-1]` → `IndexOutOfRangeException` | trả 0 = "không biết địa chỉ thân hàm" |
| `NewArm64Utils.GetArm64MethodBodyAtVirtualAddress` | map VA 0 → `Exception` | trả rỗng |

## 9. Những gì đã xác minh

| | trạng thái | bằng chứng |
|---|---|---|
| IPA extraction | PASS | `Test/Scripts/download_test_inputs.sh ios` |
| `.app` discovery | PASS | `iOSGameStructure.Exists` nhận `Payload/` |
| UnityFramework discovery | PASS | DECOMP-0021, metareg 0x0 → 0x2D234B8 |
| Mach-O parsing | PASS | "Using binary type Mach-O File", 73 load command, 3 segment, 46 section |
| encryption detection | PASS | cảnh báo nêu đúng cryptoff/cryptsize/cryptid |
| metadata extraction | PASS | "Using actual IL2CPP Metadata version 31.1", 307ms |
| metadata registration | PASS | 0x2D234B8, mọi count khớp |
| **code registration** | **PASS** | **0x2C723A8, tìm bằng module count, 57 con trỏ map được hết** |
| **binary initialisation** | **PASS** | "Initialized Binary in 78ms" |
| lớp recovery của AssetRipper chạy | PASS | "14 assemblies will be attempted, 43 framework assemblies will be stubbed" |
| chẩn đoán đúng khi không có mã máy | PASS | "no methods with native code were found in the game's own assemblies" |
| không có exception nào thoát ra | PASS | không còn OOM / ArgumentException / KeyNotFound / IndexOutOfRange |

## 10. Những gì chưa xác minh

1. **`typeDefinitionsSizes` cho giá trị vô lý** dù nằm trong `__DATA`:
   `InstanceSize=2249170484, NativeSize=1619002878` cho `Mono.ValueTuple`. Con trỏ ở 0x2DE5478
   thuộc `__DATA` nên đáng lẽ đọc được. Hai giả thuyết, chưa phân định:
   (a) metareg là một false positive khớp đúng count nhưng không phải struct thật;
   (b) `ApplyChainedFixups` không phủ trang chứa con trỏ này, nên con trỏ còn ở dạng encoded — lưu ý
   `DYLD_CHAINED_PTR_64_OFFSET` đang được xử lý y như `DYLD_CHAINED_PTR_64`, đúng chỉ khi image base
   bằng 0 (ở fixture này `__TEXT` vmaddr = 0 nên trùng, nhưng đó là may).
   Đây là việc tiếp theo của nhánh iOS.
2. **Phần khai báo chưa xuất ra được**: 1495/1496 file vẫn là dummy class, vì lỗi ở (1) vẫn chặn
   assembly manager. Khi (1) xong thì phải đo lại — kỳ vọng là toàn bộ type/member/field offset.
3. **Toàn bộ nửa sau pipeline trên iOS**: lift mã máy, type recovery, sinh C#, field layout
   self-check. Cần một bản plaintext. `BLOCKED_BY_ENCRYPTION`, không phải decompiler bug.
4. **Tương ứng UUID giữa encrypted và plaintext**: chưa cài, chưa có plaintext để test.
5. **Cách xử lý `IsDumped`** (VA == file offset, `p_offset` bị ghi đè) mà
   `IL2CPP-REBUILD-GUIDE.md` dòng 543 cảnh báo: sẽ thành liên quan ngay khi có plaintext từ thiết bị.

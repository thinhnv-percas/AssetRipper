# iOS `typeDefinitionsSizes` — truy vết con trỏ đầu-cuối

Iteration 035. Fixture: `Test/Input/JellyBlast` (Jelly Blast 1.1, IPA từ release asset), Unity
2022.3.53f1, metadata v31.1, ARM64.

Mục tiêu: phân định hai giả thuyết đã ghi ở `AGENT_STATE.md` mục (0) về giá trị
`InstanceSize=2249170484`:

- **(A)** candidate `Il2CppMetadataRegistration` là false positive, khớp đúng count một cách tình cờ.
- **(B)** `MachOFile.ApplyChainedFixups` sai, nên con trỏ còn ở dạng encoded.

**Kết luận: cả hai đều sai.** Nguyên nhân thật là một giả thuyết thứ ba (C): registration đúng, binary
này *không có* chained fixups, và payload mà `typeDefinitionsSizes` trỏ tới nằm trong vùng FairPlay
mã hoá.

---

## 1. Audit `ref/devx` (bắt buộc trước khi viết lại Mach-O logic)

```
git fetch origin 'refs/heads/*:refs/remotes/origin/*'
git grep -n -i "ApplyChainedFixups"        origin/ref/devx   → 0 kết quả
git grep -n -i "DYLD_CHAINED_PTR_64"       origin/ref/devx   → 0 kết quả
git grep -n -i "DYLD_CHAINED_PTR_64_OFFSET" origin/ref/devx  → 0 kết quả
git grep -n -i "LC_DYLD_CHAINED_FIXUPS"    origin/ref/devx   → 0 kết quả
git grep -n -i "dyld_chained"              origin/ref/devx   → 0 kết quả
git grep -n -i "chained fixup"             origin/ref/devx   → 0 kết quả
```

**`ref/devx` không có một dòng nào về chained fixups.** `IL2CPP-REBUILD-GUIDE.md` §5.3 chỉ nói:

> Tự viết là hợp lý: đọc `mach_header(_64)`, duyệt `LC_SEGMENT_64`, mỗi `section_64` cho
> `(addr, size, offset)`. Nếu là FAT (`0xCAFEBABE` big-endian), đọc `fat_header` → chọn `cputype`
> bạn cần rồi đệ quy vào offset của slice.

Tức là DevX đọc segment/section và dừng ở đó — không rebase gì cả. Đây là giới hạn đã biết của nó,
khớp với phát hiện ở iteration 033 rằng nó cũng chỉ *cảnh báo* với `LC_ENCRYPTION_INFO`.

**Một thứ `ref/devx` có và đáng lấy**: `Recovered/DevXUnityUnpackerTools/DMP4/Il2Cpp.cs` dòng 262–274
cho thấy `typeDefinitionsSizes` là **bảng con trỏ**, không phải mảng struct inline:

```csharp
ulong[] array2 = MapVATR<ulong>(pMetadataRegistration.typeDefinitionsSizes,
                               pMetadataRegistration.typeDefinitionsSizesCount);
typeDefinitionsSizes = new Il2CppTypeDefinitionSizes[array2.Length];
for (int i = 0; i < array2.Length; i++)
    typeDefinitionsSizes[i] = array2[i] == 0
        ? new Il2CppTypeDefinitionSizes()
        : MapVATR<Il2CppTypeDefinitionSizes>(array2[i]);
```

Đã kiểm tra: AssetRipper (`Il2CppBinary.cs:186` + `Il2CppTypeDefinition.RawSizes`) **đã làm đúng như
vậy**. Nên đây không phải nguồn lỗi. Ghi lại vì đây là điểm dễ sai và việc nó đúng đã được xác nhận.

Dòng 79–92 của cùng file còn có `AutoCorrect_codeRegistration_test` — một bộ kiểm tra tính hợp lý
nhiều field cho `Il2CppCodeRegistration` (mỗi count phải `> 0 && < 1000` hoặc `== 0`, mỗi pointer
tương ứng phải `> 100000`). Cùng ý tưởng với "validate nhiều field" mà brief yêu cầu; cách làm ở
mục 3 dưới đây mạnh hơn vì kiểm tra cả việc con trỏ có map được và có đúng stride hay không.

---

## 2. Binary này không có chained fixups

Liệt kê load command của
`Payload/JellyBlast.app/Frameworks/UnityFramework.framework/UnityFramework`:

```
SEG __TEXT         vm 0x00000000..0x02C38000  file 0x00000000 len 0x02C38000
SEG __DATA         vm 0x02C38000..0x03290000  file 0x02C38000 len 0x00304000
SEG __LINKEDIT     vm 0x03290000..0x0345C000  file 0x02F3C000 len 0x001CA550

LC 0x00000019 SEGMENT_64         ×3
LC 0x80000022 DYLD_INFO_ONLY     size 48
LC 0x00000002 SYMTAB
LC 0x0000000B DYSYMTAB
LC 0x0000002C ENCRYPTION_INFO_64 size 24
LC 0x0000001D CODE_SIGNATURE
```

**Không có `LC_DYLD_CHAINED_FIXUPS` (0x80000034).** Binary dùng `LC_DYLD_INFO_ONLY` — opcode
rebase/bind cổ điển. `ApplyChainedFixups` **không bao giờ chạy** trên fixture này, nên giả thuyết (B)
không thể là nguyên nhân.

Với `LC_DYLD_INFO_ONLY`, con trỏ trên đĩa mang đúng địa chỉ ảo link-time; `__TEXT` ở vm 0 nên image
base là 0 và trong `__DATA` thì **VA == file offset**. Không cần biến đổi gì để đọc.

`LC_ENCRYPTION_INFO_64`: `cryptoff=0x8000`, `cryptsize=0x2C30000`, `cryptid=1` → phủ
`0x8000..0x2C38000`, tức **toàn bộ `__TEXT`** trừ trang header.

---

## 3. Validate `Il2CppMetadataRegistration` bằng nhiều field

Candidate: VA `0x2D234B8` → file `0x2D234B8`, nằm trong `__DATA.__const`.

| Field | Count | Pointer | Segment / section | Đọc được? |
|---|---:|---|---|---|
| genericClasses | 7077 | `0x2CA3430` | `__DATA.__const` | có |
| genericInsts | 4220 | `0x2CC1918` | `__DATA.__const` | có |
| genericMethodTable | 45952 | `0x296B40C` | `__TEXT.__const` | **mã hoá** |
| types | 25590 | `0x2D44778` | `__DATA.__const` | có |
| methodSpecs | 56439 | `0x28C5E78` | `__TEXT.__const` | **mã hoá** |
| fieldOffsets | 8702 | `0x2DD4488` | `__DATA.__data` | bảng đọc được |
| typeDefinitionsSizes | 8702 | `0x2DE5478` | `__DATA.__data` | bảng đọc được |
| metadataUsages | 0 | `0x0` | — | n/a (đúng cho v27+) |

Bằng chứng candidate **đúng**, không phải false positive:

1. `fieldOffsetsCount == typeDefinitionsSizesCount == 8702 == metadata.TypeDefinitionCount`. Hai
   field độc lập khớp cùng một con số từ file metadata.
2. Mọi pointer khác 0 đều map được vào một section thật và đều aligned 4.
3. `metadataUsages == 0` đúng với v31.1 — một candidate ngẫu nhiên không có lý do gì cho ra 0 ở
   đúng field duy nhất được phép bằng 0.
4. **Quyết định**: bảng `typeDefinitionsSizes` đọc ra 8702 con trỏ, **không có con trỏ 0 nào**, tăng
   đơn điệu, **bước đúng 0x10 byte** — bằng chính `sizeof(Il2CppTypeDefinitionSizes)` (4 × uint32):

   ```
   [  0] 0x00000000028997F4   __TEXT.__const
   [  1] 0x0000000002899804
   [  2] 0x0000000002899814
   ...
   [ 11] 0x00000000028998A4
   min 0x28997F4   max 0x28BB7C4   zeros 0
   ```

   `0x28BB7C4 - 0x28997F4 = 0x21FD0 = 8701 × 0x10`. Một bảng ngẫu nhiên không có hình dạng này.

Giả thuyết (A) bị loại.

---

## 4. Truy vết đầu-cuối

```
raw bytes                 16 byte tại file offset 0x28997F4:
                          53 dc aa 72 8c e5 ad e5 9c c9 9a ba 9e fc f2 6f
Mach-O file offset        0x28997F4
virtual address           0x28997F4        (__TEXT: vm 0 == file 0, nên VA == offset)
segment                   __TEXT   (vm 0x00000000..0x02C38000)
section                   __TEXT.__const
chained fixup             KHÔNG CÓ — binary dùng LC_DYLD_INFO_ONLY
rebased pointer           không cần rebase; giá trị trên đĩa đã là VA
MetadataRegistration      0x2D234B8, đã validate ở mục 3
typeDefinitionsSizes      bảng ở 0x2DE5478, entry [0] = 0x28997F4  ← ĐÚNG
InstanceSize              đọc 4 byte đầu của 16 byte trên → 1923800147
```

Mắt xích đứt nằm ở bước cuối: **địa chỉ đích `0x28997F4` nằm trong `0x8000..0x2C38000`**, tức trong
vùng `LC_ENCRYPTION_INFO_64` khai báo. 16 byte đó là ciphertext.

Ba phép đo phân biệt ciphertext với dữ liệu thật, không cần khoá:

| Vùng | VA | Trong vùng mã hoá | Entropy (0x20000 byte) |
|---|---|---|---|
| `typeDefinitionsSizes[0]` target | `0x28997F4` | có | **7.999** / 8 |
| `methodSpecs` target | `0x28C5E78` | có | **7.999** |
| `genericMethodTable` target | `0x296B40C` | có | **7.999** |
| `genericClasses` target | `0x2CA3430` | không | 3.175 |
| `genericInsts` target | `0x2CC1918` | không | 4.195 |
| `types` bảng | `0x2D44778` | không | 3.767 |

Chênh lệch entropy 7.999 so với 3.2–4.2 là dứt khoát. `types` còn trỏ tiếp vào `__DATA.__data`
(`0x2E55DD0`…), nên **bảng type đọc được trọn vẹn** — đó là lý do lớp recovery vẫn chạy và mọi
declaration vẫn ra được.

`fieldOffsets` cùng hình dạng: bảng ở `__DATA.__data` đọc tốt, nhưng target (`0x2876568`…) nằm trong
`__TEXT` → mã hoá. `Il2CppBinary.GetFieldOffsetFromIndex` đọc offset **tại** con trỏ đó, nên mọi
field offset trên input này là ciphertext.

---

## 5. Sửa ở đúng layer

Không sửa symptom. Không có `if (InstanceSize > X) ignore`. Phép kiểm tra là **provenance của địa
chỉ**, không phải tính hợp lý của giá trị:

**Layer Mach-O** — `MachOFile.IsVirtualAddressEncrypted(ulong)`, và
`Il2CppBinary.IsVirtualAddressEncrypted` trả `false` cho mọi format không thể mã hoá. Map qua
*segment* chứ không qua section: segment mới là thứ mang mapping file↔memory, và một byte nằm trong
segment nhưng ngoài mọi section thì vẫn bị mã hoá. Một offset vượt `FileSize` (vùng zero-fill) không
nằm trên đĩa nên không thể là ciphertext.

**Layer metadata** — `Il2CppTypeDefinition.RawSizesAreReadable`;
`Il2CppBinary.CountEncryptedFieldOffsetTables()`; và `GetFieldOffsetFromIndex` trả `-1` khi con trỏ
nằm trong vùng mã hoá. `-1` đã là sentinel "không biết" của chính hàm đó từ trước, nên đây không
phải case đặc biệt mới — nó là câu trả lời trung thực. Đọc bytes rồi coi là offset sẽ xếp mọi field
của type vào vị trí ngẫu nhiên mà không gì ở phía sau phát hiện được.

**Layer output** — `AsmResolverDllOutputFormat.ConfigureTypeSize` bỏ qua và đếm, thay vì `throw`
`Got invalid size`. Kiểm tra `Size > 1 << 30` cũ là kiểm tra *giá trị*: nó bắt được ciphertext lớn và
bỏ sót ciphertext nhỏ, cả hai đều sai lý do.

**Layer báo cáo** — `Il2CppRecoveryDiagnosticsProcessingLayer.ReportEncryptedRegions`. Cần thiết vì
`AssetRipper.Import/Logging/Logger.cs:16` map **mọi** warning của Cpp2IL sang `LogType.Verbose`, nên
cảnh báo Mach-O mã hoá thêm ở iteration 033 chưa từng xuất hiện trong log. Một chẩn đoán không ai đọc
được thì không phải chẩn đoán.

---

## 6. Hai defect chained-fixup thật, tìm được nhờ đọc spec

Fixture này không có chained fixups, nhưng code xử lý chúng có hai lỗi thật, nên sửa kèm theo test.

**6.1 `DYLD_CHAINED_PTR_64_OFFSET` bị xử lý y như `DYLD_CHAINED_PTR_64`.** Hai format khác nhau đúng
một điểm. Nguồn đã tra cứu:

| Project | URL | Revision |
|---|---|---|
| Apple dyld | `github.com/apple-oss-distributions/dyld` — `include/mach-o/fixup-chains.h`, `common/MachOLoaded.cpp`, `common/MachOLayout.cpp`, `mach_o/ChainedFixups.cpp` | `main` = `fd8d0c4d52320ebf64db34f3cb280310d905c5ae` (file giống byte-for-byte ở tag `dyld-1378`) |
| LIEF | `github.com/lief-project/LIEF` — `src/MachO/ChainedFixup.cpp`, `src/MachO/BinaryParser.tcc` | `main` = `d005663ac7bfab4feca435d01dfc87667907ce42` |
| LLVM | `github.com/llvm/llvm-project` — `llvm/lib/Object/MachOObjectFile.cpp`, `llvm/include/llvm/BinaryFormat/MachO.h` | `main` = `dc6825047c42442c5e18dd09d260bee983bc5712` |
| blacktop go-macho | `github.com/blacktop/go-macho` — `pkg/fixupchains/` | `master` = `0b3c4a4cb4548a0d1284c1b5fc0de6f4422c0246` |

`fixup-chains.h` dòng 161–169 và enum dòng 96–112:

```c
    DYLD_CHAINED_PTR_64                     =  2,    // target is vmaddr
    DYLD_CHAINED_PTR_64_OFFSET              =  6,    // target is vm offset

struct dyld_chained_ptr_64_rebase
{
    uint64_t    target    : 36,    // 64GB max image size (DYLD_CHAINED_PTR_64 => vmAddr, DYLD_CHAINED_PTR_64_OFFSET => runtimeOffset)
                high8     :  8,    // top 8 bits set to this
                reserved  :  7,    // all zeros
                next      : 12,    // 4-byte stride
                bind      :  1;    // == 0
};
```

`common/MachOLoaded.cpp` dòng 801–823:

```cpp
    // plain rebase (old format target is vmaddr, new format target is offset)
    if ( segInfo->pointer_format == DYLD_CHAINED_PTR_64 )
        newValue = (void*)(fixupLoc->generic64.unpackedTarget()+slide);
    else
        newValue = (void*)((uintptr_t)this + fixupLoc->generic64.unpackedTarget());
```

LLVM `MachOObjectFile.cpp` dòng 3539–3581 nói cùng một điều ngắn hơn:

```cpp
    PointerValue = Target | (High8 << 56);
    if (PointerFormat == MachO::DYLD_CHAINED_PTR_64_OFFSET)
      PointerValue += textAddress();
```

Công thức: `unpackedTarget = (high8 << 56) | target` ở **cả hai** format; `_64` cho VA = chính nó,
`_64_OFFSET` cho VA = `preferredLoadAddress + unpackedTarget`. Hai format trùng nhau trên một dylib
(link ở 0) — `UnityFramework` chính là dylib — nên phải test trên binary có image base khác 0 mới
thấy. Lưu ý `go-macho` corroborate *layout* nhưng **sai semantics** (`fixupchains.go` 746–752 trừ
`preferredLoadAddress` cho cả hai format); và biến thể `unpack_target()` trong header public của
LIEF (`ChainedPointerAnalysis.hpp` 115–117) **thiếu `<< 56`**. Không copy hai chỗ đó.

**6.2 Chain không bị chặn ở biên trang.** `while (true)` với `chainOffset += next * 4` cho phép một
`next` trỏ quá cuối trang chạy sang chain của trang sau và ghi lại những con trỏ đã đúng — im lặng.
Apple giới hạn `next` ≤ `4*0xFFF` = 16380 byte và chain thuộc về một trang; `common/MachOFile.cpp`
1536–1571 duyệt theo từng trang.

Cả hai đều được test bao (mục 7) và cả hai test đều **fail khi revert fix**, đã kiểm tra.

Một điểm *không* phải defect, ghi lại để không sửa nhầm lần nữa: cộng bias vào **giá trị đã compose**
(`(high8 << 56 | target) + base`) so với cộng vào riêng field target (`high8 << 56 | (target + base)`)
cho **cùng kết quả** với mọi image base thực tế, vì bit 36–55 của một giá trị unpacked luôn bằng 0.
Code viết theo thứ tự của spec, nhưng đây không phải sửa lỗi hành vi — test
`TheImageBaseIsAddedToTheComposedValue` pin công thức chứ không bắt collision.

---

## 7. Test — viết trước khi sửa production

`Source/AssetRipper.Tests/MachOChainedFixupTests.cs`, 17 test, dựng Mach-O tổng hợp trong bộ nhớ
(header + `__TEXT` + `__DATA` + `__LINKEDIT` + blob `dyld_chained_fixups`), không phụ thuộc fixture:

| Test | Bao phủ |
|---|---|
| `ChainedPtr64TreatsTargetAsAnAbsoluteAddress` | `_64`, image base ≠ 0 |
| `ChainedPtr64OffsetAddsTheImageBaseToTheTarget` | `_64_OFFSET`, image base ≠ 0 |
| `TheTwoFormatsAgreeWhenTheImageBaseIsZero` | image base = 0, cả hai format |
| `TheImageBaseIsAddedToTheComposedValue` | thứ tự compose/bias |
| `High8OccupiesTheTopByteOfTheRebasedPointer` | high8 |
| `NextIsAStrideInFourByteUnits` | stride ×4, pointer chain |
| `AChainStopsAtNextZeroAndLeavesLaterWordsAlone` | `next == 0` |
| `ABindEntryIsLeftEncodedRatherThanRebasedToZero` | bind ≠ rebase |
| `AnUnknownPointerFormatRebasesNothing` | format lạ |
| `PageStartsAreRelativeToTheSegmentAndScaledByPageSize` | multiple starts |
| `APageMarkedStartNoneIsSkipped` | `DYLD_CHAINED_PTR_START_NONE` |
| `AChainDoesNotRunPastTheEndOfItsPage` | biên trang |
| `AnUnencryptedBinaryReportsNoEncryptedRegion` | không có encryption command |
| `TheEncryptedRegionIsTestedPerAddressRatherThanPerFile` ×2 (base 0 và 0x100000000) | 7 địa chỉ: trước vùng, biên dưới, biên trên, sau vùng, không thuộc segment nào |
| `ACryptIdOfZeroMeansTheRangeIsPlaintext` | bản đã giải mã giữ load command, `cryptid = 0` |
| `AnEncryptedBinaryStillRebasesItsDataSegment` | `__DATA` vẫn xử lý khi `__TEXT` mã hoá |

**Bốn test đầu tiên viết ra là degenerate** và đã sửa: `Rebase(target, 0, 0) == target`, nên dạng
encoded và dạng đã rebase là cùng một số và assertion không phân biệt được gì. Phải cho `high8 ≠ 0`.
Đây đúng là dạng "một pass không bao giờ chạy trông như thế nào" mà `CLAUDE.md` đã ghi, lần này ở
phía test.

---

## 8. Kết quả đo

**iOS (Jelly Blast)** — baseline là iteration 034:

| | 034 | 035 |
|---|---:|---:|
| `Got invalid size` errors | 1 | **0** |
| codereg / metareg | `0x2C723A8` / `0x2D234B8` | không đổi |
| Báo cáo vùng mã hoá trong log | không có | **2 dòng, per-table** |
| field offset tables mã hoá | đọc ciphertext im lặng | **5782/5782 báo unknown** |
| type definition sizes mã hoá | 1 error rồi ciphertext | **8702/8702 báo unknown** |
| field layout self-check | 0 exact / 84 thiếu / 2080 disagree | không còn gì để đo (đúng) |
| method bodies | 0 | 0 (không đổi — `__TEXT` mã hoá) |
| file `.cs` xuất ra | 1496 | 1481 |

1481 thay vì 1496: những type không còn `ClassLayout` giả không còn sinh file riêng. Đây là hệ quả
của việc bỏ kích thước không đọc được, không phải mất dữ liệu.

**Android (Impostor)** — regression, phải giống hệt:

| | baseline | 035 |
|---|---:|---:|
| Mọi file `.cs` recovered | — | **byte-for-byte giống hệt** (md5 toàn bộ 819 file) |
| `Method not found` | 2079 | 2079 |
| generator failures | 0 | 0 |
| shape checks | 16 PASS / 1 SKIP | 16 PASS / 1 SKIP |

`IsVirtualAddressEncrypted` trả `false` trên ELF nên không có đường nào để nhánh Android đổi hành vi;
phép so md5 xác nhận điều đó chứ không chỉ suy luận.

**Test suite**: 296 test, 295 pass, 1 fail có sẵn từ trước
(`GetMainExportID_ValueGreaterThan100000_DebugAssertFails`). Trước đó 279 test — thêm 17 test mới.

---

## 9. Còn lại

Không còn blocker nào ở nhánh iOS *có thể sửa bằng phân tích tĩnh*. Điều còn thiếu là plaintext của
`__TEXT`, và đó là vấn đề acquisition, không phải parser — xem `reports/IOS_RESEARCH.md`. Repository
chỉ cần nhận thêm một input là Mach-O `cryptid = 0`; pipeline hiện tại đã xử lý đúng phần `__DATA` và
nói rõ phần nào không đọc được.

Một việc có thể làm mà chưa làm: `AssetRipper.Import/Logging/Logger.cs:16` map mọi warning của Cpp2IL
sang `LogType.Verbose`. Iteration này đi vòng qua nó bằng cách báo cáo từ phía AssetRipper. Sửa thẳng
dòng đó sẽ làm hiện mọi warning của Cpp2IL cùng lúc, cần đo mức ồn trước — chưa đo, nên chưa sửa.

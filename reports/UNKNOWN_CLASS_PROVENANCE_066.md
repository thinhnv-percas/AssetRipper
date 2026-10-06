# Provenance của class trên iOS và guard khởi tạo class — iteration 066 (§2)

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Baseline `Test/Out65z-*`, kết quả `Test/Out66i-*`. Cả hai đầu đo bằng
script cuối của 066 (`iterations/066/metrics/`).

## 1. Câu hỏi

065 để lại 2510 dòng `UNKNOWN_CLASS_SOURCE` trên JellyBlastV2. 2315 dòng có provenance `[Add]`: toán hạng class
của lookup interface được nạp từ một địa chỉ tính bằng phép cộng. Brief §2 yêu cầu dựng provenance
`page + add + load → metadata usage → Il2CppClass* → interface lookup`, dùng lại luật base trang có sẵn, không
hardcode địa chỉ, không heuristic.

## 2. Tầng đầu tiên sai — PROVEN

Mã iOS (Apple clang) giữ base trang trong một thanh ghi callee-saved và cộng offset trong một lệnh riêng:

```
adrp x8, 0x2E1B000        ; Move v, 0x2E1B000      (base trang)
add  x8, x8, #0x9F0       ; Add  v', v, 0x9F0
ldr  x1, [x8]             ; Move x1, [v' + 0]      (slot usage)
```

Luật base trang của 054 chỉ đọc `[page + k]` khi offset nằm *trong* memory operand. Ở đây offset đứng trong một
`Add` riêng, nên `[v' + 0]` không bao giờ được nhận là usage và class đọc ra không có kiểu.

`MetadataResolver.FindComputedSlotAddresses` đi ngược qua các định nghĩa đơn của một local:
- `Move` từ một immediate căn trang;
- `Move` từ local khác;
- `Add local, imm` hoặc `Add pageImm, imm`.

Đầu ra là địa chỉ tuyệt đối mà local mang, chỉ khi có ít nhất một phép cộng. Một memory operand qua local đó được
đọc như usage tại địa chỉ ấy, qua đúng kiểm tra `NotAUsageSlot` (slot phải ghi được) của 063. Không địa chỉ nào được
viết ra; mọi giá trị đến từ lệnh của chính method.

## 3. Tầng thứ hai lộ ra — guard khởi tạo class

Khi class đã có kiểu, lỗi thân JellyBlastV2 tăng 2599 → 3116 (66b). `'System.Type' to 'nint'` tăng thêm 517 lỗi.
Truy ngược: đây là guard `IL2CPP_RUNTIME_CLASS_INIT` chưa bao giờ được nhận ra trên iOS. Ở 65z nó compile được chỉ
vì class pointer là một số nguyên không kiểu.

```
ldr  w8, [x0, #0xe0]      ; Il2CppClass.cctor_finished_or_no_cctor (int32)
cbnz w8, skip
bl   il2cpp_codegen_runtime_class_init
```

Ba lý do guard này sống sót, mỗi lý do chỉ thấy được khi lý do trước đã sửa:

1. **Test là cả một word, không phải một bit.** `MetadataInitGuardRemover` chỉ biết `And flag, 1` trên byte bitfield.
   Từ Unity 2021, macro là `if (!klass->cctor_finished_or_no_cctor)`. Offset lấy từ bảng đo được
   (`Il2CppClassUsefulOffsets.TryGetOffset("cctor_finished")`, do `Il2CppClassOffsetPatcher` đo từ struct DB).
   Layout không biết thì không nhận gì.
2. **Phần tiếp theo bị nhân đôi vào nhánh init.** Compiler sao `rest` vào sau lời gọi init, nên vùng không bao giờ
   hội tụ. `TryFoldDuplicatedTail` gập khi chứng minh được `rest'` ≡ `rest`: từng lệnh, cùng opcode, cùng
   hằng/callee, local từ ngoài giống hệt, local định nghĩa bên trong ánh xạ 1-1.
3. **Lời gọi init đã bị xoá như code chết, và bản sao đã được rút gọn khác bản gốc.** Ví dụ: phủ định kép ở một
   bên, nhánh đảo ở bên kia. `TryFoldClassInitWordTest` gập chỉ dựa vào danh tính của word: mã sinh ra chỉ đọc
   `cctor_finished_or_no_cctor` ở đúng một chỗ, là macro. Nhánh giữ lại là nhánh "đã khởi tạo", đọc từ phép so sánh
   và mọi `Not` giữa nó với lệnh nhảy. Đọc không được thì không gập. Số lần gập theo luật này được đếm riêng.

Guard method-init (`if (!s_Il2CppMethodInitialized)`) cũng có hai dạng iOS chưa được nhận:
- **Flag store qua base trang:** `[page + 0xAEC] = 1` thay vì `[const] = 1`.
- **Skip arm là phần còn lại của guard trong đã gập:** vùng hội tụ một block xa hơn
  (`TryExciseThroughForwardingBlock`).

Một lần gập có thể để lại block không còn ai tới. Rendering và generator đều đi qua mọi block, nên block chết đọc như
một lời gọi method vẫn làm (`GetViewport<t>` bị chấm FALLBACK vì thế). Chỉ block mà chính pass này làm cho không tới
được mới bị xoá.

## 4. Kết quả — MEASURED (65z → 66i)

| | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 | Pinata | opt-in |
|---|---:|---:|---:|---:|---:|---:|
| `UNKNOWN_CLASS_SOURCE` (dòng) | 0 → 0 | 54 → 54 | 10 → 10 | **2510 → 98** | 141 → 141 | **3072 → 118** |
| Dòng dispatch interface UNRESOLVED | 118 → 116 | 185 → 171 | 68 → 66 | **2582 → 168** | 147 → 147 | **3144 → 188** |
| Usage qua địa chỉ tính (log) | 0 | 0 | 0 | 51252 | 0 | — |
| Guard word `cctor_finished` gỡ | 5021 | 16864 | — | 13657 | — | — |
| ↳ gập qua phần tiếp theo nhân đôi | 0 | 40 | 0 | 442 | 6 | 652 |
| ↳ gập chỉ theo word | 56 | 170 | 15 | 5624 | 200 | 10047 |
| Method-init gỡ qua block chuyển tiếp | 29 | 384 | 44 | 2126 | 28 | 3637 |

Đọc bảng:
- `+E0]` còn lại trong mã: 4 / 12 / 5 / 10 / 0 / 19.
- Hàng "Guard word gỡ" đếm mọi guard có test là word, kể cả guard mà luật cũ cũng gỡ được qua `sawClassInit`. Không
  phải số guard mới.
- Ô "—" là dòng log bị cắt khi trích.

Lấy mẫu dispatch đã giải (JellyBlastV2):
- `DictionaryWrapper.Remove` → `IDictionary.Contains`;
- `ProcessPurchase` → `IPurchaseResult.get_Purchase`.

JellyBlastV2:
- EXACT 3127 → **4349**.
- Placeholder 34947 → **16619**.
- Lỗi thân Roslyn 2599 → 2599. Số không đổi nhưng họ lỗi đổi chỗ, xem `MERGE_ROOM_BODY_ERRORS_066.md` §4.
- Oracle độc lập 0.6862 → **0.7594** (912/1329 → 1013/1334).

## 5. Còn lại — UNKNOWN, và vì sao

- **98 / 118 `UNKNOWN_CLASS_SOURCE` trên iOS.** Chưa phân loại provenance. Không bị ép thành usage.
- **760 / 1309 load flag method-init tuyệt đối còn lại** trên JellyBlastV2 / opt-in. Phần lớn là `([X] & 1) != 0` có
  vùng không đạt điều kiện gỡ. Chưa đọc từng vùng.
- **Merge-Room 54 `UNKNOWN_CLASS_SOURCE` không đổi.** Đó là các dạng 065 đã giải thích (`TWO_LOADS_OTHER`,
  `METHOD_POINTER` có merge bất đồng). Luật 066 không áp dụng cho chúng.

## 6. Test

`Il2CppIteration066Tests`:
- gập qua phần tiếp theo nhân đôi;
- gập chỉ theo word, đếm đúng luật;
- giữ đúng nhánh khi phân cực đảo;
- word ở offset khác không phải guard;
- không có offset đo được thì không nhận gì;
- excise qua block chuyển tiếp;
- store qua địa chỉ không phải hằng không làm vùng thành guard.

Hai test dương tính đỏ khi bỏ luật tương ứng.

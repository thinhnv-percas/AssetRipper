# Provenance của class interface không rõ nguồn — iteration 065 (§6)

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Nguyên liệu: cột 12 của `CPP2IL_DUMP_INTERFACE_CALLS`
(`RuntimeInterfaceResolver.Provenance`), dump ISIL của `Sirenix.Utilities.LinqExtensions+<PrependWith>d__9`1::MoveNext`
(`CPP2IL_DUMP_METHOD`), Merge-Room.

## 1. Câu hỏi

Một dispatch interface đi qua runtime lookup `(receiver, interface class, slot)` chỉ giải được khi biết toán hạng class
là interface nào. 064 để lại các dispatch có toán hạng class `UNKNOWN_CLASS_SOURCE`. Brief §6 yêu cầu dựng đồ thị
provenance của toán hạng đó. Một class lấy ra lúc chạy không được ép thành một metadata usage; thiếu bằng chứng thì
giữ `UNKNOWN`.

## 2. Đồ thị provenance — MEASURED

`RuntimeInterfaceResolver.Provenance` đi ngược từ toán hạng class qua copy, load (đặt tên offset theo bảng struct
runtime), call (phân loại bằng `NativeBoundary`), phi và tham số. Iteration này thêm hai bước:

- một local có **nhiều định nghĩa** (sau SSA destruction) được hiện là `{a | b}` thay vì `DEFINED_2_TIMES`;
- một call tới helper mà mã máy chứng minh là trả về đối số đầu được hiện là `returns-argument@0x…(…)`.

Phân bố trên Merge-Room trước khi sửa (số dòng evidence; mỗi thân được phân tích hai lần nên mỗi dispatch là hai
dòng):

| Provenance | Dòng |
|---|---:|
| `{[[[stack spill+0x20]->rgctx_data]+K] \| returns-argument@0x17FDEF4(…)}` | **124** |
| `RuntimeMethodInfoAnalysisContext` | 12 |
| `Add` | 12 |
| tham số | 7 |
| `{[[call get_Assembly]+K] \| RuntimeMethodInfo}` | 6 |
| `{[[DEFINED_2_TIMES->rgctx_data]+K] \| returns-argument…}` | 6 |
| `{RuntimeMethodInfo \| RuntimeMethodInfo}` | 6 |
| khác | 23 |

## 3. Nguyên nhân của nhóm 124 — PROVEN, hai tầng

Dump của `<PrependWith>d__9`1::MoveNext` (thân generic chia sẻ hoàn toàn) cho thấy chuỗi:

```
20  Move [X29-0x20], methodInfo                 ; spill MethodInfo* vào frame
127 Move X8, [X29-0x20]                          ; nạp lại trước mỗi lần đọc RGCTX
128 Move X8, [X8+0x20]                           ; MethodInfo.klass
129 Move X8, [X8+0xC0]                           ; Il2CppClass.rgctx_data
130 Move X1, [X8+0x18]                           ; entry 3 = class của interface
137 X1 = 0x17FDEF4(X1)    nếu !klass->initialized
```

**Tầng 1 — helper khởi tạo class.** `0x17FDEF4` là
`stp x30,x19,[sp,#-16]!; mov x19,x0; bl init; ldr w0,[x19,#0xd8]; cbnz w0,raise; mov x0,x19; ldp; ret`. Nó trả về
đúng class nó nhận, hoặc ném ngoại lệ không quay lại. Không biết điều đó thì toán hạng class là
`phi(entry, helper(entry))`, và không luật nào được gán kiểu cho kết quả của một helper.
`ArgumentReturningHelper.ReturnsFirstArgument` chứng minh điều này từ lệnh máy, không từ địa chỉ hay tên:

- prologue lưu `x0` vào một thanh ghi callee-saved;
- không lệnh nào ghi thanh ghi đó ngoài lệnh restore;
- mọi `ret` đi thẳng tới từ `mov x0, xN`, chỉ qua lệnh restore, không có nhánh nào đáp xuống giữa;
- lệnh cuối trước hàm kế tiếp phải rời hàm (`ret`, `b` hoặc một `bl` không quay lại);
- lệnh ngoài whitelist nhỏ ⇒ "không chứng minh được".

Năm test (một dương tính với đúng các word của `0x17FDEF4`, bốn âm tính) xác định quy tắc phân biệt được.
`ArgumentReturningHelper.LookThrough` đi qua copy, merge mà mọi nhánh đồng ý, và helper đã chứng minh. Một định nghĩa
trả local về chính nó thì không đóng góp gì; bất đồng không bao giờ được giải bằng cách chọn một bên.
`InterfaceInvokeDataRecovery.InterfaceOfLookup` dùng nó ở cả ba nơi đọc toán hạng class.

**Tầng 2 — frame pointer của ARM64 chưa từng được resolve.** Tầng 1 tự nó không đổi một dispatch nào (65h: 78/62/48
giữ nguyên). Lý do là entry RGCTX được đọc qua một `MethodInfo*` spill ở `[x29-0x20]`. `StackAnalyzer` chỉ biết
alias frame của x86 (`mov reg, rsp`), và chỉ khi thanh ghi không bao giờ bị ghi lại. Trên A64, epilogue luôn restore
X29, nên quy tắc đó không bao giờ chạy và mọi spill qua frame pointer vẫn là một memory operand không kiểu.
`StackAnalyzer.ResolveFramePointer` làm việc sau:

- X29 là alias của stack từ lệnh `add x29, sp, #k` duy nhất cho tới khi có gì ghi X29. Đây là must-dataflow: một
  merge chỉ được alias khi mọi predecessor đều alias.
- Mỗi `[x29 + a]` trong vùng đó là ô stack `frame + a`, cùng tên với một truy cập qua SP vào cùng byte.
- `add/sub xN, x29, #k` và `mov xN, x29` thành `AddressOf(slot)`, đúng như lifter đã viết cho `add xN, sp, #k`.
- Method nào đọc X29 như một giá trị khác trong vùng alias thì bị bỏ nguyên (`FramePointerEscapes`, 0 trên Merge-Room).

Bật lên thì lộ ra hai lỗi cũ, mỗi lỗi chỉ hiện ra khi lỗi trước được sửa:

1. **Epilogue reset SP từ X29.** `mov sp, x29` sau một alloca kích thước động được lift thành `Add TEMP, X29, 0`, nên
   stack walk không biết SP đã được đặt lại. Mọi restore sau đó bị đặt tên lệch đúng bằng kích thước alloca: X26 được
   "restore" từ `stack_-80` trong khi prologue lưu nó ở `stack_-40`. Giờ lifter phát `ShiftStack(k, X29)` và stack walk
   đặt `SP = frame + k` (628 lần trên Merge-Room).
2. **Bản ghi frame của il2cpp.** il2cpp ghi địa chỉ của các local đang sống vào một bản ghi nhỏ cho việc xử lý ngoại
   lệ: `[x29-0x38]=0; [x29-0x30]=&[x29-0x20]; [x29-0x28]=&[x29-0x18]`. SSA coi mỗi address-take là một định nghĩa mới
   của ô bị lấy địa chỉ. Vì vậy mọi lần đọc lại `MethodInfo*` thấy một version không có giá trị.
   `SsaForm.OnlyRecordedInUnreadSlots` xử lý trường hợp này: một address-take mà kết quả chỉ được ghi vào các ô stack
   không ai đọc lại, cũng không ai lấy địa chỉ, thì không thể bị ghi xuyên qua bởi bất cứ gì method làm. Cửa sổ là
   block của chính lệnh lấy địa chỉ, tới định nghĩa kế tiếp của thanh ghi giữ nó. Bốn test.

## 4. Kết quả — MEASURED (65z, bản build cuối)

| Merge-Room | 64j | 65g | **65z** |
|---|---:|---:|---:|
| Dispatch giải từ đối số của lookup (dòng) | 574 | 574 | **692** |
| `METHOD_POINTER:UNKNOWN_CLASS_SOURCE` | 78 | 78 | **16** |
| `INVOKER_THROUGH_METHOD:UNKNOWN_CLASS_SOURCE` | 62 | 62 | **0** |
| `TWO_LOADS_OTHER:UNKNOWN_CLASS_SOURCE` | 48 | 48 | **38** |
| `…:LOOKUPS_DISAGREE_OR_LATE` | 8 | 8 | **0** |
| Tổng `UNKNOWN_CLASS_SOURCE` | 196 | 196 | **54** |
| Truy cập / tính địa chỉ qua frame pointer được đặt tên ô stack | 0 / 0 | 0 / 0 | 5949 / 1182 |
| Toán hạng class đi qua helper đã chứng minh | — | — | 15 |

Số lần đi qua helper giảm từ 139 (65h, chưa có alias frame) xuống 15. Lý do: khi `MethodInfo*` đọc được qua frame, đa
số toán hạng class được gán kiểu trực tiếp từ RGCTX và không còn cần đi xuyên helper. Helper vẫn là bằng chứng cần
thiết ở các chỗ class đi qua nó trước khi tới lookup.

Các fixture khác (dòng `UNKNOWN_CLASS_SOURCE`, 64j → 65z):

| Fixture | 64j | 65z |
|---|---:|---:|
| Impostor | 2 | 0 |
| RunFromZombies | 28 | 10 |
| JellyBlastV2 | 2575 | 2510 |
| JellyBlastV2 opt-in | 3159 | 3072 |

**JellyBlastV2 (iOS) là một họ khác, chưa làm.** 2315 trong 2510 dòng có provenance `[Add]`: class được nạp từ một
địa chỉ tính bằng phép cộng, tức base trang `adrp` cộng offset. Trên iOS v27+, slot usage được giải từ giá trị *tại*
địa chỉ, nên phép nạp đó phải được nhận ra là một metadata usage. Đây là mục tiêu kế tiếp có bằng chứng, không phải
một lookup interface đã sai kiểu.

## 5. Còn lại — UNKNOWN, và vì sao đúng là UNKNOWN

- **38 `TWO_LOADS_OTHER`** (48 ở 65m): toán hạng class là một `RuntimeMethodInfo`, một phép `Add`, một tham số,
  `get_Assembly()`, một `MethodInfo`, hoặc một hằng/chuỗi. Đây không phải interface lookup: helper có cùng
  dạng gọi nhưng nhận một `MethodInfo` hoặc một con trỏ tính toán. Hai load sau đó không đi qua `invoker_method`. Không
  có bằng chứng nào để gọi chúng là dispatch interface, nên chúng giữ UNKNOWN.
- **16 `METHOD_POINTER`**: 6 có class đọc qua RGCTX mà base vẫn có nhiều định nghĩa không đồng ý; 6 là
  `{RuntimeMethodInfo | RuntimeMethodInfo}` (hai `MethodInfo` khác nhau trên hai nhánh); 2 là `{Type | Type}`; 2 là
  một hằng.
- **0 `INVOKER`** ở 65z. Ở 65m còn 2 dòng (`DictionaryFormatter`2.SerializeImplementation`): toán hạng class là merge
  của `IReadOnlyDictionary`2` và `IDictionary`2`. Giờ chúng nằm trong `TARGET_NOT_NAMED_BY_THE_LOOKUP` của invoker,
  không được giải: hai interface thật sự khác nhau, nên chọn một bên là đoán.

## 6. Phân loại §12

**INDEPENDENT**: mọi bằng chứng đến từ binary (lệnh máy của helper, layout frame) và metadata (RGCTX). Không dùng
repo source.

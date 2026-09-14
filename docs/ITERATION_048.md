# Iteration 048 — hành vi của method, và ba con số tôi đã đo sai

## 1. Baseline

Tái lập 047 trước khi chạm vào gì.

| | 047 | 048 đầu |
|---|---:|---:|
| load bỏ cuộc (Impostor / Pinata) | 2722 / 9245 | **2722 / 9245** |
| `generatorFailures` | 0 | **0** |
| file `.cs` (Impostor / Pinata) | 819 / 3083 | 819 / 3083 |
| Roslyn Impostor / Pinata | 348-0 / 1478-1 | 348-0 / 1478-1 |
| shape | 16/16 | 16/16 |
| test | 388 | 388 |

## 2. §2 — giải thích TOÀN BỘ placeholder theo họ nguyên nhân

Brief đặt đây là ưu tiên số một. `method_recovery_report.py` của 047 nói *method nào* mang
placeholder; nó không nói placeholder **là gì**. Đếm chữ in ra thì không trả lời được, vì chữ mang
theo toán hạng — mỗi `Unmanaged memory load: [v24 @ X29_v1-58]` là một chuỗi riêng — nên một phép
đếm ngây thơ cho ra hàng nghìn ca đơn lẻ và không họ nào cả.

Thứ định nghĩa một họ là **điểm phát ra**: mỗi họ dưới đây là đúng một
`instructions.Add(CilOpCodes.Ldstr, …)` trong `IlGenerator`.
`Test/Scripts/placeholder_families.py` gắn mỗi placeholder về điểm đó, kèm phép toán ISIL dẫn tới nó
và — nơi chữ có mang — mã lệnh máy bên dưới.

Impostor, 5853 placeholder:

| họ | số | % | method | asm | điểm phát ra | phép toán ISIL |
|---|---:|---:|---:|---:|---|---|
| `UNMANAGED_MEMORY_LOAD` | 2651 | 45,3 | 625 | 7 | `IlGenerator.cs:2463` | `LoadOperand`, một `MemoryOperand` không tìm ra field |
| `METHOD_NOT_FOUND` | 1573 | 26,9 | 763 | 7 | `IlGenerator.cs:1328` | `OpCode.Call`, đích là `Immediate` |
| `NATIVE_IMPORT` | 485 | 8,3 | 183 | 8 | `IlGenerator.cs:1328` | `OpCode.Call` qua một ô PLT |
| `INDIRECT_CALL` | 350 | 6,0 | 221 | 7 | `IlGenerator.cs:1446` | `OpCode.IndirectCall` |
| `NOT_IMPLEMENTED_INSTRUCTION` | 303 | 5,2 | 121 | 5 | `IlGenerator.cs:1019` | `OpCode.NotImplemented` |
| `INDIRECT_JUMP` | 254 | 4,3 | 227 | 7 | `IlGenerator.cs:1471` | `OpCode.IndirectJump` |
| `UNRESOLVED_DELEGATE` | 128 | 2,2 | 85 | 6 | `IlGenerator.cs:1155` | `OpCode.Newobj` trên một delegate |
| `UNKNOWN_CALL_TARGET` | 107 | 1,8 | 67 | 6 | `IlGenerator.cs:1333` | `OpCode.Call`, đích không phải `Immediate` |
| `OTHER` | 2 | 0,0 | 1 | 1 | — | stack không cân ở cuối thân |

Pinata, 14881 placeholder, cùng thứ tự, trừ một khác biệt đáng đọc:
`NOT_IMPLEMENTED_INSTRUCTION` là **16**, không phải 303. Họ đó không phân bố theo chương trình mà
theo **tập lệnh trình biên dịch sinh ra cho fixture đó**.

Ba họ chỉ tới ba loại công việc ngược nhau, và đó là điều phép đếm gộp giấu đi:

* `NOT_IMPLEMENTED_INSTRUCTION` **có tên mã lệnh máy ngay trong chữ**, nên nó là việc của lifter và
  không cần suy luận gì. Impostor: `UNIMPLEMENTED` 93, **`BFI` 80**, `FABD` 48, `DUP` 43,
  **`BFXIL` 12**, `USHL` 8, `BIT` 6, còn lại ≤ 3.
* `NATIVE_IMPORT` đã có tên từ `.rela.plt` (`__cxa_end_catch` 96, `memcpy` 85, `modf` 73,
  `__stack_chk_fail` 54). Phần lớn là **giới hạn thật**: không metadata managed nào gọi tên một hàm
  libc. Ngoại lệ là số ít có phép toán C# tương đương — xem §4.
* `UNMANAGED_MEMORY_LOAD` là việc của type recovery, đã có `recovery_report.py` chia nhỏ từ 046.

## 3. §4 — phát hiện method "sạch giả", và phép đo của chính tôi sai

Tổng của bảng trên là **5853**, còn 047 báo **5130**. Chênh 723 không phải sai số: `DIAGNOSTIC` trong
`method_recovery_report.py` là một bản chép tay của danh sách họ, và nó

* ghi `"Unresolved delegate"`, một chuỗi generator **không bao giờ in ra** (chuỗi thật là
  `Delegate over an unresolved function pointer`), và
* **bỏ hẳn** `Indirect call` và `Indirect jump`.

Nên 732 placeholder vô hình, và **mọi method mà khuyết tật duy nhất là một trong ba họ đó được chấm
`RECOVERED_CLEAN`**. Đây đúng là "fake-clean method" mà §4 đòi phát hiện, và nó nằm trong phép đo
chứ không nằm trong bản rip.

Danh sách họ giờ định nghĩa một lần ở `placeholder_families.MESSAGE_PREFIXES` và được
`method_recovery_report.py` **import**, nên hai phép đo không thể lệch nhau nữa.

Hệ quả là **con số của chính tôi tụt xuống**, trên cả hai fixture:

| Impostor | trước sửa phép đo | sau sửa phép đo |
|---|---:|---:|
| method không có placeholder | 4107 | **3902** |
| `PARTIAL` | 1375 | **1580** |
| placeholder đếm được | 5130 | **5862** |

205 method từng được báo là phục hồi sạch thì không. Không có thay đổi nào của bản rip ở đây — chỉ
có một phép đo thôi nói dối.

## 4. §22 — cải thiện hành vi thứ nhất: `fmodf` là phép chia lấy dư

`Method not found @1854EF0 (native fmodf)` là một lời gọi tới libc mà **C# có toán tử tương đương**.
`IlGenerator.EmitNativeImportOperation` nhận diện ô PLT, đọc tên import từ `.rela.plt`, và với
`fmod`/`fmodf` thì phát ra `Rem` trên hai thanh ghi vector đầu tiên thay vì một placeholder.

`PowOut.cs`:

```diff
-  Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EF0 (native fmodf)");
+  object obj = Power % 2f;
```

22 lời gọi trên Impostor, 7 trên Pinata.

**Layout toán hạng là 18, không phải 19.** Một lời gọi chưa phân giải giữ nguyên cả tệp thanh ghi
làm toán hạng — đích, đích lưu, X0–X7, V0–V7 — và bản đầu tiên đếm đích hai lần, đòi 19, rồi **không
khớp một lần nào trong 2219 lời gọi** trong khi trông y hệt một luật không có gì để khớp. Chỉ có
biến đếm đặt tại từng guard mới tìm ra (`reached 2252, shape 0`). Layout giờ là hằng số public có
test.

**Và một lỗ hổng hình-fixture.** Bản đầu truyền `null!` làm `writeLine`. Trên Impostor không sao;
trên Pinata một toán hạng không nạp được sẽ phát ra một lời gọi tới chính `writeLine` đó, nên nó ném
`ArgumentNullException` ra khỏi generator trong `QuaternionPlugin::SetChangeValue` — và vì một
assembly được decompile như **một đơn vị song song**, 3083 file `.cs` còn **4**. Nhánh không chạy
trên fixture đang đo không phải là nhánh không tồn tại.

## 5. Cải thiện hành vi thứ hai: `BFI` và `BFXIL`

§2 chỉ thẳng vào đây: hai mã lệnh chiếm **92** placeholder trên Impostor và chúng là số học nguyên
thuần tuý, không có gì để suy luận. Một bitfield *move* là `UBFIZ`/`UBFX` cộng thêm một lần **đọc
đích** — và lần đọc đó là toàn bộ khác biệt, vì những bit mà field không phủ thì giữ nguyên.

Disarm trả về toán hạng của chính alias (`BFI W8, W9, 0x4, 0x8` ra lsb 4, width 8), nên không phải
gỡ ngược immr/imms của `BFM`.

Phần dễ sai không phải phép dịch mà là **bề rộng của phần bù**: một thanh ghi 32 bit giữ 32 bit, nên
`~placed` phải bị cắt về bề rộng của thanh ghi, nếu không toàn bộ nửa cao của đích nhận toàn bit 1
từ một lệnh chưa từng ghi vào đó. `BitfieldMoveMasks` được tách ra để kiểm chứng riêng, và **3 trong
5 test đỏ khi khôi phục lại lỗi** — một test mà hai kết cục cho cùng một số thì không phải test.

Đo trên Impostor, bằng phép đo đã sửa ở §3 cho cả hai đầu:

| | trước BFI | sau BFI |
|---|---:|---:|
| method không có placeholder | 3913 | **3942** |
| `PARTIAL` | 1569 | **1540** |
| placeholder | 5841 | **5753** |
| `Expected I4, but got I8` | 261 | 305 |
| Roslyn / shape / `.cs` / `genFail` | 348 / 16-16 / 819 / 0 | **không đổi** |
| load bỏ cuộc | 2722 | 2726 |

19 file đổi, và chúng **đúng là chỗ bitfield move sống**: ACTk `Obscured*` đóng gói khoá và giá trị
vào một từ, cùng `xxHash`, `MeshGenerator`, `SkeletonBinary`. Không có file nào ở chỗ khác, tức luật
khớp đúng hình dạng nó nhắm tới.

`ObscuredUShort.op_Implicit`:

```diff
-  NoteDecompilerIssue("Not implemented instruction: \"Instruction BFI not yet implemented.\"");
-  ObscuredUShort result = (flag ? ((ObscuredUShort)4294967296L) : ((ObscuredUShort)4294967296L));
-  NoteDecompilerIssue("Not implemented instruction: \"Instruction BFXIL not yet implemented.\"");
-  NoteDecompilerIssue("Not implemented instruction: \"Instruction BFI not yet implemented.\"");
-  return result;
+  int num2 = num ^ value;
+  … đóng gói khoá vào 16 bit thấp, giá trị đã làm rối vào bit 16 …
+  return (ObscuredUShort)num14;
```

Hai nhánh của `flag ? … : …` trước đây **giống hệt nhau**, tức giá trị mất hẳn; sau thì
`num ^ value` — đúng phép làm rối của ACTk — chảy tới nơi.

**Cái giá, nói thẳng:** `Expected I4, but got I8` tăng 44 và load bỏ cuộc tăng 4. Cái sau là hình
dạng CLAUDE.md đã ghi: phục hồi thêm một đoạn chương trình làm lộ ra những lệnh đọc trước đây bị bỏ
đi cùng code chết. Cái trước là bề rộng: một mặt nạ 32 bit có bit cao bật là một `int` **âm** chứ
không phải một `long` dương lớn, và viết rộng thì generator đẩy I8 vào đích I4. `MaskImmediate` viết
nó ở bề rộng của thanh ghi, đưa 336 xuống 305 mà không mất placeholder nào. 44 còn lại là thanh ghi
64 bit thật, tức bài toán local không có kiểu ở §5 của ROADMAP, không phải của lift này.

## 6. §23 — BEHAVIORALLY RECOVERED METHODS

Đo bằng phép đo **đã sửa** ở §3 cho cả hai đầu, không phải phép đo cũ.

| | baseline (047) | 048 | delta |
|---|---:|---:|---:|
| **Impostor** — method không có placeholder | 3902 | **3942** | **+40** |
| Impostor — `PARTIAL` | 1580 | 1540 | −40 |
| Impostor — placeholder | 5862 | 5753 | −109 |
| **Pinata** — method không có placeholder | 13167 | **13176** | **+9** |
| Pinata — `PARTIAL` | 3196 | 3187 | −9 |
| Pinata — placeholder | 14740 | 14726 | −14 |

**BEHAVIORALLY RECOVERED METHODS: 3902 → 3942 (Impostor, +40) và 13167 → 13176 (Pinata, +9).**

Không có cổng nào lùi:

| | baseline | 048 |
|---|---|---|
| `generatorFailures` | 0 / 0 | **0 / 0** |
| file `.cs` | 819 / 3083 | 819 / 3083 |
| Roslyn Impostor / Pinata | 348-0 / 1478-1 | **348-0 / 1478-1** |
| shape | 16/16 | 16/16 |
| `_002Ector()` / `array[i].field` / `(float)array[i]` | 51 / 164 / 0 | 51 / 164 / 0 |
| test | 388 | **400** (1 fail có sẵn) |
| load bỏ cuộc | 2722 / 9245 | 2726 / 9248 |

Hai cột cuối tăng, và cả hai đều đã giải thích ở §5 chứ không được giấu đi.

## 7. Những gì iteration này KHÔNG làm

§6 (cụm 113 method của `MeshGenerator`), §7 (`OrderedDictionary`), §9 (`CALL_RESULT` như nguồn kiểu
hạng nhất), §14 (phân loại hai thân bị mất trên Pinata), §19 (Recovery Scorecard JSON), §20 (kho
method vàng). §2 và §4 chiếm phần lớn thời gian, và §4 hoá ra là một lỗi trong phép đo của chính
iteration trước, phải sửa trước khi bất cứ con số nào đọc được.

Unity vẫn `UNITY_NOT_AVAILABLE`; U1–U9 và I1–I4 vẫn `NOT_RUN`.

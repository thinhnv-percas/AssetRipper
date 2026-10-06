# Cấp phát stack kích thước động — iteration 066 (§3)

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Baseline `Test/Out65z-*`, kết quả `Test/Out66i-*`.

## 1. Hình dạng — PROVEN từ mã máy

Một thân generic chia sẻ hoàn toàn không biết kích thước của tham số kiểu cho tới lúc chạy. il2cpp viết
`alloca(il2cpp_codegen_sizeof(T))` cho mỗi local kiểu `T`. Trên A64 (`ExtensionList.KeyByValue`, Merge-Room
`0x1CEE8E8`):

```
mov x9, sp
and x8, x8, #0x1fffffff0          ; (stack_slot_size + 15) & ~15
sub x8, x9, x8
mov sp, x8                        ; SP_new = SP_old - size
```

Đếm trong section `il2cpp` của Merge-Room:
- 4783 lệnh `mov sp, xN` (không tính X29);
- 4693 trong số đó có `sub xB, xA, xSize` trong ba lệnh trước;
- 0 lệnh `sub sp, sp, xN`.

## 2. Tầng đầu tiên sai

Lifter coi `mov sp, xN` (bí danh của `add sp, xN, #0`) là phép cộng vào một thanh ghi bị bỏ, nên stack walk tin SP
không đổi:
- Mọi `mov xA, sp` sau đó đều được đặt tên là cùng một ô cố định (`stack_-E0`).
- Mọi buffer trở thành "ô đó trừ size".
- Ô đó nhận kiểu của bất cứ thứ gì buffer được dùng làm.

Trong mã phục hồi điều đó hiện ra là `(nint)enumerator - num`, `Dictionary.Enumerator enumerator = default`, và các
truy cập `[sp + k]` sau alloca bị gộp với local cố định ở cùng offset.

## 3. Mô hình

- **Lifter:** `mov sp, xN` → `ShiftStack [Register xN]`, tức SP đặt về một giá trị đã tính.
- **`StackAnalyzer`:**
  - `StackState.Dynamic` bật từ lệnh đó.
  - Reset từ frame pointer (`mov sp, x29` / `sub sp, x29, #k`) tắt nó; frame không di chuyển.
  - Merge là dynamic nếu bất kỳ nhánh nào dynamic.
- **`ResolveDynamicStack`** (chạy trước mọi pass đặt tên ô):
  - SP mới nằm trong thanh ghi riêng `SPDYN`, nên SSA đánh version cho nó.
  - Khi đủ cả ba lệnh (đọc SP; trừ đúng giá trị đó; ghi đúng kết quả về SP), phép trừ trở thành
    `OpCode.StackAlloc dest, size`. Đó là `localloc` của IL, đúng như nguồn il2cpp viết.
  - Operand theo SP trong vùng dynamic được đọc tương đối `SPDYN`, không đặt tên ô cố định.
  - Truy cập qua X29 không đổi.
- **Generator:** `StackAlloc` → `conv.u; localloc`.
- **Kiểu của kết quả:** `byte*`. Kiểu `IntPtr` cho ra `(nint)stackalloc …` (CS8346 ×20 trên Merge-Room ở 66e),
  không phải C#.
- **`InvokerArgumentRecovery`** nhận `StackAlloc` như định nghĩa buffer T, cùng dạng cũ. Ghi buffer vào `SPDYN` là
  một lần dùng đã giải thích. Thiếu hai điều này, số dispatch viết lại rơi 64 → 0 ở 66e. Lỗi đó được bắt và sửa
  trước khi đóng.

## 4. Test (đỏ khi bỏ luật)

`Il2CppIteration066Tests`:
- cấp phát cố định;
- alloca động → `StackAlloc`;
- operand sau alloca không phải ô cố định cùng offset;
- lấy địa chỉ sau alloca → `SPDYN + k`;
- lấy địa chỉ trước alloca giữ local cố định;
- frame pointer vẫn đặt tên ô cố định trong vùng dynamic;
- reset `sub sp, x29, #k` kết thúc vùng;
- `mov sp, x29` kết thúc vùng;
- alloca thứ hai đọc SP đã di chuyển;
- đặt SP không phải alloca vẫn di chuyển nó.

Tắt cờ dynamic trong stack walk làm ba test đỏ.

## 5. Kết quả — MEASURED

| | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 | Pinata |
|---|---:|---:|---:|---:|---:|
| Alloca → `localloc` | 184 | 995 | 146 | 121 | 0 |
| Ghi SP khác (không phải alloca) | 0 | 21 | 24 | 20 | 154 |
| Operand đọc tương đối SP động | 109 | 476 | 57 | 73 | 138 |
| `stackalloc` trong mã | 0 → 93 | 2 → 550 | 0 → 72 | 0 → 64 | 2 → 2 |

Kiểm tra brief yêu cầu (Merge-Room):
- `ExtensionList.cs`: lỗi thân **25 → 10**.
- `LayerMaskExtension.cs`: 0 → 0.
- `MMSwap`: vẫn hoán đổi qua indexer, compile được, không ghi đè tham số. `parameter_overwrite_scan` 0 trên cả sáu
  fixture.

Pinata (2019.2) có 154 lần ghi SP không phải alloca: chuỗi lệnh khác, chưa đọc.

## 6. Chi phí còn lại — MEASURED

Một thanh ghi chứa buffer `byte*` ở nhánh này và `nint` ở nhánh kia bị giữ không kiểu (luật "input bất đồng thì không
kiểu"). Local thành `object`, cho ra `Cannot convert type 'byte*' to 'object'`: 14 lỗi trên năm fixture
(Impostor 8, Merge-Room 3, JellyBlastV2 3). Ở 65z cùng chỗ đó là `(nint)T`, 1 lỗi.

Sửa đúng là luật merge cho hai kiểu địa chỉ không quản lý. Chưa làm.

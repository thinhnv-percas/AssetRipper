# Invoker argument recovery — iteration 065 (§5)

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Pass: `Source/External/Cpp2IL.Core/Analysis/InvokerArgumentRecovery.cs`.
Evidence: `CPP2IL_DUMP_INVOKER_ARGS=<file>`, mỗi đối số một dòng với các cột:
- caller, target, `invoker_method`, receiver, interface;
- chỉ số đối số, con trỏ, giá trị;
- trạng thái, lý do, kết cục.

## 1. Bài toán

Trong một thân generic chia sẻ hoàn toàn, lời gọi interface không đi qua `VirtualInvokeData.methodPtr`. Nó đi qua:

```
method->invoker_method(methodPointer, method, receiver, void** args, void* ret)
```

Đây là trampoline kiểu reflection của runtime. Method interface nào được gọi thì đã biết từ đối số của lookup (064: 46
dispatch đích EXACT). Gọi với **cái gì** thì chưa: các đối số nằm trong một mảng con trỏ trên frame, và mỗi con trỏ:
- hoặc trỏ tới một ô frame mà thân đã ghi giá trị vào;
- hoặc trỏ tới một buffer cỡ `T` mà thân cấp phát trên stack (`sp -= (Il2CppClass<T>.stack_slot_size + 15) & ~15`),
  nội dung di chuyển bằng `memcpy`.

Brief cấm phát `InterfaceMethod(a, b, c)` khi đối số chưa được chứng minh, và cấm suy kiểu từ kích thước.

## 2. Mô hình — PROVEN

- **Buffer T.** Một con trỏ được định nghĩa **chỉ** theo cách cấp phát trên là storage của một giá trị `T`. Nó được
  mô hình hoá thành một local `T` khi **mọi** lần dùng thuộc một trong các dạng mô hình giải thích được:
  - `memset` về 0 (`default(T)`);
  - `memcpy` giữa hai buffer cùng class (`a = b`);
  - ghi địa chỉ của nó vào một ô frame, kể cả trực tiếp vào ô có tên khi frame pointer đã resolve;
  - toán hạng của call invoker;
  - phần đuôi thanh ghi thô của một lookup.

  `memcpy`/`memset` được đặt tên bằng relocation của chính binary (`NativeBoundary`), không bao giờ theo địa chỉ.
- **Provenance đối số.** `args[i]` là store tới `args + 8i` đến được call. Store đó nằm trong block của call (trước
  call), hoặc là store cuối của block dominate gần nhất, với điều kiện không có store nào khác vào cùng địa chỉ trên
  đường đi. Con trỏ trong đó:
  - là một buffer T, thì đối số là local T của buffer;
  - là địa chỉ một ô frame, thì giá trị là store đến được ô đó; chỉ nhận cho primitive hoặc reference, loại được ghi
    trọn bằng một store.
- **Mới trong 065:**
  - một store trực tiếp vào ô có tên (sau alias frame X29) được đọc như store qua địa chỉ;
  - giá trị đọc ở store phải không bị gán lại trước call (`VALUE_REDEFINED_BEFORE_THE_CALL`). Ngoài SSA, một local có
    thể bị gán lại, và khi đó gọi tên nó là đối số sai;
  - store trực tiếp vào ô có tên thì lấy chính ô làm giá trị.
- **Bất kỳ điều gì thiếu** ⇒ `UNKNOWN_ARGUMENT` hoặc `UNKNOWN_RETURN`, và call giữ nguyên là indirect call.

## 3. Hai lỗi tầng dưới mà pass phơi ra — PROVEN

1. **Store `args[1]` bị xoá như store chết.** Khi frame pointer đã resolve, mảng `args` là các ô có tên liên tiếp và
   call chỉ nhận địa chỉ ô đầu. Ô thứ hai được ghi, không ai đọc theo tên, nên DCE, `SsaSimplifier` và `Simplifier`
   đều bỏ nó. `StackAnalyzer.KeepStoresReadThroughABaseAddress` giữ đúng các ô thuộc một dãy liên tiếp được ghi, không
   ai đọc theo tên, bắt đầu từ một ô bị lấy địa chỉ (405 store trên Merge-Room). Giữ mọi store qua frame pointer thì
   giữ luôn scaffolding của vùng quét interface; đã đo và loại.
2. **`&slot` bị thay bằng `&i`.** Xem `UNRESOLVED_LOAD_RECOVERY_065.md` §5. Hậu quả trên chính pass này: `args[0]` trở
   thành địa chỉ của tham số, và con trỏ method của invoker ghi đè tham số đó. Hai luật bù trong pass (`LOCAL_STORAGE`,
   `ARGS_IN_A_LOCAL_HOLD_ONE_ELEMENT`) được viết trước khi tìm ra nguyên nhân. Ở 65z chúng **không bắn lần nào**: hình
   dạng đó không còn được tạo ra. Chúng được giữ lại vì đúng theo cấu trúc, và được ghi rõ là không bắn.

## 4. Kết quả — MEASURED (65z)

Mỗi thân được phân tích hai lần, nên số dòng gấp đôi số call site.

| Fixture | Site invoker | Viết lại | Buffer T | EXACT | BUFFER | UNKNOWN_ARGUMENT |
|---|---:|---:|---:|---:|---:|---:|
| Merge-Room (65g) | 167 | 26 | 42 | 16 | 16 | 73 |
| **Merge-Room (65z)** | 167 | **60** | 94 | 16 | 18 | 71 |
| Impostor | 14 | 2 | 10 | 0 | 2 | 18 |
| RunFromZombies | 36 | 0 | 0 | 0 | 2 | 30 |
| JellyBlastV2 | 48 | 0 | 0 | 0 | 0 | 48 |

Trên Merge-Room, 30 dispatch được viết lại, trong 18 method:
- `MMSwap` (`get_Item` và `set_Item`, dịch đúng nguồn: `val = list[i]; list[i] = list[j]; list[j] = val`);
- `ImmutableList<T>.get_Item` ×4;
- `LinqExtensions.ForEach`/`AddRange` và 9 state machine `Append*/Prepend*` (`IEnumerator<T>.get_Current`).

## 5. Còn lại — UNKNOWN, có lý do

| Lý do (Merge-Room, dòng) | Số | Nghĩa |
|---|---:|---|
| `UNKNOWN_RETURN` | 46 | kết quả ghi vào một buffer mà mô hình không giải thích được mọi lần dùng (thường là một `Box` của chính buffer) |
| `POINTER_NOT_A_FRAME_ADDRESS_OR_BUFFER` | 45 | con trỏ trong `args[i]` không phải ô frame cũng không phải buffer T đã mô hình |
| `TARGET_NOT_NAMED_BY_THE_LOOKUP` | 8 | class của lookup là merge của hai interface khác nhau, xem `UNKNOWN_CLASS_PROVENANCE_065.md` |
| `NO_STORE_REACHES_THE_VALUE_SLOT` | 6 | không có store nào đến được ô giá trị trên mọi đường |
| `ARGS_NOT_A_FRAME_ADDRESS` | 2 | mảng `args` không phải địa chỉ frame |

Không dispatch nào ở đây được viết lại với một đối số đoán. Mục tiêu tiếp theo:
- `Box` của buffer T, tức đọc giá trị `T` từ storage của nó: cần thay toán hạng bằng local của buffer khi viết lại.
- RunFromZombies/JellyBlastV2, nơi không buffer nào được mô hình hoá: dạng alloca ở đó khác, cần đo trước khi làm.

# Buffer trả về của invoker — iteration 066 (§4)

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**.

## 1. Câu hỏi

Invoker của runtime (`invoker_method(methodPointer, method, obj, args, ret)`) ghi kết quả qua đối số cuối:
`*(T*)ret = method(...)` cho một giá trị, con trỏ object cho một tham chiếu. 065 chỉ nhận `ret` là buffer `T`, và mọi
trường hợp khác là một `UNKNOWN_RETURN` không lý do: 48 trên Merge-Room, 6 trên JellyBlastV2 và RunFromZombies, 2
trên Impostor.

## 2. Phân loại — `InvokerArgumentRecovery.PlanReturn`

Local giữ kết quả sau lời gọi chính là storage mà `ret` trỏ tới. Không gì được suy từ kích thước.

| `ret` | Kết quả |
|---|---|
| buffer `T` đã mô hình, cùng kiểu | buffer (`T_BUFFER`) |
| buffer `T` khác kiểu | `UNKNOWN_RETURN:BUFFER_OF_ANOTHER_TYPE` |
| `0` | `UNKNOWN_RETURN:NULL_RETURN_POINTER` |
| `&ô frame`, kiểu một store ghi trọn, mọi local đặt tên ô là một storage | **local của ô đó** (`FRAME_SLOT`) |
| `&ô frame`, struct | `UNKNOWN_RETURN:STRUCT_ACROSS_FRAME_SLOTS` |
| `&ô frame`, ô có nhiều storage | `UNKNOWN_RETURN:FRAME_SLOT_HAS_SEVERAL_STORAGES` |
| địa chỉ frame tính được | `UNKNOWN_RETURN:COMPUTED_FRAME_ADDRESS` |
| một `StackAlloc` bị loại khỏi mô hình buffer | `UNKNOWN_RETURN:T_BUFFER_WITH_A_USE_THE_MODEL_DOES_NOT_EXPLAIN` |
| khác | `UNKNOWN_RETURN:POINTER_FROM_<opcode>` |

Pass chạy ngoài SSA, nên định nghĩa local của ô tại lời gọi chính là store của callee. Điều kiện "một storage" bảo
đảm lần đọc sau lời gọi đọc đúng thứ lời gọi ghi.

## 3. Kết quả — MEASURED (65z → 66i)

| | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 |
|---|---:|---:|---:|---:|
| Dòng viết lại (`REWRITTEN`) | 2 → 4 | **64 → 80** | 0 → 2 | 0 → 0 |
| `UNKNOWN_RETURN` | 2 → 0 | 48 → 34 | 6 → 4 | 6 → 4 |
| ↳ có lý do cụ thể | 0 → 0 | 0 → **34** | 0 → 4 | 0 → 4 |

Mọi `UNKNOWN_RETURN` còn lại đều mang lý do, và trên cả ba fixture đó là cùng một lý do:
`T_BUFFER_WITH_A_USE_THE_MODEL_DOES_NOT_EXPLAIN`. Kết quả nằm trong một buffer `T` mà mô hình buffer loại ra vì một
lần dùng nó không giải thích được. 065 đã ghi trường hợp phần lớn là một `Box`. Đây là mục tiêu kế tiếp, cụ thể:
dạy mô hình buffer về `Box` của buffer.

## 4. Không làm

- Không có cast nào.
- Không có temporary nào ngoài local của chính ô hoặc buffer.
- Một struct trải qua nhiều ô không được ghép lại thành một giá trị: không có bằng chứng native nào cho phép coi
  các ô đó là một biến.

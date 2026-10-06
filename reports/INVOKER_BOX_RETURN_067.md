# Return của invoker qua buffer T — iteration 067 (§4)

Nhãn: **MEASURED**, **UNKNOWN**.

## 1. Đã làm: lý do chính xác hơn

066 để lại mọi `UNKNOWN_RETURN` với cùng một lý do, `T_BUFFER_WITH_A_USE_THE_MODEL_DOES_NOT_EXPLAIN`. Mô hình buffer
bỏ một buffer ngay khi gặp một use nó không giải thích được, nhưng không ghi use đó là gì.

067 ghi lại use đầu tiên làm vỡ mô hình (`InvokerArgumentRecovery.DescribeUse`). Use là callee của một call (method,
helper có tên, hay địa chỉ) cùng vị trí đối số, hoặc opcode cùng vị trí toán hạng. Lý do thành
`T_BUFFER_USED_BY:<use>`.

Không có suy đoán theo kích thước, không có cast. Mô hình không đổi hành vi, chỉ nói rõ hơn vì sao nó từ chối.

## 2. Đo (`CPP2IL_DUMP_INVOKER_ARGS`)

| Fixture | 066 | 067 |
|---|---|---|
| Merge-Room | 34 × `T_BUFFER_WITH_A_USE_THE_MODEL_DOES_NOT_EXPLAIN` | 14 × `CALL:0x179CE74:ARG4`, 14 × `INDIRECTCALL:OPERAND6`, 4 × `CALL:0x17FDEF4:ARG3` |
| RunFromZombies | 4 | 4 × `CALL:0xE6A35C:ARG3` |
| JellyBlastV2 | 4 | 6 × lý do cũ (use không phải call hay opcode có toán hạng là buffer) |
| Impostor | 0 | 0 |

Số `UNKNOWN_RETURN` không giảm. Brief cho phép điều đó khi lý do chính xác hơn, và ở đây lý do đã chính xác hơn.

## 3. Use chưa được mô hình — UNKNOWN

- **`0xE6A35C` (RunFromZombies)** là một helper runtime chưa định vị. Nó xuất hiện:
  - với một `Il2CppClass` trong guard khởi tạo lớp: `if ((klass.bitfield & 1) == 0) E6A35C(klass, …)`;
  - với buffer làm đối số thứ hai.

  Hai chữ ký khác nhau ở cùng một địa chỉ. Nó có thể là một veneer dùng chung, hoặc thứ tự đối số đọc sai. Không
  đặt tên được nó nếu không đọc mã máy. Box có phải là use này hay không vẫn **chưa chứng minh**.
- **`0x179CE74` (Merge-Room, đối số thứ ba)** nằm cạnh `il2cpp_codegen_initialize_runtime_metadata` (`0x179CE50`)
  và bản inline của nó (`0x179CE64`), trong cùng bảng veneer. Vị trí thứ ba khớp
  `UnBoxNullable(obj, klass, storage)`, nhưng đó là suy luận, chưa đo.
- **`INDIRECTCALL:OPERAND6`**: buffer là đối số của một dispatch khác chưa giải. Đây là một invoker lồng invoker.

Việc cho 068: định vị `0x179CE74`/`0xE6A35C` bằng cùng cách đã định vị write barrier — anchor corlib cộng quét hình
dạng call site — rồi thêm use tương ứng vào mô hình buffer.

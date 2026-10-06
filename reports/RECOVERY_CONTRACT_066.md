# Hợp đồng phục hồi theo method — iteration 066 (§9)

`Test/Scripts/recovery_contract.py <rip game dir> --assembly Assembly-CSharp --errors <body-errors> --invoker <tsv>`

## 1. Câu hỏi nó trả lời

"Vì sao method này không compile?". Mỗi phép đo cũ trả lời cho tất cả method cùng lúc. Hợp đồng đặt mọi trục cạnh
nhau cho từng method, và mỗi trục được đọc bằng đúng công cụ sở hữu nó, nên hợp đồng không thể bất đồng với phép đo
nó tóm tắt:

| Trục | Nguồn |
|---|---|
| `semantic_status` | `recovery_metrics.classify` |
| `provenance_status`, `unresolved_loads`, `unresolved_calls` | `placeholder_families.family_of` |
| `unresolved_returns`, `unknown_arguments`, `abi_status` | dump invoker (`CPP2IL_DUMP_INVOKER_ARGS`); không có dump nghĩa là không có invoker được phân tích, không phải "không có lỗi" |
| `type_status` | comment `Expected X, but got Y` của ILSpy, local `object` |
| `control_flow_status` | `goto`, `NOT_IMPLEMENTED_INSTRUCTION` |
| `compile_status` | body pass của `compile_recovered_scripts.sh` (COMPILES / FAILS / NOT_COMPILED) |
| `compile_risk` | `cluster_body_errors.classify` trên lỗi *đầu tiên* của method, tức họ producer, không phải message |

Hai đầu đọc method bằng hai cách khác nhau: attribute `Address` và `recovery_metrics.methods`. Khi chúng không khớp,
file được báo `UNPAIRED` chứ không ghép sai. Trên mười lần chạy (năm fixture × hai bản rip) có 0 file unpaired.

## 2. Kết quả (Assembly-CSharp, 66i)

| | Method | Compile | Fail | EXACT nhưng fail | Họ hàng đầu của method fail |
|---|---:|---:|---:|---:|---|
| Impostor | 390 | 335 | 55 | 16 | OTHER 10, SHARED_GENERIC_PLACEHOLDER 9, INDIRECT_STRUCT_ARGUMENT 9, BASE_CONSTRUCTOR_CALL 8 |
| Merge-Room | 570 | 474 | 96 | 49 | OTHER 15, OBJECT_AS_NATIVE_INT 13, STRUCT_FIRST_MEMBER 12, INDIRECT_STRUCT_ARGUMENT 10 |
| JellyBlastV2 | 1140 | 677 | 463 | 65 | OBJECT_AS_NATIVE_INT 212, OTHER 89, INTERFACE_SCAN_SURVIVOR 40, BASE_CONSTRUCTOR_CALL 25 |
| RunFromZombies | 52 | 47 | 5 | 5 | STRUCT_FIRST_MEMBER 4, STRIPPED_FRAMEWORK_MEMBER 1 |
| Pinata | 5170 | 4655 | 515 | 70 | — |

Đọc bảng:
- **EXACT không có nghĩa là compile được.** 49 method EXACT của Merge-Room fail. Lỗi của chúng nằm ở tầng biểu diễn
  (`(nint)obj`, member đầu của struct, field private của framework) chứ không ở tầng nội dung. Đây là con số mà
  tổng EXACT che đi.
- **RunFromZombies:** cả năm method fail đều EXACT. Bốn là `STRUCT_FIRST_MEMBER`. Một là member framework bị strip
  khỏi build, tức một khiếm khuyết của bộ tham chiếu chứ không của bản phục hồi.

JSON đầy đủ theo method: `iterations/066/metrics/contract-{65z,66i}-*.json`.

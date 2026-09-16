# Iteration 051 — mốc kiểm chứng baseline 050

Commit: `a943a2fa` (Iteration 050: complete semantic vtable/runtime-helper recovery)
Fixture: `Test/Input/Impostor`, script level 3, Release, `--struct-db StructDb`.
Tiến trình rip kết thúc với `EXIT=0`; mọi con số dưới đây đọc **sau khi tiến trình thoát**,
không đọc theo một dòng log giữa chừng.

| Phép đo | 050 công bố | 051 đo lại | Khớp |
|---|---|---|---|
| EXACT | 2852 | 2852 | có |
| HIGH_CONFIDENCE | 157 | 157 | có |
| PARTIAL | 1158 | 1158 | có |
| FALLBACK | 1315 | 1315 | có |
| MISSING | 0 | 0 | có |
| placeholder | 4502 | 4502 | có |
| METHOD_NOT_FOUND | 715 | 715 | có |
| INDIRECT_CALL | 207 | 207 | có |
| INDIRECT_JUMP | 120 | 120 | có |
| UNRESOLVED_DELEGATE | 0 | 0 (họ không còn xuất hiện) | có |
| unresolved load | 2711 | 2711 | có |
| file `.cs` | 819 | 819 | có |
| generatorFailures | 0 | 0 | có |
| field layout self-check | 1394 exact / 0 disagreed | 1394 exact / 0 disagreed | có |
| golden corpus | 61 method | 61, improved 0 regressed 0 | có |
| test suite | 414 (1 lỗi có sẵn) | 413 pass / 1 fail | có |

## Phân loại indirect call còn lại (điểm xuất phát của 051)

| Nhãn | Số |
|---|---|
| LOADED_POINTER | 236 |
| METHODINFO_POINTER_AT_0x10 (`invoker_method`) | 126 |
| VTABLE_SLOT_UNRESOLVED | 34 |
| LOADED_FROM_reference | 12 |
| LOADED_FROM_valuetype | 4 |

`METHODINFO_POINTER_AT_0x0` (`methodPointer`) không còn trong bảng: 050 đã phân giải hết 56 lời
gọi đó thành lời gọi trực tiếp. Đây là bằng chứng cho phần "MethodInfo pointer handling" của §2.

## Phân loại indirect jump còn lại

| Nhãn | Số |
|---|---|
| VTABLE_SLOT | 135 |
| DEFINED_BY_Add | 60 |
| LOADED_POINTER | 28 |
| DELEGATE_INVOKE | 20 |
| OTHER_ArrayLength | 2 |
| LOADED_FROM_valuetype | 2 |

Mục tiêu chính của 051 theo brief là `LOADED_POINTER` (236 call + 28 jump), không phải thêm luật
vtable.

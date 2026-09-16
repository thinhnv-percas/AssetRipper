# Iteration 052 — mốc kiểm chứng baseline 051

Commit: `b9d68901`. Release build, `--script-level 3 --reconstruct-bodies --struct-db StructDb`.
Cả hai tiến trình rip kết thúc với `EXIT=0`; mọi con số đọc **sau khi tiến trình thoát**.

| Phép đo | Impostor | Pinata |
|---|---|---|
| `EXACT` | 2852 | 9634 |
| `HIGH_CONFIDENCE` | 157 | 463 |
| `PARTIAL` | 1158 | 3043 |
| `FALLBACK` | 1315 | 3233 |
| `MISSING` | 0 | 2 |
| phục hồi không kèm đồ thế chỗ | 3009 / 5482 | 10097 / 16375 |
| placeholder | 4455 | 14166 |
| `UNMANAGED_MEMORY_LOAD` | 2673 | 8438 |
| `METHOD_NOT_FOUND` | 691 | 2770 |
| `NATIVE_IMPORT` | 490 | 1224 |
| `INDIRECT_CALL` | 183 | 612 |
| `INDIRECT_JUMP` | 120 | 781 |
| `UNKNOWN_CALL_TARGET` | 97 | 303 |
| `NOT_IMPLEMENTED_INSTRUCTION` | 211 | 0 |
| `UNRESOLVED_DELEGATE` | 0 | 122 |
| interface dispatch phục hồi | 48 | 90 |
| **field layout self-check** | **1394 exact / 0 disagreed** | **3170 exact / 0 disagreed** |
| `.cs` | 819 | 3083 |
| `generatorFailures` | 0 | 0 |

Golden corpus: **165/165 có mặt** trên `Test/Out052i/Impostor`, improved 0 regressed 0.
Test suite: 447 pass / 1 fail (`GetMainExportID_ValueGreaterThan100000_DebugAssertFails`, có sẵn).

Lưu ý phép đo, ghi ở 051 và vẫn áp dụng: golden corpus nhận root là **thư mục game bên trong**
bản rip; chĩa lên thư mục output thì 0/165 khớp và nó trả `CORPUS_NOT_APPLICABLE`.

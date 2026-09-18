# Iteration 056 — kết quả

Commit: xem `source-commit.txt`. Cây git sạch khi đo.

Bản rip: `Test/Out56F-{z,i,m,j}` (pass bật) và `Test/Out56B-{z,i,m,j}` (baseline, pass tắt, **cùng
build cho mọi thứ khác**, kể cả hai phép sửa đo lường). Cả hai đầu đo bằng cùng một phép đo, vì
iteration này dịch mẫu số.

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| EXACT (baseline → sau) | 2513 → 2513 | 3776 → 3782 | 7605 → 7671 | 2855 → 2867 |
| FALLBACK | 150 → 150 | 346 → 346 | 384 → 386 | 43 → 44 |
| placeholder | 5964 → 5962 | 4297 → 4293 | 37.690 → 37.507 | 38.524 → 38.236 |
| `List.Add` inline gấp lại | 130 / 160 | 267 / 297 | 820 / 1346 | 870 / 1252 |
| lệnh đọc member private `List<T>` | 304 → 46 | 736 → 216 | 1665 → 380 | 2648 → 988 |
| `native_plugin_preservation_rate` | — | — | 1,0000 (2/2) | **1,0000 (6/6)**, trước 0/6 |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| field layout disagreement | 0 / 2165 | 0 / 1394 | 0 / 3947 | 0 / 2654 |
| golden corpus | 0 / 0 | +1 / 0 | +8 / 0 | +2 / 0 |

Roslyn (assembly chịu ảnh hưởng nặng nhất): Impostor `Assembly-CSharp` 342 → 200;
JellyBlast `RayFireAssembly` 4462 → 3457; Merge-Room và RFZ `Assembly-CSharp` không đổi (6 và 7).

Source oracle RunFromZombies: `semantic_equivalence_rate` **1,0000 (36/36)** trước và sau.

Test: 488 ca, 487 pass, một fail có sẵn (`GetMainExportID_ValueGreaterThan100000_DebugAssertFails`).
Harness: `test_measurement_completeness.sh` 10/10, `test_placeholder_extraction.sh` 5/5, shape checks
sạch trên Impostor.

Unity không có trong container: stage E–I `BLOCKED`, `runtime_status: NOT_RUN`. Không có claim runtime.

**Cảnh báo so sánh**: hai phép sửa đo lường trong iteration này (`docs/ITERATION_056.md` mục 2) dịch
EXACT lên 2285→2513 / 2879→3776 / 6634→7605 / 2517→2855 **mà không phục hồi thêm gì**. Số công bố ở
iteration ≤ 055 không so trực tiếp được với số ở đây.

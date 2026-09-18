# Iteration 057 — kết quả

Bản rip: `Test/Out57H-{z,i,m,j}`. Baseline: `Test/Out56F-*` (bản cuối của 056), đo lại bằng chính phép
đo của 057.

**Method recovery không đổi một byte nào.** `diff_recovered_scripts.sh` báo
`only-in-one: 0  content-differs: 0` trên cả bốn fixture. 057 đổi *cách đo* và *shader / native
plugin*, không đổi thứ được đo.

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| EXACT (baseline = sau) | 2513 | 3782 | 7671 | 2867 |
| FALLBACK | 150 | 346 | 386 | 44 |
| placeholder | 5962 | 4293 | 37.507 | 38.236 |
| thân hàm có semantic IR | 4615 | 5963 | 17.913 | 8983 |
| contract EXACT | 2433 | 3704 | 7670 | 2722 |
| shader: pass viết ra (trước → sau) | 0 → 96 | 0 → 3 | 0 → 48 | 0 → 29 |
| `shader_exact` | 0 / 24 | 0 / 3 | 0 / 34 | 0 / 30 |
| native plugin | — | — | 2/2 | 6/6 + `.meta` |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| field layout disagreement | 0 / 2165 | 0 / 1394 | 0 / 3947 | 0 / 2654 |
| golden corpus | 0 / 0 | 0 / 0 | 0 / 0 | 0 / 0 |

Source oracle RunFromZombies: `semantic_equivalence_rate` **1,0000 (36/36)**.
Test: 488 ca, 487 pass, một fail có sẵn. Shape checks sạch trên Impostor.
Unity không có: stage E–I `BLOCKED`, `runtime_status: NOT_RUN`.

Hai phép đo tự báo mình sai trong iteration này và cả hai phải sửa trước khi tin được:
`STORE_FIELD` đọc 0 trên 5916 `LOAD_FIELD` (instrumentation đặt sai chỗ), và `shader_exact` đọc 24/24
(phép đo neo vào *sự vắng mặt* của một chuỗi).

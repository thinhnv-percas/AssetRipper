# Iteration 059 — kết quả

Bản rip: `Test/Out59G-{z,i,m,j}`. Baseline: `Test/Out58H-*` tại commit `7babffb8`.

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| EXACT (058 → 059) | 2513 → 2515 | 3782 → 3782 | 8170 → 8170 | 2867 → 2867 |
| placeholder | 5962 | 4293 | 39.533 | 38.236 |
| file `.cs` đổi nội dung vì bản sửa tham số | 37 | 46 | 180 | 85 |
| `behaviour_equivalence_rate` | 1,0000 (35/35) | — | 0,6951 → **0,7284** | — |
| hàng ánh xạ blob shader | 13.143 | 1644 | 978 | 2532 |
| chỉ số chương trình ∩ chỉ số tham số | **0** | **0** | **0** | **0** |
| biến thể / chương trình khác nhau | 7153 / 1312 | 551 / 133 | 298 / 96 | 0 |
| shader SEMANTICALLY_EQUIVALENT | 9/24 | 2/3 | 1/7 → **3/7** | — (29 `METAL_BINARY_ONLY`) |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| field layout disagreement | 0 / 2165 | 0 / 1394 | 0 / 3947 | 0 / 2654 |
| golden corpus regression 058 → 059 | 0 | 0 | 0 | 0 |
| corpus hành vi | 50/50 | 84/84 | 86/86 | 73/73 |

Hai kết quả chính:

1. **Một lifted local sống ở đúng một chỗ.** 058 sửa một trong ba site; site ghi vẫn `stloc` vào một
   local bịa trong khi site đọc `ldarg` vào tham số. Tham số `ref`/`out` được gán vào chỗ người gọi
   không đọc. 348 file qua bốn fixture, mọi con số tổng y nguyên.
2. **`ParameterBlobIndices` phân hoạch bảng blob shader.** Hai tập chỉ số không giao nhau ở
   148/148 và 166/166 cặp (shader, backend) trên hai fixture. Kéo theo: 13 shader không có chương
   trình nào là do biến thể bị strip khỏi build (2523 entry kích thước 0), không do đọc sai bảng.

Và một tiền đề của brief bị dữ liệu bác bỏ: "197 FALLBACK của Merge-Room, phần lớn là loops bị mất" —
chỉ **6 trong 192** có vòng lặp trong nguồn. Nguyên nhân là oracle đọc toàn văn file nguồn trong khi
build chỉ biên dịch một nhánh `#if`.

Test: 508 ca, 507 pass, một fail có sẵn. Harness self-tests: 10/10, 5/5, 13/13, 11/11.
Unity không có: stage E–I `BLOCKED`, `runtime_status: NOT_RUN`.

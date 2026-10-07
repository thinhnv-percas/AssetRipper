# Iteration 068 — kết quả

Bản rip cuối: `Test/Out68z-{z,m,i,j,p,o}` từ một bản build, cộng `68zk-i` (`--package-cache`) và `68zn-j`
(`--no-cpp2il-injected-attributes --keep-global-qualification`). Baseline: 67x. Chi tiết: `docs/ITERATION_068.md`.
Log nén: `logs/`. Số theo fixture: `metrics/`. Artefact project: `artifacts/`.

## Tóm tắt

- **Immediate của thanh ghi W là `int`.** Regression Pinata DECOMP-0073 đã sửa bằng luật tổng quát, có test trên word
  lệnh thật.
- **Thanh ghi call trước làm hỏng không còn là đối số của call sau.** Đây là nguyên nhân gốc của `0xF7087C` (PROVEN).
  Lỗi thân: Impostor 194 → 156, Merge-Room 298 → 275, JellyBlastV2 1982 → 1693, Pinata 1136 → 1074.
- **Stride hằng giữ trong thanh ghi được chứng minh,** và member cộng riêng sau elements offset được gập. Stride đọc lúc
  chạy không bao giờ được gập.
- **Mỗi nửa `STP` mang độ rộng của nó.** STRUCT_FIRST_MEMBER: Merge-Room 21 → 15, JellyBlastV2 67 → 55, Pinata
  138 → 127.
- **`SetStruct<T>` trên field enum** được dựng lại trên kiểu của field.
- **Mỗi struct trên stack bị để nguyên mang tên luật từ chối;** dump producer theo địa chỉ native.
- **CLI:** `--emit-cpp2il-injected-attributes`, `--simplify-global-qualification`, `--keep-global-qualification`.
- **Behaviour:** RunFromZombies 1.0000 (35/35), Merge-Room 0.8338, Impostor 0.7587, JellyBlast độc lập 0.7849.
- **Không Unity:** `UNITY_NOT_AVAILABLE`. Không có FULLY_RECOVERED. Trạng thái: `PROJECT_GENERATED_COMPILE_IMPROVED`.

## Số liệu, 67x → 68z

| Fixture | EXACT | FALLBACK | Placeholder | Lỗi thân | Golden +/− |
|---|---|---|---|---|---|
| Impostor | 4449 → 4437 | 56 → 65 | 3406 → 3456 | 194 → 156 | 22/2 → 22/11 |
| Merge-Room | 11954 → 11876 | 212 → 233 | 18142 → 18046 | 298 → 275 | 16/2 → 16/22 |
| JellyBlastV2 | 5258 → 5247 | 38 → 38 | 12587 → 12709 | 1982 → 1693 | 31/2 → 31/2 |
| RunFromZombies | 2934 → 2931 | 57 → 57 | 3859 → 3920 | 7 → 7 | 22/2 → 23/5 |
| Pinata | 12971 → 12927 | 265 → 259 | 8442 → 8736 | 1136 → 1074 | — |
| opt-in | 8510 → 8502 | 115 → 115 | 19343 → 19210 | — | 31/2 → 31/2 |

Bất biến trên cả sáu: generatorFailures 0, layout mismatch 0, TrueAlias 0, parameter overwrite 0.

## Regression

- **REAL_REGRESSION mở:** không có.
- **REAL_REGRESSION gặp trong iteration và đã sửa:** Pinata exit 134 (stack overflow trong `ReachesFrom`).
- **EXPECTED_CHANGE / MEASUREMENT_CHANGE:** EXACT giảm nhẹ, golden regression và METHOD_NOT_FOUND tăng, JellyBlast độc
  lập −2 method. Tất cả là tên call giả từ MethodInfo cũ bị gỡ; mỗi trường hợp đã đọc, `docs/ITERATION_068.md` §4.

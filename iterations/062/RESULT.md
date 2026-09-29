# Iteration 062 — kết quả

Bản rip cuối: `Test/Out62m-{z,m,j,i,p}` (Impostor, Merge-Room, RunFromZombies, JellyBlastV2, Pinata).
Baseline: bản rip cuối của 061 (`Out61l-z`, `Out61m-m`, `Out61h-j`, `Out61i-i`, `Out61j-p`), đo lại
bằng cùng script.

| | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 | Pinata |
|---|---:|---:|---:|---:|---:|
| Lỗi `Decompiling` / field-layout disagree | 0 / 0 | 0 / 0 | 0 / 0 | 0 / 0 | 0 / 0 |
| EXACT | 4011 → 4027 | 11131 → 11184 | 2770 → 2785 | 3005 → 3014 | 12526 → 12526 |
| Placeholder | 4149 → 4291 | 26380 → 25580 | 4642 → 4578 | 36566 → 36304 | 13048 → 12974 |
| Interface dispatch giải quyết (tail) | 48 → 52 (4) | 505 → 551 (34) | 177 → 179 (12) | 36 → 56 (20) | 90 → 128 (38) |
| Interface corpus NOT_NAMED 061 → 062 | 1 → 0 | 3 → 0 | 4 → 0 | 4 → 0 | 0 → 0 |
| `MoveNext` trên enumerator mặc định | 113 → 5 | 244 → 5 | 30 → 5 | 95 → 0 | 126 → 112 |
| Storage TrueAlias | 1 | 0 | 0 | 2 | 0 |
| Shader fidelity EXACT | 9/9 | 29/30 | 7 pass nhúng | 0 (Metal) | 0 (không tên keyword) |
| `variant_binding_rate` | 0.5556 → 1.0 | 0.8000 → 1.0 | — | — | — |
| Golden corpus improved / regressed | 1 / 3 | 1 / 1 | 0 / 0 | 0 / 0 | — |
| Reference graph (so với rip cuối 061) | giống hệt | giống hệt | giống hệt | — | — |
| Source behavior | — | — | 1.0000 (35/35) | — | — |
| Unity build | — | — | `UNITY_NOT_AVAILABLE`, stage 2–5 `NOT_REACHED`, runtime `NOT_RUN` | — | — |

Bốn golden regression được giải thích từng cái ở `docs/ITERATION_062.md` §6: một là phép đo đọc tên
trong một đoạn IR không được emit, ba là một giá trị mặc định lặng lẽ thành một unresolved load báo
ra. Baseline golden không được đóng băng lại.

Nguyên liệu: `metrics/`, `interface-dispatch/` (bằng chứng + corpus), `shader-variant-fidelity/`,
`serialized-reference-graph/`, `storage/`, `source-behavior-RunFromZombies.json`,
`unity-build-RunFromZombies.{json,txt}`.

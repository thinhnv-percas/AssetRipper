# Iteration 061 — kết quả

Bản rip cuối: `Test/Out61l-z` (Impostor), `Test/Out61m-m` (Merge-Room), `Test/Out61i-i` (JellyBlastV2),
`Test/Out61h-j` (RunFromZombies), `Test/Out61j-p` (Pinata). Baseline: `Test/Out61c-*` (commit `fd40ca72`).

| | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 | Pinata |
|---|---:|---:|---:|---:|---:|
| Rip hoàn tất / lỗi `Decompiling` | ✓ / 0 | ✓ / 0 | ✓ / 0 | ✓ / 0 | ✓ / 0 (trước: exit 134) |
| Native AR = READER (method / field / size / generic) | 33436 / 21208 / 5012 / 36577 | 83496 / 55733 / 12895 / 82828 | 51393 / 30189 / 7486 / 44205 | 58890 / 36003 / 8702 / 45952 | — |
| File `.cs` đổi bởi sửa storage | 30 | 161 | 0 | 46 | — |
| EXACT / placeholder | 4011 / 4137 (không đổi) | — | — | — | — |
| Golden corpus regression | 0 | 0 | — | — | — |
| Program shader là source | 231 → 484 / 759 | 194 → 412 / 727 | — | 0 (Metal) | 1026 / 2976 |
| Variant "bị strip" | 457 → 0 | 291 → 0 | — | 0 | 0 |
| `variant_binding_rate` | 0.5556 (9) | 0.8000 (30) | — | — | keyword không ghi |
| Reference graph: GameObject / script / reference sai | 103 / 12 / 0 | 587 / 143 / 0 | 666 / 14 / 0 | — | — |
| Initial state bằng nhau | 0.9963 | 0.9924 | 0.9975 | — | — |
| Lifecycle khác biệt đã quyết định | 0 / 115 class | 0 / 294 | 0 / 14 | — | — |
| Storage hazard | 22 | 68 | 103 | 81 | — |
| Vùng quét interface: chết đã chứng minh | 26 / 78 | 88 / 869 | — | — | — |
| Unity build | — | — | `UNITY_NOT_AVAILABLE` | — | — |

Merge-Room không tất định (±50 method giữa các bản rip giống nhau), nên 161 file của nó đã được kiểm
từng cái: cả 161 đều mang một thay đổi `default(...)`, không cái nào là nhiễu.

Nguyên liệu: `native-cross-oracle/`, `serialized-reference-graph/`, `storage/`, `shader-variant-binding/`,
`runtime-snapshot/`, `lifecycle/`, `unity-build-RunFromZombies.json`.

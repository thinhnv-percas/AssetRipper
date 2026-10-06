# Iteration 066 — kết quả

Bản rip cuối: `Test/Out66i-{z,m,i,j,p,o}`, một bản build. Baseline: `Test/Out65z-*`, đo lại bằng script cuối. Chi tiết:
`docs/ITERATION_066.md`. Log nén: `logs/`. Số theo fixture: `metrics/`. Artefact project: `artifacts/`.

## Tóm tắt

- iOS: `UNKNOWN_CLASS_SOURCE` 2510 → 98 (opt-in 3072 → 118); dòng dispatch chưa giải 2582 → 168.
- JellyBlastV2: EXACT 3127 → 4349; placeholder 34947 → 16619.
- Oracle độc lập JellyBlast 0.6862 → 0.7594.
- Alloca kích thước động được mô hình: `localloc`, 995 trên Merge-Room.
- Mọi `UNKNOWN_RETURN` mang lý do; dòng invoker viết lại trên Merge-Room 64 → 80.
- Cờ C/V của ADDS/CMN không còn là hằng 0. Đây là lỗi giá trị sai im lặng có từ trước.
- Lỗi thân Merge-Room 324 → 310. Bốn họ P0 không đổi.
- Không có Unity: `UNITY_NOT_AVAILABLE`, không có FULLY_RECOVERED.

## File thay đổi

**Cpp2IL (vendored):**
- `Analysis/MetadataResolver` (usage qua địa chỉ tính);
- `Analysis/MetadataInitGuardRemover` (guard word, phần tiếp theo nhân đôi, block chuyển tiếp, xoá block bị làm cho
  không tới được);
- `Analysis/StackAnalyzer` (SP động, `Analyze(graph)`);
- `Analysis/InvokerArgumentRecovery` (`StackAlloc`, `PlanReturn`);
- `Analysis/FieldAddressArguments` (`FieldOfALoadedObject`);
- `Analysis/LocalVariables` (kiểu của `StackAlloc`);
- `ISIL/OpCode`, `ISIL/Instruction` (`StackAlloc`);
- `IlGenerator` (`localloc`);
- `InstructionSets/NewArmV8InstructionSet` (`mov sp, xN`, cờ ADDS).

**AssetRipper.Import:** `Il2CppIlRecoveryOutputFormat` (log 066).

**Tests:** `Il2CppIteration066Tests` (17). 661 pass, 1 lỗi có sẵn (Debug.Assert trong Release).

**Scripts:**
- Mới: `recovery_contract.py`, `buildability_matrix.py`, `project_artifact_check.py`.
- Sửa: `parameter_overwrite_scan.py`.

## Số liệu, 65z → 66i

| Fixture | EXACT | FALLBACK | Placeholder | Lỗi thân | Golden +/− |
|---|---|---|---|---|---|
| Impostor | 4474 → 4483 | 63 → 63 | 3440 → 3382 | 202 → 208 | 22 / 3 (cũ) |
| Merge-Room | 11923 → 11965 | 221 → 221 | 18601 → 18148 | 324 → 310 | 16 / 2 |
| RunFromZombies | 2967 → 2969 | 59 → 59 | 3902 → 3859 | 7 → 7 | 21 / 3 |
| JellyBlastV2 | 3127 → 4349 | 18 → 32 | 34947 → 16619 | 2599 → 2599 | 22 / 0 |
| Pinata | 13150 → 13178 | 286 → 285 | 8786 → 8442 | 1146 → 1144 | — |
| opt-in | 5357 → 7145 | 30 → 74 | 54695 → 25551 | — | 22 / 0 |

Bất biến:
- generatorFailures 0, layout disagreement 0, layout mismatch 0.
- TrueAlias 0 trên cả sáu.
- Parameter overwrite 0 trên cả sáu.
- RunFromZombies behaviour 1.0000 (35/35).

## Regression thật

- **Còn lại:** `byte*` gộp với `nint` → local `object` (14 lỗi; Impostor +6 ròng).
- **Đã sửa trước khi đóng:**
  - mô hình buffer invoker mất `StackAlloc`;
  - `(nint)stackalloc`;
  - block chết sau khi gập;
  - store qua SP (đã revert).

# Iteration 065 — kết quả

Bản rip cuối: `Test/Out65z-{m,z,j,i,p}` và `Test/Out65z-o` (JellyBlastV2, `CPP2IL_RECOVER_ALSO`), một bản build.
Baseline: `Test/Out64j-*`, đo lại bằng script cuối. Chi tiết: `docs/ITERATION_065.md`.

## Tóm tắt

- Lỗi thân Merge-Room 684 → 324, theo họ producer.
- Dispatch invoker viết lại với mọi đối số chứng minh được: 26 → 60 dòng.
- `UNKNOWN_CLASS_SOURCE` 196 → 54. Nguyên nhân gốc là frame pointer X29 của A64 chưa từng được resolve.
- `UNMANAGED_MEMORY_LOAD` giảm trên cả sáu fixture, không thêm một cast nào.
- RayFire được chứng minh trùng byte với mã đã link. iOS `__Internal` có 92/96 PROVEN. Version package được báo theo
  từng nguồn.
- Một lỗi giá trị sai im lặng có từ trước (thay `&slot` bằng `&i`) được tìm ra và sửa; có detector mới.
- Không có Unity: `UNITY_NOT_AVAILABLE`, không có FULLY_RECOVERED.

## File thay đổi

**Cpp2IL (vendored):**
- Mới: `Analysis/{ArgumentReturningHelper, InvokerArgumentRecovery, InlineListClearRecovery, StructRegisterFields}.cs`.
- Sửa: `StackAnalyzer` (alias frame X29, reset SP, store đọc qua địa chỉ ô gốc), `SsaForm`, `SsaSimplifier`,
  `Simplifier`, `DeadCodeEliminator`, `LocalVariables`, `MetadataResolver`, `InterfaceDispatchRecovery`,
  `InterfaceInvokeDataRecovery`, `RuntimeInterfaceResolver`, `FieldAddressArguments`, `FieldOffsetFrame`,
  `InlineOperationRecovery`, `IsilDump`, `ISIL/LocalVariable`, `IlGenerator`, `NewArmV8InstructionSet`,
  `MethodAnalysisContext`, `Arm64ArgumentPlacement`, `Arm64CallingConventionResolver`,
  `BaseCallingConventionResolver`, `README.md` (24–27).

**AssetRipper.Import:** `Il2CppIlRecoveryOutputFormat` (log 065), `PseudoCSharpWriter`, `Il2CppClassOffsetPatcher`.

**Tests:** `Il2CppIteration065Tests` (21), `Arm64ArgumentPlacementTests` (+2). 644 pass, 1 lỗi có sẵn (Debug.Assert
trong Release).

**Scripts:**
- Mới: `cluster_body_errors.py`, `method_status_diff.py`, `parameter_overwrite_scan.py`,
  `static_library_provenance.py`, `ios_native_unknown.py`, `package_manifest_reconstruction.py`,
  `recovered_project_plan.py`.
- Sửa: `recovery_metrics.py`, `native_dependency_graph.py`, `recovered_project_manifest.py`.

## Nguyên nhân gốc

| Triệu chứng | Tầng đầu tiên sai |
|---|---|
| Class interface không rõ nguồn (Merge-Room) | stack analysis: X29 không bao giờ là alias; `mov sp, x29` không reset stack state; address-take của bản ghi frame il2cpp |
| Đối số invoker không dựng được | store `args[1]` bị bỏ như store chết; `&slot` bị thay bằng `&i` |
| `i = 0;` trước `list[i]` | `SsaSimplifier` thay đích của `AddressOf` sang thanh ghi khác; `CopyCoalescer` gộp version của thanh ghi bị lấy địa chỉ |
| TrueAlias 0 → 1 tạm thời | `LoadsCallOperands` trả "có" cho `IndirectCall`, opcode mà generator không load toán hạng |
| `out value` kiểu `System.Object` | luật by-ref lấy kiểu từ instantiation chia sẻ |
| FALLBACK giả | rendering static field trần; `decimal.Zero` → `0m`; `?.` không là branch |

## Số liệu, 64j → 65z

| Fixture | EXACT | FALLBACK | Placeholder | Body errors | Golden +/− |
|---|---|---|---|---|---|
| Impostor | 4351 → 4474 | 154 → 63 | 3864 → 3440 | 237 → 202 | 22 / 3 (cũ) |
| Merge-Room | 11658 → 11923 | 396 → 221 | 23789 → 18601 | 684 → 324 | 16 / 1 (cũ) |
| RunFromZombies | 2935 → 2967 | 85 → 59 | 4405 → 3902 | 7 → 7 | 21 / 2 (1 cũ, 1 cosmetic) |
| JellyBlastV2 | 3100 → 3127 | 39 → 18 | 36141 → 34947 | 3005 → 2599 | 8 / 0 |
| Pinata | 12907 → 13150 | 337 → 286 | 11734 → 8786 | 1297 → 1146 | — |
| opt-in | 5308 → 5357 | 61 → 30 | 56398 → 54695 | — | 8 / 0 |

Bất biến:
- generatorFailures 0, layout disagreement 0, layout mismatch 0.
- RunFromZombies behaviour 1.0000 (35/35).
- Oracle độc lập JellyBlast 0.6817 → 0.6862.
- TrueAlias: 1/0/2/3 → **0/0/0/0** (Impostor/Merge-Room/JellyBlastV2/opt-in).

## Regression thật

- **Đã sửa:** `MMSwap` (khi alias frame vừa bật).
- **Còn lại:**
  - `ExtensionList.cs` +3 lỗi: thân fully shared có alloca động. `LayerMaskExtension.cs` −9 cùng lúc.
  - `JsonValidatingReader` EXACT → HIGH: local chưa gán đổi kiểu, giá trị không đổi.

## Bằng chứng mới

- Mã máy RayFire trùng từng byte.
- Wrapper → implementation trong `UnityFramework`.
- DLL Newtonsoft 3.2.1/3.2.2 trùng từng byte.
- Helper `0x17FDEF4` trả về đối số.
- Bản ghi frame il2cpp `{0, &a, &b}`.

## Blocker còn lại / mục tiêu kế tiếp

Xem `ROADMAP.md` "Sau iteration 065".

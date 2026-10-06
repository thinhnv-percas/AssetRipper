# Iteration 067 — kết quả

Bản rip cuối: `Test/Out67x-{z,m,i,j,p,o}`, một bản build, cộng `67xk-i` (`--package-cache`) và `67xn-j`
(`--no-cpp2il-injected-attributes`). Baseline: `Test/Out66i-*`, đo lại bằng script cuối. Chi tiết:
`docs/ITERATION_067.md`. Log nén: `logs/`. Số theo fixture: `metrics/`. Artefact project: `artifacts/`.

## Tóm tắt

- Struct trên stack là một storage. Kickoff async dạng con trỏ 120 → 16; `m_builder` JellyBlastV2 25 → 0. CS0122
  Merge-Room không quay lại mức 066h.
- Carry unsigned chính xác (`clt.un`/`cgt.un`), có test vector. Một REAL_REGRESSION ở Pinata (DECOMP-0073).
- Tham số lấy kiểu theo chỉ số của chính nó. `= ref *(` giảm trên cả sáu fixture.
- Write barrier iOS (pre-indexed): JellyBlastV2 EXACT 4330 → 5258, placeholder 16619 → 12587, lỗi thân 2599 → 1982.
- Hai tuỳ chọn output trong một cấu hình, CLI và GUI:
  - "Emit Cpp2ILInjected Attributes" (mặc định bật; tắt: 22511 attribute → 0);
  - "Simplify global:: Qualification" (mặc định bật; Merge-Room 36 → 0, Impostor giữ 18 vì va chạm thật).
- Package UPSTREAM_EXACT vào manifest: mathematics 1.2.6, textmeshpro 3.0.9, visualscripting 1.9.11. Lock BLOCKED.
- Oracle độc lập JellyBlast 0.7594 → 0.7864; RunFromZombies behaviour 1.0000.
- Không Unity: `UNITY_NOT_AVAILABLE`. Không có FULLY_RECOVERED. Trạng thái: `PROJECT_GENERATED_COMPILE_IMPROVED`.

## File thay đổi

**Cpp2IL (vendored)**, mỗi chỗ đánh dấu `AssetRipper:`. Danh sách ở `Source/External/README.md` mục 30:
- `InstructionSets/Arm64FlagLifting` (mới), `NewArmV8InstructionSet`, `ISIL/Instruction.IsUnsigned`,
  `Analysis/FlagConditionRecovery`;
- `ISIL/StackOffset.Size`, `Analysis/StackAnalyzer`, `Analysis/StackStructStorage` (mới);
- `ISIL/LocalVariable.ParameterIndex`, `Analysis/LocalVariables`, `Analysis/FieldAddressArguments`,
  `Analysis/MetadataResolver`, `Analysis/InvokerArgumentRecovery`;
- `IlGenerator`;
- `NewArm64KeyFunctionAddresses`.

**AssetRipper:**
- `RecoveredCodeOutputOptions`, `Il2CppRecoverySetup`;
- `ImportSettings`, `ExportSettings`, `FullConfiguration`;
- `ScriptExporter`, `ScriptDecompiler`, `GlobalQualificationSimplifier` (mới);
- GUI `SettingsPage` và localization; SystemTester (`--no-cpp2il-injected-attributes`, `--no-simplify-global`,
  `--package-cache`).

**Tests:** `Il2CppIteration067Tests`, `Il2CppOutputOptionsTests`, `Il2CppStackStructStorageTests` (15).

**Scripts:**
- Mới: `proven_package_cache.py` (self-test 8).
- Sửa:
  - `parameter_overwrite_scan.py`: out/ref tách riêng, self-test 16;
  - `recovery_metrics.py`: accessor auto-property đã gập, self-test 14.

## Số liệu, 66i → 67x (cả hai đầu đo bằng script cuối)

| Fixture | EXACT | FALLBACK | Placeholder | Lỗi thân | File sạch | Golden +/− |
|---|---|---|---|---|---|---|
| Impostor | 4447 → 4449 | 57 → 56 | 3382 → 3406 | 208 → 194 | 0.625 → 0.641 | 22/3 → 22/2 |
| Merge-Room | 11944 → 11954 | 214 → 212 | 18148 → 18142 | 310 → 298 | 0.595 → 0.607 | 16/2 → 16/2 |
| RunFromZombies | 2933 → 2934 | 57 → 57 | 3859 → 3859 | 7 → 7 | 0.783 → 0.783 | 22/3 → 22/2 |
| JellyBlastV2 | 4330 → 5258 | 27 → 38 | 16619 → 12587 | 2599 → 1982 | 0.352 → 0.453 | 25/2 → 31/2 |
| Pinata | 12972 → 12971 | 265 → 265 | 8442 → 8442 | 1144 → 1136 | 0.645 → 0.646 | — |
| opt-in | 7108 → 8510 | 63 → 115 | 25551 → 19343 | — | — | 25/2 → 31/2 |

Bất biến trên cả sáu:
- generatorFailures 0, layout disagreement 0, layout mismatch 0;
- TrueAlias 0, parameter overwrite 0;
- RunFromZombies behaviour 1.0000 (35/35); oracle độc lập JellyBlast 0.7864, không dưới 0.7594.

## Regression thật

- **Còn lại:** Pinata `FBSDKViewHiearchy.CheckPathMatchPath`. Carry unsigned của một `-1` không kiểu chạy ở 64 bit
  (DECOMP-0073).
- **Đã sửa trước khi đóng:**
  - store vector chép `Matrix4x4` bị gọi là store member;
  - ba guard quanh `0xF7087C` (revert).

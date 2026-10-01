# Iteration 064 — kết quả

Bản rip cuối: `Test/Out64j-{m,z,j,i,p}` và `Test/Out64j-o` (JellyBlastV2, `CPP2IL_RECOVER_ALSO`). Baseline 063:
`Test/Out63g-*`, `Test/Out63o3-i`. Chi tiết: `docs/ITERATION_064.md`.

## Tóm tắt

Bốn P0 của brief, mỗi cái sửa ở tầng đầu tiên sai: ghi qua `ref` (field search + `stobj`), ABI của thân generic
chia sẻ hoàn toàn (`il2cppRetVal`), CAS runtime đặt tên theo lệnh máy với overload theo call site, và CS0102 ở
Merge-Room (accessor chuẩn + backing field tên compiler). Native graph, package provenance, serialize policy,
binding material → MSL, project manifest và scenario schema được thêm như phép đo, không như project giả.
Không có Unity: runtime `NOT_RUN`, không có FULLY_RECOVERED.

## File thay đổi

Cpp2IL (vendored): `Analysis/{ValueFlow, FullGenericSharing, CompareExchangeRecovery, FieldAddressArguments,
RuntimeInterfaceResolver}.cs` (mới); `AtomicIntrinsicRecognizer`, `MetadataResolver`, `LocalVariables`,
`KeyFunctionRecovery`, `InterfaceInvokeDataRecovery`, `DeadCodeEliminator`, `RecoveredSemanticIr`, `IlGenerator`,
`MethodAnalysisContext`, `Arm64CallingConventionResolver`, `BaseCallingConventionResolver`, `README.md` (21–23).
AssetRipper.Import: `SerializedFieldPolicy.cs` (mới), `EventDeclarationPolicy`, `Il2CppIlRecoveryOutputFormat`.
Tests: `Il2CppValueFlowTests` (8), `SerializedFieldPolicyTests` (8), `Il2CppAtomicIntrinsicTests` (+7),
`Il2CppEventDeclarationTests` (+2) — 621 pass, 1 lỗi có sẵn (Debug.Assert trong Release).
Scripts: `native_dependency_graph.py`, `package_provenance.py`, `recovered_project_manifest.py` (mới);
`recovery_metrics.py`, `cluster_native_int_casts.py --trace`, `shader_variant_binding.py`, `runtime_smoke_contract.py`,
`check_recovered_shapes.sh`, `semantic_ir.py`, `method_*_contract.py`.

## Nguyên nhân gốc

| Issue | Tầng đầu tiên sai |
|---|---|
| DECOMP-0056 SetColor | `ResolveFieldOffsets` lấy byref làm owner; `StoreToOperand` ghi `[ref+0]` bằng `starg` |
| DECOMP-0058 RGCTX "không có kiểu" | calling convention của thân fully shared đặt `MethodInfo` sai thanh ghi |
| DECOMP-0059 CAS | callee không có method managed; operand và overload chưa được đọc từ lệnh / call site |
| DECOMP-0055 CS0102 | accessor không bao giờ field-like (CAS + cast mở rộng); field event bị widen vì body inline đọc nó |
| DECOMP-0060 (đo) | rendering bị cắt giữa định danh |

## Số liệu trước / sau

| Fixture | EXACT | Placeholder | FALLBACK | Roslyn A-CSharp (body) |
|---|---|---|---|---|
| Impostor | 4042 → 4335 | 4301 → 3864 | 170 → 170 | 237 → 237 |
| Merge-Room | 11221 → 11484 | 25697 → 23789 | 565 → 573 | 5 (1) → 4 (684) |
| RunFromZombies | 2785 → 2820 | 4581 → 4405 | 201 → 201 | 7 → 7 |
| JellyBlastV2 | 3027 → 3056 | 36383 → 36141 | 84 → 84 | 11 (3038) → 11 (3005) |
| Pinata | 12533 → 12790 | 12990 → 11734 | 456 → 454 | 1355 → 1297 |

generatorFailures 0, layout disagreement 0, MonoBehaviour layout mismatch 0 (cả năm); RunFromZombies behaviour
1.0000 (35/35); oracle độc lập JellyBlast 0.6802 → 0.6817; TrueAlias không đổi; shape check Impostor đều PASS,
DECOMP-0056 PASS trên rip opt-in. Gán lại ref: 143 → 44 / 842 → 148 / 1000 → 520 (opt-in) / 172 → 80 (Pinata).
Dispatch interface giải quyết (phân biệt, Merge-Room) 251 → 263. CAS: 318 / 686 / 18 / 74 / 476 (476/476 Pinata).

## Regression

Không REAL_REGRESSION. Golden: Impostor 3 (GUIManager, AnimationMatchModifierAsset, Skin — đã đọc ở 062),
Merge-Room 1 (MMFeedbacks, như 062), RunFromZombies 1 (`ConvertUtils.TryConvert`: gán lại ref sai thành gán
đúng qua một local `object`, metric đếm là untyped).

## Measurement change

Accessor event gập thành field-like event không còn thân để đo; `m_X` và `_003CX_003Ek__BackingField` là X;
dòng bị cắt của rendering bị bỏ; Merge-Room Assembly-CSharp lần đầu bind được (684 lỗi thân thật);
Merge-Room FALLBACK +8 đọc từng cái (placeholder hết làm lộ kiểm tên; `?.` không đếm là branch).

## Blocker còn lại

Runtime NOT_RUN (không Unity). Invoker dispatch 46 (đối số chưa dựng). `libRF_CNative_ios.a` phải do vendor cấp
lại. 3 nhóm `__Internal` UNKNOWN. Package stub chưa khai báo trong manifest xuất ra. Merge-Room 684 lỗi thân.

## Việc tiếp theo chính xác

Xem `ROADMAP.md` "Sau iteration 064" (7 mục, mỗi mục có bằng chứng và điều kiện dừng).

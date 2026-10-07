# Iteration 068 — Native value provenance, compile recovery & Unity runtime gate

Bản rip cuối: `Test/Out68z-{z,m,i,j,p,o}` từ một bản build, cộng `68zk-i` (`--package-cache`) và `68zn-j`
(`--no-cpp2il-injected-attributes --keep-global-qualification`). Baseline: 67x, các số lấy từ `iterations/067/metrics`
và đo bằng cùng script. Báo cáo chi tiết:
- `reports/REGISTER_WIDTH_068.md`
- `reports/STALE_REGISTER_ARGUMENTS_068.md`
- `reports/NATIVE_VALUE_PROVENANCE_068.md`
- `reports/STRUCT_REJECTION_REASONS_068.md`
- `reports/BUILDABILITY_068.md`

## 1. Kết luận

- **Regression Pinata của 067 đã sửa bằng một luật tổng quát.** Không phải ca riêng cho -1: một immediate trên đường dữ
  liệu 32 bit là `int` mang đúng các bit đó.
- **Nguyên nhân gốc của `0xF7087C` đã tìm ra, PROVEN.** Một MethodInfo do call trước để lại trong X3 đọc như đối số của
  call sau. Cùng gốc với ba lỗi im lặng khác: `__cxa_end_catch` thành `Buffer.Claim`, `HashSet.Remove` gọi trên một
  exception, và `default(StreamingContext)` thay cho `context`.
- **Lỗi thân giảm trên mọi fixture có thể compile:** Impostor 194 → 156, Merge-Room 298 → 275, JellyBlastV2 1982 → 1693,
  Pinata 1136 → 1074. RunFromZombies giữ 7.
- **EXACT giảm nhẹ trên bốn fixture.** Mỗi trường hợp đã đọc: đó là tên giả bị gỡ, không phải mất ngữ nghĩa (mục 4).
- **Không có FULLY_RECOVERED. Unity: `UNITY_NOT_AVAILABLE`.** Trạng thái: `PROJECT_GENERATED_COMPILE_IMPROVED`.

## 2. Các stage

| Stage | Kết quả |
|---|---|
| A — native | `generatorFailures` 0, layout disagreement 0, layout mismatch 0 trên cả sáu |
| B — semantic | EXACT 82.5 / 74.3 / 70.5 / 75.4 / 80.1 / 71.6 % |
| C — project | refs 0.9942 / 0.9998 / 1.0 / 1.0 / 1.0; chỉ RunFromZombies PASS stage A–C |
| D — compile | lỗi thân 156 / 275 / 1693 / 7 / 1074; không fixture nào sạch |
| E — Unity import | UNITY_NOT_AVAILABLE |
| F — Unity build | UNITY_NOT_AVAILABLE |
| G — runtime | UNITY_NOT_AVAILABLE |
| H — behaviour (tĩnh) | RunFromZombies 1.0000 (35/35), Merge-Room 0.8338, Impostor 0.7587, JellyBlast độc lập 0.7849 |

## 3. Số liệu, 67x → 68z

| Fixture | Native | EXACT | Fallback | Placeholder | Lỗi thân | File sạch (body pass) | Golden +/− | TrueAlias | UnknownAlias |
|---|---|---|---|---|---|---|---|---|---|
| Impostor | PASS | 4449 → 4437 | 56 → 65 | 3406 → 3456 | 194 → **156** | 41/64 → 41/64 | 22/2 → 22/11 | 0 | 13 |
| Merge-Room | PASS | 11954 → 11876 | 212 → 233 | 18142 → **18046** | 298 → **275** | 50/84 → 51/84 | 16/2 → 16/22 | 0 | 43 |
| JellyBlastV2 | PASS | 5258 → 5247 | 38 → 38 | 12587 → 12709 | 1982 → **1693** | 79/179 → 79/179 | 31/2 → 31/2 | 0 | 32 |
| RunFromZombies | PASS | 2934 → 2931 | 57 → 57 | 3859 → 3920 | 7 → 7 | 18/23 → 18/23 | 22/2 → 23/5 | 0 | 36 |
| Pinata | PASS | 12971 → 12927 | 265 → 259 | 8442 → 8736 | 1136 → **1074** | 716/1109 → 724/1109 | — | 0 | 14 |
| JellyBlastV2 opt-in | PASS | 8510 → 8502 | 115 → 115 | 19343 → **19210** | — | — | 31/2 → 31/2 | 0 | 53 |

Bất biến trên cả sáu:
- parameter overwrite 0;
- TrueAlias 0;
- RunFromZombies behaviour 1.0000 (35/35, §25).

Behaviour oracle:
- Impostor 0.7587 → 0.7587;
- Merge-Room 0.8331 → 0.8338;
- JellyBlast INDEPENDENT 0.7864 → 0.7849 (mục 4).

Shape check: Impostor 18 PASS / 2 FAIL / 3 SKIP. Hai FAIL là DECOMP-0021, đã fail từ 065. Pinata: DECOMP-0073 PASS.

## 4. Regression, trước/sau, nguyên nhân, xử lý

| Thay đổi | Trước → sau | Nguyên nhân gốc | Nhãn | Xử lý |
|---|---|---|---|---|
| Golden Impostor/Merge-Room/RunFromZombies tụt | regressed 2/2/2 → 11/22/5 | tên call giả từ MethodInfo cũ đã bị gỡ: Sirenix `BinaryDataWriter` ×11, `__cxa_begin_catch` mang tên `Queue.Enumerator.Dispose` (`MemoryTraceWriter`) | EXPECTED_CHANGE | giữ |
| METHOD_NOT_FOUND tăng | Impostor +78, Merge-Room +234, JellyBlastV2 +502, RunFromZombies +61 | cùng nguyên nhân: boundary trung thực thay cho tên giả | EXPECTED_CHANGE | giữ |
| JellyBlast INDEPENDENT | 0.7864 → 0.7849 (2 method) | `Serialization.StartOperation` từng có `((HashSet)(object)ex2).Remove(...)`, tên giả khớp với `Remove` của nguồn. `EndOperation` cùng lớp, INFERRED cùng hình dạng. VERSION_MISMATCH 381 → 380: `RFDictionary.GetRFDictionary` từng index một `List` bằng `(int)typeof(RFDictionary)` | MEASUREMENT_CHANGE | giữ; đo per-method bằng một bản build 343014e2 dựng lại |
| Merge-Room 21 method PARTIAL → FALLBACK | — | `ES3Type_*Module.Read<T>` mất placeholder vì `MethodSlotDispatchRecovery` giờ nhận generic virtual call; phép kiểm tên thấy một call `0x17FDF50` khởi tạo method mà generator không bao giờ phát | MEASUREMENT_CHANGE | giữ |
| Behaviour oracle tụt khi `STP` có độ rộng | RunFromZombies 1.0 → 0.9714, Merge-Room 0.8331 → 0.8304 | semantic IR ghi `STORE_FIELD x`, không ghi `firstSpawn`/`_rot` cho một bản sao từng member đúng hành vi | MEASUREMENT_CHANGE | đã sửa ở nguồn bản ghi; về 1.0000 và 0.8338 |
| Pinata exit 134 | crash giữa rip (68e) | `ReachesFrom` đệ quy mở rộng một vòng phi mãi | REAL_REGRESSION | đã sửa (worklist), có test |

Không còn REAL_REGRESSION nào mở.

## 5. Proven / Inferred / Unknown / Blocked

**Proven:**
- immediate W là `int` (lift từ word lệnh thật, 8/22 test đỏ khi bỏ luật);
- thanh ghi caller-saved không qua call (AAPCS64), và nguyên nhân gốc 0xF7087C;
- stride hằng giữ trong thanh ghi;
- độ rộng mỗi nửa `STP`;
- `0x179CE74` đọc buffer, còn `0xE6A35C` không đọc: phép đo xác nhận suy luận của 067;
- `SetStruct<T>` trên field enum.

**Inferred:**
- gắn OBJECT_AS_NATIVE_INT với producer theo method, không theo biểu thức;
- `Serialization.EndOperation` cùng hình dạng với `StartOperation`.

**Unknown:**
- member đầu ở offset 0 của phần tử struct mà load không mang độ rộng;
- lỗi OBJECT_AS_NATIVE_INT không gắn được producer: 10 trên Merge-Room, 76 trên JellyBlastV2;
- `0xF7087C` vẫn không được đặt tên, và đó là đúng.

**Blocked:**
- Unity import/build/runtime (không có editor);
- `packages-lock.json` (không có nguồn hash);
- `shader_exact` (cần ShaderLab nguồn).

## 6. Hai cấu hình output đã kiểm

RunFromZombies, mặc định so với `--no-cpp2il-injected-attributes --keep-global-qualification`:
- attribute Cpp2ILInjected 22504 → 0;
- `[NativeSource]` 3926 cả hai;
- `global::` 0 → 1;
- `.cs` 796 → 751;
- lỗi Roslyn 7 → 7.

Mặc định giữ nguyên hành vi cũ. `BUILDABILITY_068.md` §5.

## 7. Sẵn sàng runtime

- Không có Unity: không cổng runtime nào chạy.
- Project được sinh, nhưng không fixture nào compile sạch.
- RunFromZombies gần nhất: 7 lỗi, stage A–C PASS, behaviour tĩnh 1.0000.
- Package UPSTREAM_EXACT vào manifest. Lock BLOCKED.
- Native plugin của game được chép: Merge-Room, Pinata, JellyBlastV2.

## 8. Thay đổi code

**Cpp2IL, đánh dấu `AssetRipper:`** (`Source/External/README.md` mục 31):
- `NewArmV8InstructionSet`: `ImmediateAtWidth`, `LiftImmediate`, `PairAccessWidth`, `NativeAddress`.
- `IlGenerator`: bit float âm; ghi field chứa ngoài cùng vào semantic IR.
- `MetadataResolver`:
  - `ReachesWithoutAnInterveningCall`, `ReplaceClobberedRawArguments`;
  - từ chối MethodInfo cũ;
  - `SharingPlaceholderAdmits`, `InstantiateMethodParameterOn`.
- `MethodAnalysisContext`, `FieldAddressArguments`.
- `StackStructStorage`: lý do từ chối, `IsPadding`.
- `ArrayRecovery`: `DefinitionMap`, `ConstantHeldBy`, unwrap hằng ≥ elements offset.
- `Instruction.NativeAddress`.

**AssetRipper:**
- `Il2CppIlRecoveryOutputFormat`: `CPP2IL_DUMP_UNTYPED`, dòng log `(068)`.
- `SystemTester`: `--emit-cpp2il-injected-attributes`, `--simplify-global-qualification`,
  `--keep-global-qualification`.

**Test:** `Il2CppIteration068Tests` (31 case), `Il2CppScaledIndexTests` (9 → 19), `Il2CppStackStructStorageTests` (15 → 21).
781/782 pass; case fail duy nhất là `GetMainExportID_ValueGreaterThan100000_DebugAssertFails`, đã fail từ trước 068.

**Script:** `untyped_producers.py` (mới, self-test 11); `check_recovered_shapes.sh` (`check_if_present`, DECOMP-0073).

## 9. Đã thử và loại

- **Luật thanh ghi cũ trong `InvokerArgumentRecovery`.** Pass chạy sau SSA destruction, khi một lần nạp lại đã bị gập vào
  bản sao cũ. Đã revert.
- **Luật padding** viết đúng nhưng chưa bắn lần nào. Store đến từ `StructSlotAliasRecovery` không có độ rộng, nên
  không chứng minh được vùng đó là padding. Để nguyên, ghi là việc tiếp theo.

# Iteration 069 — Trạng thái tool và kế hoạch hoàn thiện

Ngày đo: 2026-10-15, trên nhánh `claude/read-current-repository-daqxc1` @ `68db4b31` (cuối iteration 068).
Mọi con số dưới đây là **tự đo lại trong container** bằng đúng lệnh và script của repo, không chép từ tài liệu.

## 0. Tóm tắt cho người vội

- **Tool nào cần hoàn thiện?** Nhánh này (`claude/read-current-repository-daqxc1`): IL2Cpp → C# recovery trên Cpp2IL vendored, 68 iteration, 782 test. Nhánh `codegraph-csharp-setup-07l07b` (pipeline tự viết, Level4) chưa từng xuất được thân hàm nào và không có gì đáng port — dừng nó.
- **Trạng thái hôm nay, tự đo lại trong container trống**: build 0 lỗi; test 781/782 (ca fail là test upstream chỉ fail ở Release); rip 5 fixture **khớp 068 từng chữ số**. Pinata (game của bạn): 16.146 method, **80,1 % EXACT**, 8736 placeholder, **1074 lỗi thân** Assembly-CSharp; không fixture nào compile sạch; cổng Unity E–G chưa bao giờ chạy (không có editor).
- **Phát hiện lớn nhất (PROVEN, đo đủ 5 fixture)**: một lỗi upstream Cpp2IL làm **mọi** `Derived : Base<T>` có `BaseType == null`, cắt chuỗi base trong `BaseChainFieldSearch` (Pinata 421 type, Impostor 398). Patch 36 dòng (chưa commit, phụ lục A): Pinata lỗi thân **1074 → 876**, placeholder **8736 → 8534**, EXACT **+154**, 154 method PARTIAL→EXACT, 0 chiều ngược; 4 fixture kia trung tính hoặc tốt lên nhẹ; 0 regression golden/shape; test không đổi. Cụm lỗi lớn nhất của bạn (185 × `((Fsm)0)` trong PlayMaker) biến mất, đọc đúng như nguồn.
- **Ba lỗi project chưa ai ghi**: mọi `.asmdef` có `references: []` (Unity sẽ CS0246 hàng loạt trước cả lỗi thân); `.so` Android không có `.meta` PluginImporter; GUI mặc định (`Hybrid`) chỉ decompile `Assembly-CSharp*` — 40/42 assembly Pinata ra DLL, người dùng GUI không thấy thân hàm đã phục hồi.
- **Kế hoạch**: iteration 069 = A1 (patch) + A2 (Pinata vào ma trận) + C1/C2/C3 (ba lỗi project/GUI trên) + A3 (phân cụm lỗi Pinata theo producer) + bạn chạy cổng Unity trên Windows theo checklist §7. Iteration 070 = họ FRAMEWORK_PRIVATE_MEMBER (≈208 lỗi Pinata) + độ rộng load + trang Log/copy clipboard. Chi tiết §4–§5; "đã thử và loại — không làm lại" §6; checklist Unity §7; đối chiếu với khảo sát độc lập (6 reader, 10 skeptic, critic) §9; việc hoãn có lý do §10. Số đo của mọi bảng nằm trong `iterations/069/`.
- **Cần ở bạn**: (1) máy Windows có Unity 2019.2.6f1 (Pinata) và 2022.3.62f2 (Impostor) để mở cổng E–G; (2) **source project Pinata nếu có** — biến Pinata thành source oracle trên codegen 2019.2 (A6).

## 1. Tool này là gì, và nhánh này so với nhánh kia

| | `claude/read-current-repository-daqxc1` (nhánh này) | `claude/codegraph-csharp-setup-07l07b` |
|---|---|---|
| Cách tiếp cận | Vendor Cpp2IL (`Source/External`, commit upstream `cae273a`, 94 chỗ sửa đánh dấu `AssetRipper:`), lift ISIL → CIL → ILSpy; `ScriptContentLevel.Level3` | Pipeline tự viết từ đầu (`AssetRipper.Il2CppRestore.*`, 5 project), `Level4` chạy sau export |
| Lịch sử | 327 commit, 68 iteration có ghi chép, 5 fixture, 782 test | 10 commit |
| Kết quả trên Pinata | 16.146 method có địa chỉ native, **80,1 % EXACT**, 3130 file `.cs`, 1074 lỗi thân Assembly-CSharp | Chưa từng xuất được một thân hàm nào vào script (registration/struct offset tự viết sai theo version) |
| Kết luận | **Đây là tool cần hoàn thiện.** | Dừng; không có gì đáng port sang (mọi thứ nhánh đó cố làm — tìm registration, đọc metadata, lift ARM64 — Cpp2IL đã làm đúng và tốt hơn). Riêng yêu cầu "copy toàn bộ log console ra clipboard" là việc GUI, chuyển sang kế hoạch này (mục C). |

## 2. Trạng thái hiện tại, đo lại

### 2.1 Build, test

- Container không có .NET SDK; cài `dotnet-install.sh --channel 10.0` → SDK 10.0.402. `dotnet build AssetRipper.slnx -c Release`: **0 lỗi**.
- `dotnet test -c Release --no-build`: **781/782 pass**. Ca fail duy nhất `ExportIdHandlerTests.GetMainExportID_ValueGreaterThan100000_DebugAssertFails` là test upstream mong `Debug.Assert` ném — chỉ fail ở Release (assert bị biên dịch bỏ). Không liên quan recovery; đã fail từ trước 068 (docs/ITERATION_068.md §8).
- `nuget.config` khai một nguồn `nuget.samboy.dev` (không `<clear/>`, nên nuget.org kế thừa từ config máy). ~22 gói `AssetRipper.*` (Primitives 3.2.0, CIL, …) và `Disarm` **chỉ có trên feed đó** — build bắt buộc tới được `nuget.samboy.dev`; một mạng chặn feed này sẽ fail ở restore (NU1301), không có đường vòng ngoài cache local.
- Không có `global.json`; container cài SDK 10.0.402, CI upstream dùng `10.0.x`.

### 2.2 Rip và đo (cùng script của repo: `recovery_metrics.py`, `placeholder_families.py`, `compile_recovered_scripts.sh`, `golden_corpus.py`, `check_recovered_shapes.sh`)

| | Impostor (`Test/Out69s-i`) | Pinata (`Test/Out69s-p`) | 068 ghi (`reports/regression-matrix.md`) |
|---|---:|---:|---|
| thời gian rip (4 core) | 54 s | 110 s | — |
| file `.cs` | 830 | 3130 | — |
| method có địa chỉ native | 5376 | 16.146 | — |
| EXACT | **4437** (82,5 %) | **12.927** (80,1 %) | 4437 / 12.927 ✔ |
| HIGH_CONFIDENCE | 190 | 659 | — |
| PARTIAL | 684 | 2299 | — |
| FALLBACK | **65** | **259** | 65 / 259 ✔ |
| MISSING | 0 | 2 (`YandexAppMetricaReceipt/Config`, 76 byte) | 2 (AGENT_STATE 047) ✔ |
| placeholder | **3456** | **8736** | 3456 / 8736 ✔ |
| lỗi thân Assembly-CSharp (Roslyn, body pass) | **156** / 64 file | **1074** / 1109 file | 156 / 1074 ✔ |
| shape check | 18 PASS / 2 FAIL (DECOMP-0021, fail từ 065) | corpus viết cho Impostor → không áp | ✔ |
| golden corpus | 11 regression, tất cả EXPECTED_CHANGE (068 §4) | CORPUS_NOT_APPLICABLE (exit 3) | ✔ |

**Mọi con số khớp từng chữ số với 068.** Trạng thái tool tái lập được hoàn toàn từ repo trong một container trống.

Placeholder theo họ:

| họ | Impostor | Pinata |
|---|---:|---:|
| UNMANAGED_MEMORY_LOAD | 1945 (56 %) | 3879 (44 %) |
| METHOD_NOT_FOUND | 419 | 2232 (26 %) |
| NATIVE_IMPORT (PLT, đã đặt tên) | 551 | 1689 |
| INDIRECT_CALL | 177 | 301 |
| UNKNOWN_CALL_TARGET | 97 | 300 |
| INDIRECT_JUMP | 54 | 207 |
| UNRESOLVED_DELEGATE | 0 | 122 |
| NOT_IMPLEMENTED_INSTRUCTION | 211 | 5 |

### 2.3 Cổng chất lượng (068, không đổi)

| Stage | Trạng thái |
|---|---|
| A native (generatorFailures, layout mismatch, TrueAlias) | PASS, 0/0/0 trên cả 5 fixture |
| B semantic (EXACT) | 70–82 % |
| C project (reference resolution) | chỉ RunFromZombies PASS |
| D compile | **không fixture nào sạch** (7 … 1693 lỗi thân) |
| E–G Unity import/build/runtime | **UNITY_NOT_AVAILABLE** — chưa bao giờ chạy |
| H behaviour tĩnh | RunFromZombies 1.0000; Merge-Room 0,83; Impostor 0,76; JellyBlast 0,78 |

Trạng thái chính thức: `PROJECT_GENERATED_COMPILE_IMPROVED`. Chưa có `FULLY_RECOVERED`.

### 2.4 Pinata — game của bạn — đọc kỹ 1074 lỗi thân

| mã | số | cụm lớn nhất | họ |
|---|---:|---|---|
| CS0030 | 810 (75 %) | `'int' → 'HutongGames.PlayMaker.Fsm'` **185**; `'float' → 'Vector3'` 46; `RaycastHit → float` 25; `Type → IntPtr` 20 | local không kiểu / load không phân giải (ROADMAP §5) |
| CS0122 | 121 | `Rect.m_XMin` 27, `RaycastHit2D.m_Centroid` 19, `RaycastHit.m_Normal` 7, `JointMotor2D.m_*` 12 | FRAMEWORK_PRIVATE_MEMBER: getter struct UnityEngine bị inline, pairing chưa gập |
| CS1061 | 87 | `Selectable.m_Navigation/m_Colors` 38, `List<T>._items` 26 | cùng họ trên |
| CS0019 | 24 | `DynamicBone.Particle + int` 8 | địa chỉ phần tử struct (ARRAY_ELEMENT_ADDRESS) |
| CS0117 | 11 | `MonoBehaviour._002Ector` 8 | DECOMP-0006 (bị chặn sau DECOMP-0004) |
| khác | 21 | CS0246 `_003F`, CS1612, CS0165, CS0023, CS0103 | lẻ |

385 file có lỗi; 10 file tệ nhất: `DynamicBone.cs` 30, `ProGrids/pg_Util.cs` 27, 6 file PlayMaker Actions 15–23, 3 file Tayx/Graphy 14–17.

**Cụm 185 `((Fsm)0)` — nguyên nhân gốc đã chốt bằng probe, không phải suy đoán:**

1. Mọi site là `base.Fsm` của một action kế thừa `ComponentAction<T> : FsmStateAction`; il2cpp inline getter thành load `[this + 0x30]`; `FsmStateAction.fsm` nằm đúng `[FieldOffset(0x30)]` (file export `PlayMaker/HutongGames/PlayMaker/FsmStateAction.cs:54`).
2. `CPP2IL_DUMP_LOADS`: 175 dòng `ComponentAction` ghi `RESOLVABLE:field-at-this-exact-offset … EXACT:fsm … SEARCH_EMPTY` — probe tìm thấy, pass thì không.
3. ISIL dump `SetAudioClip::OnEnter` (`023-after ResolveTypesAndFields`): base **đã có kiểu** `SetAudioClip`, kết quả đã nhận kiểu `Fsm` từ tham số call, nhưng operand vẫn là `MemoryOperand`.
4. Probe chạy trên context thật của Pinata (`scratchpad/probe-fsm`): `ComponentAction<AudioSource>.BaseType == null` trong khi `ComponentAction`1.BaseType == FsmStateAction`. `BaseChainFieldSearch` đi `SetAudioClip → ComponentAction<AudioSource> → null` và dừng; `FsmStateAction` **không bao giờ được hỏi**.
5. Code: `Source/External/Cpp2IL.Core/Model/Contexts/GenericInstanceTypeAnalysisContext.cs` có hai constructor; bản `private (Il2CppType, ApplicationAnalysisContext)` — đường `GetOrCreate`, tức **mọi** `Derived : Base<T>` đọc từ metadata — không bao giờ gán `DefaultBaseType`; chỉ bản public `(genericType, args)` gán. Đây là code upstream Cpp2IL nguyên bản (`git log -L` → commit vendor, không có dấu `AssetRipper:`).
6. Phạm vi (probe `--count`): chuỗi base bị cắt ở **421 type trên Pinata** (251 instance link; 179 type trong Assembly-CSharp, 26 instance của `ComponentAction`1`, 25 `Morpeh.MonoProvider`1`, 19 `ABSTweenPlugin`3`, 11 `UnityEvent`1`, 11 `Obi.ObiConstraints`1`) và **398 type trên Impostor** (356 link; 246 trong UIElementsModule — framework bị stub nên không hiện triệu chứng, 12 Assembly-CSharp, 8 ACTk.Runtime, 19 DOTween). Vì ma trận mặc định toàn 2022.3 và PlayMaker chỉ có ở Pinata, lỗi này sống qua 15 iteration.

Ghi chú 2019.2 khác đã xác minh trong lần rip này:
- `il2cpp_codegen_write_barrier`: log ghi `0x1588A6C: 288 call sites have the shape (next busiest 98), 0 of 5 corlib anchors agree; not decisive`. Luật (`NewArm64KeyFunctionAddresses.GetWriteBarrier`) đòi ≥ 500 site và ≥ 4× runner-up (Merge-Room 4064/459). 288 không phải "mọi lần ghi reference" → Unity 2019.2 mặc định tắt incremental GC, build không có barrier; luật từ chối **đúng**. Không phải việc.
- 2 method MISSING (`YandexAppMetricaReceipt/Config`, 76 byte mỗi cái) đúng như AGENT_STATE 047.
- `KEYWORDS_NOT_RECORDED` 53 shader: 2019.2 không ghi `KeywordNames` (BUILDABILITY_068 §4).

## 3. Phát hiện mới của lần khảo sát này

Mỗi mục ghi mức bằng chứng theo quy ước repo: **PROVEN** (đo được, tái lập), **INFERRED** (suy từ code/tài liệu, chưa đo), **UNKNOWN**.

### 3.1 [PROVEN] Chuỗi base của generic instance bị đứt — lỗi upstream Cpp2IL, ảnh hưởng mọi fixture

Xem §2.4. Tóm tắt: `GenericInstanceTypeAnalysisContext` dựng từ `Il2CppType` (đường `GetOrCreate`, tức mọi
`Derived : Base<T>` đọc từ metadata) không bao giờ gán `DefaultBaseType`; chỉ constructor `(genericType, args)` gán. Hệ quả:
`BaseChainFieldSearch` dừng ngay sau mắt xích generic, mắt xích thường phía sau không bao giờ được hỏi.

Patch v2 (`GenericInstanceTypeAnalysisContext.cs`, 36 dòng diff, phụ lục A): `DefaultBaseType` tính lười, bằng
`GenericInstantiation.Instantiate(GenericType.BaseType, GenericArguments, [])` — tức base của định nghĩa **đã thay đối số** của
instance, nên `Foo<int> : Bar<T>` cho `Bar<int>` chứ không phải `Bar<T>` mở. Bản v1 (không thay đối số) đã sinh cast kiểu mở
`<_00210>` trên Impostor (2 → 4) và bị loại; v2 giữ 2 (= baseline).

Đo cả hai đầu trên **đủ 5 fixture** (RunFromZombies và Merge-Room tải về trong container, SHA256 khớp; baseline của cả 5 khớp 068 từng chữ số), cùng script, body pass bật (`Test/Tools/MemberVisibility` đã build):

| 69s → 69g | Pinata | Impostor | JellyBlastV2 | RunFromZombies | Merge-Room |
|---|---|---|---|---|---|
| EXACT | 12.927 → **13.081** (+154, toàn bộ Assembly-CSharp 4286 → 4440) | 4437 → 4438 | 5247 → 5246 | 2931 → 2931 | 11.876 → 11.876 |
| HIGH_CONFIDENCE | 659 → 676 | 190 → 190 | 221 → 220 | 171 → 171 | 751 → 750 |
| PARTIAL | 2299 → 2128 | 684 → 683 | 1934 → 1935 | 729 → 729 | 3120 → 3121 |
| FALLBACK / MISSING | 259 / 2 → 259 / 2 | 65 / 0 | 38 / 0 | 57 / 0 | 233 / 1 |
| placeholder | 8736 → **8534** (−202) | 3456 → 3455 | 12.709 → 12.710 | 3920 → 3918 | 18.046 → **18.019** (−27) |
| lỗi thân Assembly-CSharp (body pass) | 1074 → **876** (−198): CS0030 810 → 613, cụm `((Fsm)0)` 185 → 0; CS0122/CS1061 không tăng | 156 → 156 | 1693 → **1690** | 7 → 7 | 275 → 275 |
| file `.cs` đổi nội dung | 163 | 2 | 8 | 3 | 19 |
| cast kiểu mở `<_0021N>` | 0 → 0 | 2 → 2 | 0 → 0 | 0 → 0 | 0 → 0 |
| golden corpus / shape check | n/a | y hệt baseline | y hệt | y hệt | y hệt |
| chuyển trạng thái method (`method_status_diff.py`) | **154 PARTIAL→EXACT, 17 PARTIAL→HIGH_CONFIDENCE, 0 chiều ngược** | 0 | 1 EXACT→PARTIAL, 1 HC→PARTIAL (đọc bên dưới) | 0 | 1 HC→PARTIAL (đọc bên dưới) |
| test | 781/782 (ca fail có sẵn) | | | | |

Ba method tụt trên JBV2/Merge-Room đã đọc, **cùng một hình dạng, nhãn EXPECTED_CHANGE**: một delegate generic (`DOGetter<string>`, `ObjectConstructor<object>`, `Action<HashSet<int>,bool>`, `Func<Type,JsonContract>`) trước patch được viết thành delegate **giả** `new DOGetter<string>(closure, (IntPtr)num)` (giá trị sai im lặng, nhưng "có `new`" nên phép đo chấm EXACT); sau patch thành ranh giới trung thực `NoteDecompilerIssue("Delegate over an unresolved function pointer…")` + `null`. Cơ chế: `TypeAnalysisContext.IsDelegate` kiểm `BaseType is { Name: "MulticastDelegate" }`, nên mọi delegate generic trước đây **không được nhận là delegate** (base null) và đi nhầm vào đường dựng object thường. Cùng loại với nhãn EXPECTED_CHANGE của 068 §4 ("tên giả bị gỡ"). Đi kèm là cải thiện thật: closure `<>c__DisplayClass37_0` của `DOTweenModuleUI.DOFillAmount` được gập lại thành biến cục bộ, `JsonPropertyCollection` đọc đúng `((Collection<JsonProperty>)this).items`, `DefaultContractResolver` bỏ cast thừa.

Corpus hành vi tĩnh (`logic_behavior_corpus.py --check`, 293 entry đóng băng, không cần source): RunFromZombies 50 entry, Merge-Room 86, JellyBlastV2 73 — **y hệt** trước/sau; Impostor 84 entry: changed 22 → 24, hai entry mới đều là hai method đã đọc ở trên — `WallHackDetector.OnDestroy` field_reads **thêm** `instancesInScene` (đúng với nguồn `instancesInScene--`), `KeepAliveBehaviour.OnDestroy` mất allocation `UnityAction<Scene,LoadSceneMode>` giả (delegate trên con trỏ chưa phân giải → `null` trung thực). Không có effect nào của nguồn bị mất.

Theo họ placeholder, 69s → 69g (`placeholder_families.py`): UNMANAGED_MEMORY_LOAD Pinata 3879 → 3671, Impostor 1945 → 1943, JBV2 8046 → 8033, RFZ 1555 → 1550, Merge-Room 9166 → 9099; UNRESOLVED_DELEGATE Pinata 122 → 128, Impostor 0 → 1, JBV2 4 → 18, RFZ 0 → 3, Merge-Room 128 → 168 (`LoadedPointerKind.cs:159` và `IndirectJumpClassifier.cs:272` đọc `IsDelegate`). Ghi nhớ cho A1: phần UNRESOLVED_DELEGATE tăng là delegate giả thành ranh giới thật, và là việc tiếp theo của họ đó (Pinata 113/122 là `TweenCallback`, đứng yên từ 050) — không phải regression.

`SetAudioClip.OnEnter` trước: `NoteDecompilerIssue("Unmanaged memory load: [this+30]"); GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);`
— sau: `GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);` (accessor pairing `fsm` → `Fsm` tự bắn, vì `get_Fsm` là một load + return).

Không trùng mục nào đã loại: giả thuyết 3.2 của `GENERIC_BASE_FIELD_ANALYSIS.md` (để mắt xích generic trả lời cho field của tổ tiên)
vẫn bị loại và **vẫn bị loại sau patch** — patch chỉ làm mắt xích *thường* phía sau được hỏi, đúng như luật 041 mô tả nhưng chưa bao giờ
xảy ra. Ghi chú CLAUDE.md:2253 ("`fsm` is resolved correctly to `FsmStateAction.fsm`") là **lỗi thời** — trước patch nó không phân giải.

Patch **chưa commit**: theo quy trình repo, nó là thay đổi đầu tiên của iteration 069 và phải đi kèm test, số đo đủ ma trận và tài liệu (mục A1).

### 3.2 [PROVEN] Mọi `.asmdef` xuất ra có `"references": []`

Pinata: 46/46 asmdef rỗng references; `Unity.TextMeshPro` có 11 file `using UnityEngine.UI`, DLL cùng tên trong `AuxiliaryFiles/GameAssemblies`
có AssemblyRef tới `UnityEngine.UI`. Nguyên nhân (PROVEN bởi skeptic P04): `AssemblyDefinitionExporter.cs:13-25` đọc `module.AssemblyReferences` của module Cpp2IL dựng
**trong bộ nhớ**, mà Cpp2IL không bao giờ điền bảng này (`Source/External/Cpp2IL.Core/Utils/AsmResolver/ContextToTypeSignature.cs:17-21`
bọc thẳng `TypeDefinition` ngoại module; `grep AssemblyReferences|ImportAssembly` trong Cpp2IL.Core = 0); AssemblyRef chỉ xuất hiện khi
AsmResolver ghi PE (`BaseManager.cs:88`), tức sau khi asmdef đã được viết. Roslyn harness không bắt được vì nó tham chiếu *mọi* GameAssemblies. Đây sẽ là lỗi U2 (compile trong Unity) đầu tiên, trước
mọi lỗi thân, và nó che số lỗi decompiler thật. Chưa có báo cáo nào ghi.

### 3.3 [PROVEN] Native plugin Android không có `.meta` PluginImporter

Pinata: 7 `.so` trong `Assets/Plugins/Android/arm64-v8a`, 0 `.so.meta`. `NativePluginPostExporter.CopyAndroidLibraries` chỉ copy;
`WritePluginImporter` chỉ gọi cho `.framework`/`.dylib` iOS (từ 057). Bất đối xứng trong cùng exporter.

### 3.4 [PROVEN] GUI mặc định không decompile 40/42 assembly đã phục hồi

`ExportSettings.ScriptExportMode` mặc định `Hybrid` → `ScriptExporter.cs:91-95` chỉ decompile `Assembly-CSharp*`
(`ReferenceAssemblies.IsPredefinedAssembly`), mọi assembly khác lưu DLL. `SystemTester` — tức **mọi** số liệu của 68 iteration — ép
`Decompiled` (`Program.cs:268`). Người dùng GUI trên Pinata sẽ không thấy thân hàm DOTween/PlayMaker/EasyMobile… dù log báo đã phục hồi.
Không phải lỗi recovery; là lỗi trải nghiệm + tài liệu.

### 3.5 [PROVEN] Những thứ KHÔNG phải việc

- Write barrier Pinata (288/98, bị từ chối): luật `≥500 & ≥4×` (Merge-Room thật đo 4064/459) từ chối đúng vì 288 không phải "mọi lần ghi reference". Giả thuyết giải thích (INFERRED, **không có bằng chứng trong repo**): build 2019.2 không bật incremental GC nên không có barrier. Không phải việc, trừ khi A7 tìm thấy helper đó bằng anchor.
- `StructDb` 742 file = 370 version × 2 width + README + index: tài liệu "370 version" **đúng**.
- Test fail `GetMainExportID_…_DebugAssertFails`: upstream, chỉ Release.

### 3.6 [INFERRED] Khoảng trống còn lại trong Pinata sau patch (từ `CPP2IL_DUMP_LOADS` 69d, Assembly-CSharp 481 load trước patch)

| họ | số | ghi chú |
|---|---:|---|
| between fields of the base type | 197 | phần lớn là 175 `fsm` — **đã sửa**; phần dư cần đếm lại sau patch |
| `Il2CppClass.0x12E` | 60 | đọc struct runtime (bit `valuetype`/`has_cctor` 2019.2) — RUNTIME_STRUCT, không ép thành field |
| value type base | 59 | struct trên stack / phần tử struct — họ B2/B3 |
| past the last field | 24 | |
| base không kiểu (Move/Add/Newobj…) | ~50 | untyped local — họ B4 |

---

## 4. Kế hoạch hoàn thiện — việc theo phase, mỗi mục có bằng chứng, phạm vi, tiêu chí chấp nhận

Quy ước: **S** < 1 ngày, **M** 1–3 ngày, **L** > 3 ngày (một iteration riêng). "Pinata" = tác động trực tiếp lên game của bạn.
Mọi mục chạm lõi phân tích phải đo **cả hai đầu** trên đủ ma trận (Impostor, Merge-Room, RunFromZombies, JellyBlastV2 **và Pinata**).

### Phase A — nền tảng và phép đo (làm trước, vì mọi số sau phụ thuộc)

| id | việc | bằng chứng | phạm vi | ước | tiêu chí chấp nhận |
|---|---|---|---|---|---|
| **A0** | **Layout StructDb đúng cho JellyBlastV2 (2022.3.53f1)**: hiện rơi về 2021.2.9f1 (log: "has no layout for Unity 2022.3.53f1; using 2021.2.9f1", áp 9/10 offset `Il2CppClass`; `actualSize` 252 → 256). Cách rẻ nhất: tạo `2022.3.53f1-x64/x32.json.gz` từ Editor 2022.3.53f1 (clang `-fdump-record-layouts`, docs/articles §"Adding a version"), hoặc chứng minh mọi offset trong `Il2CppClassUsefulOffsets`/`MethodInfo` bằng nhau giữa 53f1 và 62f2 rồi cho catalog chọn "gần nhất cùng minor" | §9.3 #1; `StructDbCatalog.cs:91–131` | `StructDb/`, `StructDbCatalog.cs` | S (nếu có Editor) | log JBV2 không còn dòng fallback; mọi số JBV2 đo lại hai đầu |
| **A1** | **Đưa patch v2 (§3.1) vào iteration 069** kèm: test đơn vị cho `GenericInstanceTypeAnalysisContext.BaseType` (dựng từ Il2CppType ≠ null; `Foo<int>:Bar<T>` → `Bar<int>`; base thường giữ nguyên) và cho `BaseChainFieldSearch` đi qua mắt xích generic tới mắt xích thường; đo đủ ma trận; `Source/External/README.md` mục 32; sửa CLAUDE.md:2253; `issues.json` thêm DECOMP-0079 FIXED | §3.1 | `Source/External/Cpp2IL.Core/Model/Contexts/GenericInstanceTypeAnalysisContext.cs`; `Source/AssetRipper.Tests/Il2CppBaseChainFieldTests.cs`; docs | S | Pinata lỗi thân ≤ 876, placeholder ≤ 8534; Impostor/JBV2/MR/RFZ lỗi thân không tăng; golden 0 regression mới; `<_0021N>` không tăng; test ≥ 781/782 |
| **A2** | **Đưa Pinata trở lại ma trận mặc định** (`RUN-TEST`/`collect_metrics`/`regression-matrix` luôn có cột Pinata). Lý do: fixture duy nhất 2019.2/v24.2, duy nhất có PlayMaker, duy nhất crash ở 068, và chính nó bắt được §3.1 mà 4 fixture 2022.3 không bắt được | AGENT_STATE 090–091; docs/RECOVERY_MATRIX.md "Vì sao Pinata rời"; §3.1 | `docs/RECOVERY_MATRIX.md`, `Test/Scripts/collect_metrics.sh`, `AGENT_STATE.md` | S | mọi iteration từ 069 có hàng Pinata trong `reports/regression-matrix.md` |
| A3 | Phân cụm 876 lỗi thân Pinata còn lại **theo producer** (`cluster_body_errors.py`, `untyped_producers.py`, `CPP2IL_DUMP_LOADS` sau patch) và ghi `reports/PINATA_BODY_ERRORS_069.md` — Pinata chưa bao giờ có báo cáo này | §2.4, §3.6; reader next-targets C13 | `Test/Scripts/*`, `reports/` | S | bảng họ × producer, mỗi họ map tới một mục B |
| A4 | Phép đo: `recovery_metrics.py` nhận mảng ngầm định (`params`, `String.Concat(string[])` → `+`) để 11 PARTIAL→FALLBACK giả trên JBV2 không bị chấm sai; rà golden entry từng khớp nhờ tên call giả (Sirenix `BinaryDataWriter` ×11, `Queue.Enumerator.Dispose`) | ROADMAP 067#11; docs/ITERATION_068.md §4 | `Test/Scripts/recovery_metrics.py`, `Test/golden-corpus*.json` | S | golden regression "EXPECTED_CHANGE" của 068 về 0 mà không đóng băng lại baseline |
| A5 | Đo mức ồn warning của Cpp2IL rồi quyết định bỏ map `WarningLog → Verbose` ở `Logger.cs:16` (hoặc lọc theo pattern) — hiện mọi warning per-method của Cpp2IL (Mach-O mã hoá, helper không định vị) không bao giờ vào log. Đo tĩnh được ngay: đếm call site `Logger.Warn*` trong `Source/External` theo pass | AGENT_STATE (0b) 496–500; §9.3 #8 | `Source/AssetRipper.Import/Logging/Logger.cs` | S | số dòng warning/rip trên 5 fixture; quyết định ghi vào CLAUDE.md |
| **A6** | **Hỏi bạn: có source project Unity của Pinata không?** Lý do duy nhất Pinata "chỉ nói được về số lượng" là thiếu source. Có source → `source_oracle.py`/`source_behavior_oracle.py` (toolchain sẵn, RunFromZombies 35/35) chạy được trên codegen **2019.2** — thứ RunFromZombies (2022.3) không phủ — và mọi mục B có thước ngữ nghĩa thay vì chỉ thước compile | reader pinata P-A2; `docs/RECOVERY_MATRIX.md:26–28` | `Test/Scripts/source_oracle.py`, `artifacts/reference/Pinata` (gitignored) | phụ thuộc bạn | `semantic_equivalence_rate` cho Pinata |
| A8 | Đối chiếu `reports/issues.json` + ROADMAP với log 068 (chỉ đọc, S): đóng DECOMP-0055 (064), 0068 (067), 0071 (068), 0038 phần lõi (062); DECOMP-0045 là artefact phép đo đã biến mất; ROADMAP §10 "type(s) skipped" = 0 trên 5 log; DECOMP-0070 có thể là hệ quả của A0 — để Phase B không nhắm vào thứ đã đóng | reader issues; §9.3 #7, #11 | `reports/issues.json`, `ROADMAP.md` | S | mọi issue OPEN có iterationFound/fix đúng với log 068 |
| A7 | Đo lại ranh giới native/runtime helper trên Pinata (`cluster_runtime_boundaries.py`, `runtime_helper_report.py`) — lần cuối 052, trước luật khoảng địa chỉ managed 053 (Impostor UNKNOWN 416 → 112). METHOD_NOT_FOUND 2232 + UNKNOWN_CALL_TARGET 300 + NATIVE_IMPORT 1689 = 48 % placeholder Pinata; 2019.2 có bộ helper khác 2022.3 | reader pinata P-B4; `regression-matrix.md:683–691` | scripts + `reports/runtime_boundaries_pinata.json` (mới) | S | bảng ranh giới Pinata với UNKNOWN đã phân loại |

### Phase B — recovery, xếp theo tác động lên Pinata

| id | việc | bằng chứng | phạm vi | ước | tiêu chí |
|---|---|---|---|---|---|
| **B1** | **FRAMEWORK_PRIVATE_MEMBER trên struct/class UnityEngine** (Pinata ≈ 208 lỗi: `Rect.m_XMin` 27, `RaycastHit2D.m_Centroid` 19, `RaycastHit.m_Normal/m_Distance` 11, `JointMotor2D/JointSuspension2D` 16, `Selectable.m_Navigation/m_Colors/…` 42, `List<T>._items` 26, `InputField.m_SelectionColor` 4). ROADMAP §8j nói đã pair field↔property cho value type, nhưng trên 2019.2 không bắn. Bước 1: đo theo **call site** (như `reports/FRAMEWORK_PRIVATE_MEMBER.md` đã chứng minh ở 054–056 — đo theo tên member là lặp lỗi cũ) với probe `RecordRejectedGetter`/`AccessorsWithNoCandidate` để biết "không có candidate" hay "thân getter không phải một load + return"; bước 2 sửa đúng nhánh. Lưu ý từ skeptic: field của `List<T>.Enumerator` trong mscorlib **2019.2 không có gạch dưới** (`list/index/version/current`), nên mọi pass/cluster neo theo tên `_x`/`m_x` đều mù trên Pinata — neo theo **offset field của definition** | §2.4; `IlGenerator.cs:835–1000`; reader next-targets C15/C07; skeptic P03 | `Source/External/Cpp2IL.Core/IlGenerator.cs` (AccessorDefinitionFor, ReturnsNothingButTheField) | M | Pinata CS0122 121 → < 30, CS1061 87 → < 30; 4 fixture kia không tăng |
| B2 | **Độ rộng LOAD trong lifter ARM64** (`ldr s0` = 4) để gỡ mơ hồ member đầu ở offset 0 của phần tử struct; cùng họ: `'float' → 'Vector3'` 46, `'float' → 'Vector2'` 13, `RaycastHit → float` 25 trên Pinata; STRUCT_FIRST_MEMBER Pinata 127 | ROADMAP 068#4; `NewArmV8InstructionSet.cs:892,906` (LDR không size) so với `:918` | `NewArmV8InstructionSet.cs:891–892` (truyền `size: AccessWidth()` — hàm **đã có** ở `:697–712`), thêm `LDRSW/LDURSW => 4`, nửa load `LDP/LDPSW` `:939–940`; `MetadataResolver.NarrowerThan`, `NestedFieldResolver` | S–M | STRUCT_FIRST_MEMBER giảm trên cả 5; `float→Vector3` Pinata 46 → < 10 |
| B3 | **Địa chỉ phần tử struct làm base** (`DynamicBone.Particle + int` 8, `Keyframe[] → IntPtr` 9, ARRAY_ELEMENT_ADDRESS Pinata 7, Merge-Room 26) và hình dạng `NAMED_READ_INSIDE` (mảng `Keyframe` của `AnimationCurve` dựng trên stack: Merge-Room 768/1000) — tổng quát hoá `FieldReference.ElementIndex` + `FieldOfALoadedObject` | ROADMAP 068#2; `STRUCT_REJECTION_REASONS_068.md` §44–45; `FIELD_REFERENCE_PROVENANCE_067.md` §6 | `ArrayRecovery.cs`, `FieldAddressArguments.cs`, `StackStructStorage.cs` | L | `(float)array[i]` giữ 0; `= ref *(` giảm; Pinata CS0019 24 → < 8 |
| B4 | **OBJECT_AS_NATIVE_INT sửa ở producer** (`System.Type → IntPtr` 20, `X → IntPtr` ~40, `Enum → int` 18 trên Pinata; JBV2 184) — ENTRY_VALUE / `this + k` không trúng field / MANAGED_CALL_RESULT; và miền phi con trỏ/số nguyên (MERGE, JBV2 429 local). **Cấm** sửa ở cast (DECOMP-0011) | `NATIVE_VALUE_PROVENANCE_068.md` §23–43, §115–121 | `MetadataResolver` (ResolveTypesAndFields, PropagatePhi), `LocalVariables` | M | OBJECT_AS_NATIVE_INT giảm trên 5 fixture; nint_cast không tăng |
| B5 | DECOMP-0006 base ctor: hai chặn còn lại — store immediate 64 bit gói int+float trong ctor (`Expected I4, but got I8`): `PackedFieldsCovered` **đã** xét `Immediate` (`IlGenerator.cs:1468–1487`), chỗ hụt là `PrimitiveFieldWidth` (`:3300–3307`) không biết `System.Single` → width 0 → phép tách hỏng ở field float (`TCP2_PlanarReflection.m_ClipPlaneOffset @0x20`); và hoist khi block base-call là đích nhảy. Pinata 11 CS0117, Impostor 8, JBV2 26 | reader issues DECOMP-0006; `TCP2_PlanarReflection.cs:598–602` | `IlGenerator.HoistBaseConstructorCall`, `PackedFieldsCovered` | S | CS0117 `_002Ector` về 0 trên Pinata/Impostor |
| B6 | Pinata-2019.2: phân loại trước khi sửa — DECOMP-0042 (20/62 call trả struct generic qua buffer mà X8 không có địa chỉ stack; giả thuyết địa chỉ qua X29/bản sao) và DECOMP-0064 (154 lần ghi SP không phải alloca, 138 toán hạng SPDYN). Thêm dump (callee, size, định nghĩa X8 / shape SP) rồi mới quyết | `AR68z-p.log:73,118,122`; `DYNAMIC_STACK_ALLOCATION_066.md:85` | `NewArmV8InstructionSet.cs:553–583`, `StackAnalyzer` | S (dump) + M | bảng phân loại; `MoveNext` mặc định Pinata 112 → gần 5 như 4 fixture kia |
| B7 | Độ rộng store do `DefineHiddenReturnBuffer` tạo (`NewArmV8InstructionSet.cs:582`: `new StackOffset(slot + offset)` không `Size`, trong khi `:683` có; `StructSlotAliasRecovery` chỉ `SetOperand`, không tạo store — skeptic P05) (width 0 → 4/8) để luật padding `StackStructStorage` bắn; `PackedFieldsCovered` ở tầng struct trên stack (STORE_WIDTH_MISMATCH RFZ 131/181) — RFZ (fixture gần compile sạch nhất, 7 lỗi) | ROADMAP 068#1,#3; `STRUCT_REJECTION_REASONS_068.md` §46–65; DECOMP-0072 | `NewArmV8InstructionSet.cs:579–582`, `StackStructStorage.cs` | S+M | RFZ kickoff async `)->Start(ref` 14 → 0; RFZ 7 lỗi → < 7 |
| B8 | DECOMP-0044: `&slot` theo bản sao/phi trong `StructSlotAliasRecovery` (`ThroughCopies` đã có trong file), chỉ khi mọi input là `&slot` cùng một ô — nguồn 2 golden regression Impostor mở từ 062. Tránh hai cách đã loại (luật bản sao trong `PointerClassifier`; đi ngược block thẳng hàng) | `StructSlotAliasRecovery.cs:99–103,191–226`; ROADMAP 062 | `StructSlotAliasRecovery.cs` | S/M | 2 golden Impostor (AnimationMatchModifierAsset, Skin.AddSkin) về EXACT |
| B9 | DECOMP-0070: excise vùng quét interface có verdict `DeadRegionProven` trên dạng iOS (JBV2 309 lỗi thân) — **chỉ** phần đã chứng minh, iteration riêng, baseline riêng | ROADMAP 068#8; `InterfaceScanRegionClassifier.cs` | `InterfaceDispatchRecovery` | L | JBV2 1693 → < 1400; Merge-Room 29 giữ nguyên |
| B10 | Accessor pairing cho `List<T>.Enumerator` inline (`MoveNext`/`Current` đọc `_list/_current/_version`) — gập cả vùng như `InlineListAddRecovery` | ROADMAP 068#7; `MERGE_ROOM_BODY_ERRORS_067.md:39–42` | pass mới cạnh `InlineListAddRecovery` | L | FRAMEWORK_PRIVATE_MEMBER: Impostor 43, MR 38, JBV2 254, Pinata ~30 (sau B1) giảm ≥ 50 % |

### Phase C — tích hợp người dùng và project Unity sinh ra

| id | việc | bằng chứng | phạm vi | ước | tiêu chí |
|---|---|---|---|---|---|
| **C1** | **asmdef `references`** (§3.2): sinh references từ type reference thật của module đã phục hồi (hoặc từ DLL đã ghi trong `GameAssemblies`), lọc theo `ReferenceAssemblies`; thêm check tĩnh vào `validate_unity_project.py` (namespace `using` ↔ asmdef references); test | §3.2 | `AssemblyDefinitionExporter.cs`, `ScriptExportCollection.cs:118–`, `Test/Scripts/validate_unity_project.py` | M | 0 asmdef rỗng references khi assembly có AssemblyRef ngoài engine; U2 trên Windows không còn CS0246 liên assembly |
| **C2** | **`.meta` PluginImporter cho `.so` Android** (platform Android, CPU theo thư mục ABI), dùng `WritePluginImporter` sẵn có | §3.3 | `NativePluginPostExporter.cs:65–89,220–249`; `project_artifact_check.py` | S | Pinata 7/7 `.so.meta`; artifact check báo PRESENT |
| **C3** | **Level 3 ⇒ Script Export Mode = Decompiled**: tự chuyển (hoặc cảnh báo rõ trên Settings/Commands) khi `ScriptContentLevel ≥ Level3` — nếu không người dùng GUI không thấy 40/42 assembly đã phục hồi | §3.4 | `SettingsPage.cs`, `ScriptContentLevelDropDownSetting.cs`, `Localizations/*.json` | S | GUI ở Level 3 cho cùng số `.cs` với SystemTester |
| **C4** | **Trang Log trong web UI**: xem log của phiên hiện tại, nút **copy toàn bộ ra clipboard** (`navigator.clipboard.writeText`, fallback `execCommand('copy')`) và tải file — yêu cầu bạn đã nêu trước; hiện không có route nào trả log (`WebApplicationLauncher.cs:80–101,176–320`) | reader user-facing C-01 | `WebApplicationLauncher.cs`, `Pages/Log*.cs` (mới), `StaticContent/js/site.js`, `DefaultPage.cs`, Localizations | M | mở `/Log`, bấm Copy → clipboard chứa đúng nội dung file log; hoạt động trên Chrome/Edge/Firefox |
| C5 | Bảng tóm tắt recovery trên UI sau khi load: kiến trúc, struct DB exact/fallback, `N attempted / M failed`, assembly bị abandon, cảnh báo ARMv7/x86 — các dòng quyết định hiện chỉ ở log | `Il2CppRecoveryDiagnosticsProcessingLayer.cs:116–129`; `StructDbCatalog.cs:122–130` | `Pages/Commands.cs`/`CommandsPage.cs` | M | người dùng thấy "42 assemblies, 18483 methods, 0 failed" ngay sau load |
| C6 | Localization: 23 khoá en_US chưa có bản dịch vi (vi.json 270/293); hai trang Package hard-code tiếng Anh; chuỗi Settings IL2Cpp chưa qua Localization | reader user-facing C-04; `LocalizationGenerator.cs:67–72` | `Localizations/*.json`, `Pages/PackageRemapping/*` | S | 0 khoá thiếu trong vi.json; test khoá tồn tại |
| C7 | Tài liệu: `docs/articles/Il2CppScriptRecovery.md` lỗi thời (ARMv7 "not possible" trong khi lifter đã vendored; "three changes" so với 31 mục; nhãn setting); AGENT_STATE ghi Pinata "x86" (thực tế arm64-v8a); CLAUDE.md:2253; thêm hướng dẫn tiếng Việt cho Windows (`docs/articles/vi/`) | §3.5; reader C-03/C-09 | docs | S | — |
| C8 | Thông báo trên Commands/Settings: load ở Level 3 tự động rip vào `DefaultExportPath` (xoá sạch thư mục, không hỏi) hoặc `%TEMP%`; không đổi hành vi (đã quyết ở `d1ea6e72`/`71ba1125`), chỉ nói trước | `Commands.cs:55–60,96–125`; `GameFileLoader.cs:66–75` | GUI | S | — |
| C9 | `applicationIdentifier`/bundle id vào `ProjectSettings.asset` từ `AndroidManifest.xml` (Pinata có) / `Info.plist`, kèm provenance; package/lib giữ BLOCKED | DECOMP-0057; `BUILDABILITY_068.md:29–31` | post-exporter nhỏ | S | ProjectSettings không còn `applicationIdentifier {}` |
| C10 | Android P/Invoke: tên thư viện từ chuỗi `PInvokeArguments` trong code sinh ra (metadata không giữ) — Pinata có 7 `.so` plugin | ROADMAP 063#8; `grep PInvokeArguments Source → 0` | `AsmResolverAssemblyPopulator.CopyMethodsInType` | M | `[DllImport("easymobile")]` thay `static extern` trần |
| C11 | Chứng minh version package cho Impostor/Pinata bằng `package_manifest_reconstruction.py` (bước 1 còn thiếu) để `--package-cache` áp được ngoài JBV2; **không** ghi version không có bằng chứng | `PACKAGE_MANIFEST_067.md:10–25,58–62` | `Test/Scripts/package_manifest_reconstruction.py` | M | manifest Pinata có TMP/UGUI UPSTREAM_EXACT hoặc ghi rõ BLOCKED vì sao |

### Phase D — cổng Unity (E–G) — chỉ mở được trên máy có Unity

| id | việc | bằng chứng | phạm vi | ước | tiêu chí |
|---|---|---|---|---|---|
| **D1** | **Checklist chạy cổng Unity trên Windows** (§7 dưới) và ghi kết quả vào `reports/BLOCKED_UNITY_TESTS.md` mục 069 — U1–U8 từ BLOCKED thành kết quả thật, không bao giờ PASS khi chưa chạy | reader unity-gate D-01/D-07 | `docs/UNITY_GATE_WINDOWS_CHECKLIST.md` (mới), `iterations/069/reports/unity/*` | S (viết) + chạy trên máy bạn | log U1/U2 thật cho Pinata và Impostor được commit |
| D2 | Nối stage E–I của `validate_unity_stages.py` (chỉ `which Unity`, `:51–53`; `buildability_matrix.py:38` **đã** đọc `UNITY_PATH`) với kết quả Unity thật (JSON của `UnityBuildValidator`, log `run_all.sh`), nhận `UNITY`/`UNITY_PATH` và đường Hub Windows; `UnityBuildValidator --method import` (U1+U2 không cần Android module); `Harness.cs` in tên component null và đối chiếu allowlist | `validate_unity_stages.py:51–53,289–325`; `buildability_matrix.py:36–49`; `ValidationScript.cs:19–49`; `install_editor_harness.sh:58–104` | scripts + `AssetRipper.Tools.UnityBuildValidator` | M | ma trận có cột E–G với giá trị thật |

### Phase E — bảo trì

| id | việc | bằng chứng | ước |
|---|---|---|---|
| E1 | Vòng test trung thực ở Release: chạy unit test ở Debug (`dotnet test` không `-c Release`) tách khỏi build rip Release, hoặc lọc test Debug-only — để "1 fail có sẵn" không phải tự đoán ở mọi iteration. **Không** rip bằng Debug (Debug.Assert fail → `Environment.FailFast` im lặng) | `ExportIdHandlerTests.cs:24–32`; `ExportIdHandler.cs:63`; CLAUDE.md "A Debug build dies silently" | S |
| E2 | CI cho nhánh fork: workflow build + unit test + rip Impostor (fixture đã commit, 97 MB) + `golden_corpus.py`/`recovery_metrics.py` so baseline — hiện **không workflow nào chạy trên `claude/*`** (`test.yml` chỉ `master`), 327 commit chưa qua máy nào ngoài container | `.github/workflows/test.yml`; `Test/Scripts/rip.sh` | M |
| E3 | `download_test_inputs.sh` phủ đủ 5 fixture (hiện chỉ Impostor + JellyBlast v1 mã hoá): URL + SHA256 cho RunFromZombies (`thinhabc01/RunFromZombiesFullProject` v1 `demo.apk`), Merge-Room (`thinhabc01/Merge-Room` v1 `merge-room.apk`), JellyBlastV2 — **đã kiểm trong phiên này: hai URL theo mẫu release tải được và SHA khớp**; ghi provenance của Pinata (chưa có ở đâu) | `download_test_inputs.sh:24–30`; `RECOVERY_MATRIX.md:7–13` | S |
| E4 | Build không phụ thuộc máy: `global.json` pin SDK 10.0 (`rollForward: latestFeature`); ghi rõ trong README rằng `nuget.samboy.dev` là nguồn duy nhất của ~22 gói `AssetRipper.*`/`Disarm`; `dependabot.yml` upstream bump `AsmResolver.*`/`AssetRipper.CIL` ở `Source/` trong khi `Source/External/Cpp2IL.Core.csproj` pin riêng → đúng bẫy NU1605 CLAUDE.md:45–48 — ignore hoặc thêm `Source/External` vào dependabot | §2.1; `.github/dependabot.yml`; `Cpp2IL.Core.csproj:30–31` | S |
| E5 | Playbook cập nhật Cpp2IL: sha đầy đủ + ngày của `cae273a` (2026-08-19), xuất patch series của `Source/External` so với upstream (hoặc nhánh `vendor/cpp2il-cae273a` giữ bản gốc) để `git diff`/`git apply --3way` thay cho diff tay 94 file / 516 marker; checklist 31+ mục | `Source/External/README.md:251–254` | M |
| E6 | Sửa mâu thuẫn tài liệu: Pinata "x86" (AGENT_STATE:143,798; RECOVERY_MATRIX:21) → ARM64; AGENT_STATE "Giai đoạn hiện tại" (:166–169) vẫn trỏ baseline `Out54*`; "Pinata rời ma trận" (:142–145) vs thực tế rip mọi iteration 062–068; CLAUDE.md:33 "RUN-TEST.bat rips Pinata" (mặc định là Impostor) và :41 "số ở ROADMAP" (ROADMAP tự khai số cũ); "base commit" `5d5405ba` là commit của agent, merge-base thật với upstream AssetRipper là `cc53aff9` (2026-07-30; upstream master đã đi 53 commit / 105 file); nhãn tag 068 (p/z/j/i/m/o) khác quy ước i/z/j/m; `iterations/039` không tồn tại | reader health F6, pinata F13 | S |
| E7 | Dung lượng repo: 546 MB nội dung tracked (iterations 199 MB, Test/Input 272 MB — Impostor và JellyBlastV2 **đang tracked dù .gitignore nói ignore**, Pinata 86 MB); hai log Roslyn thô 54 MB (`iterations/045`, `040`), `reports/method-contracts` 34 MB. Quyết định chính sách: nén/ignore log > 1 MB, và hoặc `git rm --cached` Impostor/JBV2 + sửa comment .gitignore, hoặc tuyên bố cả ba tracked (pack 165 MB không nhỏ lại nếu không rewrite history) | `.gitignore:46–54`; `git ls-files` | S |
| E8 | `requirements.txt` (pyyaml) và guard `import yaml` trong `serialized_reference_graph.py`; các script khác là stdlib | `serialized_reference_graph.py:64` | S |
| E9 | Hằng ghi cứng `InitialisedFlagOffset64 = 0x135` trong `MetadataInitGuardRemover.cs:23` (2019.2 là 0x12E) → đọc từ struct DB như CLAUDE.md đã quy định ("cùng một lỗi ba lần"); guard hiện nhận theo hình dạng nên giá trị thấp, nhưng rẻ | `MetadataInitGuardRemover.cs:23,33`; ROADMAP:726–728 | S |
| E11 | Script sinh layout StructDb từ một Editor đã cài (bọc clang `-fdump-record-layouts` → JSON schema 1, cả hai width) — hiện chỉ có mô tả tay; 368/370 version đến từ `dvxil2c`, 2 từ clang; và cân nhắc luật fallback ưu tiên "cùng major.minor" | §9.3 #5; `StructDb/README.md:30`; `docs/articles/Il2CppScriptRecovery.md:164–168` | S–M |
| E10 | Cache giải nén blob theo (shader, platform) trong `ShaderProgramPostExporter.WriteVariantPrograms` (O(biến thể × blob)) | ROADMAP 059#5 | S |

## 5. Thứ tự thực hiện đề xuất

**Iteration 069 — "Pinata trở lại, chuỗi base, project mở được"** (toàn bộ là S, đã có bằng chứng PROVEN):
A1 → A2 → C1 → C2 → C3 → A3 → E1/E2. Kết thúc bằng rip 5 fixture, `regression-matrix` mục 069, và **bạn chạy D1 trên Windows** (U1/U2) cho Pinata + Impostor để lần đầu có số Unity thật.

**Iteration 070 — "Compile Pinata"**: B1 (M) → B5 (S) → B2 (M) → C4 + C5 (GUI, M). Mục tiêu: Pinata lỗi thân 876 → < 500; Impostor 156 → < 120; RFZ 7 → 0 (B7).

**Iteration 071 — "Đóng họ struct/địa chỉ"**: B3 (L) hoặc B4 (M) tuỳ A3 nói họ nào lớn hơn sau 070; B6; D2.

**Iteration 072+**: B9 (iOS), B10, C10/C11, E3.

Nguyên tắc giữ nguyên từ repo: không đóng băng lại golden baseline để che regression; không gán kiểu cho stand-in; không xoá vùng quét
interface chưa chứng minh; không ghi version package không có bằng chứng; không bao giờ ghi PASS cho stage Unity chưa chạy.

## 6. Đã thử và loại — KHÔNG đề xuất lại (gộp từ AGENT_STATE, CLAUDE.md, ROADMAP, issues.json, các ITERATION_06x)

| việc | vì sao loại | nguồn |
|---|---|---|
| Gán kiểu cho giá trị stand-in mà điểm bỏ cuộc đẩy vào (DECOMP-0011) | tệ hơn mọi cột: REAL_ERROR 1766→2007, Roslyn 456→548 | CLAUDE.md:2316–2327; AGENT_STATE:421 |
| Để mắt xích generic trả lời cho field của tổ tiên (giả thuyết 3.2) | 186 lỗi mới trên Pinata, cast `<>` 5→45 | GENERIC_BASE_FIELD_ANALYSIS.md §3.2, §8 |
| Cộng header 0x10 cho value type / "cách đọc nào trúng thì lấy" | bị loại 036/037/038, bác bỏ bằng đo 042/045 (1761 VALUE_RELATIVE chống 0) | AGENT_STATE:247–259, 574–577 |
| Chạy lại field resolution muộn (sau CopyCoalescer / cuối Analyze) | tiền đề sai: base đã có kiểu khi fixpoint chạy; 11903 method gọi, đổi 2 | CLAUDE.md:2238–2248 |
| Giữ store qua SP sau ô bị lấy địa chỉ như qua X29 (66g/66h) | JBV2 EXACT 4347→4149; CS0122 MR 27→57 | docs/ITERATION_066.md:75–85 |
| Luật "bản sao vào local khác kiểu là dùng lại thanh ghi" trong PointerClassifier | bị chính chuỗi định nghĩa bác bỏ | docs/ITERATION_060.md:75–78 |
| Đi ngược block thẳng hàng trong InlineListAddRecovery | không bao giờ bước được một bước (guard là điểm hợp lưu) | docs/ITERATION_060.md:80–83 |
| `TypeAttributes.NotPublic` cho type inject để dập CS0433 | ILSpy viết attribute fully-qualified → `recovery_metrics` đọc NO_BODIES; thay bằng `--no-cpp2il-injected-attributes` (067) | CLAUDE.md:2220–2229 |
| Ba guard quanh lookup `0xF7087C` | đo âm, EXACT MR 11973→11882; 068 đã tìm nguyên nhân gốc (thanh ghi bị call trước làm hỏng) | MERGE_ROOM_BODY_ERRORS_067.md:73–83 |
| Luật thanh ghi cũ đặt trong InvokerArgumentRecovery | chạy sau SSA destruction nên báo sai; đã revert | docs/ITERATION_068.md:142–143 |
| Hạ carry unsigned về so sánh có dấu | chỉ đúng tình cờ; 068 sửa đúng bằng `ImmediateAtWidth` | AGENT_STATE:31–32 |
| Xoá vùng quét interface chưa có dispatch chứng minh | 340/592 vùng "thoát" là dispatch chưa giải, không phải mã chết | AGENT_STATE:92–93 |
| Nới ngưỡng write barrier 76/75 | một site chênh lệch, không anchor nào đồng ý | AGENT_STATE:101–102 |
| Đóng băng lại golden baseline để regression biến mất | luật repo | AGENT_STATE:75–78 |
| DCE chỉ đánh dấu định nghĩa cuối (030) | xoá code sống (CS0165 5→12) | AGENT_STATE:567–570 |
| Nhận diện cặp so sánh qua chùm cờ A64 (DECOMP-0019) | toàn bộ nằm trong code chết sau DCE | CLAUDE.md:2259–2271 |
| Gập địa chỉ phần tử tính được VÀO phần tử | sinh `(float)array[i]`; thay bằng gập vào member (039) | CLAUDE.md:2273–2282 |
| Viết `packages-lock.json` tay / ghi version package chưa UPSTREAM_EXACT | chỉ resolver của editor thật mới nói được lock chứa gì | PACKAGE_MANIFEST_067.md |
| Bịa GUID cho `m_Script` gãy | component sai im lặng | RUNNABLE_PROJECT_RECOVERY.md §4 |
| Kiểm shader bằng "material có hồng không" | Dummy/Replacement không hồng mà shading sai | AGENT_STATE 044 §2 |
| Mô phỏng/báo PASS stage Unity khi không có editor | script từ chối chạy (exit 90) | BLOCKED_UNITY_TESTS.md |
| Đưa `CPP2IL_RECOVER_ALSO` lên GUI | chế độ ĐO; từng làm UI Image mất sprite | AGENT_STATE:66–67 |
| Sửa thẳng `Logger.cs:16` mà không đo mức ồn | AGENT_STATE 0b | AGENT_STATE:496–500 |

## 7. Checklist chạy cổng Unity trên Windows (cho D1)

1. **Editor**: Unity Hub cài **2019.2.6f1** (Pinata) và **2022.3.62f2** (Impostor), module *Android Build Support* (+ OpenJDK/SDK/NDK nếu định chạy U7). Script `_common.sh` chỉ *in* version mong đợi, không kiểm — mở sai version sẽ migrate project và làm sai mọi số.
2. **Bản rip**: không được commit (`Test/Out*` gitignored). Rip trên Windows: `dotnet build AssetRipper.slnx -c Release` rồi
   `dotnet Source\0Bins\AssetRipper.Tools.SystemTester\Release\AssetRipper.Tools.SystemTester.dll --script-level 3 --reconstruct-bodies --struct-db StructDb --output Test\Out69-p --log Test\AR69-p.log Test\Input\Pinata` (và `Test\Input\Impostor`).
3. **Kiểm tĩnh trước**: `python3 Test/Scripts/validate_unity_project.py <rip>/Pinata --json iterations/069/reports/unity/pinata-static.json` — mong đợi FAIL ở `m_Script` gãy đã biết (Impostor 6, Pinata 2; UNRESOLVED có lý do, **không** bịa GUID).
4. **Shell**: `Test/Scripts/unity/*.sh` là bash → Git Bash hoặc WSL; biến môi trường **`UNITY`** = đường dẫn `Unity.exe` (không phải `UNITY_PATH`); `LOG`/`OUT` tuỳ chọn. Thiếu `UNITY` → exit 90 (cố ý).
5. **Thứ tự**: `import_project.sh` (U1: sinh `Library/`) → `compile_scripts.sh` (U2: đếm `error CS\d+`; **sẽ FAIL** vì Pinata 876/Impostor 156 lỗi thân + C1 asmdef; `run_all.sh` dừng ở đây) → sau C1/B1 chạy lại → `refresh_assets.sh` (U3) → `validate_scenes.sh`/`validate_prefabs.sh` (U4/U5; so với allowlist `audit_script_references.json`) → `build_player.sh` (U7) → `smoke_test.sh`.
   Đường C# thay thế: `dotnet Source\0Bins\AssetRipper.Tools.UnityBuildValidator\Release\AssetRipper.Tools.UnityBuildValidator.dll build <project> --target Android --editor <Unity.exe>` (xuất JSON có `stages`).
6. **Đã biết sẽ hỏng khi mở** (không phải regression): manifest 31 module/0 package, `packages-lock.json` vắng (BLOCKED cố ý), package stub dưới `Assets/Scripts`, `ProjectSettings` trống `applicationIdentifier`/SDK/scriptingBackend (C9), `#error VARIANT_SELECTION_UNKNOWN` trong shader (Unity có coi là lỗi hay không: cần log U1 thật), kiểu tiêm `Cpp2ILInjected` trùng giữa assembly (dùng `--no-cpp2il-injected-attributes` nếu CS0433), asmdef rỗng references (C1), `.so` không `.meta` (C2).
7. **Ghi nhận**: log từng stage + JSON vào `iterations/069/reports/unity/`, cập nhật `reports/BLOCKED_UNITY_TESTS.md`. BLOCKED → PASS/FAIL **chỉ** khi script đã chạy thật.

## 8. Chưa biết / chưa đo (gaps trung thực)

- Patch v2 đã đo đủ 5 fixture trong container (§3.1), nhưng chưa có unit test và chưa đo hành vi (`behaviour oracle`/`source_oracle` trên RunFromZombies, Merge-Room) — A1 phải chạy `Test/Scripts/source_oracle.py` và `method_behavior_contract.py` trước khi commit, vì 068 đã thấy một thay đổi semantic IR làm behaviour oracle tụt dù EXACT tăng.
- Nguyên nhân chính xác `references: []` (INFERRED: AssemblyRef chưa serialize) — xác nhận khi làm C1.
- Unity có coi `#error VARIANT_SELECTION_UNKNOWN` là lỗi import không; `.so` không `.meta` trên 2019.2 có tự cấu hình theo thư mục ABI không — cần log U1 thật.
- Mức ồn warning Cpp2IL (A5) chưa đo.
- Thời gian rip/bộ nhớ chưa có cột trong ma trận (chỉ số đo tay ở §2.2); peak RSS chưa đo.
- Pinata placeholder 8442 → 8736 ở 068 chưa có nhãn EXPECTED/MEASUREMENT/REAL trong `docs/ITERATION_068.md` §4 (chỉ giải thích 4 fixture kia).
- Không có bản PowerShell/cmd cho `Test/Scripts/unity/*.sh`.

## 9. Đối chiếu với khảo sát độc lập (Workflow 6 reader → gộp → skeptic → critic)

Để kế hoạch không chỉ là ý kiến của một phiên, một workflow 6 reader độc lập (issues, mục tiêu tiếp theo, mặt người dùng, cổng Unity,
Pinata, sức khoẻ repo) đã đọc repo với cùng ràng buộc "mọi claim phải có file:dòng", rồi một bước gộp xếp hạng, mỗi ứng viên top-10 bị
một skeptic cố bác bỏ (hai lăng kính: *đã thử và loại / mâu thuẫn với cảnh báo đã ghi* và *bằng chứng có thật*; mặc định bác bỏ nếu
không chắc), cuối cùng một critic hỏi "còn thiếu gì". Reader thu 75 ứng viên thô và **98 mục "đã thử và loại"** (nguồn của §6).

### 9.1 Xếp hạng sau gộp ↔ mục trong §4

| hạng | ứng viên gộp | ↔ §4 | ghi chú |
|---|---|---|---|
| P01 | Hạ cánh patch v2 `DefaultBaseType` + test + đo 5 fixture + phân cụm lại Pinata | **A1 + A3** | gộp C13/P-B3/DECOMP-0004; bước gộp ghi "bằng chứng mới hơn mọi iteration" |
| P02 | Độ rộng truy cập phía LOAD (`ldr s0` = 4…) — STRUCT_FIRST_MEMBER | **B2** | phụ thuộc P01 |
| P03 | FRAMEWORK_PRIVATE_MEMBER Pinata 208: đo vì sao §8j không bắn trên 2019.2, rồi gập vùng `List<T>.Enumerator` | **B1 + B10** | |
| P04 | asmdef `references: []` | **C1** | |
| P05 | Độ rộng store của `DefineHiddenReturnBuffer`/`StructSlotAliasRecovery` + `&slot` qua bản sao | **B7 + B8** | |
| P06 | Cổng Unity trên Windows: checklist + nối JSON/log + `--method import` + Harness allowlist | **D1 + D2** | phụ thuộc P04, P07 |
| P07 | Project Android Pinata: `.meta` PluginImporter cho `.so` + `applicationIdentifier` | **C2 + C9** | |
| P08 | Pinata trở lại ma trận: golden corpus, hàng RECOVERY_MATRIX, ranh giới native, 5 URL+SHA, chính sách fixture, nhãn x86, hỏi source | **A2 + A6 + A7 + E3 + E6 + E7** | |
| P09 | Dump và phân loại hai hình dạng chỉ 2019.2: buffer generic không địa chỉ (DECOMP-0042), 154 lần ghi SP (DECOMP-0064) | **B6** | phụ thuộc P08 |
| P10 | DECOMP-0006 base ctor: packed-immediate store + hoist khi block là đích nhảy | **B5** | bước gộp phát hiện lý do chặn cũ ("behind DECOMP-0004") không còn đúng: sau patch vẫn đúng 11 CS0117 |
| P11 | Mặt người dùng GUI: Hybrid→Decompiled, bảng kết quả, trang Log/copy, Localization, docs, auto-export | **C3 + C4 + C5 + C6 + C7 + C8 + A5** | |
| P12 | Phép đo nói thật: tên call giả, `params`/`Concat`, `0x17FDF50`, CS0433 dưới `--no-cpp2il-injected-attributes`, đếm lại họ 060, vòng test Debug, CI nhánh fork | **A4 + E1 + E2** | |

Ngoài top-12 nhưng không bị loại (giữ trong §4 với ưu tiên thấp hơn): write barrier bằng chứng thứ ba (ghi chú §3.5), DECOMP-0061 (Merge-Room, không ảnh hưởng Pinata),
OBJECT_AS_NATIVE_INT ở producer (B4), miền phi (B4), `FieldReference` lồng (B3), `Keyframe[]`/`PackedFieldsCovered` tầng stack (B3, bước sau P05),
P/Invoke Android (C10), DECOMP-0038 keyword 2019.2, DECOMP-0039, cache blob shader (E10), Metal→HLSL (iOS, dự án riêng), SHARED_GENERIC_ALLOCA (nhóm A DECOMP-0022, **đừng** gán kiểu).

### 9.2 Kết quả skeptic (mỗi ứng viên top-10 một skeptic, mặc định bác bỏ nếu không chắc)

Kết quả: **10/10 ứng viên sống sót** (không ứng viên nào trùng mục đã loại, không bằng chứng cốt lõi nào sai). Mỗi skeptic chạy 13–29 lệnh grep/đọc; các hiệu chỉnh chi tiết đã được áp vào §3–§4 và liệt kê ở đây:

| ứng viên | verdict | hiệu chỉnh của skeptic (đã áp vào kế hoạch) |
|---|---|---|
| P01 patch v2 | giữ | `git log -S DefaultBaseType` chỉ ra commit vendor — file chưa từng bị vá; cảnh báo "ĐỪNG" gần nhất (AGENT_STATE:262–264, nhánh open-generic 041) là cơ chế khác. Test với v2 đã có (781/782). CLAUDE.md:2249–2256 ("`fsm` resolved correctly") phải sửa khi hạ cánh |
| P02 độ rộng load | giữ | `AccessWidth()` **đã tồn tại** (`NewArmV8InstructionSet.cs:697–712`, có LDRB/LDRH/S/W/D/X); việc cần làm là truyền `size: AccessWidth()` ở `:892` (và nhánh literal `:891`), thêm case `LDRSW/LDURSW => 4` (hiện rơi vào X → 8), và nửa load của `LDP/LDPSW` (`:939–940`) chưa có size dù `STP` đã có |
| P03 FRAMEWORK_PRIVATE_MEMBER | giữ | 208 là CS0122+CS1061 thô; cluster regex (`cluster_body_errors.py:49–50`) chỉ bắt `m_*`/`_*`, nên `List<T>.Enumerator.list/index/version/current` của **mscorlib 2019.2 không có gạch dưới** (khác `_list/_current` trên 2022.3) rơi vào OTHER → ≈194 (ROADMAP ghi 190). Hệ quả thiết kế: pass Enumerator phải neo vào **offset field của definition**, không vào tên |
| P04 asmdef | giữ | cơ chế **không còn INFERRED**: Cpp2IL không bao giờ điền `module.AssemblyReferences` trong bộ nhớ (`Utils/AsmResolver/ContextToTypeSignature.cs:17–21` bọc trực tiếp `TypeDefinition` ngoại module; `grep AssemblyReferences\|ImportAssembly` trong Cpp2IL.Core = 0); AssemblyRef chỉ sinh khi AsmResolver ghi PE (`BaseManager.cs:88`). Sửa: lấy references từ tập TypeRef/scope thực sự dùng, hoặc đọc bảng AssemblyRef của DLL đã ghi trong `GameAssemblies` |
| P05 độ rộng store | giữ | `StructSlotAliasRecovery` **không tạo store** (chỉ `SetOperand` ở `:138/:170/:207`); store `Move stack[slot+k], [X8+k]` do `DefineHiddenReturnBuffer` tạo tại `NewArmV8InstructionSet.cs:582` (`new StackOffset(slot + offset)` không `Size`, trong khi đường `:683` có). Một chỗ sửa |
| P06 cổng Unity | giữ | `buildability_matrix.py:38` **đã** đọc `UNITY_PATH`; chỉ `validate_unity_stages.py:51–53` là `which Unity` và `:289` in "not implemented in this harness" |
| P07 project Android | giữ | `NativePluginPostExporter.cs:82` là `ArchitectureOf(file) ?? "arm64-v8a"`; `WritePluginImporter` ở `:220–264`; `lib/arm64-v8a` có 10 `.so`, `NativeLibraryClassifier` bỏ 3 engine → 7 đúng |
| P08 Pinata vào ma trận | giữ | placeholder sau patch là 8534 (không phải 8522); `docs/ITERATION_068.md:69` **có** nhắc Pinata (exit 134) — thiếu là nhãn cho +294 placeholder ở dòng 65 |
| P09 dump 2019.2 | giữ | con số "21 load không kiểu" không có nguồn — bỏ; DECOMP-0064 phát hiện qua CS0030 (+3 ExtensionList), không chỉ lỗi im lặng |
| P10 base ctor | giữ | `PackedFieldsCovered` **đã** xét nguồn `Immediate` (`IlGenerator.cs:1468–1487`); chỗ hụt thật là `PrimitiveFieldWidth` (`:3300–3307`) chỉ biết kiểu nguyên — `System.Single` → 0, nên field float `m_ClipPlaneOffset @0x20` của `TCP2_PlanarReflection` làm phép tách lỗi; `EmitIntegerFieldStore` (`:1416–1430`) chỉ phát `Ldc_I8` khi width == 8 |

### 9.3 Critic — còn thiếu gì

Critic (một agent, đọc survivors + mục bị loại + gaps của reader) nêu 14 khoảng trống; những mục quan trọng đã được **tự kiểm lại** và đưa vào kế hoạch:

| # | khoảng trống | đã kiểm | đưa vào |
|---|---|---|---|
| 1 | **JellyBlastV2 (2022.3.53f1) đang phân tích bằng layout StructDb của 2021.2.9f1**: StructDb chỉ có một bản 2022.x (`2022.3.62f2`), luật fallback "mới nhất ≤ version" rơi về 2021.2.9f1 | **PROVEN**: `Test/AR69s-j.log`: "has no layout for Unity 2022.3.53f1; using 2021.2.9f1 … applied 9 measured Il2CppClass" (Impostor 2022.3.62f2 áp 10); `Il2CppClass.actualSize` 252 → 256 giữa hai bản, 68 field khác tên/offset (hai bản do hai generator khác nhau tạo) | **A0** (mới, trước A1): mọi số JBV2 (STRUCT_FIRST_MEMBER 55, FRAMEWORK_PRIVATE_MEMBER 254, INTERFACE_SCAN_SURVIVOR 309) phải đo lại sau khi có layout đúng |
| 2 | Thời gian chạy / bộ nhớ không đo từ 034 (`run-result.txt` không còn; không cột nào trong ma trận) | đúng; trong phiên này đo tay: Impostor 54 s, RFZ 69 s, JBV2 88 s, Pinata 110 s, Merge-Room 108 s (4 core) | A2 thêm cột `run seconds` + peak RSS vào `collect_metrics.sh`/`rip.sh` |
| 3 | ARMv7 chưa từng đo trong ma trận; `AndroidGameStructure.cs:171–178` ưu tiên arm64-v8a, SystemTester không có tuỳ chọn ABI; docs nói "not possible" | đúng | §10 (hoãn, có lý do) + C7 sửa docs |
| 4 | x86/PE và WebGL: không fixture, không hàng ma trận; "fixture x86" duy nhất (Pinata) thực ra là AArch64 | đúng | §10 |
| 5 | Bảo trì StructDb thủ công (clang `-fdump-record-layouts`, không script); 368/370 version từ `dvxil2c`, 2 từ clang — nguyên nhân trực tiếp của #1 | đúng | A0 + E11 |
| 6 | ROADMAP §7 crash (Smash Fest) không có issue/fixture; CI chỉ master và không `-c Release` | đúng | §10; E1/E2 |
| 7 | ROADMAP §10/§11 có thể lỗi thời: "type(s) skipped" = 0 trong cả 5 log 068 | đúng theo log | A8 (đối chiếu issues.json + ROADMAP với log) |
| 8 | `Logger.cs:16` nuốt WarningLog của Cpp2IL; đo mức ồn **không cần chạy**: đếm tĩnh call site `Logger.Warn*` trong `Source/External` theo pass | đúng | A5 (cập nhật cách đo) |
| 9 | Bằng chứng của P01/P03/P10 nằm ở artefact ngoài repo (scratchpad, `Test/Out69*`) — session sau không kiểm được | đúng → **đã sửa trong commit này**: `iterations/069/logs/AR69{s,g}-*.log.gz`, `iterations/069/metrics/*` (recovery_metrics, placeholder_families, compile, golden, bodyerr), `iterations/069/patch-lazy-basetype-v2.diff` | — |
| 10 | Claim "2019.2 tắt incremental GC nên không có write barrier" không có bằng chứng trong repo; `reports/FRAMEWORK_PRIVATE_MEMBER.md` (chưa trích) đã chứng minh phép đo accessor pairing phải theo **call site** | đúng → §3.5 hạ xuống INFERRED; B1 bước 1 đo theo call site | §3.5, B1 |
| 11 | `issues.json` lệch trạng thái thật: DECOMP-0071 OPEN dù 068 PROVEN đã sửa; 0055/0068/0038 đã sửa mà chưa đóng; DECOMP-0070 (iOS) có thể là hệ quả của #1 | theo reader issues (bằng chứng file:dòng) | A8 |
| 12 | Nguồn chưa trích: `BUG_FAMILY_PRIORITY.md`, `TYPE_RECOVERY_ANALYSIS.md`, `UNTYPED_LOCAL_IMPACT.md`, `FRAMEWORK_PRIVATE_MEMBER.md`, `REGISTER_WIDTH_068.md`, `docs/FULL_RECOVERY_ARCHITECTURE.md` | — | đọc trước B1/B4 |
| 13 | Cập nhật Cpp2IL upstream: 562 dòng marker `AssetRipper:` qua 146 commit (không phải 94 — 94 là số file), không script kiểm marker | đúng | E5 |
| 14 | ROADMAP 068 #5 (miền phi, JBV2) và #6 (`0x17FDF50`, Merge-Room) không có trong survivors và không bị bác | đúng | B4 ghi rõ "hoãn: phụ thuộc A0 / fixture" |

Nhận xét về hình dạng kế hoạch (critic) đã áp: A0 và cột chi phí đi **trước** A1 để JBV2 không phải đo lại hai đầu hai lần; P09 (dump 2019.2) và P05 độc lập với A1 nên làm song song; mọi thay đổi `Source/External` kèm kiểm artefact (`ls -la` DLL + `strings -el`) và chạy đủ 5 fixture; bước 1 của B1 đo theo call site như `FRAMEWORK_PRIVATE_MEMBER.md`.

## 10. Hoãn có lý do — đã xét, không làm trong 069–071

| việc | lý do hoãn | điều kiện mở lại |
|---|---|---|
| ARMv7 (armeabi-v7a) | lifter đã vendored (`ArmV7InstructionSet`) nhưng chưa từng đo trong ma trận; `AndroidGameStructure.cs:171–178` luôn ưu tiên arm64-v8a và SystemTester không có tuỳ chọn ABI; game của bạn là arm64 | có yêu cầu game 32-bit; thêm cờ `--abi` rồi đo Impostor armeabi-v7a (có sẵn trong Test/Input) |
| x86/x86-64 (PE, Windows), WebGL | không fixture nào; PE import table chưa đọc (ROADMAP §2); WebGL không lifter. Docs nói x86 "recovered" nhưng chưa có fixture x86 nào trong ma trận — sửa câu đó ở C7 | có fixture |
| Crash ROADMAP §7 (Smash Fest / cannonball) | không fixture, không issue, không tái lập từ 0xx | có APK |
| Cập nhật Cpp2IL upstream | 562 dòng marker `AssetRipper:` / 146 commit; không có script kiểm marker; cần E5 trước | sau E5 |
| ROADMAP 068 #5 (miền phi con trỏ/số nguyên, JBV2 429 local) và #6 (`0x17FDF50`, Merge-Room) | phụ thuộc A0 (số JBV2 đổi theo layout) và Merge-Room | sau A0, trong 071 |
| Metal → HLSL (iOS) | dự án riêng, không ảnh hưởng Android/Pinata | — |

## Phụ lục A — patch v2 (chưa commit; áp bằng `git apply`)

```diff
diff --git a/Source/External/Cpp2IL.Core/Model/Contexts/GenericInstanceTypeAnalysisContext.cs b/Source/External/Cpp2IL.Core/Model/Contexts/GenericInstanceTypeAnalysisContext.cs
index 2a91a545..ba953d2c 100644
--- a/Source/External/Cpp2IL.Core/Model/Contexts/GenericInstanceTypeAnalysisContext.cs
+++ b/Source/External/Cpp2IL.Core/Model/Contexts/GenericInstanceTypeAnalysisContext.cs
@@ -34,7 +34,22 @@ public class GenericInstanceTypeAnalysisContext : ReferencedTypeAnalysisContext
         set => GenericType.OverrideNamespace = value;
     }
 
-    public sealed override TypeAnalysisContext? DefaultBaseType { get; }
+    // AssetRipper (experiment 069, v2): the Il2CppType constructor never set this, so every generic
+    // instance resolved from metadata - every `Derived : Base<T>` link - had a null base and the
+    // base-chain field search stopped there. The definition's base is instantiated on this
+    // instance's arguments, so `Foo<int> : Bar<T>` gives `Bar<int>` rather than the open `Bar<T>`,
+    // which would otherwise reach the output as a cast to a type C# cannot spell.
+    private TypeAnalysisContext? _defaultBaseType;
+    public sealed override TypeAnalysisContext? DefaultBaseType => _defaultBaseType ??= InstantiateBaseType();
+
+    private TypeAnalysisContext? InstantiateBaseType()
+    {
+        var open = GenericType.BaseType;
+        if (open is null)
+            return null;
+
+        return Utils.GenericInstantiation.Instantiate(open, GenericArguments, []);
+    }
 
     public sealed override Il2CppTypeEnum Type => Il2CppTypeEnum.IL2CPP_TYPE_GENERICINST;
 
@@ -69,7 +84,6 @@ public class GenericInstanceTypeAnalysisContext : ReferencedTypeAnalysisContext
     {
         GenericType = genericType;
         GenericArguments.AddRange(genericArguments);
-        DefaultBaseType = genericType.BaseType;
 
         SetDeclaringType();
     }
```

## Phụ lục B — lệnh đo đã dùng (tái lập trong container trống)

```
curl -sSL https://dot.net/v1/dotnet-install.sh | bash -s -- --channel 10.0 --install-dir ~/.dotnet
dotnet build AssetRipper.slnx -c Release
dotnet test  AssetRipper.slnx -c Release --no-build
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb --output Test/Out69s-p --log Test/AR69s-p.log Test/Input/Pinata
python3 Test/Scripts/recovery_metrics.py Test/Out69s-p --log Test/AR69s-p.log
python3 Test/Scripts/placeholder_families.py Test/Out69s-p --log Test/AR69s-p.log
bash    Test/Scripts/compile_recovered_scripts.sh Test/Out69s-p Assembly-CSharp
bash    Test/Scripts/check_recovered_shapes.sh Test/Out69s-p
python3 Test/Scripts/golden_corpus.py Test/Out69s-i/Impostor --log Test/AR69s-i.log --corpus Test/golden-corpus.json --check Test/golden-corpus-baseline.json
CPP2IL_DUMP_LOADS=loads.tsv CPP2IL_DUMP_METHOD='SetAudioClip::OnEnter' CPP2IL_DUMP_DIR=isil <lệnh rip>   # provenance + ISIL từng stage
```

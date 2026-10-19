# Iteration 069 — project mở được trong Unity: asmdef references, package chuẩn, Hybrid, abstract struct, cổng MiniUnity

Năm hướng từ `reports/MINIUNITY_EVALUATION_069.md` §4, mỗi hướng là một bước tay đã làm trên `Test/Out69s-z` để
MiniUnity compile được project phục hồi. Giờ cả năm nằm trong tool và harness. Số đo nằm trong `iterations/069/`
(`metrics/*-69n-*`, `logs/AR69{n,h,r}-*.log.gz`, `miniunity/stages-69h-z.json`, `miniunity/gate-69r-z.json`).

## 1. Kết quả

| | trước (69s / 69k) | sau |
|---|---|---|
| asmdef có `references` (z / i / p / j / m) | 0 cạnh ở mọi fixture | 19 / 7 / 62 / 9 / 76 cạnh, **0 tên treo** |
| `abstract struct` trong `__Generated` | 2 file mỗi fixture 2022 | 0 |
| `__Generated` RunFromZombies, compile với assembly Editor thật | — | 12/12 file sạch |
| Lỗi Assembly-CSharp (stub, body pass) z / i / p / j / m | 7 / 156 / 1074 / 1663 / 275 | **2 / 156 / 1026 / 1652 / 270** |
| CS0030 Pinata | 810 | 762 |
| Semantic status, placeholder, golden corpus (5 fixture) | | **giống từng chữ số** |
| RunFromZombies Hybrid + Editor 2022.3.62f2: stage C | 73 script reference "broken" | 5378/5378 resolve |
| D2 compile như Unity (MiniUnity) | Assembly-CSharp bị bỏ qua (3022 lỗi) | **PASS, 0 lỗi, 3/3 assembly** |
| F2 scene play | — | PASS_WITH_GAPS: 2 scene, 0 runtime exception, 18 gap của MiniUnity (`TextGenerator`) |
| I2 hành vi = source | — | **PASS: 5 giá trị theo dõi, 0 khác** |

Chỉ CS0030 giảm; không có mã lỗi mới ở fixture nào (`compile-69n-*` so với `compile-69s-*`/`69k-*`).

## 2. asmdef `references` (C1)

Nguyên nhân (kế hoạch 069 §10 ghi INFERRED, giờ đã xác nhận): module AsmResolver mà Cpp2IL giữ trong bộ nhớ có
`AssemblyReferences` **rỗng**; bảng AssemblyRef chỉ xuất hiện khi PE được ghi ra
(`AssemblyManager.GetStreamForAssembly`). `AssemblyDefinitionExporter` đọc bảng của module trong bộ nhớ nên mọi asmdef
ra `references: []`, và trong Unity một asmdef thiếu reference là CS0246 cho mọi type của assembly kia — sau đó mọi
assembly phụ thuộc bị bỏ qua, kể cả Assembly-CSharp.

`AssemblyReferenceNames.Read(Stream)` đọc bảng từ PE đã ghi (PEReader, giữ vị trí stream). `AssemblyDefinitionExporter.Select`
lọc: bỏ chính nó, bỏ reference assembly (engine, BCL), bỏ trùng, và chỉ giữ tên **là asmdef trong project** — một
plugin DLL được Unity tham chiếu ngầm, còn `Assembly-CSharp*` không tham chiếu được. Test:
`AssemblyDefinitionReferenceTests` (5).

## 3. `abstract struct`

il2cpp sinh `__Il2CppFullySharedGenericType` và `__Il2CppFullySharedGenericStructType` là `abstract sealed` trên
`System.ValueType`. C# không có abstract struct (CS0106), `__Generated` hỏng và kéo mọi assembly tham chiếu nó.

Bản đầu xoá `Abstract` khi `Il2CppTypeDefinition.IsValueType` — và chỉ sửa được **một** trong hai: type thứ nhất không
phải value type theo cờ của il2cpp. Thứ khiến decompiler viết `struct` là base type, nên luật giờ nằm ở
`AsmResolverAssemblyPopulator.ConfigureHierarchy`, sau khi base được đặt (`IsValueTypeOver`, ngoại lệ duy nhất là
`System.Enum`, abstract class trên `ValueType`). Test: `Il2CppAbstractValueTypeTests` (7).

Stub vẫn báo một CS8701 trong `__Generated` (default interface implementation): mscorlib đã strip không có
`RuntimeFeature.DefaultImplementationsOfInterfaces`. Với `UNITY_EDITOR_DATA` nó biến mất — lỗi của bộ reference, không
phải của bản phục hồi.

## 4. `vector = (Vector3)num` (CS0030)

Năm lỗi còn lại của RunFromZombies theo luật Unity là `Vector3.MoveTowards` bị inline: thành phần x được tính vào
thanh ghi mà cả vector từng ở, nên một bản sao float vào local kiểu `Vector3` thành phép cast. Luật số học đã ghi vào
member đầu (CLAUDE.md, "A register that carries one member of an aggregate…"); `IlGenerator` `OpCode.Move` giờ làm
điều tương tự cho một bản sao. Kết quả: `vector.x = x;`. RunFromZombies 7 → 2 lỗi (2 còn lại là `Math.PI`,
`Quaternion.Euler(Vector3)` bị strip khỏi stub), Pinata −48, JellyBlastV2 −11, Merge-Room −5.

## 5. Package chuẩn thành package

`SystemTester --unity-editor <Editor>` thêm `Editor/Data/Resources/PackageManager/BuiltInPackages` làm nguồn remap;
`--package-cache` lặp lại được, và `ExportSettings.OfficialPackageCachePath` nhận nhiều đường dẫn ngăn bởi
`Path.PathSeparator`. com.unity.ugui chỉ có trong Editor, không có trên registry, nên đây là nguồn duy nhất cho
UnityEngine.UI.

Hai lỗi lộ ra ngay lần chạy đầu, cả hai sẽ làm hỏng project một cách im lặng:

- **BuiltInPackages là catalog, không phải danh sách game dùng.** Asset ghép theo tên giữa các package, nên shader
  `Hidden/PostProcessing/*` và texture blue noise của PostProcessing v2 khớp với bản cùng tên của HDRP: run xoá 78
  file của game và thêm HDRP, URP, Shader Graph vào manifest của một game Built-in RP. Từ một catalog
  (`PackageSourceResolver.IsEditorCatalog`, `ResolvedPackage.RequiresCodeEvidence`), một package chỉ được áp khi ít
  nhất một type hoặc assembly của nó ghép được; còn lại `NoCodeEvidence` và không đụng gì. Cache của chính project
  (`Library/PackageCache`) vẫn áp như cũ, vì nó đã là danh sách project resolve.
- **`AddedToManifest` đọc danh sách script của cả run**, nên mọi package xét sau một package đã ghép type đều vào
  manifest: com.unity.ui, ui.builder, VFX Graph, nuget.mono-cecil. Giờ là của riêng package đó.

Kết quả RunFromZombies: ugui 80 type ghép, 2 file xoá, chỉ `com.unity.ugui` vào manifest. Test: `PackageRemapCatalogTests` (4).

**GUID của package không có `.meta` nào trong project** (package nằm trong manifest), nên kiểm reference đọc 73 script
reference của UI là broken. `PackageRemapPostExporter` ghi `AuxiliaryFiles/PackageGuids.json` (guid → package), và
`audit_project_references.py` coi một guid ở đó là RESOLVED khi package của nó có trong `Packages/manifest.json`,
BROKEN khi không.

## 6. Hybrid cho thư viện bên thứ ba

`SystemTester --script-mode Hybrid`: decompile `Assembly-CSharp*`, ghi mọi assembly khác thành plugin DLL **mang thân
đã phục hồi**. Meta plugin mặc định (`Any: enabled 1`) dùng được trong Editor — MiniUnity đồng ý — nên không cần đổi.

Lý do đây là đường đúng hiện nay, đo trên `Test/Out69r-z` (Decompiled, có cả C1 và §3): MiniUnity báo **2854 lỗi, toàn bộ
trong Newtonsoft.Json** (CS0104 `ErrorEventArgs` mơ hồ, CS0508 nullable của override…), và theo luật Unity một
assembly hỏng chặn 10 assembly phụ thuộc, kể cả Assembly-CSharp. Thân đã phục hồi của Newtonsoft là IL hợp lệ; chỉ
nguồn C# của nó không compile. Mặc định của SystemTester vẫn là Decompiled để mọi phép đo trong ma trận giữ nghĩa.

## 7. Cổng MiniUnity trong harness

`Test/Scripts/miniunity_gate.py <game dir> [--source <project>] [--scenario …] --unity-editor <Editor>`:

- **D2** compile như Unity: asmdef, define, reference của Editor; một assembly lỗi làm các assembly phụ thuộc
  `skipped_because_a_dependency_failed` — đúng thứ harness Roslyn từng assembly không thấy.
- **F2** play từng scene (`--seconds`, `--size`, `--input`), tách `RUNTIME_EXCEPTION` khỏi `MINIUNITY_GAP`
  (`NotImplementedException` của một member Unity mà MiniUnity chưa làm). Gap không phải lỗi phục hồi, nhưng được báo.
- **I2** hành vi = source: chơi project source *cùng kịch bản* và so các giá trị `--watch`. Kịch bản
  (`Test/miniunity-scenarios.json`) chỉ nói chơi gì và nhìn gì, **không bao giờ ghi giá trị mong đợi** — source là
  giá trị mong đợi. Một giá trị không quan sát được ở cả hai phía là `unobserved`, không phải bằng nhau.
- Chạy trên bản sao (bỏ `Library/Temp/Logs`), không ghi vào rip. Không tìm thấy MiniUnity → `BLOCKED`, không bao giờ PASS.
- `--self-test`: 21 kiểm tra; mỗi luật bỏ đi làm ít nhất một kiểm tra đỏ (đã thử).

`validate_unity_stages.py --miniunity <dir> --source <project>` thêm ba dòng D2/F2/I2 bên cạnh E–I (vẫn
`UNITY_NOT_AVAILABLE`: MiniUnity không phải Unity, và ba dòng mang tiền tố `MiniUnity:` để không bị đọc nhầm).

Ảnh chụp không phải phép so: GameScene của source thiếu model vì MiniUnity chưa đọc FBX khi thiếu `Library/` (MINIUNITY_EVALUATION_069 §3–§4),
trong khi bản phục hồi có mesh đã xuất (`iterations/069/miniunity/rfz-hybrid-Game_4s.png`). Giá trị theo dõi mới là
phép so.

## 8. Còn lại

- Decompiled-mode của thư viện bên thứ ba không compile theo luật Unity (Newtonsoft 2854). Đây là việc của khôi phục
  thân, không phải của project.
- Một catalog chỉ áp package có bằng chứng code. Package chỉ có asset (không type nào) từ catalog sẽ không bao giờ được
  áp; với nguồn là cache của project thì có.
- `packages-lock.json` vẫn BLOCKED (067).
- I2 mới có kịch bản cho RunFromZombies; bốn fixture kia chỉ có kích thước màn hình và thời gian.

## 9. Tái lập

```
E=<Editor 2022.3.62f2>/Editor
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb --script-mode Hybrid --unity-editor $E \
  --output Test/Out69h-z --log Test/AR69h-z.log Test/Input/RunFromZombies
python3 Test/Scripts/validate_unity_stages.py Test/Out69h-z/RunFromZombies --log Test/AR69h-z.log \
  --miniunity <MiniUnity> --source <RunFromZombiesFullProject> --unity-editor $E
```

MiniUnity cần các bản vá ở `iterations/069/miniunity/api-fixes.diff`.

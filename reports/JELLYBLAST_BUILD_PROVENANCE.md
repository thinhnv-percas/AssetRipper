# JellyBlast build provenance — iteration 063

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**. Source: `ThinhNV-x-Percas/jelly-blast`
`develop` @ `462789cf` (pin: `Test/fixtures/jellyblast-source-revision.txt`). Build:
`Test/Input/JellyBlastV2` (IPA `io.heseri.blast` 1.1 (0), UnityFramework sha256 `8fe519ca…`). Bản rip
dùng làm phía build: `Test/Out62m-i` (metadata stub trong `AuxiliaryFiles/GameAssemblies`).

## 1. Câu hỏi brief đặt ra có chiều ngược lại — PROVEN

Brief giả định IPA được build từ `develop` và yêu cầu kiểm chứng điều đó. Lịch sử của repo source nói
điều ngược lại: **source được suy ra từ IPA này**, không phải IPA được build từ source.

- Commit gốc `fe27775f` ("add demo code", 2026-09-16, 1890 file) mang Assembly-CSharp dạng stub
  Cpp2IL: `[global::Cpp2ILInjected.Token(Token = "0x200007A")]`,
  `[global::Cpp2ILInjected.FieldOffset(Offset = "0x10")]`, `NativeSource` gọi
  `Unity.Collections.NativeHashMap\`2<...>::get_Item`.
- 64 trong 90 commit sau đó là dọn dẹp code decompile ("Clean up decompiled Burst jobs…", "Audit
  previously cleaned scripts and remove decompiler scaffolding", "Fix Fish: …").
- `ProjectVersion.txt` ghi 2022.3.62f2 ngay từ `fe27775f`; IPA là **2022.3.53f1** (header UnityFS của
  `data.unity3d`). Bản rip của pipeline này ghi đúng 53f1.

Hệ quả cho toàn iteration: với Assembly-CSharp, scene, prefab và shader, source **không phải oracle độc
lập** — nó là một bản phục hồi khác của cùng binary, đã được người (và LLM) sửa tay. So sánh với nó đo
độ đồng thuận giữa hai bản phục hồi, và mọi khác biệt phải được quy cho một trong ba nguồn: pipeline này,
pipeline đã tạo `fe27775f`, hoặc một chỉnh sửa tay sau đó. Gọi nó là "exact oracle" là sai (§3).

## 2. Phép đo — so khai báo, theo hướng build ⊆ source

IL2CPP bỏ những gì không ai gọi, nên một member source có mà build không có không chứng minh gì. Hướng
phân biệt được là ngược lại: mọi type, method và field build khai báo phải có trong source với cùng chữ
ký. `Test/Scripts/jellyblast_build_provenance.sh` tái tạo toàn bộ:

1. `AssemblyFingerprint` đọc metadata (System.Reflection.Metadata) của stub build và của
   `Library/ScriptAssemblies` trong checkout: một hàng mỗi type/method/field với arity, kiểu tham số đã
   giải mã và visibility.
2. Checkout không có `Assembly-CSharp.dll` đã compile, và compile nó thẳng với engine stub của build thất
   bại ở 42 chỗ trong *thân* method (`Texture2D.GetPixels`, `Graphics.Blit` — member IL2CPP đã strip).
   `SourceDeclarationSurface` (Roslyn) viết lại mỗi thân thành `throw null`, bỏ initializer không phải
   const nhưng giữ `.cctor` khi có static initializer, và giữ nguyên trivia để `#region`/`#if` không lệch.
   Tập file là đúng tập Unity giao cho Assembly-CSharp (ngoài asmdef, ngoài `Editor/`, `Plugins/`), với
   preprocessor symbol của player iOS 2022.3 từ `source_preprocessor.py` cộng define của project.
3. `build_provenance.py`: loại type do chính pipeline inject (`AssetRipperInjected.`, `Cpp2ILInjected.`),
   đếm riêng member do compiler sinh (`<`) và type đăng ký job của Burst, ghép assembly build với assembly
   source chứa ≥50% type của nó.

## 3. Kết quả theo assembly — MEASURED

`iterations/063/provenance/jellyblast-provenance.{txt,json}`. 56 assembly build (loại injected):

| Assembly build | Source | Member khớp | Type thiếu | Kết luận | Nguyên nhân |
|---|---|---:|---:|---|---|
| Unity.Mathematics | Unity.Mathematics | 177/177 | 0 | **PROVEN_BUILD_MATCH** | — |
| Unity.TextMeshPro | Unity.TextMeshPro | 3047/3047 | 0 | **PROVEN_BUILD_MATCH** | — |
| Unity.VisualScripting.Core | idem | 1205/1205 | 0 | **PROVEN_BUILD_MATCH** | — |
| UnityEngine.UI | UnityEngine.UI | 2573/2573 | 0 | **PROVEN_BUILD_MATCH** | — |
| Voodoo.UI.Particles | idem | 160/160 | 0 | **PROVEN_BUILD_MATCH** | — |
| PathCreator | PathCreator | 235/239 | 0 | LIKELY_MATCH | phiên bản PathCreator khác (`showAllPointsInspector`, hai overload `MathUtility.Constrain*`) |
| RayFireAssembly | RayFireAssembly | 2922/2956 | 1 | SOURCE_MISMATCH | phiên bản RayFire khác: `DemolishMesh(RayfireRigid)`, `UpdateOriginalClusterOLD`, `FragLastMode` |
| Unity.Burst | Unity.Burst | 417/425 | 2 | SOURCE_MISMATCH | build có `BurstCompiler/BurstCompilerHelper`; manifest ghim 1.8.21 |
| Unity.Collections | Unity.Collections | 405/1014 | 61 | SOURCE_MISMATCH | build có `NativeParallelHashMap`, `UnsafeHashMap`, `HashMapHelper` — dòng ≥ 2.x; manifest ghim 1.2.4 |
| Assembly-CSharp-firstpass | Demigiant.DOTween | 204/269 | 5 | SOURCE_MISMATCH | xem §4 |
| Assembly-CSharp | Assembly-CSharp | 1745/1975 | 19 | SOURCE_MISMATCH | xem §4 |
| 45 khác | — | — | — | NO_SOURCE | engine module, BCL, Facebook/GameAnalytics SDK, Newtonsoft, DOTween bản chính thức, `__Generated` |

**PROVEN** ở đây là ở mức khai báo: tên, arity, kiểu tham số và kiểu field. Hai source cùng bề mặt khác
thân không phân biệt được bằng phép đo này. Nhưng năm package này **không** đi qua decompile (không một
file nào mang `Cpp2ILInjected`/`NativeSource`, và RayFire/PathCreator/UIOverlayParticles được thêm nguyên
ở `fe27775f` rồi không bao giờ sửa), nên chúng là oracle độc lập thật — là phần duy nhất của repo source
có tư cách đó.

## 4. Assembly-CSharp: 230 member và 19 type thiếu, tất cả quy được nguyên nhân — PROVEN

| Nhóm | Số | Bằng chứng |
|---|---:|---|
| Sample Facebook SDK (`FBWindows*` ×15, `AdsPage`, `PurchasePage`, `ProductRowPrefab`, `PurchaseRowPrefab`), và 4 method sample của `MainPage` | 19 type, 194 member của chúng, + 4 method `MainPage` | xoá ở `fcbf1ec0` "update 1" (2026-09-19) |
| Field kiểu `NativeParallelHashMap`/`NativeParallelMultiHashMap` (`FluidSolver`, 10 job) | 25 | source viết `NativeHashMap` để compile với Collections 1.2.4. Đã như vậy từ `fe27775f`, và local trong chính file đó vẫn tên `nativeParallelHashMap` — tên ILSpy đặt theo kiểu nó thấy — nên kiểu đã bị đổi bằng tay trước commit đầu (**INFERRED**) |
| `Loader.GameAnalyticsATTListener*` ×4, `Loader.InitAnalytics` | 5 | xoá ở `fcbf1ec0` |
| `Fish.OnMenuReached`, `GameManager.OnGameStateChanged` (field của field-like event) | 2 | source viết lại thành event có accessor tường minh với field `m_…`; build (và bản rip này) là field-like event |

Không có khai báo nào của build thiếu trong source mà không có một commit hay một đổi version giải thích.

Theo chiều kia, một phát hiện đáng giá hơn con số: **`SDFTextureGenerator` của source không phải của
build**. Build đặt nó trong `Assembly-CSharp-firstpass` (Plugins) với `ComputeShader _cs`, `_jfaTexture`,
các kernel JFA; source đặt một `SDFTextureGenerator` khác trong Assembly-CSharp dùng
`Texture2D.GetPixels` — member engine mà build không hề giữ, nên không code nào của build gọi nó. Tương
tự `ClosedPathCollider`, `DebugSDF`, `EarClipTriangulator`, `RoundedPathMeshCreator` có trong build và
không có trong source. Một method oracle so thân `SDFTextureGenerator` với source sẽ so hai chương trình
khác nhau.

## 5. Package và version — MEASURED, không sửa

| | Build (IPA) | Source |
|---|---|---|
| Unity | 2022.3.53f1 | 2022.3.62f2 |
| com.unity.collections | ≥ 2.x (**INFERRED** từ `UnsafeHashMap`/`HashMapHelper`) | 1.2.4 |
| com.unity.burst | có `BurstCompilerHelper`, version **UNKNOWN** | 1.8.21 |
| DOTween | bản chính thức, assembly `DOTween` + module trong firstpass | fork `thinhnv-percas/DoTween.git`, assembly `Demigiant.DOTween` |
| Spine, UniTask, Addressables, Purchasing, 2D, Notifications | không có trong build | có trong manifest |

§19: "Không tự thay version để làm compile pass." Không version nào được đổi. Việc chính source đã hạ
Collections để compile là một ví dụ của đúng điều cấm đó, ở phía source.

## 6. Kết luận theo §3

| Phạm vi | Kết luận |
|---|---|
| Unity.Mathematics, TextMeshPro, VisualScripting.Core, UGUI, Voodoo.UI.Particles | **PROVEN_BUILD_MATCH** — oracle độc lập |
| PathCreator | **LIKELY_MATCH** — oracle độc lập, trừ 4 khai báo |
| RayFire, Burst, Collections | **SOURCE_MISMATCH** — version khác; không dùng làm oracle cho thân method |
| Assembly-CSharp, firstpass | **SOURCE_MISMATCH / DERIVED** — suy ra từ chính IPA; mọi so sánh ghi nhãn `DERIVED` |
| Project (toàn bộ) | **SOURCE_MISMATCH**: source không build ra IPA này, và IPA không build từ `develop` |

## 7. Giới hạn

- So khai báo không so thân. Một method cùng chữ ký khác logic là "match" ở đây.
- `Library/ScriptAssemblies` là bản compile của editor tại `88cb0ae0`, không phải tại pin. Package không
  đổi giữa hai commit đó (`Packages/manifest.json` sửa lần cuối ở `606d4b1c`), nhưng asmdef trong
  `Assets/` được đọc từ cây làm việc tại pin.
- Ba chỗ source dùng member engine mà stub build không khai báo (`CreateAssetMenu(fileName=…)`, `order`,
  `Mathf.PI` trong một const) được viết lại trước khi compile; không cái nào là khai báo.

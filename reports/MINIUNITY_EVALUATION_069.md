# MiniUnity: thử nghiệm và hướng update (iteration 069)

Ngày 2026-10-16. Repo `ThinhNV-DEV/miniUnity` @ `a880097`, clone đọc (không push được). Bằng chứng ở
`iterations/069/miniunity/`.

MiniUnity là một "Unity giả" headless trên .NET 8: đọc/ghi YAML của project lossless, compile C# theo luật của Unity
(asmdef, define, reference assembly của Editor), chạy player loop (physics 3D/2D, Animator, audio, coroutine),
EditMode/PlayMode test, và render phần mềm ra ảnh. Không cần license, không cần chạy Unity: chỉ đọc DLL và package
của Editor.

**Kết luận chính: MiniUnity là thứ AssetRipper thiếu cho các cổng E–G.** Trước nay AssetRipper ghi
`UNITY_NOT_AVAILABLE` cho các cổng đó trên mọi fixture. Với MiniUnity, một project AssetRipper phục hồi đã được
compile theo luật Unity, Play, và so hành vi frame-by-frame với project source gốc, tất cả trong container này.

## 1. Cài đặt: chạy được, nhưng không độc lập

`setup.sh` thành công (stub 3676 type, 18+51 file decompile, engine build) sau khi vượt qua ba trở ngại. Cả ba đều là
lỗi của repo, không phải của môi trường:

| Trở ngại | Nguyên nhân | Đề xuất |
|---|---|---|
| `./setup.sh: Permission denied` | Mọi file `*.sh` được commit với mode `100644` (19/19) | `git update-index --chmod=+x *.sh scripts/*.sh` |
| `setup.sh` đọc `../ProjectSettings/ProjectVersion.txt` và `../Packages/packages-lock.json` | Repo là thư mục con được tách từ repo video; project mặc định là thư mục cha, nên clone độc lập không có gì để đọc | Cho phép `UNITY_VERSION` / phiên bản package qua tham số; mặc định khi không có project: 2022.3 LTS mới nhất |
| Lock file phải có `com.unity.cinemachine`, `com.unity.timeline`, `com.unity.textmeshpro` **và** `com.annulusgames.lit-motion` (hash git) | Engine compile chung các package này | Bỏ LitMotion/Cinemachine khỏi engine lõi (đưa sang host), hoặc pin phiên bản mặc định trong `config/` |

Tôi dựng một project host tối thiểu (`ProjectVersion` 2022.3.62f2, lock: timeline 1.7.7, TMP 3.0.9, cinemachine 2.10.3,
LitMotion v2.0.2). Editor dùng lại phần Linux Editor 2022.3.62f2 đã stream cho StructDb (`Managed`,
`MonoBleedingEdge/4.7.1-api`, `NetStandard`, `BuiltInPackages`, `UnityReferenceAssemblies`).

## 2. Bộ test của chính MiniUnity

- `tests/ua_selftest.py` và `tests/roundtrip.py`: **không chạy được ngoài repo video**. Chúng copy
  `../Assets/VideoRecreate/...` và `git ls-files` của repo cha.
- `tests/run_fixtures.py` (194 fixture runtime): cần `../ProjectSettings` và `../Library/PackageCache` (test-framework
  1.1.33, ext.nunit 1.0.6, timeline 1.7.1). Đã cung cấp đủ.
  - Lần 1, ProjectSettings mượn của RunFromZombies: **188 đạt, 4 lỗi, 2 bỏ qua**. Ba lỗi (`MsaaTests`,
    `RenderApiTests.PropertyBlockStoresValuesByKind`, `RenderShaderTests.ColorSpaceComesFromPlayerSettings`) là do fixture
    đọc color space và quality của **project cha**: RunFromZombies là Gamma, MSAA 4.
  - Lần 2, đặt Linear và MSAA 2: **191 đạt, 1 lỗi, 2 bỏ qua**. Lỗi còn lại cần sample RoboHero của
    `com.unity.2d.pixel-perfect`; hai ca bỏ qua cần `unity_builtin_extra`. Không có lỗi engine.

  → Fixture không kín: kết quả phụ thuộc settings của project bao quanh. Nên tự mang `ProjectSettings` riêng.

## 3. Trên một project Unity thật (RunFromZombies, source, Unity 2022.3.62f2)

| Phép thử | Kết quả |
|---|---|
| Đọc–ghi lại YAML (`mu rt`) | **239/239 file** `.unity/.prefab/.asset/.mat/.anim/.controller` trùng từng byte |
| `pkg.resolve --fetch` | 52 package, 17 tải về, 14 s |
| `compile` | **56 assembly, 0 lỗi**, 35 s |
| `play MenuScene` | Chạy, nhưng ảnh chỉ có skybox: UI dùng uGUI `Text` cũ, mà `TextGenerator` còn là stub |
| `play GameScene` | Physics/audio chạy, nhưng người chơi **không di chuyển**: `Movement.Update` ném ở dòng đầu (`Screen.currentResolution`) mỗi frame; 39 model FBX không đọc được khi thiếu `Library/` của Unity, nên thiếu nhân vật và zombie |

`ua apigap --play` xếp hạng đúng những gì chặn game này:

| API | Số lần gặp |
|---|---|
| `GraphicsSettings.currentRenderPipeline` | 900 |
| `TypeCache.GetTypesDerivedFrom` (PostProcessing chạy nhánh `UNITY_EDITOR`) | 302 |
| `Screen.currentResolution` | 300 |
| `SortingGroup.invalidSortingGroupID` | 154 |
| `DrivenRectTransformTracker.Clear` | 151 |
| `TextGenerator.*` | 6 + 6 |
| `TextMesh.text` | — |
| `SceneManager.LoadScene` / `LoadSceneAsync` | stub, nên không chuyển được Menu → Game |

## 4. Trên project AssetRipper phục hồi từ APK (Test/Out69s-z)

| Bước | Lỗi | Nguyên nhân / ghi chú |
|---|---:|---|
| `compile` nguyên trạng | **3022** | Assembly-CSharp **bị bỏ qua hẳn** (`skippedBecause: Unity.Services.Core.Device`) |
| Điền `references` của 10/15 asmdef từ bảng AssemblyRef trong DLL | 2 | Lỗi CS0246 dây chuyền biến mất; còn `internal abstract struct __Il2CppFullySharedGenericType` (CS0106, AssetRipper xuất type `abstract sealed` của metadata thành `abstract struct`) |
| Bỏ `abstract` | 2854 | Toàn bộ trong Newtonsoft.Json phục hồi. Nó chặn 10 assembly phụ thuộc và **chặn cả Assembly-CSharp**, vì Assembly-CSharp tự tham chiếu mọi asmdef |
| Hybrid: thư viện dùng DLL đã phục hồi làm plugin, giữ source cho Assembly-CSharp / UI / PostProcessing | 5 | Đúng 5 CS0030 `float → Vector3` mà harness của AssetRipper đo; đó là `Vector3.MoveTowards` bị inline, `vector = (Vector3)numN` thay vì `vector.x = numN` |
| Vá 5 dòng | **0** | Project phục hồi compile theo luật Unity |

`play GameScene` trên bản phục hồi:

- Ảnh **đầy đủ hơn bản source**: AssetRipper xuất mesh dạng `.asset`, MiniUnity đọc được; source dùng FBX, MiniUnity thì
  không. Spawner sinh các hàng chướng ngại vật.
- Nhưng `EventSystem.current` là `null` nên click gây `NullReferenceException`. Lý do: AssetRipper xuất `UnityEngine.UI`
  thành **asmdef source trong Assets**, trùng với package `com.unity.ugui`. Component trong scene thuộc bản này, còn
  static mà Assembly-CSharp đọc thuộc bản kia. Unity thật cũng sẽ báo trùng tên assembly.
- Bỏ thư mục `UnityEngine.UI` phục hồi, thêm `com.unity.ugui` vào manifest, và đổi GUID `m_Script` theo tên class
  (76/79 khớp; ba cái không khớp là interface, không có trong scene): compile 0 lỗi, EventSystem hoạt động.

So hành vi với bản source, cùng input kịch bản (click phải ở frame 60, trái ở frame 150), sau khi vá MiniUnity (§5):

| | Source | Phục hồi (ugui remap) |
|---|---|---|
| `Main Camera/Transform.position` cuối | (0.00, 2.00, -6.00) | **(0.00, 2.00, -6.00)** |
| `Movement.posZ` | -2.5 | **-2.5** |
| Lỗi trong 300 frame | 1210 (PostProcessing nhánh Editor, `moveSound` MissingReference vì FBX) | **6** (`TextGenerator`) |
| Âm thanh bước chân `Stone footstep 8` | không phát (MissingReference) | phát |

Đây là lần đầu tiên một project AssetRipper phục hồi được **chạy** và so hành vi với nguồn trong pipeline này.

## 5. Ba bản vá cho MiniUnity (đã thử, chưa push — repo chỉ đọc)

`iterations/069/miniunity/api-fixes.diff`, một file mới `Engine/Core/Objects/ScreenAndTextMesh.cs`:

- `Screen.currentResolution` / `resolutions`, `Resolution` (width / height / refreshRate / refreshRateRatio / ToString),
  `RefreshRate.value / Equals / CompareTo / ToString`. Giá trị lấy từ màn hình mô phỏng (`--size`).
- `TextMesh.text / fontSize / color` đọc và ghi túi YAML (`m_Text`, `m_FontSize`, `m_Color`), như các component native khác.
- `DrivenRectTransformTracker.*`: no-op như trong player; `SortingGroup.invalidSortingGroupID` = `0xFFFFF`. Thiếu hằng
  số này thì mọi sự kiện chuột qua `EventSystem.RaycastAll` đều thành "Failed to compare two elements in the array"
  (299 lần / 300 frame).

Sau vá: fixture vẫn 191/1/2 (không hồi quy); GameScene trên source 1552 → 1210 lỗi, trên bản phục hồi 348 → 6. Người
chơi di chuyển ở cả hai.

## 6. Hướng update

### Cho MiniUnity (theo giá trị trên game thật, đo bằng `apigap`)

1. **Tách khỏi repo video cho thật**: chmod `*.sh`; `setup.sh --unity <version>` không cần project cha; fixture tự mang
   `ProjectSettings` và `Library/PackageCache`; `ua_selftest.py` dùng project mẫu trong `tests/` thay cho
   `../Assets/VideoRecreate`; CI (`.github/workflows/miniunity.yml` được nhắc trong ROADMAP 2.5 nhưng không có trong
   repo này).
2. **uGUI `Text` cũ** (`TextGenerator`): rất nhiều game mobile còn dùng; hiện UI menu trắng trơn. Có thể dựa trên
   FontEngine + atlas sẵn có cho TMP.
3. **`SceneManager.LoadScene` / `LoadSceneAsync`**: game nào cũng đi Menu → Game; hiện là stub.
4. **`GraphicsSettings.currentRenderPipeline`** (null cho Built-in RP) và PostProcessing không đi nhánh `UNITY_EDITOR`
   khi Play.
5. **Đọc mesh từ FBX khi không có `Library/`** (ROADMAP 5.3.3, `ufbx`). Project source thật gần như luôn có FBX.
6. **Albedo texture trong shader 3D** và fallback theo property cho shader lạ (ROADMAP 5.1.5): ảnh hiện không có texture.
7. Ba bản vá ở §5.

### Cho AssetRipper (MiniUnity làm cổng E–G)

1. **C1 của kế hoạch 069 giờ đã đo được**: điền `references` của asmdef từ AssemblyRef. Đây là khác biệt giữa "Assembly-CSharp
   bị bỏ qua" và "compile được". Đã chứng minh bằng một script 20 dòng.
2. **Xuất `UnityEngine.UI` (và mọi package chuẩn) thành package, không thành asmdef source**: đổi GUID `m_Script` theo
   tên class sang GUID trong package (76/79 khớp trên RunFromZombies). `PackageRemapPostExporter` đã có khung cho việc này.
3. **Thư viện bên thứ ba (Newtonsoft, Unity.Services.\*) nên xuất Hybrid** (DLL đã phục hồi làm plugin) hoặc thay bằng
   package upstream đã chứng minh. Một assembly lỗi chặn mọi assembly phụ thuộc, kể cả Assembly-CSharp.
4. **`abstract struct`** trong `__Generated`: sửa ở exporter.
5. **Thêm MiniUnity vào harness đo**: `validate_unity_stages.py` stage E (compile như Unity) và F/G (play N giây, so
   `--watch` và nhật ký audio với source khi có). Nhận định trước đây rằng "không có Unity thì không đo được runtime"
   không còn đúng.
6. Compile harness hiện tại (Roslyn từng assembly với reference là DLL) **không thấy** cả ba lỗi 1, 2, 4 ở trên.
   MiniUnity compile như Unity nên thấy được.

## 7. Tái lập

```
GIT_LFS_SKIP_SMUDGE=1 git clone --depth 1 https://github.com/ThinhNV-DEV/miniunity host/MiniUnity
# host/: ProjectSettings/ProjectVersion.txt (2022.3.62f2 + revision 7670c08855a9), Packages/packages-lock.json (§1)
chmod +x host/MiniUnity/*.sh host/MiniUnity/scripts/*.sh
UNITY_EDITOR=<…/2022.3.62f2/Editor> host/MiniUnity/setup.sh        # hoặc --download-unity
UNITY_PROJECT=<project> host/MiniUnity/ua.sh pkg.resolve --fetch
UNITY_PROJECT=<project> host/MiniUnity/ua.sh compile
UNITY_PROJECT=<project> host/MiniUnity/ua.sh play Assets/Scenes/GameScene.unity --seconds 5 --size 720x1280 \
  --watch "Main Camera/Transform.position,Main Camera/Movement.posZ" \
  --input "mouse0@60-62,mouse=(600,640),mouse0@150-152,mouse=(100,640)" --screenshot shot.png@4
UNITY_PROJECT=<project> host/MiniUnity/ua.sh apigap --play Assets/Scenes/GameScene.unity --frames 300
```

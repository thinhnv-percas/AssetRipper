# Runtime contracts — iteration 061

§18–§20: những gì phải được quan sát khi một project khôi phục chạy, và những gì đo được *trước* khi
nó chạy. Không có Unity trong container: mọi kết quả runtime là **NOT_RUN**, không bao giờ là pass.
Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**, **BLOCKED**.

## 1. RuntimeScenario — đã có, không làm lại

`runtime_smoke_contract.py` (iteration 054) đã là §18: một scenario cho mỗi (scene, object, component,
Unity message), initial state đọc từ YAML, `expected_state`/`expected_event` là `UNKNOWN` kèm lý do, và
`runtime_status: NOT_RUN` trên chính artefact.

## 2. RuntimeSnapshot — MEASURED trên initial state

`Test/Scripts/runtime_snapshot.py`, schema `assetripper.runtime-snapshot/1`. Một snapshot được khoá
giống hệt serialized reference graph: GameObject theo hierarchy path, component theo GameObject cộng
kiểu (namespace và class của script), reference theo cái nó trỏ tới, giá trị theo chính nó. **Không có
instance ID, fileID hay GUID nào** trong khoá — hai project không chung cái nào. Float so trong 1e-5
tương đối, vì build serialize lại. Field chỉ-editor (`m_LocalEulerAnglesHint`, inspector identifier…)
bị bỏ.

Hai loại cùng schema: `SERIALIZED_INITIAL_STATE` (đọc từ YAML, loại duy nhất môi trường này tạo được)
và `RUNTIME` (một capture phía editor sẽ ghi; so một snapshot runtime với một snapshot serialized cho
`NOT_RUN`, không bao giờ là một kết quả).

So initial state của source với recovered — nơi mọi scenario bắt đầu:

| | RunFromZombies | Impostor | Merge-Room |
|---|---:|---:|---:|
| Giá trị EQUAL | 14826 | 4894 | 270422 |
| DIFFERENT | 37 | 18 | 2063 |
| UNKNOWN (reference vào script source không khai báo) | 19 | 26 | 442 |
| ABSENT_IN_RECOVERED | 20 | 0 | 0 |
| `value_equality_rate` | **0.9975** | **0.9963** | **0.9924** |

Hai sửa đổi phép đo trên Merge-Room, lần đầu báo **382770** giá trị vắng mặt ở recovered — nhiều bằng
số giá trị khớp:

- `serializedVersion` là một dấu định dạng ở mọi độ sâu — mỗi keyframe của mỗi curve mang một — chứ
  không riêng ở top level.
- `MinMaxCurve` của particle system chỉ đọc `maxCurve` ở mode Curve (1) và cả hai ở TwoCurves (2); ở
  Constant (0) và TwoConstants (3) nó không đọc curve nào. PROVEN trên chính dữ liệu: source có key
  dưới mode 0 (8108 curve) và 3 (1379), recovered không có ở đó và **giống hệt** ở mode 1 (2291) và 2
  (3). Curve không được đọc thì không phải state; build không serialize nó.

Các khác biệt, theo nhóm (MEASURED, nguyên nhân chưa xác lập trừ khi ghi):

- `MeshCollider.m_CookingOptions` 14 → 30 (33 lần trên RunFromZombies).
- `Renderer.m_StitchLightmapSeams` 1 → 0, `m_SelectedEditorRenderState` — thuộc tính baking/editor.
  INFERRED: build không mang chúng và exporter ghi giá trị mặc định; chưa kiểm bằng type tree.
- `ParticleSystem.CustomDataModule.*Label*`, `InitialModule.*.m_RotationOrder` trên Merge-Room (152–153
  mỗi field) — cùng dạng.
- `AudioSource.m_audioClip`: tên bị `FixInvalidFileNameCharacters` đổi, xem
  `SERIALIZED_REFERENCE_GRAPH.md` §3.3 — PROVEN.

`ABSENT_IN_SOURCE` (793 / 324 / 3267) là field build serialize mà scene source (lưu bởi phiên bản script cũ
hơn) không có — không phải lỗi.

## 3. Unity lifecycle contract — MEASURED

`Test/Scripts/lifecycle_contract.py`: với mỗi class hai bên cùng khai báo, message Unity nào nó nhận
(khớp theo khai báo — tên và số tham số — không theo tên: `Update(float)` không phải message),
`IEnumerator Start` khác `void Start`, và execution order (`.meta` hoặc `[DefaultExecutionOrder]`).

| | RunFromZombies | Impostor | Merge-Room |
|---|---:|---:|---:|
| Class so sánh | 14 | 115 | 294 |
| Message so sánh | 27 | 223 | 636 |
| MATCH | 14 | 115 | 294 |
| Khác biệt đã quyết định | 0 | 0 | 0 |
| MESSAGE_UNDER_UNDECIDED_BRANCH | 0 | 1 | 1 |
| `lifecycle_match_rate` | 1.0 | 1.0 | 1.0 |

Ba sửa đổi phép đo, mỗi cái đọc giống hệt một lỗi recovery ở lần chạy trước nó:

- **Class là (assembly, namespace, tên), không phải (namespace, tên).** Feel khai báo hai
  `MoreMountains.FeedbacksForThirdParty.MMAutoFocus`, một trong assembly URP và một trong assembly
  post-processing. Khoá theo tên thì so bản URP của source với bản post-processing của recovery và báo
  mất `Start`/`Update`.
- **Symbol mà project tự nói.** `source_preprocessor.project_defines` đọc scripting define của player
  cho platform trong `ProjectSettings.asset`, và `versionDefines` của asmdef sở hữu file — một
  versionDefine đúng khi package của nó có trong manifest ở phiên bản biểu thức chấp nhận, và **sai**
  khi package không có (`MM_POSTPROCESSING` trên Merge-Room). 9 trong 10 "message thiếu" biến mất.
- **Một branch không quyết định được thì không phải bằng chứng mất.** `compile_text(..., "drop")` là
  cận còn lại: message chỉ có ở bản đọc giữ branch mơ hồ là `MESSAGE_UNDER_UNDECIDED_BRANCH`, UNKNOWN.
  Hai cái còn lại: `WallHackDetector.OnGUI` dưới `#if WALLHACK_DEBUG`, symbol file tự `#define` trong
  `#if (UNITY_EDITOR || DEVELOPMENT_BUILD)`; `AutoSwitchToNewInputSystem.Start` dưới
  `USC_INPUT_SYSTEM`, không nguồn define nào của project nhắc tới.

Kết quả 0 khác biệt là điều nên kỳ vọng và chính nó là thông tin: danh sách method của một class khôi
phục đến từ metadata, nên lifecycle chỉ có thể lệch nếu export bỏ hoặc đổi một khai báo. Contract này
tồn tại để bắt đúng lỗi đó khi nó xảy ra, không phải vì nó đang xảy ra.

## 4. BLOCKED

Chạy scenario, capture snapshot runtime, và so sánh chúng: cần Unity. `IUnityBuildProvider` báo
`UNITY_NOT_AVAILABLE` trong container này (xem `iterations/061/unity-build-RunFromZombies.json`).

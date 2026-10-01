# Unity runtime readiness — iteration 064

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**, **BLOCKED**. Không có Unity trong môi trường này: mọi stage từ
`UNITY_IMPORT` trở đi là `NOT_REACHED`, runtime `NOT_RUN`. Không có PASS nào được suy ra từ exit code (§14).

## 1. `RecoveredProjectManifest.json` (§13)

`Test/Scripts/recovered_project_manifest.py`, mỗi trường đọc từ bằng chứng, trường không được xác lập là null
kèm lý do. Nguyên liệu: `iterations/064/manifest/<fixture>.RecoveredProjectManifest.json`.

| Trường | Nguồn |
|---|---|
| `source` | SHA-256 của `libil2cpp.so`/`UnityFramework` và `global-metadata.dat`, cộng một digest trên đường dẫn + kích thước mọi file |
| `unity_version` | dòng "found Unity version" của log — dữ liệu của chính build, không hằng số |
| `target_platform` | layout package: `lib/<abi>/libil2cpp.so` ⇒ Android (kèm ABI), `UnityFramework` ⇒ iOS (kiến trúc từ header Mach-O) |
| `assemblies`, `packages` | `package_provenance.py` |
| `native_dependencies` | `native_dependency_graph.py` |
| `shaders` | `ShaderPrograms.json` theo encoding, số `.metal` ngoài ShaderLab |
| `serialized` | scene, prefab, material, asset |
| `recovery_confidence` | phân bố semantic status của `recovery_metrics.py` |
| `known_blockers` | những gì bằng chứng nói còn thiếu |
| `runtime_status` | luôn `NOT_RUN` ở đây |

| Fixture | Unity (build) | Platform | Assembly | Blocker |
|---|---|---|---:|---|
| Impostor | 2022.3.62f2 | Android | 42 | RUNTIME_NOT_RUN, 2 package stub không khai báo, shader một phần |
| Merge-Room | 2022.3.62f2 | Android | 99 | như trên, 21 package |
| RunFromZombies | 2022.3.62f2 | Android | 55 | như trên, 12 package |
| Pinata | 2019.2.6f1 | Android | 86 | như trên, 6 package |
| JellyBlastV2 | 2022.3.53f1 | iOS | 59 | thêm `libRF_CNative_ios.a` link tĩnh (vendor phải cấp lại), 3 nhóm `__Internal` UNKNOWN, shader MSL ngoài ShaderLab |

## 2. Stage (§14) — không đổi so với 062–063

`PROJECT_DISCOVERY` → `UNITY_IMPORT` → `SCRIPT_COMPILE` → `ASSET_IMPORT` → `BUILD_PLAYER` → `RUNTIME`
(`AssetRipper.Validation.Unity.UnityBuildStages`). Không Unity ⇒ `UNITY_NOT_AVAILABLE`, exit 2, discovery
PASSED, bốn stage NOT_REACHED, runtime NOT_RUN. Đây là kết quả hợp lệ theo §19E.

## 3. Runtime differential (§15)

Scenario (`runtime_smoke_contract.py`, schema có thêm `message` và `frame` trong iteration này):

| Trường | Giá trị |
|---|---|
| `scene`, `object`, `component`, `message` | đọc từ scene serialize |
| `frame` | từ thứ tự thực thi được Unity *công bố*: `LOAD` (Awake/OnEnable), `FIRST_FRAME_BEFORE_UPDATE` (Start), `EVERY_FRAME`, `EVERY_PHYSICS_STEP`, `EVERY_FRAME_AFTER_UPDATE`, `UNLOAD`, còn lại `EVENT_DRIVEN` — một sự thật về hợp đồng của engine, không phải quan sát |
| `input` | `NONE` (message Unity không nhận đối số) |
| `initial_state` | field serialize của component |
| `expected_state`, `expected_event` | **`UNKNOWN`** — cần engine; không tự sinh (§15) |

JellyBlastV2: 276 scenario trên 2 scene, 33 component; `expected_state` xác định 0/276. Theo frame: LOAD 115,
UNLOAD 90, FIRST_FRAME_BEFORE_UPDATE 24, EVERY_FRAME 23, EVERY_PHYSICS_STEP 23, EVERY_FRAME_AFTER_UPDATE 1.

Snapshot (`runtime_snapshot.py`, schema `assetripper.runtime-snapshot/1`): khoá theo đường dẫn hierarchy và kiểu,
không instance ID. Phủ hôm nay từ YAML: active, tag, layer, Transform, enabled, field serialize, reference.
Renderer/material/shader/animation/particle/physics/custom chỉ là field serialize của component tương ứng —
trạng thái *runtime* của chúng cần capture phía editor: **BLOCKED**.

## 4. Kết luận

**Không FULLY_RECOVERED.** Không có bằng chứng runtime Unity nào. Những gì đã chứng minh: project tự mô tả
được (manifest), phụ thuộc native và package có provenance, scenario có hình dạng đúng và trung thực về điều
chưa biết.

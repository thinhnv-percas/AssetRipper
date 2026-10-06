# Buildability, Unity gate và artefact project — iteration 067 (§11, §15, §16, §17)

Nhãn: **MEASURED**, **PROVEN**, **BLOCKED**, **UNITY_NOT_AVAILABLE**.

## 1. Ma trận (67x) — `Test/Scripts/buildability_matrix.py`

| Fixture | Native | Semantic (tỉ lệ EXACT) | Project A–C | Compile (tỉ lệ file sạch, Assembly-CSharp) | Runtime | Behaviour (oracle tĩnh) |
|---|---|---|---|---|---|---|
| Impostor | PASS | 0.8274 | FAIL (refs 0.9942) | FAIL 0.625 → **0.6406** (208 → 194 lỗi) | UNITY_NOT_AVAILABLE | NOT_MEASURED |
| Merge-Room | PASS | 0.7478 | FAIL (refs 0.9998) | FAIL 0.5952 → **0.6071** (310 → 298) | UNITY_NOT_AVAILABLE | NOT_MEASURED |
| JellyBlastV2 | PASS | 0.7065 | FAIL (refs 1.0) | FAIL 0.352 → **0.4525** (2599 → 1982) | UNITY_NOT_AVAILABLE | 0.7594 → **0.7864** (độc lập) |
| RunFromZombies | PASS | 0.7542 | PASS (refs 1.0) | FAIL 0.7826 → 0.7826 (7 → 7) | UNITY_NOT_AVAILABLE | 1.0 (35/35) |
| Pinata | PASS | 0.8034 | FAIL (refs 1.0) | FAIL 0.6447 → 0.6456 (1144 → 1136) | UNITY_NOT_AVAILABLE | NOT_MEASURED |

Tỉ lệ EXACT ở đây đo bằng `recovery_metrics.py` đã sửa ở 067 (§4), nên không so trực tiếp với cột của 066.

Toàn bộ project (stage D của `validate_unity_stages.py`, mọi assembly):

| | file sạch | lỗi | `compile_pass_rate` | `body_recovery_rate` |
|---|---|---:|---:|---:|
| Impostor | 749 / 830 | 660 | 0.9024 | 0.9896 |
| Merge-Room | 3709 / 4033 | 2426 | 0.9197 | 0.9867 |
| JellyBlastV2 | 1327 / 1471 | 3027 | 0.9021 | 0.9949 |
| RunFromZombies | 779 / 796 | 39 | 0.9786 | 0.9853 |
| Pinata | 2339 / 3115 | 4813 | 0.7509 | 0.9835 |

Stage D là declaration pass cộng body pass của từng assembly. Đọc nó cạnh `body_recovery_rate`, không thay cho nó.

## 2. Trạng thái — `PROJECT_GENERATED_COMPILE_IMPROVED`

Mục tiêu §16 của brief là `PROJECT_GENERATED_COMPILE_IMPROVED`. Bốn trên năm fixture có tỉ lệ file sạch tăng. Không
fixture nào lùi. RunFromZombies đứng yên ở 7 lỗi: 5 STRUCT_FIRST_MEMBER, và 2 member IL2CPP strip khỏi build
(`Quaternion.Euler(Vector3)` CS7036, `Math.PI` CS0117) — hai lỗi đó không có trên một bản Unity thật. **Không fixture
nào compile sạch**, nên trạng thái không phải `PROJECT_COMPILES`.

## 3. Unity gate (§17)

`buildability_matrix.find_unity` tìm `UNITY_PATH`, `Unity`/`unity`/`unity-editor` trên PATH và các vị trí Hub, và không
thấy editor nào trong container. Hệ quả:
- stage E–I của `validate_unity_stages.py` là `BLOCKED (UNITY_NOT_AVAILABLE)` trên cả năm fixture;
- mọi cột runtime là `UNITY_NOT_AVAILABLE`;
- không stage nào được thay bằng PASS, và `FULLY_RECOVERED` là `false` trên mọi fixture.

`AssetRipper.Tools.UnityBuildValidator` là đường chạy khi có Unity: exit 2, `UNITY_NOT_AVAILABLE`.

## 4. Artefact project — `project_artifact_check.py`

| | `Packages/manifest.json` | `packages-lock.json` | `Assets/Plugins` |
|---|---|---|---|
| Impostor, Merge-Room, RunFromZombies, Pinata | 31 module built-in, 0 package | ABSENT | như 066 |
| JellyBlastV2 mặc định | 31 module, 0 package | ABSENT | iOS: 6 `.framework` Facebook SDK |
| JellyBlastV2 với `--package-cache` (67xk) | 31 module + **3 package** | ABSENT (**BLOCKED**) | như trên |

Ba package vào manifest là `com.unity.mathematics` 1.2.6, `com.unity.textmeshpro` 3.0.9 và
`com.unity.visualscripting` 1.9.11. Cả ba là UPSTREAM_EXACT, chứng minh bằng fingerprint khai báo. Chi tiết, kể cả lý
do `com.unity.ugui` 1.0.0 không vào, ở `PACKAGE_MANIFEST_067.md`. Không version nào được ghi khi thiếu bằng chứng.

Không có `--package-cache`, manifest giữ nguyên như 066. Package chỉ được thay khi có cache `name@version` để thay, vì
một version trong manifest mà export vẫn giữ mã của package đó sẽ khai báo hai lần cùng một type.

Kết quả theo fixture: `iterations/067/artifacts/*.json`.

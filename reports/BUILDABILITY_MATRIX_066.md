# Ma trận buildability, Unity gate và artefact project — iteration 066 (§10, §11, §12)

Nhãn: **PROVEN**, **MEASURED**, **BLOCKED**, **UNITY_NOT_AVAILABLE**. Gộp ba mục (buildability, Unity runtime
readiness, artefact E2E) vào một báo cáo vì chúng là ba cột của cùng một bảng.

## 1. Ma trận (66i) — `Test/Scripts/buildability_matrix.py`

Các phép đo cũ giữ nguyên; ma trận đặt cạnh chúng sáu mức, mỗi mức đọc từ artefact sở hữu nó.

| Fixture | Native | Semantic (tỉ lệ EXACT) | Project A–C | Compile (tỉ lệ file sạch) | Runtime | Behaviour |
|---|---|---|---|---|---|---|
| Impostor | PASS | 0.8273 | FAIL (refs 0.9942) | FAIL 0.625 (208 lỗi) | UNITY_NOT_AVAILABLE | NOT_MEASURED |
| Merge-Room | PASS | 0.7472 | FAIL (refs 0.9998) | FAIL 0.5952 (310 lỗi) | UNITY_NOT_AVAILABLE | NOT_MEASURED |
| JellyBlastV2 | PASS | 0.5647 | FAIL (refs 1.0) | FAIL 0.352 (2599 lỗi) | UNITY_NOT_AVAILABLE | 0.7594 (oracle tĩnh, độc lập) |
| RunFromZombies | PASS | 0.7559 | PASS (refs 1.0) | FAIL 0.7826 (7 lỗi) | UNITY_NOT_AVAILABLE | 1.0 (oracle tĩnh) |
| Pinata | PASS | 0.8049 | FAIL (refs 1.0) | FAIL 0.6447 (1144 lỗi) | UNITY_NOT_AVAILABLE | NOT_MEASURED |

Chú thích từng cột:
- **Native:** run hoàn tất; 0 thân văng khỏi generator; 0 field layout bất đồng; 0 MonoBehaviour layout mismatch.
- **Project A–C:** project được tạo, script được tạo, reference nhất quán. Stage C FAIL vì một số ít reference không
  resolve (Impostor 8 trên 1376; các fixture khác dưới 1 phần nghìn).
- **Compile:** body pass của Assembly-CSharp. Stage D của `validate_unity_stages.py` chỉ đếm declaration pass
  (Merge-Room 4 lỗi, JellyBlastV2 11). Đọc con số đó như số lỗi thân là bẫy "lỗi khai báo che lỗi thân" lần nữa,
  nên ma trận lấy body pass.
- **Behaviour:** là oracle *tĩnh* trên văn bản phục hồi. Tương đương hành vi cần cả hai build chạy, và chưa có build
  nào chạy.
- **`FULLY_RECOVERED`:** `false` trên mọi fixture.

## 2. Unity gate (§11)

`buildability_matrix.find_unity` tìm `UNITY_PATH`, `Unity`/`unity`/`unity-editor` trên PATH, và các vị trí Hub. Trong
container không có. Mọi stage runtime đều là `UNITY_NOT_AVAILABLE`:
- import;
- compile trong editor;
- build;
- launch;
- scenario.

Stage E–I của `validate_unity_stages.py` là `BLOCKED (UNITY_NOT_AVAILABLE)`. Không stage nào được thay bằng PASS.
`AssetRipper.Tools.UnityBuildValidator` (065) là đường chạy khi có Unity.

## 3. Artefact project (§12) — `Test/Scripts/project_artifact_check.py`

| | `Packages/manifest.json` | `packages-lock.json` | `Assets/Plugins` | `ProjectSettings` |
|---|---|---|---|---|
| Impostor | 31 module built-in, 0 package khác | ABSENT | không có | 17 file, 2022.3.62f2 |
| Merge-Room | 31 module, 0 package | ABSENT | Android `arm64-v8a`, `armeabi-v7a` (`liblofelt_sdk.so`) | 17 file, 2022.3.62f2 |
| JellyBlastV2 | 31 module, 0 package | ABSENT | iOS: 6 `.framework` Facebook SDK | 17 file, 2022.3.53f1 |
| RunFromZombies | 31 module, 0 package | ABSENT | không có | 18 file, 2022.3.62f2 |
| Pinata | 31 module, 0 package | ABSENT | Android `arm64-v8a` (7 `.so`) | 18 file, 2019.2.6f1 |

Đọc bảng:
- `com.unity.modules.*` đều 1.0.0. Đó là version editor cố định cho module built-in, không phải một phỏng đoán.
- Manifest không khai báo một package nào ngoài module, nên một project mở ra từ export sẽ thiếu mọi package (TMP,
  UGUI, Burst…). Version đã chứng minh được của chúng nằm trong `iterations/065/manifest/`
  (`package_manifest_reconstruction.py`), chưa được ghi vào `Packages/manifest.json`. Không version nào được bịa.
- `packages-lock.json` không được export. Không có nguồn nào để dựng nó ngoài chính manifest.

Kết quả theo fixture: `iterations/066/artifacts/*.json`.

## 4. Kết luận đặt cho câu hỏi "export → project → build → chạy" đang ở đâu

- **Tới compile, kiểm được.** Không fixture nào compile sạch. Tỉ lệ file sạch từ 0.35 (JellyBlastV2) tới 0.78
  (RunFromZombies).
- **Sau compile, không kiểm được.** Unity không có trong container.
- **Trạng thái tổng:** `PROJECT_COMPILES_NOT_RUNTIME_VALIDATED` vẫn là cách gọi quá lời cho mọi fixture có lỗi thân.
  Cách gọi đúng là `PROJECT_GENERATED_COMPILE_FAILS`, với số lỗi ở trên.

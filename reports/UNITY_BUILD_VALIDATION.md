# Unity build validation — iteration 062

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**, **BLOCKED**.

## 1. Từ một status thành sáu stage

Iteration 061 dựng `IUnityBuildProvider` (Local, Docker, Unavailable) và `UnityLogClassifier`, trả
về *một* status cho cả lần chạy. Một status che mất stage nó nói về: "Unity exited 1" có thể là
licence, import, compile hay build, và kết luận duy nhất không bao giờ được rút ra từ exit code là
scripts không compile (§21).

`AssetRipper.Validation.Unity/UnityBuildStages.cs` quyết định từng stage trên bằng chứng riêng của nó:

| Stage | PASSED khi | FAILED khi | Còn lại |
|---|---|---|---|
| `PROJECT_DISCOVERY` | có `Assets/` và `ProjectSettings/`; version đọc từ `ProjectVersion.txt` | không phải project | — |
| `UNITY_IMPORT` | validation method đã chạy (Unity chỉ chạy `-executeMethod` sau khi project mở) | log có dấu hiệu import/package lỗi | `UNKNOWN` |
| `SCRIPT_COMPILE` | validation method chạy và không báo `CompileFailed` | `error CSxxxx`, "Scripts have compiler errors", marker `CompileFailed` | `UNKNOWN` — exit code một mình không quyết định |
| `ASSET_IMPORT` | validation method chạy (sau initial import) | "Asset import failed", "Could not create asset from", "Failed to import asset" | `UNKNOWN` |
| `BUILD_PLAYER` | marker `BUILD_RESULT Succeeded`, exit 0 **và** player trên đĩa | marker `Failed`, crash, hoặc marker thành công mà không có player | `UNKNOWN` |
| `RUNTIME` | — | — | luôn `NOT_RUN`: build một player không phải chạy nó |

Bằng chứng của stage sau chứng minh stage trước. Stage sau một stage `FAILED` là `NOT_REACHED`; khi
editor không chạy, mọi stage sau discovery là `NOT_REACHED` với lý do. `UnityBuildResult.Stages` đi
vào JSON (`"stages": [{stage, outcome, evidence}]`) ở cả ba provider, và
`AssetRipper.Tools.UnityBuildValidator` in từng stage.

## 2. Kết quả trong container này — BLOCKED

`iterations/062/unity-build-RunFromZombies.json`, trên bản rip `Test/Out62m-j/RunFromZombies`:

```
UNITY_NOT_AVAILABLE  BLOCKED  local: no Unity 2022.3.62f2 editor at any of: ...
  PROJECT_DISCOVERY  PASSED       Assets/ and ProjectSettings/ present; ProjectVersion.txt reads 2022.3.62f2
  UNITY_IMPORT       NOT_REACHED  the editor did not run the project: ...
  SCRIPT_COMPILE     NOT_REACHED  ...
  ASSET_IMPORT       NOT_REACHED  ...
  BUILD_PLAYER       NOT_REACHED  ...
  RUNTIME            NOT_RUN      a build does not run the player; no runtime harness was run
```

**BLOCKED**: không có Unity editor trong container, không có licence và Docker không được bật. Không
kết quả runtime nào được tạo ra; `runtime_status = NOT_RUN` ở mọi nơi.

## 3. Test

`UnityBuildValidationTests`, năm case mới, mỗi case đỏ nếu luật nó mang tên bị bỏ:

- mọi stage đều được báo và `RUNTIME` không bao giờ được build quyết định;
- exit 1 không kèm log nào không quyết định stage nào (`SCRIPT_COMPILE`, `UNITY_IMPORT`,
  `BUILD_PLAYER` đều `UNKNOWN`);
- lỗi dừng ở đúng stage của nó: compile error → `SCRIPT_COMPILE FAILED`, `BUILD_PLAYER NOT_REACHED`;
  import lỗi rồi compile error → `UNITY_IMPORT FAILED`, `SCRIPT_COMPILE NOT_REACHED` (compile error
  sau import lỗi là hệ quả, không phải lỗi thứ hai);
- marker thành công không có player → `BUILD_PLAYER FAILED`;
- không có editor → discovery `PASSED`, bốn stage `NOT_REACHED`, runtime `NOT_RUN`, và JSON mang
  `"stage": "RUNTIME"`.

## 4. Còn thiếu

- **UNKNOWN**: các chuỗi nhận diện asset import lỗi được chọn từ thông điệp Unity đã biết, chưa được
  kiểm trên một log thật của một project khôi phục. Cần một môi trường có Unity để xác nhận.
- Runtime scenario / snapshot so với bản gốc (§22–§23) cần một player chạy được: **BLOCKED**.

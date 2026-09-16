# Merge-Room — fixture thứ tư

Thêm vào ma trận mặc định ở iteration 054. Đây là fixture Android lớn nhất trong ma trận và là
fixture thứ ba có source đối chiếu.

## Provenance

| | |
|---|---|
| build artifact | `https://github.com/thinhabc01/Merge-Room/releases/download/v1/merge-room.apk` |
| sha256 | `fdd2b98f269d5e1d4d825d694d66c607c1e1a6c85c361726e19af0d0f7836ff2` |
| kích thước | 73.821.977 byte |
| source repository | `https://github.com/thinhabc01/Merge-Room` @ `63e88b33` ("update dll") |
| thư mục fixture | `Test/Input/MergeRoom` (gitignored) |

Build artifact và source repository được ghi provenance riêng. **Source chỉ là oracle** — không có
đường nào từ source đi vào pipeline extraction/recovery, và `source_manifest.py`/`source_oracle.py`
chỉ đọc nó.

## Fingerprint

| | |
|---|---|
| Unity | 2022.3.62f2 (`ProjectVersion.txt` của source; `boot.config` không mang phiên bản) |
| ABI | `arm64-v8a` và `armeabi-v7a` (rip dùng arm64) |
| metadata | v31 (`af 1b b1 fa 1f 00 00 00`) |
| `libil2cpp.so` | 63.135.680 byte (arm64-v8a) |
| `global-metadata.dat` | 11.338.380 byte |
| assembly khai báo trong build | 137 (`ScriptingAssemblies.json`) |
| assembly recovery thử | 29, stub 68 |
| scene | 2 — `[Gtap]CoreScene.unity`, `Level_1.unity` |
| prefab | 36 |
| material | 333 |
| shader | 34 |

Đáng chú ý về nội dung: Odin (Sirenix), MoreMountains Feedbacks, Cinemachine, UniTask, URP,
EasySave3, Newtonsoft.Json, Unity Input System, LevelPlay, Unity Services. Đây là bản dựng có nhiều
package nhất trong ma trận.

## Baseline (iteration 054)

Đo trên `Test/Out54mr2`, sau khi tiến trình rip thoát.

| | |
|---|---|
| `.cs` | 4009 |
| method có địa chỉ native | 15.237 |
| `EXACT` | 6639 (43,6%) |
| `HIGH_CONFIDENCE` | 353 |
| `PARTIAL` | 6755 |
| `FALLBACK` | 1490 |
| `MISSING` | 0 |
| placeholder | 37.663 |
| `body_recovery_rate` | 0,9022 |
| `compile_pass_rate` | 0,8937 (3573 / 3998 file, 4865 lỗi) |
| `reference_resolution_rate` | 0,9998 (12.355 / 12.358) |
| `type_recovery_rate` | 0,9943 (1222 / 1229) |
| `property_recovery_rate` (shader) | 1,0000 (78 / 78) |
| `shader_exact` | 0 / 34 — **tất cả DUMMY** |
| field layout | 3947 / 4181, **0 disagreed** |
| `generatorFailures` | **0** |
| stage E–I | BLOCKED, `UNITY_NOT_AVAILABLE` |

## Source có khớp build không

**Có**, theo phép kiểm ngược: không một kiểu nào bản build có mà source không khai báo
(`source_matches_build`). Ba thứ từng đọc như sai lệch đều có lý do gọi tên được — `PlayerInput`
Unity sinh từ `PlayerInput.inputactions`, còn `<>f__AnonymousType0` và
`<PrivateImplementationDetails>` là tên compiler sinh, không tên nào viết được trong source.

Chiều ngược lại — source có mà build không — là **216 kiểu `NOT_IN_METADATA`**, và đó là cấu hình
build chứ không phải mất mát: `YandexAppMetrica` và `AppsFlyer` xuất hiện **0 lần** trong chính
`global-metadata.dat` của bản build, trong khi `GameManager` xuất hiện 3 lần. Source cây có các SDK
ấy, bản dựng thì không.

Còn lại 7 `NOT_IN_BUILD` thật sự chưa giải thích được, tất cả trong `Assembly-CSharp`: bốn file ví
dụ của Facebook SDK (`Menu`, `UIState`, `Utility`), `GameAnalytics` `Settings`/`Game`, và hai module
DOTween. Cả bảy đều là code demo hoặc module tuỳ chọn.

## Ba tham chiếu không theo được

`m_Texture` một lần và `m_AtlasTextures` một lần trong `.asset`/`.mat`. 1116 `m_Texture` khác là
`NULL` hợp lệ (một material không gán texture), nằm ngoài mẫu số. `m_Script` **808/808** phân giải,
nên không MonoBehaviour nào mất component.

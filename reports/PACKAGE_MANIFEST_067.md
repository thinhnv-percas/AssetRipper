# Package manifest từ version đã chứng minh — iteration 067 (§11)

Nhãn: **PROVEN**, **MEASURED**, **BLOCKED**.

## 1. Đường đi

Một package chỉ vào `Packages/manifest.json` khi version của nó được chứng minh. Ba bước, mỗi bước là thứ đã có
hoặc một script nhỏ:

1. **Chứng minh version.** `package_provenance.py` / `package_manifest_reconstruction.py` (065) phân loại từng package
   theo fingerprint khai báo của assembly trong build. Kết quả ở
   `iterations/065/manifest/JellyBlastV2.RecoveredProjectManifest.json`. Chỉ `UPSTREAM_EXACT` mang một version.
2. **Lấy package.** `Test/Scripts/proven_package_cache.py` (mới):
   - đọc manifest đó, tải *chỉ* các package `UPSTREAM_EXACT` từ `packages.unity.com` đúng version đã chứng minh;
   - từ chối tarball có `package.json` khai báo tên hoặc version khác;
   - giải nén theo layout `name@version` mà resolver đọc;
   - ghi `provenance.json` cạnh cache.

   Mọi package khác được ghi kèm lý do và không vào cache.
3. **Thay bản rip.** `PackageRemapPostExporter` có từ trước và làm đúng phần khó:
   - trỏ lại mọi script reference sang GUID của package thật;
   - xoá bản rip mà package thay thế, để không kiểu nào bị khai báo hai lần;
   - thêm package vào `Packages/manifest.json`.

   Nó chỉ cần một nguồn. `SystemTester --package-cache <dir>` (mới) đặt `ExportSettings.OfficialPackageCachePath`.

## 2. JellyBlastV2 — MEASURED

`proven_package_cache.py iterations/065/manifest/JellyBlastV2.RecoveredProjectManifest.json Test/Input/PackageCache/JellyBlastV2`:

| Package | Phân loại build | Version | Vào manifest |
|---|---|---|---|
| com.unity.mathematics | UPSTREAM_EXACT | 1.2.6 | **có** |
| com.unity.textmeshpro | UPSTREAM_EXACT | 3.0.9 | **có** |
| com.unity.visualscripting | UPSTREAM_EXACT | 1.9.11 | **có** |
| com.unity.ugui | UPSTREAM_EXACT | 1.0.0 | không: `PROVEN_VERSION_NOT_ON_REGISTRY` (core package đi kèm editor; registry trả 404) |
| com.unity.burst | UPSTREAM_VERSION_MISMATCH | — | không: `NOT_PROVEN` |
| com.unity.collections | UPSTREAM_VERSION_MISMATCH | — | không: `NOT_PROVEN` |
| com.unity.nuget.newtonsoft-json | UNKNOWN | — | không: `NOT_PROVEN` |

Rip với `--package-cache` (`Test/Out67k-i`), theo log của post exporter:
- 3 package được thêm vào manifest;
- 490 file bản rip mà chúng thay thế bị xoá (`Unity.Mathematics`, `Unity.TextMeshPro`, `Unity.VisualScripting.Core`
  không còn dưới `Assets/Scripts`);
- 45 script reference được viết lại trên 21 file;
- `UnityEngine.UI` vẫn là bản rip, vì version đã chứng minh không tải được.

Các module built-in `com.unity.modules.*` giữ nguyên như export vẫn ghi.

## 3. packages-lock.json — BLOCKED

Không tạo ra. Chỉ resolver của một editor thật mới nói được lock file chứa gì. Một lock file viết từ manifest sẽ
tuyên bố một lần resolve chưa từng chạy. `provenance.json` ghi `packages_lock: BLOCKED` kèm lý do đó.

## 4. Các fixture khác — BLOCKED

Impostor, Merge-Room, RunFromZombies và Pinata chưa có bước 1: chưa fixture nào được đo fingerprint theo package
như JellyBlastV2 ở 063–065. Không có version nào được chứng minh, nên manifest của chúng không nhận package nào.
Đó là đúng chứ không phải thiếu sót của bước 2–3.

## 5. Test

`proven_package_cache.py --self-test`, 8 case:
- chỉ version đã chứng minh được nhận;
- UNKNOWN và version mismatch không bao giờ được nhận;
- package không có trong build không được nhận cũng không được báo;
- version đã chứng minh mà registry không có thì được báo, không thay bằng version khác;
- tarball khai báo version khác bị từ chối;
- lock file BLOCKED, không được viết;
- layout cache là layout resolver đọc.

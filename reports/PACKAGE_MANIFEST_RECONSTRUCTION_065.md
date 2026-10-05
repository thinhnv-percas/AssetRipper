# Package manifest reconstruction — iteration 065 (§10)

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Công cụ: `Test/Scripts/package_manifest_reconstruction.py`
(`--self-test` 4/4). Nguyên liệu: `iterations/065/packages/jellyblast-manifest-reconstruction.json`.

## 1. Nguyên tắc

Một checkout ghi version của package ở tối đa ba chỗ, và ba chỗ đó không bắt buộc khớp nhau:

- **manifest** (`Packages/manifest.json`): cái được yêu cầu;
- **lock** (`Packages/packages-lock.json`): cái resolver đã chọn, cùng **depth** (dependency trực tiếp là depth 0);
- **PackageCache** (`Library/PackageCache/<name>@<version>`): cái thực sự có trên đĩa của editor.

Không chỗ nào trong ba chỗ đó là build. Build chỉ lên tiếng qua **fingerprint**: khai báo trong assembly mà build
ship so với khai báo của package (063, `build_provenance.py`). Với package ship DLL biên dịch sẵn, có thêm một câu
hỏi phải trả lời trước: các version ứng viên có ship DLL khác nhau không.

Mỗi package được báo cáo theo bốn cột **tách riêng**. Version chỉ được điền khi fingerprint xác lập build ship đúng
package đó **và** cả ba nguồn khớp; còn lại là `UNKNOWN`, kèm xung đột nếu có. Không version nào được chọn bằng
cách đoán, và không dependency nào bị bỏ để project "compile được".

## 2. Kết quả — MEASURED

| Package | manifest | lock (depth) | PackageCache | Fingerprint build | Version |
|---|---|---|---|---|---|
| `com.unity.textmeshpro` | 3.0.9 | 3.0.9 (0) | 3.0.9 | PROVEN_BUILD_MATCH | **3.0.9** |
| `com.unity.ugui` | 1.0.0 | 1.0.0 (0) | 1.0.0 | PROVEN_BUILD_MATCH | **1.0.0** |
| `com.unity.mathematics` | 1.2.6 | 1.2.6 (0) | 1.2.6 | PROVEN_BUILD_MATCH | **1.2.6** |
| `com.unity.visualscripting` | 1.9.11 | 1.9.11 (0) | 1.9.11 | PROVEN_BUILD_MATCH | **1.9.11** |
| `com.unity.burst` | 1.8.21 | 1.8.21 (0) | 1.8.21 | SOURCE_MISMATCH | **UNKNOWN** |
| `com.unity.collections` | 1.2.4 | 1.2.4 (0) | 1.2.4 | SOURCE_MISMATCH | **UNKNOWN** |
| `com.unity.nuget.newtonsoft-json` | 3.2.1 | 3.2.2 (**2**) | 3.2.2 | xem mục 3 | **UNKNOWN**, ứng viên {3.2.1, 3.2.2} |

Burst và Collections: ba nguồn khớp nhau, nhưng khai báo của checkout khác build (063: Collections bị hạ về 1.2.4
trước commit đầu). Ba nguồn khớp nhau mà không khớp build thì vẫn không phải version của build.

## 3. Newtonsoft — xung đột, và lý do xung đột không thể giải bằng fingerprint

**Xung đột giữa các nguồn — PROVEN:**

- manifest ghi `3.2.1`, lock ghi `3.2.2`, PackageCache có `com.unity.nuget.newtonsoft-json@3.2.2` (thư mục
  `Library/` được commit ở `88cb0ae0`, "add library").
- Lock ghi package ở **depth 2**, tức là *không* phải dependency trực tiếp, nhưng manifest pin nó trực tiếp. Nếu pin
  trực tiếp đó có hiệu lực khi resolve thì lock phải ghi depth 0. Vậy manifest và lock mô tả **hai lần resolve khác
  nhau**. Lock khớp với `com.unity.services.core 1.18.0` (lock) cần `newtonsoft-json 3.2.2`, trong khi manifest khai
  `services.core 1.14.0`: lock là trạng thái của một manifest khác với manifest đang có.
- Cả ba trạng thái giống nhau ở `fe27775f`, `606d4b1c` và `HEAD`: xung đột có từ commit đầu, không phải do một
  commit sau.

**Vì sao không thể chọn — MEASURED:** tải cả hai version từ registry
(`https://packages.unity.com/com.unity.nuget.newtonsoft-json/-/…-3.2.1.tgz` và `…-3.2.2.tgz`):

| File | SHA-256 (3.2.1) | SHA-256 (3.2.2) |
|---|---|---|
| `Runtime/AOT/Newtonsoft.Json.dll` (bản IL2CPP dùng) | `a5614620…dfbf1f` | `a5614620…dfbf1f` — **giống hệt** |
| `Runtime/Newtonsoft.Json.dll` | `7292d3eb…0897e` | `7292d3eb…0897e` — **giống hệt** |

DLL trong `PackageCache@3.2.2` của checkout cũng có đúng hash đó. Changelog của 3.2.2 ("Fixed Newtonsoft DLL when
compiling with netstandard 2.0") không đổi một byte nào của DLL. Khi payload của hai ứng viên trùng từng byte thì
**không fingerprint nào của build có thể chọn giữa chúng** — đây là giới hạn của bằng chứng, không phải của công cụ.

**Fingerprint của build so với DLL — MEASURED:** 3651 dòng khai báo của `Newtonsoft.Json` mà build ship (đọc từ
`AuxiliaryFiles/GameAssemblies`) so với 6835 dòng của DLL AOT: 3623 dòng nằm trong DLL. 28 dòng còn lại là attribute
do exporter tự chèn (`AddressAttribute`, `NativeSourceAttribute`), `<PrivateImplementationDetails>` mà compiler đặt
tên theo hash, và cách viết tên khác nhau của explicit interface implementation. Không dòng nào là một member mà DLL
không có. Build ship đúng DLL này; version là {3.2.1, 3.2.2}, không hẹp hơn được.

## 4. Hệ quả cho project xuất ra

`recovered_project_manifest.py` vẫn ghi blocker `PACKAGES_STUBBED_NOT_DECLARED`. Bốn package có version chứng minh
được có thể khai báo; Burst, Collections và Newtonsoft thì không. Ghi một version cho ba package đó để project
"compile được" là đúng thứ brief cấm (§10, §13), nên chúng giữ `version: UNKNOWN` cùng ứng viên và xung đột.

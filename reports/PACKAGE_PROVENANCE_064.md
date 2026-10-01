# Package provenance — iteration 064

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**. Công cụ: `Test/Scripts/package_provenance.py`
(`--self-test` 6/6). Nguyên liệu: `iterations/064/packages/<fixture>.json`.

## 1. Vấn đề

`Packages/manifest.json` của project xuất ra chỉ liệt kê module engine (`com.unity.modules.*`). Project không
biết `Unity.TextMeshPro` là một package, `Assembly-CSharp` là game, `__Generated` do build sinh ra. Mỗi assembly
build ship giờ có một category, và các sự thật riêng brief yêu cầu: `manifest_declared`, `engine_provided`,
`vendor_source`, `stub_only`, `in_build`, `export` (RECOVERED / STUB, đọc từ dòng `Attempted:` của log — không
đoán), `version` cùng nguồn của nó.

| Category | Khi nào |
|---|---|
| `UPSTREAM_EXACT` | khai báo khớp checkout của package (`build_provenance.py` PROVEN_BUILD_MATCH / LIKELY_MATCH) |
| `UPSTREAM_VERSION_MISMATCH` | package registry, checkout khai báo bề mặt khác build |
| `BUILTIN_UNITY` | `UnityEngine.*Module`, `UnityEngine`, thư viện lớp .NET |
| `CUSTOM` | code game (và SDK vendor), được phục hồi |
| `GENERATED` | `__Generated` |
| `STUB` | trong build, bị stub, không fingerprint nào chứng minh upstream nào |
| `NOT_IN_BUILD` | manifest source khai báo, không assembly nào trong build |
| `UNKNOWN` | không gì ở trên được xác lập |

**Tên assembly không phải bằng chứng version.** `Unity.TextMeshPro` cho biết package *nào*; chỉ fingerprint
khai báo cho biết *build ship đúng nó*. Không có fingerprint ⇒ `STUB`, version `null`. Version không bao giờ
được điền để compile (§9 brief).

## 2. Kết quả — MEASURED

| Fixture | UPSTREAM_EXACT | VERSION_MISMATCH | BUILTIN | CUSTOM | GENERATED | STUB | NOT_IN_BUILD | UNKNOWN |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
| Impostor | — | — | 31 | 8 | 1 | 2 | — | — |
| Merge-Room | — | — | 50 | 26 | 1 | 21 | — | 1 |
| RunFromZombies | — | — | 40 | 1 | 1 | 12 | — | 1 |
| Pinata | — | — | 39 | 41 | — | 6 | — | — |
| JellyBlastV2 (với source) | **6** | **2** | 39 | 9 | 1 | 1 | 28 | 1 |

Fixture không có source thì không có gì chứng minh upstream: mọi package registry ở đó là `STUB` — đúng, không
phải thiếu sót của công cụ.

### JellyBlast — bảy package brief hỏi

| Package | Category | Export | Version | Nguồn version |
|---|---|---|---|---|
| `com.unity.textmeshpro` | UPSTREAM_EXACT | STUB | 3.0.9 | manifest source, khai báo khớp |
| `com.unity.ugui` | UPSTREAM_EXACT | STUB | 1.0.0 | như trên |
| `com.unity.mathematics` | UPSTREAM_EXACT | STUB | 1.2.6 | như trên |
| `com.unity.visualscripting` | UPSTREAM_EXACT | STUB | 1.9.11 | như trên |
| `com.unity.burst` | UPSTREAM_VERSION_MISMATCH | STUB | null | checkout 1.8.21 khai báo khác build |
| `com.unity.collections` | UPSTREAM_VERSION_MISMATCH | STUB | null | checkout bị hạ về 1.2.4 (063) |
| `com.unity.nuget.newtonsoft-json` | UNKNOWN | RECOVERED | null | không có checkout để fingerprint |

`Unity.Burst.Unsafe` là `STUB` (không có hàng fingerprint riêng). PathCreator và Voodoo.UI.Particles là vendor
source dưới `Assets/` với khai báo khớp: `UPSTREAM_EXACT`.

## 3. Hệ quả cho project xuất ra — chưa thay đổi

`recovered_project_manifest.py` ghi blocker `PACKAGES_STUBBED_NOT_DECLARED`: các assembly package bị stub
nhưng `manifest.json` xuất ra không khai báo package của chúng. Thêm chúng vào manifest cần version, và version
chỉ được chứng minh cho 4 package của JellyBlast. Iteration này **không** sửa manifest xuất ra: ghi provenance
trước, sửa sau, đúng thứ tự brief yêu cầu.

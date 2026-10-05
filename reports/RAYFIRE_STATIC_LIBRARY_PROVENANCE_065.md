# RayFire static library provenance — iteration 065 (§9)

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**. Công cụ: `Test/Scripts/static_library_provenance.py`
(`--self-test` 5/5). Nguyên liệu: `iterations/065/native/rayfire-static-library-provenance.json`.

## 1. Kết luận

**`SOURCE_ORACLE_ARTIFACT_AVAILABLE`, và mạnh hơn mức brief yêu cầu: `LINKED_ARCHIVE_PROVEN`.** Lát arm64 của
`libRF_CNative_ios.a` trong source oracle chính là mã máy đã được link vào `UnityFramework` của IPA: cả 34 entry
point `__Internal` mà `RFLib_DotNet_2018_ios` P/Invoke đều **trùng từng byte** với hàm cùng tên trong binary đã
ship, trừ đúng những word mà relocation của object file nói linker đã vá. Blocker cũ của 064 ("vendor phải cấp
lại") được thay bằng bằng chứng, và archive được giữ lại vào project khôi phục kèm hồ sơ provenance.

Archive vẫn là **source-derived** theo nghĩa §12: nó đến từ repo `jelly-blast`, không phải từ IPA. Cái làm nó dùng
được không phải nguồn gốc của repo mà là phép so mã máy với binary của build — một bằng chứng độc lập với repo.

## 2. Danh tính file — PROVEN

| Trường | Giá trị |
|---|---|
| Đường dẫn | `Assets/RayFire/Plugins/Ios/libRF_CNative_ios.a` (`ThinhNV-x-Percas/jelly-blast`, nhánh `develop`) |
| Git blob | `9a3750356ff2ae9ff05b58a930144478aa8125a7` — khớp SHA brief nêu; file được lưu trực tiếp, không phải LFS pointer |
| SHA-256 | `5c20bbad4aaec07482f6673c01b19e672d963928eba7a0f09d53dbb759c0643a` |
| Commit đưa vào | `fe27775f` (2026-09-16, "add demo code") — derivation root của repo (063); không commit nào sửa nó sau đó |
| `.meta` | `PluginImporter`, chỉ bật iOS (`Exclude iOS: 0`, mọi platform khác bị exclude) |

## 3. Cấu trúc archive — MEASURED

Universal archive (`FAT_MAGIC`, 2 lát):

| Lát | CPU | Kích thước | Member | Tương thích với `UnityFramework` |
|---|---|---:|---:|---|
| 1 | `arm64` (`CPU_SUBTYPE_ARM64_ALL`) | 9 911 712 | 38 object | **có** — `UnityFramework` là thin arm64 |
| 2 | `armv7` | 9 558 624 | 38 object | không (build không có lát armv7) |

Các object không mang `LC_BUILD_VERSION` (toolchain cũ dùng load command min-version khác), nên phiên bản SDK của
archive **UNKNOWN** — không suy ra từ gì khác.

Cả 34 entry point được định nghĩa trong **một** member, `RFInterface.o`; 37 member còn lại là phần cài đặt
(`RFShatter.o`, `VoroCell.o`, `FastNoise.o`, …) mà `RFInterface.o` gọi tới.

## 4. Phép so mã máy — PROVEN

Với mỗi entry point (lấy từ `[DllImport("__Internal")]` của `RFLib_DotNet_2018_ios` trong bản rip):

1. tìm member định nghĩa symbol `_<entry>` (N_EXT, N_SECT) trong lát arm64;
2. hàm kết thúc ở symbol kế tiếp trong cùng section, hoặc cuối section;
3. đánh dấu mọi word mà một relocation của section phủ (`r_address`), vì đó là chỗ linker vá địa chỉ;
4. lấy đúng số byte đó tại symbol `_<entry>` trong `LC_SYMTAB` của `UnityFramework` (`cryptid 0`: binary đã giải
   mã, đọc được);
5. so từng word 4 byte, bỏ qua word bị relocation phủ.

| | |
|---|---:|
| Entry point | 34 |
| `BYTE_IDENTICAL` | **34** |
| Word được so (tổng) | 2 920 |
| Word bị relocation phủ (bỏ qua) | 221 |
| Word khác nhau | **0** |

**Đối chứng âm** (để chứng minh phép so phân biệt được): so mỗi hàm của archive với byte tại symbol của entry point
*kế tiếp*: 33/34 khác nhau; một cặp trùng (`getParamFloat` với `getParamInteger`, 6 word, cùng hình dạng accessor).
Phép so không phải là "luôn bằng".

## 5. Kiểm tra brief yêu cầu

| Yêu cầu §9 | Kết quả |
|---|---|
| Kiến trúc archive | arm64 + armv7; arm64 tương thích |
| Danh sách member | 38 object mỗi lát |
| Bảng symbol | 34/34 entry point được định nghĩa (`RFInterface.o`) |
| 34 symbol RayFire | 34/34 có trong archive **và** 34/34 trong `LC_SYMTAB` của `UnityFramework` (064) |
| P/Invoke entry point | 34 trong `RFLib_DotNet_2018_ios`, mỗi cái một `static extern` |
| Kiểm chứng nguồn gốc | mã máy trùng byte (mục 4) — mạnh hơn "định nghĩa đủ symbol" |

## 6. Giữ lại vào project — đã làm, có điều kiện

`static_library_provenance.py --preserve <game>` chép archive và `.meta` của nó vào
`Assets/Plugins/iOS/libRF_CNative_ios.a` của project khôi phục, cùng `libRF_CNative_ios.a.provenance.json` (toàn bộ
báo cáo mục 4) — **chỉ khi** verdict là `LINKED_ARCHIVE_PROVEN`. Không có đường nào đặt một archive vào project
theo tên, theo symbol hay theo chuỗi version. Đã chạy trên `Test/Out65c-i/JellyBlastV2`.

Đây vẫn là bước tách khỏi ripper: ripper chỉ nhận IPA, và archive không nằm trong IPA. Bước giữ lại nhận một
nguồn thứ hai *có kiểm chứng*, đúng như kiến trúc "tách acquisition khỏi parsing" ghi ở CLAUDE.md.

## 7. Còn lại

- Lát armv7 không được kiểm (build không có armv7 để so) — UNKNOWN cho lát đó, vô hại vì không target nào cần.
- `libRFUtils_ios.a` (cũng trong repo) định nghĩa 0 entry point được P/Invoke — không cần, không giữ.

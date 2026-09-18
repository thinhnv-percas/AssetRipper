# Native plugin của iOS — `.framework` và cách giữ nó

Iteration 056, §9 và §10. Iteration 055 báo `native_plugin_preservation_rate` **0 / 6** trên fixture
iOS và ghi lý do là "layout `.framework` của iOS", không làm gì thêm. Đây là phần làm.

## Giả thuyết

`NativePluginPostExporter` của 055 chỉ liệt kê `*.so`. Một gói `.ipa` không có file nào như thế, nên
vòng lặp chạy không lần nào và bản export không mang thư viện native nào cả — cùng một dạng "một pass
không bao giờ chạy trông hệt như một pass không tìm thấy gì" đã ghi nhiều lần trong `CLAUDE.md`.

## Bằng chứng

`Payload/JellyBlast.app/Frameworks/` có 25 mục:

| | số | đọc từ |
|---|---|---|
| `GAME_NATIVE_PLUGIN` | 6 | `FBAEMKit`, `FBSDKCoreKit`, `FBSDKCoreKit_Basics`, `FBSDKGamingServicesKit`, `FBSDKLoginKit`, `FBSDKShareKit` |
| `UNITY_ENGINE` | 1 | `UnityFramework.framework`, 51 MB |
| `SYSTEM_LIBRARY` | 18 | `libswift*.dylib` — runtime Swift, Apple cung cấp |

`UnityFramework` mang **cả** player lẫn il2cpp: Unity 2019.3 chuyển player vào một framework nhúng,
điều `CLAUDE.md` đã ghi từ iteration 032. Nó là một mục dưới engine chứ không phải hai, và engine là
thứ gọi tên nó.

Kiến trúc: cả 25 file đều là Mach-O 64-bit little-endian với `cputype` `0x0100000C`, tức
`CPU_TYPE_ARM64`. Không file nào là fat binary.

## Triển khai

Hai nền tảng đóng gói plugin khác nhau **và Unity import chúng khác nhau**, nên chúng được xử lý bằng
hai nhánh chứ không bằng một luật chung:

| | Android | iOS |
|---|---|---|
| đơn vị | một file `.so` | một bundle `.framework` (thư mục) |
| kiến trúc nằm ở | thư mục ABI trên đường dẫn | chỉ trong header Mach-O |
| đích | `Assets/Plugins/Android/<abi>/` | `Assets/Plugins/iOS/<name>.framework/` |

Bundle được chép **nguyên vẹn** — binary, `Info.plist`, headers, module map, resource bundle — vì đó
là thứ Unity nhận ra là plugin; chép mỗi binary thì Unity không nhận ra gì. Chỉ `_CodeSignature` bị bỏ
lại, vì nó ký cho app đã được ký chứ không cho project.

Kiến trúc đọc từ Mach-O (`MachOArchitecture`), không viết sẵn. Viết `arm64` vào code sẽ là đúng lỗi
"một pass gọi tên offset phải đọc nó từ bảng" đặt ở chỗ khác: một bản build cho simulator, hay một bản
cũ còn `armv7`, sẽ bị ghi sai và không gì phía sau nhận ra được. Hàm đọc cả thin lẫn fat, và một
`cputype` không nhận ra được báo bằng chính con số của nó (`cpu_<n>`) chứ không bằng một phỏng đoán.

`NativeLibraryClassifier` tách khỏi exporter và `runtime_dependency_graph.py` phân loại bằng cùng một
luật, vì **một phép đo phân loại khác với thứ nó đo thì báo ra một tỉ lệ không ai hành động được.**

## Kết quả

| fixture | game plugin | preserved trước | preserved sau |
|---|---|---|---|
| Impostor | 0 | — | — |
| RunFromZombies | 0 | — | — |
| Merge-Room | 2 | 2 / 2 | 2 / 2 |
| JellyBlast v2 | 6 | **0 / 6** | **6 / 6** |

## Giới hạn còn lại

- Unity nhận diện plugin iOS qua một `.meta` của plugin importer với `PluginImporter` settings
  (platform, CPU, `AddToEmbeddedBinaries`). Bản export **chưa sinh** `.meta` cho framework, nên Unity
  sẽ import nó với thiết lập mặc định. Đây là một bước còn thiếu, không phải một bước đã làm sai.
- `required_by_symbols` cho các framework này là rỗng: nối một symbol với thư viện khai báo nó cần
  bảng export của chính thư viện, mà bản rip không đọc. Một thư viện không managed code nào chạm tới
  vẫn được báo với `required_by` rỗng chứ không bị bỏ, vì một plugin có thể được gọi từ native hoặc
  từ thiết lập importer mà phép đo này không thấy.
- Gói này là bản tải từ App Store, nên `__TEXT` của mọi binary trong đó bị FairPlay mã hoá. Việc giữ
  file không đổi điều đó: framework được mang sang nguyên trạng, kể cả phần bị mã hoá.

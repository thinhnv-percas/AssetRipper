# NativeDependencyGraph — iteration 064

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Công cụ: `Test/Scripts/native_dependency_graph.py`
(`--self-test` 5/5). Nguyên liệu: `iterations/064/native/<fixture>.json`.

## 1. Cái báo cáo cũ không thấy được

`runtime_dependency_graph.py` (054–056) hỏi "project có mang thư viện package ship không". Một thư viện
**không ship thành file** thì nó không thấy: trên iOS một static library (`.a`) được link vào
`UnityFramework` lúc build. Package không có gì để copy, và báo cáo cũ đọc phụ thuộc đó là *vắng* thay vì
*đã link*. Graph mới thêm ba nguồn bằng chứng và không bao giờ tạo file:

1. P/Invoke của script phục hồi — `[DllImport("__Internal")]` trên Apple (063 khôi phục import map), tên thư
   viện ở nơi khác: assembly managed nào cần entry point nào.
2. Bảng symbol (`LC_SYMTAB`) của binary mà entry point phải resolve trong đó (`UnityFramework`): entry point có
   ở đó là đã link vào nó — điều đó *chứng minh* static library chứ không giả định.
3. Tuỳ chọn, plugin trong source (`--source`): một `.a` mà bảng symbol của archive (kể cả archive universal)
   định nghĩa các entry point đó là thư viện chúng đến từ. Đó là nơi duy nhất *tên* của static library tồn tại.
   So khớp có NUL hai đầu: `New`, `Delete` là entry point thật của RayFire và là hậu tố của hàng nghìn tên khác.

## 2. Kind và recoverability

| Kind | Ý nghĩa | Recoverability |
|---|---|---|
| `IL2CPP_RUNTIME`, `UNITY_ENGINE`, `ENGINE_BUILD_OUTPUT`, `SYSTEM_LIBRARY` | không phải của project | `NOT_REQUIRED` |
| `GAME_NATIVE_PLUGIN` | `.so`/`.dylib` game ship | `PRESERVED` / `MISSING` |
| `FRAMEWORK` | bundle iOS game ship | `PRESERVED` / `MISSING` |
| `STATIC_LIBRARY` | link vào binary engine | **`LINKED_STATIC_NOT_EXTRACTABLE`** |
| `UNKNOWN` | bằng chứng không quyết định | `UNKNOWN` |

## 3. Kết quả — MEASURED

| Fixture | Game plugin / framework | Static | UNKNOWN | Ghi chú |
|---|---|---|---|---|
| Impostor | 0 | 0 | 0 | 2 il2cpp + 4 player |
| Merge-Room | `liblofelt_sdk.so` ×2 ABI, PRESERVED | 0 | 0 | 2 `lib_burst_generated` NOT_REQUIRED |
| RunFromZombies | 0 | 0 | 0 | |
| Pinata | 6 `.so` (Firebase ×2, Oni, easymobile, swappy ×2), PRESERVED | 0 | 0 | |
| JellyBlastV2 | 6 Facebook framework, PRESERVED | **1** | 3 | |

### JellyBlast — PROVEN / UNKNOWN

- **6 framework Facebook** (`FBAEMKit`, `FBSDKCoreKit`, `FBSDKCoreKit_Basics`, `FBSDKGamingServicesKit`,
  `FBSDKLoginKit`, `FBSDKShareKit`): bundle nguyên vẹn (binary, Info.plist, header, resource, bỏ
  `_CodeSignature`), kiến trúc đọc từ header Mach-O. PRESERVED.
- **RayFire: `STATIC_LIBRARY`, `LINKED_STATIC_NOT_EXTRACTABLE`.** `RFLib_DotNet_2018_ios` khai báo 34
  `__Internal` entry point; **34/34** là symbol của `UnityFramework` (bảng symbol còn mang cả C++ symbol
  `RayFire::RFMesh…`); trong source, `Assets/RayFire/Plugins/Ios/libRF_CNative_ios.a` định nghĩa **34/34**,
  `libRFUtils_ios.a` định nghĩa 0. Không có file nào để trích — code đã thành một phần của engine binary.
  Project phục hồi cần vendor cung cấp lại `libRF_CNative_ios.a`.
- **Facebook.Unity.IOS (39), GameAnalyticsSDK (53), Assembly-CSharp Taptic (4): UNKNOWN.** 0 entry point có
  trong bảng symbol (`UnityFramework` chỉ còn 3213 symbol — đã strip). Chúng *có thể* được link tĩnh từ `.mm`
  trong `Plugins/iOS`, nhưng bằng chứng ở đây không nói được; ghi UNKNOWN, không suy.

## 4. Giới hạn

- Android: một `DllImport("foo")` resolve theo tên file; graph ghép theo tiền tố `lib<foo>`. Không fixture
  Android nào ở đây có `DllImport` không phải `__Internal` tới thư viện game.
- Graph không đọc dependency *giữa* các thư viện native (`DT_NEEDED`, `LC_LOAD_DYLIB`) — chưa cần cho câu hỏi
  "project thiếu gì".

# iOS native `__Internal` UNKNOWN — iteration 065 (§11)

Nhãn: **PROVEN**, **LINKED**, **UNKNOWN**. Công cụ: `Test/Scripts/ios_native_unknown.py` (`--self-test` 3/3).
Nguyên liệu: `iterations/065/native/jellyblast-ios-internal-bindings.json`.

## 1. Câu hỏi và lý do 064 dừng ở UNKNOWN

Ba nhóm `[DllImport("__Internal")]` của JellyBlastV2 (Facebook.Unity.IOS 39, GameAnalyticsSDK 53, Taptic trong
Assembly-CSharp 4) có **0** entry point trong `LC_SYMTAB` của `UnityFramework`: symbol C đã bị strip khi build App
Store. 064 dừng ở đó vì bảng symbol là bằng chứng duy nhất nó đọc.

## 2. Bằng chứng không bị strip

Trên iOS, `__Internal` được linker resolve, nên phần cài đặt nằm trong `UnityFramework`; strip chỉ xoá *tên*. Mối
liên kết vẫn nằm trong mã:

1. **Wrapper → địa chỉ cài đặt.** il2cpp biên dịch mỗi `static extern` thành một wrapper marshal đối số rồi gọi
   thẳng phần cài đặt (`[NativeSource]` của wrapper: `marshal_string → call 0x24108 → free`). Call tới helper
   marshal xuất hiện ở nhiều wrapper; call tới phần cài đặt xuất hiện ở đúng một. Wrapper có đúng một target duy
   nhất ⇒ đó là phần cài đặt.
2. **Ranh giới hàm** từ `LC_FUNCTION_STARTS` (179 500 hàm), vốn không bị strip. Target phải là một điểm bắt đầu hàm
   trong `__text`, nằm ngoài section `il2cpp` của mã sinh.
3. **Hàm tham chiếu gì** (giải mã từng lệnh A64 trong hàm):
   - selector Objective-C qua `__objc_stubs` (`bl` tới một stub `adrp/ldr x1, selref`) hoặc qua `__objc_selrefs`;
   - class qua `__objc_classrefs`: class từ framework được **bind opcode của dyld** (`LC_DYLD_INFO_ONLY`) ghi kèm
     dylib ordinal ⇒ tên framework; class định nghĩa trong binary được đọc tên qua `class_t → class_ro_t`;
   - chuỗi C qua `__cstring`/`__cfstring`; import qua `__stubs` và bảng indirect symbol.

**Đối chứng:** RayFire giữ symbol, nên quy tắc 1 kiểm được trên nó: **35/35** wrapper RayFire trỏ đúng tới symbol
`_<entry point>` của chính nó. Quy tắc không trả lời nhầm hàm.

## 3. Kết quả

| Nhóm | Entry point | PROVEN | UNKNOWN | Tham chiếu ra (class, theo nơi định nghĩa) |
|---|---:|---:|---:|---|
| Assembly-CSharp (Taptic) | 4 | **4** | 0 | `UnityTapticPlugin` (trong binary); selector `shared`, `notification:`, `selection`, `impact:` |
| Facebook.Unity.IOS | 39 | **38** | 1 | `FBUnityInterface`/`FBUnityUtility`/`FBUnitySDKDelegate` (trong binary); `FBSDKAppEvents`, `FBSDKSettings`, `FBSDKProfile`, `FBSDKAccessToken`, … bind từ `@rpath/FBSDKCoreKit.framework` (19 tham chiếu); `FBSDKContextDialogPresenter`, `FBSDKGamingImageUploader`, … từ `@rpath/FBSDKGamingServicesKit.framework` (12) |
| GameAnalyticsSDK | 53 | **50** | 3 | `GameAnalytics`, `GARemoteConfigsUnityDelegate` (**trong binary**); Foundation |

Ví dụ (PROVEN): `IOSFBInit` → `0x21184`, tham chiếu `FBSDKSettings` và `FBSDKAppEvents` từ FBSDKCoreKit cùng
`FBUnityInterface` trong binary; `gaInitialize` → `0x24640`, gửi `initializeWithGameKey:gameSecret:` tới
`GameAnalytics`; `_unityTapticImpact` → `0x1e1ac`, gửi `impact:` tới `[UnityTapticPlugin shared]`.

## 4. Từng nhóm nghĩa là gì

- **Facebook — PROVEN, đã có đủ trong project.** Phần cài đặt là cầu nối Objective-C của Facebook Unity SDK
  (`FBUnityInterface.mm`…) được biên dịch vào `UnityFramework`; nó gọi vào các framework `FBSDK*` mà project khôi phục
  **đã giữ** (064: 6 framework PRESERVED). Cái còn thiếu là source của cầu nối (`.mm`), vốn là một phần của plugin
  Facebook Unity SDK, không phải binary riêng.
- **GameAnalytics — PROVEN, link tĩnh.** Không có framework GameAnalytics nào trong `LC_LOAD_DYLIB`; class
  `GameAnalytics` được định nghĩa ngay trong `UnityFramework`. Thư viện iOS của GameAnalytics được link tĩnh, giống
  RayFire. Khác RayFire ở chỗ source oracle không có archive nào của nó để so mã máy: **có mặt — PROVEN; file để giữ
  lại — UNKNOWN**.
- **Taptic — PROVEN, link tĩnh.** `UnityTapticPlugin` định nghĩa trong binary. Source oracle chỉ có `TapticManager.cs`,
  không có phần native: file native **UNKNOWN**.

## 5. Bốn UNKNOWN còn lại — vì sao

- `GameAnalyticsSDK.setEventSubmission` (2 overload) dùng chung một phần cài đặt, nên target của mỗi wrapper không
  còn duy nhất. Quy tắc "một wrapper ↔ một target" từ chối thay vì chọn bừa. Đúng thiết kế.
- `IOSFBSetDataProcessingOptions` và `GameAnalyticsRequestTrackingAuthorization`: không wrapper call nào duy nhất
  (wrapper marshal mảng / callback, có nhiều call). Vẫn UNKNOWN.

## 6. Phân loại §12

Cả ba nhóm là **INDEPENDENT**: bằng chứng đến từ chính binary của IPA (mã wrapper, function starts, bind opcode,
metadata ObjC), không từ repo source.

# SandOut — project Unity phục hồi bằng AssetRipper (IL2CPP, iOS) — bản v3 (checkpoint)

Nguồn: `com.uncosoft.sandout_0.2.5_und3fined.ipa` (Unity **6000.0.72f1**, metadata v31.1, ARM64). Xuất bằng nhánh
`claude/sandout-ipa-decompile` của repo này (commit `8d01edde6`), rồi hậu xử lý như mô tả dưới đây.

## Vì sao bản trước crash khi Play

Bản trước (`ecfce60af`) đưa **mọi** assembly vào `Assets/Plugins` dưới dạng DLL phục hồi từ mã máy — kể cả
`Unity.Entities`, `Unity.Collections`, `Unity.Burst`, `Unity.InputSystem`… Các package này có hook
`[RuntimeInitializeOnLoadMethod]` chạy ở **mọi scene** khi bấm Play (Entities tạo World, Collections cấp phát bộ nhớ
native…). Thân method của chúng là IL phục hồi gần đúng, nên con trỏ/kích thước sai đi thẳng vào code native của Unity
→ Editor crash mà Console không kịp ghi gì. Đó là lý do "không có lỗi đỏ nhưng Play scene nào cũng crash".

Ngoài ra tool còn sinh `get { return Progress; }` bên trong chính getter `Progress` (đệ quy vô hạn → stack overflow, cũng
làm Editor crash). Lỗi này đã được sửa trong tool.

## Bản này khác gì

| | bản trước | bản này |
|---|---|---|
| Package Unity (Entities 1.4.6, Entities.Graphics 1.4.19, Collections 2.6.6, Mathematics 1.3.2, Serialization 3.1.3, InputSystem 1.19.0, Splines 2.8.4, Burst, URP 17.0.4, uGUI 2.0.0) | DLL phục hồi | **package thật từ registry**, phiên bản được xác định bằng cách đối chiếu khai báo của build với từng phiên bản |
| PrimeTween | DLL phục hồi (325/504 thân hỏng) | package **1.3.3** từ npm (khớp đúng), scoped registry trong `manifest.json` |
| Newtonsoft.Json | DLL phục hồi (989/2323 thân hỏng) | `com.unity.nuget.newtonsoft-json` 3.2.2 |
| Gameplay (`Assembly-CSharp`) | DLL | **C# nguồn** trong `Assets/Scripts/Assembly-CSharp` |
| Framework của studio (Unco.*, ContainerSystem/Reflex, Database, SoundSystem, UiFactory, TimeTaskSystem…) và thư viện bên thứ ba trả phí (HighlightPlus, EnhancedScroller, AllIn1, TCP2…) | DLL | **C# nguồn**, mỗi assembly một asmdef |
| SDK quảng cáo / IAP / tracking / social (Facebook, Firebase, AppLovin MAX, Adjust, Elephant, Unity Purchasing, Unity Services, SRDebugger…) | DLL | DLL **chỉ còn khai báo**: mọi thân method trả giá trị mặc định, không chạy gì |
| Burst trên code phục hồi | có | bỏ `[BurstCompile]` trong code phục hồi (Burst từ chối thân có lời gọi managed; job vẫn chạy đúng dạng managed) |

Đã kiểm bằng MiniUnity (giả lập trình biên dịch và player loop của Unity trên .NET — môi trường này không có Unity
Editor thật):

- Compile toàn bộ project như Unity (asmdef, package, source generator của Entities): **0 lỗi**.
- `IntroScene`: `GameBootstrapper.Awake` chạy, rồi ném `InvalidCastException` ở `GameBootstrapper.Initialize` — lỗi
  logic phục hồi đầu tiên trên đường khởi động, đang được sửa (xem dưới).
- `Main`, `elephant_scene`: 0 exception.

## Điều bản này CHƯA làm được — đọc kỹ

- **Game chưa chơi được.** Mã gameplay được phục hồi từ mã máy ARM64 và có hai loại lỗi:
  1. **3774 thân method không compile được đã được thay bằng stub** (`RecoveryStub.Missing("…")`: ghi một warning
     `[Recovery] body not recovered yet: …` ở lần gọi đầu, rồi trả giá trị mặc định). Danh sách đầy đủ, kèm lỗi compile
     khiến mỗi method bị stub: `RecoveryStubs.json`. Trong đó 1674 ở `_game/CoreSystem` (vật lý cát, mold, lưới…),
     407 ở `_game/CoreGameKit`.
  2. Nhiều thân **compile được nhưng sai**: một giá trị đọc từ bộ nhớ không phục hồi được trở thành `0`/`null`
     (`Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: …")` đánh dấu chỗ đó), một phép toán vector ARM64 bị
     mất thành phần. Không có lỗi compile nào báo các chỗ này.
- Mỗi method có attribute `[NativeSource(Body = "…")]` chứa bản dựng lại từ mã máy (dạng giả C#) — đó là nguồn để sửa
  tay. Thân rất dài bị cắt cuối (`// ... truncated`).
- Đang sửa tiếp theo thứ tự: đường khởi động (GameBootstrapper → container → SceneFlow → Intro → Main), rồi hệ thống
  ECS vật lý cát và mold, rồi lưới/cơ chế, rồi UI. SDK quảng cáo/IAP/tracking cố ý không sửa.
- Shader vẫn là bản thay thế (cấu trúc ShaderLab và `Properties` đúng, chương trình không phải bản gốc).
- `RuntimeSafeBodies.json`: các thân bị thay trong những DLL còn lại (SDK đã stub, Sirenix/Odin, Spine).

## Mở project

Unity **6000.0.72f1**. Mở thư mục này làm project; Unity tải package theo `Packages/manifest.json` (cần mạng; PrimeTween
lấy từ `registry.npmjs.org` qua scoped registry đã khai báo). Khi Play sẽ thấy các warning `[Recovery] body not
recovered yet: …` — mỗi dòng là một method đang là stub.

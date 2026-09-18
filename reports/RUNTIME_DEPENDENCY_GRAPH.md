# Đồ thị phụ thuộc runtime — thư viện native nào project phải mang

Iteration 055, §8 và §9. Iteration 054 báo cả bốn project có **0 native plugin** trong khi package
có thư viện native, và gọi đó là blocker runtime mà không nói thư viện nào và ai cần nó.
`Test/Scripts/runtime_dependency_graph.py` trả lời cả hai, và câu trả lời đúng khác với 054.

## Phân loại, vì bốn loại cần bốn cách xử lý trái ngược

| loại | xử lý |
|---|---|
| `IL2CPP_RUNTIME` | `libil2cpp.so` / `UnityFramework` — recovery **thay thế** nó, nên project **không được** mang. Copy vào là ship game hai lần. |
| `UNITY_ENGINE` | `libunity.so`, `libmain.so` — player của Unity, editor cung cấp. |
| `ENGINE_BUILD_OUTPUT` | `lib_burst_generated.so` — Burst biên dịch từ chính managed source lúc build, nên project sinh lại. |
| `SYSTEM_LIBRARY` | thư viện của nền tảng, thiết bị đã có. |
| `GAME_NATIVE_PLUGIN` | thứ developer thêm vào. **Chỉ loại này** project phải mang, và chỉ sự thiếu của nó là blocker. |

## Kết quả

| | thư viện trong package | game native plugin | preserved |
|---|---|---|---|
| Impostor | 6 | **0** | — |
| RunFromZombies | 6 | **0** | — |
| Merge-Room | 10 | **2** (`liblofelt_sdk.so`, hai ABI) | 2 / 2 |
| JellyBlast v2 | 25 | **6** (Facebook SDK framework) | 0 / 6 |

**Kết luận của 054 sai với một nửa ma trận**: Impostor và RunFromZombies không có plugin nào của
game cả — 6 thư viện của chúng là đúng hai bản il2cpp runtime và bốn bản Unity player, không thứ nào
được phép đi vào project. Không có blocker nào ở đó để sửa.

Merge-Room thì có thật: `Lofelt.NiceVibrations` là một assembly được recover mà việc duy nhất của nó
là P/Invoke vào `liblofelt_sdk.so`, và không có thư viện ấy thì mọi lời gọi vào nó hỏng ngay khi
chạy. `NativePluginPostExporter` giờ copy nó vào `Assets/Plugins/Android/<ABI>/`.

JellyBlast v2 cần sáu framework Facebook SDK. Chưa preserve: một `.framework` của iOS là một thư mục
có `Info.plist`, headers và module map, và Unity nhập nó theo cách khác một `.so`; copy sai layout
thì tệ hơn là không copy. Đây là mục tiêu tiếp theo và được ghi là **MISSING** chứ không phải bỏ qua.

## P/Invoke (§10)

Không sinh `[DllImport]` nào. `NativeBoundary` khai báo `P_INVOKE` và **cố ý không bao giờ sinh ra
nó**: không có gì tại một call site phân biệt đích của một P/Invoke với bất kỳ symbol import nào
khác, và một verdict không chứng minh được thì tệ hơn một verdict vắng mặt. Tên thư viện cũng không
được đoán. Nơi bằng chứng chưa đủ, ranh giới vẫn là `IL2CPP_RUNTIME`, `SYSTEM_API`,
`EXTERNAL_DEPENDENCY` hoặc `UNKNOWN` — xem `reports/regression-matrix.md`.

Đồ thị chỉ nối tới mức bằng chứng cho phép: 31 symbol native mà script của Merge-Room gọi tên được
ghi lại, nhưng symbol nào thuộc thư viện nào thì không đọc được mà không có bảng export, nên
`required_by_symbols` để trống thay vì đoán. Một thư viện không managed code nào với tới cũng được
báo kèm `required_by` rỗng chứ không bị bỏ, vì một plugin có thể được gọi từ native hoặc qua thiết
lập plugin importer mà chỗ này không thấy.

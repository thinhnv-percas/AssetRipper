# SandOut — project Unity phục hồi bằng AssetRipper (IL2CPP, iOS)

Nguồn: `com.uncosoft.sandout_0.2.5_und3fined.ipa` (Unity **6000.0.72f1**, metadata v31.1, ARM64). Xuất bằng nhánh
`claude/sandout-ipa-decompile` của repo này, commit `0981f4e39`:

```
AssetRipper.Tools.SystemTester --script-level 3 --reconstruct-bodies --struct-db StructDb \
  --script-mode DllExportWithRenaming --runtime-safe-bodies --unity-editor <Unity 6000.0.72f1>/Editor \
  --output <out> <thư mục IPA đã giải nén>
```

Báo cáo đầy đủ: `reports/SANDOUT_IPA.md` (§6–7) trên nhánh đó.

## Đã kiểm gì, và kết quả

Kiểm bằng MiniUnity (giả lập player loop của Unity trên .NET, bản vá cục bộ ghi ở `iterations/sandout/miniunity/`),
không phải bằng Unity Editor thật — môi trường không có Editor.

| bước | kết quả |
|---|---|
| Compile như Unity (asmdef, package, plugin) | **0 lỗi**, 36/36 assembly |
| `Assets/Elephant/elephant_scene.unity`, 30 s (1800 frame) | 0 lỗi, 0 warning, 0 exception; script Elephant chạy Awake/Start/Update/LateUpdate mỗi frame |
| `Assets/Scenes/IntroScene.unity`, 30 s | 0 lỗi, 0 warning, 0 exception; `GameBootstrapper.Awake` của game chạy hết |
| `Assets/Scenes/Main.unity`, 30 s | 0 lỗi, 0 warning, 0 exception; scene không chứa MonoBehaviour nào của game |

## Những gì "không lỗi" ở đây KHÔNG có nghĩa

- **Đây không phải game chơi được như bản gốc.** Script của game nằm trong `Assets/Plugins/*.dll` (IL phục hồi từ mã máy
  ARM64), không phải C# nguồn. **14841 trên 65104 thân method (23%)** bị thay bằng thân tối thiểu (không làm gì, trả giá
  trị mặc định) vì ILVerify thấy chúng không an toàn để chạy — chạy chúng thì JIT từ chối hoặc crash. Danh sách từng method
  và lý do: `RuntimeSafeBodies.json`. Riêng Assembly-CSharp: 3290 / 9958.
- **Gameplay của SandOut là ECS (Unity.Entities)**, mà MiniUnity không chạy; MiniUnity cũng không chuyển scene, nên luồng
  IntroScene → Main của bootstrapper chưa từng được thử. Ảnh chụp ở giây 29 là màn hình trống.
- Shader là bản thay thế (cấu trúc ShaderLab đúng, chương trình không phải bản gốc); các chương trình Metal gốc nằm trong
  output của AssetRipper (`AuxiliaryFiles/ShaderPrograms`), không trong project này.
- Chưa mở bằng Unity Editor thật. Các package `com.unity.*` được lấy theo `Packages/manifest.json`.

## Mở project

Unity **6000.0.72f1**. Mở thư mục này làm project; Unity tự tải package trong `Packages/manifest.json`.

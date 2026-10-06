# Tuỳ chọn "Emit Cpp2ILInjected Attributes" — iteration 067 (§12, §14)

Nhãn: **PROVEN**, **MEASURED**.

## 1. Policy nằm ở đâu

Mọi attribute `Cpp2ILInjected.*` đều do một layer phát ra: `AttributeInjectorProcessingLayer`. Layer đó gồm:
- `[Token]`, `[Address]`, `[FieldOffset]`;
- `[Attribute]` cho custom attribute metadata không biểu diễn được;
- các kiểu attribute tương ứng, được inject vào mọi assembly.

Vì thế "tắt" nghĩa là **không cài layer**: không có gì được sinh ra rồi bị xoá. Không có `string.Replace` hay regex
trên văn bản C#.

| | |
|---|---|
| Policy | `RecoveredCodeOutputOptions.EmitCpp2ILInjectedAttributes` (mặc định `true`) |
| Nơi quyết định duy nhất | `Il2CppRecoverySetup.Cpp2ILInjectedAttributeLayers(output)` |
| Lưu trữ | `ImportSettings.EmitIl2CppOffsets` — giữ tên cũ để settings đã lưu vẫn nạp được |
| GUI | checkbox "Emit Cpp2ILInjected attributes" trong mục IL2Cpp Script Recovery (`SettingsPage.g.cs` sinh lại bằng `AssetRipper.GUI.SourceGenerator`) |
| CLI | `--no-cpp2il-injected-attributes` (bí danh của `--no-emit-offsets` có sẵn) |

Hai layer khác của Cpp2IL cũng inject vào `Cpp2ILInjected`: `CallAnalysisProcessingLayer` và
`NativeMethodDetectionProcessingLayer`. AssetRipper không cài cái nào, và một test giữ nguyên điều đó.

Các kiểu helper không phải attribute ở lại:
- `Cpp2ILInjected.Il2CppRuntime` và `Cpp2ILHelpers`: thân phục hồi gọi chúng, nên bỏ đi sẽ làm thân không compile.
- `AssetRipperInjected.NativeSource`: là `--reconstruct-bodies`, một tuỳ chọn riêng.

## 2. Đo — RunFromZombies, cùng một bản build

| | mặc định (67a) | tắt (67n) |
|---|---:|---:|
| `[Address(`/`[Token(`/`[FieldOffset(`/`[Attribute(` | 23360 | **0** |
| File kiểu attribute trong `Cpp2ILInjected/` | 45 | **0** |
| `[SerializeField]` | 209 | 209 |
| `[Tooltip(`/`[Header(`/`[Range(`/`[AddComponentMenu(`/`[RequireComponent(` | 248 | 248 |
| `[NativeSource(` | 3928 | 3928 |
| File `.cs` | 796 | 751 |

Attribute của chính game không đổi một cái nào. Log ghi `Cpp2ILInjected attributes off`.

## 3. Test (`Il2CppOutputOptionsTests`)

- Mặc định: layer phát attribute được cài đúng một lần.
- Tắt: không có layer phát attribute nào.
- Bật hay tắt: `AttributeAnalysisProcessingLayer`, layer khôi phục attribute của game, luôn được cài.
- Không có layer nào khác inject `Cpp2ILInjected` được cài.
- `FullConfiguration.RecoveredCodeOutput` đọc đúng setting đã lưu.

## 4. Lưu ý đo đạc

`recovery_metrics.py`, golden corpus và source oracle ghép method theo `[Address(RVA=…)]`. Một bản rip tắt tuỳ chọn
này **không đo được** bằng các script đó. Đó là lý do mặc định là `true`, và mọi số trong ma trận 067 là ở chế độ
mặc định.

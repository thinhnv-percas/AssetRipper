# Tuỳ chọn "Simplify global:: Qualification" — iteration 067 (§13, §14)

Nhãn: **PROVEN**, **MEASURED**.

## 1. Đã có gì trước 067

AssetRipper upstream đã có `ExportSettings.ScriptTypesFullyQualified` (mặc định tắt), đặt `AlwaysUseGlobal` của
ILSpy. Ở mặc định, ILSpy chỉ viết `global::` khi lookup tên đơn của chính nó không ra đúng kiểu. Phần còn lại là
hai thứ khác hẳn nhau:
- **Va chạm thật.** Trong `namespace Spine.Collections`, `Unity.IL2CPP…` sẽ resolve thành `Spine.Unity.IL2CPP…`, nên
  `global::` là bắt buộc.
- **Tên ILSpy không tra được.** Ví dụ kiểu compiler sinh ở namespace gốc, `global::_003CPrivateImplementationDetails_003E`.

## 2. Cách làm — phân giải tên, không phải sửa văn bản

`GlobalQualificationSimplifier` là một `IAstTransform` được thêm vào cuối pipeline của ILSpy
(`ScriptDecompiler.CustomWholeProjectDecompiler.CreateDecompiler`). Không có `Replace("global::", "")`.

`global::A.B` thành `A.B` chỉ khi:
1. `A` tồn tại ở namespace gốc, là namespace hoặc kiểu. Kiểu được nhận qua annotation `TypeResolveResult` của ILSpy,
   hoặc tên metadata sau khi bỏ escape (`_003C` → `<`).
2. Lookup tên đơn của C# từ chỗ đó tới được namespace gốc trước khi gặp một `A` khác. Nghĩa là không có:
   - namespace hay kiểu `N.A` với mọi namespace bao `N`;
   - alias hay extern alias tên `A`;
   - kiểu `A` import bởi một `using` đặt *bên trong* một khai báo namespace;
   - member, nested type hay type parameter tên `A` của kiểu bao hay các kiểu cơ sở của nó;
   - local, tham số, biến lambda/query hay type parameter tên `A` trong member bao.
3. Không xác định được kiểu bao thì giữ `global::`.

Tên namespace và kiểu được đọc từ `ICompilation` của chính decompiler, mọi module. Logic viết trên interface
`IGlobalNameScope` nên test không cần metadata.

| | |
|---|---|
| Policy | `RecoveredCodeOutputOptions.SimplifyGlobalQualification` (mặc định `true`) |
| Lưu trữ | `ExportSettings.SimplifyGlobalQualification` |
| Tương tác | `ScriptTypesFullyQualified = true` yêu cầu `global::` ở mọi nơi, nên tắt simplification thay vì chống lại nó |
| GUI | checkbox "Simplify global:: qualification" cạnh Script Export Mode |
| CLI | `--no-simplify-global` |

## 3. Test (`Il2CppOutputOptionsTests`, 13 case)

- `global::System.String` → `System.String`; `global::UnityEngine.Vector3` → `UnityEngine.Vector3`;
  `global::MyGame.Type` từ namespace khác → `MyGame.Type`; kiểu ở namespace gốc → bỏ `global::`.
- Giữ `global::` khi va chạm với: `class System` trong namespace bao, namespace `Spine.Unity`, member của kiểu bao,
  local, type parameter, alias; kiểu bao không xác định được; tên không tồn tại.
- Chỉ bỏ qualifier, không bỏ phần còn lại của tên.

Kiểm tra phân biệt: cho phép bỏ mọi qualifier có đích tồn tại thì 7 trên 18 test đỏ.

## 4. Đo

| `global::` trong export | 66i | 67 |
|---|---:|---:|
| Impostor | 18 | 18 (đều là `global::Unity.IL2CPP…` trong `Spine.*`: va chạm thật, giữ) |
| Merge-Room | 36 | **0** (đều là `_003CPrivateImplementationDetails_003E`) |
| RunFromZombies | 1 | **0** |
| JellyBlastV2 | 0 | 0 |

Lỗi thân Roslyn Merge-Room 66i → 67a (bản rip đầu tiên có simplification, cùng với cờ unsigned): 310 → 310. Không
có `global::` nào bị bỏ ở chỗ nó là bắt buộc.

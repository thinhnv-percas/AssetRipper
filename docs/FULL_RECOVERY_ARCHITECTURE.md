# Kiến trúc phục hồi đầy đủ

Iteration 044. Mỗi tầng ghi: đầu vào, đầu ra, bằng chứng, độ tin cậy, cách hỏng, và test đang có.
Trạng thái lấy từ `docs/RECOVERY_MATRIX.md`, đo trên fixture thật.

---

## Tầng 1 — Container

- **Vào**: thư mục APK đã giải nén, hoặc thư mục `Payload/*.app`.
- **Ra**: đường dẫn tới binary IL2CPP, `global-metadata.dat`, thư mục Data.
- **Bằng chứng**: có file.
- **Cách hỏng**: APK có *nhiều* ABI và không có gì nói vì sao một cái được chọn; iOS phải lấy
  `Frameworks/UnityFramework.framework/UnityFramework` chứ không phải launcher — nhầm thì lỗi hiện
  ra là "No codegen modules found for mscorlib", đọc như vấn đề metadata.
- **Test**: `LinuxGameStructureTests`, `MachOChainedFixupTests`.
- **Trạng thái**: PARTIAL — đường `.apk`/`.ipa` nén chưa đo.

## Tầng 2 — Nhận dạng build

- **Ra**: `UNITY_VERSION`, `IL2CPP_METADATA_VERSION`, `ARCH`, `PLATFORM`.
- **Bằng chứng**: đọc từ chính build, in ra log: `Unity 2022.3.62f2, metadata v31.1, 64-bit`.
- **Trạng thái**: OK.

## Tầng 3 — Serialized asset

- **Vào**: `data.unity3d`, `sharedassets*.resource`, `unity default resources`.
- **Ra**: Texture2D, Sprite, Material, AudioClip, Font, TextAsset, AnimationClip, GameObject…
- **Nguyên tắc**: serialized data là nguồn sự thật. Không dựng lại bằng heuristic khi dữ liệu còn.
- **Cách hỏng**: `ExportUnreadableAssets: False` bỏ qua asset không đọc được **mà không đếm** —
  một asset bị bỏ trông giống một asset không tồn tại.
- **Trạng thái**: OK cho các loại đã đo, UNKNOWN cho Mesh.

## Tầng 4 — Scene và tham chiếu

- **Ra**: `.unity`, `.prefab`, PPtr, `m_Script` GUID.
- **Bằng chứng**: 103 GameObject / 113 MonoBehaviour / 29 Transform trong scene duy nhất; 450 GUID
  duy nhất trên 450 `.cs.meta`, tức GUID theo từng script.
- **Cách hỏng**: 4 `m_Script` trỏ `fileID: 0`. Một tham chiếu hỏng phải có nguồn, đích, lý do, cách
  sửa và độ tin cậy — hiện **chưa có** báo cáo như vậy, đó là việc còn lại.
- **Trạng thái**: PARTIAL.

## Tầng 5 — Shader

- **Vào**: Shader asset trong bundle.
- **Ra**: `.shader` (Dummy) hoặc `.asset` YAML mang subprogram và blob (Yaml).
- **Bằng chứng**: `GpuProgramType` 4 và 5 = GLES3 và GLES; 12 subprogram, 31 blob trên một shader.
- **Cách hỏng, và đây là cách hỏng tệ nhất trong toàn bộ kiến trúc**: `Dummy` phục hồi đúng
  `Properties` rồi gắn cùng một pass unlit cho mọi shader. Nó **biên dịch được**, material
  **không hồng**, nên mọi phép kiểm tra dựa trên "có hồng không" đều báo PASS trong khi shading sai.
- **Trạng thái**: decompile NOT_AVAILABLE trong cây này; surface + blob PARTIAL.

## Tầng 6 — Metadata IL2CPP

- **Ra**: type, field, method, offset, registration.
- **Cách hỏng**: trên iOS store build, `__TEXT` mã hoá nên nửa sau pipeline dừng; phải báo tại input
  (`ENCRYPTED_NATIVE_INPUT`) chứ không vá tầng dưới để che.
- **Test**: `Il2CppStructDbTests`, `Il2CppRecoverySetupTests`.
- **Trạng thái**: OK (Android), PARTIAL (iOS).

## Tầng 7 — Native / IR

- **Ra**: ISIL → SSA trên CFG → ISIL đã phân tích.
- **Bằng chứng mới của iteration này**: `BasePointerOrigin` nói con trỏ base của mỗi lệnh đọc trỏ
  vào loại ô nhớ nào, và chỉ báo thứ IR nói thẳng ra.
- **Test**: `Il2CppBasePointerOriginTests`, `Il2CppLoadProvenanceTests`, `Il2CppScaledIndexTests`.
- **Trạng thái**: OK.

## Tầng 8 — Phục hồi managed

- **Ra**: CIL → C#.
- **Bằng chứng**: 819 file; **96,06%** method có thân thật theo `measure-bodies.py`, một oracle bên
  ngoài đo bản export IL2CPP thường được 0,00%.
- **Cách hỏng**: `generatorFailures` là dòng phải đọc trước mọi con số khác — một thân hàm ném ra
  khỏi generator không đóng góp placeholder nào và làm mọi metric khác đẹp lên.
- **Trạng thái**: OK, còn 2722 unresolved load.

## Tầng 9 — Tương thích

- **Phân loại cần có**: RECOVERED / AVAILABLE_FROM_UNITY / THIRD_PARTY_RECOVERED /
  THIRD_PARTY_STUB_REQUIRED / PLATFORM_ONLY / UNKNOWN.
- **Trạng thái**: **chưa có**. Hiện chỉ có `IsFrameworkAssembly` nhị phân, dùng cho việc nới quyền
  truy cập chứ không phải để phân loại khả năng phục hồi.

## Tầng 10 — Sinh project Unity

- **Ra**: `Assets/`, `ProjectSettings/`, `Packages/`, `.meta` cho mọi asset.
- **Trạng thái**: OK về cấu trúc; chưa kiểm chứng bằng Unity.

## Tầng 11–13 — Validation, Build, Runtime

- **Trạng thái**: **UNITY_NOT_AVAILABLE** trên máy này. Đã kiểm tra: không có `unity`,
  `unity-editor`, `/opt/Unity`, `~/Unity`.
- Những gì *vẫn* chạy được và đang chạy: trình biên dịch C# (Roslyn, `compile_recovered_scripts.sh`),
  kiểm tra hình dạng (`check_recovered_shapes.sh`), đối chiếu với nguồn
  (`audit_recovered_scripts.py`), và oracle độ sống thân hàm (`measure-bodies.py`).
- Không được ghi PASS cho build hay runtime khi chưa chạy.

---

## Thứ tự ưu tiên sửa (§15)

1. representation/model
2. tiêu thụ metadata
3. chuẩn hoá layout
4. type recovery
5. resolver
6. generator

Generator chỉ sửa khi đã chứng minh mọi tầng trước nó đúng.

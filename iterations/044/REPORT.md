# Iteration 044 — Báo cáo tổng kết

**Mục tiêu brief đặt ra:** từ một APK/IPA của game Unity IL2CPP, dựng lại một Unity project
**mở được / import được / build được / chạy được**. Đây là lần đầu mục tiêu dự án được phát biểu
như vậy; các iteration trước đo theo "giảm unresolved load".

**Phạm vi thực tế làm được trong iteration này:** phần core mà brief tự đặt tên (§11
`BasePointerOrigin`), và một khảo sát **đo được** trên toàn bộ 23 layer để biết mục tiêu mới còn
cách bao xa. Không patch pipeline phục hồi. Lý do ở mục Q.

Commit: `d930b2af`, `e473b4db`, `4dec5263`. Nhánh `claude/read-current-repository-daqxc1`.

---

## A. Baseline

Chạy trên `Test/Input/Impostor` (Unity 2022.3.62f2, metadata v31.1, ARM64), đối chiếu chéo
`Test/Input/Pinata` (v24.2, x86).

| Chỉ số | 043 | 044 |
|---|---|---|
| `generatorFailures` | 0 | **0** |
| File `.cs` xuất ra | 819 | 819 |
| Load bỏ cuộc | 2722 | 2722 |
| `method-not-found` | 2079 | 2079 |
| Roslyn Assembly-CSharp | 348 / 0 REFERENCE | 348 / 0 |
| Shape check | 16/16 | 16/16 |
| File `.cs` khác baseline | — | **0** |
| Test | 361 (1 fail có sẵn) | **372** (1 fail có sẵn) |

`generatorFailures = 0` đọc trước mọi con số khác, theo bài học iteration 037: một thay đổi làm 308
body ném ra ngoài generator sẽ làm mọi cột còn lại đẹp lên.

Output không đổi **một byte nào** so với 043 là chủ ý: iteration này chỉ thêm đo lường.

## B. Base-pointer provenance (§11 — ITERATION 044 CORE)

`Source/External/Cpp2IL.Core/Analysis/BasePointerOrigin.cs`. Iteration 042 kết luận khung toạ độ
của một offset thuộc về **con trỏ base**, không thuộc về kiểu; muốn dùng kết luận đó thì phải có
luật nói con trỏ base có được bằng cách nào. Đây là luật đó.

Mười ba hằng: `This`, `StackSlot`, `StaticField`, `InstanceField`, `ArrayElement`, `ReturnBuffer`,
`GenericContext`, `Parameter`, `Allocation`, `EntryValue`, `CallResult`, `LoadedPointer`, `Unknown`.
Ba nguyên tắc:

- Một local **là gì** mạnh hơn cái gì định nghĩa nó.
- `OffsetFromLocal` đi theo base: cộng một hằng không đổi chỗ lưu trữ.
- `LoadFromMemory` trả `LoadedPointer` chứ không trả nguồn gốc của địa chỉ đọc — con trỏ đọc lên
  trỏ vào cái đã được *ghi*, không trỏ vào chỗ nó được đọc ra.

Nhiều hơn một định nghĩa → `Unknown`. Giới hạn độ sâu 16.

Phân bố trên 2722 load:

```
809 UNKNOWN         548 RUNTIME_STRUCTURE   394 PARAMETER    329 LOADED_POINTER
160 ENTRY_VALUE     138 INSTANCE_FIELD      103 STATIC_FIELD  92 CALL_RESULT
 81 STACK_SLOT       60 THIS                  8 ALLOCATION
```

## C. Kết quả có giá trị nhất: bảng chéo nguồn gốc × khung toạ độ

Chỗ nguồn gốc **đã biết**, hai khung tách sạch, không một ngoại lệ:

| Khung | Nguồn gốc | Số ca |
|---|---|---|
| VALUE_RELATIVE | STATIC_FIELD | **43 / 43** |
| OBJECT_RELATIVE | PARAMETER | 14 |
| OBJECT_RELATIVE | CALL_RESULT | 7 |
| OBJECT_RELATIVE | THIS | 3 |
| OBJECT_RELATIVE | INSTANCE_FIELD | 1 |
| (còn lại) | UNKNOWN | 38 |

Tức `THIS / PARAMETER / CALL_RESULT / INSTANCE_FIELD → OBJECT_RELATIVE 25/25`.

Khớp với vật lý il2cpp: static storage giữ giá trị **inline, không header**; một struct đã box hoặc
nhận qua receiver **mang header**. Đây chính là câu trả lời mà iteration 041 đi tìm và không có bằng
chứng để trả lời, và là lý do iteration 041 từ chối cộng `+0x10` đại trà (77 ca sẽ hỏng để cứu 29).

**Và vẫn không patch.** Mẫu bị lệch: `CPP2IL_DUMP_LOADS` chỉ ghi những load **không** phân giải
được, nên 68 ca trên là mẫu của phần *thất bại*, không phải của chương trình. Một luật đúng trên
phần thất bại vẫn có thể sai trên phần đang chạy tốt. Phải đo lại trên cả load đã phân giải trước
khi biến nó thành luật trong `MetadataResolver`.

## D. Phục hồi IL2CPP

96,06% method của Assembly-CSharp có **thân thật** (đo bằng `measure-bodies.py` của
`clericall/il2cpp-wasm-teardown`, oracle ngoài, đếm `throw null;` là stub); 62,97% trên cả 819 file.
Tác giả oracle đó đo **0,00%** trên một bản export IL2CPP thông thường.

Còn lại: 2722 load bỏ cuộc, 2079 `method-not-found`, 348 lỗi Roslyn — tất cả đều là
`DECOMPILER_ERROR`, 0 `REFERENCE_ERROR` (tức không lỗi nào do bộ assembly đối chiếu).

## E. Phục hồi asset

36 Texture2D (36 PNG), 29 Sprite, 7 Material, 6 AudioClip, 4 TextAsset, 2 Font, 2 AnimationClip,
1 AnimatorController, 20 asset dưới `Resources`. `StreamingAssets`: không có trong APK này
(`NONE_PRESENT`, khác `NOT_RUN`). Mesh: **UNKNOWN** — không có thư mục Mesh trong bản rip và chưa
xác định được game có mesh hay không.

## F. Phục hồi scene và tham chiếu

1 scene, 103 GameObject, 113 MonoBehaviour, 29 Transform, 6 prefab.

GUID script: **450 GUID duy nhất trên 450 file `.cs.meta`** — đã là per-script. Tiền đề §9 của brief
("assembly-level synthetic GUID cần map thành per-script") là **sai với cây này**.

Tham chiếu gãy đo được: **4 `m_Script` trỏ `fileID: 0`**. Chưa có báo cáo dạng
source/target/reason/repair/confidence như §12 yêu cầu — ghi là thiếu, không ghi là không có.

## G. Trích xuất shader

Thêm `--shader-mode <Dummy|Yaml|Decompile>` cho `AssetRipper.Tools.SystemTester`.

`Yaml` giữ được bytecode: riêng `Spine_Skeleton` có **12 `m_SubPrograms`, 31 blob, 18
`GpuProgramType`**, kèm hai script editor AssetRipper tự sinh. Tức yêu cầu §20 "ưu tiên giữ compiled
shader artifact" **đã làm được hôm nay**, chỉ là harness chưa bao giờ bật nó.

Backend thực tế của fixture: `GpuProgramType` chỉ có hai giá trị, **4 và 5**, mỗi giá trị 57 lần.
Theo `ShaderGpuProgramType55`: `GLES3 = 4`, `GLES = 5`. **Không một chương trình DXBC, SPIR-V hay
Metal nào.** Công việc SPIR-V (§18), HLSLcc (§19) và Metal (§20) sẽ áp dụng cho **0 chương trình**
ở đây; muốn làm phải có fixture khác (build Vulkan hoặc build Windows).

Blob bị nén — base64-decode ra dữ liệu entropy cao, không thấy `#version`, `gl_Position`,
`uniform` — nên "GLES thì blob nên là GLSL văn bản" **chưa được xác nhận** và không được ghi là đã
xác nhận.

## H. Decompile shader

`ShaderExportMode.Decompile` **không tồn tại trong repository này**. Phần dispatch chỉ có hai
nhánh:

```csharp
ShaderExportMode.Yaml => new YamlShaderExporter(),
_                     => new DummyShaderTextExporter(),   // Decompile rơi vào đây
```

GUI gate nó sau `GameFileLoader.Premium`, tức một `ExportHandler` khác không có trong cây mã nguồn
mở. Tiền đề §23 ("tận dụng AssetRipper shader decompilation") **sai với repository này**.

**Cái bẫy quan trọng hơn:** `Dummy` không rỗng. Nó phục hồi **chính xác** phần `Properties` — tên,
kiểu, giá trị mặc định, `[Toggle]`, `[NoScaleOffset]`, `[HideInInspector]`, cả `//CustomEditor` —
rồi gắn cho **mọi** shader cùng một pass unlit thay thế. Thứ đó **biên dịch được**, nên material
dùng nó **không hồng**, và một phép kiểm tra chỉ tìm material hồng sẽ báo **PASS** trong khi toàn bộ
shading sai. Đây đúng dạng `SHADER_NOT_FOUND != SHADER_NOT_USED` của §34, ở chiều nguy hiểm hơn:
một stand-in biên dịch được trông y hệt thành công.

## I. Animation

2 AnimationClip, 1 AnimatorController. Curve **chưa kiểm chứng** → `PARTIAL`, không phải `OK`.

## J. Audio

6 clip `.ogg`. `OK`.

## K. Native plugin

`libmain.so`, `libunity.so` có trong APK. **Chưa phân loại** → `NOT_RUN`. Không suy đoán.

## L. Sinh Unity project

Bản rip xuất ra cấu trúc `Assets/` với script, meta, prefab, scene, material, texture, audio. Chưa
có công cụ `validate-unity-project` như §27 yêu cầu.

## M. Validate Unity

**`UNITY_NOT_AVAILABLE`** — kiểm tra chứ không đoán: không có Unity cài trên máy này. U1–U9 giữ
nguyên `NOT RUN`.

## N. Validate build

**`UNITY_NOT_AVAILABLE`**. Phép đo biên dịch có được là Roslyn chạy trên chính các assembly bản rip
xuất kèm (`AuxiliaryFiles/GameAssemblies`) — yếu hơn phép đo của Unity, và nghiêm hơn theo một
hướng: một thành viên framework mà IL2CPP đã strip sẽ đọc thành lỗi dù bản xuất vẫn đúng so với một
bản cài Unity thật.

## O. Validate runtime

**`UNITY_NOT_AVAILABLE`**. I1–I4 giữ `NOT RUN`. Không giả lập runtime test.

## P. Điểm số phục hồi, tách riêng (§33)

Không gộp thành một con số.

| Hạng mục | Trạng thái | Con số |
|---|---|---|
| Script | **OK** | 819 file, 96,06% method có thân thật |
| Asset | PARTIAL | 36 texture, 29 sprite, 6 audio, 2 font, 4 text |
| Behavior | PARTIAL | 2722 unresolved load, 348 lỗi Roslyn |
| Scene | PARTIAL | 1 scene / 103 GameObject |
| Reference | PARTIAL | 4 `m_Script` trỏ `fileID: 0` |
| Shader | **NOT_AVAILABLE** (decompile) / PARTIAL (surface + blob) | mục G, H |
| Animation | UNKNOWN | 2 clip, chưa kiểm chứng |
| Audio | OK | 6 clip |
| Native | NOT_RUN | — |
| Build | UNITY_NOT_AVAILABLE | — |
| Runtime | UNITY_NOT_AVAILABLE | — |

## Q. Bug đã sửa

**Không có bug pipeline nào được sửa trong iteration này, và đó là chủ ý.** Phát hiện chính (mục C)
đến từ một mẫu lệch; patch theo nó là đúng dạng sai lầm mà 036, 037, 038 và 041 đã bị và đã ghi sổ.
Theo §21 của brief 043, một iteration loại trừ được giả thuyết bằng bằng chứng vẫn là thành công.

Ba tiền đề của brief bị **đo là sai** (mục F, G, H) — bản thân đó là kết quả: nó ngăn ba hướng công
việc sẽ không sinh ra gì.

## R. Kết quả âm

1. **Không patch khung toạ độ** dù bảng chéo tách sạch 68/68 — mẫu chỉ gồm load thất bại.
2. **SPIR-V / DXBC / Metal** (§18–20): 0 chương trình trên fixture. Không có gì để làm.
3. **Map GUID per-script** (§9): đã đúng sẵn, 450/450.
4. **Shader decompilation** (§23): không có trong cây này.
5. **Một test tự phát hiện là suy biến và được ghi chú đúng như vậy** —
   `ACopyCycleTerminatesAsUnknown`: với một định nghĩa mỗi local, gỡ chặn chu trình **không** làm
   test đỏ, vì giới hạn độ sâu đằng nào cũng trả `Unknown`. Giữ lại như test chống treo, không phải
   bằng chứng rằng guard chịu lực. Ghi ra thay vì giấu đi.

## S. Commit

| Hash | Nội dung |
|---|---|
| `d930b2af` | `feat(measure)`: phân loại nguồn gốc con trỏ base, và luật về hệ toạ độ rơi ra từ đó |
| `e473b4db` | `feat(measure)`: cờ `--shader-mode`, và ma trận phục hồi đo được cho toàn bộ pipeline |
| `4dec5263` | `docs`: ghi sổ iteration 044 và ba bài học đo lường |

Tài liệu mới: `docs/RECOVERY_MATRIX.md` (23 layer), `docs/FULL_RECOVERY_ARCHITECTURE.md` (13 layer,
mỗi layer có input/output/bằng chứng/chế độ hỏng/test). Sổ: `iterations/044/`.

## T. Đề xuất Iteration 045

Dựa trên bằng chứng thu được ở 044, không phải danh sách mong muốn.

1. **Đo lại bảng chéo nguồn gốc × khung trên *load đã phân giải*.** Đây là việc phải làm trước
   tiên và là hệ quả trực tiếp của mục C. Nếu luật `STATIC_FIELD → VALUE_RELATIVE` và
   `THIS/PARAMETER/CALL_RESULT/INSTANCE_FIELD → OBJECT_RELATIVE` vẫn đúng trên toàn chương trình
   thì nó thành luật trong `MetadataResolver`, và đó là thứ 041 đã phải bỏ vì thiếu đúng bằng chứng
   này. Nếu sai, ghi là kết quả âm và đóng hướng đó.

2. **Báo cáo tham chiếu gãy (§12).** 4 `m_Script` trỏ `fileID: 0` đã đo được; cái thiếu là dạng
   báo cáo source/target/reason/repair/confidence. Nhỏ, xác định được, và là điều kiện cần cho mọi
   phát biểu về "project import được".

3. **Pinata `CS0030 = 1125`** (`Cannot convert type 'int' to 'TCP2_PlanarReflection'`) — họ lỗi lớn
   nhất còn lại theo số đo, và là vấn đề **gán kiểu**, không phải layout. Đúng hướng "use-side type
   recovery" mà 039 để lại: một local được gán kiểu từ định nghĩa rồi dùng ở chỗ muốn kiểu khác.

Ba việc trên theo thứ tự đó. Không mở thêm subsystem shader cho tới khi có fixture có backend khác
GLES.

---

## Ghi chú chống bịa (§34)

- `UNKNOWN != ZERO`: Mesh, shader variant, Addressables, chọn ABI ghi `UNKNOWN` vì chưa đo, không
  ghi là không có.
- `NOT_RUN != PASS`: native plugin, iOS từ layer serialized asset trở xuống, U1–U9, I1–I4.
- `SHADER_NOT_FOUND != SHADER_NOT_USED`: mục H, và chiều nguy hiểm hơn của nó — một stand-in biên
  dịch được làm phép kiểm tra "có hồng không" báo PASS sai.
- `UNITY_NOT_AVAILABLE` là kết quả của một phép kiểm tra, không phải một phỏng đoán.

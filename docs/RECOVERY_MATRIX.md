# Ma trận phục hồi: APK/IPA → Unity project chạy được

Iteration 044. Mọi ô trong bảng là **đo được**, không phải suy đoán. Nơi không đo được thì ghi
`NOT_RUN` hoặc `UNKNOWN`, không ghi `PASS`.

Fixture đo: `Test/Input/Impostor` (APK đã giải nén, Unity 2022.3.62f2, metadata v31.1, ARM64) và
`Test/Input/Pinata` (x86, v24.2). iOS: `Test/Input/JellyBlast`, FairPlay-encrypted.

Lệnh dựng lại: `Test/Scripts/collect_metrics.sh`, và bản rip `Test/Output-044b`.

---

## 1. Bảng theo layer

| Layer | Android | iOS | Bằng chứng |
|---|---|---|---|
| Giải nén container | **PARTIAL** | **PARTIAL** | Đầu vào là thư mục đã giải nén, không phải file `.apk`/`.ipa`. Chưa đo được đường unzip. |
| Chọn ABI | **UNKNOWN** | n/a | APK có *hai* ABI (`arm64-v8a`, `armeabi-v7a`); log chỉ nói `instruction set Arm64InstructionSetSelector`, không nói vì sao chọn cái đó. |
| Unity version | **OK** | **OK** | `Unity 2022.3.62f2, metadata v31.1, 64-bit` đọc ra từ chính build. |
| Metadata IL2CPP | **OK** | **PARTIAL** | iOS: `__DATA` đọc được, `__TEXT` mã hoá — xem `ENCRYPTED_NATIVE_INPUT` bên dưới. |
| Binary IL2CPP | **OK** | **BLOCKED** | FairPlay `cryptid=1`. Không tự bypass DRM. |
| Serialized assets | **OK** | NOT_RUN | 36 Texture2D, 29 Sprite, 7 Material, 6 AudioClip, 4 TextAsset, 2 Font, 2 AnimationClip, 1 AnimatorController. |
| Scenes | **PARTIAL** | NOT_RUN | 1 scene, 103 GameObject, 113 MonoBehaviour, 29 Transform. |
| Prefabs | **OK** | NOT_RUN | 6 prefab. |
| Meshes | **UNKNOWN** | NOT_RUN | Không có thư mục Mesh trong bản rip; chưa xác định game có mesh hay không. |
| Textures | **OK** | NOT_RUN | 36 PNG. |
| Materials | **PARTIAL** | NOT_RUN | 7 material, tham chiếu tới shader **thay thế** — xem mục 2. |
| Shaders | **PARTIAL** | NOT_RUN | Xem mục 2. Đây là ô quan trọng nhất và dễ đọc nhầm nhất. |
| Shader variants | **UNKNOWN** | NOT_RUN | `m_KeywordNames` có mặt (3 lần); chưa đo variant nào được giữ. |
| Animation | **PARTIAL** | NOT_RUN | 2 AnimationClip, 1 AnimatorController; chưa kiểm chứng curve. |
| Audio | **OK** | NOT_RUN | 6 `.ogg`. |
| Scripts | **OK** | NOT_RUN | 819 file `.cs`, 96,06% method có thân thật (đo bằng `measure-bodies.py`). |
| Native plugins | **NOT_RUN** | NOT_RUN | `libmain.so`, `libunity.so` có trong APK; chưa phân loại. |
| GUID references | **OK** | NOT_RUN | 450 GUID *duy nhất* trên 450 file `.cs.meta` — GUID theo từng script, không phải theo assembly. |
| Addressables | **UNKNOWN** | NOT_RUN | Chưa dò. |
| Resources | **OK** | NOT_RUN | 20 asset dưới `Resources`. |
| StreamingAssets | **NONE_PRESENT** | NOT_RUN | Không có trong APK này. |
| Runtime behavior | **NOT_RUN** | NOT_RUN | Cần Unity. |
| Build | **UNITY_NOT_AVAILABLE** | **UNITY_NOT_AVAILABLE** | Không có Unity trên máy này. |
| Run | **UNITY_NOT_AVAILABLE** | **UNITY_NOT_AVAILABLE** | idem. |

---

## 2. Shader — ô dễ đọc nhầm nhất, và ba sự thật đo được

### 2.1 `Decompile` không tồn tại trong repository này

`ShaderExportMode` có ba giá trị, nhưng phần dispatch chỉ có hai:

```csharp
OverrideExporter<IShader>(settings.ExportSettings.ShaderExportMode switch
{
    ShaderExportMode.Yaml => new YamlShaderExporter(),
    _ => new DummyShaderTextExporter(),   // Decompile rơi vào đây
});
```

`Decompile` **rơi xuống `DummyShaderTextExporter`**. Phần GUI gate nó sau `GameFileLoader.Premium`,
tức một `ExportHandler` khác không có trong repo mã nguồn mở này. Kết luận:
**shader decompilation là NOT_AVAILABLE trong cây này**, và giả định của brief §23 rằng có thể "tận
dụng AssetRipper shader decompilation" là sai với repository này.

### 2.2 `Dummy` không rỗng — và đó mới là chỗ nguy hiểm

`Dummy` phục hồi **chính xác** phần `Properties`: tên, kiểu, giá trị mặc định, cả `[Toggle]`,
`[NoScaleOffset]`, `[HideInInspector]`, và cả `//CustomEditor`. Rồi nó gắn cho **mọi** shader cùng
một pass unlit thay thế:

```hlsl
output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
return _MainTex.Sample(sampler_MainTex, input.uv.xy);
```

Thứ này **biên dịch được**. Nên material dùng nó **không hồng**, và một phép kiểm tra chỉ tìm
material hồng sẽ báo PASS trong khi toàn bộ shading sai. Đây đúng dạng
`SHADER_NOT_FOUND != SHADER_NOT_USED` của brief §34, ở chiều nguy hiểm hơn: một stand-in biên dịch
được trông y hệt thành công.

### 2.3 `Yaml` giữ được bytecode, và một cờ là đủ

`--shader-mode Yaml` (thêm ở iteration này) xuất shader thành `.asset` YAML mang
**12 `m_SubPrograms`, 31 blob, 18 `GpuProgramType`** trên riêng `Spine_Skeleton`, cùng hai script
editor AssetRipper tự sinh (`AvoidSavingYamlShaders.cs`, `YamlShaderPostprocessor.cs`). Tức yêu cầu
"ưu tiên giữ compiled shader artifact" của §20 **đã làm được hôm nay**, chỉ là harness chưa bao giờ
bật nó.

### 2.4 Backend thực tế của fixture này: **chỉ GLES**

Đọc `GpuProgramType` trên toàn bộ shader đã xuất: chỉ có hai giá trị, **4** và **5**, mỗi giá trị 57
lần. Theo chính enum trong repo (`ShaderGpuProgramType55`): `GLES3 = 4`, `GLES = 5`.

Nghĩa là **không có một chương trình DXBC, SPIR-V hay Metal nào** trong fixture này. Công việc
HLSLcc (§19), SPIR-V (§18) và Metal (§20) sẽ áp dụng cho **0 chương trình** ở đây. Muốn làm chúng
thì phải có fixture khác — một build Vulkan hoặc một build Windows — chứ không phải Impostor.

Blob thì bị nén (thử base64-decode ra dữ liệu entropy cao, không thấy `#version`, `gl_Position`,
`uniform`), nên "GLES nên là GLSL văn bản" **chưa được xác nhận** và không được ghi là đã xác nhận.

---

## 3. Những tiền đề của brief bị đo là sai

| Tiền đề | Thực tế đo được |
|---|---|
| §9 "assembly-level synthetic GUID cần map thành per-script GUID" | Đã là per-script: 450 GUID duy nhất trên 450 `.cs.meta`. |
| §23 "tận dụng AssetRipper shader decompilation" | Không có trong cây này; `Decompile` rơi xuống Dummy. |
| §18/§19 SPIR-V và DXBC là hướng ưu tiên | 0 chương trình thuộc hai backend đó trên fixture. |

---

## 4. Điểm số phục hồi, tách riêng (§33)

Không gộp thành một con số.

| Hạng mục | Trạng thái | Con số |
|---|---|---|
| Asset Recovery | PARTIAL | 36 texture, 29 sprite, 6 audio, 2 font, 4 text |
| Script Recovery | **OK** | 819 file, 96,06% method có thân thật |
| Behavior Recovery | PARTIAL | 2722 unresolved load, 348 lỗi Roslyn (Assembly-CSharp) |
| Scene Recovery | PARTIAL | 1 scene / 103 GameObject |
| Reference Recovery | PARTIAL | 4 `m_Script` trỏ `fileID: 0` |
| Shader Recovery | **NOT_AVAILABLE (decompile)** / PARTIAL (surface + blob) | xem mục 2 |
| Animation Recovery | UNKNOWN | 2 clip, chưa kiểm chứng |
| Audio Recovery | OK | 6 clip |
| Native Recovery | NOT_RUN | — |
| Build Recovery | UNITY_NOT_AVAILABLE | — |
| Runtime Recovery | UNITY_NOT_AVAILABLE | — |

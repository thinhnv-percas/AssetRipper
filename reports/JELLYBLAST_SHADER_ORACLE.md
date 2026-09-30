# JellyBlast shader & material oracle — iteration 063

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Bản rip `Test/Out63g-i`; source `develop` @ `462789cf`.
Nguyên liệu: `iterations/063/shader/`.

## 1. ShaderRuntimeContract của fixture này

| Thành phần | Trạng thái |
|---|---|
| Backend của build | Metal duy nhất |
| Chương trình | 780 MSL source (`reports/JELLYBLAST_METAL_ANALYSIS.md`), 0 thư viện |
| `SOURCE_SHADER_AVAILABLE` | 29 shader có `.shader` trong source |
| `METAL_BINARY_AVAILABLE` | 0 |
| `METAL_SOURCE_AVAILABLE` | 83 shader |
| ShaderLab xuất ra | cấu trúc thật (subshader, pass, tag, render state, keyword), chương trình là bản thay thế — `DUMMY` 29/29 theo `shader_semantic_equivalence.py`, đúng, vì ShaderLab không có khối MSL |
| `SERIALIZED_SHADER_MATCH` | cấu trúc: đã đo ở 057–062; không đổi ở đây |
| `SOURCE_SHADER_MATCH` | xem §3 — đo trên chương trình MSL, không trên ShaderLab xuất ra |
| `METAL_SEMANTIC_MATCH` | UNKNOWN ngoài phần §3 đo được |
| Render / runtime | **BLOCKED** (không có Unity) |

## 2. Source shader của JellyBlast phần lớn không phải bản gốc — PROVEN

Lịch sử source nói thẳng: "Rebuild dummy Custom/Bee shader", "Rebuild dummy Custom/Octopus shader"…
Trong 26 `.shader` của `Assets/Shader`: **19 được viết lại tay** từ bản stand-in của một bản rip, **7 vẫn
là stand-in** (mang `DummyShaderTextExporter`/`AssetRipperReplacementProgram`). Không cái nào là
chương trình gốc của studio. Ngoại lệ là TextMesh Pro Essential Resources trong `Assets/TextMesh Pro`:
có từ `fe27775f`, không có dấu rip, là bản sao upstream — **độc lập**.

Hệ quả: với 19 shader Custom, **MSL trích từ build là bản gốc duy nhất tồn tại**, và chiều so đảo lại —
build là tham chiếu, source là bản chép.

## 3. MSL so với source — MEASURED (`msl_source_comparison.py`)

So theo lớp phép toán và theo texture thật sự được sample (không theo số đếm: HLSLcc unroll, inline và
tách, nên số đếm khác nhau giữa mọi HLSL và bản dịch của nó). Phán quyết dựa trên thứ một bản dịch phải
giữ: texture được sample, discard, ghi position/color. Lớp số học (lerp → số học, saturate → clamp) được
báo nhưng không phán.

| Nguồn gốc source | SAMPLING_AGREES | SAMPLING_DIFFERS | Không có chương trình để so |
|---|---:|---:|---:|
| INDEPENDENT (TMP Distance Field Overlay, Mobile/Distance Field, Sprite) | **3** | 0 | — |
| REBUILT (Custom/* viết tay) | 9 | 9 | — |
| STAND_IN | — | — | 8 |

- **Độc lập 3/3**: MSL trích ra sample đúng các texture mà source của programmer sample. Đây là kiểm
  chứng việc trích xuất, không phải của một project dùng được.
- **Viết lại 9/18 khác** — và ở đây build là đúng: bản gốc của `Custom/Bee`, `Honey_NoGrab`, `Mud`,
  `SingleFluid`, `SpecialFluid`, `Sponge`, `Octopus` sample `_FluidTex`, `_RawFieldTex`, `_EmissionTex`,
  `_EyesTex` mà bản viết tay bỏ; `Custom/Water` viết tay thêm `discard` và `_WaterGrabTex` mà build không
  có; `Glass2` gốc sample `_SceneColor`. Đây là phát hiện về source của studio, không về bản phục hồi.

Lỗi đo tìm được: bản đầu đọc `[[ texture(0) ]]` của MSL (attribute binding) là một lần sample và báo
texture tên `'0'`, `'1'`; sampler của MSL giờ đọc qua `tex.sample(`.

## 4. Material → keyword → variant

Đo ở 062 (`shader_variant_fidelity.py`) cho các fixture GLES. JellyBlast: 27 shader có material trong bản
rip (`jellyblast-metal.json` liệt kê theo shader). Chọn variant cho Metal cần guard keyword bao quanh MSL,
mà MSL không thể nằm trong ShaderLab — nên chưa có gì để chọn: **UNKNOWN**.

## 5. Mức chấp nhận (§27)

Shader của JellyBlast: `STRUCTURE_ONLY` cho project xuất ra (pass thay thế), `PROGRAM_EXTRACTED` cho
chương trình (MSL). `RUNTIME_RENDER_VALIDATED`: **BLOCKED**.

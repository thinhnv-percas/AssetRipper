# Shader variant runtime fidelity — iteration 062

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**, **BLOCKED**.

## 1. Lỗi — PROVEN ở iteration 061, sửa ở đây

Iteration 061 ghi mỗi pass một program: variant đầu (thường là base, không keyword). Unity chọn program
theo keyword mà material và engine bật, nên project khôi phục compile đúng một program và mọi material
của shader vẽ bằng nó. `shader_variant_binding.py` đo: **4 trên 9** binding trên Impostor và **6 trên
30** trên Merge-Room vẽ bằng variant không keyword trong khi keyword của material chọn variant khác
(`variant_binding_rate` 0.5556 và 0.8000). Program đúng mà material vẫn vẽ sai.

## 2. Sửa — `ShaderVariantGuards`

Mọi variant của pass đi vào một `GLSLPROGRAM`, mỗi program dưới guard là **chính xác** tập keyword nó
được compile cho:

```
#pragma multi_compile __ OUTLINE_ON
#pragma multi_compile __ UNDERLAY_ON
...
#if (!defined(OUTLINE_ON) && !defined(UNDERLAY_ON) && !defined(UNITY_UI_ALPHACLIP) && !defined(UNITY_UI_CLIP_RECT))
// AssetRipperVariant: variant 1, content 1386dc120161b3f0, keywords <none>
...
#elif (defined(OUTLINE_ON) && !defined(UNDERLAY_ON) && ...)
// AssetRipperVariant: variant 2, content 2366a48b65f6782f, keywords OUTLINE_ON
...
#else
// AssetRipperVariantSelectionUnknown: the original build compiled no program for this keyword state
#error VARIANT_SELECTION_UNKNOWN
#endif
```

Không có gì được *chọn*: không first variant, không base variant, không nearest variant. Một trạng thái
keyword mà build gốc không compile rơi vào `#else` và nói ra như vậy. Ở runtime Unity sẽ chọn variant
gần nhất theo luật riêng của nó, luật đó không được tái tạo ở đây, và viết base program vào chỗ đó mà
không nói gì chính là heuristic §10 cấm.

Bốn quyết định, mỗi cái có bằng chứng:

- **Identity của program là nội dung**, không phải blob index: SHA-256 (16 hex đầu) của source. Iteration
  061 thấy bảng index → program đọc sai stride, nên một identity dựa riêng vào bảng sẽ thừa kế mọi lỗi
  của bảng. Program giống hệt nhau dùng chung một guard (`||`), nên text là một bản cho mỗi program
  khác nhau.
- **Scope của keyword đọc từ asset.** `m_KeywordFlags` song song với `m_KeywordNames`; bit 0 là local.
  **MEASURED**: trên 16 keyword có source shader trong fixture, bit 0 = 1 đúng khi pragma nguồn là
  `_local`, không trường hợp nào khác; không bit nào khác được đặt trên keyword nào của hai fixture
  (6046 giá trị 0, 314 giá trị 1). Keyword global được khai báo `multi_compile`, local
  `multi_compile_local`. Khai báo `SHADOWS_DEPTH` (engine đặt, global) là local sẽ làm program của pass
  ShadowCaster không bao giờ được chọn.
- **Hardware tier.** Mỗi tier liệt kê lại các tập keyword. Nếu hai tier compile hai program khác nhau
  cho cùng một tập, pass không được nhúng và nói lý do (2 pass trên RunFromZombies); lấy tier đầu là
  chọn.
- **Giới hạn**: tối đa 8 keyword (2^n tổ hợp) và 1 MB program khác nhau; vượt thì không nhúng và nói
  lý do (`AssetRipperVariantsNotEmbedded`).

`ShaderVariants.json` giờ mang identity của program theo §11: `backend`, `stage`, `blobIndex`,
`platform`, `offset`, `length`, `textOffset`, `textLength`, `contentHash`. Khoá dedupe trước đây là
`string.GetHashCode()`, 32 bit và ngẫu nhiên theo process, nên không đặt tên được một program giữa hai
bản rip.

## 3. Đo — `shader_variant_fidelity.py`

Script đọc **chuỗi guard thật** trong file `.shader` (không đọc comment bên cạnh), đánh giá nó cho mỗi
material với **mọi tổ hợp keyword engine** (keyword có trong bảng variant mà không material nào của
shader điều khiển), và so program được chọn **theo content hash** với program bảng variant nói build
gốc đã compile cho đúng trạng thái đó. Material keyword nguồn được đọc từ source project theo tên
material + tên shader.

| Fixture | 061 `variant_binding_rate` | 062 binding | 062 fidelity (EXACT / quyết định) | Khác |
|---|---:|---:|---:|---|
| Impostor | 0.5556 (9) | 1.0 (9) | **9 / 9** | — |
| Merge-Room | 0.8000 (30) | 1.0 (30) | **29 / 30** | 1 `NOT_EMBEDDED`, 5 `PROGRAM_NOT_RECOVERED`, 310 material Toon không có pass được đánh dấu |
| RunFromZombies | — | — | 7 pass được nhúng | 2 pass tier khác nhau, 1 pass > 8 keyword |
| JellyBlastV2 | — | — | 0 | chỉ có Metal: không source để nhúng |
| Pinata | — | — | 0 | Unity 2019.2 không ghi tên keyword |

Chi tiết từng material: `iterations/062/shader-variant-fidelity/{Impostor,MergeRoom}.{json,txt}`, mỗi
hàng mang `material`, `shader`, `pass`, `sourceKeywords`, `recoveredKeywords`, `expectedVariants`,
`selectedVariant`, `vertexProgram`, `fragmentProgram`, `engineKeywords`, `statesJudged`, `status`.

**Mismatch còn lại** (Merge-Room):

| material | shader | pass | recovered keywords | expected | selected | status |
|---|---|---|---|---|---|---|
| Ghost | Shader Graphs/Ghost | 0.0 | ∅ | — (không variant nào compile cho ∅ trên backend) | variant 1, `bf85497a73daf336` | `NOT_EMBEDDED` (pass chỉ có một program) |
| circle_AB, cloud_2x2_default_AB, PolySprite_ADD | URP/Particles/Unlit | 0.2 | `_FADING_ON _SOFTPARTICLES_ON _SURFACE_TYPE_TRANSPARENT` | — | — | `PROGRAM_NOT_RECOVERED` |
| PolySolidGlow | PolygonArsenal/URP/PolygonArsenal-SolidGlowSoft | 0.3 | ∅ | — | — | `PROGRAM_NOT_RECOVERED` |

Material keyword so với source: Impostor 4 AGREE, 5 AMBIGUOUS (cùng tên material nhiều lần trong
source); Merge-Room 7 AGREE, 3 AMBIGUOUS, 25 NOT_FOUND (material URP/package không có trong source
tree). **Không một DIFFER.**

**Phép đo phân biệt được**: hoán đổi hai điều kiện guard trong một bản sao TMP Mobile SDF cho
`EXACT 6, WRONG_PROGRAM 3`. Và bản đầu của parser dừng chuỗi ở `#else` đầu tiên *bên trong* một program
(`#ifdef GL_FRAGMENT_PRECISION_HIGH ... #else`) và báo `MISSING_PROGRAM` 7/9 cho một export đúng — một
phép đo quá chặt cũng sai như một phép đo quá lỏng. `--self-test` có sáu case, gồm đúng case đó.

## 4. Ngữ nghĩa và render state

Render state (Blend, ColorMask, Offset, Stencil, ZTest, ZWrite, Cull) được ghi từ asset từ iteration
058 và không đổi ở đây. Phép so ngữ nghĩa program với source (`shader_semantic_equivalence.py`) gộp
operation của mọi program nên mù với gán nhầm variant (ghi ở 061); binding được đo riêng như trên.

## 5. Chưa biết

- **INFERRED, chưa kiểm bằng Unity**: một variant `#error` trong một tổ hợp `multi_compile` mà build gốc
  không có sẽ làm Unity báo shader error cho tổ hợp đó khi build. Đó là lựa chọn có chủ đích (material
  ở trạng thái đó vẽ bằng error shader, nhìn thấy được, thay vì vẽ sai lặng lẽ), nhưng việc nó có làm
  `BuildPipeline` báo lỗi hay chỉ cảnh báo phải được xác nhận trong một môi trường có Unity: **BLOCKED**.
- Program Metal (JellyBlastV2) không phải source; không có gì để nhúng.

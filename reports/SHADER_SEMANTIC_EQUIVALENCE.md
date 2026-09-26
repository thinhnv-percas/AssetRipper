# Shader phục hồi so với ShaderLab nguồn

Iteration 058, §13–§16. `Test/Scripts/shader_semantic_ir.py` +
`Test/Scripts/shader_semantic_equivalence.py`, đo trên `Test/Out58H-*`.

## 1. Oracle có tồn tại, và luôn tồn tại

Iteration 057 ghi: "không fixture nào ship shader nguồn — đó là rào chặn mọi verdict trên
`STRUCTURE_ONLY`". Điều đó **chưa bao giờ được kiểm** với chính các fixture. Ba trong bốn có nguồn:

| fixture | shader trong build | xuất ra ShaderLab | **có nguồn để so** | nguồn ở đâu |
|---|---:|---:|---:|---|
| RunFromZombies | 78 | 24 | **24** | `com.unity.postprocessing@3.4.0`, phiên bản `manifest.json` ghim |
| Impostor | 55 | 3 | **3** | TextMesh Pro và Spine vendored trong `Assets/` |
| Merge-Room | 85 | 32 | 7 | TMP trong `Assets/`; 25 shader URP thì không |
| JellyBlast v2 | 85 | 30 | 0 | không có source project |

Nguồn của package lấy được ở đúng phiên bản `Packages/manifest.json` ghim
(`https://packages.unity.com/<gói>/-/<gói>-<phiên bản>.tgz`). URP 14.0.12 trả 404 ở registry đó, nên
25 shader của Merge-Room là `NOT_APPLICABLE` vì **thiếu oracle**, không phải vì bản phục hồi thiếu.

**Không cần tạo fixture shader riêng** (§10). Việc đó chỉ nên làm nếu không tìm được nguồn.

## 2. So cái gì

Theo thứ tự, vì cái trước hỏng thì cái sau vô nghĩa:

1. **Có phải bản thay thế không?** Một pass mang `AssetRipperReplacementProgram` thì không phải
   chương trình của shader, dù mọi thứ khác khớp. `DUMMY`, quyết trước mọi mức độ thành công.
2. **Trạng thái vẽ.** Properties, Tags, Cull, ZWrite, ZTest, Blend, ColorMask, Offset, Stencil. Một
   chương trình đúng dưới trạng thái sai thì không vẽ ra thứ shader đã vẽ: `PARTIAL`, không bao giờ
   `EXACT`.
3. **Ngữ nghĩa chương trình.** Bộ thao tác mỗi bên chạm tới, qua `shader_semantic_ir`, quy cả GLSL
   lẫn Cg về một bộ từ vựng.

## 3. Kết quả

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| `EXACT` | 0 | 0 | 0 | 0 |
| `SEMANTICALLY_EQUIVALENT` | **9** | **2** | **2** | 0 |
| `PARTIAL` | 2 | 1 | 3 | 0 |
| `FALLBACK` | 0 | 0 | 1 | 0 |
| `DUMMY` | 13 | 0 | 1 | 0 |
| `NOT_APPLICABLE` | 0 | 0 | 25 | 29 |
| tỉ lệ | 0,3750 | 0,6667 | 0,2857 | — (0 so được) |

**13 shader đạt `SEMANTICALLY_EQUIVALENT`** trên ba fixture — tiêu chí §22.10.

`EXACT` vẫn **0** ở mọi fixture, và đó là con số đúng: `EXACT` đòi bộ thao tác *trùng khít* hai
chiều, mà HLSLcc thì khai triển `lerp` thành số học và gộp `saturate` thành clamp của hằng. Không
shader nào đạt, và không nên ép cho đạt.

## 4. Những thao tác một trình biên dịch shader được phép khai triển

`LERP CLAMP MIN MAX NORMALIZE LENGTH VECTOR_MUL MATRIX_MUL ADD SUB MUL DIV RETURN COMPARE` — vắng mặt
của chúng trong chương trình đã biên dịch **không** là bằng chứng mất mát, và được báo riêng
(`expanded_operations`). Phần còn lại — `TEXTURE_SAMPLE`, `LOAD_VERTEX_*`, `STORE_POSITION`,
`STORE_COLOR`, `DISCARD`, `BRANCH`, `LOAD_UNIFORM`, `LOAD_SAMPLER`, `DOT`, `CROSS` — sống sót qua
biên dịch, và vắng mặt của chúng là khác biệt thật.

## 5. Bốn phép đo tự báo mình sai trước khi tin được

Cả bốn đều đọc y như một khiếm khuyết của bản phục hồi:

- **`Cull Off ZWrite Off ZTest Always` trên một dòng** đọc thành `Cull = "Off ZWrite Off ZTest
  Always"`. 11 shader báo `PARTIAL` vì đúng chuyện đó.
- **Trạng thái đọc cả bên trong khối chương trình**: một biến cục bộ tên `offset`, chữ `Blend` trong
  một comment HLSL.
- **Mặc định của ShaderLab**: shader viết `ZTest LEqual` và shader không viết gì thì đặt cùng một
  trạng thái. So theo *sự có mặt* thay vì theo *giá trị* báo hai cái đó là khác nhau.
- **Trạng thái do material property điều khiển** (`ZTest [unity_GUIZTestMode]`) không có giá trị cố
  định để so.

Và một cái nữa, đúng cùng lớp lỗi mà iteration 057 đã mất một baseline để tìm:
`validate_unity_stages.py` quyết "exact" bằng **sự vắng mặt** của dấu bản thay thế, nên ngay khi một
pass mang được chương trình thật nó báo `shader_exact 10 of 34`. Đã đổi thành
`shader_programs_recovered`, và `shader_exact` ở đó nay là `NOT_MEASURED_HERE`: script đó không so gì
với nguồn cả, nên nó không có tư cách quyết.

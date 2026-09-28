# Shader variant binding — iteration 061

`Material → Shader → Keywords → Variant → program`. Một program đúng mà material chọn variant khác
thì vẫn vẽ sai. Báo cáo này có hai phần: một lỗi đọc bảng làm mọi program bị gán nhầm variant, và phép
đo binding chỉ có ý nghĩa sau khi lỗi đó được sửa. Nhãn: **PROVEN**, **MEASURED**, **INFERRED**,
**UNKNOWN**, **BLOCKED**.

## 1. Bảng entry của blob được đọc sai stride — PROVEN, đã sửa

Đầu blob đã giải nén của `TextMeshPro/Mobile/Distance Field` (GLES, Impostor):

```
0d000000 | a0000000 1c000000 00000000 | bc000000 50170000 00000000 | ...
count 13 | (160, 28, seg 0)          | (188, 5968, seg 0)         | ...
```

Mỗi entry là `(offset, length, segment)` — 12 byte. Header dài `4 + 13 × 12 = 160`, đúng offset của
entry đầu; và offset + length của mỗi entry bằng đúng offset của entry sau (188 + 5968 = 6156,
6156 + 6160 = 12316, …). `ShaderProgramProbe.ReadEntryTable` đọc cặp 8 byte, nên chỉ một trong ba
entry trùng với entry thật, còn lại đọc thành `(x, 0)` hoặc `(0, n)` — một đoạn từ đầu blob, gồm cả
header, chạy qua nhiều program. Hệ quả:

- mọi program được gán cho keyword set của một variant khác;
- một số "program" là vài program nối nhau, đúng là triệu chứng iteration 058 ghi lại ("entry có
  length chạy tới cuối blob") và đã cắt bớt ở phía extractor thay vì sửa ở tầng đọc;
- các entry `(x, 0)` đọc thành variant bị strip.

Kiểm độc lập bằng source: trong `TMP_SDF-Mobile.shader`, `_UnderlayColor` chỉ xuất hiện dưới
`UNDERLAY_ON`, và `UNITY_UI_ALPHACLIP` là một `clip()` → `discard` trong fragment. Trước khi sửa,
program gắn nhãn `OUTLINE_ON+UNDERLAY_ON` không có `_UnderlayColor`. Sau khi sửa, **12/12** variant
GLES khớp: underlay đúng ở những variant có `UNDERLAY_ON`, `discard` đúng ở những variant có
`UNITY_UI_ALPHACLIP`.

Layout giờ do chính bảng quyết định chứ không do phiên bản: mỗi layout (cặp 8 byte của blob flat,
bộ ba 12 byte của blob segmented) nói program đầu tiên phải bắt đầu ở đâu — ngay sau bảng — và chỉ một
layout khớp được với offset nó đọc ra. Khớp cả hai hoặc không khớp cái nào thì không có entry nào: đoán
ở đây gán nhầm mọi program. Một entry không vừa giữ vị trí của nó dưới dạng entry rỗng, vì vị trí đó là
`BlobIndex`.

| | Impostor trước → sau | Merge-Room trước → sau | Pinata (flat) |
|---|---|---|---|
| Sub-program là source text | 231 → **484** / 759 | 194 → **412** / 727 | 1026 / 2976 |
| Variant có program source | 551 → **1449** / 1644 | 298 → **783** / 978 | 2568 / 9228 |
| Program khác nhau | 133 → 454 | 96 → 359 | 867 |
| Variant "bị strip" (size 0) | 457 → **0** | 291 → **0** | 0 |
| Shader có blob mà không đọc được bảng | 0 → 0 | 0 → 0 | 0 |

JellyBlastV2 chỉ có Metal (1164 library) trước và sau; một shader không đọc được bảng ở cả hai. Script
`.cs` của Impostor giống từng byte giữa rip có và không có sửa đổi này.

Ghi nhận của iteration 059 rằng "2523 program entry là 0 byte và 1241 là 1 byte, tức variant bị strip"
là sản phẩm của lỗi này, không phải tính chất của build.

`shader_semantic_equivalence.py` cho kết quả **giống hệt** trước và sau (2 SEMANTICALLY_EQUIVALENT,
1 PARTIAL trên Impostor). Nó gộp operation của mọi program của một shader, nên về cấu trúc không thể
thấy một program bị gán nhầm variant. Đó là lý do lỗi sống qua hai iteration đo shader.

## 2. Pinata không rip được — PROVEN, đã sửa

Trên Pinata (2019.2), `ShaderSemanticModel.Read` ném `ArgumentNullException`: một serialized shader
trước 2021 không có bảng tên keyword và không có `KeywordIndices`. Exception thoát khỏi export và kết
thúc cả process với exit 134. Dòng đó có từ iteration 057 (`9b268002`, 2026-09-18); rip Pinata cuối
cùng trên đĩa là 2026-09-16, nên Pinata không rip được suốt từ 057 và không lần chạy nào thấy điều đó —
ma trận bốn fixture không có Pinata. Hai sửa đổi:

- `StructuredShaderTextExporter.TryExport` bắt lỗi đọc cấu trúc và rơi về canned pass như hợp đồng của
  nó vẫn nói, kèm một warning có tên shader. Một lỗi đọc cấu trúc của một shader không còn là lỗi của
  cả rip.
- `ProgramModel.KeywordsKnown`: khi bản build không ghi keyword, keyword set là **không biết**, không
  phải rỗng. `ShaderBlobMapping.json` ghi `"keywords": null`. Đọc nó thành rỗng sẽ biến mọi variant
  thành base variant — đó là lỗi đầu tiên phép đo binding mắc phải trên Pinata (53 BOUND_EXACT giả).

Sau sửa: Pinata rip xong, 0 warning đọc cấu trúc, 0 lỗi `Decompiling`.

## 3. Binding — MEASURED

`Test/Scripts/shader_variant_binding.py <rip>`: với mỗi material và mỗi pass, keyword material bật
(từ `m_ValidKeywords`) giao với không gian keyword của pass chọn ra variant nào, và đó có phải program
mà ShaderLab export mang theo không. Keyword do *material* điều khiển được lấy, theo từng shader, là
những keyword mà một material nào đó của shader thật sự bật trong build — bằng chứng build mang theo, và
nó nghiêng đúng hướng: keyword không material nào bật được coi là của engine, chỉ có thể làm binding
trông *mơ hồ hơn*, không bao giờ chính xác giả.

| | Impostor | Merge-Room | Pinata | JellyBlastV2 | RunFromZombies |
|---|---:|---:|---:|---:|---:|
| Material | 11 | 333 | 64 | 60 | 24 |
| BOUND_EXACT | 3 | 23 | — | — | — |
| BOUND_MODULO_ENGINE | 2 | 1 | — | — | — |
| **VARIANT_BINDING_WRONG** | **4** | **6** | — | — | — |
| PROGRAM_NOT_RECOVERED | 0 | 5 | — | 43 (Metal) | — |
| KEYWORDS_NOT_RECORDED | — | — | 53 | — | — |
| NO_MARKED_PASS | — | 310 | — | — | — |
| Shader built-in | 4 | 1 | 17 | 18 | 24 |
| `variant_binding_rate` | 0.5556 (9) | 0.8000 (30) | None | None | None |

`VARIANT_BINDING_WRONG` là một khác biệt thật và có một nguyên nhân: ShaderLab export mang **một**
`GLSLPROGRAM` mỗi pass, không có directive keyword, nên project chỉ compile đúng program đó, và mọi
material của shader vẽ bằng nó bất kể bật gì. Sau sửa §1 exporter chọn đúng base variant (keyword rỗng),
nên material bật `OUTLINE_ON`/`UNDERLAY_ON` (TMP), `UNITY_UI_CLIP_RECT` (TMP Sprite),
`_SOFTPARTICLES_ON`/`_FADING_ON`/`_SURFACE_TYPE_TRANSPARENT` (URP Particles Unlit) vẽ bằng program của
base variant.

Cách sửa đúng là ghi mỗi variant dưới guard của đúng keyword set của nó và khai báo keyword bằng
`shader_feature_local` (để editor chỉ compile tổ hợp material dùng) — không phải `multi_compile` cho
mọi keyword, vì một shader post-processing có hàng chục keyword thì đó là hàng triệu variant. Nhóm các
keyword thành directive (keyword nào loại trừ nhau) không đọc được từ bảng variant mà phải suy ra, nên
chưa làm ở iteration này.

`NO_MARKED_PASS` 310 trên Merge-Room là toàn bộ material của `DELTation/Toon Shader`, được export không
có pass program nào đánh dấu. UNKNOWN, cần đọc riêng.

## 4. `ICompiledShaderProgram`

`CompiledShaderProgram.cs`: `GLSLSourceProgram`, `MetalBinaryProgram`, `DXBCProgram`, `SPIRVProgram`,
`UnknownBinaryProgram`, `StrippedProgram`, mỗi cái có `Kind` và `Recoverability`
(`Source`/`BinaryOnly`/`Stripped`/`Unknown`). Chỉ `GLSLSourceProgram` mang được text, theo cấu trúc: các
kiểu khác không có chỗ để chứa. Metal là `BinaryOnly` bất kể byte trông thế nào — tên bảng của một
Metal library đủ printable để đọc ra như source. DXBC và SPIR-V được nhận bằng signature, không bằng
backend. `ShaderPrograms.json` mang thêm `programKind` và `recoverability` cho mỗi sub-program (có từ
rip sau commit này; các rip 61i trong báo cáo được tạo trước đó).

Test: `ShaderProgramProbeTests` (5 case mới về bảng entry, 3 đỏ khi quay về stride 8),
`CompiledShaderProgramTests` (5 case).

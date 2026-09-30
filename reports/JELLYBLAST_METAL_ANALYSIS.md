# JellyBlast Metal analysis — iteration 063

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Bản rip: `Test/Out63g-i`. Công cụ:
`Test/Scripts/metal_program_report.py`, dump byte `ASSETRIPPER_DUMP_SHADER_PROGRAMS`. Nguyên liệu:
`iterations/063/shader/jellyblast-metal.{json,txt}`.

## 1. Tiền đề của brief — và của chính CLAUDE.md — sai

Brief (§12–§15) giả định chương trình Metal là thư viện biên dịch và yêu cầu mô tả chúng mà không giả vờ
decompile. CLAUDE.md ghi từ iteration 058: "JellyBlast compiles only to Metal, 0 of 1164 sub-programs are
source, and no amount of extraction work will change that", và iteration 059: "Classify by the backend
the asset names, never by the bytes: 870 of them carry enough printable name table to read as source
text otherwise".

Chưa ai mở byte. Dump từng sub-program và đọc chúng nói:

```
ba750a0c 18000000 … ab610000 feca0df0 …          container của Unity, magic 0x0C0A75BA
xlatMtlMain
#include <metal_stdlib>
#include <metal_texture>
using namespace metal;
…
fragment Mtl_FragmentOut xlatMtlMain(
    constant FGlobals_Type& FGlobals [[ buffer(0) ]],
    sampler sampler_MainTex [[ sampler (0) ]],
    texturecube<half, access::sample > _MainTex [[ texture(0) ]] , …
```

**PROVEN**: một chương trình Metal của Unity là **Metal Shading Language source** do HLSLcc sinh, đặt
trong container riêng của Unity; driver Metal compile nó trên thiết bị. Không có header `MTLB` nào. Luật
"backend Metal thì là thư viện" của 059 chính là thứ đã giấu điều này.

## 2. Kiểm kê — MEASURED

| | Số |
|---|---:|
| Entry Metal | 1164 |
| `METAL_SOURCE_AVAILABLE` (MSL trích được) | **780** — 336 vertex, 444 fragment, entry point `xlatMtlMain` ở cả 780 |
| Chương trình khác nhau (theo hash nội dung) | 532 |
| `PARAMETER_BLOCK` (bảng tên hằng: `VGlobals`, `FGlobals`, `unity_ObjectToWorld`…) | 384 |
| `METAL_BINARY_AVAILABLE` (thư viện `MTLB`) | **0** |
| Shader có chương trình Metal | 83, trong đó 27 có material trong bản rip |

Parameter block là nửa kia của bảng blob mà iteration 059 đã tìm ra (`ParameterBlobIndices`): mỗi
sub-program sở hữu một entry code và một entry tham số. Mỗi chương trình ghi: shader, index, offset và
size trong blob của platform, stage, entry point, sha256 (16 ký tự đầu) và các phép toán ngữ nghĩa
(`shader_semantic_ir`, giờ đọc được MSL). Mỗi shader ghi các material trong bản rip dùng nó.

## 3. Pipeline — thay đổi

- `ShaderProgramProbe.ProgramEncoding.MetalSourceText`: backend quyết định họ, byte quyết định thành viên —
  header `MTLB` là thư viện, dòng `#include <metal_stdlib>` là MSL source. Không bao giờ ngược lại.
- `CompiledProgramKind.MslSource`, `ProgramRecoverability.SourceOutsideShaderLab`: là source, nhưng
  ShaderLab không có khối cho MSL — nên được trích ra `AuxiliaryFiles/ShaderPrograms/*.metal` và
  `ShaderVariants/*.metal`, và **không bao giờ** được ghi vào `GLSLPROGRAM`. Pass trong ShaderLab xuất ra
  vẫn là chương trình thay thế và nói rõ điều đó (`shader_semantic_equivalence.py` gọi nó `DUMMY`, đúng).
- Log: "780 Metal Shading Language source, 384 Metal library". 384 đó là parameter block và 4 entry cực
  nhỏ; nhãn "Metal library" ở dòng log là nhãn dự phòng của probe cho một entry Metal không có source,
  `metal_program_report.py` gọi đúng tên chúng.

## 4. METAL_SEMANTIC_MATCH

Không có decompile nào ở đây, nên không có gì để giả vờ. Thứ được so là MSL (chương trình gốc) với
ShaderLab của source: `reports/JELLYBLAST_SHADER_ORACLE.md`. Nơi không có source, `semanticMatch` là
**UNKNOWN**.

## 5. Còn mở

- Đưa MSL về một project dùng được cần dịch MSL → HLSL (HLSLcc chạy ngược). Chưa làm; MSL trích ra là
  nguyên liệu đúng cho việc đó, và là chương trình gốc duy nhất tồn tại (§ shader oracle: source của
  studio không có chúng).
- Một build bật "precompile Metal shaders" sẽ mang `MTLB` thật; nhánh đó giữ nguyên `BinaryOnly`, không
  fixture nào có để kiểm.

# Shader — cấu trúc thật đã về, thân program thì chưa

Iteration 057, §12 đến §17.

## Điều tra: fixture thật sự mang cái gì (§14)

Một `Shader` asset đã serialize mang **toàn bộ ShaderLab trừ mã program**:

| có trong asset | trước 057 |
|---|---|
| `Properties` — tên, kiểu, mặc định, attribute | **được xuất đúng** |
| số subshader, `LOD`, tag của từng subshader | vứt đi |
| số pass, tên pass, kiểu pass (`Normal`/`Use`/`Grab`) | vứt đi |
| tag của từng pass (`LightMode`, `RenderType`…) | vứt đi |
| render state: `Cull`, `ZWrite`, `ZTest`, `AlphaToMask`, stencil, blend | vứt đi |
| keyword của shader và tập keyword của từng biến thể program | vứt đi |
| backend mà từng program được biên dịch sang (`GLES`, `GLES3`) | vứt đi |
| bản thân blob program đã biên dịch | không nạp ở chế độ xuất mặc định |

`DummyShaderTextExporter` dựng lại `Properties` chính xác rồi cho **mọi** shader cùng một pass unlit.
Nó biên dịch được, nên không material nào màu hồng, nên mọi phép kiểm tìm material hồng báo thành công
trong khi shading sai — và người đọc không phân biệt được một shader unlit một pass với một shader
post-processing hai mươi pass.

## Việc đã làm (§13, §15)

`ShaderSemanticModel` đọc tất cả những gì ở bảng trên. `StructuredShaderTextExporter` viết chúng ra.

| fixture | shader | pass được viết trước | sau |
|---|---:|---:|---:|
| RunFromZombies | 24 | 0 | **96** |
| Impostor | 3 | 0 | **3** |
| Merge-Room | 34 | 0 | **48** |
| JellyBlast v2 | 30 | 0 | **29** |

`Hidden/PostProcessing/DepthOfField` giờ có đúng 20 pass của nó, `Bloom` có 9, mỗi pass mang
`Cull Off` / `ZWrite Off` / `ZTest Always` thật của nó. `Properties` không đổi một dòng nào so với
baseline — được kiểm từng shader, không phải giả định.

## Điều KHÔNG làm, và cách bản xuất nói ra điều đó

Thân program **không** được dựng lại. Mỗi pass mang một stage thay thế có dấu
`AssetRipperReplacementProgram` và một comment gọi tên backend mà program thật của nó được biên dịch
sang.

Hai phép đo đọc dấu đó:

- `shader_oracle.py` đặt **trần `PARTIAL`** cho một shader mang dấu ấy. Gọi một bản thay thế là
  `SEMANTICALLY_EQUIVALENT` là đúng cái sai đã gọi một stand-in là recovered, chỉ muộn hơn một bước.
- `validate_unity_stages.py` báo `shader_structure_only` tách khỏi `shader_exact`.

**Và phép đo thứ hai đã bắt được chính lỗi ấy ở lần chạy đầu.** `validate_unity_stages.py` quyết định
"exact" bằng *sự vắng mặt* của dấu `//DummyShaderTextExporter`; khi exporter mới ngừng viết dấu đó, nó
báo `shader_exact 24 of 24`. Đúng cùng một lớp lỗi iteration 056 mất một baseline để tìm: một phép đo
neo vào một chuỗi, và chuỗi đổi. Đã sửa; `shader_exact` trở lại **0** trên cả bốn fixture, và bản thay
thế tự gọi tên mình thay vì được suy ra từ việc thiếu tên người khác.

## Trạng thái

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| `shader_exact` | 0 / 24 | 0 / 3 | 0 / 34 | 0 / 30 |
| `shader_structure_only` | 24 / 24 | 3 / 3 | 34 / 34 | 30 / 30 |
| `shader_dummy` | 0 | 0 | 0 | 0 |

## Vì sao chưa có `SEMANTICALLY_EQUIVALENT` cho program (§15)

Ba rào, theo thứ tự phải vượt:

1. **Chế độ xuất mặc định không nạp blob program.** Mọi `SubPrograms.Count` đọc ra 0 ở bản rip mặc
   định; `--shader-mode Yaml` mới giữ chúng (12 `m_SubPrograms`, 31 blob, 18 `GpuProgramType` trên một
   shader, theo ghi nhận từ iteration 044). Nên bước đầu tiên là *lấy* được dữ liệu, không phải dịch
   nó.
2. **Blob bị nén**, và "GLES nghĩa là GLSL text" **chưa được xác nhận** — `CLAUDE.md` đã ghi rõ điều
   này và iteration 057 không xác nhận thêm được gì, nên nó vẫn là giả định chứ không phải bằng chứng.
3. **Không fixture nào hiện có shader nguồn để đối chiếu.** Project nguồn của RunFromZombies khai báo
   **0** shader, nên `shader_oracle.py` chạy ra `property_recovery_rate: None (0 of 0)`. Không có
   oracle thì không có cách nào phát biểu `SEMANTICALLY_EQUIVALENT` bằng bằng chứng.

Rào 3 là rào rẻ nhất và phải đi trước: một fixture có shader nguồn.

## Material ↔ shader (§16)

`reference_resolution_rate` không đổi (1,0000 / 0,9942 / 0,9998 / 1,0000) — các material vẫn trỏ đúng
shader, và khối `Properties` mà chúng gán vào không đổi một dòng. Việc đối chiếu đầy đủ *tên property
của material ↔ tên property của shader ↔ kiểu ↔ texture binding ↔ điều kiện keyword* mà §16 yêu cầu
thì **chưa làm**: nó cần cùng một oracle mà rào 3 đang chặn.

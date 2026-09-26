# Chương trình shader: mở blob ra, và cái tìm thấy bên trong

Iteration 058. Số đo trên `Test/Out58H-{z,i,m}` và `Test/Out58H-j`.

## 1. Câu hỏi đã mở từ iteration 053

`CLAUDE.md` ghi từ 053 rằng shader của game thử nghiệm chỉ mang `GpuProgramType` 4 và 5 — `GLES3` và
`GLES` — và ghi kèm một cảnh báo: **"blob bị nén, nên 'GLES nghĩa là GLSL text' *chưa* được xác nhận
và không được ghi lại như thể đã biết."** Năm iteration trôi qua mà không ai mở một blob ra.

`ShaderProgramProbe` mở. Nó giải nén LZ4 từng segment của mỗi platform, đọc bảng entry ở đầu blob đã
giải nén, rồi *đo* từng sub-program: tỉ lệ byte in được, các marker của ngôn ngữ shader, 32 byte đầu.
Không có bước nào suy ra encoding từ tên backend.

## 2. Câu trả lời

| fixture | sub-program | mã nguồn | binary | chưa xác định |
|---|---:|---:|---:|---:|
| RunFromZombies | 6704 | **3079** | 3375 | 250 |
| Impostor | 759 | **231** | 528 | 0 |
| Merge-Room | *xem bảng cuối* | | | |
| JellyBlast v2 (iOS) | 1164 | **0** | 798 | 366 |

Trên Android, chương trình GLES **là mã nguồn GLSL nguyên vẹn**, và trong *một* blob có cả hai stage:

```
#ifdef VERTEX
#version 100
uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
attribute highp vec4 in_POSITION0;
void main() { … gl_Position = …; }
#endif
#ifdef FRAGMENT
#version 100
void main() { SV_Target0 = …; }
#endif
```

Đó chính xác là dạng khối `GLSLPROGRAM` của Unity nhận. Nên phục hồi chương trình shader ở đây là
**trích xuất, không phải dịch ngược**, và `StructuredShaderTextExporter` viết thẳng nó vào pass.

## 3. Trên iOS thì không

JellyBlast v2 biên dịch **chỉ sang Metal**: 798 binary, 366 in được nhưng không mang marker nào của
ngôn ngữ shader, 0 mã nguồn. Metal là một định dạng thư viện đã biên dịch; không có văn bản để trích
xuất, và không có lượng công sức nào ở phía trích xuất lấy được nó. Muốn đi tiếp trên iOS thì cần một
trình dịch ngược Metal, và đó là một dự án khác.

Đây là lý do `shader_semantic_equivalence.py` trả `FALLBACK` cho fixture đó chứ không phải một mức độ
thành công nào.

## 4. Ba thứ phải sửa trước khi con số nào đáng tin

Cả ba đều là phép đo tự báo mình sai, và cả ba đều đọc giống hệt một khiếm khuyết của bản phục hồi.

**Từ Unity 2021 sub-program chuyển chỗ.** `m_SubPrograms` rỗng và dữ liệu nằm ở `m_PlayerSubPrograms`
— một danh sách mỗi hardware tier, kiểu khác (`SerializedPlayerSubProgram`) nhưng mang đúng bốn
trường cần dùng. Chỉ đọc danh sách đầu thì mọi pass báo `Vertex 0 variant(s) []` trên shader có hàng
trăm biến thể, và **không pass nào ghép được về chương trình đã biên dịch của nó** — 0 chương trình
phục hồi trên một bản rip có 3079 chương trình đọc được.

**Marker phải tìm trên toàn bộ sub-program.** Một byte không in được nằm giữa mã nguồn cắt đoạn in
được làm đôi, và tìm chỉ trong đoạn dài nhất báo một chương trình rõ ràng là text thành
`PRINTABLENOMARKERS`.

**Text lấy ra phải dừng ở hết đoạn in được chứa marker.** Vài entry trong bảng của shader lớn có
`length` chạy tới cuối blob của platform; lấy tới byte in được cuối cùng của khoảng đó kéo theo mọi
thứ nằm sau chương trình — một "shader" 8 MB, và 3 GB cho một bản rip, đủ để lấp đầy đĩa.

## 5. Cái còn lại chưa phục hồi được

Một pass chỉ viết ra được chương trình thật nếu entry tại `BlobIndex` của một biến thể của nó đọc ra
mã nguồn. Trên RunFromZombies, `Hidden/PostProcessing/Bloom` có pass trỏ tới blob 1 (152 byte, binary)
và blob 2 (0 byte) — những entry đó không phải chương trình. Bảng entry xen kẽ chương trình với thứ
khác; `ISerializedProgram.ParameterBlobIndices` là ứng viên rõ nhất cho phần "thứ khác" và chưa được
đọc. Đó là việc của iteration sau, và nó được báo như một giới hạn chứ không được đoán.

Một pass đã phục hồi chỉ viết ra **một** biến thể, và comment nói rõ là biến thể thứ mấy trên tổng
bao nhiêu. ShaderLab không mang được tất cả các biến thể keyword trong một khối, và viết một trong
nhiều như thể nó là cả pass thì không trung thực.

## 6. Hạn mức

Mã nguồn trích ra đi vào từng file rời dưới `AuxiliaryFiles/ShaderPrograms/`, có hạn mức 128 MB và
báo lại số bị bỏ. Báo cáo JSON vẫn ghi vị trí, kích thước và encoding của *mọi* sub-program, nên
không mất gì về mặt phân tích.

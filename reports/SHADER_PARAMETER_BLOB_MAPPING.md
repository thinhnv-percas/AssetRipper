# Bảng blob của shader: chương trình và khối tham số, chứng minh bằng chính asset

Iteration 059, §11. Sinh bởi `ShaderBlobMapping`, ra `AuxiliaryFiles/ShaderBlobMapping.json`.

## 1. Câu hỏi bỏ ngỏ từ iteration 058

058 giải nén blob của từng platform và đọc bảng entry ở đầu, rồi thấy nó **xen kẽ**: một số entry là
mã nguồn GLSL, một số là khối nhị phân nhỏ, một số rỗng. Kết luận lúc đó là "bảng entry xen kẽ chương
trình với thứ khác, và `ISerializedProgram.ParameterBlobIndices` là ứng viên rõ nhất chưa được đọc".

Nó đã được đọc. Kiểu của nó là `AssetList<AssetList<uint>>` — một danh sách **mỗi hardware tier**,
bên trong là một chỉ số **mỗi sub-program**, tức song song chính xác với `m_PlayerSubPrograms`. Vậy
một sub-program sở hữu **hai** entry: mã đã biên dịch của nó, và khối tham số của nó.

## 2. Bằng chứng: hai tập chỉ số không giao nhau

Với mỗi cặp (shader, backend), lấy tập `BlobIndex` của mọi sub-program và tập
`ParameterBlobIndices` của chính chúng:

| fixture | cặp (shader, backend) | cặp có giao nhau |
|---|---:|---:|
| RunFromZombies (GLES, GLES3, Vulkan) | 148 | **0** |
| JellyBlast v2 (Metal) | 166 | **0** |

**PROVEN.** Không một entry nào vừa là chương trình của một sub-program vừa là khối tham số của một
sub-program khác, trên hai build khác nhau, hai nền tảng khác nhau, ba họ backend khác nhau. Bảng
entry là một kho duy nhất được đánh địa chỉ bởi hai danh sách chỉ số, và chúng phân hoạch nó.

Ví dụ `Standard` trên RunFromZombies, backend GLES3: chỉ số tham số là 0..95, chỉ số chương trình bắt
đầu từ 96. Ví dụ `Hidden/PostProcessing/Bloom`, GLES: tham số `{0}`, chương trình `{1..9}`.

## 3. Vậy 13 shader không có chương trình nào là vì sao

Không phải vì đọc sai bảng. Trên RunFromZombies, trong 13143 hàng sub-program:

| | số hàng |
|---|---:|
| entry chương trình đọc ra **mã nguồn** | 7153 |
| entry chương trình là nhị phân | 5296 |
| — trong đó **kích thước 0** | 2523 |
| — kích thước 1 | 1241 |
| entry chương trình không có trong bảng | 195 |

2523 + 1241 hàng có chương trình **rỗng**: biến thể đó đã bị strip khỏi build. Đó là một sự thật về
build, không phải một thất bại của phục hồi.

Đếm theo pass: **87 pass được xuất ra ShaderLab, 43 có ít nhất một biến thể đọc ra mã nguồn, và
exporter viết ra đúng 43 khối GLSL.** Độ phủ so với trần đạt được là 100%.

## 4. Biến thể (§12)

Trước 059, mỗi pass viết ra một biến thể và phần còn lại không đi đâu cả. Giờ:

- ShaderLab mang **biến thể gốc** — biến thể biên dịch với tập keyword rỗng, chứ không phải biến thể
  đầu tiên tình cờ đọc ra mã nguồn — và comment ghi rõ nó là biến thể mấy trên tổng bao nhiêu, kèm
  danh sách các tập keyword của pass.
- `AuxiliaryFiles/ShaderVariants.json` ánh xạ **mọi** biến thể: shader, subshader, pass, stage,
  backend, tập keyword, blob index, kích thước, và file chứa mã nguồn.
- Mã nguồn được khử trùng lặp **theo nội dung**, không theo tập keyword: trên RunFromZombies
  **7153 biến thể phục hồi được, 1312 chương trình khác nhau** — 82% biến thể dùng chung chương trình
  với một biến thể khác. Khử theo tập keyword sẽ mất thông tin keyword nào dẫn tới chương trình nào;
  khử theo nội dung thì không.

## 5. iOS

`MetalVS` và `MetalFS` không có trong bảng ánh xạ backend → platform, nên **toàn bộ 2532 hàng của
JellyBlast báo `NOT_IN_TABLE`** — một con số nói về việc bảng chưa được tra, không nói gì về build.
Thêm vào rồi thì: 0 mã nguồn, **1164/1164 sub-program là thư viện Metal**.

Phân loại đó đọc từ *backend mà asset gọi tên*, không từ byte: 870 trong số đó có bảng tên hàm đủ
in được để một phép tìm marker đọc nhầm thành text. Bằng chứng từ asset mạnh hơn một phép quét byte.

`IMetalShaderDecompiler` được **khai báo và cố ý không hiện thực**. `MetalShaderLibrary.Read` báo lại
những gì byte tự nói: có header `MTLB` hay không, ở đâu, dài bao nhiêu, tên hàm nào. Trên fixture này
không có header `MTLB` — Unity không giữ nó — nên trạng thái là `BINARY_ONLY_NO_DECOMPILER`, và
verdict của shader là `METAL_BINARY_ONLY`, quyết **trước** khi tìm oracle, vì "build này chỉ biên dịch
sang Metal" đúng bất kể có nguồn hay không.

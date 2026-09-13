# Truy nguyên nguồn gốc của unresolved load

Iteration 040, phần B. Fixture Impostor (`Test/Output-040b`), ARM64, metadata v31.1, commit gốc
`03408625`. **2756 load, tất cả đều được phân loại**, `generatorFailures` = 0.

Đây là một phép đo, không phải một bản sửa. Brief nói rõ: báo cáo phân bố mới trước, không patch.

## 1. Vì sao cần một cột nữa

Mọi cột khác của `CPP2IL_DUMP_LOADS` mô tả load **tại chỗ generator bỏ cuộc**. Đó là đúng chỗ để
*đếm* nó và sai chỗ để *giải thích* nó. Một base có kiểu `object` nằm sau ba lần copy kể từ một lệnh
gọi chưa phân giải không nói gì về lệnh gọi đó.

Trong dự án này việc gom theo triệu chứng đã **bốn lần** cho ra một họ hoá ra là nhiều nguyên nhân
không liên quan: 850 load "past the last field" (bốn nguyên nhân), 245 "frame-pointer spill" (ba),
124 "X8/X27 trỏ vào stack slot" (kết luận đã ghi là *sai cả hai tiền đề*), và cluster G của iteration
039 (55% là hoãn lại chứ không phải nguyên nhân mới).

Cột `RootCauseOrigin` đi ngược các định nghĩa — qua một phép copy, qua phía base của một phép cộng,
qua mọi input của một phi — rồi phân loại thứ mà đường đi kết thúc ở đó.

## 2. Phân bố

| Nguyên nhân | Số | % |
|---|---:|---:|
| `RUNTIME_STRUCT` | 684 | 24,8% |
| `TYPE_PROPAGATION` | 486 | 17,6% |
| `PAST_LAST_FIELD` | 469 | 17,0% |
| `MISSING_METADATA` | 378 | 13,7% |
| `GENERIC_LAYOUT` | 277 | 10,0% |
| `ARRAY_ELEMENT` | 250 | 9,1% |
| `UNKNOWN` | 188 | 6,8% |
| `PHI_AMBIGUITY` | 24 | 0,9% |

Chi tiết, là bằng chứng cho từng nhãn:

| Chi tiết | Số |
|---|---:|
| `RUNTIME_STRUCT:RuntimeClassTypeAnalysisContext` | 512 |
| `PAST_LAST_FIELD:value-type` | 312 |
| `TYPE_PROPAGATION:entry-value` | 290 |
| `GENERIC_LAYOUT:instantiation` | 277 |
| `ARRAY_ELEMENT:array-typed-base` | 221 |
| `TYPE_PROPAGATION:address-of` | 177 |
| `MISSING_METADATA:offset-within-the-layout-and-on-no-field` | 177 |
| `MISSING_METADATA:base-type-declares-no-field-offsets` | 165 |
| `PAST_LAST_FIELD:class` | 157 |
| `RUNTIME_STRUCT:StaticFieldStorageTypeAnalysisContext` | 103 |
| `UNKNOWN:absolute-address` | 69 |
| `RUNTIME_STRUCT:RuntimeMethodInfoAnalysisContext` | 69 |
| `UNKNOWN:add-of-MemoryOperand` | 52 |
| `MISSING_METADATA:unresolved-call-result` | 36 |
| `ARRAY_ELEMENT:computed-element-address` | 29 |
| còn lại | 102 |

## 3. Điều cột này nói mà cột hình dạng không nói

Bảng chéo *hình dạng × nguyên nhân* là chỗ trả công của cả việc này.

**Họ "past the last field of the base type" tách làm đôi.** 301 load mang tên đó, và truy nguyên
cho hai câu trả lời khác nhau:

| | Số |
|---|---:|
| `PAST_LAST_FIELD` — thật sự quá field cuối | 147 |
| `MISSING_METADATA:base-type-declares-no-field-offsets` | 154 |

154 cái sau có base **không ghi offset cho một field nào cả**, nên `largest` bằng 0 và *mọi* addend
dương đều "quá field cuối". Đây không phải một lỗi layout; đây là metadata không có. Đúng cùng một
phát hiện mà `reports/BASE_FIELD_OVERFLOW_ANALYSIS.md` đã ghi cho họ 850 trước đây (361 cái "không
có field nào để mà quá"), lần này rơi ra từ phép đo thay vì phải phân loại tay.

**Họ "value type base" cũng tách làm đôi**: 97 `MISSING_METADATA` / 90 `PAST_LAST_FIELD`.

**Và chiều ngược lại:** nhiều load bị hình dạng gọi là "base has no type" thật ra có nguyên nhân
xác định. `Add of Single[] and Immediate` (46), `Add of Vector3[] and Int32` (38),
`Add of Single[] and Int32` (38) đều là `ARRAY_ELEMENT` — địa chỉ phần tử mà cột hình dạng chỉ
biết nói là "không có kiểu".

## 4. Theo assembly

| Assembly | Load | Nguyên nhân lớn nhất |
|---|---:|---|
| spine-unity | 1125 | `TYPE_PROPAGATION` 291, `RUNTIME_STRUCT` 288, `PAST_LAST_FIELD` 224 |
| DOTween | 790 | `GENERIC_LAYOUT` 249, `MISSING_METADATA` 157, `PAST_LAST_FIELD` 122 |
| Assembly-CSharp | 274 | `TYPE_PROPAGATION` 106, `RUNTIME_STRUCT` 85 |
| ACTk.Runtime | 186 | `RUNTIME_STRUCT` 76, `MISSING_METADATA` 69 |
| spine-unity-examples | 179 | `PAST_LAST_FIELD` 74, `TYPE_PROPAGATION` 48 |
| GoogleMobileAds | 167 | `RUNTIME_STRUCT` 89 |

Assembly-CSharp giữ dưới một phần mười tổng số, đúng như đã ghi trong CLAUDE.md. `GENERIC_LAYOUT`
gần như toàn bộ nằm ở DOTween (249/277): đó là một thư viện generic nặng, nên một luật về layout của
instantiation sẽ đo được ở đó chứ không ở Assembly-CSharp.

## 5. Một kết quả âm tính phải ghi lại: **phi không còn tồn tại ở điểm đo này**

Brief yêu cầu xử lý phi, và code có xử lý. Nhưng đo ra thì **0 dòng nào trong 2756 đi qua một phi**:
cột `baseDefinition` không có lấy một `Phi` nào. Lý do là SSA đã bị destruct trước khi `IlGenerator`
chạy, nên tới điểm này trong pipeline không còn phi nào sống sót.

24 `PHI_AMBIGUITY` đều là `multiple-definitions` — tức một local có nhiều hơn một định nghĩa sau khi
SSA đã bị phá, đúng cái bẫy CLAUDE.md đã ghi ("phải đánh dấu mọi định nghĩa của một local, không chỉ
cái cuối"). Cơ chế hợp nhất bất đồng *có* chạy, chỉ là qua đường đó.

Nhánh phi được giữ lại vì nó đúng và sẽ chạy nếu phép đo dời lên sớm hơn trong pipeline, nhưng phải
ghi rõ ở đây rằng **ở vị trí hiện tại nó không bao giờ chạy** — đây đúng là hình dạng "một pass không
bao giờ chạy" mà dự án đã nhiều lần bị mắc.

## 6. Giới hạn của phép đo

- **`MISSING_METADATA:unresolved-call-result` chỉ có 36**, thấp đáng ngờ so với 290
  `TYPE_PROPAGATION:entry-value`. Cả hai đều bắt nguồn từ lệnh gọi chưa phân giải; sự khác nhau là
  entry-value không có định nghĩa nào để đi ngược. Chưa phân biệt được bao nhiêu trong 290 đó là do
  một lệnh gọi chưa phân giải giữ nguyên cả file thanh ghi.
- **`UNKNOWN:add-of-MemoryOperand` (52) và `add-of-FieldReference` (25)** là phép cộng mà cả hai phía
  đều không phải local — đường đi dừng ở đó. Có thể đi tiếp, chưa làm.
- Nhãn gán cho một base *có kiểu* dựa trên cùng bảng field mà cột hình dạng dùng, nên nó thừa hưởng
  mọi giới hạn của bảng đó.

## 7. Không sửa gì trong iteration này

Theo brief §12. Phân bố ở trên là đầu vào cho việc chọn cluster tiếp theo, không phải giấy phép để
patch cluster nào.

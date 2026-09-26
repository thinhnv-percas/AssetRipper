# Iteration 059 — trung thực về hành vi, và bảng blob của shader

Mỗi kết luận dưới đây mang một nhãn: **PROVEN** (chứng minh bằng dữ liệu của chính asset hoặc bằng
một phép kiểm phân biệt được), **MEASURED** (đo trên fixture), **INFERRED** (suy ra, chưa chứng
minh), **UNKNOWN**, **BLOCKED**.

## 1. Baseline

Baseline là bản rip cuối của iteration 058, `Test/Out58H-*`, tại commit `7babffb8`. Bản rip của 059 là
`Test/Out59F-*`, đo sau khi tiến trình thoát. Không có bản rip nào pha trộn binary cũ và mới: mỗi lần
đo trung gian trong iteration này chạy trên một binary đã build xong trước khi rip bắt đầu.

## 2. Giả thuyết của brief, và cái dữ liệu nói

Brief §7 đặt "197 `FALLBACK` và 16 `MISMATCH` của Merge-Room, phần lớn mang dấu `loops: source N,
recovered 0`" làm ưu tiên cao nhất của method recovery, và yêu cầu truy từ native instruction xuống
tới nơi vòng lặp biến mất.

**Tiền đề đó sai, và dữ liệu bác bỏ nó ngay ở bước đầu.** Trong 192 hàng `FALLBACK`, **chỉ 6 hàng có
nguồn chứa vòng lặp**. Và hai ví dụ đầu tiên mở ra thì bản phục hồi *chính xác tuyệt đối*:

```
DeviceInfo.IsIOS()                       ES3Stream.CopyTo(Stream, Stream)
  nguồn:  #if UNITY_EDITOR …  #endif       nguồn:  #if UNITY_2019_1_OR_NEWER
          #if UNITY_IOS  return true;                  source.CopyTo(destination);
          #else          return false;                 #else   <một vòng while>
          #endif                                       #endif
  phục hồi: return false;                  phục hồi: source.CopyTo(destination);
```

Cả hai là **đúng**. Cái sai là phép đo: nó đọc toàn văn file nguồn và so với một bản phục hồi của
*một* nhánh. Một file C# thường xuyên là ba chương trình cùng lúc.

**PROVEN.** `Test/Scripts/source_preprocessor.py` rút file về chương trình mà build đã biên dịch, với
bảng ký hiệu chỉ gồm những thứ *suy ra được* từ hai sự thật về fixture: nền tảng nó build cho, và
phiên bản Unity. `UNITY_EDITOR` là false — dự án này đã ghi điều đó như một sự thật từ iteration 030.
Một ký hiệu **không xác định được thì giữ cả hai nhánh**, nên sai số nghiêng về phía báo mất mát, là
phía tốn thời gian của người đọc chứ không phải phía đánh lừa họ.

## 3. Method: một lifted local sống ở đúng một chỗ

**PROVEN.** Iteration 058 sửa *một* trong ba site quyết định chỗ ở của một lifted local. Site ghi vẫn
`stloc` vào một local generator tự bịa trong khi site đọc `ldarg` vào tham số — hai chỗ chứa cho một
giá trị.

| | trước | sau |
|---|---|---|
| `TimeCheatingDetector` | `reference = ref *(OnlineTimeResult*)1` | `result = ref *(…)` |
| `ObscuredBool` | `ref byte reference = ref *(byte*)…` | `key = ref *(byte*)…` |

46 file đổi nội dung trên Impostor — fixture tất định — và **mọi con số tổng y nguyên** (5482 method,
4293 placeholder, EXACT 3782). Đó là hình dạng của một bản sửa tính đúng đắn: cùng số lệnh, khác chỗ
ghi. Một tham số `ref`/`out` được gán vào một local mà người gọi không bao giờ thấy.

`LocalStorage.For` là **một** luật, và cả `LoadLocal`, `StoreLocal` lẫn `LoadLocalAddress` đều hỏi nó.
Bảy ca test, một trong đó phát biểu thẳng bất biến mà hai iteration đã vi phạm. `check_recovered_shapes.sh`
DECOMP-0022 giữ nó lại.

## 4. Method: phân loại con trỏ thành một phân tích hạng nhất

**MEASURED.** `PointerClassifier` trả lời "con trỏ này trỏ vào cái gì và được dựng ra thế nào", với
các kind của §5 và coordinate frame. Ba thứ phải phân biệt và hai thứ đầu dùng chung kiểu tĩnh: mảng
nền `list._items`; địa chỉ phần tử `&list._items[i]`; và chính cái list.

`InlineListAddRecovery` **không được nới** — 1346 candidate, 820 gấp, 526 từ chối, y như 058. Cái đổi
là lý do từ chối nay đọc từ phân tích, và họ "133 element address" của 058 tách ra:

| | |
|---|---|
| element address thật, kèm đường đi | `v242[i][i]`, `v246[i][i]`, … |
| `[This/ObjectRelative this+32]` ×16 | **không phải** element address: một field ở offset 0x20 của receiver chưa phân giải được |
| receiver là kết quả một lời gọi | 35 |
| receiver là một cấp phát mới | 15 + 10 + … |

Nhóm `this+32` là phát hiện: câu chuyện "địa chỉ phần tử" không áp dụng ở đó, và trước 059 nó nằm lẫn
trong cùng một họ.

## 5. Shader: bảng blob phân hoạch, chứng minh được

**PROVEN.** `ISerializedProgram.ParameterBlobIndices` là `AssetList<AssetList<uint>>`, song song
chính xác với `m_PlayerSubPrograms`: một sub-program sở hữu **hai** entry, mã đã biên dịch và khối
tham số. Với mỗi cặp (shader, backend), hai tập chỉ số **không giao nhau một lần nào** — 148 cặp trên
RunFromZombies, 166 cặp trên JellyBlast.

Kéo theo: 13 shader không có chương trình nào **không** do đọc sai bảng. 2523 entry chương trình có
kích thước 0 và 1241 có kích thước 1 — biến thể bị strip khỏi build. Đếm theo pass: 87 pass xuất ra,
**43 có ít nhất một biến thể là mã nguồn, và exporter viết đúng 43 khối GLSL** — trần đạt được đã đạt
100%.

`reports/SHADER_PARAMETER_BLOB_MAPPING.md` là bản đầy đủ.

## 6. Shader: mọi biến thể

**MEASURED.** ShaderLab nay mang **biến thể gốc** (tập keyword rỗng) chứ không phải biến thể đầu tiên
tình cờ đọc ra mã nguồn, kèm danh sách tập keyword của pass. `AuxiliaryFiles/ShaderVariants.json` ánh
xạ mọi biến thể tới file mã nguồn của nó: trên RunFromZombies **7153 biến thể, 1312 chương trình khác
nhau** — 82% biến thể dùng chung chương trình với một biến thể khác. Khử trùng lặp **theo nội dung**,
không theo tập keyword, để không mất thông tin keyword nào dẫn tới chương trình nào.

## 7. Shader: iOS

**PROVEN.** `MetalVS`/`MetalFS` thiếu trong bảng ánh xạ backend → platform, nên cả 2532 hàng của
JellyBlast báo `NOT_IN_TABLE` — một con số nói rằng bảng chưa được tra. Thêm vào rồi:
**1164/1164 sub-program là thư viện Metal**, phân loại theo backend mà *asset gọi tên* chứ không theo
byte — 870 trong số đó có bảng tên hàm đủ in được để một phép tìm marker đọc nhầm thành text.

`IMetalShaderDecompiler` được khai báo và **cố ý không hiện thực**. Verdict `METAL_BINARY_ONLY` quyết
**trước** khi tìm oracle, vì "build này chỉ biên dịch sang Metal" đúng bất kể có nguồn hay không.

## 8. Số cuối, và cái gì so được

Xem `docs/RECOVERY_MATRIX.md`. Hai điều phải nói ra:

**Oracle hành vi Merge-Room đi 0,6951 → 0,7284**, `FALLBACK` 197 → 114, `MISMATCH` 16 → 15. Phần lớn
chuyển động đó là **phép đo trở nên trung thực** (preprocessor + bằng chứng inline), không phải phục
hồi tốt lên. Phần thật sự của phục hồi là bản sửa ở mục 3, và nó không đổi một con số đếm nào.

**Verdict shader so được với 058 chỉ ở `shader_exact` (0 ở cả hai).** Trước 059 phép so đọc toàn văn
shader nguồn; nay nó so với **biến thể gốc**, vì đó là biến thể mà ShaderLab xuất ra mang. Merge-Room
đi 1/7 → 3/7 vì lý do đó: `TextMeshPro/Distance Field` mất `SIN`/`COS` chỉ vì chúng nằm dưới một
keyword mà biến thể gốc không bật.

`Graphy/Graph Mobile` vẫn `PARTIAL` và đó là câu trả lời **đúng**: nó lấy mẫu `_AlphaTex` dưới
`#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED`, một macro nền tảng mà không có gì trong repo này xác định
được cho build đó. Giữ cả hai nhánh và báo `PARTIAL` là trung thực; xoá nó đi để lấy một
`SEMANTICALLY_EQUIVALENT` thì không.

## 9. Unity

**BLOCKED.** Unity không có trong container: stage E–I `BLOCKED`, `runtime_status: NOT_RUN`. Không có
tuyên bố runtime nào.

## 10. Giới hạn đã biết

- 25 shader URP của Merge-Room vẫn `NO_SOURCE_ORACLE`: registry công khai trả 404 cho
  `com.unity.render-pipelines.universal@14.0.12`. **BLOCKED**, thiếu oracle chứ không thiếu phục hồi.
- 136 site `List<T>.Add` "guard does not end in a conditional branch" vẫn chưa phân loại. **UNKNOWN**.
- Corpus hành vi không bắt được lỗi ở mục 3, vì nó đổi *giá trị được ghi* chứ không đổi *thao tác*.
  Cùng lý do với 058. Hai phép đo phân công như vậy và cần cả hai.

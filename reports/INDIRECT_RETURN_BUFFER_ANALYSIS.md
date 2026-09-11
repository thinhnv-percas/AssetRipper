# DECOMP-0022 nhóm B — không phải số học trên stack, mà là buffer trả về gián tiếp

Iteration 036. Fixture chính: `Test/Input/Impostor` (ARM64, metadata v31.1). Cổng kiểm chứng độc
lập: `Test/Input/Pinata` (x86, metadata v24.2).

## 1. Kết luận ngắn: phân loại cũ sai

`reports/FRAME_SLOT_ANALYSIS.md` xếp 124 load vào "nhóm B — X8/X27 trỏ vào một stack slot đã biết",
và kết luận:

> `&stack_-88 + 0x14` là **chính xác** `stack_-74`, bằng số học trên layout frame đã biết […] Cái khó
> duy nhất còn lại là **chọn version SSA** của slot đích.

**Cả tiền đề lẫn cái khó đều không đúng.** Truy vết ISIL cho thấy:

- `X8` không phải một thanh ghi trỏ vào slot bất kỳ. Trên AAPCS64 nó là **indirect result register**:
  một struct quá lớn để trả về trong thanh ghi được trả về qua bộ nhớ, caller đặt địa chỉ một stack
  slot vào X8 và callee ghi giá trị vào đó.
- Các slot đích **không hề tồn tại**. Không lệnh nào ghi `stack_-84`, `stack_-80`, … dưới tên của
  chúng — callee ghi cả khối. Nên không có version SSA nào để chọn, và cũng không có slot đích đã có
  kiểu nào để đáp xuống.
- Câu trả lời đúng không phải số học trên frame mà là **giá trị trả về của lệnh gọi**, thứ mà chính
  lệnh gọi đã đặt tên qua toán hạng kết quả của nó. `[buffer + k]` là field ở offset `k` của giá trị
  đó — và nó có **kiểu**, điều mà số học trên slot không bao giờ cho được.

Đếm lại theo thanh ghi của base thay vì theo hình dạng chung: trong 211 load có base là
`AddressOf(stack_…)`, **121 đi qua X8** (buffer trả về) và **89 đi qua X29** (frame pointer, tức
nhóm A/C), 1 qua X27.

## 2. Bằng chứng

`ObscuredDouble::op_Increment` là toàn bộ hình dạng trong sáu lệnh:

```
7  Move v10 @ X8_v1, &v11 @ stack_-40
13 Call ObscuredDouble.Increment, returnVal1 @ X0_v2 (ObscuredDouble), &v7 @ V2_v1, 1d
29 Move returnBuffer.hiddenValueOldByte8 (ACTkByte8), [v10 @ X8_v1+10]
30 Move returnBuffer.fakeValue (System.Double), [v10 @ X8_v1+20]
31 Move returnBuffer.currentCryptoKey (System.Int64), [v10 @ X8_v1]
35 Return returnVal1 @ X0_v2 (ObscuredDouble)
```

Nguồn là `public static ObscuredDouble operator ++(ObscuredDouble input) => Increment(input, 1);`.

Điểm quyết định: **phía ghi của chính ba lệnh đó đã đặt tên đúng các offset ấy** —
`returnBuffer.currentCryptoKey` ở 0x0, `hiddenValueOldByte8` ở 0x10, `fakeValue` ở 0x20, là ba field
của `ObscuredDouble`. Cùng một struct ở cả hai đầu, nên ánh xạ offset → field được xác nhận độc lập
chứ không phải do pass này giả định.

Đầu ra trước khi sửa:

```csharp
ObscuredDouble result = Increment((ObscuredDouble)(&num), 1.0);
NoteDecompilerIssue("Unmanaged memory load: [v10 @ X8_v1+10]");
((ObscuredDouble*)(nint)obscuredDouble)->hiddenValueOldByte8 = (ACTkByte8)0;
NoteDecompilerIssue("Unmanaged memory load: [v10 @ X8_v1+20]");
((ObscuredDouble*)(nint)obscuredDouble)->fakeValue = 0.0;
((ObscuredDouble*)(nint)obscuredDouble)->currentCryptoKey = (long)obj;   // obj = default(object)
```

**Mọi field được gán số không.** Đây không phải một load bị báo thiếu — đây là một chương trình sai
một cách im lặng. Sau khi sửa:

```csharp
ObscuredDouble result = Increment((ObscuredDouble)(&num), 1.0);
((ObscuredDouble*)(nint)obscuredDouble)->hiddenValueOldByte8 = result.hiddenValueOldByte8;
((ObscuredDouble*)(nint)obscuredDouble)->fakeValue = result.fakeValue;
((ObscuredDouble*)(nint)obscuredDouble)->currentCryptoKey = result.currentCryptoKey;
```

`GameHelper.SetSizeByWidth` là ví dụ thứ hai, và nó cho thấy cái giá thật của họ lỗi này:

```csharp
// trước
NoteDecompilerIssue("Unmanaged memory load: [v.. + C]");
nint num2 = 0;
object obj3 = num2 + 0;
object obj4 = (nint)obj / (nint)obj3;      // chia cho số không
sizeDelta.y = (float)obj5;

// sau
float num2 = bounds.m_Extents.x + bounds.m_Extents.x;
float num3 = (float)obj / num2;
float y = num3 * (float)maxWidth;
sizeDelta.y = y;
```

`Sprite.bounds.extents.x * 2` là chiều rộng của sprite. Bản cũ đọc nó là số không và làm toán trên
native integer; năm chẩn đoán `Expected O, but got I` còn lại một.

## 3. Pass đã cài — `IndirectReturnBufferRecovery`

Chạy **trước** `LocalVariables.ResolveTypesAndFields` (để base sau khi viết lại được gán kiểu và
field được phân giải bởi chính fixpoint đã có, không cần fixpoint thứ hai) và **sau**
`MetadataResolver.ResolveAll` (để callee đã được phân giải).

Điều kiện, toàn bộ là bằng chứng chứ không phải hình dạng:

1. `Move buffer, AddressOf(slot)` với `buffer` là local.
2. Có **đúng một** lệnh gọi sau đó mà callee trả về qua hidden buffer và thanh ghi buffer của nó
   trùng thanh ghi của `buffer`. Hai lệnh gọi nghĩa là buffer bị dùng lại và một lệnh đọc về sau có
   thể thuộc về giá trị nào cũng không quyết định được → bỏ cả buffer.
3. Không có lệnh nào ghi `slot` dưới **tên của chính nó** trong khoảng giữa phép lấy địa chỉ và lệnh
   gọi. Sau lệnh gọi thì không tính: compiler thường xuyên dùng lại chính ô stack đó để giữ thứ vừa
   đọc ra, và SSA version hoá phép ghi ấy hoàn toàn được.
4. Chỉ viết lại các lệnh **đọc** bị lệnh gọi **thống trị** (dominate). Trong cùng một block là thứ tự
   lệnh; khác block là dominance, nên một lệnh đọc nằm trên đường đi không qua lệnh gọi thì không
   được tính là sau nó.
5. Không viết lại phía ghi qua buffer (đó là việc của callee), và không viết lại `[buffer + index*scale]`
   (không phải một thành viên cố định).

Thanh ghi nào là buffer đọc từ **calling convention của chính callee**
(`CallingConventionResolver.HiddenReturnBufferRegister`), không phải từ một cái tên viết cứng ở đây —
nên kiến trúc nào trả về struct lớn theo cách khác thì không khớp gì cả và được để yên. Đó cũng là lý
do pass này chạy đúng trên cả ARM64 lẫn x86 mà không cần một nhánh nào theo kiến trúc.

## 4. Đo

**Android (Impostor, ARM64)** — baseline là iteration 035:

| | 035 | 036 |
|---|---:|---:|
| unresolved loads | 2870 | **2773** (−97) |
| họ `AddressOf(stack_…)` qua X8 | 121 | **10** |
| REAL_ERROR (audit) | 884 | **861** (−23) |
| ├ unresolved_load | 230 | **212** |
| ├ nint_cast | 248 | **242** |
| ├ type_mismatch | 285 | 286 (+1) |
| SEMANTIC_RISK | 167 | 170 (+3) |
| └ mangled_ctor | 4 | **7 (+3)** |
| generator failures | 0 | 0 |
| file `.cs` | 819 | 819 |
| shape checks | 16 PASS | 16 PASS |

**Pinata (x86, metadata v24.2)** — cổng kiểm chứng độc lập, kiến trúc và codegen khác hẳn:

| | baseline | 036 |
|---|---:|---:|
| unmanaged memory loads | 9177 | **9061** (−116) |
| method not found | 4052 | 4052 |
| file `.cs` | 3083 | 3083 |
| generator failures | 0 | 0 |

Test suite: 296 → **307** test (thêm 11), 306 pass, 1 fail có sẵn từ trước
(`GetMainExportID_ValueGreaterThan100000_DebugAssertFails`).

Roslyn: **NOT RUN** — `Test/Scripts/compile_recovered_scripts.sh` báo "no Roslyn csc.dll under the
.NET SDK" trong môi trường này. Không giả lập kết quả.

## 5. `mangled_ctor` 4 → 7 — nói thẳng cái giá

Ba file (`ItemArtifact`, `ItemDistinc`, `ItemStack`) mọc thêm một `base._002Ector()`, là hình dạng C#
không viết được. Cơ chế, truy ra đến tận nơi:

```
8  Move v11 (Int32), v10.currentCryptoKey (Int32)      ← đọc offset 0, giờ đã có kiểu
20 Move this.level (ObscuredInt), v11 (Int32)          ← stack type mismatch
```

CLAUDE.md đã ghi: **ILSpy không gấp được lệnh gọi base trong một thân hàm mang stack type mismatch**,
ở vị trí nào cũng vậy. Nên mismatch ở lệnh 20 sinh ra `base._002Ector()`.

Lỗi thật nằm ở **phía đích**, không phải phía nguồn: máy ghi 4 byte vào field `level` dài 24 byte, nên
đích đúng phải là `this.level.currentCryptoKey` chứ không phải `this.level`. Đó là họ "một phép ghi có
thể hẹp hơn field mà offset của nó đặt tên" — mặt trái của DECOMP đã ghi về `strh` — và
`MetadataResolver.FindNestedFieldPath` là chỗ nó thuộc về. Pass này không tạo ra lỗi đó; nó làm lỗi
đó **hiện ra**, vì trước đây phía nguồn là `object` nên ILSpy không coi là mismatch.

So sánh hai bản trên chính `ItemDistinc..ctor` (nguồn gần như chắc chắn là `level = 1;`):

```csharp
// trước — hai field, cả hai sai, im lặng
reference.fakeValueActive = false;
level = (ObscuredInt)obj;              // obj = default(ObscuredInt), nên level = 0

// sau — một field đúng, một field đúng nguồn với cast bị đánh dấu
level.fakeValueActive = obscuredInt.fakeValueActive;
level = (ObscuredInt)obscuredInt.currentCryptoKey;
```

Đây đúng là điều CLAUDE.md đã ghi ở chỗ khác: *phục hồi được nhiều hơn thì con số đếm cái-không-phục-
hồi-được đi lên*. Một giá trị sai im lặng trở thành một giá trị đúng kèm một chẩn đoán nhìn thấy được.
Vẫn phải ghi là một cái giá, không được gộp vào phần lãi.

## 6. Đã đo và loại — đừng làm lại nếu chưa sửa phía đích

**Nới lệnh đọc ở offset 0 thành cả giá trị.** Offset 0 là offset duy nhất nhập nhằng: địa chỉ của một
struct và địa chỉ field đầu tiên của nó là cùng một con số, và độ rộng truy cập không sống sót để nói
cái nào. Ý tưởng là để phía đích quyết định — đích kiểu `T` thì đọc cả `T`, đích kiểu của thành viên
thì đọc thành viên.

Ba lần đặt pass và **cả ba lần kết quả giống hệt từng con số** (2773 load, REAL_ERROR 861,
mangled_ctor 7), tức là nó không bao giờ chạy:

1. Ngay sau `ResolveTypesAndFields` — ở đó đích còn là một local chưa có kiểu.
2. Sau copy propagation — ở đó local đã bị gán kiểu `Int32` **từ chính lệnh đọc hẹp**, nên hai đầu
   "khớp" nhau và luật không có gì để sửa.
3. So kiểu **theo tên thay vì theo tham chiếu** (đúng bài học `CopyCoalescer` trong CLAUDE.md) — vẫn
   không chạy, vì nguyên nhân là (2) chứ không phải phép so sánh.

Và dạng *sẽ* chạy được thì **không đúng**: đi ngược chuỗi copy từ lệnh 20 về lệnh 8 rồi nới nguồn
thành `v10` là lấy một khiếm khuyết phía đích mà bóp méo phía nguồn — tuyên bố máy đã ghi 24 byte
trong khi nó ghi 4. Đã bỏ. Việc cần làm là phân giải đích thành `this.level.currentCryptoKey`.

## 7. Còn lại của DECOMP-0022

| nhóm | số (036) | trạng thái |
|---|---:|---|
| buffer trả về gián tiếp (X8) | 121 → 10 | **xong** |
| X29 trong `OrderedDictionary<TKey,TValue>` | 56 | cần thông tin runtime — xem FRAME_SLOT_ANALYSIS mục A |
| X29 khác (`Extensions`, `CollectionExtensions`, …) | 33 | spill thường, chưa làm |

10 load X8 còn lại là các buffer bị điều kiện 2 hoặc 3 loại ra (dùng lại, hoặc slot bị ghi dưới tên
riêng trước lệnh gọi). Đó là các điểm dừng đúng: một load được báo còn hơn một giá trị sai im lặng.

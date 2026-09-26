# `this + 0x20`: provenance của các receiver `List<T>.Add` không phải là list

Iteration 059 phân loại 16 receiver của `List<T>.Add` là `this + 0x20` và kết luận
chúng **không** phải element address. Brief của iteration 060 yêu cầu truy nguyên
chúng tới tận nơi: native pointer → provenance → offset → field layout → declaring
type, và cấm xử lý chúng bằng một special case trong `InlineListAddRecovery`.

Báo cáo này ghi lại kết quả. Mỗi khẳng định mang một nhãn:
`PROVEN` (suy ra được từ dữ liệu trong binary hoặc metadata),
`MEASURED` (số đo trên một bản rip cụ thể),
`INFERRED` (suy luận hợp lý, chưa có bằng chứng trực tiếp),
`UNKNOWN`, `BLOCKED`.

## 1. Giả thuyết ban đầu đã sai

Giả thuyết đầu tiên là compiler dùng lại thanh ghi: một local từng giữ receiver
rồi sau đó giữ một list mới, và `PointerClassifier` đi ngược qua một `Move` nên
thừa kế nhầm provenance `This`. Một luật "bản sao vào local có kiểu khác là dùng
lại thanh ghi" đã được viết, có test, và test đó phân biệt được (bỏ luật đi thì
test đỏ).

**`PROVEN`: giả thuyết đó sai.** Bằng chứng là chính chuỗi định nghĩa. `ChainOf`
in mọi bước của đường đi từ receiver về định nghĩa, không dừng ở local có kiểu
đầu tiên, và trên Merge-Room nó đọc:

```
v1350[isThis=False][System.Collections.Generic.List`1<UnityEngine.UI.Text>]
    <-Add  this[isThis=True][Tayx.Graphy.Advanced.G_AdvancedData]<-nothing
```

Không có `Move` nào trong chuỗi. Định nghĩa duy nhất của receiver là một `Add`
mà toán hạng thứ nhất chính là local mang cờ `IsThis`. Nên provenance `This` là
**đúng**: giá trị thật sự là `this` cộng một hằng số. Luật dùng lại thanh ghi
không bao giờ chạy cho họ này và đã bị gỡ bỏ cùng test của nó.

Bài học lặp lại: đo tại điểm quyết định trước khi tin một chẩn đoán, dù chẩn đoán
đó đã được ghi ở hai chỗ.

## 2. `this + <hằng số>` thật sự là gì

**`PROVEN`: đó là đối số địa chỉ field của `il2cpp_codegen_write_barrier`.**

il2cpp phát ra một write barrier sau mỗi lần ghi reference vào heap object, với
địa chỉ của chính ô vừa ghi:

```
str x2, [x0, #0x20]     ; this.field = value
add x0, x0, #0x20       ; &this.field
bl  <write barrier>
```

Trên mọi fixture ARM64, `BaseKeyFunctionAddresses.GetWriteBarrier` trả về 0 —
nó chỉ được cài cho x86. Lời gọi barrier do đó thành placeholder
`Method not found @179CDFC` trên Merge-Room, và phép cộng địa chỉ nuôi nó không
chết theo vì lời gọi vẫn còn đó tiêu thụ nó. Trong C# xuất ra, điều này hiện lên
nguyên văn:

```csharp
_ = (nint)this + 112;
m_graphyManager = componentInChildren;
Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @179CDFC");
```

Khi một lời gọi khác về sau đọc thanh ghi đó — và một lời gọi chưa giải quyết
được giữ cả tệp thanh ghi làm đối số, như CLAUDE.md đã ghi — giá trị `this + 0x20`
còn sót lại trở thành receiver của nó. Đó là toàn bộ họ này.

**`PROVEN`: địa chỉ khớp.** Sau khi cài `GetWriteBarrier` cho A64, key function
report in `il2cpp_codegen_write_barrier=0x179CDFC` — đúng bằng địa chỉ vẫn xuất
hiện trong placeholder.

## 3. Sửa ở tầng đầu tiên nơi hai nghĩa khác nhau

Tầng đó không phải `InlineListAddRecovery`, cũng không phải `PointerClassifier`.
Nó là chỗ runtime helper được định vị. Xem
`Source/External/Cpp2IL.Core/Il2CppApiFunctions/NewArm64KeyFunctionAddresses.cs`.

Barrier không được export và không có managed method nào nằm trên nó, nên nó được
tìm qua hình dạng call site, bằng hai đường độc lập:

- **corlib anchor** — đường x86 vốn có: các method corlib được biết là ghi một
  reference vào field, nên thân hàm của chúng chứa lời gọi barrier.
- **quét call site** — một phép đếm không cần disassembler trên mọi executable
  section. Mã A64 rộng cố định: `STR Xt, [Xn, #imm12]` là `1111100100`,
  `ADD Xd, Xn, #imm12` không shift là `1001000100`, và immediate của store được
  nhân tám còn của add thì không. Quét *mọi* section là bắt buộc, vì mã sinh ra
  nằm ở section tên `il2cpp` chứ không phải `.text`.

Hai đường bất đồng thì không lấy đường nào.

## 4. Kết quả đo

**`MEASURED`, Merge-Room** (`Test/Out60i-m` → `Test/Out60j-m`):

| số đo | trước | sau |
|---|---|---|
| placeholder | 40292 | 32385 |
| `METHOD_NOT_FOUND` | 11859 | 4914 |
| `UNMANAGED_MEMORY_LOAD` | 21224 | 20446 |
| EXACT | 8170 | 9591 |
| method không còn chỗ thay thế | 53,4% | 64,7% |
| dòng `_ = (nint)this + N;` còn lại | 5 | 0 |
| thân hàm mất (`Decompiling`) | 0 | 0 |

Bằng chứng định vị: 4064 call site có hình dạng barrier, đích đông thứ nhì 459,
3 trên 5 corlib anchor đồng ý.

`G_AdvancedData::Init` đi từ một thân hàm rải `_ = (nint)this + 112;`,
`string text = (string)((nint)array + 32);` và ba placeholder barrier, sang
`m_graphyManager = componentInChildren; ... array[0] = "CPU: ";`.

**`MEASURED`, ba fixture còn lại**: không đổi một chữ số nào.

| fixture | placeholder | EXACT | không còn chỗ thay thế |
|---|---|---|---|
| Impostor | 4293 → 4293 | 3782 → 3782 | 72,9% → 72,9% |
| RunFromZombies | 5962 → 5962 | 2515 → 2515 | 68,9% → 68,9% |
| JellyBlastV2 | 38236 → 38236 | 2867 → 2867 | 39,4% → 39,4% |

**`PROVEN`: trên ba fixture đó bằng chứng không đủ, và luật đã được siết để từ
chối.** Impostor và RunFromZombies đo 76 call site so với đích đông thứ nhì 75 —
một site chênh lệch — và **không** corlib anchor nào đồng ý. JellyBlastV2 thì hai
đường trả lời hai địa chỉ khác nhau. Một đích thắng sít sao như vậy không phải
bằng chứng; nó là nhiễu của một hình dạng cũng khớp với mã thường. Luật hiện tại:
nếu corlib anchor không trả lời thì phép quét chỉ được chấp nhận khi có ít nhất
500 call site **và** gấp ít nhất bốn lần đích đông thứ nhì. Merge-Room đo 8,85
lần; hai fixture kia đo 1,01 lần.

**`INFERRED`: ba bản build đó tắt write barrier, hoặc inline nó.** Phù hợp với
việc chúng không có họ `Method not found` nào đông tương đương, và với việc kết
quả không đổi khi địa chỉ sít sao kia từng được nhận. Chưa kiểm chứng trực tiếp
từ cờ build.

## 5. Còn lại

**`MEASURED`**: sau khi barrier được nhận, họ `this + 0x20` trong danh sách từ
chối của `InlineListAddRecovery` trên Merge-Room cần được đếm lại; xem
`LIST_ADD_GUARD_TERMINATORS.md`.

**`UNKNOWN`**: trên ba fixture kia, vì sao hình dạng barrier chỉ xuất hiện 76 lần.
Câu trả lời cần đọc cờ build của il2cpp, không có trong bản rip.

**`BLOCKED`**: không có khẳng định runtime nào ở đây. Unity không tồn tại trong
container; mọi kết quả trên là đo trên artefact, không phải trên game đang chạy.

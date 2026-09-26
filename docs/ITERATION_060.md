# Iteration 060 — storage provenance, và ba tầng nơi nghĩa của binary khác nghĩa phục hồi

Nhãn dùng trong tài liệu này: `PROVEN` (suy ra được từ binary hoặc metadata),
`MEASURED` (số đo trên một bản rip cụ thể), `INFERRED`, `UNKNOWN`, `BLOCKED`.

## Tóm tắt

Brief §25 yêu cầu tìm lỗi có dạng *nghĩa của binary ≠ nghĩa của bản phục hồi* và
sửa ở tầng đầu tiên nơi hai nghĩa bắt đầu khác nhau. Iteration này tìm được ba,
và cả ba đều nằm ở tầng thấp hơn chỗ triệu chứng xuất hiện.

| # | Lỗi | Tầng | Merge-Room: placeholder |
|---|---|---|---|
| 1 | `il2cpp_codegen_write_barrier` chưa bao giờ được định vị trên ARM64 | định vị runtime helper | 40292 → 32385 |
| 2 | virtual dispatch ở vị trí tail call không được giải quyết | `MetadataResolver` | 32338 → 28278 |
| 3 | generic virtual dispatch đọc slot lúc chạy không được nhận diện | pass mới | 28278 → 26309 |

Kèm một `MEASUREMENT_CHANGE` bắt buộc phải báo riêng, và hai kết quả âm được ghi
lại thay vì im lặng.

## 1. Write barrier trên ARM64

`BaseKeyFunctionAddresses.GetWriteBarrier` chỉ được cài cho x86; lớp cơ sở trả về
0 cho mọi kiến trúc khác. Hệ quả không phải một placeholder: mỗi lần ghi reference
vào field, lời gọi barrier thành `Method not found` và phép tính địa chỉ field nó
nhận được sống sót theo, rồi nằm lại trong thanh ghi mà lời gọi kế tiếp đọc. Đó là
nguồn của các receiver `List<T>.Add` đọc thành `this + 0x20`, và của các dòng
`_ = (nint)this + 112;` rải khắp bản phục hồi.

Barrier được tìm qua hình dạng call site bằng hai đường độc lập — corlib anchor
(đường x86 vốn có) và một phép quét không cần disassembler trên mọi executable
section. Chi tiết và bằng chứng: `reports/THIS_OFFSET_PROVENANCE.md`.

**`MEASURED`**: chỉ Merge-Room có barrier (4064 call site so với đích đông thứ nhì
459, 3/5 anchor đồng ý). Ba fixture kia đo 76 so với 75 hoặc hai đường bất đồng, và
luật đã được siết để từ chối — bản rip Impostor giống hệt trước và sau khi siết,
tới từng byte.

## 2. Virtual dispatch ở vị trí tail call

Một method mà câu lệnh cuối là virtual call biên dịch thành `br` qua vtable chứ
không phải `bl`. `ResolveVirtualCalls` và `ResolveMethodInfoPointerCalls` chỉ nhìn
`OpCode.IndirectCall`. `DelegateInvokeRecovery` đã phải học điều này cho nửa
delegate của cùng họ ở iteration 051; hai resolver kia thì không.

**`MEASURED`**: `INDIRECT_JUMP` trên Merge-Room 1849 → 381; `UNMANAGED_MEMORY_LOAD`
20446 → 17894. Cả bốn fixture đều cải thiện.

## 3. Generic virtual dispatch

Một virtual call *generic* không thể có slot hằng số, vì thân hàm được chia sẻ giữa
các instantiation. Compiler đọc `method->slot` ra từ chính metadata usage mà call
site đã nêu, index vtable của receiver, rồi đưa override tìm được cùng MethodInfo
của generic method cho một runtime helper để inflate. Lời gọi đi qua kết quả helper.

**`PROVEN`**: phép đọc slot và usage đưa cho helper nêu cùng một method — không có
gì khác trong một thân hàm làm vậy. Địa chỉ helper không bao giờ được dùng, nên
không phụ thuộc vào việc đặt tên nó.

`ES3Type_BoxCollider::ReadComponent` quay về `reader.Read<Vector3>()`,
`reader.Read<bool>()`, `reader.Read<PhysicMaterial>()`.

## MEASUREMENT_CHANGE — không phải cải thiện recovery

`recovery_metrics.py` nhận một allocation ở phía C# bằng từ khoá `new`. C# có bốn
cách viết cùng phép cấp phát delegate và chỉ một cách nói `new`: lambda, anonymous
method, method group, constructor. Ba cách kia bị đếm là mất một allocation — 415
method trên Merge-Room, recovery đã trả lại đủ cả 415.

Mọi so sánh với một iteration từ 060 trở về trước phải đo lại cả hai đầu. Chi tiết
trong commit `MEASUREMENT_CHANGE`.

## Hai kết quả âm, ghi lại thay vì im lặng

**Luật "bản sao vào local có kiểu khác là dùng lại thanh ghi"** trong
`PointerClassifier`: viết xong, có test phân biệt được, và **bác bỏ bằng dữ liệu**.
Chuỗi định nghĩa cho thấy receiver được định nghĩa bởi một `Add` trên chính local
mang cờ `IsThis`, không có `Move` nào cả. Luật và test của nó đã bị gỡ.

**Phép đi ngược qua các block thẳng hàng** trong `InlineListAddRecovery`: không bao
giờ bước được một bước, vì guard có một successor và *nhiều* predecessor — một điểm
hợp lưu, không phải một chuỗi. Phép đo đặt ngay sau nó cũng chết vì cùng lý do và
luôn in "không có nhánh điều kiện trong tám block". Cả ba đã bị gỡ.

## Số đo cuối

**`MEASURED`**, so với baseline của iteration 059 (0 lỗi `Decompiling` ở mọi đầu):

| fixture | placeholder | EXACT | không còn chỗ thay thế |
|---|---|---|---|
| Merge-Room | 40292 → 26309 | — → 11131 | — → 74,7% |
| Impostor | 4293 → 4137 | 3782 → 4011 | 72,9% → 77,2% |
| RunFromZombies | 5962 → 4681 | 2515 → 2770 | 68,9% → 75,7% |
| JellyBlastV2 | 38236 → 37290 | 2867 → 3005 | 39,4% → 41,3% |

Cột EXACT của Merge-Room không có số "trước" so sánh được, vì phép đo EXACT đã đổi
giữa chừng; xem MEASUREMENT_CHANGE ở trên.

Golden corpus được đóng băng lại ở cuối iteration, cố ý và có ghi lại: phép đo đổi
nên baseline cũ không còn so sánh được. 887 entry, 531 cập nhật, 0 thêm, 0 mất.
Ba regression mang từ trước (`CinemachineCollider`, `MMSpawnAround`,
`DictionaryKeyUtility`) có mặt cả khi đo chính bản rip của iteration 059, nên
không phải do iteration này; chúng được đóng băng ở trạng thái hiện tại và vẫn là
hạng mục mở.

## `BLOCKED`

Unity không tồn tại trong container. Không một khẳng định runtime nào trong
iteration này; mọi số đo là trên artefact, không phải trên game đang chạy.

## Phần của brief chưa làm

§3–§5 `StorageLocation` với alias/lifetime; §9–§13 shader variant fidelity và
`ICompiledShaderProgram`; §14–§15 value flow trong behaviour contract; §17–§18
`RuntimeScenario`. Iteration này dành toàn bộ ngân sách cho §7, §8 và §25, vì §7
truy ra một khiếm khuyết ở tầng định vị runtime helper và từ đó mở ra hai khiếm
khuyết cùng họ.

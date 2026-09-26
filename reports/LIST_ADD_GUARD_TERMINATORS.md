# `List<T>.Add`: phân loại các site bị từ chối theo terminator thật của guard

Brief của iteration 060 §8 yêu cầu: không sửa recognizer ngay, mà trước tiên phân
loại toàn bộ các site bị từ chối theo *terminator thật sự* của block guard, và chỉ
sửa những loại mà bằng chứng native hoặc CFG chứng minh có một cách hiểu ngữ nghĩa
rõ ràng. Cấm biến element address thành receiver của list.

Nhãn: `PROVEN`, `MEASURED`, `INFERRED`, `UNKNOWN`, `BLOCKED`.

## 1. Vì sao phải đặt tên theo terminator

`InlineListAddRecovery` nhận diện một `List<T>.Add` đã bị inline bằng chỗ neo là
lời gọi `AddWithResize` — hàm private mà framework chỉ gọi từ `Add` — rồi kiểm tra
hình dạng CFG quanh nó trước khi xoá fast path. Lý do từ chối cũ viết là "guard
không kết thúc bằng một nhánh điều kiện", tức là một *triệu chứng*. Dự án này đã
phải tách một họ đặt tên theo triệu chứng bảy lần; lần nào nguyên nhân cũng nằm ở
một cột khác với cột đặt tên.

Lý do từ chối nay nêu opcode kết thúc block, số successor và số predecessor.

## 2. Số đo

**`MEASURED`, Merge-Room, khi `il2cpp_codegen_write_barrier` *chưa* được định vị**
(`Test/Out60i-m`, 1346 candidate, 820 nhận diện, 526 từ chối):

| số site | terminator của guard |
|---|---|
| 44 | `CallVoid`, 1 successor |
| 14 | block rỗng, 1 successor |
| 14 | `Call`, 1 successor |
| 10 | `Move`, 1 successor |
| 2 | `Jump`, 1 successor |
| **84** | tổng |

**`PROVEN`: không có site nào trong 84 site đó nằm cuối một chuỗi block thẳng
hàng.** Một phép đi ngược qua các block "một đường vào, một đường ra" đã được viết
và đo: nó không bước được một bước nào. Lý do nằm ở phía predecessor chứ không
phải phía terminator — guard có đúng một successor nhưng *nhiều* predecessor, tức
là một điểm hợp lưu. Cả phép đi ngược lẫn phép viết lại dựa trên nó đều đã bị gỡ;
xem commit `[Iteration 060] chỉ nhận write barrier khi biên độ đủ lớn`.

**`MEASURED`, cùng fixture, sau khi write barrier được định vị** (`Test/Out60k-m`,
1020 candidate, 828 nhận diện, 192 từ chối):

| số site | terminator của guard |
|---|---|
| 6 | `Call`, 1 successor, 1 predecessor |
| **6** | tổng |

84 xuống 6, và số candidate xuống 1346 → 1020 vì scaffolding của barrier mang theo
mã chết khi biến mất.

**`PROVEN`: họ này không phải một khiếm khuyết của recognizer.** Nguyên nhân nằm
ở tầng định vị runtime helper, cách recognizer nhiều tầng. Mỗi lần ghi reference
vào field, lời gọi barrier chưa giải quyết được chia block ở giữa một guard và giữ
lại phép tính địa chỉ field, nên block chứa phép thử capacity kết thúc bằng
`CallVoid` thay vì bằng nhánh điều kiện. Không có thay đổi nào trong
`InlineListAddRecovery` gây ra kết quả này.

## 3. Họ `this + 0x20` đã biến mất

**`MEASURED`**: trong bản dump lý do từ chối của `Test/Out60i-m` có 10 dòng mang
phân loại `This/ObjectRelative this+32` hoặc `this+248` / `this+256`, tổng 20 site,
trên `Tayx.Graphy.Advanced.G_AdvancedData::Init` và
`MoreMountains.Tools.FloatController::FillDropDownList`. Trong bản `Test/Out60k-m`
không còn một dòng nào. Đây là cùng một nguyên nhân với mục 2; truy nguyên đầy đủ
ở `THIS_OFFSET_PROVENANCE.md`.

## 4. 192 site còn lại trên Merge-Room

**`MEASURED`**, gộp theo cột quyết định (180 trên 192 site nằm trong 25 lý do đông
nhất mà log in ra; bản dump đầy đủ qua `CPP2IL_DUMP_REJECTIONS`):

| số site | vì sao bị từ chối | có phải khiếm khuyết không |
|---|---|---|
| 64 | điều kiện nhánh là `CheckNotEqual` chứ không phải phép thử capacity — receiver là một call result hoặc một exception vừa cấp phát | **không**: đây là null check của il2cpp, không phải fast path của `Add` |
| 58 | fast path hoặc slow path có nhiều predecessor | `UNKNOWN`: vùng bị chia sẻ, xoá đi sẽ mang theo mã của nhánh khác |
| 44 | phép so sánh không đọc `_size` của chính receiver này | `UNKNOWN`: phần lớn là `memory+0x18` không gắn được vào receiver nào |
| 6 | guard kết thúc bằng `Call` | `UNKNOWN`, 6 site |

**`PROVEN`: nhóm 64 site không được viết lại.** Một `CheckNotEqual` trên một
`NullReferenceException` hoặc `OutOfMemoryException` vừa `newobj` là phần đuôi của
một injected check, không phải phép thử `_size < _items.Length`. Viết lại chúng sẽ
xoá một nhánh còn sống.

**`INFERRED`: nhóm 44 site là vấn đề gán kiểu, không phải vấn đề recognizer.** Lý
do in ra `CheckLess of memory+0x18 and memory+0x18` — nghĩa là cả hai vế đều là một
phép đọc bộ nhớ chưa được giải quyết thành field, nên không thể chứng minh chúng
thuộc về receiver. Khi phép đọc đó được giải quyết thành `_size` và `_items`, câu
hỏi tự trả lời. Chưa thử.

## 5. Điều đã *không* làm

**`PROVEN`**: không có element address nào bị biến thành receiver của list. Các
site có receiver là element address vẫn bị từ chối, với lý do nói rõ điều đó
("the fast path's own address in the receiver register").

**`PROVEN`**: recognizer không được nới. Số site nhận diện được đi từ 820 lên 828
hoàn toàn do write barrier được định vị; không một điều kiện nào của recognizer
được bỏ đi.

**`BLOCKED`**: không có khẳng định runtime. Unity không tồn tại trong container.

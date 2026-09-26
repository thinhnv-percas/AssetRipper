# `List<T>.Add`: các site bị từ chối, phân loại theo nguồn gốc của receiver

Iteration 058, §17. Số đếm ở `reports/INLINE_LIST_ADD.md`, sinh từ log của bốn bản rip `Test/AR58H-*`.
File này giải thích chúng.

## 1. Tiền đề của iteration 057 vẫn đúng, và nó không phải lỗi phân giải lời gọi

Iteration 057 truy vết 145 site bị từ chối trên Merge-Room và kết luận: receiver không phải một list,
nó là **địa chỉ của một phần tử mảng** — chính địa chỉ mà fast path tự tính ra, còn nằm trong thanh
ghi receiver. 058 xác nhận lại trên cả bốn fixture, với lý do từ chối nay nói ra điều đó:

| số lượng | receiver | nó thực sự là gì |
|---:|---|---|
| 133 | `Add of (Add …) and Immediate`, bên trong có `_items` | **địa chỉ phần tử** của mảng nền |
| 26 | `Add of local and Immediate` | cùng hình dạng, một bước copy xa hơn |
| 96 + 91 + 18 | `Newobj memory+0x0` | một cấp phát mà lời gọi constructor không hợp nhất được |
| 40 | `nothing holds the receiver, which is memory+0x0` | receiver chưa bao giờ nằm trong một local |
| 25 + 16 + 14 | `a local with no single definition` | hợp lưu của nhiều nhánh |

**Ba thứ phải phân biệt, và chúng khác nhau:**

- **list receiver** — cái mà pass nhận: một local mang chính đối tượng `List<T>`.
- **backing array** — `list._items`, một `T[]`. Nó xuất hiện *bên trong* phép so sánh capacity, và
  đó là bằng chứng hợp lệ; nhưng nó không phải receiver.
- **element address** — `_items + elementsOffset + (index << k)`, một con trỏ tới *một ô*. Nó có cùng
  kiểu tĩnh với backing array trong nhiều trường hợp, và đó là lý do nó đi lọt vào thanh ghi receiver.

## 2. Đây là khiếm khuyết ở phía ánh xạ đối số, không phải phía nhận diện

`MetadataResolver` không chọn `MethodsByAddress[address][0]` ở bất cứ đâu — iteration 057 đã kiểm và
057 ghi lại: `ResolveCalls` chỉ commit khi đúng một method nằm ở địa chỉ, `ResolveAmbiguousCalls`
khớp theo kiểu receiver qua chuỗi base, và `PreferredOf` chỉ chạy cho các candidate mà
`AreInterchangeable` thấy cùng chữ ký và dùng chung thân. Không có chỗ nào để "chọn sai".

Cái sai nằm sớm hơn: lời gọi `AddWithResize` được phân giải đúng, nhưng **toán hạng thứ nhất của nó**
— receiver — mang một giá trị mà chỉ tình cờ nằm trong thanh ghi đó. Đó là cùng một họ với
"một lời gọi chưa phân giải giữ cả tệp thanh ghi làm đối số", đã ghi trong `CLAUDE.md`.

**Pass từ chối là đúng.** Gấp một site như thế lại sẽ sinh ra `((List<T>)<địa chỉ phần tử>).Add(x)` —
biên dịch được, và sai. Nới lỏng recogniser là cách sai để lấy thêm 159 site.

## 3. Cái đúng để làm tiếp

Không phải nới recogniser mà là **sửa ánh xạ đối số**: khi toán hạng receiver của một lời gọi đã
phân giải là một địa chỉ phần tử, nó không phải đối số của lời gọi đó. `PointerProvenance` đã là phép
đi ngược đúng chỗ để hỏi câu đó, và `InlineListAddRecovery.DescribeReceiver` đã biết nhận ra hình
dạng — nó chỉ mới dùng để *báo cáo*.

## 4. 140 site "guard does not end in a conditional branch"

Nhóm lớn nhất, và nó không cùng họ với ba nhóm trên: khối guard kết thúc bằng một thứ khác
`ConditionalJump`. Chưa phân loại. Trước khi làm, hãy đếm nó theo *terminator thật sự* chứ không theo
tên triệu chứng — đây sẽ là lần thứ bảy dự án này phải tách một họ đặt tên theo triệu chứng.

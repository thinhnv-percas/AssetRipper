# `List<T>.Add` được inline — nhận diện và đặt lại tên

Iteration 056, §2 đến §8. Số liệu sinh từ `Test/Scripts/inline_list_add_report.py`; bản JSON kèm theo
là `reports/INLINE_LIST_ADD.json`.

## Giả thuyết

Iteration 055 đo `List<T>._size`, `._items` và `._version` **theo từng call site** thay vì theo tên
member, và kết luận: đó không phải ba recovery defect độc lập mà là **một** — đường nhanh của
`List<T>.Add` được il2cpp inline vào hàm gọi:

```csharp
_version++;
T[] array = _items;
int size = _size;
if ((uint)size < (uint)array.Length) { _size = size + 1; array[size] = item; }
else AddWithResize(item);
```

Hàm gọi vì thế gọi tên ba trường private của framework, thứ C# không cho phép. Iteration 056 đặt lại
cái tên đã mất, **ở tầng IR**, chứ không sửa `.cs` đã sinh.

## Neo là bằng chứng, các kiểm tra cấu trúc là hàng rào

`AddWithResize` là private của `List<T>` và framework gọi nó **từ `Add` và không từ đâu khác**. Một
call đã resolve tới nó gọi tên thao tác, receiver và giá trị bằng chính thứ binary mang theo — không
phải bằng một hình dạng đoán từ một lệnh ghi mảng. Đó là điều giữ mọi thứ khác ngoài họ này: một lệnh
ghi mảng thường, một collection tự viết, một indexer setter, `Insert`, `RemoveAt`, một lệnh ghi
dictionary — **không cái nào chạm tới pass**, vì không cái nào gọi `AddWithResize`.

Các kiểm tra control-flow/dataflow theo sau **không** định danh thao tác. Việc của chúng là xác lập
rằng vùng sắp bị xoá đúng là đường nhanh của *chính* receiver ấy:

1. block chứa call có đúng một predecessor, và predecessor ấy kết thúc bằng một nhánh hai chiều;
2. đường nhanh là successor còn lại, và chỉ cạnh đó tới được nó;
3. điều kiện của guard truy về một phép so sánh giữa `_size` của receiver và `Length` của mảng mà
   `_items` của receiver giữ;
4. đường nhanh ghi vào `_size` của chính receiver ấy.

**Và hàng rào đó đã bắt được một neo sai.** Trên Merge-Room, 159 trong 1346 candidate có receiver là
*một local được định nghĩa bằng `Add`* — một địa chỉ tính bằng số học con trỏ, không phải một list.
Địa chỉ của `AddWithResize` bị dùng chung (`CLAUDE.md`: "một địa chỉ method có thể bị dùng chung"),
nên một lệnh ghi phần tử và một write barrier cùng resolve về nó. Pass từ chối cả 159.

## Biểu diễn: không có opcode mới

`LIST_ADD` được biểu diễn bằng **một `CallVoid` tới chính `List<T>::Add`**, không bằng một opcode mới.
Một `Call` đã resolve là trừu tượng ngữ nghĩa tương đương và tốt hơn về mọi mặt: mọi pass phía sau —
dead code elimination, copy coalescing, lan truyền kiểu — đã xử lý đúng một call, còn một opcode mới
cần dạy lại sáu walker và bỏ sót một cái là im lặng (`CLAUDE.md`). Generator sinh `list.Add(value);`
mà không cần biết gì thêm.

## Vị trí trong pipeline

Sau `ArrayRecovery` và ngoài SSA. Cả hai đều bắt buộc: `items.Length` chỉ là một `ArrayLength` sau
`ArrayRecovery` (trước đó nó là một lệnh đọc ở offset), và ngoài SSA thì xoá đường nhanh không để lại
phi nào phải vá ở điểm hợp lưu — đúng vấn đề `InterfaceDispatchRecovery` đã phải tự tay gán 0.

## Kết quả

| fixture | candidate | matched | rejected | tỉ lệ |
|---|---:|---:|---:|---:|
| RunFromZombies | 160 | 130 | 30 | 81% |
| Impostor | 297 | 267 | 30 | 90% |
| Merge-Room | 1346 | 820 | 526 | 61% |
| JellyBlast v2 | 1252 | 870 | 382 | 69% |
| **tổng** | **3055** | **2087** | **968** | **68%** |

Lệnh đọc member private của `List<T>` còn lại trong thân hàm đã xuất:

| fixture | trước | sau | |
|---|---:|---:|---:|
| RunFromZombies | 304 | 46 | −85% |
| Impostor | 736 | 216 | −71% |
| Merge-Room | 1665 | 380 | −77% |
| JellyBlast v2 | 2648 | 988 | −63% |

Roslyn, trên assembly chịu ảnh hưởng nặng nhất của mỗi fixture:

| | trước | sau |
|---|---:|---:|
| Impostor `Assembly-CSharp` | 342 | **200** |
| JellyBlast `RayFireAssembly` | 4462 | **3457** |
| Merge-Room `Assembly-CSharp` | 6 | 6 |
| RunFromZombies `Assembly-CSharp` | 7 | 7 |

Hai fixture cuối không đổi vì `Assembly-CSharp` của chúng gần như không có site nào — 130 lần khớp
của RunFromZombies hầu hết nằm trong `Newtonsoft.Json`. **Đếm theo từng assembly trước khi kết luận
một thay đổi không làm gì.**

## False positive và false negative

**False positive: bị chặn bởi cấu trúc, không bởi việc soi tay.** Một site không gọi `AddWithResize`
không bao giờ tới được luật. Thứ còn kiểm được là phần dư: một thân hàm đã gấp phải không còn gọi tên
`_items`, `_size` hay `_version` của list ấy — và số dư ở bảng trên là phần *chưa* gấp, không phải
phần gấp sai. Không một site nào bị gấp mà receiver không được xác lập ở cả bốn kiểm tra.

**False negative: 968, mỗi cái dưới lý do của nó.** Bốn nhóm lớn nhất:

| số | lý do | đây là gì |
|---:|---|---|
| 159 | receiver là local định nghĩa bằng `Add` | neo sai — địa chỉ `AddWithResize` bị dùng chung. **Từ chối là đúng.** |
| ~200 | `CheckLess of memory+0x18 and memory+0x18` | hai bên đều chưa resolve thành field. Đây là công việc type recovery, không phải của pass này. |
| 136 | guard không kết thúc bằng nhánh hai chiều | đường nhanh đã bị gấp/xoá bởi pass khác, hoặc điều kiện đã bị hằng-số-hoá |
| ~110 | điều kiện là `CheckEqual`/`CheckNotEqual` | guard là một null check chứ không phải capacity test — `list = new List<T>(); list.Add(x)` |

## Kết quả âm đã đo — đừng làm lại

- **Mở rộng việc đi qua bản sao sang phía `_size`.** Trị giá **đúng bằng không** trên cả bốn fixture.
  Các trường hợp còn lại là local có **nhiều hơn một** định nghĩa, không phải local giữ một bản sao.
  (Việc đi qua bản sao ở phía `_items` thì có chạy và được giữ.)
- **Khớp receiver qua bản sao** (`AliasesOf` cho một receiver là local): cũng bằng không. Nhóm 159 mà
  nó nhắm tới không phải vấn đề bản sao mà là neo sai.
  Nhánh cho receiver **không phải local** (`this.cameras.Add(x)`) thì có chạy: +16 trên Merge-Room,
  +36 trên JellyBlast.

## Khung mở rộng (§8)

`InlineOperationRecovery` khai báo `Family` gồm `LIST_ADD`, `LIST_INSERT`, `LIST_REMOVE_AT`,
`LIST_CLEAR`, `DICTIONARY_ADD`, `HASHSET_ADD`, và `ImplementedFamilies` nói rõ **chỉ `LIST_ADD` có
luật**. Iteration 056 cố ý không thêm luật thứ hai: `Dictionary.Add` không có một helper riêng như
`AddWithResize` để làm neo — bằng chứng cho nó yếu hơn hẳn, và một luật đoán sẽ làm hỏng call site
một cách im lặng. Thêm luật thứ hai cần bằng chứng riêng của nó.

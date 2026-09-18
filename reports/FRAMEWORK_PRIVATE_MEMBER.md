# `FRAMEWORK_PRIVATE_MEMBER` — một `List<T>.Add` bị inline, không phải ba họ member

Iteration 055 đo lại cụm này ở mức từng *call site* chứ chỉ theo tên member, và cả ba tiền đề của
iteration 054 (cùng brief 055 §3, §4, §5) đều sai.

## Phân loại từng site, không phải từng tên

Đọc chính dòng nguồn mà Roslyn chỉ tới, 1627 lỗi trên JellyBlastV2 phân bố thành **đúng bốn hình
dạng**, không một ngoại lệ nào:

| số | member | hình dạng | dòng nguồn |
|---|---|---|---|
| 429 | `_items` | READ_WHOLE | `string[] items = list._items;` |
| 408 | `_version` | READ_WHOLE | `int version = list._version + 1;` |
| 398 | `_size` | STORE_WHOLE | `list._size = size;` |
| 392 | `_version` | STORE_WHOLE | `list._version = version;` |

Không có **một** lệnh đọc `_size` nào, và không có **một** lệnh đọc phần tử `_items[i]` nào.

## Vì sao ba tiền đề đều sai

**`_size` không phải recovery mistake, và phép ghép accessor *đang chạy*.** Một probe ghi lại quyết
định của `InstanceAccessorFor` cho từng field cho thấy `List<T>._size` **ghép thành công mọi lần**
(`asked, concrete=True` rồi `paired`), nên mọi lệnh *đọc* `_size` đã được viết thành `list.Count` từ
trước. `ReturnsNothingButTheField` không hề quá nghiêm ở đây: trên RunFromZombies chỉ có **16**
getter đọc đúng offset của field mình mà bị từ chối, và không cái nào là `_size`. 398 lỗi còn lại là
**lệnh ghi**, và `Count` là property chỉ đọc — không có setter để ghép.

**`_items` không cần indexer.** Cả 429 site đọc *toàn bộ* mảng nền vào một local, không index nó.
`this[int]` không diễn đạt được `string[] items = list._items;`, nên phép ghép indexer mà brief §4
yêu cầu sẽ khớp đúng **0** site — hình dạng "một pass không bao giờ chạy".

**Và cả bốn hình dạng là một method.** Đọc nguyên một site:

```csharp
int version = list._version + 1;
list._version = version;
string[] items = list._items;
if (list.Count < items.Length)          // <- _size đã thành Count, phép ghép có chạy
{
    int size = list.Count + 1;
    list._size = size;
    int num4 = list.Count << 3;         // index * sizeof(element)
    object obj4 = (nint)items + num4;
    object obj5 = (nint)obj4 + 32;      // + elementsOffset
    obj5 = obj2;                        // lệnh ghi phần tử, giá trị đã mất
}
else
    list.Add((string)obj2);             // <- nhánh chậm tự gọi tên Add
```

Đó là `List<T>.Add` bị inline, nguyên văn: bump version, đọc `_items` và `_size`, so với dung lượng,
ghi `_size + 1`, ghi phần tử, và nhánh chậm gọi `AddWithResize` mà generic sharing quy về `Add`.
Nhánh `else` **tự gọi tên `List<T>.Add`** — bằng chứng đối chiếu có ngay tại chỗ khớp.

## Cái gì thật sự là earliest wrong transformation

Không phải bốn phép ghép accessor. Là **lệnh ghi phần tử**:

```
num4 = Count << 3
obj4 = (nint)items + num4
obj5 = (nint)obj4 + 32
obj5 = value
```

Phép fold địa chỉ phần tử (`ComputedElementAddress`) không khớp hình dạng này vì `elementsOffset`
được cộng ở **một lệnh riêng** thay vì làm addend của memory operand, và mảng nằm trong một local
chứa kết quả đọc field. Vì thế `items[size] = item` biến thành số học native-int — và đó cũng chính
là cụm `NATIVE_INT_CAST` mà brief §7 nói tới. Hai hạng mục là **một** khiếm khuyết.

Chừng nào lệnh ghi phần tử còn chưa phục hồi được thì giá trị được thêm vào list vẫn mất, nên nhận
diện được cả vùng thành `list.Add(item)` cũng chỉ sinh ra `list.Add(<giá trị đã mất>)`. Sửa lệnh ghi
trước; nhận diện vùng sau.

## Không làm

Không nới accessibility của member framework. Không thêm setter cho `Count`. Không ghép indexer cho
một site đọc toàn bộ mảng. Không nhận diện vùng `Add` trước khi giá trị nó thêm vào còn phục hồi
được — làm ngược thứ tự chỉ đổi một lỗi biên dịch thành một lệnh gọi sai im lặng.

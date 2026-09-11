# 245 load qua một địa chỉ được lấy — phân loại, không phải đếm

Họ `untyped_base` có 245 load mà base được định nghĩa bởi `Move dest, AddressOf(x)`. Trước đây nó
được ghi là "frame-pointer spill" và xếp làm mục tiêu lớn nhất còn lại. Phân loại nó ra thì đó là
**ba thứ khác nhau**, và chỉ một trong ba là việc có thể làm bằng phân tích tĩnh hiện tại.

Số liệu lấy từ `iterations/033/reports/unresolved-loads.tsv`.

## Ba nhóm

| nhóm | số | bản chất | làm được? |
|---|---:|---|---|
| A. X29 trong thân generic chia sẻ hoàn toàn | 109 | slot cấp phát động, kích thước đọc từ `Il2CppClass.stack_slot_size` lúc chạy | **không** — cần thông tin runtime |
| B. X8/X27 trỏ vào một stack slot đã biết | 124 | `[&stack_-88 + k]` = chính slot ở offset `-0x88 + k` | **được** — số học trên layout frame, xem bên dưới |
| C. X29 trong thân không generic | 23 | spill thường | được, nhưng chỉ 23 |

## Nhóm A — cần thông tin runtime, và đây là bằng chứng

87 trong 109 nằm trong `Spine.Collections.OrderedDictionary<TKey,TValue>`, 12 nữa trong state
machine `<GetEnumerator>d__34` của nó. Đây là thân **fully shared generic**: một thân duy nhất dùng
cho mọi instantiation, với `TKey`/`TValue` là tham số kiểu thật sự chứ không phải placeholder có thể
suy ra.

Phần mở đầu của `OrderedDictionary.Insert` phục hồi ra như sau, và nó không phải rác:

```csharp
Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X8_v3 (Il2CppClass<TKey>)+FC]");
object obj2 = (nint)0 + (nint)15;
int num3 = (int)((nint)obj2 & 0x1FFFFFFF0L);      // làm tròn lên bội số 16
object obj3 = default(object);                     // SP
nint num4 = (nint)obj3 - num3;                     // SP -= size
Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X9_v1 (Il2CppClass<TValue>)+FC]");
...
Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
```

Offset `0xFC` của `Il2CppClass` là `stack_slot_size` (đọc từ `StructDb/2022.3.62f2-x64.json.gz`).
Trình tự này là **`alloca` lúc chạy**: đọc kích thước một ô stack cho `TKey` và cho `TValue`, làm
tròn lên 16, trừ vào SP, rồi `memset`. Kích thước — và do đó cả layout của những slot ấy — chỉ tồn
tại lúc chạy.

Nguồn đối chiếu (`spine-csharp/Collections/OrderedDictionary.cs:135`) là mười hai dòng:

```csharp
public void Insert (int index, TKey key, TValue value) {
    if (index < 0 || index > values.Count) throw new ArgumentOutOfRangeException(...);
    dictionary.Add(key, index);
    for (int keyIndex = index; keyIndex != keys.Count; ++keyIndex) { ... }
    keys.Insert(index, key);
    values.Insert(index, value);
    ++version;
}
```

`key` và `value` là giá trị có kiểu tham số. Trong thân chia sẻ chúng là các buffer stack cấp phát
động, và không có bằng chứng tĩnh nào nói chúng là kiểu gì — bởi vì chúng *không phải* một kiểu cố
định. Đây là điểm dừng hợp lệ cho nhóm này: **phân tích tĩnh hiện tại không cung cấp được thông tin
cần thiết.** 61 lệnh đọc `Il2CppClass.0xFC` trong bản rip đều thuộc trình tự này.

Việc *có thể* làm cho nhóm A, và là việc khác: nhận diện cả trình tự alloca như một khối scaffolding
runtime và bỏ nó đi, giống cách `TypeCheckRecovery` và `InterfaceDispatchRecovery` nhận diện phần
của chúng. Như thế thân hàm ngắn lại và dễ đọc hơn, nhưng các load qua slot vẫn không có kiểu — và
đó là đúng, vì chúng thật sự không có.

## Nhóm B — ĐÃ SỬA Ở ITERATION 036, VÀ PHÂN LOẠI DƯỚI ĐÂY SAI

> **Cảnh báo.** Phần còn lại của mục này giữ nguyên như khi viết, vì nó là ví dụ về một kết luận
> nghe hợp lý mà sai. Hai tiền đề của nó đều không đúng:
>
> - `X8` không phải "một thanh ghi trỏ vào stack slot". Trên AAPCS64 nó là **indirect result
>   register**, và `&stack_-88` ở đây là buffer cho một struct được **trả về qua bộ nhớ**.
> - Các slot đích (`stack_-84`, `stack_-80`, …) **không tồn tại**: không lệnh nào ghi chúng dưới tên
>   riêng, vì callee ghi cả khối. Nên không có version SSA nào để chọn — "cái khó duy nhất còn lại"
>   là một bài toán không có thật.
>
> Câu trả lời đúng là giá trị trả về của lệnh gọi, thứ mà chính lệnh gọi đã đặt tên, và nó **có
> kiểu** — điều số học trên slot không bao giờ cho được. Đếm lại theo thanh ghi của base: 121 trong
> 211 load đi qua X8 (buffer trả về, đã xử lý), 89 qua X29 (nhóm A và C thật sự).
> Xem `reports/INDIRECT_RETURN_BUFFER_ANALYSIS.md`.

## Nhóm B — làm được, và đây là cách (bản gốc, sai)

124 load còn lại không đi qua X29. Ví dụ sạch nhất là
`Spine.Unity.SkeletonGraphic.MatchRectTransformMultipleRenderers`:

```
119 Move v537 @ X8_v14, &v190 @ stack_-88_v3 (System.Single)
123 Move v522 @ stack_-88_v5 (System.Single), [v537 @ X8_v14]
124 Move v521 @ stack_-84_v5 (System.Single), [v537 @ X8_v14+4]
125 Move v520 @ stack_-80_v5 (System.Single), [v537 @ X8_v14+8]
126 Move v519 @ stack_-7C_v5 (System.Single), [v537 @ X8_v14+C]
127 Move v518 @ stack_-78_v5 (System.Single), [v537 @ X8_v14+10]
128 Move v517 @ stack_-74_v5 (System.Single), [v537 @ X8_v14+14]
```

Nguồn: `Bounds combinedBounds = ...; combinedBounds = bounds;` — một `Bounds` là 24 byte, hai
`Vector3`, tức sáu float ở offset 0x0, 0x4, 0x8, 0xC, 0x10, 0x14. **Khớp chính xác** các offset đọc
được. Đây là một phép copy struct mà máy làm bằng sáu lần load/store float.

Điểm quan trọng: **các slot đích đã có kiểu đúng** (`System.Single`), và tên slot mang chính offset
của nó — `StackAnalyzer.NameForSlot` sinh `stack_-88`, `stack_-84`, ... Nên
`&stack_-88 + 0x14` là **chính xác** `stack_-74`, bằng số học trên layout frame đã biết, không phải
suy đoán.

Vì thế nhóm này không phải bài toán gán kiểu. Nó là một phép viết lại operand:

> một lệnh đọc qua địa chỉ của một stack slot, với offset là hằng số, chính là stack slot ở
> `slotOffset + offset`.

Cái khó duy nhất còn lại là **chọn version SSA** của slot đích. Ở ví dụ trên, địa chỉ được lấy ở
version `stack_-88_v3` còn các slot được ghi ở `_v5`, nên đọc version nào là câu hỏi thật. Đây đúng
là vấn đề aliasing mà `SsaForm.RetargetAddressTakesOverwrittenBeforeUse` đã xử lý cho trường hợp
trong một block, và CLAUDE.md ghi rằng rộng hơn thì là bài toán aliasing tổng quát. Chọn sai version
tạo ra **một giá trị sai một cách im lặng**, tức loại lỗi duy nhất không được phép — nên việc này
phải làm cùng cơ chế đó, không phải bằng một luật mới đoán version.

Nhóm B là mục tiêu tiếp theo được khuyến nghị, với hai yêu cầu bắt buộc:

1. Chỉ viết lại khi offset là hằng số và slot đích tồn tại trong frame (tên slot khớp).
2. Version của slot đích phải lấy từ cùng cơ chế `RetargetAddressTakesOverwrittenBeforeUse` dùng,
   và nếu không xác định được thì **để nguyên placeholder** — một load được báo còn hơn một giá trị
   sai.

Ước lượng thận trọng: 124 load, cộng phần nào trong 23 load của nhóm C có cùng hình dạng.

## Nhóm C — 23 load, spill thường

Rải mỏng trên bảy method (`CollectionExtensions.ToOrderedDictionary` 7, `Extensions.Replace` 5,
`Extensions.ReplaceAll` 4, còn lại 1–2 mỗi method). Cùng hình dạng với nhóm B nhưng base là X29;
nếu cách viết lại của nhóm B được làm đúng thì phần lớn nhóm này đi theo.

## Trạng thái trên iOS

**KHÔNG KIỂM TRA ĐƯỢC.** Cả ba nhóm đều là kết quả của việc lift mã máy, và fixture iOS hiện tại có
`__TEXT` bị FairPlay mã hoá (xem `reports/IOS_INPUT_ANALYSIS.md`). Nhóm A phụ thuộc codegen của
il2cpp cho generic chia sẻ, về nguyên tắc giống nhau giữa hai nền tảng vì cùng il2cpp cùng version,
nhưng điều đó **chưa được kiểm chứng**. Nhóm B và C phụ thuộc register allocation và vị trí spill,
là những thứ compiler chọn và có thể khác nhau — đây chính là loại thay đổi mà brief yêu cầu kiểm
chứng chéo, và là loại không kiểm chứng được với fixture này.

Kiểm chứng chéo khả dụng: `Test/Input/Pinata` (x86, metadata v24.2). Nó khác cả kiến trúc lẫn
version nên vẫn bắt được phần lớn loại lỗi "đúng cho một codegen, sai cho codegen kia".

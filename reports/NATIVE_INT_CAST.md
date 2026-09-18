# `nint` cast theo producer, không theo mã lỗi

Iteration 055, §7. `NATIVE_INT_CAST` là cụm lỗi biên dịch lớn nhất trên ba trong bốn fixture, và
`Cannot convert type 'X' to 'nint'` là **cùng một thông điệp** dù giá trị bị cast là một con trỏ máy
thật sự có, một handle, một tham chiếu mà phép suy kiểu đánh mất, hay một địa chỉ metadata. Bốn thứ
đó cần bốn loại công việc khác nhau, nên cụm phải được tách theo *producer* trước khi có thể làm gì.

`Test/Scripts/cluster_native_int_casts.py` đọc chính cast trong C# đã sinh — chỗ cast nằm — và phân
loại theo hình dạng biểu thức bị cast cùng câu lệnh định nghĩa nó.

## Phân bố

| producer | JellyBlastV2 | RunFromZombies | là việc gì |
|---|---|---|---|
| `OBJECT_REFERENCE` | **9558** (55%) | **1440** (48%) | local khai báo `object` — ROADMAP mục 5 nhìn từ phía cast |
| `POINTER` | 2756 (16%) | 276 (9%) | số học địa chỉ máy thật sự có |
| `FIELD_ADDRESS` | 2079 (12%) | 205 (7%) | `(nint)this + n` — địa chỉ của field, không phải field |
| `UNKNOWN` | 1746 (10%) | 785 (26%) | chưa phân loại được |
| `ARRAY` | 825 (5%) | 46 (2%) | địa chỉ phần tử mà phép fold chưa với tới |
| `INTEGER` | 285 (2%) | 153 (5%) | cast mở rộng máy thật sự làm |
| `HANDLE` | 64 | 78 | `IntPtr`, cast là no-op decompiler viết ra |
| tổng | 17.313 | 2983 | |

## Cái đã sửa trong iteration này

Cụm `ARRAY` là nơi `FRAMEWORK_PRIVATE_MEMBER` và `NATIVE_INT_CAST` gặp nhau, và nó là **một** khiếm
khuyết chứ không phải hai. `(nint)items + (i << 3)` rồi `+ 32` rồi ghi là cách một `List<T>.Add` bị
inline ghi phần tử; `ComputedElementAddress` không khớp vì elements offset cộng ở một lệnh riêng thay
vì làm addend. Sau phép tháo (commit trước): **lệnh ghi phần tử phục hồi 676 → 903 trên
JellyBlastV2**, và `entry.Next = (Entry)next` + `next = entry` trên RunFromZombies thành
`entry.Next = array[num8]` + `array[num8] = entry`.

Phần `ARRAY` còn lại là những hình dạng địa chỉ phần tử khác; chúng cần cùng loại bằng chứng "hình
dạng tự chứng minh mảng là base" chứ không phải một affine evaluator — điều đó đã đo và **tệ hơn**
(CLAUDE.md, "Generalising the computed element address fold onto an affine evaluator").

## Cái không nên làm

`OBJECT_REFERENCE` là cụm lớn nhất và là cụm *duy nhất* đã có một kết quả âm ghi lại: gán kiểu cho
giá trị stand-in mà điểm bỏ cuộc đẩy ra (`ldnull` cho reference, `initobj` cho struct) đo **tệ hơn
trên mọi cột** — REAL_ERROR 1766 → 2007, Roslyn 456 → 548. Một native integer là thứ máy thật sự có,
và nói ra điều đó giữ sai lệch trong một biểu thức thay vì lan một tham chiếu vào số học. Cụm này
phải được sửa từ phía *nguồn* — làm cho load phân giải được — chứ không phải từ phía cast.

`FIELD_ADDRESS` 2079 phần lớn là đối số của write barrier: `il2cpp_codegen_write_barrier` vẫn chưa
định vị được (CLAUDE.md ghi từ iteration 049), nên lời gọi ấy sống sót và giữ số học địa chỉ sống
theo. Định vị được nó sẽ bỏ cả lời gọi lẫn số học — đó là đòn tiếp theo có giá trị nhất ở đây, và là
công việc key-function discovery chứ không phải công việc suy kiểu.
